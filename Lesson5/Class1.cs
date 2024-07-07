using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    public class Class1
    {
        // מחיקת חוליות בשרשרת מעגלית
        public static Node<int> DeleteNodeCircleChain(Node<int> lst, int num)
        {
            Node<int> prev = lst;

            if (lst.GetValue() == num)
            {
                while (prev.GetNext() != lst)
                    prev = prev.GetNext();

                prev.SetNext(lst.GetNext());
                lst.SetNext(null);
                lst = prev;
            }
            else
            {
                while (prev.GetNext().GetValue() != num)
                    prev = prev.GetNext();

                prev.SetNext(prev.GetNext().GetNext());
            }

            return lst;
        }

        public static void SelectAndRemove(Node<int> lst, int num)
        {
            Node<int> pos = lst;
            int i = 0, n;

            while (pos != null)
            {
                while (i <= num)
                {
                    pos = pos.GetNext();
                    i++;
                }
                n = pos.GetValue();
                Console.WriteLine(n + " ");
                lst = DeleteNodeCircleChain(lst, n);
                pos = lst;
                i = 0;
            }
        }

        public static void Print(Node<int> lst)
        {
            Node<int> pos = lst;

            while (pos.GetNext() != lst)
            {
                Console.Write(pos.GetValue() + " ");
                pos = pos.GetNext();
            }
        }

        public static void RunTestQ1()
        {
            Random rnd = new Random();

            Node<int>[] nodes = new Node<int>[rnd.Next(2, 11)];
            for (int i = 0; i < nodes.Length; i++)
                nodes[i] = new Node<int>(rnd.Next(11));

            for (int i = 0; i < nodes.Length - 1; i++)
                nodes[i].SetNext(nodes[i + 1]);
            nodes[nodes.Length - 1].SetNext(nodes[0]);

            Node<int> head = nodes[0];

            Print(head);
            SelectAndRemove(head, rnd.Next(11));
        }
    }
}
