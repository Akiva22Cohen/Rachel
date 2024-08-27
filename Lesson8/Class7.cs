using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    public class Class7
    {
        public static void InsertEnd(Stack<char> stack)
        {
            char ch = char.Parse(Console.ReadLine());

            Stack<char> stack1 = new Stack<char>();

            while (!stack.IsEmpty())
                stack1.Push(stack.Pop());

            stack1.Push(ch);

            while (!stack1.IsEmpty())
                stack.Push(stack1.Pop());
        }


        public static void TestInsertEnd()
        {
            // יצירת מחסנית עם מספר תווים
            Stack<char> stack = new Stack<char>();
            stack.Push('a');
            stack.Push('b');
            stack.Push('c');

            // הדפסת מצב המחסנית לפני ההכנסה
            Console.WriteLine("Stack before inserting: " + stack.ToString());

            // הקלט התו החדש להוספה
            Console.WriteLine("Enter the character to insert at the end:");

            // כאן נשתמש בקלט לדוגמה, אם בודקים ידנית, הקלד תו כמו 'd'
            // לא ניתן להקליד בתשובה האוטומטית, אז נניח שתהיה אפשרות להוסיף 'd' דרך שורת הפקודה.

            // חיבור לפונקציה InsertEnd
            InsertEnd(stack);

            // הדפסת מצב המחסנית לאחר ההכנסה
            Console.WriteLine("Stack after inserting: " + stack.ToString());
        }
    }
}
