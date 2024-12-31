using Internship_7_Drive.Data.Entities;
using Internship_7_Drive.Domain.Enums;

namespace Internship_7_Drive.Domain.Repositories
{
    public class FileRepository : BaseRepository
    {
        public FileRepository(DriveDbContext dbContext) : base(dbContext) { }

        public List<Data.Entities.Models.File> GetAllFilesByOwner(int ownerId)
        {
            return DbContext.Files.Where(f => f.OwnerId == ownerId).ToList();
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
        public ResponseResultType Delete(string name)
        {
            var fileToDelete = GetByName(name);
            if (fileToDelete is null)
            {
                return ResponseResultType.NotFound;
            }

            DbContext.Files.Remove(fileToDelete);
            SaveChanges();
            return ResponseResultType.Success;
        }

        public ResponseResultType ChangeName(string oldName, string newName, int userId)
        {
            var currentFile = GetByName(oldName);
            if (currentFile == null)
            {
                return ResponseResultType.NotFound;
            }
            currentFile.Name = newName;
            SaveChanges();
            return ResponseResultType.Success;
        }
    }
}
