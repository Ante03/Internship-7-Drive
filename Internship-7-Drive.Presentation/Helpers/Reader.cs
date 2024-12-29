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
    }
}
