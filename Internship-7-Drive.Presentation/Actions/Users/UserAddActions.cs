using Internship_7_Drive.Data.Entities.Models;
using Internship_7_Drive.Domain.Enums;
using Internship_7_Drive.Domain.Repositories;
using Internship_7_Drive.Presentation.Abstractions;
using Internship_7_Drive.Presentation.Factories;
using Internship_7_Drive.Presentation.Helpers;

namespace Internship_7_Drive.Presentation.Actions.Users
{
    public class UserAddAction : IAction
    {
        private readonly UserRepository _userRepository;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Sign In";

        public UserAddAction(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Open()
        {
            var firstName = Reader.EnterName();
            var lastName = Reader.EnterSurname();
            var newMail = Writer.ChangeEmail();
            var newPassword = Writer.ChangePassword();

            var user = new User();
            if (Reader.ConfirmCaptcha())
            {
                var responseResult = _userRepository.Add(firstName, lastName, newMail, newPassword);
                if (responseResult is ResponseResultType.Success)
                {
                    var userActions = UserActionsFactory.Create();
                    userActions.Open();
                }
                Console.WriteLine("Neuspjesna registracija!");
            }
        }
    }
}
