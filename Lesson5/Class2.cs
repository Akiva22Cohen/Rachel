using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    public class Class2
    {
        public static void Print(Node<int> lst)
        {
            Node<int> pos = lst;

            while (pos.GetNext() != lst)
            {
                Console.Write(pos.GetValue() + " ");
                pos = pos.GetNext();
            }
            Console.WriteLine(pos.GetValue() + " ");
        }

        public static void CircularToLineVonversion(Node<int> head)
        {
            Node<int> pos = head;

            while (pos.GetNext() != head)
                pos = pos.GetNext();

            pos.SetNext(null);
            pos = head;

            while (pos != null)
            {
                Console.Write(pos.GetValue() + ", ");
                pos = pos.GetNext();
            }
            Console.WriteLine("null");
        }

        public static void RunTestQ2()
        {
            Random rnd = new Random();

            Node<int>[] nodes = new Node<int>[rnd.Next(2, 11)];
            for (int i = 0; i < nodes.Length; i++)
                nodes[i] = new Node<int>(rnd.Next(11));

            for (int i = 0; i < nodes.Length - 1; i++)
                nodes[i].SetNext(nodes[i + 1]);
            nodes[nodes.Length - 1].SetNext(nodes[0]);

            Node<int> head = nodes[0];

            Console.WriteLine("Node:");
            Print(head);
            Console.WriteLine("circular to line conversion:");
            CircularToLineVonversion(head);
        }
    }
}
