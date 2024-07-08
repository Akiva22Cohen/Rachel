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
            if (lst == null)
                return null;

            Node<int> current = lst;
            Node<int> prev = null;

            // Check if the head needs to be deleted
            if (current.GetValue() == num)
            {
                // Find the last node which points to the head
                do
                {
                    prev = current;
                    current = current.GetNext();
                } while (current != lst);

                if (prev == lst)
                    // Only one node in the list
                    return null;


                // Remove the head node
                prev.SetNext(lst.GetNext());
                lst = lst.GetNext();
            }
            else
            {
                // Traverse the list to find the node to delete
                do
                {
                    prev = current;
                    current = current.GetNext();
                } while (current != lst && current.GetValue() != num);

                if (current.GetValue() == num)
                    // Remove the node
                    prev.SetNext(current.GetNext());

            }

            return lst;
        }


        public static void SelectAndRemove(Node<int> lst, int num)
        {
            Node<int> pos = lst;
            int n = num;
            while (pos != null)
            {
                for (int i = 0; i < n - 1; i++)
                    pos = pos.GetNext();

                n = pos.GetValue();
                Console.Write(n + " ");
                lst = DeleteNodeCircleChain(lst, n);
                pos = lst;
            }
            Console.WriteLine();
        }

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

            Console.WriteLine("Node:");
            Print(head);
            Console.WriteLine("Remove:");
            SelectAndRemove(head, rnd.Next(11));
        }
    }
}
