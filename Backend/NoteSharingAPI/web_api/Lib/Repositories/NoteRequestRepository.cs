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
using web_api.Lib.Repositories.Interfaces;

namespace web_api.Lib.Repositories
{
	public class NoteRequestRepository : INoteRequestRepository
	{
		private IServiceScopeFactory scopeFactory;

		public NoteRequestRepository(IServiceScopeFactory scopeFactory)
		{
			this.scopeFactory = scopeFactory;
		}

		public Task<NoteRequestAnswerViewDTO> AddAnswer(NoteRequestAnswerCreateDTO dto)
		{
			throw new NotImplementedException();
		}

		public Task<bool> ChangeAnswerStatus(Guid answerId, EAnswerStatus status)
		{
			throw new NotImplementedException();
		}

		public Task<bool> ChangeRequestStatus(Guid requestId, ERequestStatus status)
		{
			throw new NotImplementedException();
		}

		public Task<NoteRequestViewDTO> Create(NoteRequestCreateDTO dto)
		{
			throw new NotImplementedException();
		}

		public Task<NoteRequestViewDTO?> Get(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<object?> GetByCreator(Guid userId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<NoteRequestViewDTO>> GetByUser(Guid userId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<NoteRequestViewDTO>> GetRelevantRequest(Guid userId)
		{
			throw new NotImplementedException();
		}

		public Task<object?> GetRelevantRequestByUser(Guid userId)
		{
			throw new NotImplementedException();
		}

		public Task<object?> ModifyRequest(NoteRequestViewDTO dto)
		{
			throw new NotImplementedException();
		}

		public Task<object?> UpdateAnswerStatus(Guid answerId, EAnswerStatus newStatus)
		{
			throw new NotImplementedException();
		}

		public Task<object?> UpdateStatus(Guid requestId, ERequestStatus newStatus)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<NoteRequestAnswerViewDTO>> ViewAnswersByNote(Guid requestId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<NoteRequestAnswerViewDTO>> ViewAnswersByUser(Guid userId)
		{
			throw new NotImplementedException();
		}
	}
}
