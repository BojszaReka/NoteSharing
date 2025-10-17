﻿using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasKey(x => x.ID);

            modelBuilder.Entity<Institution>().HasKey(x => x.ID);
            modelBuilder.Entity<Subject>().HasKey(x => x.ID);
            modelBuilder.Entity<Preference>().HasKey(x => x.ID);

            modelBuilder.Entity<UserSubject>().HasKey(x => new { x.UserID, x.SubjectID });
            modelBuilder.Entity<UserFollow>().HasKey(x => new { x.FollowerUserID, x.FollowedUserID });

            modelBuilder.Entity<Log>().HasKey(x => x.ID);

            modelBuilder.Entity<UserFollow>()
                .HasOne(uf => uf.FollowerUser)
                .WithMany(u => u.Followings)
                .HasForeignKey(uf => uf.FollowerUserID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserFollow>()
                .HasOne(uf => uf.FollowedUser)
                .WithMany(u => u.Followers)
                .HasForeignKey(uf => uf.FollowerUserID)
                .OnDelete(DeleteBehavior.NoAction);

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

			modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Institution>().ToTable("Institutions");
            modelBuilder.Entity<Subject>().ToTable("Subjects");
            modelBuilder.Entity<Preference>().ToTable("Preferences");
            modelBuilder.Entity<UserSubject>().ToTable("UserSubjects");
            modelBuilder.Entity<UserFollow>().ToTable("UserFollows");

			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.NoAction;
			}
		}
    }
}
