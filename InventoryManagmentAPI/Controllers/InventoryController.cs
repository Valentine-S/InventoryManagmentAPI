using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagmentAPI.Models;

namespace InventoryManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly InvManageDBContext _context;

        public InventoryController(InvManageDBContext context)
        {
            _context = context;
        }

        // GET: api/Inventory
        [HttpGet]
        public async Task<ActionResult<InvResponse>> GetInventories()
        {
            var inventory = await _context.Inventory.ToListAsync();

            var response = new InvResponse();

            response.statusCode = 400;
            response.statusDescription = "NOT FOUND";

            
            if (inventory != null)
            {
                response.statusCode = 200;
                response.statusDescription = "FOUND";
                response.inventoryData = inventory;
            }
            return response;
        }

        // GET: api/Inventory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvResponse>> GetInventory(int id)
        {
            var inventory = await _context.Inventory.FindAsync(id);

            var response = new InvResponse();

            response.statusCode = 400;
            response.statusDescription = "NOT FOUND";
            
            if (inventory != null)
            {
                response.statusCode = 200;
                response.statusDescription = "FOUND";
                response.inventoryData.Add(inventory);
            }
            
            return response;
        }

        // PUT: api/Inventory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventory(int id, Inventory inventory)
        {
            if (id != inventory.InventoryId)
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
                if (!InventoryExists(id))
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

        // POST: api/Inventory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvResponse>> PostInventory(Inventory inventory)
        {
            _context.Inventory.Add(inventory);
            await _context.SaveChangesAsync();
            var response = new InvResponse();
            response.statusCode = 200;
            response.statusDescription = "Added";
            response.inventoryData.Add(inventory);
            //return CreatedAtAction("GetInventory", new { id = inventory.InventoryId }, inventory);
            return response;
        }

        // DELETE: api/Inventory/5
        [HttpDelete("{id}")]
        public async Task<InvResponse> DeleteInventory(int id)
        {
            var inventory = await _context.Inventory.FindAsync(id);

            var response = new InvResponse();

            if (inventory == null)
            {
                response.statusCode = 404;
                response.statusDescription = "The inventory item can not be found";
                return response;
            }

            _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();

            response.statusCode = 200;
            response.statusDescription = "Removed";
            response.inventoryData.Add(inventory);

            return response;
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventory.Any(e => e.InventoryId == id);
        }
    }
}
