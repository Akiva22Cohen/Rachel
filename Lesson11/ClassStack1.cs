using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11
{
    public class ClassStack1
    {
        public static int Max(int x, int y)
        {
            if (x > y) 
                return x;
            
            return y;
        }

        public static int FindMaxInStack(Stack<int> stk)
        {
            int x, y = -1;
            if (stk.IsEmpty())
                return -1;
            x = stk.Pop();
            y = Max(x, FindMaxInStack(stk));
            stk.Push(x);
            return y;
        }

        public static void Run()
        {
            Random rnd = new Random();
            Stack<int> stack;
            int stackSize, maxValue , stackCount = rnd.Next(3, 11);

            for (int i = 0; i < stackCount; i++) 
            {
                stackSize = rnd.Next(3, 11);
                stack = new Stack<int>();

                for (int j = 0; j < stackSize; j++)
                    stack.Push(rnd.Next(101));

                Console.WriteLine($"Stack {i + 1}/{stackCount}: {stack}");

                maxValue  = FindMaxInStack(stack);

                Console.WriteLine($"Maximum value in the stack: {maxValue }");
                Console.WriteLine($"Stack after FindMaxInStack: {stack}");
                Console.WriteLine();
            }
        }
    }
}
