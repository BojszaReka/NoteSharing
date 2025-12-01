using class_library.DTO;
using class_library.Enums;
using Microsoft.Extensions.DependencyInjection;
using web_api.Lib.Repositories.Interfaces;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
		private readonly IServiceScopeFactory _scopeFactory;

		public AnswerRepository(IServiceScopeFactory scopeFactory)
		{
			_scopeFactory = scopeFactory;
		}

		public async Task<bool> ChangeStatus(Guid answerId, EAnswerStatus status)
		{
			using var scope = _scopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<IAnswerManagerService>();
			return await service.ChangeStatus(answerId, status);
		}

		public async Task<NoteRequestAnswerViewDTO> Create(NoteRequestAnswerCreateDTO dto)
		{
			using var scope = _scopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<IAnswerManagerService>();
			return await service.Create(dto);
		}

		public async Task<IEnumerable<NoteRequestAnswerViewDTO>> GetByNote(Guid noteId)
		{
			using var scope = _scopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<IAnswerManagerService>();
			return await service.GetByNote(noteId);
		}

		public async Task<IEnumerable<NoteRequestAnswerViewDTO>> GetByUser(Guid userId)
		{
			using var scope = _scopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<IAnswerManagerService>();
			return await service.GetByUser(userId);
		}
	}
}
