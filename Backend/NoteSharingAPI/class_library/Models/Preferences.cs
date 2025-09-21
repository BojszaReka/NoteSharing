using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace class_library.Models
{
    [Table("Preferences")]
    public class Preference
    {
        [Key, Required]
        public Guid ID { get; set; } = Guid.NewGuid();

        public bool PrioritiseUsersFromInstitution { get; set; }
        public bool PrioritiseInstructorNotes { get; set; }
        public bool PrivateMyNotes { get; set; }
        public bool PrioritiseRatedNotes { get; set; }
        public bool PrioritiseFollowedUsers { get; set; }
    }
}
