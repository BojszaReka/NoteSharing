using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace class_library.Models
{
    [Table("Users")] 
    public class Student : User
    {
        public Guid InstitutionID { get; set; }
        [ForeignKey(nameof(InstitutionID))]
        public Institution Institution { get; set; }

        public string Grade { get; set; }
    }
}
