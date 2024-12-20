using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class ClassBool1
    {
        public static bool IsNonNegative(BinNode<int> node)
        {
            if (node == null) return true;

            if (node.GetValue() < 0) return false;

            return IsNonNegative(node.GetLeft()) && IsNonNegative(node.GetRight());
        }

        public static void Run()
        {
            // עץ תקין
            BinNode<int> node1 = new BinNode<int>(1);
            BinNode<int> node4 = new BinNode<int>(4);
            BinNode<int> node3 = new BinNode<int>(node1, 3, node4);
            BinNode<int> node7 = new BinNode<int>(7);
            BinNode<int> root1 = new BinNode<int>(node3, 5, node7);

            // עץ לא תקין
            BinNode<int> nodeNeg3 = new BinNode<int>(node1, -3, null);
            BinNode<int> root2 = new BinNode<int>(nodeNeg3, 5, node7);

            // בדיקות IsNonNegative
            Console.WriteLine("All non-negative (tree 1): " + IsNonNegative(root1)); // Output: true
            Console.WriteLine("All non-negative (tree 2): " + IsNonNegative(root2)); // Output: false
        }
    }
}
