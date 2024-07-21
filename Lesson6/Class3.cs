using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    public class Class3
    {
        // הצגת השרשרת מימין לשמאל
        public static void ShowBackWord(BinNode<int> lst)
        {
            BinNode<int> pos = lst;
            while (pos != null && pos.HasRight())
                pos = pos.GetRight();

            Console.Write("[");
            while (pos != null)
            {
                Console.Write(pos.GetValue());
                pos = pos.GetLeft();
                Console.Write((pos != null) ? ", " : "");
            }
            Console.WriteLine("]");
        }

        public static BinNode<int> GetList(int size, int from, int to)
        {
            Random rnd = new Random();
            BinNode<int> newBinNode = new BinNode<int>(rnd.Next(from, to + 1));
            BinNode<int> pos = newBinNode;

            for (int i = 1; i < size; i++)
            {
                pos.SetRight(new BinNode<int>(pos, rnd.Next(from, to + 1), null));
                pos = pos.GetRight();
            }

            return newBinNode;
        }

        public static void RunTestQ3()
        {
            Random rnd = new Random();
            int size = rnd.Next(1, 11),
                from = rnd.Next(-100, 0),
                to = rnd.Next(101);

            Console.WriteLine($"size: {size}\nfrom: {from}\nto: {to}\n");
            BinNode<int> lst = GetList(size, from, to);
            Console.WriteLine(lst.ToPrint());

            ShowBackWord(lst);
        }
    }
}
