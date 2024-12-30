using Internship_7_Drive.Data.Entities;
using Internship_7_Drive.Data.Entities.Models;
using Internship_7_Drive.Domain.Repositories;
using Internship_7_Drive.Presentation.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_7_Drive.Presentation.Actions.Users
{
    public class ChangeProfilData
    {
        public static void ChangeMailAndPassword(DriveDbContext dbContext, User user)
        {
            var userRepository = new UserRepository(dbContext);
            var messageToConfirmChangingMail = "Sto zelite promijeniti: \n1 - Mail \n2 - Lozinku \n3 - izlaz";
            var choiceMailOrPassword = Reader.CheckNumberBetweenRange(messageToConfirmChangingMail, 1, 3);
            if (choiceMailOrPassword == 1)
            {
                var newMail = Writer.ChangeEmail();
                var newPassword = Writer.ChangePassword();
                if (Reader.ConfirmCaptcha())
                {
                    Console.WriteLine("Uspjesno promijenuta lozinka!");
                    userRepository.Update(newMail, newPassword, user.Email);
                }
                else
                    Console.WriteLine("Promjena maila ponistena!");
            }
            else if (choiceMailOrPassword == 2)
            {
                var newPassword = Writer.ChangePassword();
                var newMail = user.Email;
                if (Reader.ConfirmCaptcha())
                {
                    Console.WriteLine("Uspjesno promijenuta lozinka!");
                    userRepository.Update(newMail, newPassword, user.Email);
                }
                else
                    Console.WriteLine("Promjena lozinke ponistena!");
            }
        }
    }
}
