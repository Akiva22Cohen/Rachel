using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class ClassCount6
    {
        public static int SumSingleChildren(BinNode<int> node)
        {
            if (node == null) return 0;

            int sum = 0;

            if (!node.HasLeft() && node.HasRight())
                sum = node.GetRight().GetValue();
            else if (!node.HasRight() && node.HasLeft())
                sum = node.GetLeft().GetValue();

            return sum + SumSingleChildren(node.GetLeft()) + SumSingleChildren(node.GetRight());
        }


        public static void Run()
        {
            // יצירת עץ לדוגמה
            BinNode<int> node3 = new BinNode<int>(3);
            BinNode<int> node7 = new BinNode<int>(7);
            BinNode<int> node5 = new BinNode<int>(node3, 5, null);
            BinNode<int> node8 = new BinNode<int>(null, 8, node7);
            BinNode<int> root = new BinNode<int>(node5, 10, node8);

            // בדיקת הפונקציה SumSingleChildren
            int result = SumSingleChildren(root);
            Console.WriteLine("Sum of single child nodes: " + result);
        }
    }
}
