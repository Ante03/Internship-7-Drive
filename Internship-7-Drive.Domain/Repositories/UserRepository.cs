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

        public ResponseResultType UpdateMail(string mail, int id)
        {
            var userWithSameMail = GetUserByMail(mail);
            if (userWithSameMail != null)
                return ResponseResultType.AlreadyExists;

            var userToUpdate = DbContext.Users.Find(id);
            if (userToUpdate is null)
            {
                return ResponseResultType.NotFound;
            }

            userToUpdate.Email = mail;

            SaveChanges();
            return ResponseResultType.Success;
        }

        public ResponseResultType UpdatePassword(string password, int id)
        {
            var userToUpdate = DbContext.Users.Find(id);
            if (userToUpdate is null)
            {
                return ResponseResultType.NotFound;
            }
            userToUpdate.Password = password;
            Console.WriteLine("AAAA");
            SaveChanges();
            return ResponseResultType.Success;
        }

        public User? GetUserByMailAndPassword(string email, string password)
        {
            return DbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
        public User? GetUserByMail(string email)
        {
            return DbContext.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}
