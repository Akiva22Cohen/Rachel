using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13
{
    public class Class5
    {
        public static bool IsSymmetric(BinNode<int> root)
        {
            if (root == null) return true; // עץ ריק נחשב סימטרי
            return IsMirror(root.GetLeft(), root.GetRight());
        }

        private static bool IsMirror(BinNode<int> left, BinNode<int> right)
        {
            if (left == null && right == null) return true; // שני ענפים ריקים הם מראה
            if (left == null || right == null) return false; // רק צד אחד ריק, אינו מראה

            // הערכים חייבים להיות שווים וגם המבנה של התת-עץ השמאלי ושל התת-עץ הימני צריכים להיות מראה
            return left.GetValue() == right.GetValue() &&
                   IsMirror(left.GetLeft(), right.GetRight()) &&
                   IsMirror(left.GetRight(), right.GetLeft());
        }


        public static void Run()
        {
            // עץ ריק
            BinNode<int> emptyTree = null;
            Console.WriteLine($"Test 1 (Empty tree): {IsSymmetric(emptyTree)}"); // צפי: true

            // עץ עם צומת יחיד
            BinNode<int> singleNode = new BinNode<int>(1);
            Console.WriteLine($"Test 2 (Single node): {IsSymmetric(singleNode)}"); // צפי: true

            // עץ סימטרי
            BinNode<int> symmetricTree = new BinNode<int>(
                new BinNode<int>(new BinNode<int>(1), 2, new BinNode<int>(4)),
                3,
                new BinNode<int>(new BinNode<int>(4), 2, new BinNode<int>(1))
            );
            Console.WriteLine($"Test 3 (Symmetric tree): {IsSymmetric(symmetricTree)}"); // צפי: true

            // עץ לא סימטרי
            BinNode<int> asymmetricTree = new BinNode<int>(
                new BinNode<int>(new BinNode<int>(1), 2, null),
                3,
                new BinNode<int>(new BinNode<int>(4), 2, new BinNode<int>(1))
            );
            Console.WriteLine($"Test 4 (Asymmetric tree): {IsSymmetric(asymmetricTree)}"); // צפי: false
        }
    }
}
