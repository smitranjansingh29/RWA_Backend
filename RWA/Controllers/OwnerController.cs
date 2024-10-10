using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Ensure this is added
using RWA.Data;
using RWA.Models;
using System.Threading.Tasks;

namespace RWA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly DataContext _context;

        public OwnerController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson(Owner owner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Owner created successfully" });
        }

        [HttpGet]
        public async Task<IActionResult> GetOwners()
        {
            var owners = await _context.Owners.ToListAsync();
            return Ok(owners);
        }
    }
}
