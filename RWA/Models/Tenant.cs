using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace RWA.Models
{
    public class Tenant
    {
        [JsonIgnore]
        public int TenantId { get; set; } // Tenant Id (int)
        //[JsonIgnore]
        public string? TenantIdOriginal { get; set; } // Tenant Id Original (e.g., TEN000001)
        public string TenName { get; set; } // Tenant Name
        public string TenFlatNum { get; set; } // Tower + Flat Number
        public string TenPhoneNum { get; set; } // Phone Number
        public string TenWhatsappNum { get; set; } // WhatsApp Number
        public string TenMail { get; set; } // Email Id
        public DateTime TenLSD { get; set; } // Lease Start Date
        public string Role { get; set; }

        [JsonIgnore]
        public string? TenPassword { get; set; } // Tenant Password (Generated in backend)

    }
}
