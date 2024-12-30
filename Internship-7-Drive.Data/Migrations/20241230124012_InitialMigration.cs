using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Internship_7_Drive.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    OwnerMail = table.Column<string>(type: "text", nullable: false),
                    ParentFolderId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastChangedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folders_Folders_ParentFolderId",
                        column: x => x.ParentFolderId,
                        principalTable: "Folders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Folders_Users_OwnerMail",
                        column: x => x.OwnerMail,
                        principalTable: "Users",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    OwnerMail = table.Column<string>(type: "text", nullable: false),
                    FolderId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastChangedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Folders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "Folders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Files_Users_OwnerMail",
                        column: x => x.OwnerMail,
                        principalTable: "Users",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    OwnerMail = table.Column<string>(type: "text", nullable: false),
                    FileId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_OwnerMail",
                        column: x => x.OwnerMail,
                        principalTable: "Users",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FileShareds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileId = table.Column<int>(type: "integer", nullable: false),
                    OwnerMail = table.Column<string>(type: "text", nullable: false),
                    SharedWithUserMail = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileShareds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileShareds_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileShareds_Users_OwnerMail",
                        column: x => x.OwnerMail,
                        principalTable: "Users",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileShareds_Users_SharedWithUserMail",
                        column: x => x.SharedWithUserMail,
                        principalTable: "Users",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { "ante@gmail.com", "Ante", "Antic", "password1" },
                    { "marija@gmail.com", "Marija", "Maric", "password4" },
                    { "marko@gmail.com", "Marko", "Markic", "password2" },
                    { "marta@gmail.com", "Marta", "Martic", "password5" },
                    { "mate@gmail.com", "Mate", "Matic", "password3" }
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "CreatedAt", "LastChangedAt", "Name", "OwnerMail", "ParentFolderId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2024, 12, 30, 13, 40, 11, 718, DateTimeKind.Unspecified).AddTicks(7501), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 12, 30, 13, 40, 11, 718, DateTimeKind.Unspecified).AddTicks(7582), new TimeSpan(0, 1, 0, 0, 0)), "Folder1", "ante@gmail.com", null },
                    { 2, new DateTimeOffset(new DateTime(2024, 12, 30, 13, 40, 11, 718, DateTimeKind.Unspecified).AddTicks(7591), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 12, 30, 13, 40, 11, 718, DateTimeKind.Unspecified).AddTicks(7595), new TimeSpan(0, 1, 0, 0, 0)), "Folder2", "marko@gmail.com", null },
                    { 3, new DateTimeOffset(new DateTime(2024, 12, 30, 13, 40, 11, 718, DateTimeKind.Unspecified).AddTicks(7599), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 12, 30, 13, 40, 11, 718, DateTimeKind.Unspecified).AddTicks(7602), new TimeSpan(0, 1, 0, 0, 0)), "Folder3", "mate@gmail.com", null },
                    { 4, new DateTimeOffset(new DateTime(2024, 12, 30, 13, 40, 11, 718, DateTimeKind.Unspecified).AddTicks(7606), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 12, 30, 13, 40, 11, 718, DateTimeKind.Unspecified).AddTicks(7608), new TimeSpan(0, 1, 0, 0, 0)), "Folder4", "marija@gmail.com", null },
                    { 5, new DateTimeOffset(new DateTime(2024, 12, 30, 13, 40, 11, 718, DateTimeKind.Unspecified).AddTicks(7612), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 12, 30, 13, 40, 11, 718, DateTimeKind.Unspecified).AddTicks(7615), new TimeSpan(0, 1, 0, 0, 0)), "Folder5", "marta@gmail.com", null }
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "Content", "CreatedAt", "FolderId", "LastChangedAt", "Name", "OwnerMail" },
                values: new object[,]
                {
                    { 1, "Content1", new DateTimeOffset(new DateTime(2024, 12, 30, 13, 40, 11, 718, DateTimeKind.Unspecified).AddTicks(7670), new TimeSpan(0, 1, 0, 0, 0)), 1, new DateTimeOffset(new DateTime(2024, 12, 30, 13, 40, 11, 718, DateTimeKind.Unspecified).AddTicks(7674), new TimeSpan(0, 1, 0, 0, 0)), "File1", "ante@gmail.com" },
                    { 2, "Content2", new DateTimeOffset(new DateTime(2024, 12, 30, 13, 40, 11, 718, DateTimeKind.Unspecified).AddTicks(7682), new TimeSpan(0, 1, 0, 0, 0)), 2, new DateTimeOffset(new DateTime(2024, 12, 30, 13, 40, 11, 718, DateTimeKind.Unspecified).AddTicks(7685), new TimeSpan(0, 1, 0, 0, 0)), "File2", "marko@gmail.com" },
                    { 3, "Content3", new DateTimeOffset(new DateTime(2024, 12, 30, 13, 40, 11, 718, DateTimeKind.Unspecified).AddTicks(7689), new TimeSpan(0, 1, 0, 0, 0)), 3, new DateTimeOffset(new DateTime(2024, 12, 30, 13, 40, 11, 718, DateTimeKind.Unspecified).AddTicks(7692), new TimeSpan(0, 1, 0, 0, 0)), "File3", "mate@gmail.com" },
                    { 4, "Content4", new DateTimeOffset(new DateTime(2024, 12, 30, 13, 40, 11, 718, DateTimeKind.Unspecified).AddTicks(7696), new TimeSpan(0, 1, 0, 0, 0)), 4, new DateTimeOffset(new DateTime(2024, 12, 30, 13, 40, 11, 718, DateTimeKind.Unspecified).AddTicks(7698), new TimeSpan(0, 1, 0, 0, 0)), "File4", "marija@gmail.com" },
                    { 5, "Content5", new DateTimeOffset(new DateTime(2024, 12, 30, 13, 40, 11, 718, DateTimeKind.Unspecified).AddTicks(7703), new TimeSpan(0, 1, 0, 0, 0)), 5, new DateTimeOffset(new DateTime(2024, 12, 30, 13, 40, 11, 718, DateTimeKind.Unspecified).AddTicks(7705), new TimeSpan(0, 1, 0, 0, 0)), "File5", "marta@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "FileId", "OwnerMail", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Comment1", new DateTimeOffset(new DateTime(2024, 12, 30, 13, 40, 11, 718, DateTimeKind.Unspecified).AddTicks(7751), new TimeSpan(0, 1, 0, 0, 0)), 1, "ante@gmail.com", null },
                    { 2, "Comment2", new DateTimeOffset(new DateTime(2024, 12, 30, 13, 40, 11, 718, DateTimeKind.Unspecified).AddTicks(7760), new TimeSpan(0, 1, 0, 0, 0)), 2, "marko@gmail.com", null },
                    { 3, "Comment3", new DateTimeOffset(new DateTime(2024, 12, 30, 13, 40, 11, 718, DateTimeKind.Unspecified).AddTicks(7765), new TimeSpan(0, 1, 0, 0, 0)), 3, "mate@gmail.com", null },
                    { 4, "Comment4", new DateTimeOffset(new DateTime(2024, 12, 30, 13, 40, 11, 718, DateTimeKind.Unspecified).AddTicks(7768), new TimeSpan(0, 1, 0, 0, 0)), 4, "marija@gmail.com", null },
                    { 5, "Comment5", new DateTimeOffset(new DateTime(2024, 12, 30, 13, 40, 11, 718, DateTimeKind.Unspecified).AddTicks(7772), new TimeSpan(0, 1, 0, 0, 0)), 5, "marta@gmail.com", null }
                });

            migrationBuilder.InsertData(
                table: "FileShareds",
                columns: new[] { "Id", "FileId", "OwnerMail", "SharedWithUserMail" },
                values: new object[,]
                {
                    { 1, 1, "ante@gmail.com", "marta@gmail.com" },
                    { 2, 2, "marko@gmail.com", "ante@gmail.com" },
                    { 3, 3, "mate@gmail.com", "marko@gmail.com" },
                    { 4, 4, "marija@gmail.com", "mate@gmail.com" },
                    { 5, 5, "marta@gmail.com", "marija@gmail.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FileId",
                table: "Comments",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_OwnerMail",
                table: "Comments",
                column: "OwnerMail");

            migrationBuilder.CreateIndex(
                name: "IX_Files_FolderId",
                table: "Files",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_OwnerMail",
                table: "Files",
                column: "OwnerMail");

            migrationBuilder.CreateIndex(
                name: "IX_FileShareds_FileId",
                table: "FileShareds",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_FileShareds_OwnerMail",
                table: "FileShareds",
                column: "OwnerMail");

            migrationBuilder.CreateIndex(
                name: "IX_FileShareds_SharedWithUserMail",
                table: "FileShareds",
                column: "SharedWithUserMail");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_OwnerMail",
                table: "Folders",
                column: "OwnerMail");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_ParentFolderId",
                table: "Folders",
                column: "ParentFolderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "FileShareds");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
