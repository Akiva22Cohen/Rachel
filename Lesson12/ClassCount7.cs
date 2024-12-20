using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class ClassCount7
    {
        public static bool IsLeaf(BinNode<int> node)
        {
            return !node.HasLeft() && !node.HasRight();
        }

        public static void Run()
        {
            // יצירת עץ לדוגמה
            BinNode<int> node3 = new BinNode<int>(3);
            BinNode<int> node7 = new BinNode<int>(7);
            BinNode<int> node5 = new BinNode<int>(node3, 5, null);
            BinNode<int> node8 = new BinNode<int>(null, 8, node7);
            BinNode<int> root = new BinNode<int>(node5, 10, node8);

            // בדיקות
            Console.WriteLine(IsLeaf(node3)); // true
            Console.WriteLine(IsLeaf(node5)); // false
            Console.WriteLine(IsLeaf(node8)); // false
            Console.WriteLine(IsLeaf(node7)); // true
        }
    }
}
