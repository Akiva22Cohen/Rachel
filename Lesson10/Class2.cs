using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10
{
    public class Class2
    {
        public static bool IsAValidBoolExpression(Queue<char> queue)
        {
            Queue<char> temp = new Queue<char>();

            if (queue.Head() != 'T' && queue.Head() != 'F')
                return false;

            temp.Insert(queue.Remove());
            bool flag = true, b = false;
            char c;

            while (!queue.IsEmpty())
            {
                c = queue.Remove();

                flag = flag && (((!b) && (c == 'A' || c == 'O')) || (b && (c == 'T' || c == 'F')));
                b = !b;

                if (queue.IsEmpty() && (c != 'T' && c != 'F'))
                    flag = false;

                temp.Insert(c);
            }

            while (!temp.IsEmpty())
                queue.Insert(temp.Remove());

            return flag;
        }

        public static void Run()
        {
            Random rnd = new Random();

            Queue<char> queue = new Queue<char>();
            queue.Insert('F');
            queue.Insert('O');
            queue.Insert('T');
            queue.Insert('A');
            queue.Insert('T');

            Console.WriteLine($"IsAValidBoolExpression(Queue<char> {queue}): " + IsAValidBoolExpression(queue));
            Console.WriteLine("\n");

            Queue<char> queue2;
            int len;
            char[] chars = { 'T', 'F', 'A', 'O' };

            do
            {
                queue2 = new Queue<char>();
                len = rnd.Next(2, 10);

                for (int i = 0; i < len; i++)
                    queue2.Insert(chars[rnd.Next(chars.Length)]);

                Console.WriteLine($"IsAValidBoolExpression(Queue<char> {queue2}): " + IsAValidBoolExpression(queue2));
                Console.WriteLine();

            } while (!IsAValidBoolExpression(queue2));
        }
    }
}
