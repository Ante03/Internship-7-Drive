using Internship_7_Drive.Data.Entities;
using Internship_7_Drive.Data.Entities.Models;
using Internship_7_Drive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_7_Drive.Domain.Repositories
{
    public class FolderRepository : BaseRepository
    {
        public FolderRepository(DriveDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType Add(string name, int ownerId, int? parentFolderId)
        {
            if (DbContext.Folders.FirstOrDefault(f => f.Name == name) != null)
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
            return DbContext.Folders.Where(f => f.OwnerId == ownerId).ToList();
        }
    }
}
