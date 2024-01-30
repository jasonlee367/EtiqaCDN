using System.ComponentModel.DataAnnotations;

namespace EtiqaCDN.Models.UserDto
{
    public class UserDto
    {
		public string UserName { get; set; }

		[RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$", ErrorMessage = "Invalid pattern.")]
		public string Email { get; set; } = "string";
		public string Password { get; set; }
		public string Role { get; set; }
	}
}
