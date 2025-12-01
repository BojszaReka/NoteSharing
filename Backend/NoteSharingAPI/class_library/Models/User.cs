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
        public EUserType UserType { get; set; } = EUserType.Default;
        public EPermissionType PermissionType { get; set; } = EPermissionType.User;
		public bool Enabled { get; set; }
		public string? Description { get; set; }
		public string? RefreshToken { get; set; }
		public DateTime? RefreshTokenExpires { get; set; }

		[Required]
        public Guid PreferenceID { get; set; }

 

        /// <summary>
        /// Represents the institution for the user.
        /// - If <see cref="UserType"/> is <see cref="EUserType.Default"/>, this value is <c>null</c>.
        /// - Otherwise, this indicates the institution where the user belongs.
        /// </summary>
        public Guid? InstitutionID { get; set; }        

        /// <summary>
        /// Represents the grade information for the user.
        /// - If <see cref="UserType"/> is <see cref="EUserType.Default"/>, this value is <c>null</c>.
        /// - If <see cref="UserType"/> is <see cref="EUserType.Student"/>, this value indicates the grade of the student.
        /// - If <see cref="UserType"/> is <see cref="EUserType.Instructor"/>, this value indicates the grade the instructor is teaching.
        /// </summary>
        public string? Grade { get; set; }

		// Kapcsolatok
		[ForeignKey(nameof(PreferenceID))]
		public Preference Preference { get; set; }
		[ForeignKey(nameof(InstitutionID))]
		public Institution Institution { get; set; }
		public ICollection<UserFollow> Followers { get; set; }
        public ICollection<UserFollow> Followings { get; set; }
        public ICollection<UserSubject> UserSubjects { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<NoteRating> NoteRatings { get; set; }
        public ICollection<Collection> Collections { get; set; }
        public ICollection<NoteRequest> NoteRequests { get; set; }
        public ICollection<NoteRequestAnswer> NoteRequestAnswers { get; set; }

		public override string ToString()
        {
            var followers = Followers?.Count ?? 0;
            var followings = Followings?.Count ?? 0;
            var subjects = UserSubjects?.Count ?? 0;

            return $"UserID:{ID}, UserName:{UserName}, Name:{Name}, Email:{Email}, " +
                   $"UserType:{UserType}, PreferenceID:{PreferenceID}, " +
                   $"Followers:{followers}, Followings:{followings}, Subjects:{subjects}, " +
                   $"Password:{Password}";
        }
    }
}
