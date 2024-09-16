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
            Random rnd = new Random();
            int len = rnd.Next(2, rnd.Next(3, 20));
            
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < len; queue.Insert(rnd.Next(rnd.Next(100))), i++) ;

            Console.Write("queue: ");
            Console.WriteLine(queue);

            Console.WriteLine("len: " + len);
            Console.WriteLine("CountMember(queue): " + CountMember(queue));

        }
    }
}
