using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace class_library.Models
{
    [Table("Subjects")]
    public class Subject
    {
        [Key, Required]
        public Guid ID { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; }

        [Required]
        public Guid InstitutionID { get; set; }

        [ForeignKey(nameof(InstitutionID))]
        public Institution Institution { get; set; }

        public Guid? InstructorID { get; set; }

        [ForeignKey(nameof(InstructorID))]
        public Instructor Instructor { get; set; }

        public ICollection<UserSubject> UserSubjects { get; set; }

        public override string ToString()
            => $"SubjectID:{ID}, Name:{Name}, InstitutionID:{InstitutionID}, InstructorID:{InstructorID}";
    }
}
