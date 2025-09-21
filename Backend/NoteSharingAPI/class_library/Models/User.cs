using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using class_library.Enums;

namespace class_library.Models
{
    [Table("Users")]
    public class User
    {
        [Key, Required]
        public Guid ID { get; set; } = Guid.NewGuid();

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        /// <summary>Hashelt jelszó</summary>
        [Required]
        public string Password { get; set; }

        [Required]
        public EUserType UserType { get; set; } = EUserType.Simple;

        [Required]
        public Guid PreferenceID { get; set; }

        [ForeignKey(nameof(PreferenceID))]
        public Preference Preference { get; set; }

        // Kapcsolatok
        public ICollection<UserFollow> Followers { get; set; }
        public ICollection<UserFollow> Followings { get; set; }

        public ICollection<UserSubject> UserSubjects { get; set; }

        public override string ToString()
        {
            return $"UserID:{ID}, UserName:{UserName}, Name:{Name}, Email:{Email}, Type:{UserType}";
        }
    }
}
