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
        public DbSet<Comments> Comments { get; set; }

        public static void Seed(ModelBuilder modelBuilder)
        {
            var users = new List<User>
            {
                new User { FirstName = "Ante", LastName = "Antic", Email = "ante@gmail.com", Password = "password1" },
                new User { FirstName = "Marko", LastName = "Markic", Email = "marko@gmail.com", Password = "password2" },
                new User { FirstName = "Mate", LastName = "Matic", Email = "mate@gmail.com", Password = "password3" },
                new User { FirstName = "Marija", LastName = "Maric", Email = "marija@gmail.com", Password = "password4" },
                new User { FirstName = "Marta", LastName = "Martic", Email = "marta@gmail.com", Password = "password5" },
            };

            modelBuilder.Entity<User>().HasData(users);

            var folders = new List<Folder>
            {
                new Folder { Id = 1, Name = "Folder1", OwnerMail = "ante@gmail.com", CreatedAt = DateTimeOffset.Now, LastChangedAt = DateTimeOffset.Now },
                new Folder { Id = 2, Name = "Folder2", OwnerMail = "marko@gmail.com", CreatedAt = DateTimeOffset.Now, LastChangedAt = DateTimeOffset.Now },
                new Folder { Id = 3, Name = "Folder3", OwnerMail = "mate@gmail.com", CreatedAt = DateTimeOffset.Now, LastChangedAt = DateTimeOffset.Now },
                new Folder { Id = 4, Name = "Folder4", OwnerMail = "marija@gmail.com", CreatedAt = DateTimeOffset.Now, LastChangedAt = DateTimeOffset.Now },
                new Folder { Id = 5, Name = "Folder5", OwnerMail = "marta@gmail.com", CreatedAt = DateTimeOffset.Now, LastChangedAt = DateTimeOffset.Now },
            };

            modelBuilder.Entity<Folder>().HasData(folders);

            var files = new List<Entities.Models.File>
            {
                new Entities.Models.File { Id = 1, Name = "File1", Content = "Content1", OwnerMail = "ante@gmail.com", FolderId = 1, CreatedAt = DateTimeOffset.Now, LastChangedAt = DateTimeOffset.Now },
                new Entities.Models.File { Id = 2, Name = "File2", Content = "Content2", OwnerMail = "marko@gmail.com", FolderId = 2, CreatedAt = DateTimeOffset.Now, LastChangedAt = DateTimeOffset.Now },
                new Entities.Models.File { Id = 3, Name = "File3", Content = "Content3", OwnerMail = "mate@gmail.com", FolderId = 3, CreatedAt = DateTimeOffset.Now, LastChangedAt = DateTimeOffset.Now },
                new Entities.Models.File { Id = 4, Name = "File4", Content = "Content4", OwnerMail = "marija@gmail.com", FolderId = 4, CreatedAt = DateTimeOffset.Now, LastChangedAt = DateTimeOffset.Now },
                new Entities.Models.File { Id = 5, Name = "File5", Content = "Content5", OwnerMail = "marta@gmail.com", FolderId = 5, CreatedAt = DateTimeOffset.Now, LastChangedAt = DateTimeOffset.Now },
            };

            modelBuilder.Entity<Entities.Models.File>().HasData(files);


            var comments = new List<Comments>
            {
                new Comments { Id = 1, Content = "Comment1", CreatedAt = DateTimeOffset.Now, OwnerMail = "ante@gmail.com", FileId = 1 },
                new Comments { Id = 2, Content = "Comment2", CreatedAt = DateTimeOffset.Now, OwnerMail = "marko@gmail.com", FileId = 2 },
                new Comments { Id = 3, Content = "Comment3", CreatedAt = DateTimeOffset.Now, OwnerMail = "mate@gmail.com", FileId = 3 },
                new Comments { Id = 4, Content = "Comment4", CreatedAt = DateTimeOffset.Now, OwnerMail = "marija@gmail.com", FileId = 4 },
                new Comments { Id = 5, Content = "Comment5", CreatedAt = DateTimeOffset.Now, OwnerMail = "marta@gmail.com", FileId = 5 },
            };

            modelBuilder.Entity<Comments>().HasData(comments);

            var fileShared = new List<FileShared>
            {
                new FileShared { Id = 1, FileId = 1, OwnerMail = "ante@gmail.com", SharedWithUserMail = "marta@gmail.com" },
                new FileShared { Id = 2, FileId = 2, OwnerMail = "marko@gmail.com", SharedWithUserMail = "ante@gmail.com" },
                new FileShared { Id = 3, FileId = 3, OwnerMail = "mate@gmail.com", SharedWithUserMail = "marko@gmail.com" },
                new FileShared { Id = 4, FileId = 4, OwnerMail = "marija@gmail.com", SharedWithUserMail = "mate@gmail.com" },
                new FileShared { Id = 5, FileId = 5, OwnerMail = "marta@gmail.com", SharedWithUserMail = "marija@gmail.com" },
            };

            modelBuilder.Entity<FileShared>().HasData(fileShared);
        }
    }
}
