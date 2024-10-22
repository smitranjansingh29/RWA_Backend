using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RWA.Models
{
    public class TenantDetails
    {
        public int? Id { get; set; }  // Auto-incremented primary key
        public string? TenantIdOriginal { get; set; } // Foreign key linked to Tenant
        public string? NameOfTenFather { get; set; }
        public string? TenPerAddress { get; set; }
        public string? TenCorAddress { get; set; }
        public DateTime? TenDOB { get; set; }  // Changed from DateOnly to DateTime for consistency
        public string? TenOcc { get; set; }
        public string? TenCaste { get; set; }
        public string? TenPAN { get; set; }  // PAN of tenant
        public string? TenAdhar { get; set; }  // Aadhar of tenant
        public string? TenPoliceVer { get; set; }  // Police verification details
         // Path to the uploaded PDF file

        // Additional Fields
        public string? AmtOfAnnFee { get; set; }
        public string? AmtOfMemFee { get; set; }
        public string? AnnFav { get; set; }
        public string? AnnFeesNumber { get; set; }
        public string? AnnYear { get; set; }
        public string? DateOfAnnFee { get; set; }
        public string? DateOfMemFee { get; set; }
        public string? DecisionDate { get; set; }
        public string? DecisionMemberAddress { get; set; }
        public string? DecisionMemberAge { get; set; }
        public string? DecisionMemberFather { get; set; }
        public string? DecisionMemberName { get; set; }
        public string? DecisionMemberType { get; set; }
        public string? DecisionPlace { get; set; }
        public string? MemAddress { get; set; }
        public string? MemAge { get; set; }
        public string? MemFatherName { get; set; }
        public string? MemFav { get; set; }
        public string? MemFeesNumber { get; set; }
        public string? MemName { get; set; }
        public string? RDate { get; set; }
        public string? RMemName { get; set; }
        public string? RMemNumber { get; set; }
        public string? RPlace { get; set; }
        public string? ResolutionNumber { get; set; }

        //file upload
        public string? CasteCert { get; set; }  // Optional, could be a file path
        public string? DeedCopy { get; set; }  // Optional, could be a file path
        public string? ProofDOBDoc { get; set; } // Optional,
        public string? TenPOA { get; set; }  // Power of Attorney (optional file)
        public string? TenPOI { get; set; }
        public string? TenPhoto { get; set; }  // Path to the uploaded tenant photo

        // Navigation property for Tenant (optional)
        [ForeignKey("TenantIdOriginal")]
        public Tenant? Tenant { get; set; }
    }
}

