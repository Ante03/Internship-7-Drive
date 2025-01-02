using Internship_7_Drive.Data.Entities;
using Internship_7_Drive.Data.Entities.Models;
using Internship_7_Drive.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Internship_7_Drive.Data.Entities
{
    public class DriveDbContext : DbContext
    {
        public DriveDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Folder> Folders => Set<Folder>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Models.File> Files => Set<Models.File>();
        public DbSet<Comments> Comments => Set<Comments>();
        public DbSet<FileShared> FileShareds => Set<FileShared>();
        public DbSet<FolderShared> FolderShareds => Set<FolderShared>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => new { u.Id });

            modelBuilder.Entity<Folder>()
                .HasKey(f => new { f.Id });

            modelBuilder.Entity<Folder>()
                .HasOne(f => f.Owner)
                .WithMany()
                .HasForeignKey(f => f.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Folder>()
                .HasOne(f => f.ParentFolder)
                .WithMany(f => f.Subfolders)
                .HasForeignKey(f => f.ParentFolderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Models.File>()
                .HasKey(mf => new { mf.Id });

            modelBuilder.Entity<Models.File>()
                .HasOne(f => f.Folder)
                .WithMany(f => f.Files)
                .HasForeignKey(f => f.FolderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Models.File>()
                .HasOne(o => o.Owner)
                .WithMany()
                .HasForeignKey(o => o.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comments>()
                .HasKey(c  => new { c.Id });
            modelBuilder.Entity<Comments>()
                .HasOne(c => c.Owner)
                .WithMany()
                .HasForeignKey(mf => mf.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Comments>()
                .HasOne(c => c.File)
                .WithMany()
                .HasForeignKey(mf => mf.FileId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FileShared>()
                .HasKey(fs => new { fs.FileId, fs.OwnerId, fs.SharedWithUserId });

            modelBuilder.Entity<FileShared>()
                .HasOne(fs => fs.Owner)
                .WithMany()
                .HasForeignKey(fs => fs.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FileShared>()
                .HasOne(fs => fs.ShardWithUser)
                .WithMany()
                .HasForeignKey(fs => fs.SharedWithUserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FileShared>()
                .HasOne(fs => fs.File)
                .WithMany()
                .HasForeignKey(fs => fs.FileId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FileShared>()
                .HasOne(fs => fs.ParentFolder)
                .WithMany()
                .HasForeignKey(fs => fs.ParentFolderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FolderShared>()
                .HasKey(fs => new { fs.SharedWithUserId, fs.OwnerId, fs.FolderId });

            modelBuilder.Entity<FolderShared>()
                .HasOne(fs => fs.Owner)
                .WithMany()
                .HasForeignKey(fs => fs.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FolderShared>()
                .HasOne(fs => fs.ShardWithUser)
                .WithMany()
                .HasForeignKey(fs => fs.SharedWithUserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FolderShared>()
                .HasOne(fs => fs.ParentFolder)
                .WithMany()
                .HasForeignKey(fs => fs.ParentFolderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FolderShared>()
                .HasOne(fs => fs.Folder)
                .WithMany()
                .HasForeignKey(fs => fs.FolderId)
                .OnDelete(DeleteBehavior.Cascade);

            DatabaseSeeder.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
public class DriveDbContextFactory : IDesignTimeDbContextFactory<DriveDbContext>
{
    public DriveDbContext CreateDbContext(string[] args)
    {
        var connectionString = "Host=127.0.0.1;Port=5433;Database=DumpProject;User Id=postgres;Password=novcanik";

        var options = new DbContextOptionsBuilder<DriveDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        return new DriveDbContext(options);
    }
}
