using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class ClassCount11
    {
        public static int SumAtDepth(BinNode<int> node, int x)
        {
            if (node == null) return 0;

            if (x <= 0)
                return node.GetValue();

            return SumAtDepth(node.GetLeft(), x - 1) + SumAtDepth(node.GetRight(), x - 1);
        }

        public static void Run()
        {
            // יצירת עץ לדוגמה
            BinNode<int> node4 = new BinNode<int>(4);
            BinNode<int> node5 = new BinNode<int>(5);
            BinNode<int> node6 = new BinNode<int>(6);
            BinNode<int> node2 = new BinNode<int>(node4, 2, node5);
            BinNode<int> node3 = new BinNode<int>(null, 3, node6);
            BinNode<int> root = new BinNode<int>(node2, 1, node3);

            // בדיקות SumAtDepth
            Console.WriteLine("Sum of values at depth 0: " + SumAtDepth(root, 0)); // Output: 1
            Console.WriteLine("Sum of values at depth 1: " + SumAtDepth(root, 1)); // Output: 5
            Console.WriteLine("Sum of values at depth 2: " + SumAtDepth(root, 2)); // Output: 15
        }
    }
}
