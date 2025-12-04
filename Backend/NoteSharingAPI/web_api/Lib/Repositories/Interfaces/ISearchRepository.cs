
namespace web_api.Lib.Repositories.Interfaces
{
	public interface ISearchRepository
	{
		Task<object?> SearchNotes(NoteSearchDTO dto);
		Task<object?> SearchSubjects(SubjectSearchDTO dto);
		Task<object?> SearchUsers(UserSearchDTO dto);
	}
}
