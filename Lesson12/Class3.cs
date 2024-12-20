using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class Class3
    {
        public static int GetHeight(BinNode<int> node)
        {
            if (node == null)
                return 0; // עץ ריק - גובהו הוא -1 (גובה של עץ עלה הוא 0)

            return 1 + Math.Max(GetHeight(node.GetLeft()), GetHeight(node.GetRight())); // הגובה הוא 1 + הגובה המקסימלי של תת-העצים
        }

        public static bool IsBalanced(BinNode<int> node)
        {
            if (node == null) return true;

            if (Math.Abs(GetHeight(node.GetLeft()) - GetHeight(node.GetRight())) > 1) 
                return false;

            return IsBalanced(node.GetLeft()) && IsBalanced(node.GetRight());
        }

        public static void Run()
        {
            BinNode<int> balancedTree = new BinNode<int>(
                new BinNode<int>(new BinNode<int>(1), 2, new BinNode<int>(3)),
                4,
                new BinNode<int>(null, 6, null));

            BinNode<int> unbalancedTree = new BinNode<int>(
                new BinNode<int>(new BinNode<int>(new BinNode<int>(0), 1, null), 2, null),
                4,
                new BinNode<int>(null, 6, null)
            );

            Console.WriteLine(IsBalanced(balancedTree)); // פלט: true
            Console.WriteLine(IsBalanced(unbalancedTree)); // פלט: false

        }
    }
}
