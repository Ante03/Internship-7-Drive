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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
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
                        name: "FK_Folders_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
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
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
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
                        name: "FK_Files_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
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
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
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
                        name: "FK_Comments_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FileShareds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileId = table.Column<int>(type: "integer", nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    SharedWithUserId = table.Column<int>(type: "integer", nullable: false)
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
                        name: "FK_FileShareds_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileShareds_Users_SharedWithUserId",
                        column: x => x.SharedWithUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, "ante.antic@gmail.com", "Ante", "Antić", "lozinka1" },
                    { 2, "marko.maric@gmail.com", "Marko", "Marić", "lozinka2" },
                    { 3, "ivan.ivic@gmail.com", "Ivan", "Ivić", "lozinka3" },
                    { 4, "stipe.stipic@gmail.com", "Stipe", "Stipić", "lozinka4" },
                    { 5, "luka.lukic@gmail.com", "Luka", "Lukić", "lozinka5" },
                    { 6, "karlo.karlic@gmail.com", "Karlo", "Karlić", "lozinka6" },
                    { 7, "josip.josic@gmail.com", "Josip", "Josić", "lozinka7" },
                    { 8, "mate.matic@gmail.com", "Mate", "Matić", "lozinka8" },
                    { 9, "nikola.nikolic@gmail.com", "Nikola", "Nikolić", "lozinka9" },
                    { 10, "toni.tonic@gmail.com", "Toni", "Tonić", "lozinka10" }
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "CreatedAt", "LastChangedAt", "Name", "OwnerId", "ParentFolderId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8336), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8404), new TimeSpan(0, 1, 0, 0, 0)), "Dokumenti", 1, null },
                    { 2, new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8408), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8409), new TimeSpan(0, 1, 0, 0, 0)), "Slike", 2, null },
                    { 3, new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8412), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8413), new TimeSpan(0, 1, 0, 0, 0)), "Projekti", 3, null },
                    { 4, new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8416), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8417), new TimeSpan(0, 1, 0, 0, 0)), "Muzika", 4, null },
                    { 5, new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8419), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8421), new TimeSpan(0, 1, 0, 0, 0)), "Video", 5, null },
                    { 6, new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8423), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8425), new TimeSpan(0, 1, 0, 0, 0)), "Arhiva", 6, null },
                    { 7, new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8427), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8428), new TimeSpan(0, 1, 0, 0, 0)), "Backup", 7, null },
                    { 8, new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8430), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8432), new TimeSpan(0, 1, 0, 0, 0)), "Bilješke", 8, null },
                    { 9, new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8434), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8435), new TimeSpan(0, 1, 0, 0, 0)), "Reference", 9, null },
                    { 10, new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8437), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8439), new TimeSpan(0, 1, 0, 0, 0)), "Osobno", 10, null }
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "Content", "CreatedAt", "FolderId", "LastChangedAt", "Name", "OwnerId" },
                values: new object[,]
                {
                    { 1, "Sadržaj datoteke 1", new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8471), new TimeSpan(0, 1, 0, 0, 0)), 1, new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8474), new TimeSpan(0, 1, 0, 0, 0)), "file1.txt", 1 },
                    { 2, "Sadržaj datoteke 2", new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8477), new TimeSpan(0, 1, 0, 0, 0)), 2, new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8478), new TimeSpan(0, 1, 0, 0, 0)), "file2.txt", 2 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "FileId", "OwnerId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Komentar 1", new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8501), new TimeSpan(0, 1, 0, 0, 0)), 1, 1, null },
                    { 2, "Komentar 2", new DateTimeOffset(new DateTime(2024, 12, 30, 19, 41, 48, 901, DateTimeKind.Unspecified).AddTicks(8506), new TimeSpan(0, 1, 0, 0, 0)), 2, 2, null }
                });

            migrationBuilder.InsertData(
                table: "FileShareds",
                columns: new[] { "Id", "FileId", "OwnerId", "SharedWithUserId" },
                values: new object[,]
                {
                    { 1, 1, 1, 3 },
                    { 2, 2, 2, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FileId",
                table: "Comments",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_OwnerId",
                table: "Comments",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_FolderId",
                table: "Files",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_OwnerId",
                table: "Files",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_FileShareds_FileId",
                table: "FileShareds",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_FileShareds_OwnerId",
                table: "FileShareds",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_FileShareds_SharedWithUserId",
                table: "FileShareds",
                column: "SharedWithUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_OwnerId",
                table: "Folders",
                column: "OwnerId");

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
