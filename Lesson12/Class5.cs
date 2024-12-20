using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class Class5
    {
        // הפונקציה המבוצעת
        public static BinNode<int> FindNodeByValue(BinNode<int> node, int x)
        {
            if (node == null) return null;

            if (node.GetValue() == x) return node;

            // חפש בצד השמאלי והימני, אם הצומת נמצא באחד מהם, החזר אותו
            BinNode<int> leftResult = FindNodeByValue(node.GetLeft(), x);
            if (leftResult != null) return leftResult;

            return FindNodeByValue(node.GetRight(), x);
        }

        public static void Run()
        {
            // יצירת עץ לדוגמה
            BinNode<int> node1 = new BinNode<int>(1);
            BinNode<int> node2 = new BinNode<int>(2);
            BinNode<int> node3 = new BinNode<int>(3);
            BinNode<int> node4 = new BinNode<int>(4);
            BinNode<int> node5 = new BinNode<int>(5);
            BinNode<int> node6 = new BinNode<int>(6);

            // חיבור הצמתים
            node5.SetLeft(node3);
            node5.SetRight(node2);
            node3.SetLeft(node1);
            node2.SetLeft(node4);
            node2.SetRight(node6);

            // קריאה לפונקציה FindNodeByValue עם מספרים שונים
            Console.WriteLine("Testing FindNodeByValue with value 4:");
            BinNode<int> result = FindNodeByValue(node5, 4);
            if (result != null)
            {
                Console.WriteLine("Found node with value: " + result.GetValue());
                Console.WriteLine("The returned tree: " + result.ToString());
            }
            else
                Console.WriteLine("Node with value 4 not found");

            Console.WriteLine("\nTesting FindNodeByValue with value 10:");
            result = FindNodeByValue(node5, 10);
            if (result != null)
            {
                Console.WriteLine("Found node with value: " + result.GetValue());
                Console.WriteLine("The returned tree: " + result.ToString());
            }
            else
                Console.WriteLine("Node with value 10 not found");
        }
    }
}
