namespace RWA.Models
{
    public class UserLoginRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }    // Required for email/password login
    }

    public class OtpLoginRequest
    {
        public string? Email { get; set; } // Required for both OTP sending and validation
        public string? PhoneNumber { get; set; } // Required only for sending OTP
    }

    public class OtpValidationRequests
    {
        public string? Email { get; set; } // Required for validating OTP
        public string? Otp { get; set; }   // Required for validating OTP
    }
}
