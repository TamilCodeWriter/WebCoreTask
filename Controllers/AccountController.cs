using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebCoreTask.Data;
using WebCoreTask.Models;

namespace WebCoreTask.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AccountController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Manage()
        {
            // You can access the token parameter here if needed
            return View("../Employee/Manage");
        }

        [HttpPost]

        public async Task<IActionResult> Login(User model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users
                     .FirstOrDefaultAsync(u => u.Username == model.Username && u.Password == model.Password);

                if (user != null)
                {
                    // User credentials are valid, proceed with login logic
                    // Valid user
                    var token = GenerateJwtToken(model.Username);
                   // return Ok(new { Token = token });
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                    // User credentials are invalid, handle accordingly (e.g., display error message)
                }
               
            }

            return RedirectToAction("Manage");
        }

        private string GenerateJwtToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            byte[] key = KeyGenerator.GenerateRandomKey(32);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:ExpiryInMinutes"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
