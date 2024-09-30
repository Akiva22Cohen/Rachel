using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace End_of_semester_exam
{
    public class Class1
    {
        public static Stack<int> QueueConvertToStack(Queue<int> queue)
        {
            Stack<int> stack = new Stack<int>();
            Queue<int> temp = new Queue<int>();

            while (!queue.IsEmpty())
            {
                stack.Push(queue.Head());
                temp.Insert(queue.Remove());
            }

            while (!temp.IsEmpty())
                queue.Insert(temp.Remove());

            return stack;
        }

        public static void Temp(Stack<int> q1, Stack<int> q2, int remainder)
        {
            int num, sum, r;

            if (!q1.IsEmpty())
            {
                while (!q1.IsEmpty())
                {
                    num = q1.Pop();

                    sum = num + remainder;
                    r = sum % 10;
                    remainder = sum / 10;

                    q2.Push(r);
                }

                if (remainder > 0)
                    q2.Push(remainder);
            }
        }

        public static Queue<int> SumLongNumbers(Queue<int> num1, Queue<int> num2)
        {
            Queue<int> result = new Queue<int>();

            Stack<int> temp1 = QueueConvertToStack(num1);
            Stack<int> temp2 = QueueConvertToStack(num2);

            int n1, n2, sum, r, l = 0;

            Stack<int> stack = new Stack<int>();

            while (!temp1.IsEmpty() && !temp2.IsEmpty())
            {
                n1 = temp1.Pop();
                n2 = temp2.Pop();

                sum = n1 + n2 + l;
                r = sum % 10;
                l = sum / 10;

                stack.Push(r);
            }

            if (temp1.IsEmpty() && temp2.IsEmpty() && l > 0) 
                stack.Push(l);

            Temp(temp1, stack, l);
            Temp(temp2, stack, l);

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
