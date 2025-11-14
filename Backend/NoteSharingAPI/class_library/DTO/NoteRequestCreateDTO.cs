using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using class_library.Enums;

namespace class_library.DTO
{
    public class NoteRequestCreateDTO
    {
        public Guid CreatorUserID { get; set; }
        public Guid SubjectID { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
    }
}
