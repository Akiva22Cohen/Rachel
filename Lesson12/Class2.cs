using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class Class2
    {
        public static int FindMaxValue(BinNode<int> node)
        {
            if (node == null)
                return 0; // אם העץ ריק, נחזיר 0 כברירת מחדל

            // אם אין תתי-עצים, נחזיר את הערך של הצומת הנוכחי
            if (!node.HasLeft() && !node.HasRight())
                return node.GetValue();

            // נחזיר את המקסימום בין הצומת הנוכחי, תת-עץ שמאלי ותת-עץ ימני
            return Math.Max(node.GetValue(), Math.Max(FindMaxValue(node.GetLeft()), FindMaxValue(node.GetRight())));
        }


        public static void Run()
        {
            // בניית עץ לדוגמה
            BinNode<int> node2 = new BinNode<int>(-2);
            BinNode<int> node5 = new BinNode<int>(-5);
            BinNode<int> node3 = new BinNode<int>(node2, -3, node5);
            BinNode<int> node10 = new BinNode<int>(-10);
            BinNode<int> root = new BinNode<int>(node3, -7, node10);

            // בדיקה
            Console.WriteLine(FindMaxValue(root)); // 10
            Console.WriteLine(FindMaxValue(node3)); // 5
            Console.WriteLine(FindMaxValue(null)); // 0
        }
    }
}
