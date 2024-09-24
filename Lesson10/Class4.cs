using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10
{
    public class Class4
    {
        public static Queue<int> Temp(Queue<int> queue)
        {
            Queue<int> newQ = new Queue<int>();
            Queue<int> temp = new Queue<int>();
            int num;

            while (!queue.IsEmpty())
            {
                num = queue.Remove();
                for (int i = 0; i < num; i++)
                    newQ.Insert(num);

                temp.Insert(num);
            }

            while (!temp.IsEmpty())
                queue.Insert(temp.Remove());

            return newQ;
        }

        public static void Run()
        {
            Queue<int> queue = new Queue<int>();
            queue.Insert(2);
            queue.Insert(1);
            queue.Insert(3);

            Console.WriteLine($"Temp(Queue<int> {queue}): {Temp(queue)}");
            Console.WriteLine(queue);
        }
    }
}
