using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_library.DTO
{
    public class NoteRatingCreateDTO
    {
        public Guid NoteID { get; set; }
        public Guid UserID { get; set; }
        public int Stars { get; set; }
        public string? Review { get; set; }
    }
}
