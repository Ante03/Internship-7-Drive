using Internship_7_Drive.Presentation.Helpers;
using Internship_7_Drive.Domain.Repositories;

namespace Internship_7_Drive.Presentation.Actions.Users
{
    public class LoginUserAction
    {
        private readonly UserRepository _userRepository;

        public LoginUserAction(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Login()
        {
            var email = Writer.EnterMail();
            var password = Writer.EnterPassword();

            var user = _userRepository.GetUserByMailAndPassword(email, password);

            if (user != null)
            {
                Console.WriteLine($"Dobrodošao, {user.FirstName} {user.LastName}!");
            }
            else
            {
                Console.WriteLine("Neispravna email adresa ili lozinka.");
            }
        }
    }
}
