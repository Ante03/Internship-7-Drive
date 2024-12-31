using Internship_7_Drive.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_7_Drive.Domain.Repositories
{
    public class FileRepository : BaseRepository
    {
        public FileRepository(DriveDbContext dbContext) : base(dbContext) { }

        public List<Data.Entities.Models.File> GetAllFilesByOwner(int ownerId)
        {
            return DbContext.Files.Where(f => f.OwnerId == ownerId).ToList();
        }
    }
}
