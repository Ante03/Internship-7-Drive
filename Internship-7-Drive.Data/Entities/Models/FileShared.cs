using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_7_Drive.Data.Entities.Models
{
    public class FileShared
    {
        public int Id { get; set; }
        public int FileId { get; set; }
        public int OwnerId { get; set; }
        public int ShardWithUserId { get; set; }

        public User Owner { get; set; } = null!;
        public User ShardWithUser { get; set; } = null!;
        public File File { get; set; } = null!;
    }
}
