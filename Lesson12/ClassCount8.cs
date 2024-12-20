using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class ClassCount8
    {
        public static bool IsLeaf(BinNode<int> node)
        {
            return !node.HasLeft() && !node.HasRight();
        }

        public static int CountLeaves(BinNode<int> binNode)
        {
            if (binNode == null) return 0;

            if (IsLeaf(binNode))
                return 1 + CountLeaves(binNode.GetLeft()) + CountLeaves(binNode.GetRight());

            return CountLeaves(binNode.GetLeft()) + CountLeaves(binNode.GetRight());
        }

        public static void Run()
        {
            // יצירת עץ לדוגמה
            BinNode<int> node3 = new BinNode<int>(3);
            BinNode<int> node4 = new BinNode<int>(4);
            BinNode<int> node7 = new BinNode<int>(7);
            BinNode<int> node5 = new BinNode<int>(node3, 5, node4);
            BinNode<int> node8 = new BinNode<int>(null, 8, node7);
            BinNode<int> root = new BinNode<int>(node5, 10, node8);

            // בדיקה של CountLeaves
            int leafCount = CountLeaves(root);
            Console.WriteLine("Number of leaves: " + leafCount); // Output: 3
        }
    }
}
