using Microsoft.EntityFrameworkCore;
using class_library.Models;
using class_library.Enums;

namespace web_api.Lib.Database
{
    public class db_context : DbContext
    {
        public db_context(DbContextOptions<db_context> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<UserSubject> UserSubjects { get; set; }
        public DbSet<UserFollow> UserFollows { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteRating> NoteRatings { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionNote> CollectionNotes { get; set; }
        public DbSet<NoteRequest> NoteRequests { get; set; }
        public DbSet<NoteRequestAnswer> NoteRequestAnswers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasKey(x => x.ID);

            modelBuilder.Entity<Institution>().HasKey(x => x.ID);
            modelBuilder.Entity<Subject>().HasKey(x => x.ID);
            modelBuilder.Entity<Preference>().HasKey(x => x.ID);

            modelBuilder.Entity<UserSubject>().HasKey(x => new { x.UserID, x.SubjectID });
            modelBuilder.Entity<UserFollow>().HasKey(x => new { x.FollowerUserID, x.FollowedUserID });

            modelBuilder.Entity<Log>().HasKey(x => x.ID);
            modelBuilder.Entity<Note>().HasKey(x => x.ID);
            modelBuilder.Entity<NoteRating>().HasKey(x => x.ID);
            modelBuilder.Entity<Collection>().HasKey(x => x.ID);
            modelBuilder.Entity<CollectionNote>().HasKey(x => new { x.CollectionID, x.NoteID });
            modelBuilder.Entity<NoteRequest>().HasKey(x => x.ID);
            modelBuilder.Entity<NoteRequestAnswer>().HasKey(x => x.ID);

			modelBuilder.Entity<UserFollow>(entity =>
			{
				entity.HasKey(uf => new { uf.FollowerUserID, uf.FollowedUserID });

				entity.HasOne(uf => uf.FollowerUser)
					.WithMany(u => u.Followings)
					.HasForeignKey(uf => uf.FollowerUserID)
					.OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(uf => uf.FollowedUser)
					.WithMany(u => u.Followers)
					.HasForeignKey(uf => uf.FollowedUserID)
					.OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<User>()
                .HasOne(u => u.Preference)
                .WithMany()
                .HasForeignKey(u => u.PreferenceID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserSubject>()
                .HasOne(us => us.User)
                .WithMany(u => u.UserSubjects)
                .HasForeignKey(us => us.UserID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserSubject>()
                .HasOne(us => us.Subject)
                .WithMany(s => s.UserSubjects)
                .HasForeignKey(us => us.SubjectID).OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<Subject>()
                .HasOne(s => s.Institution)
                .WithMany(i => i.Subjects)
                .HasForeignKey(s => s.InstitutionID).OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<Subject>()
                .HasOne(s => s.Instructor)
                .WithMany()
                .HasForeignKey(s => s.InstructorID)
                .IsRequired(false).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Note>().HasOne(n => n.Author)
                .WithMany(u => u.Notes)
                .HasForeignKey(n => n.AuthorUserID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Note>().HasOne(n => n.Subject)
                .WithMany(s => s.Notes)
                .HasForeignKey(n => n.SubjectID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Note>().HasOne(n => n.Institution)
                .WithMany(i => i.Notes)
                .HasForeignKey(n => n.InstitutionID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<NoteRating>().HasOne(nr => nr.Note)
                .WithMany(n => n.Ratings)
                .HasForeignKey(nr => nr.NoteID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<NoteRating>().HasOne(nr => nr.User).WithMany(u => u.NoteRatings)
                .HasForeignKey(nr => nr.UserID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Collection>().HasOne(c => c.User)
                .WithMany(u => u.Collections)
                .HasForeignKey(c => c.UserID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CollectionNote>()
                .HasOne(cn => cn.Collection)
                .WithMany(c => c.CollectionNotes)
                .HasForeignKey(cn => cn.CollectionID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CollectionNote>().HasOne(cn => cn.Note)
                .WithMany(n => n.CollectionNotes)
                .HasForeignKey(cn => cn.NoteID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<NoteRequest>().HasOne(nr => nr.Creator)
                .WithMany(u => u.NoteRequests)
                .HasForeignKey(nr => nr.CreatorUserID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<NoteRequest>().HasOne(nr => nr.Subject)
                .WithMany(s => s.NoteRequests)
                .HasForeignKey(nr => nr.SubjectID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<NoteRequest>().HasMany(nr => nr.Answers)
                .WithOne(nra => nra.Request)
                .HasForeignKey(nra => nra.RequestID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<NoteRequestAnswer>().HasOne(nra => nra.Uploader)
                .WithMany(u => u.NoteRequestAnswers)
                .HasForeignKey(nra => nra.UploaderUserID).OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Institution>().ToTable("Institutions");
            modelBuilder.Entity<Subject>().ToTable("Subjects");
            modelBuilder.Entity<Preference>().ToTable("Preferences");
            modelBuilder.Entity<UserSubject>().ToTable("UserSubjects");
            modelBuilder.Entity<UserFollow>().ToTable("UserFollows");
            modelBuilder.Entity<Log>().ToTable("Logs");
            modelBuilder.Entity<Note>().ToTable("Notes");
            modelBuilder.Entity<NoteRating>().ToTable("NoteRatings");
            modelBuilder.Entity<Collection>().ToTable("Collections");
            modelBuilder.Entity<CollectionNote>().ToTable("CollectionNotes");
            modelBuilder.Entity<NoteRequest>().ToTable("NoteRequests");
            modelBuilder.Entity<NoteRequestAnswer>().ToTable("NoteRequestAnswers");

			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.NoAction;
			}
		}
    }
}
