using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    public class Class3
    {
        public static int SumStack(Stack<int> stack)
        {
            Stack<int> tempStack = new Stack<int>();
            int sum = 0, x;

            while (!stack.IsEmpty())
            {
                x = stack.Pop();
                sum += x;
                tempStack.Push(x);
            }

            while (!tempStack.IsEmpty())
                stack.Push(tempStack.Pop());

            return sum;
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

        public static void TestSumStack()
        {
            // יצירת מחסנית עם מספר איברים
            Stack<int> stack = new Stack<int>();
            stack.Push(5);
            stack.Push(10);
            stack.Push(15);
            stack.Push(20);

            PrintStack(stack);
            // חישוב הסכום
            int sum = SumStack(stack);

            // הדפסת התוצאה (אמור להדפיס 50)
            Console.WriteLine("Sum of elements in the stack: " + sum);
            PrintStack(stack);
        }
    }
}
