using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace class_library.Models
{
    /// <summary>
    /// Represents a subject within an institution, optionally assigned to an Instructor.
    /// </summary>
        [Table("Subjects")]
        public class Subject
        {
            /// <summary>
            /// Unique identifier for the subject.
            /// </summary>
            [Key, Required]
            public Guid ID { get; set; } = Guid.NewGuid();

            /// <summary>
            /// Name of the subject.
            /// </summary>
            [Required]
            public string? Name { get; set; }

		    [Required]
		    public string? NeptunCode { get; set; }

		    /// <summary>
		    /// Identifier of the institution to which the subject belongs.
		    /// </summary>
		    [Required]
            public Guid InstitutionID { get; set; }

            /// <summary>
            /// Navigation property for the institution.
            /// </summary>
            [ForeignKey(nameof(InstitutionID))]
            public Institution? Institution { get; set; }

            /// <summary>
            /// Identifier of the instructor assigned to the subject, if any.
            /// </summary>
            public Guid? InstructorID { get; set; }

            /// <summary>
            /// Navigation property for the instructor.
            /// </summary>
            [ForeignKey(nameof(InstructorID))]
            public User? Instructor { get; set; }

            /// <summary>
            /// Collection of user-subject relationships.
            /// </summary>
            public ICollection<UserSubject>? UserSubjects { get; set; }

            public ICollection<Note>? Notes { get; set; }
            public ICollection<NoteRequest>? NoteRequests { get; set; }

		/// <summary>
		/// Returns a string representation of the subject.
		/// </summary>
		/// <returns>A string containing key subject properties.</returns>
		public override string ToString()
            {
                return $"SubjectID:{ID}, Name:{Name}, InstitutionID:{InstitutionID}, InstructorID:{InstructorID}";
            }
        }
}
