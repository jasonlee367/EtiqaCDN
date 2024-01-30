using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using EtiqaCDN.Models;
using EtiqaCDN.Models.User;
using EtiqaCDN.Models.UserDto;
using EtiqaCDN.Services.Interface;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace EtiqaCDN.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public static AspUser user = new AspUser();
        private readonly IConfiguration _config;
		private readonly IJWTManagerRepository _jWTManager;

		public AuthController(IConfiguration config, IJWTManagerRepository jWTManager)
        {
            _config = config;
			this._jWTManager = jWTManager;
		}
        

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto usersdata)
        {
			var token = _jWTManager.Authenticate(usersdata);

			if (token == null)
			{
				return Unauthorized();
			}

			return Ok(token);
		}

        private string CreateToken(AspUser user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "Admin")
             };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                    _config.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                                   claims: claims,
                                   expires: DateTime.UtcNow.AddDays(1),
                                   signingCredentials: cred
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
