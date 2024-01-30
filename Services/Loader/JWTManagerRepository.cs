using Microsoft.IdentityModel.Tokens;
using EtiqaCDN.Models;
using EtiqaCDN.Models.Tokens;
using EtiqaCDN.Models.User;
using EtiqaCDN.Services.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EtiqaCDN.Models.UserDto;

namespace EtiqaCDN.Services.Loader
{
    public class JWTManagerRepository : IJWTManagerRepository
    {        
        private readonly IConfiguration iconfiguration;     
        private readonly IUserInfoLoader _iUserInfoLoader;

        public JWTManagerRepository(IConfiguration iconfiguration, IUserInfoLoader iUserInfoLoader)
        {
            this.iconfiguration = iconfiguration;
            _iUserInfoLoader = iUserInfoLoader;

        }
        public Tokens Authenticate(UserDto users)
        {
            var userInfo = _iUserInfoLoader.GetAspUserInfoByIdAsync(users);
            if (userInfo.Result == null)
            {
                return null;
            }

            // Else we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Name, users.UserName),
             new Claim(ClaimTypes.Role, userInfo.Result.Role),
             new Claim(ClaimTypes.NameIdentifier, users.Email)
              }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };

        }
    }
}
