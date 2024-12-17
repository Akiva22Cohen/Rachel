using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class ClassCount1
    {
        public static int CountNodes<T>(BinNode<T> node)
        {
            if (node == null)
                return 0;

            // סופרים את הצומת הנוכחי + סופרים את כל הצמתים בתת-עץ שמאלי וימני
            return 1 + CountNodes(node.GetLeft()) + CountNodes(node.GetRight());
        }

        public static void Run()
        {
            // בניית עץ לדוגמה
            BinNode<char> nodeB = new BinNode<char>('B');
            BinNode<char> nodeD = new BinNode<char>('D');
            BinNode<char> nodeE = new BinNode<char>('E');
            BinNode<char> nodeC = new BinNode<char>(nodeD, 'C', nodeE);
            BinNode<char> root = new BinNode<char>(nodeB, 'A', nodeC);

            // קריאה לפונקציה CountNodes
            int count = CountNodes(root);
            Console.WriteLine("Number of nodes in the tree: " + count);
        }
    }
}
