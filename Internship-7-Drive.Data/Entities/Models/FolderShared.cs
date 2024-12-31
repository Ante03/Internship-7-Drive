
namespace Internship_7_Drive.Data.Entities.Models
{
    public class FolderShared
    {
        public int Id { get; set; }
        public int ParentFolderId { get; set; }
        public int OwnerId { get; set; }
        public int SharedWithUserId { get; set; }

        public User Owner { get; set; } = null!;
        public User ShardWithUser { get; set; } = null!;
        public Folder ParentFolder { get; set; } = null!;
    }
}

