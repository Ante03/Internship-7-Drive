
using Internship_7_Drive.Presentation.Abstractions;


namespace Internship_7_Drive.Presentation.Actions.Users
{
    public class UserAction : BaseMenuAction
    {
        public UserAction(IList<IAction> actions) : base(actions)
        {
            Name = "User menu";
        }

        public override void Open()
        {
            Console.Clear();
            base.Open();
        }
    }
}
