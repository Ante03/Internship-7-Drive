
using Internship_7_Drive.Data.Entities;
using Internship_7_Drive.Domain.Repositories;

namespace Internship_7_Drive.Presentation.Actions.Users
{
    public class UserActions
    {
        public static void ShowUserActions(DriveDbContext dbContext)
        {
            int choiceLoginOrRegistar = 0;
            while (choiceLoginOrRegistar != 5)
            {
                var message = "Odaberite: \n1 - Moj disk \n2 - Dijeljeno sa mnom \n3 - Postavke profila \n4 - Odjava iz profila";
                int smallestChoice = 1;
                int biggestChoice = 4;
                choiceLoginOrRegistar = Helpers.Reader.CheckNumberBetweenRange(message, smallestChoice, biggestChoice);
            }
        }
    }
}
