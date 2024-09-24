using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10
{
    public class Class3
    {
        public static Queue<int> Temp(Queue<int> queue)
        {
            Queue<int> newQ = new Queue<int>();
            Queue<int> temp = new Queue<int>();
            int num, max;

            while (!queue.IsEmpty())
            {
                max = queue.Head();

                while (!queue.IsEmpty() && queue.Head() != -1)
                {
                    num = queue.Remove();
                    if (num > max)
                        max = num;

                    temp.Insert(num);
                }

                newQ.Insert(max);

                if (!queue.IsEmpty())
                {
                    newQ.Insert(queue.Head());
                    temp.Insert(queue.Remove());
                }
            }

            while (!temp.IsEmpty())
                queue.Insert(temp.Remove());

            return newQ;
        }

        public static void Run()
        {
            Queue<int> queue = new Queue<int>();
            queue.Insert(34);
            queue.Insert(65);
            queue.Insert(3);
            queue.Insert(-1);
            queue.Insert(100);
            queue.Insert(-1);
            queue.Insert(678);
            queue.Insert(89);
            queue.Insert(5);

            Console.WriteLine($"Temp(Queue<int> {queue}): {Temp(queue)}");
            Console.WriteLine(queue);
        }
    }
}
