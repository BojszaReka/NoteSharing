using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using class_library.Enums;

namespace class_library.DTO
{
    public class NoteRequestViewDTO
    {
        public Guid ID { get; set; }
        public Guid CreatorUserID { get; set; }
        public Guid SubjectID { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public ERequestStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
