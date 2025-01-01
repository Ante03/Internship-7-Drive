﻿
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
            Console.WriteLine("stvori datoteku 'ime mape' - za stvaranje mape");
            Console.WriteLine("udi u mapu - za ulazak u mapu");
            Console.WriteLine("izbrisi 'ime mape' - za brisanje mape");
            Console.WriteLine("izbrisi 'ime datoteke' - za brisanje datoteke");
            Console.WriteLine("promjeni naziv mape 'ime mape' u 'novo ime mape' - za preimenovanje mape");
            Console.WriteLine("promjeni naziv datoteke 'ime datoteke' u 'novo ime datoteke' - za preimenovanje datoteke");
            Console.WriteLine("uredi datoteku 'ime datoteke' - za uredivanje datoteke");
            Console.WriteLine("komentari datoteke 'Ime datoteme' - za dodavanje, uredivanje i brisanje koemntara");
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
