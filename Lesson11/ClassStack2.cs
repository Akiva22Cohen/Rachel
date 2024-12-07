using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11
{
    public class ClassStack2
    {
        public static bool IsInStack(Stack<int> stack, int num)
        {
            if (stack.IsEmpty())
                return false;

            int x = stack.Pop(); // הוצאת איבר מהמחסנית

            bool found;
            if (x == num)
                found = true; // המספר נמצא
            else
                found = IsInStack(stack, num); // קריאה רקורסיבית

            stack.Push(x); // החזרת האיבר למחסנית

            return found; // החזרת התוצאה
        }

        public static void Run()
        {
            Random rnd = new Random();
            Stack<int> stack;
            int len, num;
            bool isInStack = false;

            while (!isInStack)
            {
                len = rnd.Next(2, 11);
                stack = new Stack<int>();

                for (int i = 0; i < len; i++)
                    stack.Push(rnd.Next(101));

                Console.WriteLine("Original stack: " + stack);

                num = rnd.Next(101);
                isInStack = IsInStack(stack, num);

                Console.WriteLine($"Number {num}: Found = {isInStack}");
                Console.WriteLine("After IsInStack: " + stack);
                Console.WriteLine();
            }
        }
    }
}
