using EtiqaCDN.Models;
using EtiqaCDN.Models.UserDto;

namespace EtiqaCDN.Data
{
    public interface IUserProfileContext
    {
		Task<Users> GetUserProfileContext(string Id);
		Task<bool> DeleteUserProfileContext(string Id);
		Task<Users> UpdateUserProfileContext(Users users, string Id);
		Task<bool> AddUserProfileContext(Users users);
		Task<Users> GetAspUserProfileContext(UserDto users);
	}
}
