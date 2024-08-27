using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    public class Class5
    {
        public static int GreaterAvrg(Stack<int> stack)
        {
            Stack<int> stack1 = new Stack<int>();
            int sum = 0, count = 0, avg, x;

            while (!stack.IsEmpty())
            {
                x = stack.Pop();
                count++;
                sum += x;
                stack1.Push(x);
            }

            avg = sum / count;
            sum = 0;

            while (!stack1.IsEmpty())
            {
                x = stack1.Pop();
                if (x > avg) 
                    sum += x;
                stack.Push(x);
            }

            return sum;
        }

        public static void TestGreaterAvrg()
        {
            // יצירת מחסנית עם מספר איברים
            Stack<int> stack = new Stack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Push(40);
            stack.Push(50);

            // הדפסת מצב המחסנית לפני חישוב הסכום של האיברים הגדולים מהממוצע
            Console.WriteLine("Stack before computing greater average sum: " + stack.ToString());

            // חישוב הסכום של האיברים הגדולים מהממוצע
            int sum = GreaterAvrg(stack);

            // הדפסת התוצאה (הסכום של האיברים הגדולים מהממוצע)
            Console.WriteLine("Sum of elements greater than average: " + sum);

            // הדפסת מצב המחסנית לאחר חישוב הסכום
            Console.WriteLine("Stack after computing greater average sum: " + stack.ToString());
        }
    }
}
