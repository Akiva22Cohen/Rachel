using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class ClassVoid3
    {
        public static void SetChildValues(BinNode<char> node)
        {
            if(node == null) return;

            if (node.HasLeft())
                node.GetLeft().SetValue((char)(node.GetValue() + 1));
            if (node.HasRight())
                node.GetRight().SetValue((char)(node.GetValue() + 1));

            SetChildValues(node.GetLeft());
            SetChildValues(node.GetRight());
        }

        public static void PrintTree(BinNode<char> node)
        {
            if (node == null) return;

            Console.WriteLine(node.GetValue());
            PrintTree(node.GetLeft());
            PrintTree(node.GetRight());
        }

        public static void Run()
        {
            // בניית העץ
            BinNode<char> nodeB = new BinNode<char>('B');
            BinNode<char> nodeD = new BinNode<char>('D');
            BinNode<char> nodeE = new BinNode<char>('E');
            BinNode<char> nodeC = new BinNode<char>(nodeD, 'C', nodeE);
            BinNode<char> root = new BinNode<char>(nodeB, 'A', nodeC);

            // לפני השינויים
            Console.WriteLine("Tree Before:");
            PrintTree(root);

            // קריאה לפונקציה Temp
            SetChildValues(root);

            // אחרי השינויים
            Console.WriteLine("\nTree After:");
            PrintTree(root);
        }
    }
}
