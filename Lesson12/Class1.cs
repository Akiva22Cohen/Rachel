using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class Class1
    {
        public static int GetHeight(BinNode<int> node)
        {
            if (node == null)
                return 0; // עץ ריק - גובהו הוא -1 (גובה של עץ עלה הוא 0)

            return 1 + Math.Max(GetHeight(node.GetLeft()), GetHeight(node.GetRight())); // הגובה הוא 1 + הגובה המקסימלי של תת-העצים
        }


        public static void Run()
        {
            // בניית העץ
            BinNode<int> node4 = new BinNode<int>(4);
            BinNode<int> node5 = new BinNode<int>(5);
            BinNode<int> node2 = new BinNode<int>(node4, 2, node5);
            BinNode<int> node3 = new BinNode<int>(3);
            BinNode<int> root = new BinNode<int>(node2, 1, node3);

            // בדיקה
            Console.WriteLine("Height of the tree: " + GetHeight(root)); // Output: 2
        }
    }
}
