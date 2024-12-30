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

        public ResponseResultType Add(string name, string surname, string mail, string password)
        {
            if (DbContext.Users.FirstOrDefault(u => u.Email == mail) != null)
                return ResponseResultType.AlreadyExists;

            var newUser = new User() { Email = mail, FirstName = name, LastName = surname, Password = password };
            DbContext.Users.Add(newUser);

            SaveChanges();
            return ResponseResultType.Success;
        }

        public ResponseResultType Update(string mail, string password, string oldMail)
        {
            var userToUpdate = DbContext.Users.Find(oldMail);
            if (userToUpdate is null)
            {
                return ResponseResultType.NotFound;
            }

            userToUpdate.Email = mail;
            userToUpdate.Password = password;

            return SaveChanges();
        }

        public User? GetUserByMailAndPassword(string email, string password)
        {
            return DbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
