using Internship_7_Drive.Domain.Enums;
using Internship_7_Drive.Domain.Repositories;
using Internship_7_Drive.Presentation.Abstractions;
using Internship_7_Drive.Presentation.Extensions;
using Internship_7_Drive.Presentation.Helpers;

namespace Internship_7_Drive.Presentation.Actions.SharedFoldersAndFiles
{
    public class SharedFoldersAndFiles : IAction
    {
        private readonly UserRepository _userRepository;
        private readonly FolderRepository _folderRepository;
        private readonly FolderSharedRepository _folderSharedRepository;
        private readonly FileRepository _fileRepository;
        private readonly FileSharedRepository _fileSharedRepository;
        private readonly CommentRepository _commentRepository;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Dijeljeno sa mnom";

        public SharedFoldersAndFiles(UserRepository userRepository, FolderRepository folderRepository, FileRepository fileRepository, FolderSharedRepository folderSharedRepository, FileSharedRepository fileSharedRepository, CommentRepository commentRepository)
        {
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
            _userRepository = userRepository;
            _folderSharedRepository = folderSharedRepository;
            _fileSharedRepository = fileSharedRepository;
            _commentRepository = commentRepository;
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
                var sharedFolders = _folderSharedRepository.GetAllFoldersSharedWithUser(currentUser.Id);
                var sharedFiles = _fileSharedRepository.GetAllFilesSharedWithUser(currentUser.Id);
                var currentFolder = ApplicationStateFolder.CurrentFolder;

                Console.WriteLine("Mape podijeljene s vama:");
                foreach (var folder in sharedFolders)
                {
                    Console.WriteLine($"ParentFodlerID: {folder.ParentFolderId}");
                }

                Console.WriteLine("Datoteke podijeljene s vama:");
                foreach (var file in sharedFiles)
                {
                    Console.WriteLine($"ID: {file.Id}");
                }

                Console.WriteLine("\nUnesite komandu: ");
                inputCommand = Console.ReadLine();
                Console.Clear();

                if (string.IsNullOrEmpty(inputCommand))
                    continue;

                if (inputCommand.StartsWith("help", StringComparison.OrdinalIgnoreCase))
                    Writer.WriteHelpCommandsForShare();

                else if (inputCommand.StartsWith("podijeli mapu", StringComparison.OrdinalIgnoreCase))
                {
                    var parts = inputCommand.Split("'");
                    if (parts.Length < 4)
                    {
                        Console.WriteLine("Niste ispravno unijeli naredbu. Pokušajte: podijeli mapu 'ime mape' s 'email korisnika'");
                        continue;
                    }

                    var folderName = parts[1].Trim();
                    var newUserMail = parts[3].Trim();
                    var response = _folderSharedRepository.Share(folderName, currentUser.Id, newUserMail);
                    if(response == ResponseResultType.Success)
                        Console.WriteLine($"Uspjesno podijeljena mapa {folderName}.");
                    else if(response == ResponseResultType.AlreadyExists)
                        Console.WriteLine($"Vec dijelite {folderName} sa {newUserMail}.");
                    else if(response == ResponseResultType.NotFound)
                        Console.WriteLine($"Nismo uspjeli pronaci mapu s imenom {folderName} ili korisnika s mailom {newUserMail}");
                    else if(response == ResponseResultType.ValidationError)
                        Console.WriteLine($"Nemate mapu s imenom {folderName}.");
                }

                else if(inputCommand.StartsWith("podijeli datoteku", StringComparison.OrdinalIgnoreCase))
                {
                    var parts = inputCommand.Split("'");
                    if (parts.Length < 4)
                    {
                        Console.WriteLine("Niste ispravno unijeli naredbu. Pokušajte: podijeli datoteku 'ime datoteke' s ' mail korisnika'");
                        continue;
                    }

                    var fileName = parts[1].Trim();
                    var newUserMail = parts[3].Trim();
                    
                    var response = _fileSharedRepository.Share(fileName, currentUser.Id, newUserMail);
                    if (response == ResponseResultType.Success)
                        Console.WriteLine($"Uspjesno podijeljena datoteka {fileName}.");
                    else if (response == ResponseResultType.AlreadyExists)
                        Console.WriteLine($"Vec dijelite {fileName} sa {newUserMail}.");
                    else if (response == ResponseResultType.NotFound)
                        Console.WriteLine($"Nismo uspjeli pronaci datoteku s imenom {fileName} ili korisnika s mailom {newUserMail}");
                    else if (response == ResponseResultType.ValidationError)
                        Console.WriteLine($"Nemate datoteku s imenom {fileName}.");
                }

                else if(inputCommand.StartsWith("prestani dijeliti datoteku", StringComparison.OrdinalIgnoreCase))
                {
                    var parts = inputCommand.Split("'");
                    if (parts.Length < 4)
                    {
                        Console.WriteLine("Niste ispravno unijeli naredbu. Pokušajte: prestani dijeliti datoteku 'ime datoteke' s ' mail korisnika'");
                        continue;
                    }

                    var fileName = parts[1].Trim();
                    var UserMail = parts[3].Trim();

                    var response = _fileSharedRepository.Delete(fileName, currentUser.Id, UserMail);
                    if (response == ResponseResultType.Success)
                        Console.WriteLine($"Prestali dijeliti {fileName} sa {UserMail}.");
                    else if(response == ResponseResultType.NotFound)
                        Console.WriteLine("Dogodila se greska!");
                }

                else if (inputCommand.StartsWith("prestani dijeliti mapu", StringComparison.OrdinalIgnoreCase))
                {
                    var parts = inputCommand.Split("'");
                    if (parts.Length < 4)
                    {
                        Console.WriteLine("Niste ispravno unijeli naredbu. Pokušajte: prestani dijeliti mapu 'ime mape' s ' mail korisnika'");
                        continue;
                    }

                    var folderName = parts[1].Trim();
                    var UserMail = parts[3].Trim();

                    var response = _folderSharedRepository.Delete(folderName, currentUser.Id, UserMail);
                    if (response == ResponseResultType.Success)
                        Console.WriteLine($"Prestali dijeliti {folderName} sa {UserMail}.");
                    else if (response == ResponseResultType.NotFound)
                        Console.WriteLine("Dogodila se greska!");
                }

                else if(inputCommand.StartsWith("uredi datoteku", StringComparison.OrdinalIgnoreCase))
                {
                    var fileName = Writer.ReturnNewName("uredi datoteku", inputCommand);
                    _fileSharedRepository.EditFile(fileName, currentUser.Id);
                }

                else if (inputCommand.StartsWith("dodaj komentar datoteci", StringComparison.OrdinalIgnoreCase))
                {
                    var fileName = Writer.ReturnNewName("dodaj komentar datoteci", inputCommand);
                    var fileShared = _fileSharedRepository.GetByNameFileShared(fileName, currentUser.Id);

                    if (fileShared == null)
                    {
                        Console.WriteLine("Datoteka nije pronađena.");
                        continue;
                    }
                    var content = Reader.ReturnContent();
                    _commentRepository.AddComment(fileShared.FileId, currentUser.Id, content);
                }
            
            } while (inputCommand != "exit");
        }
    }
}

