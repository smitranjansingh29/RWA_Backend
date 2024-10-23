using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace RWA.Models
{
    public class Inventory
    {
        [Key]
        [JsonIgnore]
        public int InvId { get; set; } 
        public string? InvProduct { get; set; } 
        public string? Category { get; set; }
        public string? InvProductName { get; set; }
        public string? InvProductDesc { get; set; }
        public string? InvProductPrice { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string? PurchaseWhere { get; set; }
        public string? PurchaseWarranty { get; set; }
        public string? PurchasePrice { get; set; }
    }
}
