using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13
{
    public class Class4
    {
        public static bool IsLeaf(BinNode<int> node)
        {
            return !node.HasLeft() && !node.HasRight();
        }

        public static bool IsBalanced (BinNode<int> node)
        {
            if (node == null || IsLeaf(node)) return true;

            int vC = node.GetValue(),
                vL = 0,
                vR = 0;

            if (node.HasLeft()) vL = node.GetLeft().GetValue();
            if (node.HasRight()) vR = node.GetRight().GetValue();

            int sum = vL + vR;

            return vC >= sum && IsBalanced (node.GetLeft()) && IsBalanced (node.GetRight());
        }

        public static void Run()
        {
            // עץ ריק
            BinNode<int> emptyTree = null;
            Console.WriteLine($"Test 1 (Empty tree): {IsBalanced (emptyTree)}"); // צפי: true

            // עץ עם צומת יחיד (עלה)
            BinNode<int> singleNode = new BinNode<int>(5);
            Console.WriteLine($"Test 2 (Single node): {IsBalanced (singleNode)}"); // צפי: true

            // עץ שבו הצומת עומד בתנאים
            BinNode<int> leftChild = new BinNode<int>(2);
            BinNode<int> rightChild = new BinNode<int>(1);
            BinNode<int> root1 = new BinNode<int>(leftChild, 4, rightChild);
            Console.WriteLine($"Test 3 (Valid tree): {IsBalanced (root1)}"); // צפי: true

            // עץ שבו הצומת אינו עומד בתנאים
            BinNode<int> invalidLeft = new BinNode<int>(3);
            BinNode<int> invalidRight = new BinNode<int>(2);
            BinNode<int> root2 = new BinNode<int>(invalidLeft, 4, invalidRight);
            Console.WriteLine($"Test 4 (Invalid tree): {IsBalanced (root2)}"); // צפי: false

            // עץ מורכב יותר שעומד בתנאים
            BinNode<int> leaf1 = new BinNode<int>(1);
            BinNode<int> leaf2 = new BinNode<int>(2);
            BinNode<int> innerNode = new BinNode<int>(leaf1, 4, leaf2);
            BinNode<int> complexTree = new BinNode<int>(innerNode, 8, new BinNode<int>(3));
            Console.WriteLine($"Test 5 (Complex valid tree): {IsBalanced (complexTree)}"); // צפי: true

            // עץ מורכב יותר שאינו עומד בתנאים
            BinNode<int> invalidTree = new BinNode<int>(new BinNode<int>(2), 3, new BinNode<int>(2));
            Console.WriteLine($"Test 6 (Complex invalid tree): {IsBalanced (invalidTree)}"); // צפי: false
        }
    }
}
