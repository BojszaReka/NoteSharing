using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_library.DTO
{
	public class NoteViewedDTO
	{
		public NoteViewDTO note { get; set; }
		public DateTime viewedAt { get; set; }
	}
}
