using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13
{
    public class Class3
    {
        public static bool IsLeaf(BinNode<int> node)
        {
            return !node.HasLeft() && !node.HasRight();
        }

        public static bool CheckNode(BinNode<int> node)
        {
            if (node == null || IsLeaf(node)) return true;

            int vC = node.GetValue(),
                vL = 0,
                vR = 0;

            if (node.HasLeft()) vL = node.GetLeft().GetValue();
            if (node.HasRight()) vR = node.GetRight().GetValue();

            return vR > vL && vL > vC && CheckNode(node.GetLeft()) && CheckNode(node.GetRight());
        }

        public static void Run()
        {
            // בדיקת צומת בודד (עלה)
            BinNode<int> node1 = new BinNode<int>(5);
            Console.WriteLine($"Test 1 (Single node): {CheckNode(node1)}"); // צפי: true

            // בדיקת צומת עם שני ילדים שהם עלים ועומדים בתנאים
            BinNode<int> nodeLeft = new BinNode<int>(5);
            BinNode<int> nodeRight = new BinNode<int>(6);
            BinNode<int> root1 = new BinNode<int>(nodeLeft, 4, nodeRight);
            Console.WriteLine($"Test 2 (Two leaf children meet conditions): {CheckNode(root1)}"); // צפי: true

            // בדיקת צומת עם שני ילדים שהם עלים ולא עומדים בתנאים
            BinNode<int> nodeLeft2 = new BinNode<int>(2);
            BinNode<int> nodeRight2 = new BinNode<int>(7);
            BinNode<int> root2 = new BinNode<int>(nodeLeft2, 5, nodeRight2);
            Console.WriteLine($"Test 3 (Two leaf children don't meet conditions): {CheckNode(root2)}"); // צפי: false

            // בדיקת צומת עם ילד אחד בלבד
            BinNode<int> nodeWithOneChild = new BinNode<int>(nodeLeft, 5, null);
            Console.WriteLine($"Test 4 (One child only): {CheckNode(nodeWithOneChild)}"); // צפי: false

            // בדיקת עץ מורכב יותר
            BinNode<int> leftLeaf = new BinNode<int>(7);
            BinNode<int> rightLeaf = new BinNode<int>(3);
            BinNode<int> innerNode = new BinNode<int>(leftLeaf, 4, rightLeaf);
            BinNode<int> complexRoot = new BinNode<int>(innerNode, 5, new BinNode<int>(6));
            Console.WriteLine($"Test 5 (Complex tree): {CheckNode(complexRoot)}"); // צפי: false
        }
    }
}
