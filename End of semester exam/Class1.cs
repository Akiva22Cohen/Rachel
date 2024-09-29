using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace End_of_semester_exam
{
    public class Class1
    {
        public static Queue<int> SumLongNumbers(Queue<int> num1, Queue<int> num2)
        {
            Queue<int> result = new Queue<int>();
            Stack<int> temp1 = new Stack<int>();
            Stack<int> temp2 = new Stack<int>();

            int n1, n2, sum, r, l = 0;

            Stack<int> stack = new Stack<int>();

            while (!num1.IsEmpty() && !num2.IsEmpty())
            {
                temp1.Push(num1.Remove());
                temp2.Push(num2.Remove());
            }

            if (num1.IsEmpty())
                while (!num2.IsEmpty())
                    temp2.Push(num2.Remove());

            else
                while (!num1.IsEmpty())
                    temp1.Push(num1.Remove());

            while (!temp1.IsEmpty() && !temp2.IsEmpty())
            {
                n1 = temp1.Pop();
                n2 = temp2.Pop();

                sum = n1 + n2 + l;
                r = sum % 10;
                l = sum / 10;

                stack.Push(r);

                num1.Insert(n1);
                num2.Insert(n2);
            }

            if (temp1.IsEmpty())
            {
                while (!temp2.IsEmpty())
                {
                    n2 = temp2.Pop();

                    sum = n2 + l;
                    r = sum % 10;
                    l = sum / 10;
                    stack.Push(r);

                    num2.Insert(n2);
                }
            }
            else
            {
                while (!temp1.IsEmpty())
                {
                    n1 = temp1.Pop();

                    sum = n1 + l;
                    r = sum % 10;
                    l = sum / 10;
                    stack.Push(r);

                    num1.Insert(n1);
                }
            }

            if (l > 0) 
                stack.Push(l);

            while (!stack.IsEmpty())
                result.Insert(stack.Pop());

            return result;
        }

        public static void Run()
        {
            Random rnd = new Random();

            int len = rnd.Next(2, 7);
            Queue<int> q1 = new Queue<int>();
            for (int i = 0; i < len; i++)
                q1.Insert(rnd.Next(10));

            len = rnd.Next(2, 7);
            Queue<int> q2 = new Queue<int>();
            for (int i = 0; i < len; i++)
                q2.Insert(rnd.Next(10));

            Console.WriteLine($"SumLongNumbers(Queue<int> {q1}, Queue<int> {q2}): {SumLongNumbers(q1, q2)}");

            Console.WriteLine("q1:" + q1);
            Console.WriteLine("q2:" + q2);
        }
    }
}
