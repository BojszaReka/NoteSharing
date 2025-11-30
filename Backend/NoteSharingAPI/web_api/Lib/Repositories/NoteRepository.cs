using Microsoft.Extensions.DependencyInjection;
using web_api.Lib.Repositories.Interfaces;
using web_api.Lib.Services.Interfaces;
using class_library.DTO;

namespace web_api.Lib.Repositories
{
	public class NoteRepository : INoteRepository
	{
		private readonly IServiceScopeFactory _serviceScopeFactory;

		public NoteRepository(IServiceScopeFactory serviceScopeFactory)
		{
			_serviceScopeFactory = serviceScopeFactory;
		}
		public async Task<object?> Add(NoteCreateDTO dto)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<INoteManagerService>();
			return await service.Create(dto);
		}

		public async Task<object?> AddReview(NoteRatingCreateDTO dto)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<INoteManagerService>();
			return await service.AddReview(dto);
		}

		public async Task<object?> Delete(Guid id)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<INoteManagerService>();
			return await service.Delete(id);
		}

		public async Task<object?> Dislike(NoteLikeDTO dto)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<INoteManagerService>();
			return await service.Dislike(dto);
		}

		public async Task<NoteViewDTO> Get(Guid id)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<INoteManagerService>();
			return await service.Get(id);
		}

		public async Task<ICollection<NoteViewDTO>> GetAll()
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<INoteManagerService>();
			return await service.GetAll();
		}

		public async Task<object?> Like(NoteLikeDTO dto)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<INoteManagerService>();
			return await service.Like(dto);
		}

		public async Task<object?> Update(NoteUpdateDTO dto)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<INoteManagerService>();
			return await service.Update(dto);
		}
	}
}
