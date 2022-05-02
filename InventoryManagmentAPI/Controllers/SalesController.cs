using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagmentAPI.Models;
using MySqlConnector;

namespace InventoryManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly InvManageDBContext _context;

        public SalesController(InvManageDBContext context)
        {
            _context = context;
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult<SaleResponse>> GetSales()
        {

            var sale = await _context.Sales.ToListAsync();

            var response = new SaleResponse();

            response.statusCode = 404;
            response.statusDescription = "NOT FOUND";

            if (sale != null)
            {
                response.statusCode = 200;
                response.statusDescription = "FOUND";
                response.saleData = sale;
            }
            return response;
        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaleResponse>> GetSale(int id)
        {
            var sale1 = await _context.Sales.FindAsync(id);

            var response = new SaleResponse();

            response.statusCode = 404;
            response.statusDescription = "NOT FOUND";
            
            if (sale1 != null)
            {
                response.statusCode = 200;
                response.statusDescription = "FOUND";
                response.saleData.Add(sale1);
            }
            return response;
        }

        // PUT: api/Sales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSale(int id, Sale sale)
        {
            if (id != sale.SaleId)
            {
                return BadRequest();
            }

            _context.Entry(sale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(id))
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

        // POST: api/Sales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SaleResponse>> PostSale(Sale sale)
        {
            var response = new SaleResponse();
            try
            {
                _context.Sales.Add(sale);
                await _context.SaveChangesAsync();
                //return CreatedAtAction("GetSale", new { id = sale.SaleId }, sale);
                response.statusCode = 201;
                response.statusDescription = "Added";
                response.saleData.Add(sale);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.statusDescription = "Duplicate Entry: {" +sale.InventoryId + "} for InventoryId or InventoryId does not exist. This item has already been sold, please choose a different inventory item.";
            }
            return response;
        }

        // DELETE: api/Sales/5
        [HttpDelete("{id}")]
        public async Task<SaleResponse> DeleteSale(int id)
        {
            var sale = await _context.Sales.FindAsync(id);

            var response = new SaleResponse();

            if (sale == null)
            {
                response.statusCode = 404;
                response.statusDescription = "The sale can not be found";
                return response;
            }

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();

            response.statusCode = 200;
            response.statusDescription = "Removed";
            response.saleData.Add(sale);

            return response;
        }

        private bool SaleExists(int id)
        {
            return _context.Sales.Any(e => e.SaleId == id);
        }
    }
}
