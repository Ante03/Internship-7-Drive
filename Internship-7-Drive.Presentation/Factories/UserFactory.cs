using Internship_7_Drive.Data.Entities.Models;
using Internship_7_Drive.Data.Entities;
using Internship_7_Drive.Domain.Repositories;
using Internship_7_Drive.Presentation.Helpers;
using Internship_7_Drive.Presentation.Actions.Users;

namespace Internship_7_Drive.Presentation.Factories
{
    public class UserFactory
    {

        public static void ShowUserActions(DriveDbContext dbContext, User user)
        {
            int choiceLoginOrRegistar = 0;
            while (choiceLoginOrRegistar != 4)
            {
                var message = "Odaberite: \n1 - Moj disk \n2 - Dijeljeno sa mnom \n3 - Postavke profila \n4 - Odjava iz profila";
                int smallestChoice = 1;
                int biggestChoice = 4;
                choiceLoginOrRegistar = Reader.CheckNumberBetweenRange(message, smallestChoice, biggestChoice);
                if (choiceLoginOrRegistar == 3)
                    ChangeProfilData.ChangeMailAndPassword(dbContext, user);
            }
        }

        internal static void ShowUserActions(object dbContext, User user)
        {
            throw new NotImplementedException();
        }
    }
}