using Internship_7_Drive.Data.Entities;
using Internship_7_Drive.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_7_Drive.Domain.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly DriveDbContext DbContext;

        protected BaseRepository(DriveDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected ResponseResultType SaveChanges()
        {
            var hasChanges = DbContext.SaveChanges() > 0;
            if (hasChanges)
                return ResponseResultType.Success;

            return ResponseResultType.NoChanges;
        }
    }
}

