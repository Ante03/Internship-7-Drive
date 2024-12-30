using Internship_7_Drive.Data.Entities;
using Internship_7_Drive.Data.Entities.Models;
using Internship_7_Drive.Domain.Repositories;
using Internship_7_Drive.Presentation.Factories;
using Internship_7_Drive.Presentation.Helpers;


namespace Internship_7_Drive.Presentation.Actions.Users
{
    public class RegisterUserAction
    {
        public static void Register(DriveDbContext dbContext)
        {
            var newName = Reader.EnterName();
            var newSurname = Reader.EnterSurname();
            var newMail = Writer.ChangeEmail();
            var newPassword = Writer.ChangePassword();
            if (Reader.ConfirmCaptcha())
            {
                var userRepository = new UserRepository(dbContext);
                if (userRepository.Add(newName, newSurname, newMail, newPassword) == Domain.Enums.ResponseResultType.Success)
                {
                    var newUser = new User() { Email = newMail, FirstName = newName, LastName = newSurname, Password = newPassword };
                    Console.WriteLine("Uspjesna registracija");
                    UserFactory.ShowUserActions(dbContext, newUser);
                }
                else
                    Console.WriteLine($"Korisnik sa mailom {newMail} vec postoji!");
            }
            else
            {
                Console.WriteLine("Neuspjesna registracija!");
            }
            
        }
    }
}
