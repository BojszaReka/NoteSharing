using class_library.Enums;
using class_library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_library.DTO
{
	public class NoteRequestModifyDTO
	{
		public Guid ID { get; set; }
		public Guid SubjectID { get; set; }
		public string Topic { get; set; }
		public string Description { get; set; }
		public ERequestStatus Status { get; set; } = ERequestStatus.Requested;
	}
}
