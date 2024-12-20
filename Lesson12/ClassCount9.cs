using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class ClassCount9
    {
        public static int CountOccurrences(BinNode<int> node, int x)
        {
            if (node == null) return 0;

            if (node.GetValue() == x) 
                return 1 + CountOccurrences(node.GetLeft(), x) + CountOccurrences(node.GetRight(), x);

            return CountOccurrences(node.GetLeft(), x) + CountOccurrences(node.GetRight(), x);
        }

        public static void Run()
        {
            // יצירת עץ לדוגמה
            BinNode<int> node2 = new BinNode<int>(2);
            BinNode<int> node5a = new BinNode<int>(5);
            BinNode<int> node3a = new BinNode<int>(node5a, 3, node2); // צומת שמחבר 5 ו-2
            BinNode<int> node3b = new BinNode<int>(3);
            BinNode<int> node5b = new BinNode<int>(null, 5, node3b);  // צומת שמחבר 3 לימין
            BinNode<int> root = new BinNode<int>(node3a, 5, node5b); // שורש שמחבר את שני הענפים

            // בדיקת CountOccurrences
            int count = CountOccurrences(root, 5);
            Console.WriteLine("Number of occurrences of 5: " + count); // Output: 3
        }
    }
}
