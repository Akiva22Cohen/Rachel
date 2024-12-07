using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11
{
    public class ClassTor2
    {
        public static int CountEvens(Queue<int> queue)
        {
            if (queue.IsEmpty()) return 0;
            else if (queue.Remove() % 2 == 0) 
                return CountEvens(queue) + 1;

            return CountEvens(queue);
        }

        public static void Run()
        {
            Random rnd = new Random();
            Queue<int> queue;
            int len, evenCount = 0;

            while (evenCount == 0)
            {
                len = rnd.Next(2, 11);
                queue = new Queue<int>();

                for (int i = 0; i < len; i++)
                    queue.Insert(rnd.Next(101));

                Console.WriteLine("Original Queue: " + queue);

                evenCount = CountEvens(queue);

                Console.WriteLine($"Number of even numbers: {evenCount}");
                Console.WriteLine("Queue after CountEvens: " + queue);
                Console.WriteLine();
            }
        }
    }
}
