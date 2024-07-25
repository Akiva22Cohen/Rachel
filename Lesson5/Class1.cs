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

            Node<int> prev = lst;

            // If the head node is to be deleted
            if (lst.GetValue() == num)
            {
                // Special case: if there's only one node in the list
                if (lst.GetNext() == lst)
                    return null;

                // Find the last node in the list
                while (prev.GetNext() != lst)
                    prev = prev.GetNext();

                // Update the last node to point to the new head
                prev.SetNext(lst.GetNext());
                lst.SetNext(null); // Disconnect the current head

                // Return the new head of the list
                return prev.GetNext();
            }

            // Traverse the list to find the node before the one to be deleted
            while (prev.GetNext() != lst && prev.GetNext().GetValue() != num)
                prev = prev.GetNext();

            // If the node to be deleted is found
            if (prev.GetNext().GetValue() == num)
                // Update the 'next' pointer to skip the deleted node
                prev.SetNext(prev.GetNext().GetNext());


            // Return the head of the list
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
