using Internship_7_Drive.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Drive.Data.Seeds
{
    public class DatabaseSeeder
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Entities.Models.File> Files { get; set; }
        public DbSet<FileShared> FileShared { get; set; }
        public DbSet<FolderShared> FolderShared { get; set; }
        public DbSet<Comments> Comments { get; set; }

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Ante", LastName = "Antić", Email = "ante.antic@gmail.com", Password = "lozinka1" },
                new User { Id = 2, FirstName = "Marko", LastName = "Marić", Email = "marko.maric@gmail.com", Password = "lozinka2" },
                new User { Id = 3, FirstName = "Ivan", LastName = "Ivić", Email = "ivan.ivic@gmail.com", Password = "lozinka3" },
                new User { Id = 4, FirstName = "Stipe", LastName = "Stipić", Email = "stipe.stipic@gmail.com", Password = "lozinka4" },
                new User { Id = 5, FirstName = "Luka", LastName = "Lukić", Email = "luka.lukic@gmail.com", Password = "lozinka5" },
                new User { Id = 6, FirstName = "Karlo", LastName = "Karlić", Email = "karlo.karlic@gmail.com", Password = "lozinka6" },
                new User { Id = 7, FirstName = "Josip", LastName = "Josić", Email = "josip.josic@gmail.com", Password = "lozinka7" },
                new User { Id = 8, FirstName = "Mate", LastName = "Matić", Email = "mate.matic@gmail.com", Password = "lozinka8" },
                new User { Id = 9, FirstName = "Nikola", LastName = "Nikolić", Email = "nikola.nikolic@gmail.com", Password = "lozinka9" },
                new User { Id = 10, FirstName = "Toni", LastName = "Tonić", Email = "toni.tonic@gmail.com", Password = "lozinka10" }
            );

            modelBuilder.Entity<Folder>().HasData(
                new Folder { Id = 1, Name = "Dokumenti", OwnerId = 1, CreatedAt = DateTimeOffset.Now, LastChangedAt = DateTimeOffset.Now },
                new Folder { Id = 2, Name = "Slike", OwnerId = 2, CreatedAt = DateTimeOffset.Now, LastChangedAt = DateTimeOffset.Now },
                new Folder { Id = 3, Name = "Projekti", OwnerId = 3, CreatedAt = DateTimeOffset.Now, LastChangedAt = DateTimeOffset.Now },
                new Folder { Id = 4, Name = "Muzika", OwnerId = 4, CreatedAt = DateTimeOffset.Now, LastChangedAt = DateTimeOffset.Now },
                new Folder { Id = 5, Name = "Video", OwnerId = 5, CreatedAt = DateTimeOffset.Now, LastChangedAt = DateTimeOffset.Now },
                new Folder { Id = 6, Name = "Arhiva", OwnerId = 6, CreatedAt = DateTimeOffset.Now, LastChangedAt = DateTimeOffset.Now },
                new Folder { Id = 7, Name = "Backup", OwnerId = 7, CreatedAt = DateTimeOffset.Now, LastChangedAt = DateTimeOffset.Now },
                new Folder { Id = 8, Name = "Bilješke", OwnerId = 8, CreatedAt = DateTimeOffset.Now, LastChangedAt = DateTimeOffset.Now },
                new Folder { Id = 9, Name = "Reference", OwnerId = 9, CreatedAt = DateTimeOffset.Now, LastChangedAt = DateTimeOffset.Now },
                new Folder { Id = 10, Name = "Osobno", OwnerId = 10, CreatedAt = DateTimeOffset.Now, LastChangedAt = DateTimeOffset.Now }
            );

            modelBuilder.Entity<Entities.Models.File>().HasData(
                new Entities.Models.File { Id = 1, Name = "file1.txt", Content = "Sadržaj datoteke 1", OwnerId = 1, FolderId = 1, CreatedAt = DateTimeOffset.Now, LastChangedAt = DateTimeOffset.Now },
                new Entities.Models.File { Id = 2, Name = "file2.txt", Content = "Sadržaj datoteke 2", OwnerId = 2, FolderId = 2, CreatedAt = DateTimeOffset.Now, LastChangedAt = DateTimeOffset.Now }
            );

            modelBuilder.Entity<Comments>().HasData(
                new Comments { Id = 1, Content = "Komentar 1", CreatedAt = DateTimeOffset.Now, OwnerId = 1, FileId = 1 },
                new Comments { Id = 2, Content = "Komentar 2", CreatedAt = DateTimeOffset.Now, OwnerId = 2, FileId = 2 }
            );

            modelBuilder.Entity<FileShared>().HasData(
                new FileShared { FileId = 1, OwnerId = 1, SharedWithUserId = 3, ParentFolderId = 1 },
                new FileShared { FileId = 2, OwnerId = 2, SharedWithUserId = 4, ParentFolderId = 2 }
            );

            modelBuilder.Entity<FolderShared>().HasData(
                new FolderShared { FolderId = 1, OwnerId = 1, SharedWithUserId = 2 },
                new FolderShared { FolderId = 2, OwnerId = 2, SharedWithUserId = 4 }
            );
        }
    }
}
