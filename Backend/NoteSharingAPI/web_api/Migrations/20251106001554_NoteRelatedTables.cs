using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_api.Migrations
{
    /// <inheritdoc />
    public partial class NoteRelatedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFollows_Users_FollowerUserID1",
                table: "UserFollows");

            migrationBuilder.DropIndex(
                name: "IX_UserFollows_FollowerUserID1",
                table: "UserFollows");

            migrationBuilder.DropColumn(
                name: "FollowerUserID1",
                table: "UserFollows");

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Private = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Collections_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "NoteRequests",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatorUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NoteRequests_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_NoteRequests_Users_CreatorUserID",
                        column: x => x.CreatorUserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstitutionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Notes_Institutions_InstitutionID",
                        column: x => x.InstitutionID,
                        principalTable: "Institutions",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Notes_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Notes_Users_AuthorUserID",
                        column: x => x.AuthorUserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "NoteRequestAnswers",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UploaderUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteRequestAnswers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NoteRequestAnswers_NoteRequests_RequestID",
                        column: x => x.RequestID,
                        principalTable: "NoteRequests",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_NoteRequestAnswers_Users_UploaderUserID",
                        column: x => x.UploaderUserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CollectionNotes",
                columns: table => new
                {
                    NoteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CollectionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionNotes", x => new { x.CollectionID, x.NoteID });
                    table.ForeignKey(
                        name: "FK_CollectionNotes_Collections_CollectionID",
                        column: x => x.CollectionID,
                        principalTable: "Collections",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CollectionNotes_Notes_NoteID",
                        column: x => x.NoteID,
                        principalTable: "Notes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "NoteRatings",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteRatings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NoteRatings_Notes_NoteID",
                        column: x => x.NoteID,
                        principalTable: "Notes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_NoteRatings_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFollows_FollowedUserID",
                table: "UserFollows",
                column: "FollowedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionNotes_NoteID",
                table: "CollectionNotes",
                column: "NoteID");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_UserID",
                table: "Collections",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_NoteRatings_NoteID",
                table: "NoteRatings",
                column: "NoteID");

            migrationBuilder.CreateIndex(
                name: "IX_NoteRatings_UserID",
                table: "NoteRatings",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_NoteRequestAnswers_RequestID",
                table: "NoteRequestAnswers",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_NoteRequestAnswers_UploaderUserID",
                table: "NoteRequestAnswers",
                column: "UploaderUserID");

            migrationBuilder.CreateIndex(
                name: "IX_NoteRequests_CreatorUserID",
                table: "NoteRequests",
                column: "CreatorUserID");

            migrationBuilder.CreateIndex(
                name: "IX_NoteRequests_SubjectID",
                table: "NoteRequests",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_AuthorUserID",
                table: "Notes",
                column: "AuthorUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_InstitutionID",
                table: "Notes",
                column: "InstitutionID");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_SubjectID",
                table: "Notes",
                column: "SubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollows_Users_FollowedUserID",
                table: "UserFollows",
                column: "FollowedUserID",
                principalTable: "Users",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFollows_Users_FollowedUserID",
                table: "UserFollows");

            migrationBuilder.DropTable(
                name: "CollectionNotes");

            migrationBuilder.DropTable(
                name: "NoteRatings");

            migrationBuilder.DropTable(
                name: "NoteRequestAnswers");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "NoteRequests");

            migrationBuilder.DropIndex(
                name: "IX_UserFollows_FollowedUserID",
                table: "UserFollows");

            migrationBuilder.AddColumn<Guid>(
                name: "FollowerUserID1",
                table: "UserFollows",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserFollows_FollowerUserID1",
                table: "UserFollows",
                column: "FollowerUserID1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollows_Users_FollowerUserID1",
                table: "UserFollows",
                column: "FollowerUserID1",
                principalTable: "Users",
                principalColumn: "ID");
        }
    }
}
