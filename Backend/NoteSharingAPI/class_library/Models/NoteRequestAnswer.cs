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
    [Table("NoteRequestAnswers")]
    public class NoteRequestAnswer
    {
        [Key, Required]
        public Guid ID { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UploaderUserID { get; set; }

        [Required]
        public Guid RequestID { get; set; }

        [Required]
        public string Content { get; set; }

        public string? Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public EAnswerStatus Status { get; set; } = EAnswerStatus.Pending;

        [ForeignKey(nameof(UploaderUserID))]
        public User Uploader { get; set; }

        [ForeignKey(nameof(RequestID))]
        public NoteRequest Request { get; set; }

        public override string ToString()
            => $"NoteRequestAnswerID:{ID}, RequestID:{RequestID}, UploaderUserID:{UploaderUserID}, Status:{Status}, CreatedAt:{CreatedAt:u}";
    }
}
