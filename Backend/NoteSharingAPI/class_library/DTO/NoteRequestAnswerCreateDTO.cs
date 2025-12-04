using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_library.DTO
{
    public class NoteRequestAnswerCreateDTO
    {
        public Guid UploaderUserID { get; set; }
        public Guid RequestID { get; set; }
        public string Content { get; set; }
        public string? Description { get; set; }
    }
}
