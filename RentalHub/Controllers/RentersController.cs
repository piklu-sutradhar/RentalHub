using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalHub.Entities;
using RentalHub.Models;

namespace RentalHub.Controllers
{
    [Authorize(Roles = "Renter")]
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
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<Renter>>> GetRenters()
        {
            return await _context.Renters.Include(r => r.Profile).Include(r=>r.Properties).ToListAsync();
        }*/

        // GET: api/Renters/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<Renter>> GetRenter(string userId)
        {
            var renter = await _context.Renters.Include(r => r.Properties).Where(r => r.Profile.User.Id == userId).FirstOrDefaultAsync();

            if (renter == null)
            {
                return NotFound();
            }

            foreach(var property in renter.Properties)
            {
                if(property.ProfileId != null)
                    property.Rentee = await _context.Profiles.FindAsync(property.ProfileId);
                property.Address = await _context.Addresses.FindAsync(property.AddressId);
            }
            return renter;
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> AddProperty(string id, PropertyViewModel model)
        {
            var renter = await _context.Renters.FindAsync(id);

            if (renter == null)
            {
                return NotFound("The renter is invalid");
            }

            var address = new Address
            {
                Id = Guid.NewGuid().ToString(),
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                City = model.City,
                Province = model.Province,
                Country = model.Country,
                PostalCode = model.PostalCode
            };

            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();

            Property property = new Property {
                Id = Guid.NewGuid().ToString(),
                Title = model.Title,
                Type = model.Type,
                BedRooms = model.BedRooms,
                Baths = model.Baths,
                Available = model.Available,
                Renter = renter,
                Address = address
            };

            _context.Properties.Add(property);
            await _context.SaveChangesAsync();

            return Ok("property added");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveRenterProperty(string id, string propertyId)
        {
            var renter = await _context.Renters.FindAsync(id);

            if (renter == null)
            {
                return NotFound("The renter is invalid");
            }

            var property = await _context.Properties.Include(p => p.Address).FirstOrDefaultAsync(p => p.Id == propertyId);
            if(property != null)
            {
                Address address = property.Address;
                if (address != null)
                {
                    _context.Addresses.Remove(address);
                    await _context.SaveChangesAsync();
                }
                _context.Properties.Remove(property);
                await _context.SaveChangesAsync();
            }
           
            return Ok("property removed");
        }

        // PUT: api/Renters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRenter(string id, Renter renter)
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
        /*[HttpDelete("{id}")]
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
        }*/

        private bool RenterExists(string id)
        {
            return _context.Renters.Any(e => e.Id == id);
        }
    }
}
