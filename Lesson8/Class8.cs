using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    public class Class8
    {
        public static void DeleteItem(Stack<char> stack, char ch)
        {
            Stack<char> stack1 = new Stack<char>();
            char c;

            while (!stack.IsEmpty())
            {
                c = stack.Pop();

                if (!(c == ch))
                    stack1.Push(c);
            }

            while (!stack1.IsEmpty()) 
                stack.Push(stack1.Pop());
        }

        public static void TestDeleteItem()
        {
            // יצירת מחסנית עם מספר תווים
            Stack<char> stack = new Stack<char>();
            stack.Push('a');
            stack.Push('b');
            stack.Push('c');
            stack.Push('a');
            stack.Push('d');
            stack.Push('a');

            // הדפסת מצב המחסנית לפני ההסרה
            Console.WriteLine("Stack before deleting 'a': " + stack.ToString());

            // קביעת התו להסרה
            char itemToDelete = 'a';

            // חיבור לפונקציה DeleteItem
            DeleteItem(stack, itemToDelete);

            // הדפסת מצב המחסנית לאחר ההסרה
            Console.WriteLine("Stack after deleting 'a': " + stack.ToString());
        }
    }
}
