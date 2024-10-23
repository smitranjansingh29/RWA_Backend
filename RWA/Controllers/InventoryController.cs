using Microsoft.AspNetCore.Mvc;
using RWA.Models;
using RWA.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace RWA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly DataContext _context;

        public InventoryController(DataContext context)
        {
            _context = context;
        }

        // GET: api/inventory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetInventories()
        {
            return await _context.Inventories.ToListAsync();
        }

        // GET: api/inventory/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventory>> GetInventory(string id)
        {
            var inventory = await _context.Inventories.FindAsync(id);

            if (inventory == null)
            {
                return NotFound();
            }

            return inventory;
        }

        // POST: api/inventory
        [HttpPost]
        public async Task<ActionResult<Inventory>> PostInventory(Inventory inventory)
        {
            // Generate the InvProduct in the required format (e.g., INV000001)
            var lastInventory = await _context.Inventories.OrderByDescending(i => i.InvId).FirstOrDefaultAsync();
            int nextInventoryId = (lastInventory != null) ? lastInventory.InvId + 1 : 1;
            inventory.InvProduct = $"INV{nextInventoryId.ToString("D6")}"; // Generate InvProduct


            // Set the PurchaseDate to current date and time if it's not provided
            if (inventory.PurchaseDate == null || inventory.PurchaseDate == default(DateTime))
            {
                inventory.PurchaseDate = DateTime.Now;
            }


            // Add the inventory to the database
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInventory), new { id = inventory.InvProduct }, inventory);
        }

        // PUT: api/inventory/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventory(string id, Inventory inventory)
        {
            if (id != inventory.InvProduct)
            {
                return BadRequest();
            }

            _context.Entry(inventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Inventories.Any(e => e.InvProduct == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/inventory/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory(string id)
        {
            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }

            _context.Inventories.Remove(inventory);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
