using Internship_7_Drive.Data.Entities;
using Internship_7_Drive.Domain.Enums;
using Npgsql.Internal;

namespace Internship_7_Drive.Domain.Repositories
{
    public class FileRepository : BaseRepository
    {
        public FileRepository(DriveDbContext dbContext) : base(dbContext) { }

        public List<Data.Entities.Models.File> GetAllFilesByOwner(int ownerId)
        {
            return DbContext.Files
                .Where(f => f.OwnerId == ownerId)
                .OrderBy(f => f.LastChangedAt)
                .ToList();
        }
        public ResponseResultType Add(string name, string content, int ownerId, int parentFolderId)
        {
            if (DbContext.Files.FirstOrDefault(f => f.Name == name) != null)
                return ResponseResultType.AlreadyExists;

            var newFile = new Data.Entities.Models.File()
            {
                Name = name,
                OwnerId = ownerId,
                Content = content,
                FolderId = parentFolderId,
                CreatedAt = DateTimeOffset.UtcNow,
                LastChangedAt = DateTimeOffset.UtcNow
            };

            DbContext.Files.Add(newFile);
            SaveChanges();
            return ResponseResultType.Success;
        }
        public Data.Entities.Models.File? GetByName(string name)
        {
            return DbContext.Files.FirstOrDefault(f => f.Name == name);
        }
        public ResponseResultType Delete(string name, int ownerId)
        {
            var fileToDelete = GetByName(name);
            if (fileToDelete is null)
                return ResponseResultType.NotFound;
            if(fileToDelete.OwnerId != ownerId)
                return ResponseResultType.ValidationError;

            DbContext.Files.Remove(fileToDelete);
            SaveChanges();
            return ResponseResultType.Success;
        }

        public ResponseResultType ChangeName(string oldName, string newName, int ownerId)
        {
            var currentFile = GetByName(oldName);
            if (currentFile == null)
                return ResponseResultType.NotFound;

            if(currentFile.Id != ownerId)
                return ResponseResultType.ValidationError;

            currentFile.Name = newName;
            SaveChanges();
            return ResponseResultType.Success;
        }

        public ResponseResultType EditFile(string fileName, int ownerId)
        {
            var file = GetByName(fileName);
            if (file == null)
                return ResponseResultType.NotFound;
            if(file.OwnerId != ownerId)
                return ResponseResultType.ValidationError;

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
