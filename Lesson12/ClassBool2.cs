using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class ClassBool2
    {
        public static bool AreAllNodesFull(BinNode<int> node)
        {
            if (node == null) return true;

            if (!node.HasLeft() && node.HasRight())
                return false;
            else if (node.HasLeft() && !node.HasRight()) 
                return false;

            return AreAllNodesFull(node.GetLeft()) && AreAllNodesFull(node.GetRight());
        }

        public static void Run()
        {
            // עץ תקין
            BinNode<int> node4 = new BinNode<int>(4);
            BinNode<int> node5 = new BinNode<int>(5);
            BinNode<int> node2 = new BinNode<int>(node4, 2, node5);
            BinNode<int> node3 = new BinNode<int>(3);
            BinNode<int> root1 = new BinNode<int>(node2, 1, node3);

            // עץ לא תקין
            BinNode<int> node2Invalid = new BinNode<int>(node4, 2, null);
            BinNode<int> root2 = new BinNode<int>(node2Invalid, 1, null);

            // בדיקות AreAllNodesFull
            Console.WriteLine("All nodes are full (tree 1): " + AreAllNodesFull(root1)); // Output: true
            Console.WriteLine("All nodes are full (tree 2): " + AreAllNodesFull(root2)); // Output: false
        }
    }
}
