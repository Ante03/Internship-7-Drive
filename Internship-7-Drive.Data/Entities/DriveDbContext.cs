using Internship_7_Drive.Data.Entities;
using Internship_7_Drive.Data.Entities.Models;
using Internship_7_Drive.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => new { u.Id });

            modelBuilder.Entity<Folder>()
                .HasKey(f => new { f.Id });

            modelBuilder.Entity<Folder>()
                .HasOne(f => f.Owner)
                .WithMany()
                .HasForeignKey(f => f.OwnerId);

            modelBuilder.Entity<Folder>()
                .HasOne(f => f.ParentFolder)
                .WithMany(f => f.Subfolders)
                .HasForeignKey(f => f.ParentFolderId);

            modelBuilder.Entity<Models.File>()
                .HasKey(mf => new { mf.Id });

            modelBuilder.Entity<Models.File>()
                .HasOne(f => f.Folder)
                .WithMany(f => f.Files)
                .HasForeignKey(f => f.FolderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Models.File>()
                .HasOne(o => o.Owner);

            modelBuilder.Entity<Comments>()
                .HasKey(c  => new { c.Id });
            modelBuilder.Entity<Comments>()
                .HasOne(c => c.Owner)
                .WithMany()
                .HasForeignKey(mf => mf.OwnerId);
            modelBuilder.Entity<Comments>()
                .HasOne(c => c.File)
                .WithMany()
                .HasForeignKey(mf => mf.FileId);

            modelBuilder.Entity<FileShared>()
                .HasKey(fs => new { fs.Id });
            modelBuilder.Entity<FileShared>()
                .HasOne(fs => fs.Owner)
                .WithMany()
                .HasForeignKey(fs => fs.OwnerId);
            modelBuilder.Entity<FileShared>()
                .HasOne(fs => fs.ShardWithUser)
                .WithMany()
                .HasForeignKey(fs => fs.ShardWithUserId);
            modelBuilder.Entity<FileShared>()
                .HasOne(fs => fs.File)
                .WithMany()
                .HasForeignKey(fs => fs.FileId);

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
