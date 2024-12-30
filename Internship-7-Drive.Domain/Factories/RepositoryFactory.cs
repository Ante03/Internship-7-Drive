using Internship_7_Drive.Domain.Repositories;

namespace Internship_7_Drive.Domain.Factories
{
    public class RepositoryFactory
    {
        public static TRepository Create<TRepository>()
            where TRepository : BaseRepository
        {
            var dbContext = DbContextFactory.GetDriveDbContext();
            var repositoryInstance = Activator.CreateInstance(typeof(TRepository), dbContext) as TRepository;

            return repositoryInstance!;
        }
    }
}
