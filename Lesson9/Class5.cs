using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9
{
    public class Class5
    {
        public static bool AreSame(Queue<int> q1, Queue<int> q2)
        {
            Queue<int> tQ1 = new Queue<int>();
            Queue<int> tQ2 = new Queue<int>();
            bool b = true;

            while (!q1.IsEmpty() && !q2.IsEmpty())
            {
                if (q1.Head() != q2.Head()) 
                    b = false;

                tQ1.Insert(q1.Remove());
                tQ2.Insert(q2.Remove());
            }

            if (!q1.IsEmpty() || !q2.IsEmpty()) 
                b = false;

            while (!q1.IsEmpty())
                tQ1.Insert(q1.Remove());
            
            while (!q2.IsEmpty())
                tQ2.Insert(q2.Remove());

            
            while (!tQ1.IsEmpty())
                q1.Insert(tQ1.Remove());
            
            while (!tQ2.IsEmpty())
                q2.Insert(tQ2.Remove());

            return b;
        }

        public static void Run()
        {
            Random rnd = new Random();
            int len = rnd.Next(2, 10);

            Queue<int> q1 = new Queue<int>();
            Queue<int> q2 = new Queue<int>();

            for (int i = 0; i < len; q1.Insert(rnd.Next(10)), i++) ;

            len = rnd.Next(2, 10);

            for (int i = 0; i < len; q2.Insert(rnd.Next(10)), i++) ;

            Console.WriteLine($"AreSame(Queue<int> {q1}, Queue<int> {q2}) => {AreSame(q1, q2)}");

            Console.WriteLine();
            Console.WriteLine("q1: " + q1);
            Console.WriteLine("q2: " + q2);

            len = rnd.Next(2, 10);
            q1 = new Queue<int>();
            q2 = new Queue<int>();
            for (int i = 0, num; i < len; num = rnd.Next(10), q1.Insert(num), q2.Insert(num), i++) ;

            Console.WriteLine();
            Console.WriteLine($"AreSame(Queue<int> {q1}, Queue<int> {q2}) => {AreSame(q1, q2)}");
            
            Console.WriteLine();
            Console.WriteLine("q1: " + q1);
            Console.WriteLine("q2: " + q2);
        }
    }
}
