using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalHub.Entities;
using RentalHub.Models;

namespace RentalHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly RentalHubContext _context;
        public ProfilesController(RentalHubContext context,UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateProfile([FromBody] Profile model)
        {
            return Ok();
        }
        // GET: api/Profiles/5
        [Authorize]
        [HttpGet("{userId}")]
        public async Task<ActionResult<ProfileViewModel>> GetProfile(string userId)
        {
            var profile = await _context.Profiles.Include(p => p.Address).Include(p => p.User).Where(p => p.UserId == userId).FirstOrDefaultAsync();

            if (profile == null)
            {
                return NotFound();
            }



            return  new ProfileViewModel
            {
                Id = profile.Id,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Email = profile.User.Email,
                AddressLine1 = profile.Address?.AddressLine1,
                AddressLine2 = profile.Address?.AddressLine2,
                City = profile.Address?.City,
                Province = profile.Address?.Province,
                Country = profile.Address?.Country,
                PostalCode = profile.Address?.PostalCode
            };
        }

        // PUT: api/Profiles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(string id, Profile profile)
        {
            if (id != profile.Id)
            {
                return BadRequest();
            }

            _context.Entry(profile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
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

        // POST: api/Profiles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Profile>> PostProfile(Profile profile)
        {
            _context.Profiles.Add(profile);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProfileExists(profile.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProfile", new { id = profile.Id }, profile);
        }

        // DELETE: api/Profiles/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Profile>> DeleteProfile(string id)
        {
            var profile = await _context.Profiles.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();

            var renter = await _context.Renters.Where(r => r.ProfileID == profile.Id).FirstOrDefaultAsync();
            if(renter != null)
            {
                _context.Renters.Remove(renter);
                await _context.SaveChangesAsync();
            }
            var user = await _userManager.FindByIdAsync(profile.UserId);
            await _userManager.DeleteAsync(user);

            return profile;
        }

        private bool ProfileExists(string id)
        {
            return _context.Profiles.Any(e => e.Id == id);
        }
    }
}
