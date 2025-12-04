using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_library.DTO
{
    public class NoteCreateDTO
    {
        public Guid AuthorUserID { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid SubjectID { get; set; }
        public Guid InstitutionID { get; set; }
    }
}
