using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RWA.Data;
using RWA.Models;
using System.Threading.Tasks;

namespace RWA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantDetailsController : ControllerBase
    {
        private readonly DataContext _context;

        public TenantDetailsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddTenantDetails([FromBody] TenantDetails tenantDetails)
        {
            // Ensure that TenantIdOriginal exists in the Tenant table
            var tenant = await _context.Tenants
                .FirstOrDefaultAsync(t => t.TenantIdOriginal == tenantDetails.TenantIdOriginal);

            if (tenant == null)
            {
                return NotFound("Tenant with this TenantIdOriginal not found.");
            }

            // Link the existing tenant to the tenant details
            tenantDetails.Tenant = tenant;

            // Add the tenant details to the context
            _context.TenantDetails.Add(tenantDetails);
            await _context.SaveChangesAsync();

            return Ok(tenantDetails);
        }

        [HttpGet("{tenIdOri}")]
        public async Task<IActionResult> GetTenantDetailsByTenantIdOriginal(string tenIdOri)
        {
            // Use Include to load related Tenant data
            var tenantDetails = await _context.TenantDetails
                .Include(t => t.Tenant)  // Eagerly load the related Tenant entity
                .FirstOrDefaultAsync(t => t.TenantIdOriginal == tenIdOri);

            if (tenantDetails == null)
            {
                return NotFound("Tenant details not found.");
            }

            return Ok(tenantDetails);  // Return tenant details along with tenant data
        }
    }
}
