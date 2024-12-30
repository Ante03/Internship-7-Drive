
using Internship_7_Drive.Presentation.Abstractions;
using Internship_7_Drive.Presentation.Actions;
using Internship_7_Drive.Presentation.Extensions;
using Internship_7_Drive.Domain.Factories;
using Internship_7_Drive.Domain.Repositories;
using Internship_7_Drive.Presentation.Actions.Users;

namespace Internship_7_Drive.Presentation.Factories;
public class MainMenuFactory
{
    public static IList<IAction> CreateActions()
    {
        var actions = new List<IAction>
        {
            new UserAddAction(RepositoryFactory.Create<UserRepository>()),
            new LoginUserAction(RepositoryFactory.Create<UserRepository>()),
            new ExitMenuAction(),
        };

        actions.SetActionIndexes();

        return actions;
    }
}

