using Microsoft.AspNetCore.Mvc;
using RWA.Data;
using RWA.Models;
using RWA.Services;
using System.Linq;
using System.Threading.Tasks;

namespace RWA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly OtpService _otpService;
        private readonly SmtpService _smtpService;
        private readonly Fast2SmsService _fast2SmsService;
        private readonly DataContext _context;

        public LoginController(OtpService otpService, SmtpService smtpService, Fast2SmsService fast2SmsService, DataContext context)
        {
            _otpService = otpService;
            _smtpService = smtpService;
            _fast2SmsService = fast2SmsService;
            _context = context;
        }

        [HttpPost("sendOtp")]
        public async Task<IActionResult> SendOtp([FromBody] OtpLoginRequest request)
        {
            var tenant = _context.Tenants.FirstOrDefault(t =>
                t.TenMail == request.Email && t.TenPhoneNum == request.PhoneNumber);

            if (tenant == null)
            {
                return Unauthorized("Phone number or email not found in the tenant records.");
            }

            var otp = _otpService.GenerateOtp();
            _otpService.StoreOtp(request.Email, otp.ToString());

            await _smtpService.SendEmailAsync(request.Email, "Your OTP", $"Your OTP is {otp}");
            await _fast2SmsService.SendSmsAsync(request.PhoneNumber, otp);

            return Ok("OTP Sent");
        }

        [HttpPost("validateOtp")]
        public IActionResult ValidateOtp([FromBody] OtpValidationRequests request)
        {
            if (_otpService.ValidateOtp(request.Email, request.Otp))
            {
                var tenant = _context.Tenants.FirstOrDefault(t => t.TenMail == request.Email);

                if (tenant == null)
                {
                    return Unauthorized("Email not found");
                }

                // Return tenant details, including TenantIdOriginal, after successful OTP validation
                return Ok(new
                {
                    message = "Login successful",
                    tenantIdOriginal = tenant.TenantIdOriginal,
                    tenantName = tenant.TenName,
                    email = tenant.TenMail
                });
            }

            return BadRequest("Invalid OTP");
        }

        [HttpPost("loginWithPassword")]
        public IActionResult LoginWithPassword([FromBody] UserLoginRequest request)
        {
            var tenant = _context.Tenants.FirstOrDefault(t => t.TenMail == request.Email);

            if (tenant == null)
            {
                return Unauthorized("Email not found");
            }

            bool passwordIsValid = ValidatePassword(request.Password, tenant.TenPassword);

            if (!passwordIsValid)
            {
                return Unauthorized("Invalid password");
            }

            // Return tenant details, including TenantIdOriginal, after successful login
            return Ok(new
            {
                message = "Login successful",
                tenantIdOriginal = tenant.TenantIdOriginal,
                tenantName = tenant.TenName,
                email = tenant.TenMail
            });
        }

        private bool ValidatePassword(string inputPassword, string storedPassword)
        {
            return inputPassword == storedPassword;
        }
    }
}
