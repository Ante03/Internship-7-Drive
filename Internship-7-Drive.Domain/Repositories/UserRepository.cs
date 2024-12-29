using Internship_7_Drive.Data.Entities;
using Internship_7_Drive.Data.Entities.Models;
using Internship_7_Drive.Domain.Enums;

namespace Internship_7_Drive.Domain.Repositories
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(DriveDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType Add(User user)
        {
            DbContext.Users.Add(user);
            return SaveChanges();
        }

        public User? GetUserByMailAndPassword(string email, string password)
        {
            return DbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public User? GetById(int id) => DbContext.Users.FirstOrDefault(u => u.Id == id);
    }
}
