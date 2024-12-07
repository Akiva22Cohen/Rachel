using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11
{
    public class ClassStack3
    {
        public static int CountEvens(Stack<int> stack)
        {
            if (stack.IsEmpty())
                return 0;

            int x = stack.Pop(); // הוצאת איבר מהמחסנית
            int count = CountEvens(stack); // קריאה רקורסיבית

            if (x % 2 == 0)
                count += 1; // אם האיבר זוגי, הגדל את הספירה

            stack.Push(x); // החזרת האיבר למחסנית

            return count; // החזרת המספר הכולל של איברים זוגיים
        }


        public static void Run()
        {
            Random rnd = new Random();
            Stack<int> stack;
            int len, evenCount = 0;

            while (evenCount == 0)
            {
                len = rnd.Next(2, 11);
                stack = new Stack<int>();

                for (int i = 0; i < len; i++)
                    stack.Push(rnd.Next(101));

                Console.WriteLine("Original Stack: " + stack);

                evenCount = CountEvens(stack);

                Console.WriteLine($"Number of even numbers: {evenCount}");
                Console.WriteLine("Stack after CountEvens: " + stack);
                Console.WriteLine();
            }
        }
    }
}
