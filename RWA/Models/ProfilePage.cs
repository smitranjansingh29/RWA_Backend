using System.ComponentModel.DataAnnotations.Schema;

namespace RWA.Models
{
    public class ProfilePage
    {
        public int Id { get; set; } // Auto-incremented primary key
        public string? TenantIdOriginal { get; set; } // Foreign key connected to TenantDetails
        public string? CoverPhoto { get; set; } // Path to cover photo file
        public string? ProfilePhoto { get; set; } // Path to profile photo file
        public string? Interests { get; set; } // User interests
        public string? Bio { get; set; } // Bio section
        public string? Work { get; set; } // Work details
        public string? Location { get; set; } // User's location

        // Foreign key reference to TenantDetails
        [ForeignKey("TenantIdOriginal")]
        public TenantDetails? TenantDetails { get; set; }
    }
}
