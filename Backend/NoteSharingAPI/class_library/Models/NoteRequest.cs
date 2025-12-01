using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using class_library.Enums;

namespace class_library.Models
{
    [Table("NoteRequests")]
    public class NoteRequest
    {
        [Key, Required]
        public Guid ID { get; set; } = Guid.NewGuid();

        [Required]
        public Guid CreatorUserID { get; set; }

        [Required]
        public Guid SubjectID { get; set; }

        [Required]
        public string Topic { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public ERequestStatus Status { get; set; } = ERequestStatus.Requested;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(CreatorUserID))]
        public User Creator { get; set; }

        [ForeignKey(nameof(SubjectID))]
        public Subject Subject { get; set; }

        public ICollection<NoteRequestAnswer> Answers { get; set; }

        public override string ToString()
        {
            var answers = Answers?.Count ?? 0;
            return $"NoteRequestID:{ID}, CreatorUserID:{CreatorUserID}, SubjectID:{SubjectID}, Topic:{Topic}, Status:{Status}, Answers:{answers}, CreatedAt:{CreatedAt:u}";
        }
    }
}
