using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_7_Drive.Presentation.Helpers
{
    public class Reader
    {
        public static int CheckNumberBetweenRange(string message, int smallestNumber, int biggestNumber)
        {
            var EnteredNumber = -1;
            do
            {
                Console.WriteLine(message);
                int.TryParse(Console.ReadLine(), out EnteredNumber);
            } while (EnteredNumber > biggestNumber || EnteredNumber < smallestNumber);
            return EnteredNumber;
        }
        public static string GenerateCaptcha()
        {
            var random = new Random();
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] captcha = new char[6];

            bool hasLetter = false;
            bool hasDigit = false;

            for (int i = 0; i < captcha.Length; i++)
            {
                char nextChar = characters[random.Next(characters.Length)];
                captcha[i] = nextChar;

                if (char.IsLetter(nextChar))
                    hasLetter = true;

                if (char.IsDigit(nextChar))
                    hasDigit = true;
            }

            if (!hasLetter || !hasDigit)
                return GenerateCaptcha();

            return new string(captcha);
        }
        public static bool ConfirmCaptcha()
        {
            string captcha = GenerateCaptcha();
            Console.WriteLine($"Captcha: {captcha}");

            Console.WriteLine("Ponovite unesenu Captcha:");
            string userInput = Console.ReadLine();

            if (captcha == userInput)
                return true;

            return false;
        }
        public static string EnterName()
        {
            Console.Write("Unesite ime: ");
            var enteredName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(enteredName))
            {
                Console.Write("Neispravno ime, unesite novo ime: ");
                enteredName = Console.ReadLine();
            }
            return enteredName;
        }
        public static string EnterSurname()
        {
            Console.Write("Unesite prezime: ");
            var enteredSurname = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(enteredSurname))
            {
                Console.Write("Neispravno prezime, unesite novo prezime: ");
                enteredSurname = Console.ReadLine();
            }
            return enteredSurname;
        }
    }
}
