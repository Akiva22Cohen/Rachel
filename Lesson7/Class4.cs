using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    public class Class4
    {
        public static Node<int> Before(Node<int> lst, Node<int> pos)
        {
            while (lst.GetNext() != pos)
                lst = lst.GetNext();

            return lst;
        }

        public static Node<int> GetLast(Node<int> lst)
        {
            while (lst.HasNext())
                lst = lst.GetNext();

            return lst;
        }

        public static int What(Node<int> lst, Node<int> p, Node<int> q)
        {
            if (p == q)
                return p.GetValue();
            else
            {
                p = p.GetNext();
                q = Before(lst, q);
                return What(lst, p, q);
            }
        }

        public static void RunQ4()
        {
            int[] arr = { 4, 2, 5, 1, 9 };
            Node<int> lst = new Node<int>(arr[arr.Length - 1]);

            for (int i = arr.Length - 2; i >= 0; i--)
                lst = new Node<int>(arr[i], lst);

            Console.WriteLine(lst.ToPrint());
            Console.WriteLine();

            Console.WriteLine(What(lst, lst, Before(lst, GetLast(lst))));
        }
    }
}
