using EtiqaCDN.Models;
using EtiqaCDN.Models.UserDto;

namespace EtiqaCDN.Services.Interface
{
    public interface IUserInfoLoader
    {
        Task<Users> GetUserInfoByIdAsync(string Id);
        Task<bool> DeleteUserInfoByIdAsync(string Id);
        Task<Users> UpdateUserByIdAsync(Users users, string Id);
        Task<bool> AddUserByIdAsync(Users users);
		Task<Users> GetAspUserInfoByIdAsync(UserDto users);
	}
}
