using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    public class Class2
    {
        public static int Sod(int num)
        {
            if (num < 10)
                return num;
            else
            {
                int temp = Sod(num / 10);
                int digit = num % 10;
                if (digit < temp)
                    return digit;
                else
                    return temp;

            }
        }

        public static bool Check(Node<int> p, int m)
        {
            if (p.GetNext() == null)
            {
                int x = p.GetValue();
                if (Sod(x) == m)
                    return true;
                else
                    return false;

            }
            else
            {
                int x = p.GetValue();
                if (Sod(x) == m)
                    return Check(p.GetNext(), m);
                else
                    return false;

            }
        }

        public static void RunQ2()
        {
            Console.WriteLine("Sod(789): " + Sod(789));
            Console.WriteLine("Sod(591): " + Sod(591));

            int[] arr = { 324, 52, 248, 5324, 32985 };
            Node<int> lst = new Node<int>(arr[arr.Length - 1]);

            for (int i = arr.Length - 2; i >= 0; i--)
                lst = new Node<int>(arr[i], lst);

            Console.WriteLine();
            Console.WriteLine(lst.ToPrint());
            Console.WriteLine();

            Console.WriteLine("Check(lst, 2): " + Check(lst, 2));
        }

    }
}
