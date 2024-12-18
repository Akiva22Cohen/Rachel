using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class ClassCount3
    {
        public static int SumLeafValues(BinNode<int> node)
        {
            if (node == null) return 0;

            if (!node.HasLeft() && !node.HasRight())
                return node.GetValue() + SumLeafValues(node.GetLeft()) + SumLeafValues(node.GetRight());

            return SumLeafValues(node.GetLeft()) + SumLeafValues(node.GetRight());
        }

        public static void Run()
        {
            // בניית עץ לדוגמה
            BinNode<int> node8 = new BinNode<int>(8);
            BinNode<int> node3 = new BinNode<int>(3);
            BinNode<int> node4 = new BinNode<int>(4);
            BinNode<int> node12 = new BinNode<int>(node3, 12, node4);
            BinNode<int> root = new BinNode<int>(node8, 5, node12);

            // קריאה לפונקציה Temp
            int sumLeaves = SumLeafValues(root);
            Console.WriteLine("Sum of leaf values in the tree: " + sumLeaves);
        }
    }
}
