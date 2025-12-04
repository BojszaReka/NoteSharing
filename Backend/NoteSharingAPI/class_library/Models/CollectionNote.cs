using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace class_library.Models
{
    [Table("CollectionNotes")]
    public class CollectionNote
    {
        [Required]
        public Guid NoteID { get; set; }

        [Required]
        public Guid CollectionID { get; set; }

        [ForeignKey(nameof(NoteID))]
        public Note Note { get; set; }

        [ForeignKey(nameof(CollectionID))]
        public Collection Collection { get; set; }

        public override string ToString()
            => $"CollectionNote(NoteID:{NoteID}, CollectionID:{CollectionID})";
    }
}
