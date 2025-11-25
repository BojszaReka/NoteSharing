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
			return await service.CreateAsync(dto);
		}

		public Task<object?> AddReview(NoteRatingCreateDTO dto)
		{
			throw new NotImplementedException();
		}

		public Task<object?> Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<object?> Dislike(NoteLikeDTO dto)
		{
			throw new NotImplementedException();
		}

		public Task<NoteViewDTO> Get(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<ICollection<NoteViewDTO>> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<object?> Like(NoteLikeDTO dto)
		{
			throw new NotImplementedException();
		}

		public Task<object?> Update(NoteUpdateDTO dto)
		{
			throw new NotImplementedException();
		}
	}
}
