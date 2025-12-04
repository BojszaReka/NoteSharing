using Microsoft.Extensions.DependencyInjection;
using web_api.Lib.Repositories.Interfaces;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Repositories
{
	public class SearchRepository : ISearchRepository
	{
		private IServiceScopeFactory _serviceScopeFactory;

		public SearchRepository(IServiceScopeFactory scopeFactory)
		{
			_serviceScopeFactory = scopeFactory;
		}

		public async Task<object?> SearchNotes(NoteSearchDTO dto)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<INoteManagerService>();
			return await service.Search(dto);
		}

		public async Task<object?> SearchSubjects(SubjectSearchDTO dto)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<ISubjectManagerService>();
			return await service.Search(dto);
		}

		public async Task<object?> SearchUsers(UserSearchDTO dto)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<IUserManagerService>();
			return await service.Search(dto);
		}
	}
}
