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

        /// <summary>Nyers jelszó – a service réteg hash-eli</summary>
        [Required]
        public string Password { get; set; }

        public EUserType UserType { get; set; } = EUserType.Simple;

        /// <summary>Ha nincs, a backend hozhat létre default Preference-t</summary>
        public Guid? PreferenceID { get; set; }
    }
}
