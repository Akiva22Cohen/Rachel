using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    public class Class6
    {
        public static BinNode<int> BuildBiList()
        {
            int size = int.Parse(Console.ReadLine()),
                num = int.Parse(Console.ReadLine());
            BinNode<int> newBinNode = new BinNode<int>(num);
            BinNode<int> pos = newBinNode;

            for (int i = 1; i < size; i++)
            {
                num = int.Parse(Console.ReadLine());
                pos.SetRight(new BinNode<int>(pos, num, null));
                pos = pos.GetRight();
            }

            return newBinNode;
        }
        
        public static BinNode<char> BuildBiListChar()
        {
            int size = int.Parse(Console.ReadLine());
            char ch = char.Parse(Console.ReadLine());
            BinNode<char> newBinNode = new BinNode<char>(ch);
            BinNode<char> pos = newBinNode;

            for (int i = 1; i < size; i++)
            {
                ch = char.Parse(Console.ReadLine());
                pos.SetRight(new BinNode<char>(pos, ch, null));
                pos = pos.GetRight();
            }

            return newBinNode;
        }

        public static bool IsPalindrom(BinNode<int> binNode)
        {
            if(binNode == null) return false;

            BinNode<int> first = binNode;
            BinNode<int> last = binNode;

            while (first.HasLeft())
                first = first.GetLeft();
            

            while (last.HasRight())
                last = last.GetRight();

            while (first != last)
            {
                if (first.GetValue() != last.GetValue()) 
                    return false;

                first = first.GetRight();
                last = last.GetLeft();
            }

            return true;
        }
        
        public static bool IsPalindromChar(BinNode<char> binNode)
        {
            if(binNode == null) return false;

            BinNode<char> first = binNode;
            BinNode<char> last = binNode;

            while (first.HasLeft())
                first = first.GetLeft();
            

            while (last.HasRight())
                last = last.GetRight();

            while (first != last)
            {
                if (first.GetValue() != last.GetValue()) 
                    return false;

                first = first.GetRight();
                last = last.GetLeft();
            }

            return true;
        }

        public static void RunTestQ6()
        {
            BinNode<int> lst = BuildBiList();
            Console.WriteLine(lst.ToPrint());

            Console.WriteLine("Is Palindrom: " + IsPalindrom(lst));

            Console.WriteLine();
            BinNode<char> lstChar = BuildBiListChar();
            Console.WriteLine(lstChar.ToPrint());

            Console.WriteLine("Is Palindrom: " + IsPalindromChar(lstChar));
        }
    }
}
