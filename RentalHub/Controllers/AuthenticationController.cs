using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RentalHub.Entities;
using RentalHub.Models;

namespace RentalHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly RentalHubContext _context;

        public AuthenticationController(RentalHubContext context, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            string userType = model.UserType.ToString();
            if (!(await _roleManager.RoleExistsAsync(userType)))
            {
                await _roleManager.CreateAsync(new IdentityRole(userType));
            }
            var userExist = await _userManager.FindByNameAsync(model.UserName);

            if(userExist != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists"});
            }

            User user = new User()
            {
                UserName = model.UserName,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if(!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation has failed" });
            }

            await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(model.UserName), userType);
            Profile profile = new Profile
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                User = await _userManager.FindByNameAsync(model.UserName),
                Address = null
            };

            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();

            if(model.UserType == UserTypes.Renter)
            {
                Renter renter = new Renter { Id = Guid.NewGuid().ToString(), Profile = profile };

                _context.Renters.Add(renter);
                await _context.SaveChangesAsync();
            }
            return Ok(new Response { Status = "Success", Message = "Succesfully created the user"});
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if ( user != null && result.Succeeded)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                };

                foreach(var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JwtSecret")));

                var token = new JwtSecurityToken(
                    issuer : Environment.GetEnvironmentVariable("JwtValidIssuer"),
                    audience : Environment.GetEnvironmentVariable("JwtValidAudience"),
                    expires : DateTime.Now.AddHours(1),
                    claims : authClaims,
                    signingCredentials : new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha512Signature)
                    );

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(authClaims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenToReturn = tokenHandler.CreateToken(tokenDescriptor);

                return Ok(new
                {
                    token = tokenHandler.WriteToken(tokenToReturn),
                    user,
                    result
                });
            }
            return Unauthorized();
        }
    }
}
