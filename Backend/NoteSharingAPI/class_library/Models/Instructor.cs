using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace class_library.Models
{
    [Table("Users")] // TPH
    public class Instructor : User
    {
        public Guid InstitutionID { get; set; }
        [ForeignKey(nameof(InstitutionID))]
        public Institution Institution { get; set; }
    }
}
