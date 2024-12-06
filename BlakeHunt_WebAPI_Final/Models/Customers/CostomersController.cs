using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlakeHunt_WebAPI_Final.Data;
using BlakeHunt_WebAPI_Final.Models.customers;

namespace BlakeHunt_WebAPI_Final.Models.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostomersController : ControllerBase
    {
        private readonly CustomersdbContext _context;

        public CostomersController(CustomersdbContext context)
        {
            _context = context;
        }

        // GET: api/Costomers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<customers.Customer>>> GetCostomers()
        {
            return await _context.Costomers.ToListAsync();
        }

        // GET: api/Costomers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<customers.Customer>> GetCostomers(int id)
        {
            var costomers = await _context.Costomers.FindAsync(id);

            if (costomers == null)
            {
                return NotFound();
            }

            return costomers;
        }

        // PUT: api/Costomers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCostomers(int id, customers.Customer costomers)
        {
            if (id != costomers.CustId)
            {
                return BadRequest();
            }

            _context.Entry(costomers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CostomersExists(id))
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

        // POST: api/Costomers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<customers.Customer>> PostCostomers(customers.Customer costomers)
        {
            _context.Costomers.Add(costomers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCostomers", new { id = costomers.CustId }, costomers);
        }

        // DELETE: api/Costomers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCostomers(int id)
        {
            var costomers = await _context.Costomers.FindAsync(id);
            if (costomers == null)
            {
                return NotFound();
            }

            _context.Costomers.Remove(costomers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CostomersExists(int id)
        {
            return _context.Costomers.Any(e => e.CustId == id);
        }
    }
}
