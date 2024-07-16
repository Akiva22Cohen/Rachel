using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    public class Class7
    {
        public static BinNode<int> BuildSorted(int size, int from, int to)
        {
            Random rnd = new Random();
            int num = rnd.Next(from, to + 1);
            BinNode<int> newBinNode = new BinNode<int>(num);

            BinNode<int> posL = newBinNode;
            BinNode<int> posR = newBinNode;
            BinNode<int> posM;

            for (int i = 1; i < size; i++)
            {
                num = rnd.Next(from, to + 1);

                if (num >= posR.GetValue())
                {
                    posR.SetRight(new BinNode<int>(posR, num, null));
                    posR = posR.GetRight();
                }
                else if (num <= posL.GetValue())
                {
                    posL.SetLeft(new BinNode<int>(null, num, posL));
                    posL = posL.GetLeft();
                }
                else
                {
                    posM = posL;
                    while (posM.GetValue() < num)
                        posM = posM.GetRight();
                    BinNode<int> temp = new BinNode<int>(posM.GetLeft(), num, posM);
                    posM.SetLeft(temp);
                    temp.GetLeft().SetRight(temp);
                }
            }

            return posL;
        }

        public static void Print(BinNode<int> binNode)
        {
            if (binNode == null) return;

            BinNode<int> first = binNode;
            BinNode<int> last = binNode;

            while (first.HasLeft())
                first = first.GetLeft();


            while (last.HasRight())
                last = last.GetRight();

            Console.Write("[");
            while (first != null)
            {
                Console.Write(first.GetValue());
                first = first.GetRight();
                if (first != null)
                    Console.Write(", ");
            }
            Console.WriteLine("]");

            Console.WriteLine();

            Console.Write("[");
            while (last != null)
            {
                Console.Write(last.GetValue());
                last = last.GetLeft();
                if (last != null)
                    Console.Write(", ");
            }
            Console.WriteLine("]");
        }

        public static void RunTestQ7()
        {
            Random rnd = new Random();
            int size = rnd.Next(5, 11),
                from = 1,
                to = 30;

            Console.WriteLine($"size: {size}\nfrom: {from}\nto: {to}\n");
            BinNode<int> lst = BuildSorted(size, from, to);
            Console.WriteLine(lst.ToPrint());

            Print(lst);
        }
    }
}


/*

public static BinNode<int> BuildSorted(int size, int from, int to)
        {
            Random rnd = new Random();
            int num = rnd.Next(from, to + 1);
            BinNode<int> newBinNode = new BinNode<int>(num);

            BinNode<int> posL = newBinNode;
            BinNode<int> posR = newBinNode;
            BinNode<int> posM;

            Console.WriteLine($"num: {num}");
            Console.WriteLine();
            for (int i = 1; i < size; i++)
            {
                num = rnd.Next(from, to + 1);
                Console.WriteLine($"num: {num}");
                Console.WriteLine($"posR.GetValue(): {posR.GetValue()}");
                Console.WriteLine($"posL.GetValue(): {posL.GetValue()}");
                if (num >= posR.GetValue())
                {
                    posR.SetRight(new BinNode<int>(posR, num, null));
                    posR = posR.GetRight();
                }
                else if (num <= posL.GetValue())
                {
                    posL.SetLeft(new BinNode<int>(null, num, posL));
                    posL = posL.GetLeft();
                }
                else
                {
                    posM = posL;
                    while (posM.GetValue() < num)
                        posM = posM.GetRight();
                    Console.WriteLine($"posM.GetValue(): {posM.GetValue()}");
                    posM.SetLeft(new BinNode<int>(posM.GetLeft(), num, posM));
                }
                Console.WriteLine();
            }

            return posL;
        }

*/
