using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9
{
    public class Class4
    {
        public static bool IsSort(Queue<int> queue)
        {
            Queue<int> temp = new Queue<int>();
            int prev;
            bool b = true;

            while (!queue.IsEmpty())
            {
                prev = queue.Remove();
                if (!queue.IsEmpty() && prev > queue.Head())
                    b = false;

                temp.Insert(prev);
            }

            while (!temp.IsEmpty())
                queue.Insert(temp.Remove());

            return b;
        }

        public static void Run()
        {
            Random rnd = new Random();
            int len = rnd.Next(2, 10);
            int num = 0, max = rnd.Next(2, 100);

            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < len; i++) 
            {
                num = rnd.Next(num, max);
                queue.Insert(num);

                if (num >= (0.5 * max))
                    max = (int)(max * 1.5);
            }

            Console.WriteLine($"IsSort(Queue<int> {queue}) => {IsSort(queue)}");

            Console.WriteLine();
            Console.WriteLine("queue: " + queue);


            Queue<int> queue2 = new Queue<int>();
            len = rnd.Next(2, 10);
            for (int i = 0; i < len; queue2.Insert(rnd.Next(100)), i++) ;

            Console.WriteLine();
            Console.WriteLine($"IsSort(Queue<int> {queue2}) => {IsSort(queue2)}");

            Console.WriteLine();
            Console.WriteLine("queue2: " + queue2);
        }
    }
}
