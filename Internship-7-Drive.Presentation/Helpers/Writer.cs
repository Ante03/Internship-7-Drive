
using System.Text.RegularExpressions;

namespace Internship_7_Drive.Presentation.Helpers
{
    public class Writer
    {
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
                Console.WriteLine("Unijeli ste krivo mail ili je mail zauzet vec, pokusajte ponovo (nesto@nesto.nesto): ");
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
    }
}
