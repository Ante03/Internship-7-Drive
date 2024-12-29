using Internship_7_Drive.Domain.Repositories;
using Internship_7_Drive.Presentation.Helpers;
using Internship_7_Drive.Data.Entities;
using Internship_7_Drive.Presentation.Actions.Users;


namespace Internship_7_Drive.Presentation.Factories
{
    public class MainMenuFactory
    {
        public static async Task ShowMenu(DriveDbContext dbContext)
        {
            int choiceLoginOrRegistar = 0;
            var userRepository = new UserRepository(dbContext);
            while (choiceLoginOrRegistar != 3)
            {
                var message = "Odaberite: \n1 - Registarcija \n2 - Prijava \n3 - izlaz";
                int smallestChoice = 1;
                int biggestChoice = 3;
                choiceLoginOrRegistar = Reader.CheckNumberBetweenRange(message, smallestChoice, biggestChoice);

                if (choiceLoginOrRegistar == 2)
                {
                    var mail = Writer.EnterMail();
                    var password = Writer.EnterPassword();
                    var user = userRepository.GetUserByMailAndPassword(mail, password);

                    if (user != null)
                    {
                        Console.WriteLine($"Dobrodošao, {user.FirstName} {user.LastName}!");
                        UserActions.ShowUserActions(dbContext);
                    }
                    else
                    {
                        Console.WriteLine("Neispravan korisnik. Pokušajte ponovo za 30 sekundi.");
                        await Task.Delay(30000);
                    }
                }
            }
        }
    }
}

