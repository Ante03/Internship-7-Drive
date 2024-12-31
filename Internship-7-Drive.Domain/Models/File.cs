using Internship_7_Drive.Data.Entities.Models;

namespace Models
{
    internal class File : Folder
    {
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public int? ParentFolderId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastChangedAt { get; set; }
    }
}