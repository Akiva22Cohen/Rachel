using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11
{
    public class ClassTor1
    {
        public static bool IsInQueue(Queue<int> queue, int num)
        {
            if(queue.IsEmpty()) return false;
            else if (queue.Remove() == num) return true;
            return IsInQueue(queue, num);

        }

        public static void Run()
        {
            Random rnd = new Random();
            Queue<int> queue;
            int len, num;
            bool isInTor = false;

            while (!isInTor)
            {
                len = rnd.Next(2, 11);
                queue = new Queue<int>();

                for (int i = 0; i < len; i++)
                    queue.Insert(rnd.Next(101));

                Console.WriteLine("Original Queue: " + queue);

                num = rnd.Next(101);
                isInTor = IsInQueue(queue, num);

                Console.WriteLine($"Number {num}: Found = {isInTor}");
                Console.WriteLine("After IsInQueue: " + queue);
                Console.WriteLine();
            }
        }
    }
}
