using class_library.DTO;

namespace web_api.Lib.Repositories.Interfaces
{
    public interface INoteRepository
    {
		Task<object?> Add(NoteCreateDTO dto);
		Task<object?> AddReview(NoteRatingCreateDTO dto);
		Task<object?> Delete(Guid id);
		Task<object?> Dislike(NoteLikeDTO dto);
		Task<NoteViewDTO> Get(Guid id);
		Task<ICollection<NoteViewDTO>> GetAll();
		Task<object?> Like(NoteLikeDTO dto);
		Task<object?> Update(NoteUpdateDTO dto);
	}
}
