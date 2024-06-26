using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    public class Class3
    {
        public static Node<int> FindLastNodeNext(Node<int> head)
        {
            if (head == null)
                return null;

            Node<int> slow = head;
            Node<int> fast = head;

            // Detect cycle using Floyd's Tortoise and Hare algorithm
            do
            {
                if (fast == null || fast.GetNext() == null)
                    return null; // No cycle
                slow = slow.GetNext();
                fast = fast.GetNext().GetNext();
            } while (slow != fast);

            // Find the start of the cycle
            slow = head;
            while (slow != fast)
            {
                slow = slow.GetNext();
                fast = fast.GetNext();
            }

            // Find the node to which the last node points
            Node<int> lastNode = slow;
            while (lastNode.GetNext() != slow)
            {
                lastNode = lastNode.GetNext();
            }
            return slow;
        }

        public static void RunTestQ3()
        {
            Random rnd = new Random();
            Node<int>[] nodes =
            {
                new Node<int>(rnd.Next(101)),
                new Node<int>(rnd.Next(101)),
                new Node<int>(rnd.Next(101)),
                new Node<int>(rnd.Next(101)),
                new Node<int>(rnd.Next(101))
            };
            for (int i = 0; i < nodes.Length - 1; i++)
                nodes[i].SetNext(nodes[i + 1]);

            Node<int> head = nodes[0];
            Node<int> last = nodes[nodes.Length - 1];
            Node<int> n = nodes[rnd.Next(nodes.Length - 1)];

            Console.WriteLine("head.ToPrint():");
            Console.WriteLine(head.ToPrint());
            Console.WriteLine();
            
            last.SetNext(n);

            Console.WriteLine("last.GetNext().GetValue(): " + last.GetNext().GetValue());
            Console.WriteLine("n.GetValue(): " + n.GetValue());
            Console.WriteLine("last.GetNext() == n: " + (last.GetNext() == n));
            Console.WriteLine();
            
            Console.WriteLine(FindLastNodeNext(head).GetValue());
        }
    }
}
