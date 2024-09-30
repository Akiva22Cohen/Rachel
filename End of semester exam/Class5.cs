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
            Console.Write($"n: {n}, ");

            s.Push(n);
            Console.WriteLine($"s: {s}");

            Console.WriteLine();
            n = int.Parse(Console.ReadLine());
            Console.Write($"n: {n}, ");

            while (n > 0)
            {
                if (s.Top() > n)
                {
                    s.Push(n);
                    Console.WriteLine($"s: {s}");
                }
                else
                {
                    Console.WriteLine("else: ");
                    while (!s.IsEmpty() && s.Top() < n)
                    {
                        x = s.Pop();
                        Console.Write($"s: {s}, ");
                        Console.Write($"x: {x}, ");

                        temp.Push(x);
                        Console.WriteLine($"temp: {temp}");
                    }

                    s.Push(n);
                    Console.WriteLine($"s: {s}, ");

                    while (!temp.IsEmpty())
                    {
                        x = temp.Pop();
                        Console.Write($"temp: {temp}, ");
                        Console.Write($"x: {x}, ");

                        s.Push(x);
                        Console.WriteLine($"s: {s}");
                    }
                }

                Console.WriteLine();
                n = int.Parse(Console.ReadLine());
                Console.Write($"n: {n}, ");
            }
            Console.WriteLine('\n');

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
