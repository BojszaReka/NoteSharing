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

        public bool PrioritiseUsersFromInstitution { get; set; } = false;
        public bool PrioritiseInstructorNotes { get; set; } = false;
        public bool PrivateMyNotes { get; set; } = false;
        public bool PrioritiseRatedNotes { get; set; } = false;
        public bool PrioritiseFollowedUsers { get; set; } = false;

        public override string ToString()
            => $"PreferenceID:{ID}, " +
               $"PrioritiseUsersFromInstitution:{PrioritiseUsersFromInstitution}, " +
               $"PrioritiseInstructorNotes:{PrioritiseInstructorNotes}, " +
               $"PrivateMyNotes:{PrivateMyNotes}, " +
               $"PrioritiseRatedNotes:{PrioritiseRatedNotes}, " +
               $"PrioritiseFollowedUsers:{PrioritiseFollowedUsers}";
    }
}
