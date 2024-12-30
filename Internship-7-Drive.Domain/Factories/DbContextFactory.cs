using Microsoft.EntityFrameworkCore;
using Internship_7_Drive.Data.Entities;
using System.Configuration;

namespace Internship_7_Drive.Domain.Factories
{
    public static class DbContextFactory
    {
        public static DriveDbContext GetDriveDbContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseNpgsql(ConfigurationManager.ConnectionStrings["Intership-7-Drive"].ConnectionString)
                .Options;

            return new DriveDbContext(options);
        }
    }
}
