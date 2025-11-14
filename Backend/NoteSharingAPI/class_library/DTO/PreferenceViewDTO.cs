using System;

namespace class_library.DTO
{
    public class PreferenceViewDTO
    {
        public Guid ID { get; set; }
        public bool PrioritiseUsersFromInstitution { get; set; }
        public bool PrioritiseInstructorNotes { get; set; }
        public bool PrivateMyNotes { get; set; }
        public bool PrioritiseRatedNotes { get; set; }
        public bool PrioritiseFollowedUsers { get; set; }
    }
}
