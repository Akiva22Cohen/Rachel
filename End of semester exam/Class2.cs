using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace End_of_semester_exam
{
    public class Class2
    {
        public static void SecretMessege(Queue<char> num1, Queue<int> num2)
        {
            string str = "";
            Queue<char> t1 = new Queue<char>();
            Queue<int> t2 = new Queue<int>();

            while (!num1.IsEmpty() && !num2.IsEmpty())
            {
                for (int i = 0; i < num2.Head(); i++)
                {
                    str += num1.Head();
                    t1.Insert(num1.Remove());
                }
                str += " ";
                t2.Insert(num2.Remove());
            }
            Console.WriteLine(str);

            while (!t1.IsEmpty())
                num1.Insert(t1.Remove());

            while (!t2.IsEmpty())
                num2.Insert(t2.Remove());
        }

        public static void Run()
        {
            Queue<char> num1 = new Queue<char>();
            num1.Insert('W');
            num1.Insert('E');
            num1.Insert('A');
            num1.Insert('R');
            num1.Insert('E');
            num1.Insert('L');
            num1.Insert('A');
            num1.Insert('N');
            num1.Insert('D');
            num1.Insert('I');
            num1.Insert('N');
            num1.Insert('G');
            num1.Insert('I');
            num1.Insert('N');
            num1.Insert('T');
            num1.Insert('O');
            num1.Insert('K');
            num1.Insert('Y');
            num1.Insert('O');

            Queue<int> num2 = new Queue<int>();
            num2.Insert(2);
            num2.Insert(3);
            num2.Insert(7);
            num2.Insert(2);
            num2.Insert(5);

            Console.Write($"SecretMessege(Queue<char> {num1}, Queue<int> {num2}): ");
            SecretMessege(num1, num2);

            Console.WriteLine();
            Console.WriteLine(num1);
            Console.WriteLine(num2);
        }
    }
}
