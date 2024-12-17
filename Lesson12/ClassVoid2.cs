using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class ClassVoid2
    {
        public static int UpdateNodeValues(BinNode<int> node)
        {
            if (node == null)
                return 0;

            // אם הצומת הוא עלה, נחזיר את ערכו (לא מעדכנים אותו)
            if (!node.HasLeft() && !node.HasRight())
                return node.GetValue();

            // קריאה רקורסיבית לחישוב הסכום של הבנים השמאלי והימני
            int leftSum = UpdateNodeValues(node.GetLeft());
            int rightSum = UpdateNodeValues(node.GetRight());

            // עדכון ערך האב לסכום של הבנים
            node.SetValue(leftSum + rightSum);

            // החזרת הערך החדש של הצומת למעלה ברקורסיה
            return node.GetValue();
        }

        // הדפסת העץ בצורה רקורסיבית
        public static void PrintTree(BinNode<int> node)
        {
            if (node == null)
                return;

            Console.WriteLine(node.GetValue());
            PrintTree(node.GetLeft());
            PrintTree(node.GetRight());
        }

        public static void Run()
        {
            // בניית העץ
            BinNode<int> node1 = new BinNode<int>(1);
            BinNode<int> node4 = new BinNode<int>(4);
            BinNode<int> node3 = new BinNode<int>(node1, 3, node4);
            BinNode<int> node8 = new BinNode<int>(8);
            BinNode<int> root = new BinNode<int>(node3, 5, node8);

            // עדכון ערכי הצמתים
            UpdateNodeValues(root);

            // הדפסת מבנה העץ לאחר העדכון
            PrintTree(root);
        }        
    }
}
