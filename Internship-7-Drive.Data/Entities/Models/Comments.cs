
namespace Internship_7_Drive.Data.Entities.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public int OwnerId { get; set; }
        public int FileId { get; set; }

        public User Owner { get; set; } = null!;
        public File File { get; set; } = null!;
    }
}
