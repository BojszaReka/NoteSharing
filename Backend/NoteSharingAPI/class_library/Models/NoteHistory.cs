using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_library.Models
{
	[Table("NoteHistories")]
	public class NoteHistory
	{
		[Required]
		public Guid ID { get; set; }
		[Required]
		public Guid NoteID { get; set; }
		[Required]
		public Guid UserID { get; set; }
		public DateTime ViewedAt { get; set; } = DateTime.UtcNow;

		[ForeignKey(nameof(UserID))]
		public User Viewer { get; set; }
		[ForeignKey(nameof(NoteID))]
		public Note ViewedNote { get; set; }

		public override string ToString()
		{
			// Safe extraction of related info if available
			var viewerName = Viewer != null
				? (!string.IsNullOrEmpty(Viewer.UserName) ? Viewer.UserName : Viewer.Name ?? "unknown")
				: "unknown";
			var noteTitle = ViewedNote != null
				? (!string.IsNullOrEmpty(ViewedNote.Title) ? ViewedNote.Title : "untitled")
				: "unknown";

			return $"NoteHistory {{ ID = {ID}, NoteID = {NoteID} (\"{noteTitle}\"), UserID = {UserID} (\"{viewerName}\"), ViewedAt = {ViewedAt:O} }}";
		}
	}
}
