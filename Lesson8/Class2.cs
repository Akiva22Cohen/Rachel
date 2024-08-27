using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    public class Class2
    {
        public static void ReverseStack(Stack<int> stack)
        {
            Stack<int> stack1 = new Stack<int>();
            Stack<int> stack2 = new Stack<int>();

            while (!stack.IsEmpty())
                stack1.Push(stack.Pop());

            while (!stack1.IsEmpty())
                stack2.Push(stack1.Pop());

            while (!stack2.IsEmpty())
                stack.Push(stack2.Pop());
        }

        public static void PrintStack(Stack<int> stack)
        {
            Stack<int> backup = new Stack<int>();
            int x;

            while (!stack.IsEmpty())
            {
                x = stack.Pop();
                backup.Push(x);
                Console.Write(x + " ");
            }
            Console.WriteLine();
            while (!backup.IsEmpty()) stack.Push(backup.Pop());
        }

        public static void RunDemo()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            PrintStack(stack);
            ReverseStack(stack);
            PrintStack(stack);
        }
    }
}
