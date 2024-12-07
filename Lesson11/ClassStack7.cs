using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11
{
    public class ClassStack7
    {
        public static int FindMinInStack(Stack<int> stack)
        {
            int current = stack.Pop(); // שליפת האיבר העליון

            if (stack.IsEmpty())
            {
                stack.Push(current); // החזרת האיבר למחסנית
                return current; // מחזיר את האיבר אם זה היחיד
            }

            int minOfRest = FindMinInStack(stack); // חישוב מינימום בשאר המחסנית
            int minValue = Math.Min(current, minOfRest); // השוואת המינימום הנוכחי
            stack.Push(current); // החזרת האיבר למחסנית

            return minValue; // החזרת המינימום שנמצא
        }


        public static void Run()
        {
            Random rnd = new Random();
            Stack<int> stack;
            int stackSize, minValue, stackCount = rnd.Next(3, 11);

            for (int i = 0; i < stackCount; i++)
            {
                stackSize = rnd.Next(3, 11);
                stack = new Stack<int>();

                for (int j = 0; j < stackSize; j++)
                    stack.Push(rnd.Next(101));

                Console.WriteLine($"Stack {i + 1}/{stackCount}: {stack}");

                minValue = FindMinInStack(stack);

                Console.WriteLine($"Minimum value in the stack: {minValue}");
                Console.WriteLine($"Stack after FindMinInStack: {stack}");
                Console.WriteLine();
            }
        }
    }
}
