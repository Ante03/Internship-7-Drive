
using Internship_7_Drive.Domain.Enums;
using Internship_7_Drive.Domain.Repositories;
using Internship_7_Drive.Presentation.Abstractions;
using Internship_7_Drive.Presentation.Extensions;
using Internship_7_Drive.Presentation.Helpers;

namespace Internship_7_Drive.Presentation.Actions.Users
{
    public class ChangeProfilData : IAction
    {
        private readonly UserRepository _userRepository;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Change profil settings";

        public ChangeProfilData(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Open()
        {
            var currentUser = ApplicationState.CurrentUser;
            if (currentUser == null)
            {
                Console.WriteLine("Nema prijavljenog korisnika.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"Dobrodošli, {currentUser.FirstName} {currentUser.LastName}!");
            Console.WriteLine("Što želite promijeniti?");
            Console.WriteLine("1. Email");
            Console.WriteLine("2. Lozinka");
            Console.WriteLine("3. Povratak");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var newMail = Writer.ChangeEmail();
                    if (!Reader.ConfirmCaptcha())
                        break;
                    var responseMail = _userRepository.UpdateMail(newMail, currentUser.Id);

                    if (responseMail == ResponseResultType.Success)
                    {
                        currentUser.Email = newMail;
                        Console.WriteLine("Email uspješno ažuriran.");
                    }
                    else
                        Console.WriteLine("Ažuriranje nije uspjelo.");
                    break;
                case "2":
                    var newPassword = Writer.ChangePassword();
                    if (!Reader.ConfirmCaptcha())
                        break;
                    var responsePassword = _userRepository.UpdatePassword(newPassword, currentUser.Id);

                    if (responsePassword == ResponseResultType.Success)
                    {
                        currentUser.Email = newPassword;
                        Console.WriteLine("Lozinka uspješno ažurirana.");
                    }
                    else
                        Console.WriteLine("Ažuriranje nije uspjelo.");
                    break;
                case "3":
                    Console.WriteLine("Povratak na prethodni izbornik.");
                    break;
                default:
                    Console.WriteLine("Neispravan unos. Pokušajte ponovno.");
                    break;
            }
        }
    }
}


