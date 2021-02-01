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
    public class RentersController : ControllerBase
    {
        private readonly RentalHubContext _context;

        public RentersController(RentalHubContext context)
        {
            _context = context;
        }

        // GET: api/Renters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Renter>>> GetRenters()
        {
            return await _context.Renters.Include(r => r.Address).Include(r=>r.Properties).ToListAsync();
        }

        // GET: api/Renters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Renter>> GetRenter(int id)
        {
            var renter = await _context.Renters.Include(r => r.Address).Include(r => r.Properties).Where(r => r.Id == id).FirstOrDefaultAsync();

            if (renter == null)
            {
                return NotFound();
            }
            //renter.Address = await _context.Adresses.FindAsync(id);
            //renter.Properties = await _context.Properties.Where(p => p.RenterId == renter.Id).ToListAsync();

            return renter;
        }

        // PUT: api/Renters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRenter(int id, Renter renter)
        {
            if (id != renter.Id)
            {
                return BadRequest();
            }

            _context.Entry(renter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RenterExists(id))
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

        // POST: api/Renters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Renter>> PostRenter(Renter renter)
        {
            _context.Renters.Add(renter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRenter", new { id = renter.Id }, renter);
        }

        // DELETE: api/Renters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Renter>> DeleteRenter(int id)
        {
            var renter = await _context.Renters.FindAsync(id);
            if (renter == null)
            {
                return NotFound();
            }

            _context.Renters.Remove(renter);
            await _context.SaveChangesAsync();

            return renter;
        }

        private bool RenterExists(int id)
        {
            return _context.Renters.Any(e => e.Id == id);
        }
    }
}
