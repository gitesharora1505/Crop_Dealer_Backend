using Crop_Dealer.Repository.AdminUser;
using Crop_Dealer.Repository.DealerUser;
using Crop_Dealer.Repository.FarmerUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Crop_Dealer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAdminLogin adminLogin;
        private readonly IFarmerLogin farmerLogin;
        private readonly IDealerLogin dealerLogin;
        public AuthController(IConfiguration configuration, IAdminLogin adminLogin, IFarmerLogin farmerLogin,IDealerLogin dealerLogin)
        {
            _configuration = configuration;
            this.adminLogin = adminLogin;
            this.farmerLogin = farmerLogin;
            this.dealerLogin= dealerLogin;
        }
        [HttpPost("Farmer Login")]
        public IActionResult FarmerLogin(string email, string password)
        {
            var existingUser = farmerLogin.Login(email, password);
            if (existingUser == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, existingUser.FarmerId.ToString()),
                new Claim(ClaimTypes.Role,"Farmer")
            };

            var token = GenerateJwtToken(claims);
            return Ok(new { token ,existingUser.FarmerId });
        }
        [HttpPost("Dealer Login")]
        public IActionResult DealerLogin(string email, string password)
        {
            var existingUser = dealerLogin.Login(email, password);
            if (existingUser == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, existingUser.DealerId.ToString()),
                new Claim(ClaimTypes.Role,"Dealer")
            };

            var token = GenerateJwtToken(claims);
            return Ok(new { token });
        }
        [HttpPost("Admin Login")]
        public IActionResult AdminLogin(string email, string password)
        {
            var existingUser = adminLogin.Login(email, password);
            if (existingUser == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, existingUser.AdminId.ToString()),
                new Claim(ClaimTypes.Role,"Admin")
            };

            var token = GenerateJwtToken(claims);
            return Ok(new { token });
        }
        private string GenerateJwtToken(Claim[] claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
