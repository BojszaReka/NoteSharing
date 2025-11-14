using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_library.DTO
{
    public class NoteViewDTO
    {
        public Guid ID { get; set; }
        public Guid AuthorUserID { get; set; }
        public string AuthorUsername { get; set; }
        public bool FromTeacher { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid SubjectID { get; set; }
        public Guid InstitutionID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public double AvgRating { get; set; }
    }
}
