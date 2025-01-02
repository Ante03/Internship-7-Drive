using Internship_7_Drive.Data.Entities;
using Internship_7_Drive.Data.Entities.Models;
using Internship_7_Drive.Domain.Enums;

namespace Internship_7_Drive.Domain.Repositories
{
    public class FolderSharedRepository : BaseRepository
    {
        public FolderSharedRepository(DriveDbContext dbContext) : base(dbContext)
        {
        }
        public Folder? GetByNameFolder(string name, int ownerId)
        {
            return DbContext.Folders.FirstOrDefault(f => f.Name == name && f.OwnerId == ownerId);
        }

        public User? GetByMailUser(string mail)
        {
            return DbContext.Users.FirstOrDefault(u => u.Email == mail);
        }

        public FolderShared? CheckNewFolder(int folderId, int ownerId, int sharedWithId)
        {
            return DbContext.FolderShareds.FirstOrDefault(fs => fs.FolderId == folderId && fs.OwnerId == ownerId && fs.SharedWithUserId == sharedWithId);
        }

        public ResponseResultType Share(string nameOfFolder, int ownerId, string newUserMail)
        {
            var folder = GetByNameFolder(nameOfFolder, ownerId);
            if (folder == null)
                return ResponseResultType.NotFound;

            if(ownerId != folder.OwnerId)
                return ResponseResultType.ValidationError;
            
            var newUser = GetByMailUser(newUserMail);
            if (newUser == null)
                return ResponseResultType.NotFound;

            var parentFolderId = folder?.ParentFolderId;
            var newSharedFolder = new FolderShared { FolderId = folder.Id, OwnerId = ownerId, SharedWithUserId = newUser.Id, ParentFolderId = parentFolderId };
            if (CheckNewFolder(folder.Id, ownerId, newUser.Id) == null)
                DbContext.FolderShareds.Add(newSharedFolder);
            else
                return ResponseResultType.AlreadyExists;

            SaveChanges();
            return ResponseResultType.Success;
        }

        public ResponseResultType Delete(string folderName, int ownerId, string userMail)
        {
            var sharedWithUser = GetByMailUser(userMail);
            if (sharedWithUser == null)
                return ResponseResultType.NotFound;

            var folder = GetByNameFolder(folderName, ownerId);
            if (folder == null)
                return ResponseResultType.NotFound;

            var folderSharedToDelete = CheckNewFolder(folder.Id, ownerId, sharedWithUser.Id);
            if (folderSharedToDelete == null)
                return ResponseResultType.NotFound;

            DbContext.FolderShareds.Remove(folderSharedToDelete);
            SaveChanges();
            return ResponseResultType.Success;
        }

        public List<FolderShared> GetAllFoldersSharedWithUser(int ownerId)
        {
            return DbContext.FolderShareds
                .Where(fs => fs.SharedWithUserId == ownerId)
                .ToList();
        }
    }
}