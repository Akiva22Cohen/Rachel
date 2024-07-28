using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    public class Class5
    {
        public static Node<int> Before(Node<int> lst, Node<int> pos)
        {
            while (lst.GetNext() != pos)
                lst = lst.GetNext();

            return lst;
        }

        public static double Check(Node<int> lst, Node<int> p, Node<int> q)
        {
            if (p == q)
                return p.GetValue();
            else
            if (p.GetNext() == q)
                return (p.GetValue() + q.GetValue()) / 2;
            else
                return Check(lst, p.GetNext(), Before(lst, q));

        }

        public static bool Sod(Node<int> lst, Node<int> p)
        {
            Console.WriteLine(p.ToPrint());
            if (p.GetNext() == null)
                return true;
            else
            {
                double res = Check(lst, p.GetNext(), Before(lst, null));
                Console.WriteLine("res: " + res);
                return (p.GetValue() > res) && Sod(lst, p.GetNext());
            }
        }

        public static void RunQ5()
        {
            int[] arr = { 17, 10, 4, 1 };
            Node<int> lst = new Node<int>(arr[arr.Length - 1]);

            for (int i = arr.Length - 2; i >= 0; i--)
                lst = new Node<int>(arr[i], lst);

            Console.WriteLine(lst.ToPrint());
            Console.WriteLine();

            Console.WriteLine(Sod(lst, lst));

            Console.WriteLine();
            int[] arr2 = { 20, 15, 10, 5, 1 };
            Node<int> lst2 = new Node<int>(arr2[arr2.Length - 1]);

            for (int i = arr2.Length - 2; i >= 0; i--)
                lst2 = new Node<int>(arr2[i], lst2);

            Console.WriteLine(lst2.ToPrint());
            Console.WriteLine();

            Console.WriteLine(Sod(lst2, lst2));


            Console.WriteLine();
            int[] arr3 = { 1, 2, 3 };
            Node<int> lst3 = new Node<int>(arr3[arr3.Length - 1]);

            for (int i = arr3.Length - 2; i >= 0; i--)
                lst3 = new Node<int>(arr3[i], lst3);

            Console.WriteLine(lst3.ToPrint());
            Console.WriteLine();

            Console.WriteLine(Sod(lst3, lst3));
        }
    }
}
