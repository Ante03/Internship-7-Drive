using Internship_7_Drive.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Ante", LastName = "Anić", Email = "ante.anic@gmail.com", Password = "password123" },
                new User { Id = 3, FirstName = "Ante", LastName = "Anić", Email = "ante.anic@gmail.com", Password = "password123" },
                new User { Id = 2, FirstName = "Marko", LastName = "Markić", Email = "marko.markic@gmail.com", Password = "password456" }
            );

            modelBuilder.Entity<Folder>().HasData(
                new Folder { Id = 1, Name = "Root Folder", OwnerId = 1, ParentFolderId = null, CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), LastChangedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Folder { Id = 2, Name = "Documents", OwnerId = 1, ParentFolderId = 1, CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), LastChangedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
            );

            modelBuilder.Entity<Entities.Models.File>().HasData(
                new Entities.Models.File { Id = 1, Name = "File1.txt", Content = "Ovo je sadržaj datoteke.", OwnerId = 1, FolderId = 2, CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), LastChangedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Entities.Models.File { Id = 2, Name = "File2.txt", Content = "Još jedan sadržaj datoteke.", OwnerId = 2, FolderId = 1, CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), LastChangedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
            );

            modelBuilder.Entity<FileShared>().HasData(
                new FileShared { Id = 1, FileId = 1, OwnerId = 1, ShardWithUserId = 2 }
            );

            modelBuilder.Entity<Comments>().HasData(
                new Comments { Id = 1, Content = "Ovo je komentar na datoteku.", CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = null, OwnerId = 2, FileId = 1 }
            );
        }
        
    }
}
