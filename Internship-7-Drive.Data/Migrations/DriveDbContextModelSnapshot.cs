﻿// <auto-generated />
using System;
using Internship_7_Drive.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Internship_7_Drive.Data.Migrations
{
    [DbContext(typeof(DriveDbContext))]
    partial class DriveDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Internship_7_Drive.Data.Entities.Models.Comments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("FileId")
                        .HasColumnType("integer");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Ovo je komentar na datoteku.",
                            CreatedAt = new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FileId = 1,
                            OwnerId = 2
                        });
                });

            modelBuilder.Entity("Internship_7_Drive.Data.Entities.Models.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("FolderId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("LastChangedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FolderId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Files");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Ovo je sadržaj datoteke.",
                            CreatedAt = new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FolderId = 2,
                            LastChangedAt = new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "File1.txt",
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 2,
                            Content = "Još jedan sadržaj datoteke.",
                            CreatedAt = new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FolderId = 1,
                            LastChangedAt = new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "File2.txt",
                            OwnerId = 2
                        });
                });

            modelBuilder.Entity("Internship_7_Drive.Data.Entities.Models.FileShared", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FileId")
                        .HasColumnType("integer");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<int>("ShardWithUserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ShardWithUserId");

                    b.ToTable("FileShareds");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FileId = 1,
                            OwnerId = 1,
                            ShardWithUserId = 2
                        });
                });

            modelBuilder.Entity("Internship_7_Drive.Data.Entities.Models.Folder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("LastChangedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<int?>("ParentFolderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ParentFolderId");

                    b.ToTable("Folders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            LastChangedAt = new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "Root Folder",
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            LastChangedAt = new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "Documents",
                            OwnerId = 1,
                            ParentFolderId = 1
                        });
                });

            modelBuilder.Entity("Internship_7_Drive.Data.Entities.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "ante.anic@gmail.com",
                            FirstName = "Ante",
                            LastName = "Anić",
                            Password = "password123"
                        },
                        new
                        {
                            Id = 3,
                            Email = "ante.anic@gmail.com",
                            FirstName = "Ante",
                            LastName = "Anić",
                            Password = "password123"
                        },
                        new
                        {
                            Id = 2,
                            Email = "marko.markic@gmail.com",
                            FirstName = "Marko",
                            LastName = "Markić",
                            Password = "password456"
                        });
                });

            modelBuilder.Entity("Internship_7_Drive.Data.Entities.Models.Comments", b =>
                {
                    b.HasOne("Internship_7_Drive.Data.Entities.Models.File", "File")
                        .WithMany()
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Internship_7_Drive.Data.Entities.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("File");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Internship_7_Drive.Data.Entities.Models.File", b =>
                {
                    b.HasOne("Internship_7_Drive.Data.Entities.Models.Folder", "Folder")
                        .WithMany("Files")
                        .HasForeignKey("FolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Internship_7_Drive.Data.Entities.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Folder");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Internship_7_Drive.Data.Entities.Models.FileShared", b =>
                {
                    b.HasOne("Internship_7_Drive.Data.Entities.Models.File", "File")
                        .WithMany()
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Internship_7_Drive.Data.Entities.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Internship_7_Drive.Data.Entities.Models.User", "ShardWithUser")
                        .WithMany()
                        .HasForeignKey("ShardWithUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("File");

                    b.Navigation("Owner");

                    b.Navigation("ShardWithUser");
                });

            modelBuilder.Entity("Internship_7_Drive.Data.Entities.Models.Folder", b =>
                {
                    b.HasOne("Internship_7_Drive.Data.Entities.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Internship_7_Drive.Data.Entities.Models.Folder", "ParentFolder")
                        .WithMany("Subfolders")
                        .HasForeignKey("ParentFolderId");

                    b.Navigation("Owner");

                    b.Navigation("ParentFolder");
                });

            modelBuilder.Entity("Internship_7_Drive.Data.Entities.Models.Folder", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("Subfolders");
                });
#pragma warning restore 612, 618
        }
    }
}
