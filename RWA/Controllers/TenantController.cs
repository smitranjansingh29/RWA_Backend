using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RWA.Data;
using RWA.Models;
using RWA.Services; // Assuming the SMTP service is available
using System.Linq;
using System.Threading.Tasks;
using System.Text; // For password generation
using System;

namespace RWA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly SmtpService _smtpService; // SMTP service for sending email

        public TenantController(DataContext context, SmtpService smtpService)
        {
            _context = context;
            _smtpService = smtpService;
        }

        [HttpPost]
        public async Task<IActionResult> AddTenant(Tenant tenant)
        {
            // Generate the TenantIdOriginal in the required format (e.g., TEN000001)
            var lastTenant = await _context.Tenants.OrderByDescending(t => t.TenantId).FirstOrDefaultAsync();
            int nextTenantId = (lastTenant != null) ? lastTenant.TenantId + 1 : 1;
            tenant.TenantIdOriginal = $"TEN{nextTenantId.ToString("D6")}"; // Generate TenantIdOriginal

            // Generate random alphanumeric password
            tenant.TenPassword = GenerateRandomPassword(8); // Example: Password length of 8

            // Send the email with credentials
            var message = $"Hello {tenant.TenName},\n\nYour login credentials are:\nEmail: {tenant.TenMail}\nPassword: {tenant.TenPassword}\n\nThank you!";
            await _smtpService.SendEmailAsync(tenant.TenMail, "Your Tenant Account Password", message);

            // Add the tenant to the database
            _context.Tenants.Add(tenant);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                tenant.TenantIdOriginal,
                tenant.TenName,
                tenant.TenFlatNum,
                tenant.TenPhoneNum,
                tenant.TenWhatsappNum,
                tenant.TenMail,
                tenant.TenLSD,
                tenant.Role
            });
        }



        // Method to generate a random alphanumeric password
        private string GenerateRandomPassword(int length)
        {
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder result = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                result.Append(validChars[random.Next(validChars.Length)]);
            }
            return result.ToString();
        }

        [HttpGet]
        public async Task<IActionResult> GetTenants()
        {
            var tenants = await _context.Tenants
                .Select(tenant => new
                {
                    tenant.TenantIdOriginal,
                    tenant.TenName,
                    tenant.TenFlatNum,
                    tenant.TenPhoneNum,
                    tenant.TenWhatsappNum,
                    tenant.TenMail,
                    tenant.TenLSD,
                    tenant.Role
                })
                .ToListAsync();

            return Ok(tenants);
        }

        [HttpGet("{tenantIdOriginal}")]
        public async Task<IActionResult> GetTenantByTenantIdOriginal(string tenantIdOriginal)
        {
            var tenant = await _context.Tenants
                .Where(t => t.TenantIdOriginal == tenantIdOriginal)
                .Select(t => new
                {
                    t.TenantIdOriginal,
                    t.TenName,
                    t.TenFlatNum,
                    t.TenPhoneNum,
                    t.TenWhatsappNum,
                    t.TenMail,
                    t.TenLSD,
                    t.Role
                })
                .FirstOrDefaultAsync();

            if (tenant == null)
            {
                return NotFound("Tenant not found.");
            }

            return Ok(tenant);
        }


    }
}
