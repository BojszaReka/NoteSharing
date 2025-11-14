using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using class_library.Enums;

namespace class_library.DTO
{
    public class NoteRequestAnswerViewDTO
    {
        public Guid ID { get; set; }
        public Guid RequestID { get; set; }
        public Guid UploaderUserID { get; set; }
        public string Content { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public EAnswerStatus Status { get; set; }
    }
}
