using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11
{
    public class Class4
    {
        // פונקציה למציאת הספרה הקטנה ביותר:
        public static int MinDigit(int num)
        {
            int temp, digit;
            if (num < 10)
                return num;
            else
            {
                temp = MinDigit(num / 10);
                digit = num % 10;

                return digit < temp ? digit : temp;
            }
        }

        public static void Run()
        {
            Random rnd = new Random();

            int num, smallDigit, len;
            int overallSmallestDigit = 9; // מתחילים מהספרה הגדולה ביותר האפשרית.

            // קביעת אורך הרשימה בין 3 ל-10 מספרים.
            len = rnd.Next(3, 11);

            Console.WriteLine($"The smallest digits in the following {len} numbers:");
            for (int i = 0; i < len; i++)
            {
                // יצירת מספר אקראי בן 3 עד 5 ספרות.
                num = rnd.Next(100, 10000);

                // חישוב הספרה הקטנה ביותר.
                smallDigit = MinDigit(num);

                // עדכון הספרה הקטנה ביותר הכללית.
                if (smallDigit < overallSmallestDigit)
                    overallSmallestDigit = smallDigit;
                
                // הדפסת המספר והספרה הקטנה ביותר.
                Console.WriteLine($"\tThe smallest digit in the number {num}: {smallDigit}");
            }

            // הצגת הספרה הקטנה ביותר מבין כל המספרים.
            Console.WriteLine($"\nThe smallest digit found in all numbers: {overallSmallestDigit}");

        }
    }
}
