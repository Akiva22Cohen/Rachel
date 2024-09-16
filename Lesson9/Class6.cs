using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9
{
    public class Class6
    {
        public static void Temp(Queue<int> queue, int num)
        {
            Queue<int> q = new Queue<int>();
            int n = 0;
            bool find = false;

            while (!queue.IsEmpty())
            {
                if (queue.Head() == num && !find)
                {
                    n = queue.Remove();
                    find = true;
                }

                if (!queue.IsEmpty())
                    q.Insert(queue.Remove());
            }

            if (find)
                q.Insert(n);

            while (!q.IsEmpty())
                queue.Insert(q.Remove());
        }

        public static void Run()
        {
            Random rnd = new Random();
            int len = rnd.Next(2, 10);
            int num = rnd.Next(10);

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < len; queue.Insert(rnd.Next(10)), i++) ;

            Console.WriteLine($"Temp(Queue<int> {queue}, int {num})");
            Temp(queue, num);

            Console.WriteLine();
            Console.WriteLine("queue: " + queue);
        }
    }
}
