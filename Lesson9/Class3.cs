using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9
{
    public class Class3
    {
        public static bool IsItIN(Queue<int> queue, int num)
        {
            Queue<int> temp = new Queue<int>();
            bool b = false;

            while (!queue.IsEmpty())
            {
                if (queue.Head() == num)
                    b = true;

                temp.Insert(queue.Remove());
            }

            while (!temp.IsEmpty())
                queue.Insert(temp.Remove());

            return b;
        }

        public static void Run()
        {
            Random rnd = new Random();
            int len = rnd.Next(2, 10);
            int num = rnd.Next(10);

            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < len; queue.Insert(rnd.Next(10)), i++) ;

            Console.WriteLine($"IsItIN(Queue<int> {queue}, int {num}) => " + IsItIN(queue, num));

            Console.WriteLine("queue: " + queue);
        }
    }
}
