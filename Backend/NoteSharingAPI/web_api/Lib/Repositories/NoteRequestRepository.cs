using Microsoft.Extensions.DependencyInjection;
using web_api.Lib.Repositories.Interfaces;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Repositories
{
	public class NoteRequestRepository : INoteRequestRepository
	{
		private IServiceScopeFactory _serviceScopeFactory;

		public NoteRequestRepository(IServiceScopeFactory scopeFactory)
		{
			this._serviceScopeFactory = scopeFactory;
		}

		public async Task<NoteRequestAnswerViewDTO> AddAnswer(NoteRequestAnswerCreateDTO dto)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<INoteRequestManagerService>();
			return await service.AddAnswerAsync(dto);
		}

		public async Task<bool> ChangeAnswerStatus(Guid answerId, EAnswerStatus status)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<INoteRequestManagerService>();
			return await service.ChangeAnswerStatusAsync(answerId, status);
		}

		public async Task<bool> ChangeRequestStatus(Guid requestId, ERequestStatus status)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<INoteRequestManagerService>();
			return await service.ChangeRequestStatusAsync(requestId, status);
		}

		public async Task<NoteRequestViewDTO> Create(NoteRequestCreateDTO dto)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<INoteRequestManagerService>();
			return await service.CreateAsync(dto);
		}

		public async Task<NoteRequestViewDTO?> Get(Guid id)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<INoteRequestManagerService>();
			return await service.Get(id);
		}

		public async Task<IEnumerable<NoteRequestViewDTO>> GetByCreator(Guid userId)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<INoteRequestManagerService>();
			var result = await service.GetByCreator(userId);
			return result as IEnumerable<NoteRequestViewDTO> ?? Enumerable.Empty<NoteRequestViewDTO>();
		}

		public async Task<IEnumerable<NoteRequestViewDTO>> GetByUser(Guid userId)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<INoteRequestManagerService>();
			return await service.GetByUserAsync(userId);
		}

		public async Task<IEnumerable<NoteRequestViewDTO>> GetRelevantRequest(Guid userId)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<INoteRequestManagerService>();
			return await service.GetRelevantRequestAsync(userId);
		}

		public async Task<object?> GetRelevantRequestByUser(Guid userId)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<INoteRequestManagerService>();
			return await service.GetRelevantRequestByUser(userId);
		}

		public async Task<object?> ModifyRequest(NoteRequestModifyDTO dto)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<INoteRequestManagerService>();
			return await service.ModifyRequest(dto);
		}

		public async Task<bool> UpdateAnswerStatus(Guid answerId, EAnswerStatus newStatus)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<INoteRequestManagerService>();
			return await service.UpdateAnswerStatus(answerId, newStatus);
		}

		public async Task<object?> UpdateStatus(Guid requestId, ERequestStatus newStatus)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<INoteRequestManagerService>();
			return await service.UpdateStatus(requestId, newStatus);
		}

		public async Task<IEnumerable<NoteRequestAnswerViewDTO>> ViewAnswersByNote(Guid requestId)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<INoteRequestManagerService>();
			return await service.ViewAnswersByNoteAsync(requestId);
		}

		public async Task<IEnumerable<NoteRequestAnswerViewDTO>> ViewAnswersByUser(Guid userId)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<INoteRequestManagerService>();
			return await service.ViewAnswersByUserAsync(userId);
		}
	}
}
