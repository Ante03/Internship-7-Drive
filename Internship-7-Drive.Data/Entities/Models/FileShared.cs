
namespace Internship_7_Drive.Data.Entities.Models
{
    public class FileShared
    {
        public int Id { get; set; }
        public int FileId { get; set; }
        public int OwnerId { get; set; }
        public int SharedWithUserId { get; set; }

        public User Owner { get; set; } = null!;
        public User ShardWithUser { get; set; } = null!;
        public File File { get; set; } = null!;
    }
}
