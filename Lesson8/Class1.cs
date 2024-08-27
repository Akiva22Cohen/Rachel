using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    public class Class1
    {
        public static int CountStack(Stack<int> stack)
        {
            Stack<int> tempStack = new Stack<int>();
            int count = 0;

            while (!stack.IsEmpty())
            {
                count++;
                tempStack.Push(stack.Pop());
            }

            while (!tempStack.IsEmpty())
                stack.Push(tempStack.Pop());

            return count;
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

        public static void TestCountStack()
        {
            // יצירת מחסנית עם מספר איברים
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            PrintStack(stack);
            // ספירת האיברים
            int count = CountStack(stack);

            // הדפסת התוצאה (אמור להדפיס 4)
            Console.WriteLine("Number of elements in the stack: " + count);
            PrintStack(stack);
        }
    }
}
