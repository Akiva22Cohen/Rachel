using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace End_of_semester_exam
{
    public class Class4
    {
        public static int CountStack(Stack<int> stack)
        {
            Stack<int> temp = new Stack<int>();
            int count = 0;

            while (!stack.IsEmpty())
            {
                count++;
                temp.Push(stack.Pop());
            }

            while (!temp.IsEmpty())
                stack.Push(temp.Pop());

            return count;
        }

        public static void Temp(Stack<int> s1, Stack<int> s2)
        {
            int countS1 = CountStack(s1);
            int countS2 = CountStack(s2);

            Stack<int> tempS1 = new Stack<int>();
            Stack<int> tempS2 = new Stack<int>();


            if (countS2 % 2 == 0)
            {
                for (int i = 0; !s2.IsEmpty(); i++)
                {
                    if (i >= countS2 / 2 && !s1.IsEmpty())
                    {
                        while (!s1.IsEmpty())
                        {
                            tempS1.Push(s1.Top());
                            tempS2.Push(s1.Pop());
                        }
                    }
                    tempS2.Push(s2.Pop());
                }
            }
            else if (countS1 % 2 == 0)
            {
                for (int i = 0; !s1.IsEmpty(); i++)
                {
                    if (i >= countS1 / 2 && !s2.IsEmpty())
                    {
                        while (!s2.IsEmpty())
                        {
                            tempS2.Push(s2.Top());
                            tempS1.Push(s2.Pop());
                        }
                    }
                    tempS1.Push(s1.Pop());
                }
            }

            while (!tempS1.IsEmpty())
                s1.Push(tempS1.Pop());

            while (!tempS2.IsEmpty())
                s2.Push(tempS2.Pop());
        }

        public static void Run()
        {
            Random rnd = new Random();

            int len = rnd.Next(2, 7);
            Stack<int> s1 = new Stack<int>();
            for (int i = 0; i < len; i++)
                s1.Push(rnd.Next(10));

            len = rnd.Next(2, 7);
            Stack<int> s2 = new Stack<int>();
            for (int i = 0; i < len; i++)
                s2.Push(rnd.Next(10));

            Console.WriteLine($"Temp(Stack<int> {s1}, Stack<int> {s2}):");
            Temp(s1, s2);

            Console.WriteLine("s1: " + s1);
            Console.WriteLine("s2: " + s2);
        }
    }
}
