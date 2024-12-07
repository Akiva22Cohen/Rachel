using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11
{
    public class Class3
    {
        public static Node<int> LastNode(Node<int> node)
        {
            Node<int> pos = node;

            while (pos.HasNext())
                pos = pos.GetNext();

            return pos;
        }

        public static Node<int> Delete(Node<int> lst, Node<int> pos)
        {
            if (lst == pos)
                return lst.GetNext();

            Node<int> prev = lst;

            while (prev.GetNext() != pos)
                prev = prev.GetNext();

            prev.SetNext(pos.GetNext());
            pos.SetNext(null);

            return lst;
        }


        public static Node<int> ChangeList(Node<int> list)
        {
            if (list == null)
                return list;

            Node<int> p = LastNode(list);
            int x = p.GetValue();
            p = Delete(list, p);
            return ChangeList(list);
            Node<int> q = new Node<int>(x, list);
            list = q;
            return list;
        }

        public static void Run()
        {
            // Create list: 1 -> 2 -> 3 -> 4 -> null
            Node<int> n1 = new Node<int>(1);
            Node<int> n2 = new Node<int>(2);
            Node<int> n3 = new Node<int>(3);
            Node<int> n4 = new Node<int>(4);

            n1.SetNext(n2);
            n2.SetNext(n3);
            n3.SetNext(n4);

            Console.WriteLine("Original list: " + n1.ToPrint());

            Delete(n1, n4);
            //Console.WriteLine("After deleting: " + n1.ToPrint());
            
            Delete(n1, n3);
            //Console.WriteLine("After deleting: " + n1.ToPrint());

            Delete(n1, n2);
            //Console.WriteLine("After deleting: " + n1.ToPrint());

            Delete(n1, n1);
            Console.WriteLine("After deleting: " + n1);
        }
    }
}
