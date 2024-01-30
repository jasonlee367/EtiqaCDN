using EtiqaCDN.Data;
using EtiqaCDN.Models;
using EtiqaCDN.Models.UserDto;
using EtiqaCDN.Services.Interface;

namespace EtiqaCDN.Services.Loader
{
    public class UserInfoLoader : IUserInfoLoader
    {
        private readonly IUserProfileContext _userProfileContext;

        public UserInfoLoader(IUserProfileContext userProfileContext)
        {
            _userProfileContext = userProfileContext;
        }
        public async Task<Users> GetUserInfoByIdAsync(string Id)
        {
            var response = await _userProfileContext.GetUserProfileContext(Id);

            return response;
        }

        public async Task<bool> DeleteUserInfoByIdAsync(string Id)
        {
            var response = await _userProfileContext.DeleteUserProfileContext(Id);

            return response;
        }

        public async Task<Users> UpdateUserByIdAsync(Users users, string Id)
        {
            var response = await _userProfileContext.UpdateUserProfileContext(users,Id);

            return response;
        }

        public async Task<bool> AddUserByIdAsync(Users users)
        {
            var response = await _userProfileContext.AddUserProfileContext(users);

            return response;
        }

		public async Task<Users> GetAspUserInfoByIdAsync(UserDto users)
		{
			var response = await _userProfileContext.GetAspUserProfileContext(users);

			return response;
		}
	}
}
