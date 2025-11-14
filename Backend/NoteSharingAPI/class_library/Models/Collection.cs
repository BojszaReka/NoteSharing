using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace class_library.Models
{
    [Table("Collections")]
    public class Collection
    {
        [Key, Required]
        public Guid ID { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public bool Private { get; set; } = false;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(UserID))]
        public User User { get; set; }

        public ICollection<CollectionNote> CollectionNotes { get; set; }

        public override string ToString()
        {
            var notes = CollectionNotes?.Count ?? 0;
            return $"CollectionID:{ID}, UserID:{UserID}, Name:{Name}, Title:{Title}, Private:{Private}, Notes:{notes}";
        }
    }
}
