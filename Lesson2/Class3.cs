using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    public class Class3
    {
        // Q3
        //static Node<int> RemoveNumFromNode(Node<int> chain, int num, string mode = "normal")
        //{
        //    // Q3.1
        //    if (mode.Equals("start"))
        //    {
        //        Node<int> pos = chain;
        //        while (pos.GetValue() == num)
        //            pos = pos.GetNext();

        //        return pos;
        //    } // Q3.2
        //    else if (mode.Equals("normal"))
        //    {
        //        Node<int> first = null;
        //        Node<int> last = null;
        //        while (chain != null)
        //        {
        //            if (chain.GetValue() != num)
        //            {
        //                if (first == null)
        //                {
        //                    first = new Node<int>(chain.GetValue());
        //                    last = first;
        //                }
        //                else
        //                {
        //                    last.SetNext(new Node<int>(chain.GetValue()));
        //                    last = last.GetNext();
        //                }
        //            }
        //            chain = chain.GetNext();
        //        }
        //        return first;
        //    }
        //    return null;
        //}

        static Node<int> RemoveNumFromNode(Node<int> chain, int num, string mode = "normal")
        {
            // Handle the case where the list is empty
            if (chain == null)
                return null;

            // Remove nodes with the value `num` from the beginning of the list
            while (chain != null && chain.GetValue() == num)
            {
                chain = chain.GetNext(); // Move the head to the next node
            }

            //Q3.1
            if (mode.Equals("start"))
                return chain;
            else if (mode.Equals("normal"))
            {
                // Now chain points to the new head of the list (if not empty)
                Node<int> prev = null;
                Node<int> curr = chain;

                while (curr != null)
                {
                    if (curr.GetValue() == num)
                    {
                        // Remove the node by skipping it
                        if (prev != null)
                            prev.SetNext(curr.GetNext());
                    }
                    else
                    {
                        prev = curr; // Update the previous node
                    }
                    curr = curr.GetNext(); // Move to the next node
                }

                return chain; // Return the updated head of the list
            }
            return null;
        }

        // בדיקה שאלה 3
        public static void TestQ3()
        {
            Node<int>[] nodes =
            {
                new Node<int>(8),// 0
                new Node<int>(8),// 1
                new Node<int>(5),// 2
                new Node<int>(8),// 3
                new Node<int>(2),// 4
                new Node<int>(8),// 5
                new Node<int>(4),// 6
                new Node<int>(3),// 7
                new Node<int>(8),// 8
            };
            // [8,8,5,8,2,8,4,3,8]

            Node<int> head = PublicStaticOperations.CreateNode(nodes);

            Console.WriteLine("Node:");
            PublicStaticOperations.PrintNode(head);
            Console.WriteLine();

            Console.WriteLine("RemoveNumFromNode(n1, 8, start):");
            PublicStaticOperations.PrintNode(RemoveNumFromNode(head, 8, "start"));
            Console.WriteLine();

            Console.WriteLine("RemoveNumFromNode(n1, 8):");
            PublicStaticOperations.PrintNode(RemoveNumFromNode(head, 8));
            Console.WriteLine();
        }
    }
}
