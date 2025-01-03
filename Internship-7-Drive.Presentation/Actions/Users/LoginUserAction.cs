using Internship_7_Drive.Presentation.Helpers;
using Internship_7_Drive.Domain.Repositories;
using Internship_7_Drive.Presentation.Abstractions;
using Internship_7_Drive.Presentation.Extensions;
using Internship_7_Drive.Presentation.Factories;

namespace Internship_7_Drive.Presentation.Actions.Users
{
    public class LoginUserAction : IAction
    {
        private readonly UserRepository _userRepository;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Log In";

        public LoginUserAction(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Open()
        {
            Console.Clear();
            var newMail = Writer.EnterMail();
            var newPassword = Writer.EnterPassword();

            var responseResult = _userRepository.GetUserByMailAndPassword(newMail, newPassword);
            if (responseResult is not null)
            {
                ApplicationStateUser.CurrentUser = responseResult;
                var userActions = UserActionsFactory.Create();
                userActions.Open();
            }
            else
            {
                Console.WriteLine("Neuspjesna prijava!");
                Thread.Sleep(30000);

            }
        }
    }
}

