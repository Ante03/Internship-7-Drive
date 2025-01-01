
using Internship_7_Drive.Domain.Repositories;
using Internship_7_Drive.Presentation.Actions.Users;
using Internship_7_Drive.Domain.Factories;
using Internship_7_Drive.Presentation.Abstractions;
using Internship_7_Drive.Presentation.Actions;





namespace Internship_7_Drive.Presentation.Factories;
public class UserActionsFactory
{
    public static UserAction Create()
    {
        var actions = new List<IAction>
        {
            new ChangeProfilData(RepositoryFactory.Create<UserRepository>()),
            new Actions.FoldersAndFiles.PrintFoldersAndFiles( 
                RepositoryFactory.Create<FolderRepository>(),
                RepositoryFactory.Create<FileRepository>(),
                RepositoryFactory.Create<CommentRepository>()
                ),
            new ExitMenuAction()
        };

        var menuAction = new UserAction(actions);
        return menuAction;
    }
}

