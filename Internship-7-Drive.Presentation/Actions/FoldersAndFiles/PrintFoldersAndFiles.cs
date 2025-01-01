using Internship_7_Drive.Domain.Enums;
using Internship_7_Drive.Domain.Repositories;
using Internship_7_Drive.Presentation.Abstractions;
using Internship_7_Drive.Presentation.Extensions;
using Internship_7_Drive.Presentation.Helpers;

namespace Internship_7_Drive.Presentation.Actions.FoldersAndFiles
{
    public class PrintFoldersAndFiles : IAction
    {
        private readonly FolderRepository _folderRepository;
        private readonly FileRepository _fileRepository;
        private readonly CommentRepository _commentRepository;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Moj disk";

        public PrintFoldersAndFiles(FolderRepository folderRepository, FileRepository fileRepository, CommentRepository commentRepository)
        {
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
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
                var currentFolder = ApplicationStateFolder.CurrentFolder;
                var parentFolderId = currentFolder?.Id;

                Console.WriteLine("Vaše mape:");
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

                else if (inputCommand.StartsWith("stvori mapu", StringComparison.OrdinalIgnoreCase) && Writer.CheckNewName(inputCommand, "stvori mapu"))
                {
                    if (Reader.CheckYesOrNo())
                        _folderRepository.Add(Writer.ReturnNewName("stvori mapu", inputCommand), currentUser.Id, parentFolderId);
                    else
                        Console.WriteLine("Odustali od stvaranja nove mape");
                }

                else if (inputCommand.StartsWith("stvori datoteku", StringComparison.OrdinalIgnoreCase) && Writer.CheckNewName(inputCommand, "stvori datoteku"))
                {
                    if (currentFolder == null)
                    {
                        Console.WriteLine("Ne mozete napravit datoteku bez da udete u folder!");
                        continue;
                    }
                    var content = Reader.ReturnContent();
                    if(Reader.CheckYesOrNo())
                        _fileRepository.Add(Writer.ReturnNewName("stvori datoteku", inputCommand), content, currentUser.Id, currentFolder.Id);
                    else
                        Console.WriteLine("Odustali od stvaranja datoteke");
                }
                
                else if (inputCommand.StartsWith("udi u mapu", StringComparison.OrdinalIgnoreCase) && Writer.CheckNewName(inputCommand, "udi u mapu"))
                { 
                    var newCurrentFolder = _folderRepository.GetByName(Writer.ReturnNewName("udi u mapu", inputCommand));
                    if(newCurrentFolder == null)
                    {
                        Console.WriteLine("Ne postoji mapa s tim imenom!");
                        continue;
                    }
                    if(newCurrentFolder.OwnerId == currentUser.Id)
                    {
                        ApplicationStateFolder.CurrentFolder = newCurrentFolder;
                        currentFolder = newCurrentFolder;
                        Console.WriteLine($"Uspjesno usli u {currentFolder.Name} mapu!");
                    }
                    else
                        Console.WriteLine("Nemate mapu s tim imenom");
                }

                else if (inputCommand.StartsWith("izbrisi mapu", StringComparison.OrdinalIgnoreCase) && Writer.CheckNewName(inputCommand, "izbrisi mapu"))
                {
                    if (_folderRepository.Delete(Writer.ReturnNewName("izbrisi mapu", inputCommand), currentUser.Id) == ResponseResultType.Success)
                        if (Reader.CheckYesOrNo())
                            Console.WriteLine("Uspjesno obrisana mapa!");
                        else 
                            Console.WriteLine("Odustali od brisanja mape");
                    else
                        Console.WriteLine("Doslo do greske pri brisanju!");
                    
                }
                
                else if (inputCommand.StartsWith("izbrisi datoteku", StringComparison.OrdinalIgnoreCase) && Writer.CheckNewName(inputCommand, "izbrisi datoteku"))
                {
                    if (_fileRepository.Delete(Writer.ReturnNewName("izbrisi datoteku", inputCommand), currentUser.Id) == ResponseResultType.Success)
                        if (Reader.CheckYesOrNo())
                            Console.WriteLine("Uspjesno obrisana datoteka!");
                        else 
                            Console.WriteLine("Odustali od brisanja datoteke");
                    else
                        Console.WriteLine("Doslo do greske pri brisanju!");
                }
                
                else if (inputCommand.StartsWith("promjeni naziv mape", StringComparison.OrdinalIgnoreCase))
                {
                    var parts = inputCommand.Split("'");
                    if (parts.Length < 4)
                    {
                        Console.WriteLine("Niste ispravno unijeli naredbu. Pokušajte: promjeni naziv mape 'ime mape' u 'novo ime mape'");
                        continue;
                    }

                    var currentName = parts[1].Trim();
                    var newName = parts[3].Trim();

                    var result = _folderRepository.ChangeName(currentName, newName, currentUser.Id);

                    if (result == ResponseResultType.Success)
                        if (Reader.CheckYesOrNo())
                            Console.WriteLine($"Mapa '{currentName}' uspješno preimenovana u '{newName}'.");
                        else 
                            Console.WriteLine("Odustali od preimenovanja mape");
                    else if (result == ResponseResultType.NotFound)
                        Console.WriteLine($"Mapa '{currentName}' nije pronađena.");
                    else if (result == ResponseResultType.AlreadyExists)
                        Console.WriteLine($"Mapa s imenom '{newName}' već postoji.");
                    else if (result == ResponseResultType.ValidationError)
                        Console.WriteLine($"Nemate mapu s imenom '{newName}'.");

                }
                
                else if (inputCommand.StartsWith("promjeni naziv datoteke", StringComparison.OrdinalIgnoreCase))
                {
                    var parts = inputCommand.Split("'");
                    if (parts.Length < 4)
                    {
                        Console.WriteLine("Niste ispravno unijeli naredbu. Pokušajte: promjeni naziv datoteke 'ime datoteke' u 'novo ime datoteke'");
                        continue;
                    }

                    var currentName = parts[1].Trim();
                    var newName = parts[3].Trim();

                    var result = _fileRepository.ChangeName(currentName, newName, currentUser.Id);

                    if (result == ResponseResultType.Success)
                        if (Reader.CheckYesOrNo())
                            Console.WriteLine($"Datoteka '{currentName}' uspješno preimenovana u '{newName}'.");
                        else
                            Console.WriteLine("Odustali od preimenovanja datoteke");
                    else if (result == ResponseResultType.NotFound)
                        Console.WriteLine($"Datoteka '{currentName}' nije pronađena.");
                    else if (result == ResponseResultType.AlreadyExists)
                        Console.WriteLine($"Datoteka s imenom '{newName}' već postoji.");
                    else if (result == ResponseResultType.ValidationError)
                        Console.WriteLine($"Nemate datoteku s imenom '{newName}'.");
                }
                
                else if (inputCommand.StartsWith("uredi datoteku", StringComparison.OrdinalIgnoreCase))
                {
                    var fileName = Writer.ReturnNewName("uredi datoteku", inputCommand);
                    _fileRepository.EditFile(fileName, currentUser.Id);
                }
                
                else if (inputCommand.StartsWith("komentari datoteke", StringComparison.OrdinalIgnoreCase))
                {
                    var fileName = Writer.ReturnNewName("komentari datoteke", inputCommand);
                    var file = _fileRepository.GetByName(fileName);

                    if (file == null)
                    {
                        Console.WriteLine("Datoteka nije pronađena.");
                        continue;
                    }
                    _commentRepository.DisplayComments(file.Id, currentUser.Id);
                }

            } while (inputCommand != "exit");
        }
    }
}
