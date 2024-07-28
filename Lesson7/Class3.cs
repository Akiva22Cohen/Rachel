using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    public class Class3
    {
        public static int Sod1(Node<int> lst, Node<int> p, Node<int> q)
        {
            if (p == q)
                return 0;
            else
            if (q.GetValue() > 0)
                return Sod1(lst, p, q.GetNext()) + 1;

            return Sod1(lst, p, q.GetNext());
        }

        //public static bool sod2(Node<int> lst, Node<int> p)
        //{
        //    if (p == null)
        //        return true;
        //    else
        //    {
        //        int x = p.GetValue();
        //        return sod2(lst, p.GetNext()) && (Sod1(p, lst) <= x));
        //    }
        //}

        public static Node<int> FindNode(Node<int> n, int num)
        {
            while (n != null)
            {
                if (n.GetValue() == num) return n;
                n = n.GetNext();
            }

            return null;
        }

        public static void RunQ3()
        {
            int[] arr = { 31, -9, 13, 1, -2, 5 };
            Node<int> lst = new Node<int>(arr[arr.Length - 1]);

            for (int i = arr.Length - 2; i >= 0; i--)
                lst = new Node<int>(arr[i], lst);

            Console.WriteLine(lst.ToPrint());
            Console.WriteLine();

            Node<int> p = FindNode(lst, -2);
            Console.WriteLine(p.ToPrint());

            Console.WriteLine(Sod1(lst, p, lst));
        }
    }
}
