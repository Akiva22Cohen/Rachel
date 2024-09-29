using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace End_of_semester_exam
{
    public class Class5
    {
        public static void Sod()
        {
            Stack<int> s = new Stack<int>();
            Stack<int> temp = new Stack<int>();

            int x;
            int n = int.Parse(Console.ReadLine());
            s.Push(n);
            n = int.Parse(Console.ReadLine());

            while (n > 0)
            {
                if (s.Top() > n)
                    s.Push(n);
                else
                {
                    while (!s.IsEmpty() && s.Top() < n)
                    {
                        x = s.Pop();
                        temp.Push(x);
                    }
                    s.Push(n);
                    while (!temp.IsEmpty())
                    {
                        x = temp.Pop();
                        s.Push(x);
                    }
                }
                n = int.Parse(Console.ReadLine());
            }

            while (!s.IsEmpty())
            {
                x = s.Pop();
                Console.WriteLine(x);
            }
        }

        public static void Run()
        {
            Sod();
        }
    }
}
