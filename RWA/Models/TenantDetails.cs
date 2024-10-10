using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RWA.Models
{
    public class TenantDetails
    {
        public int Id { get; set; }  // Auto-incremented primary key
        public string TenantIdOriginal { get; set; } // Foreign key linked to Tenant
        public string TenPAN { get; set; }  // PAN of tenant
        public string TenAdhar { get; set; }  // Aadhar of tenant
        public string TenPoliceVer { get; set; }  // Police verification details

        // Mark Tenant as an optional relationship
        [ForeignKey("TenantIdOriginal")]
       // [JsonIgnore]  // Ignore in serialization
        public Tenant? Tenant { get; set; }
    }
}
