using Internship_7_Drive.Data.Entities;
using Internship_7_Drive.Presentation.Factories;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Drive.Presentation.Helpers
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<DriveDbContext>()
                .UseNpgsql("Host=127.0.0.1;Port=5433;Database=DumpProject;User Id=postgres;Password=novcanik")
                .EnableSensitiveDataLogging()
                .Options;
            var dbContext = new DriveDbContext(options);

            await MainMenuFactory.ShowMenu(dbContext);
        }
    }
}

