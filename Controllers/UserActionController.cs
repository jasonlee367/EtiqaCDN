using EtiqaCDN.Models;
using EtiqaCDN.Services.Interface;
using Herbalife.Server.Models.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EtiqaCDN.Controllers
{
	[Authorize]
	[ApiController]
    [Route("api/[controller]")]
    public class UserActionController : ControllerBase
    {        
        private readonly ILogger<UserActionController> _logger;
        private readonly IUserInfoLoader _userInfoLoader;
        public UserActionController(ILogger<UserActionController> logger, IUserInfoLoader userInfoLoader)
        {
            _logger = logger;
            _userInfoLoader = userInfoLoader;
        }

        [HttpGet("GetUserById/{Id}")]
        public async Task<IActionResult> GetUserById([FromRoute] string Id)
        {
            var info = await _userInfoLoader.GetUserInfoByIdAsync(Id);

            _logger.LogInformation("Invoke GetUser: {@GetUser}", info);

            if (info != null)
            {
                return new OkObjectResult(new BaseResponse<string>()
                {
                    Message = $"Successfully retrieve user Info.",
                    Data = JsonConvert.SerializeObject(info)
                });
            }
            else
            {
                return new OkObjectResult(new BaseResponse<string>()
                {
                    Message = $"User Id : {Id} is not found!",
                });
            }
        }

        [HttpDelete("DeleteUserById/{Id}")]
        public async Task<IActionResult> DeleteUserById([FromRoute] string Id)
        {
            var deleted = await _userInfoLoader.DeleteUserInfoByIdAsync(Id);

            _logger.LogInformation("Invoke RemoveUser: {@RemoveUser}", Id);

            if (deleted)
            {
                return new OkObjectResult(new BaseResponse<string>()
                {
                    Message = $"Successfully delete user Info.",
                });
            }
            else
            {
                return new OkObjectResult(new BaseResponse<string>()
                {
                    Message = $"User Id : {Id} is not found!",
                });
            }
        }

        [HttpPut("UpdateUserById/{Id}")]
        public async Task<IActionResult> UpdateUserById([FromBody] Users users, [FromRoute] string Id)
        {
            var info = await _userInfoLoader.UpdateUserByIdAsync(users, Id);

            _logger.LogInformation("Invoke GetUser: {@GetUser}", info);

            if (info != null)
            {
                return new OkObjectResult(new BaseResponse<string>()
                {
                    Message = $"Successfully update user Info.",
                    Data = JsonConvert.SerializeObject(info)
                });
            }
            else
            {
                return new OkObjectResult(new BaseResponse<string>()
                {
                    Message = $"User Id : {Id} is not found!",
                });
            }
        }

        [HttpPost("AddUserById")]
        public async Task<IActionResult> AddUserById([FromBody] Users users)
        {
            var info = await _userInfoLoader.AddUserByIdAsync(users);

            _logger.LogInformation("Invoke GetUser: {@GetUser}", info);

            if (info)
            {
                return new OkObjectResult(new BaseResponse<string>()
                {
                    Message = $"Successfully Add user Info.",
                    Data = JsonConvert.SerializeObject(info)
                });
            }
            else
            {
                return new OkObjectResult(new BaseResponse<string>()
                {
                    Message = $"Failed to add new user!",
                });
            }
        }
    }
}