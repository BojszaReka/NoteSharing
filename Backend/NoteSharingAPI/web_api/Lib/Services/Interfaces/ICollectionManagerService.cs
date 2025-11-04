using class_library.DTO;

namespace web_api.Lib.Services.Interfaces
{
    public interface ICollectionManagerService
    {
        Task<CollectionViewDTO> CreateAsync(CollectionCreateDTO dto);
        Task<bool> UpdateAsync(CollectionViewDTO dto);
        Task<bool> DeleteAsync(Guid id);
        Task<CollectionViewDTO> GetAsync(Guid id);
        Task<IEnumerable<CollectionViewDTO>> GetByUserAsync(Guid userId);
        Task<bool> AddNoteAsync(CollectionNoteDTO dto);
        Task<bool> RemoveNoteAsync(CollectionNoteDTO dto);
    }
}
