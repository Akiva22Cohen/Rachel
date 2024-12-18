using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class ClassCount5
    {
        public static int CountGreaterNodes(BinNode<int> node)
        {
            if (node == null) 
                return 0;

            int currentValue  = node.GetValue(),
                count  = 0,
                leftValue  = 0, 
                rightValue  = 0;

            bool bL = node.HasLeft(),
                 bR = node.HasRight();
            if (bL) leftValue  = node.GetLeft().GetValue();
            if (bR) rightValue  = node.GetRight().GetValue();

            if (bL)
            {
                if (bR)
                {
                    if (currentValue  > leftValue  && currentValue  > rightValue )
                    {
                        count  = 1;
                    }
                }
                else if (currentValue  > leftValue )
                {
                    count  = 1;
                }
            }
            else if (bR)
            {
                if (currentValue  > rightValue )
                    count  = 1;
            }

            return count  + CountGreaterNodes(node.GetLeft()) + CountGreaterNodes(node.GetRight());
        }

        public static void Run()
        {
            // בניית עץ לדוגמה
            BinNode<int> node3 = new BinNode<int>(3);
            BinNode<int> node4 = new BinNode<int>(4);
            BinNode<int> node7 = new BinNode<int>(7);
            BinNode<int> node5 = new BinNode<int>(node3, 5, node4);
            BinNode<int> node8 = new BinNode<int>(null, 8, node7);
            BinNode<int> root = new BinNode<int>(node5, 10, node8);

            // קריאה לפונקציה CountGreaterNodes
            int count = CountGreaterNodes(root);
            Console.WriteLine("count ber of nodes greater than their children: " + count);
        }
    }
}
