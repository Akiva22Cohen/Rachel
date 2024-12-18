using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class ClassCount5
    {
        public static int Temp(BinNode<int> node)
        {
            if (node == null) 
                return 0;

            int current = node.GetValue(),
                num = 0,
                l = 0, 
                r = 0;

            bool bL = node.HasLeft(),
                 bR = node.HasRight();
            if (bL) l = node.GetLeft().GetValue();
            if (bR) r = node.GetRight().GetValue();

            if (bL)
                if (bR)
                    if (current > l && current > r)
                        num = 1;
                else if (current > l)
                    num = 1;
            else if (bR)
                if (current > r)
                    num = 1;

            return num + Temp(node.GetLeft()) + Temp(node.GetRight());
        }

        public static void Run()
        {
            // בניית עץ לדוגמה
            BinNode<int> node3 = new BinNode<int>(3);
            BinNode<int> node4 = new BinNode<int>(4);
            BinNode<int> node7 = new BinNode<int>(7);
            BinNode<int> node5 = new BinNode<int>(node3, 5, node4);
            BinNode<int> node8 = new BinNode<int>(null, 8, node7);
            BinNode<int> root = new BinNode<int>(node5, 10, node8);

            // קריאה לפונקציה Temp
            int count = Temp(root);
            Console.WriteLine("Number of nodes greater than their children: " + count);
        }
    }
}
