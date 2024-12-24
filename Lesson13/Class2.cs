using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13
{
    public class Class2
    {
        public static bool IsLeaf(BinNode<int> node)
        {
            return !node.HasLeft() && !node.HasRight();
        }

        public static int CountLeaves(BinNode<int> binNode)
        {
            if (IsLeaf(binNode))
                return 1;

            return CountLeaves(binNode.GetLeft()) + CountLeaves(binNode.GetRight());
        }

        public static int CountNodes<T>(BinNode<T> node)
        {
            if (node == null)
                return 0;

            // סופרים את הצומת הנוכחי + סופרים את כל הצמתים בתת-עץ שמאלי וימני
            return 1 + CountNodes(node.GetLeft()) + CountNodes(node.GetRight());
        }

        public static bool Temp(BinNode<int> node)
        {
            return CountLeaves(node) >= (CountNodes(node) / 2);
        }

        public static void Run()
        {
            // עץ עם צומת אחד בלבד
            BinNode<int> singleNodeTree = new BinNode<int>(1); // עץ פשוט עם צומת בודד
            Console.WriteLine($"Single node tree result: {Temp(singleNodeTree)}"); // ציפייה: true

            // עץ בינארי מלא בעומק 2
            BinNode<int> leftSubtree = new BinNode<int>(
                new BinNode<int>(4), // עלה שמאלי
                2,
                new BinNode<int>(5)  // עלה ימני
            );

            BinNode<int> rightSubtree = new BinNode<int>(
                new BinNode<int>(6), // עלה שמאלי
                3,
                new BinNode<int>(7)  // עלה ימני
            );

            BinNode<int> fullTree = new BinNode<int>(
                leftSubtree, // תת-עץ שמאלי
                1,           // שורש העץ
                rightSubtree  // תת-עץ ימני
            );
            Console.WriteLine($"Full tree result: {Temp(fullTree)}"); // ציפייה: true

            // עץ לא מאוזן
            BinNode<int> unbalancedTree = new BinNode<int>(
                new BinNode<int>(
                    new BinNode<int>(4), // עלה שמאלי בתת-עץ שמאלי
                    2,
                    null // אין בן ימני
                ),
                1, // שורש העץ
                new BinNode<int>(3) // תת-עץ ימני כעלה בודד
            );
            Console.WriteLine($"Unbalanced tree result: {Temp(unbalancedTree)}"); // ציפייה: false
        }
    }
}
