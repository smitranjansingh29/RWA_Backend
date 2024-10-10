using System;
using System.Collections.Generic;

namespace RWA.Services
{
    public class OtpService
    {
        private readonly Dictionary<string, string> _otpStorage = new Dictionary<string, string>();

        // Generate a numeric OTP
        public int GenerateOtp()
        {
            Random random = new Random();
            return random.Next(100000, 999999);  // Return as integer
        }

        // Store OTP as string for easier comparison later
        public void StoreOtp(string key, string otp)
        {
            _otpStorage[key] = otp;
        }

        // Validate OTP (compare as string)
        public bool ValidateOtp(string key, string otp)
        {
            return _otpStorage.ContainsKey(key) && _otpStorage[key] == otp;
        }
    }
}
