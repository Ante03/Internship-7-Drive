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
                if (choiceLoginOrRegistar == 1)
                    RegisterUserAction.Register(dbContext);
                else if (choiceLoginOrRegistar == 2)
                    await LoginUserAction.Login(dbContext);
            }
        }
    }
}

