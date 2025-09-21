using System;
using System.ComponentModel.DataAnnotations;
using class_library.Enums;

namespace class_library.DTO
{
    public class UserUpdateDTO
    {
        [Required]
        public Guid ID { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public EUserType UserType { get; set; }
        public Guid PreferenceID { get; set; }
    }
}
