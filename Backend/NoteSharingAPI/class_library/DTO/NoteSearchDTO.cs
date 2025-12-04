namespace class_library.DTO
{
	public class NoteSearchDTO
	{
		// MAIN SEARCH
		public string? Query { get; set; }

		// FIELD-SPECIFIC SEARCH
		public string? Title { get; set; }
		public string? Description { get; set; }
		public string? Content { get; set; }

		// FILTERS
		public Guid? SubjectID { get; set; }
		public Guid? InstitutionID { get; set; }
		public Guid? AuthorUserID { get; set; }

		// USER CONTEXT
		public Guid RequestingUserID { get; set; }

		// PAGINATION
		public int Page { get; set; } = 1;
		public int PageSize { get; set; } = 25;

		// SORTING
		public bool OrderByRating { get; set; } = true;
		public bool OrderByRelevance { get; set; } = true;
	}
}