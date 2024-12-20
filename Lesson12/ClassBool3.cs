using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class ClassBool3
    {
        public static bool ContainsValue(BinNode<int> node, int x)
        {
            if (node == null) return false;

            if(node.GetValue() == x) return true;

            return ContainsValue(node.GetLeft(), x) || ContainsValue(node.GetRight(), x);
        }

        public static void Run()
        {
            // בניית העץ
            BinNode<int> node4 = new BinNode<int>(4);
            BinNode<int> node5 = new BinNode<int>(5);
            BinNode<int> node2 = new BinNode<int>(node4, 2, node5);
            BinNode<int> node3 = new BinNode<int>(3);
            BinNode<int> root = new BinNode<int>(node2, 1, node3);

            // בדיקות ContainsValue
            Console.WriteLine("Does the value 5 exist? " + ContainsValue(root, 5)); // Output: true
            Console.WriteLine("Does the value 6 exist? " + ContainsValue(root, 6)); // Output: false
            Console.WriteLine("Does the value 3 exist? " + ContainsValue(root, 3)); // Output: true
        }
    }
}
