
namespace Internship_7_Drive.Presentation.Helpers
{
    public class Reader
    {
        public static void ReadInput(string message, out string input)
        {
            Console.WriteLine(message);
            input = Console.ReadLine() ?? string.Empty;
        }
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
        public static bool CheckYesOrNo()
        {
            while (true)
            {
                Console.WriteLine("\nJeste sigurni da zelite stvoriti novu mapu ('da' ili 'ne'):");
                var input = Console.ReadLine()?.Trim().ToLower();

                if (input == "da")
                {
                    return true; 
                }
                else if (input == "ne")
                {
                    return false; 
                }
                else
                {
                    Console.WriteLine("Neispravan unos. Pokušajte ponovo."); 
                }
            }
        }
        public static string ReturnContent()
        {
            Console.Write("Unesite sadrzaj: ");
            var enteredContent = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(enteredContent))
            {
                Console.Write("Sadrzaj ne moze biti prazan! Unesite sadrzaj: ");
                enteredContent = Console.ReadLine();
            }
            return enteredContent;
        }
    }
}
