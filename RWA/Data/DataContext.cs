using RWA.Models;// Import the Inventory model
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RWA.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantDetails> TenantDetails { get; set; }
        public DbSet<ProfilePage> ProfilePages { get; set; }

        // New DbSet for Inventory
        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>()
                .HasKey(i => i.InvId);
            // Existing TenantDetails and ProfilePage configurations
            modelBuilder.Entity<TenantDetails>()
                .HasOne(td => td.Tenant)
                .WithMany()
                .HasPrincipalKey(t => t.TenantIdOriginal)
                .HasForeignKey(td => td.TenantIdOriginal)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProfilePage>()
                .HasOne(pp => pp.TenantDetails)
                .WithMany()
                .HasPrincipalKey(td => td.TenantIdOriginal)
                .HasForeignKey(pp => pp.TenantIdOriginal)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var tenants = ChangeTracker.Entries<Tenant>()
                                       .Where(t => t.State == EntityState.Added)
                                       .ToList();

            // Ensure TenantIdOriginal generation
            foreach (var tenant in tenants)
            {
                int maxTenantId = await Tenants.MaxAsync(t => (int?)t.TenantId) ?? 0;
                tenant.Entity.TenantIdOriginal = $"TEN{(maxTenantId + 1).ToString("D6")}";
            }

            // Inventory ID generation logic
            var inventories = ChangeTracker.Entries<Inventory>()
                                           .Where(i => i.State == EntityState.Added)
                                           .ToList();

            foreach (var inventory in inventories)
            {
                // Generate new InvProduct ID if not set
                if (string.IsNullOrEmpty(inventory.Entity.InvProduct))
                {
                    int maxProductId = await Inventories.MaxAsync(i => (int?)i.InvId) ?? 0;  // Assuming an `Id` field exists for the numeric part
                    inventory.Entity.InvProduct = $"INV{(maxProductId + 1).ToString("D6")}";
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
