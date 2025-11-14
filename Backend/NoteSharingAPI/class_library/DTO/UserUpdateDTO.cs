using System;
using System.ComponentModel.DataAnnotations;
using class_library.Enums;

namespace class_library.DTO
{
    public class UserUpdateDTO
    {
        [Required]
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public EUserType UserType { get; set; }
        public Guid? InstitutionID { get; set; }
        public string? Grade { get; set; }
	}
}
