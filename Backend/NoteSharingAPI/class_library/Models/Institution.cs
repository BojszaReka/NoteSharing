using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace class_library.Models
{
    [Table("Institutions")]
    public class Institution
    {
        [Key, Required]
        public Guid ID { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; }

        public ICollection<Subject> Subjects { get; set; }
        public ICollection<User> Users { get; set; }

        public override string ToString()
        {
            var subjects = Subjects?.Count ?? 0;
            var users = Users?.Count ?? 0;
            return $"InstitutionID:{ID}, Name:{Name}, Subjects:{subjects}, Users:{users}";
        }
    }
}
