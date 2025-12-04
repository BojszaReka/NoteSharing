using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace class_library.Models
{
    [Table("NoteRatings")]
    public class NoteRating
    {
        [Key, Required]
        public Guid ID { get; set; } = Guid.NewGuid();

        [Required]
        public Guid NoteID { get; set; }

        [Required]
        public Guid UserID { get; set; }

        [Required, Range(1, 5)]
        public int Stars { get; set; }

        public string? Review { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(NoteID))]
        public Note Note { get; set; }

        [ForeignKey(nameof(UserID))]
        public User User { get; set; }

        public override string ToString()
            => $"NoteRatingID:{ID}, NoteID:{NoteID}, UserID:{UserID}, Stars:{Stars}, CreatedAt:{CreatedAt:u}";
    }
}
