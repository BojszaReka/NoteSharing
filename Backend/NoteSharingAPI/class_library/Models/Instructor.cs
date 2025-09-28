using System;
using System.ComponentModel.DataAnnotations.Schema;
using class_library.Enums;

namespace class_library.Models
{
    [Table("Users")] 
    public class Instructor : User
    {
        public Instructor()
        {
            UserType = EUserType.Instructor;
        }

        public Guid InstitutionID { get; set; }

        [ForeignKey(nameof(InstitutionID))]
        public Institution Institution { get; set; }

        public override string ToString()
            => base.ToString() + $", InstitutionID:{InstitutionID}";
    }
}
