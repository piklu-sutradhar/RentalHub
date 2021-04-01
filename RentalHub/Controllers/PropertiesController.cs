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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly RentalHubContext _context;

        public PropertiesController(RentalHubContext context)
        {
            _context = context;
        }

        // GET: api/Properties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>> GetProperties()
        {
            return await _context.Properties.Include(r => r.Address).Include(r => r.Renter).ToListAsync();
        }

        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>> GetPropertiesOfRenter(int renterId)
        {
            return await _context.Properties.Include(r => r.PropertyAddress).Include(p => p.CurrentRentee).Where(p=> p.RenterId == renterId).ToListAsync();
        }*/

        // GET: api/Properties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> GetProperty(string id)
        {
            var @property = await _context.Properties.Include(p => p.Address).Where(p => p.Id == id).FirstOrDefaultAsync();

            if (@property == null)
            {
                return NotFound();
            }

            return @property;
        }

        // PUT: api/Properties/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProperty(string id, PropertyViewModel propertyViewModel)
        {
            Property _property = await _context.Properties.Include(p => p.Address).FirstOrDefaultAsync(p => p.Id == id);

            if (_property == null)
            {
                return NotFound();
            }

            _property.Title = propertyViewModel.Title;
            _property.Type = propertyViewModel.Type;
            _property.BedRooms = propertyViewModel.BedRooms;
            _property.Baths = propertyViewModel.Baths;
            _property.Available = propertyViewModel.Available;
            _property.Address.AddressLine1 = propertyViewModel.AddressLine1;
            _property.Address.AddressLine2 = propertyViewModel.AddressLine2;
            _property.Address.City = propertyViewModel.City;
            _property.Address.Province = propertyViewModel.Province;
            _property.Address.Country = propertyViewModel.Country;
            _property.Address.PostalCode = propertyViewModel.PostalCode;


            _context.Entry(_property).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(id))
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

        // POST: api/Properties
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Property>> PostProperty(Property @property)
        {
            _context.Properties.Add(@property);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProperty", new { id = @property.Id }, @property);
        }

        // DELETE: api/Properties/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Property>> DeleteProperty(int id)
        {
            var @property = await _context.Properties.FindAsync(id);
            if (@property == null)
            {
                return NotFound();
            }

            _context.Properties.Remove(@property);
            await _context.SaveChangesAsync();

            return @property;
        }

        private bool PropertyExists(string id)
        {
            return _context.Properties.Any(e => e.Id == id);
        }
    }
}
