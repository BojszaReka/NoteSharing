using class_library.DTO;

namespace web_api.Lib.Services.Interfaces
{
    public interface INoteManagerService
    {
        Task<NoteViewDTO> Create(NoteCreateDTO dto);
        Task<bool> Update(NoteUpdateDTO dto);
        Task<bool> Delete(Guid id);
		Task<NoteViewDTO> Get(Guid id);
		Task<IEnumerable<NoteViewDTO>> GetByAuthor(Guid userId);
        Task<IEnumerable<NoteViewDTO>> GetBySubject(Guid subjectId);
        Task<IEnumerable<NoteViewDTO>> Search(Guid? institutionId, Guid? subjectId, string? text);
        Task<NoteRatingViewDTO> Rate(NoteRatingCreateDTO dto);
        Task<IEnumerable<NoteRatingViewDTO>> GetRatings(Guid noteId);
        Task<bool> DeleteRating(Guid ratingId);
		Task<object?> AddReview(NoteRatingCreateDTO dto);
		Task<object?> Dislike(NoteLikeDTO dto);
		
		Task<ICollection<NoteViewDTO>> GetAll();
		Task<object?> Like(NoteLikeDTO dto);
	}
}
