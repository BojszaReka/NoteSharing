using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using class_library.DTO;
using class_library.Enums;
using class_library.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using web_api.Lib.Database;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
	public class NoteRequestManagerService : INoteRequestManagerService
	{
		public Task<NoteRequestAnswerViewDTO> AddAnswerAsync(NoteRequestAnswerCreateDTO dto)
		{
			throw new NotImplementedException();
		}

		public Task<bool> ChangeAnswerStatusAsync(Guid answerId, EAnswerStatus status)
		{
			throw new NotImplementedException();
		}

		public Task<bool> ChangeRequestStatusAsync(Guid requestId, ERequestStatus status)
		{
			throw new NotImplementedException();
		}

		public Task<NoteRequestViewDTO> CreateAsync(NoteRequestCreateDTO dto)
		{
			throw new NotImplementedException();
		}

		public Task<NoteRequestViewDTO> Get(Guid userId)
		{
			throw new NotImplementedException();
		}

		public Task<object?> GetByCreator(Guid userId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<NoteRequestViewDTO>> GetByUserAsync(Guid userId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<NoteRequestViewDTO>> GetRelevantRequestAsync(Guid userId)
		{
			throw new NotImplementedException();
		}

		public Task<object?> GetRelevantRequestByUser(Guid userId)
		{
			throw new NotImplementedException();
		}

		public Task<NoteRequestViewDTO> ModifyAsync(NoteRequestCreateDTO dto)
		{
			throw new NotImplementedException();
		}

		public Task<object?> ModifyRequest(NoteRequestCreateDTO dto)
		{
			throw new NotImplementedException();
		}

		public Task<bool> UpdateAnswerStatus(Guid answerId, EAnswerStatus newStatus)
		{
			throw new NotImplementedException();
		}

		public Task<object?> UpdateStatus(Guid requestId, ERequestStatus newStatus)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<NoteRequestAnswerViewDTO>> ViewAnswersByNoteAsync(Guid noteId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<NoteRequestAnswerViewDTO>> ViewAnswersByUserAsync(Guid userId)
		{
			throw new NotImplementedException();
		}
	}
}
