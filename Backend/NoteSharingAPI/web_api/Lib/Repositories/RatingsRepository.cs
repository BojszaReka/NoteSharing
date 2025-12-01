using class_library.DTO;
using Microsoft.Extensions.DependencyInjection;
using web_api.Lib.Repositories.Interfaces;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Repositories
{
    public class RatingsRepository : IRatingsRepository
    {
		private readonly IServiceScopeFactory _serviceScopeFactory;

		public RatingsRepository(IServiceScopeFactory serviceScopeFactory)
		{
			_serviceScopeFactory = serviceScopeFactory;
		}

		public async Task<NoteRatingViewDTO> Add(NoteRatingCreateDTO dto)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<IRatingsManagerService>();
			return await service.Add(dto);
		}

		public async Task<bool> Delete(Guid ratingId)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<IRatingsManagerService>();
			return await service.Delete(ratingId);
		}

		public async Task<IEnumerable<NoteRatingViewDTO>> GetByNote(Guid noteId)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<IRatingsManagerService>();
			return await service.GetByNote(noteId);
		}
	}
}
