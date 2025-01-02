using Internship_7_Drive.Data.Entities.Models;
using Internship_7_Drive.Data.Entities;
using Internship_7_Drive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_7_Drive.Domain.Repositories
{
    public class FileSharedRepository : BaseRepository
    {
        public FileSharedRepository(DriveDbContext dbContext) : base(dbContext)
        {
        }
        public Data.Entities.Models.File? GetByNameFile(string name, int ownerId)
        {
            return DbContext.Files.FirstOrDefault(f => f.Name == name && f.OwnerId == ownerId);
        }

        public FileShared? GetByNameFileShared(string name, int ownerId)
        {
            return DbContext.FileShareds.FirstOrDefault(f => f.SharedWithUserId == ownerId && f.File.Name == name);
        }

        public User? GetByMailUser(string mail)
        {
            return DbContext.Users.FirstOrDefault(u => u.Email == mail);
        }

        public FileShared? CheckNewFile(int fileId, int ownerId, int sharedWithId)
        {
            return DbContext.FileShareds.FirstOrDefault(fs => fs.FileId == fileId && fs.OwnerId == ownerId && fs.SharedWithUserId == sharedWithId);
        }

        public ResponseResultType Share(string nameOfFile, int ownerId, string newUserMail)
        {
            var file = GetByNameFile(nameOfFile, ownerId);
            if (file == null)
                return ResponseResultType.NotFound;

            if (ownerId != file.OwnerId)
                return ResponseResultType.ValidationError;

            var newUser = GetByMailUser(newUserMail);
            if (newUser == null)
                return ResponseResultType.NotFound;

            var parentFolderId = file.FolderId;
            var newSharedFile = new FileShared { FileId = file.Id, ParentFolderId = parentFolderId, OwnerId = ownerId, SharedWithUserId = newUser.Id };
            if (CheckNewFile(file.Id, ownerId, newUser.Id) == null)
                DbContext.FileShareds.Add(newSharedFile);
            else
                return ResponseResultType.AlreadyExists;

            SaveChanges();
            return ResponseResultType.Success;
        }

        public ResponseResultType Delete(string fileName, int ownerId, string userMail)
        {
            var sharedWithUser = GetByMailUser(userMail);
            if (sharedWithUser == null)
                return ResponseResultType.NotFound;

            var file = GetByNameFile(fileName, ownerId);
            if(file == null)
                return ResponseResultType.NotFound;

            var fileSharedToDelete = CheckNewFile(file.Id, ownerId, sharedWithUser.Id);
            if (fileSharedToDelete == null)
                return ResponseResultType.NotFound;

            DbContext.FileShareds.Remove(fileSharedToDelete);
            SaveChanges();
            return ResponseResultType.Success;
        }

        public List<Data.Entities.Models.File> GetAllFilesSharedWithUser(int ownerId)
        {
            return DbContext.FileShareds
                .Where(fs => fs.SharedWithUserId == ownerId)
                .Select(fs => fs.File)
                .ToList();
        }

        public ResponseResultType EditFile(string fileName, int ownerId)
        {
            var fileShared = GetByNameFileShared(fileName, ownerId);
            if (fileShared == null)
                return ResponseResultType.NotFound;
            var file = fileShared.File;

            var lines = file.Content.Split('\n').ToList();
            Console.WriteLine("Uređivanje datoteke. Za pomoć, unesite ':help'.");

            int currentLine = lines.Count;
            while (true)
            {
                var input = Console.ReadLine();

                if (input == null)
                    continue;

                if (input.StartsWith(":"))
                {
                    switch (input)
                    {
                        case ":help":
                            Console.WriteLine("Dostupne komande:");
                            Console.WriteLine(":help - ispis komandi");
                            Console.WriteLine(":spremi i izlaz - spremanje i izlazak");
                            Console.WriteLine(":izlaz - izlaz bez spremanja");
                            break;

                        case ":spremi i izlaz":
                            file.Content = string.Join("\n", lines);
                            file.LastChangedAt = DateTimeOffset.UtcNow;
                            SaveChanges();
                            return ResponseResultType.Success;

                        case ":izlaz":
                            return ResponseResultType.Success;

                        default:
                            Console.WriteLine("Nepoznata komanda. Unesite ':help' za popis komandi.");
                            break;
                    }
                }
                else if (string.IsNullOrWhiteSpace(input))
                {
                    if (currentLine > 0)
                    {
                        currentLine--;
                        lines.RemoveAt(currentLine);
                    }
                }
                else
                {
                    if (currentLine >= lines.Count)
                    {
                        lines.Add(input);
                    }
                    else
                    {
                        lines[currentLine] = input;
                    }
                    currentLine++;
                }
            }
        }
    }
}