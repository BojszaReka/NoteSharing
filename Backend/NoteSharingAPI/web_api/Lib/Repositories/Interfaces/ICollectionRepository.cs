using class_library.DTO;

namespace web_api.Lib.Repositories.Interfaces
{
    public interface ICollectionRepository
    {
        Task<CollectionViewDTO> Create(CollectionCreateDTO dto);
        Task<bool> Update(CollectionViewDTO dto);
        Task<bool> Delete(Guid id);
        Task<CollectionViewDTO> Get(Guid id);
        Task<IEnumerable<CollectionViewDTO>> GetByUser(Guid userId);
        Task<bool> AddNote(CollectionNoteDTO dto);
        Task<bool> RemoveNote(CollectionNoteDTO dto);
    }
}
