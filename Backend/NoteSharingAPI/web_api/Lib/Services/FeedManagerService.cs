using Microsoft.Extensions.Caching.Distributed;
using web_api.Lib.Database;
using web_api.Lib.Services.Interfaces;
using web_api.Lib.UnitOfWork;

namespace web_api.Lib.Services
{
	public class FeedManagerService : IFeedManagerService
	{
		private readonly db_context _dbContext;
		private readonly IDistributedCache _cache;
		private readonly IServiceScopeFactory _scopeFactory;
		private readonly IUnitOfWork _unitOfWork;
		public FeedManagerService(db_context dbContext, IDistributedCache cache, IServiceScopeFactory scopeFactory, IUnitOfWork unitOfWork)
		{
			_dbContext = dbContext;
			_cache = cache;
			_scopeFactory = scopeFactory;
			_unitOfWork = unitOfWork;
		}

		public async Task<object?> GetFeedForUser(Guid userId)
		{
			var preference = await _unitOfWork.preferenceRepository.GetByUserId(userId);
			IQueryable<Note> notes = await _unitOfWork.noteRepository.GetAllNote();
			notes = notes.Where(n => n.IsDeleted == false).OrderByDescending(n => n.CreatedAt);
			if (preference != null)
			{
				var followedUsers = await _unitOfWork.userFollowRepository.GetFollowing(userId);
				//notes = notes.Where(n => followedUsers.Where(f => f.FollowedUserID == n.AuthorUserID) );
				return notes.Take(20).Adapt<ICollection<NoteViewDTO>>();
			}
			else
			{
				return notes.Take(20).Adapt<ICollection<NoteViewDTO>>();
			}
			
		}
	}
}
