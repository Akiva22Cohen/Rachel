using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    public class Class3
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

        public static void PrintAllOptions(Node<int> l)
        {
            if (l == null)
                return;

            Node<int> start = l;
            Node<int> current;

            do
            {
                current = start;
                do
                {
                    Console.Write(current.GetValue() + " ");
                    current = current.GetNext();
                } while (current != start);
                Console.WriteLine();
                start = start.GetNext();
            } while (start != l);
        }


        public static void RunTestQ3()
        {
            Random rnd = new Random();

            Node<int>[] nodes = new Node<int>[rnd.Next(2, 6)];
            for (int i = 0; i < nodes.Length; i++)
                nodes[i] = new Node<int>(rnd.Next(10));

            for (int i = 0; i < nodes.Length - 1; i++)
                nodes[i].SetNext(nodes[i + 1]);
            nodes[nodes.Length - 1].SetNext(nodes[0]);

            Node<int> head = nodes[0];

            Console.WriteLine("Node:");
            Print(head);
            Console.WriteLine("Print all options:");
            PrintAllOptions(head);
        }
    }
}
