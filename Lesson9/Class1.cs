using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9
{
    public class Class1
    {
        public static int CountMember(Queue<int> queue)
        {
            Queue<int> temp = new Queue<int>();
            int count = 0;

            while (!queue.IsEmpty())
            {
                count++;
                temp.Insert(queue.Remove());
            }

            while (!temp.IsEmpty())
                queue.Insert(temp.Remove());


            return count;
        }

        public static void Run()
        {
            Queue<int> queue = new Queue<int>();
            queue.Insert(1);
            queue.Insert(2);
            queue.Insert(3);
            queue.Insert(4);
            queue.Insert(5);

            Console.WriteLine("queue:");
            Console.WriteLine(queue);

            Console.WriteLine(CountMember(queue));

        }
    }
}
