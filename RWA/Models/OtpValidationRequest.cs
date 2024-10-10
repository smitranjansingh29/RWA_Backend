using System.Text.Json.Serialization;

namespace RWA.Models
{
    public class OtpValidationRequest
    {
        public string Email { get; set; }
        public string Otp { get; set; }
    }
}
