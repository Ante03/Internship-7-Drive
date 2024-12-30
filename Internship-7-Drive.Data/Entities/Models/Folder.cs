
namespace Internship_7_Drive.Data.Entities.Models
{
    public class Folder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public int? ParentFolderId {  get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastChangedAt { get; set; }

        public User Owner { get; set; } = null!;
        public Folder ParentFolder { get; set; } = null!;
        public ICollection<Folder> Subfolders { get; set; } = null!;
        public ICollection<File> Files { get; set; } = null!;
    }
}
