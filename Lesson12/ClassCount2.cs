﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class ClassCount2
    {
        public static int SumEvenValues(BinNode<int> node)
        {
            if (node == null) return 0;

            if (node.GetValue() % 2 == 0) 
                return node.GetValue() + SumEvenValues(node.GetLeft()) + SumEvenValues(node.GetRight());

            return SumEvenValues(node.GetLeft()) + SumEvenValues(node.GetRight());
        }

        public static void Run()
        {
            // בניית עץ לדוגמה
            BinNode<int> node8 = new BinNode<int>(8);
            BinNode<int> node3 = new BinNode<int>(3);
            BinNode<int> node4 = new BinNode<int>(4);
            BinNode<int> node12 = new BinNode<int>(node3, 12, node4);
            BinNode<int> root = new BinNode<int>(node8, 5, node12);

            // קריאה לפונקציה Temp
            int sumEven = SumEvenValues(root);
            Console.WriteLine("Sum of even values in the tree: " + sumEven);
        }
    }
}
