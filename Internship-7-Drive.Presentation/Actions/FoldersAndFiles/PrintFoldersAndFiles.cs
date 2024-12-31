using Internship_7_Drive.Domain.Repositories;
using Internship_7_Drive.Presentation.Abstractions;
using Internship_7_Drive.Presentation.Extensions;
using Internship_7_Drive.Presentation.Helpers;

namespace Internship_7_Drive.Presentation.Actions.FoldersAndFiles
{
    public class PrintFoldersAndFiles : IAction
    {
        private readonly UserRepository _userRepository;
        private readonly FolderRepository _folderRepository;
        private readonly FileRepository _fileRepository;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Moj disk";

        public PrintFoldersAndFiles(UserRepository userRepository, FolderRepository folderRepository, FileRepository fileRepository)
        {
            _userRepository = userRepository;
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
        }
        public void Open()
        {
            var currentUser = ApplicationStateUser.CurrentUser;
            
            if (currentUser == null)
            {
                Console.WriteLine("Nema prijavljenog korisnika.");
                return;
            }
            var inputCommand = " ";
            do
            {
                var folders = _folderRepository.GetAllFoldersByOwner(currentUser.Id);
                var files = _fileRepository.GetAllFilesByOwner(currentUser.Id);
                var currentFolder = ApplicationStateFolder.CurrentFolder;
                var parentFolderId = currentFolder?.Id;

                Console.WriteLine("Vaši folderi:");
                foreach (var folder in folders)
                {
                    Console.WriteLine($"- {folder.Name} (ID: {folder.Id})");
                }
                Console.WriteLine("Vaše datoteke:");
                foreach (var file in files)
                {
                    Console.WriteLine($"- {file.Name} (ID: {file.Id})");
                }

                Console.WriteLine("\nUnesite komandu('help' za ispis svih): ");
                inputCommand = Console.ReadLine();
                if (string.IsNullOrEmpty(inputCommand))
                {
                    continue;
                }
                if (inputCommand.StartsWith("help", StringComparison.OrdinalIgnoreCase))
                    Writer.WriteHelpCommands();
                else if (inputCommand.StartsWith("stvori mapu", StringComparison.OrdinalIgnoreCase) && Writer.CheckFolderName(inputCommand))
                    if(Reader.CheckYesOrNo())
                        _folderRepository.Add(Writer.ReturnFolderName(inputCommand), currentUser.Id, parentFolderId);
                    else
                        Console.WriteLine("Odustali od stvaranja nove datoteke");


            } while (inputCommand != "exit");
        }
    }
}
