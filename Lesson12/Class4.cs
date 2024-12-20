using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class Class4
    {
        // פונקציה להדפסת העץ
        public static void PrintTree(BinNode<int> node)
        {
            if (node == null) return;
            Console.WriteLine(node.GetValue());
            PrintTree(node.GetLeft());
            PrintTree(node.GetRight());
        }

        public static void CopyMissingChild(BinNode<int> node)
        {
            if (node == null) return;

            if (node.HasLeft() && !node.HasRight())
                node.SetRight(new BinNode<int>(node.GetLeft().GetValue()));
            else if (!node.HasLeft() && node.HasRight())
                node.SetLeft(new BinNode<int>(node.GetRight().GetValue()));
            
            CopyMissingChild(node.GetLeft());
            CopyMissingChild(node.GetRight());
        }

        public static void Run()
        {
            // יצירת העץ לדוגמה
            BinNode<int> root = new BinNode<int>(5);
            BinNode<int> node1 = new BinNode<int>(3);
            BinNode<int> node2 = new BinNode<int>(1);

            root.SetLeft(node1);
            node1.SetLeft(node2);

            // הדפסת העץ לפני הקריאה לפונקציה
            PrintTree(root); // פלט: 5 -> 3 -> 1

            // קריאה לפונקציה CopyMissingChild
            CopyMissingChild(root);

            Console.WriteLine();
            // הדפסת העץ אחרי הקריאה לפונקציה
            PrintTree(root); // פלט: 5 -> 3 -> 3
        }
    }
}
