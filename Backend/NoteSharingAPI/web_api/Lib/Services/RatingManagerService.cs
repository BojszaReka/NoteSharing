using class_library.DTO;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using web_api.Lib.Database;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
    public class RatingsManagerService : IRatingsManagerService
    {
		private readonly db_context _dbContext;
		private readonly IDistributedCache _cache;
		private readonly IServiceScopeFactory _scopeFactory;
		public RatingsManagerService(db_context dbContext, IDistributedCache cache, IServiceScopeFactory scopeFactory)
		{
			_dbContext = dbContext;
			_cache = cache;
			_scopeFactory = scopeFactory;
		}

		private async Task<IQueryable<NoteRating>> querryRatings()
		{
			var cachedData = await _cache.GetStringAsync("ratings");
			if (!string.IsNullOrEmpty(cachedData))
			{
				var data = JsonConvert.DeserializeObject<List<NoteRating>>(cachedData);
				return data.AsQueryable();
			}
			var dataFromDb = await _dbContext.NoteRatings.OrderBy(c => c.ID).ToListAsync();
			var cacheOptions = new DistributedCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
				SlidingExpiration = TimeSpan.FromMinutes(5)
			};

			var serializedData = JsonConvert.SerializeObject(dataFromDb);
			await _cache.SetStringAsync("ratings", serializedData, cacheOptions);
			return dataFromDb.AsQueryable();
		}

		public async Task<NoteRatingViewDTO> Add(NoteRatingCreateDTO dto) {
			var transaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				var newRating = new NoteRating
				{
					NoteID = dto.NoteID,
					UserID = dto.UserID,
					Stars = dto.Stars,
					Review = dto.Review,
					CreatedAt = DateTime.UtcNow
				};
				_dbContext.NoteRatings.Add(newRating);
				await _dbContext.SaveChangesAsync();
				await transaction.CommitAsync();
				// Invalidate cache
				await _cache.RemoveAsync("ratings");
				return new NoteRatingViewDTO
				{
					ID = newRating.ID,
					NoteID = newRating.NoteID,
					UserID = newRating.UserID,
					Stars = newRating.Stars,
					Review = newRating.Review,
					CreatedAt = newRating.CreatedAt
				};
			}
			catch (Exception e)
			{
				await transaction.RollbackAsync();
				throw new Exception("Failed to add rating", e.InnerException);
			}
			finally { 
				await transaction.DisposeAsync();
			}
		}

		public async Task<IEnumerable<NoteRatingViewDTO>> GetByNote(Guid noteId) { 
			var ratings = await querryRatings();
			var filteredRatings = ratings.Where(r => r.NoteID == noteId);
			if(!filteredRatings.Any())
			{
				throw new Exception("No ratings found for the specified note.");
			}	
			return filteredRatings.Adapt<List<NoteRatingViewDTO>>();
		}
		public async Task<bool> Delete(Guid ratingId)
		{
			var transaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				var ratings = await querryRatings();
				var rating = ratings.FirstOrDefault(r => r.ID == ratingId);
				if (rating == null)
				{
					throw new Exception("Rating not found.");
				}
				_dbContext.NoteRatings.Remove(rating);
				await _dbContext.SaveChangesAsync();
				await transaction.CommitAsync();
				// Invalidate cache
				await _cache.RemoveAsync("ratings");
				return true;
			}
			catch (Exception e)
			{
				await transaction.RollbackAsync();
				throw new Exception("Failed to delete rating", e.InnerException);
			}
			finally
			{
				await transaction.DisposeAsync();
			}
		}
    }
}
