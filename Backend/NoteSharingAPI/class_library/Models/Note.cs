using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace class_library.Models
{
    [Table("Notes")]
    public class Note
    {
        [Key, Required]
        public Guid ID { get; set; } = Guid.NewGuid();

        [Required]
        public Guid AuthorUserID { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Guid SubjectID { get; set; }

        [Required]
        public Guid InstitutionID { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public bool IsDeleted { get; set; } = false;

        [ForeignKey(nameof(AuthorUserID))]
        public User Author { get; set; }

        [ForeignKey(nameof(SubjectID))]
        public Subject Subject { get; set; }

        [ForeignKey(nameof(InstitutionID))]
        public Institution Institution { get; set; }

        public ICollection<NoteRating> Ratings { get; set; }
        public ICollection<CollectionNote> CollectionNotes { get; set; }

        public override string ToString()
        {
            var ratings = Ratings?.Count ?? 0;
            var inCollections = CollectionNotes?.Count ?? 0;
            return $"NoteID:{ID}, AuthorUserID:{AuthorUserID}, Title:{Title}, SubjectID:{SubjectID}, InstitutionID:{InstitutionID}, CreatedAt:{CreatedAt:u}, UpdatedAt:{UpdatedAt:u}, IsDeleted:{IsDeleted}, Ratings:{ratings}, InCollections:{inCollections}";
        }
    }
}
