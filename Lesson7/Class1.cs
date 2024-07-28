using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    public class Class1
    {
        public static int Max(int a, int b) { return (a > b) ? a : b; }

        public static int Sod1(Node<int> pos)
        {
            if (pos.GetNext() == null)
                return 1;
            if (pos.GetNext().GetValue() >= pos.GetValue())
                return Sod1(pos.GetNext()) + 1;
            else
                return 1;

        }

        public static int Sod2(Node<int> p)
        {
            if (p == null)
                return 0;
            int res = Max(Sod1(p), Sod2(p.GetNext()));
            Console.WriteLine(p.ToPrint());
            Console.WriteLine("res: " + res);
            return res;
        }

        public static void RunQ1()
        {
            int[] arr = { 5, 1, 10, 11, 13, 7, 8, 12 };
            Node<int> lst = new Node<int>(arr[arr.Length - 1]);

            for (int i = arr.Length - 2; i >= 0; i--)
                lst = new Node<int>(arr[i], lst);

            Console.WriteLine(lst.ToPrint());

            Console.WriteLine();
            Console.Write("Sod1(lst) => ");
            Console.WriteLine(Sod1(lst));

            Console.WriteLine();
            Console.Write("Sod1(lst.GetNext()) => ");
            Console.WriteLine(Sod1(lst.GetNext()));

            Console.WriteLine();
            Console.Write("Sod2(lst) => ");
            Console.WriteLine(Sod2(lst));
        }
    }
}
