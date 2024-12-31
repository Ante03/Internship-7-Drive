
using Internship_7_Drive.Data.Entities.Models;
using System.Text.RegularExpressions;

namespace Internship_7_Drive.Presentation.Helpers
{
    public class Writer
    {
        public static void Write(User user)
           => Console.WriteLine($"{user.FirstName} {user.LastName}");
        public static string EnterMail()
        {
            Console.Write("Unesite mail: ");
            var enteredMail = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(enteredMail))
            {
                Console.Write("Unesite ponovo mail: ");
                enteredMail = Console.ReadLine();
            }
            return enteredMail;
        }
        public static string EnterPassword()
        {
            Console.Write("Unesite sifru: ");
            var enteredPassword = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(enteredPassword))
            {
                Console.Write("Unesite ponovo sifru: ");
                enteredPassword = Console.ReadLine();
            }
            return enteredPassword;
        }
        public static string ChangeEmail() 
        {
            string emailPattern = @"^[^@]+@[a-zA-Z]{2,}\.[a-zA-Z]{3,}$";
            Console.Write("Unesite e-mail: ");
            var EnternedMail = Console.ReadLine();
            while (!Regex.IsMatch(EnternedMail, emailPattern))
            {
                Console.WriteLine("Unijeli ste krivo mail, pokusajte ponovo (nesto@nesto.nesto): ");
                EnternedMail = Console.ReadLine();
            }
            return EnternedMail;
        }
        public static string ChangePassword()
        {
            Console.Write("Unesite sifru: ");
            var enteredPassword = Console.ReadLine();
            Console.Write("Unesite ponovo sifru: ");
            var enteredPasswordSecondTime = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(enteredPassword) || enteredPassword != enteredPasswordSecondTime)
            {
                Console.WriteLine("Unesene sifre se ne poklapaju! Ponovite ispravno postupak: \n");
                Console.Write("Unesite sifru: ");
                enteredPassword = Console.ReadLine();
                Console.Write("Unesite ponovo sifru: ");
                enteredPasswordSecondTime = Console.ReadLine();
            }
            return enteredPassword;
        }
        public static void WriteHelpCommands()
        {
            Console.WriteLine("\nDostupne komande:");
            Console.WriteLine("help - za ispis svih komandi");
            Console.WriteLine("stvori mapu 'ime mape' - za stvaranje mape");
            Console.WriteLine("exit - za povratak na prethodni izbornik\n");
        }
        public static bool CheckFolderName(string input)
        {
            var folderName = input.Substring("stvori mapu".Length).Trim();
            if (string.IsNullOrWhiteSpace(input))
                return false;
            return true;
        }
        public static string ReturnFolderName(string input)
        {
            var folderName = input.Substring("stvori mapu".Length).Trim();
            return folderName;
        }
    }
}
