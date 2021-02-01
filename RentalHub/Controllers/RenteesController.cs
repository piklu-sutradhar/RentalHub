using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalHub.Entities;

namespace RentalHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RenteesController : ControllerBase
    {
        private readonly RentalHubContext _context;

        public RenteesController(RentalHubContext context)
        {
            _context = context;
        }

        // GET: api/Rentees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rentee>>> GetRentees()
        {
            return await _context.Rentees.Include(r => r.Address).ToListAsync();
        }

        // GET: api/Rentees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rentee>> GetRentee(int id)
        {
            var rentee = await _context.Rentees.Include(r => r.Address).Where(r => r.Id == id).FirstOrDefaultAsync();

            if (rentee == null)
            {
                return NotFound();
            }

            return rentee;
        }

        // PUT: api/Rentees/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRentee(int id, Rentee rentee)
        {
            if (id != rentee.Id)
            {
                return BadRequest();
            }

            _context.Entry(rentee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RenteeExists(id))
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

        // POST: api/Rentees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Rentee>> PostRentee(Rentee rentee)
        {
            _context.Rentees.Add(rentee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRentee", new { id = rentee.Id }, rentee);
        }

        // DELETE: api/Rentees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rentee>> DeleteRentee(int id)
        {
            var rentee = await _context.Rentees.FindAsync(id);
            if (rentee == null)
            {
                return NotFound();
            }

            _context.Rentees.Remove(rentee);
            await _context.SaveChangesAsync();

            return rentee;
        }

        private bool RenteeExists(int id)
        {
            return _context.Rentees.Any(e => e.Id == id);
        }
    }
}
