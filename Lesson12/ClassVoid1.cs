using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class ClassVoid1
    {
        public static void PrintLeftChildren(BinNode<int> node)
        {
            if(node == null) return;

            PrintLeftChildren(node.GetLeft());
            
            if(node.HasLeft())
                Console.WriteLine(node.GetLeft().GetValue());

            PrintLeftChildren(node.GetRight());
        }

        public static void Run()
        {
            // יצירת צמתים לעץ
            BinNode<int> node1 = new BinNode<int>(1); // צומת עלה 1
            BinNode<int> node4 = new BinNode<int>(4); // צומת עלה 4
            BinNode<int> node3 = new BinNode<int>(node1, 3, node4); // צומת 3 עם בנים 1 ו-4
            BinNode<int> node8 = new BinNode<int>(8); // צומת עלה 8
            BinNode<int> root = new BinNode<int>(node3, 5, node8); // שורש 5 עם בנים 3 ו-8

            // הדפסת מבנה העץ
            Console.WriteLine("Printing Tree Structure:");
            Console.WriteLine(root.ToString());
            Console.WriteLine(root.GetLeft().ToString());
            Console.WriteLine(root.GetRight().ToString());

            // קריאה לפונקציה Temp
            Console.WriteLine("\nCalling Temp Function:");
            PrintLeftChildren(root);
        }
    }
}
