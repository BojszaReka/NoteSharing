using System.ComponentModel.DataAnnotations;

namespace class_library.DTO
{
	/// <summary>
	/// Data Transfer Object for user login credentials.
	/// </summary>
	public class LoginDTO
	{
		[Required, EmailAddress] public string Email { get; set; }

		[Required] public string Password { get; set; }
	}

	/// <summary>
	/// Data Transfer Object for user registration details.
	/// </summary>
	public class RegisterDTO
	{
		[Required]
		public string UserName { get; set; }

		[Required, EmailAddress]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }
	}

	/// <summary>
	/// Data Transfer Object for authentication response containing tokens and user info.
	/// </summary>
	public class AuthResponseDTO
	{
		public string AccessToken { get; set; }
		public string RefreshToken { get; set; }
		public DateTime Expiration { get; set; }
		public Guid UserId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string UserType { get; set; }
		public string PermissionType { get; set; }
	}

	/// <summary>
	/// Data Transfer Object for refresh token requests.
	/// </summary>
	public class RefreshTokenDTO
	{
		[Required]
		public string RefreshToken { get; set; }
	}
}
