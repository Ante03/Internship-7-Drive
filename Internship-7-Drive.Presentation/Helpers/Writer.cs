using Internship_7_Drive.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
