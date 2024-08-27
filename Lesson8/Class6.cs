using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    public class Class6
    {
        public static int FindPlace(Stack<char> stack, char ch)
        {
            Stack<char> tempStack = new Stack<char>();
            int i = 0;
            char current;

            while (!stack.IsEmpty())
            {
                current = stack.Pop();
                tempStack.Push(current);
                if (current == ch)
                {
                    while (!tempStack.IsEmpty())
                        stack.Push(tempStack.Pop());
                    return i;
                }
                i++;
            }

            return -1;
        }

        public static void TestFindPlace()
        {
            // יצירת מחסנית עם מספר תווים
            Stack<char> stack = new Stack<char>();
            stack.Push('a');
            stack.Push('b');
            stack.Push('c');
            stack.Push('d');
            stack.Push('e');

            // הדפסת מצב המחסנית לפני חיפוש המקום
            Console.WriteLine("Stack before finding the place: " + stack.ToString());

            // חיפוש מקום של האות 'c'
            int place = FindPlace(stack, 'c');

            // הדפסת התוצאה (אמור להדפיס 2, כי 'c' היא האות השלישית מלמעלה)
            Console.WriteLine("Place of 'c' in the stack: " + place);

            // הדפסת מצב המחסנית לאחר חיפוש המקום
            Console.WriteLine("Stack after finding the place: " + stack.ToString());
        }
    }
}
