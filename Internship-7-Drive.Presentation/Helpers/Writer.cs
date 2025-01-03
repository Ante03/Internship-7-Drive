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
            Console.WriteLine("stvori mapu ime_mape - za stvaranje mape");
            Console.WriteLine("stvori datoteku ime_datoeke - za stvaranje datoteke");
            Console.WriteLine("udi u mapu ime_mape - za ulazak u mapu");
            Console.WriteLine("izbrisi mapu ime_mape - za brisanje mape");
            Console.WriteLine("izbrisi datoteku ime_datoteke - za brisanje datoteke");
            Console.WriteLine("promjeni naziv mape 'ime mape' u 'novo ime mape' - za preimenovanje mape");
            Console.WriteLine("promjeni naziv datoteke 'ime datoteke' u 'novo ime datoteke' - za preimenovanje datoteke");
            Console.WriteLine("uredi datoteku ime_datoteke - za uredivanje datoteke");
            Console.WriteLine("komentari datoteke ime datoteke - za dodavanje, uredivanje i brisanje komentara");
            Console.WriteLine("exit - za povratak na prethodni izbornik\n");
        }
        public static void WriteHelpCommandsForShare()
        {
            Console.WriteLine("\nDostupne komande:");
            Console.WriteLine("podijeli mapu 'ime_mape' sa 'mail' - za dijeljenje mape s korisnikom");
            Console.WriteLine("podijeli datoteku 'ime_datoteke' sa 'mail' - za dijeljenje datoteke s korisnikom");
            Console.WriteLine("prestani dijeliti mapu 'ime_mape' sa 'mail' - za prekid dijeljenja mape");
            Console.WriteLine("prestani dijeliti datoteku 'ime_datoteke' sa 'mail' - za prekid dijeljenja datoteke");
            Console.WriteLine("uredi datoteku ime_datoteke - za uredivanje dijeljene datoteke");
            Console.WriteLine("dodaj komentar datoteci ime_datoteke - za dodavanje komentara");
            Console.WriteLine("exit - za povratak na prethodni izbornik\n");
        }
        public static bool CheckNewName(string input, string trim)
        {
            var folderName = input.Substring(trim.Length).Trim();
            if (string.IsNullOrWhiteSpace(folderName))
                return false;
            return true;
        }
        public static string ReturnNewName(string checkString, string input)
        {
            var newName = input.Substring(checkString.Length).Trim();
            return newName;
        }
    }
}
