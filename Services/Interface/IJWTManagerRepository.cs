using Newtonsoft.Json.Linq;
using EtiqaCDN.Models;
using EtiqaCDN.Models.Tokens;
using EtiqaCDN.Models.User;
using EtiqaCDN.Models.UserDto;

namespace EtiqaCDN.Services.Interface
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(UserDto users);
    }
}
