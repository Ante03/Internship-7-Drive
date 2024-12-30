using Internship_7_Drive.Presentation.Helpers;
using Internship_7_Drive.Domain.Repositories;
using Internship_7_Drive.Presentation.Factories;
using Microsoft.EntityFrameworkCore;
using Internship_7_Drive.Data.Entities;

namespace Internship_7_Drive.Presentation.Actions.Users
{
    public class LoginUserAction
    {
        public static async Task Login(DriveDbContext dbContext)
        {
            var mail = Writer.EnterMail();
            var password = Writer.EnterPassword();
            var userRepository = new UserRepository(dbContext);
            var user = userRepository.GetUserByMailAndPassword(mail, password);

            if (user != null)
            {
                Console.WriteLine($"Dobrodošao, {user.FirstName} {user.LastName}!");
                UserFactory.ShowUserActions(dbContext, user);
            }
            else
            {
                Console.WriteLine("Neispravan korisnik. Pokušajte ponovo za 30 sekundi.");
                await Task.Delay(30000);
            }
        }
    }
}
