
namespace Internship_7_Drive.Data.Entities.Models
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int OwnerId { get; set; }
        public int FolderId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastChangedAt { get; set; }

        public User Owner { get; set; } = null!;
        public Folder Folder { get; set; } = null!;
    }
}
