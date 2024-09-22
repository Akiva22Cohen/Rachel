using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10
{
    public class Class1
    {
        public static int CountNum(Queue<int> q, int num)
        {
            int count = 0;
            Queue<int> temp = new Queue<int>();

            while (!q.IsEmpty())
            {
                if (q.Head() == num) 
                    count++;
                temp.Insert(q.Remove());
            }

            while (!temp.IsEmpty())
                q.Insert(temp.Remove());

            return count;
        }

        public static Queue<int> MergeQueue(Queue<int> q1, Queue<int> q2)
        {
            Queue<int> newQueue = new Queue<int>();
            Queue<int> tempQ1 = new Queue<int>();

            int x, y, z, w;

            while (!q1.IsEmpty())
            {
                w = CountNum(tempQ1, q1.Head());
                x = CountNum(q1, q1.Head()) + w;
                y = CountNum(q2, q1.Head());
                z = CountNum(newQueue, q1.Head());

                if (x > 0 && y > 0 && x != y && z == 0) 
                    newQueue.Insert(q1.Head());

                tempQ1.Insert(q1.Remove());
            }

            while (!tempQ1.IsEmpty())
                q1.Insert(tempQ1.Remove());

            return newQueue;
        }

        public static void Run()
        {
            Random rnd = new Random();
            Queue<int> q = new Queue<int>();
            for (int i = 0; i < rnd.Next(2, 20); i++) 
                q.Insert(rnd.Next(10));

            int num = rnd.Next(10);

            Console.WriteLine($"CountNum({q}, {num}): " + CountNum(q, num));

            Console.WriteLine(q);

            Queue<int> q2 = new Queue<int>();
            for (int i = 0; i < rnd.Next(2, 20); i++)
                q2.Insert(rnd.Next(10));

            Console.WriteLine($"MergeQueue(Queue<int> {q}, Queue<int> {q2}): " + MergeQueue(q, q2));
        }
    }
}
