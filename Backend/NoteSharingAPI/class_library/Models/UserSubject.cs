using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace class_library.Models
{
    [Table("UserSubjects")]
    public class UserSubject
    {
        public Guid UserID { get; set; }
        public User User { get; set; }

        public Guid SubjectID { get; set; }
        public Subject Subject { get; set; }

        public override string ToString()
            => $"UserSubject(UserID:{UserID}, SubjectID:{SubjectID})";
    }
}
