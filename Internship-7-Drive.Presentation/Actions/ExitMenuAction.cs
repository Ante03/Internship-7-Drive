using Internship_7_Drive.Presentation.Abstractions;

namespace Internship_7_Drive.Presentation.Actions
{
    public class ExitMenuAction : IAction
    {
        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Exit";

        public ExitMenuAction()
        {
        }

        public void Open()
        {
        }
    }
}
