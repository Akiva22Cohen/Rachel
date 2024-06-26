using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    public class Class2
    {
        public static Node<Node<int>> NextZero(Node<Node<int>> lst, Node<int> p)
        {
            Node<Node<int>> pos = lst;
            // Find the node with value p
            while (pos != null && pos.GetValue() != p)
                pos = pos.GetNext();

            // Start from the next node after p
            if (pos != null)
                pos = pos.GetNext();

            while (pos != null)
            {
                if (pos.GetValue().GetValue() == 0)
                    return pos;
                pos = pos.GetNext();
            }

            return null;
        }

        public static Node<Node<int>> PrevZero(Node<Node<int>> lst, Node<int> p)
        {
            Node<Node<int>> pos = lst;
            Node<Node<int>> prevZero = null;
            while (pos.GetValue() != p)
            {
                if (pos.GetValue().GetValue() == 0)
                    prevZero = pos;
                pos = pos.GetNext();
            }

            return prevZero;
        }

        public static int CountZero(Node<Node<int>> lst)
        {
            int count = 0;
            Node<Node<int>> pos = lst;

            while (pos != null)
            {
                if (pos.GetValue().GetValue() == 0)
                    count++;
                pos = pos.GetNext();
            }

            return count;
        }

        public static void RunTestQ2()
        {

        }

    }
}
