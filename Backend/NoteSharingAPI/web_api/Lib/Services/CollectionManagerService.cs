using class_library.DTO;
using class_library.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using web_api.Lib.Database;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
    public class CollectionManagerService : ICollectionManagerService
    {
		private readonly db_context _dbContext;
		private readonly IDistributedCache _cache;
		private readonly IServiceScopeFactory _scopeFactory;
		public CollectionManagerService(db_context dbContext, IDistributedCache cache, IServiceScopeFactory scopeFactory)
		{
			_dbContext = dbContext;
			_cache = cache;
			_scopeFactory = scopeFactory;
		}

		private async Task<IQueryable<Collection>> querryCollections()
		{
			var cachedData = await _cache.GetStringAsync("collections");
			if (!string.IsNullOrEmpty(cachedData))
			{
				var data = JsonConvert.DeserializeObject<List<Collection>>(cachedData);
				return data.AsQueryable();
			}
			var dataFromDb = await _dbContext.Collections.OrderBy(c => c.ID).ToListAsync();
			var cacheOptions = new DistributedCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
				SlidingExpiration = TimeSpan.FromMinutes(5)
			};

			var serializedData = JsonConvert.SerializeObject(dataFromDb);
			await _cache.SetStringAsync("collections", serializedData, cacheOptions);
			return dataFromDb.AsQueryable();
		}

		private async Task<IQueryable<CollectionNote>> querryCollectionNotes()
		{
			var cachedData = await _cache.GetStringAsync("collectionNotes");
			if (!string.IsNullOrEmpty(cachedData))
			{
				var data = JsonConvert.DeserializeObject<List<CollectionNote>>(cachedData);
				return data.AsQueryable();
			}
			var dataFromDb = await _dbContext.CollectionNotes.ToListAsync();
			var cacheOptions = new DistributedCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
				SlidingExpiration = TimeSpan.FromMinutes(5)
			};

			var serializedData = JsonConvert.SerializeObject(dataFromDb);
			await _cache.SetStringAsync("collectionNotes", serializedData, cacheOptions);
			return dataFromDb.AsQueryable();
		}

		public async Task<bool> AddNoteAsync(CollectionNoteDTO dto)
		{
			var transaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				var collection = await _dbContext.Collections.FirstOrDefaultAsync(c => c.ID == dto.CollectionID);
				if (collection == null)
				{
					throw new Exception("Collection not found");
				}
				var note = await _dbContext.Notes.FirstOrDefaultAsync(n => n.ID == dto.NoteID);
				if (note == null)
				{
					throw new Exception("Note not found");
				}

				var collectionNotes = await querryCollectionNotes();
				var existingEntry = collectionNotes.FirstOrDefault(cn => cn.CollectionID == dto.CollectionID && cn.NoteID == dto.NoteID);
				if (existingEntry != null)
				{
					throw new Exception("Note already in collection");
				}
				var collectionNote = new CollectionNote
				{
					CollectionID = dto.CollectionID,
					NoteID = dto.NoteID
				};
				_dbContext.CollectionNotes.Add(collectionNote);
				await _dbContext.SaveChangesAsync();
				await transaction.CommitAsync();
				await _cache.RemoveAsync("collectionNotes");
				return true;
			}
			catch (Exception e)
			{
				await transaction.RollbackAsync();
				throw new Exception($"Failed to add Note to Collection: {e.InnerException}");
			}
			finally
			{
				await transaction.DisposeAsync();
			}
		}

		public async Task<CollectionViewDTO> CreateAsync(CollectionCreateDTO dto)
		{
			var transaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.ID == dto.UserID);
				if (user == null)
				{
					throw new Exception("User not found");
				}
				var collection = dto.Adapt<Collection>();
				_dbContext.Collections.Add(collection);
				await _dbContext.SaveChangesAsync();
				await transaction.CommitAsync();
				await _cache.RemoveAsync("collections");
				return collection.Adapt<CollectionViewDTO>();
			}
			catch (Exception e)
			{
				await transaction.RollbackAsync();
				throw new Exception($"Failed to create Collection: {e.InnerException}");
			}
			finally
			{
				await transaction.DisposeAsync();
			}
		}

		public async Task<bool> DeleteAsync(Guid id)
		{
			var transaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				var collection = await _dbContext.Collections.FirstOrDefaultAsync(c => c.ID == id);
				if (collection == null)
				{
					throw new Exception("Collection not found");
				}
				var collectionNotes = _dbContext.CollectionNotes.Where(cn => cn.CollectionID == id);
				_dbContext.Collections.Remove(collection);
				_dbContext.CollectionNotes.RemoveRange(collectionNotes);
				await _dbContext.SaveChangesAsync();
				await transaction.CommitAsync();
				await _cache.RemoveAsync("collections");
				await _cache.RemoveAsync("collectionNotes");
				return true;
			}
			catch (Exception e)
			{
				await transaction.RollbackAsync();
				throw new Exception($"Failed to delete Collection: {e.InnerException}");
			}
			finally
			{
				await transaction.DisposeAsync();
			}

		}

		public async Task<CollectionViewDTO> GetAsync(Guid id)
		{
			var collections = await querryCollections();
			var collection = collections.FirstOrDefault(c => c.ID == id);
			if (collection == null)
			{
				throw new Exception("Collection not found");
			}
			return collection.Adapt<CollectionViewDTO>();
		}

		public async Task<IEnumerable<CollectionViewDTO>> GetByUserAsync(Guid userId)
		{
			var collections = await querryCollections();
			var userCollections = collections.Where(c => c.UserID == userId);
			if (!userCollections.Any())
			{
				throw new Exception("No collections found for user");
			}
			return userCollections.Adapt<IEnumerable<CollectionViewDTO>>();
		}

		public async Task<bool> RemoveNoteAsync(CollectionNoteDTO dto)
		{
			var transaction = await _dbContext.Database.BeginTransactionAsync();
			try 			
			{
				var collectionNotes = await querryCollectionNotes();
				var existingEntry = collectionNotes.FirstOrDefault(cn => cn.CollectionID == dto.CollectionID && cn.NoteID == dto.NoteID);
				if (existingEntry == null)
				{
					throw new Exception("Note not in collection");
				}
				_dbContext.CollectionNotes.Remove(existingEntry);
				await _dbContext.SaveChangesAsync();
				await transaction.CommitAsync();
				await _cache.RemoveAsync("collectionNotes");
				return true;
			}
			catch (Exception e)
			{
				await transaction.RollbackAsync();
				throw new Exception($"Failed to remove Note from Collection: {e.InnerException}");
			}
			finally
			{
				await transaction.DisposeAsync();
			}
		}

		public async Task<bool> UpdateAsync(CollectionViewDTO dto)
		{
			var transaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				var collection = await _dbContext.Collections.FirstOrDefaultAsync(c => c.ID == dto.ID);
				if (collection == null)
				{
					throw new Exception("Collection not found");
				}
				collection.Name = dto.Name;
				collection.Title = dto.Title;
				collection.Private = dto.Private;
				_dbContext.Collections.Update(collection);
				await _dbContext.SaveChangesAsync();
				await transaction.CommitAsync();
				await _cache.RemoveAsync("collections");
				return true;
			}
			catch (Exception e)
			{
				await transaction.RollbackAsync();
				throw new Exception($"Failed to update Collection: {e.InnerException}");
			}
			finally
			{
				await transaction.DisposeAsync();
			}
		}

    }
}
