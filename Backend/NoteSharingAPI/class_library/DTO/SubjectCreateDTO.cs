using System;
using System.ComponentModel.DataAnnotations;

namespace class_library.DTO
{
    public class SubjectCreateDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Guid InstitutionID { get; set; }

        public Guid? InstructorID { get; set; }
    }
}
