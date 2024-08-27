using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    public class Class9
    {
        public static Stack<int> Merge2Stacks(Stack<int> stack1, Stack<int> stack2)
        {
            Stack<int> newStack = new Stack<int>();

            while (!stack1.IsEmpty() && !stack2.IsEmpty())
            {
                newStack.Push(stack1.Pop());
                newStack.Push(stack2.Pop());
            }

            if (stack1.IsEmpty())
                while (!stack2.IsEmpty())
                    newStack.Push(stack2.Pop());
            else
                while (!stack1.IsEmpty())
                    newStack.Push(stack1.Pop());

            return newStack;
        }

        public static void TestMerge2Stacks()
        {
            // יצירת מחסניות עם מספר איברים
            Stack<int> stack1 = new Stack<int>();
            Stack<int> stack2 = new Stack<int>();

            // הוספת איברים למחסנית הראשונה
            stack1.Push(1);
            stack1.Push(3);
            stack1.Push(5);

            // הוספת איברים למחסנית השנייה
            stack2.Push(2);
            stack2.Push(4);
            stack2.Push(6);
            stack2.Push(7);

            // הדפסת מצב המחסניות לפני המיזוג
            Console.WriteLine("Stack1 before merge: " + stack1.ToString());
            Console.WriteLine("Stack2 before merge: " + stack2.ToString());

            // מיזוג המחסניות
            Stack<int> mergedStack = Merge2Stacks(stack1, stack2);

            // הדפסת מצב המחסנית המאוחדת
            Console.WriteLine("Merged Stack: " + mergedStack.ToString());
        }
    }
}
