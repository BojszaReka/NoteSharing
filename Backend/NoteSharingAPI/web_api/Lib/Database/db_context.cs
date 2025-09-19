namespace web_api.Lib.Database
{
	public class db_context : DbContext
	{
		public db_context(DbContextOptions<db_context> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		}
	}
}
