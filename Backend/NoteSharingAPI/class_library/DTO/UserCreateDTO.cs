using System;
using System.ComponentModel.DataAnnotations;
using class_library.Enums;

namespace class_library.DTO
{
    public class UserCreateDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
		public bool Enabled { get; set; }
		public string? Description { get; set; }

		public EUserType UserType { get; set; } = EUserType.Default;
        public EPermissionType PermissionType { get; set; } = EPermissionType.User;
		public Guid? PreferenceID { get; set; }
    }
}
