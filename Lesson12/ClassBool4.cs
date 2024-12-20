using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class ClassBool4
    {
        public static bool ContainsValue(BinNode<int> node, int x)
        {
            if (node == null) return false;

            if (node.GetValue() == x) return true;

            return ContainsValue(node.GetLeft(), x) || ContainsValue(node.GetRight(), x);
        }

        public static bool SubtreeContainsValue(BinNode<int> node, int x, int y)
        {
            if (node == null) return false;

            if (node.GetValue() == y)
                return ContainsValue(node, x);
            
            return SubtreeContainsValue(node.GetLeft(), x, y) || SubtreeContainsValue(node.GetRight(), x, y);
        }

        public static void Run()
        {
            // בניית עץ לדוגמה
            BinNode<int> node2 = new BinNode<int>(2);
            BinNode<int> node4 = new BinNode<int>(4);
            BinNode<int> node3 = new BinNode<int>(node2, 3, node4);
            BinNode<int> node8 = new BinNode<int>(8);
            BinNode<int> root = new BinNode<int>(node3, 5, node8);

            // בדיקה
            Console.WriteLine(SubtreeContainsValue(root, 4, 3)); // True: הערך 3 קיים, ותת-העץ שלו מכיל את 4
            Console.WriteLine(SubtreeContainsValue(root, 2, 8)); // False: הערך 8 קיים, אבל תת-העץ שלו לא מכיל את 2
            Console.WriteLine(SubtreeContainsValue(root, 5, 4)); // False: הערך 4 קיים, אבל תת-העץ שלו לא מכיל את 5
            Console.WriteLine(SubtreeContainsValue(root, 3, 5)); // True: הערך 5 קיים, ותת-העץ שלו מכיל את 3
        }
    }
}
