using Internship_7_Drive.Data.Entities;
using Internship_7_Drive.Data.Entities.Models;
using Internship_7_Drive.Domain.Enums;

namespace Internship_7_Drive.Domain.Repositories
{
    public class FolderRepository : BaseRepository
    {
        public FolderRepository(DriveDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType Add(string name, int ownerId, int? parentFolderId)
        {
            if (DbContext.Folders.FirstOrDefault(f => f.Name == name && f.OwnerId == ownerId) != null)
                return ResponseResultType.AlreadyExists;

            var newFolder = new Folder() { Name = name, OwnerId = ownerId, ParentFolderId = parentFolderId, CreatedAt = DateTimeOffset.UtcNow, LastChangedAt = DateTimeOffset.UtcNow };
            DbContext.Folders.Add(newFolder);

            SaveChanges();
            return ResponseResultType.Success;
        }

        public Folder? GetByName(string name)
        {
            return DbContext.Folders.FirstOrDefault(f => f.Name == name);
        }

        public List<Folder> GetAllFoldersByOwner(int ownerId)
        {
            return DbContext.Folders
                .Where(f => f.OwnerId == ownerId)
                .OrderBy(f => f.Name)
                .ToList();
        }

        public ResponseResultType Delete(string name, int ownerId)
        {
            var folderToDelete = GetByName(name);
            if (folderToDelete is null)
                return ResponseResultType.NotFound;
            if (folderToDelete.OwnerId != ownerId)
                return ResponseResultType.ValidationError;

            DbContext.Folders.Remove(folderToDelete);
            SaveChanges();
            return ResponseResultType.Success;
        }

        public ResponseResultType ChangeName(string oldName, string newName, int userId)
        {
            var currentFolder = GetByName(oldName);
            if (currentFolder == null)
                return ResponseResultType.NotFound;
            if (currentFolder.OwnerId != userId)
                return ResponseResultType.ValidationError;
            currentFolder.Name = newName;
            SaveChanges();
            return ResponseResultType.Success;
        }

    }
}