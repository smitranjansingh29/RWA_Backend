using RWA.Models;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationship between TenantDetails and Tenant using TenantIdOriginal
            modelBuilder.Entity<TenantDetails>()
                .HasOne(td => td.Tenant)
                .WithMany()  // Tenant doesn't need a navigation property to TenantDetails
                .HasPrincipalKey(t => t.TenantIdOriginal)  // Set TenantIdOriginal as the principal key
                .HasForeignKey(td => td.TenantIdOriginal)  // Set TenantIdOriginal as the foreign key
                .OnDelete(DeleteBehavior.Restrict);  // Optional: prevent cascading delete

            // Configure the relationship between ProfilePage and TenantDetails using TenantIdOriginal
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

            foreach (var tenant in tenants)
            {
                int maxTenantId = await Tenants.MaxAsync(t => (int?)t.TenantId) ?? 0;
                tenant.Entity.TenantIdOriginal = $"TEN{(maxTenantId + 1).ToString("D6")}";
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
