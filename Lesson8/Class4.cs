using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    public class Class4
    {
        public static int MaxStack(Stack<int> stack)
        {
            Stack<int> tempStack = new Stack<int>();
            int x = stack.Pop(), max = x;
            tempStack.Push(x);

            while (!stack.IsEmpty())
            {
                x = stack.Pop();
                if (x > max) 
                    max = x;
                tempStack.Push(x);
            }

            while (!tempStack.IsEmpty())
                stack.Push(tempStack.Pop());

            return max;
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

        public static void TestMaxStack()
        {
            // יצירת מחסנית עם מספר איברים
            Stack<int> stack = new Stack<int>();
            stack.Push(5);
            stack.Push(22);
            stack.Push(3);
            stack.Push(20);

            // חישוב הערך המקסימלי
            int max = MaxStack(stack);

            // הדפסת התוצאה (אמור להדפיס 20)
            Console.WriteLine("Maximum element in the stack: " + max);

            // בדיקה אם המחסנית חוזרת למצב המקורי שלה
            Console.WriteLine("Stack after finding the max: " + stack.ToString());
        }
    }
}
