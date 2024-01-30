using System.ComponentModel.DataAnnotations;

namespace EtiqaCDN.Models
{
    public class Users
    {
		[RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$", ErrorMessage = "Invalid pattern.")]
		public string Email { get; set; } = "string";
		public string Password { get; set; } = default!;
        public string Role { get; set; } = default!;

		/// <summary>
		/// User Name
		/// </summary>
		public string UserName { get; set; } = default!;
		/// <summary>
		/// User MRN
		/// </summary>
		public string Hobby { get; set; } = default!;
		/// <summary>
		/// User IC or Passport
		/// </summary>
		public string IC_Passport { get; set; } = default!;
		/// <summary>
		/// User Nationality
		/// </summary>
		public string Nationality { get; set; } = default!;
		/// <summary>
		/// User Race
		/// </summary>
		public string Race { get; set; } = default!;
		/// <summary>
		/// User Gender
		/// </summary>
		public string Gender { get; set; } = default!;
		/// <summary>
		/// User Date of birth
		/// </summary>
		public string DOB { get; set; } = default!;
		/// <summary>
		/// User Contact No
		/// </summary>
		[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
		public string PhoneNumber { get; set; } = "string";
		/// <summary>
		/// User IC Image
		/// </summary>
		public string? Skillsets { get; set; }
		/// <summary>
		/// User Address1
		/// </summary>
		public string Address1 { get; set; } = default!;
		/// <summary>
		/// User Address2
		/// </summary>
		public string Address2 { get; set; } = default!;
		/// <summary>
		/// User Postcode
		/// </summary>
		public string Postcode { get; set; } = default!;
		/// <summary>
		/// User City
		/// </summary>
		public string City { get; set; } = default!;
		/// <summary>
		/// User State
		/// </summary>
		public string State { get; set; } = default!;
		/// <summary>
		/// User Country
		/// </summary>
		public string Country { get; set; } = default!;
	}
}
