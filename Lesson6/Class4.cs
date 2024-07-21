using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    public class Class4
    {
        // מחזירה הפניה לחוליה הראשונה בשרשרת דו כיוונית
        public static BinNode<int> GetFirst(BinNode<int> lst)
        {
            while (lst != null && lst.HasLeft())
                lst = lst.GetLeft();

            return lst;
        }

        // מחזירה הפניה לחוליה האמצעית בשרשרת דו כיוונית
        public static BinNode<int> GetMiddle(BinNode<int> lst)
        {
            if (lst == null) return null;

            BinNode<int> slow = lst;
            BinNode<int> fast = lst;

            while (fast != null && fast.HasRight())
            {
                slow = slow.GetRight();
                fast = fast.GetRight().GetRight();
            }

            return slow;
        }

        // מחזירה הפניה לחוליה האחרונה בשרשרת דו כיוונית
        public static BinNode<int> GetLast(BinNode<int> lst)
        {
            while (lst != null && lst.HasRight())
                lst = lst.GetRight();

            return lst;
        }

        // הצגת השרשרת משמאל לימין
        public static void Show(BinNode<int> lst)
        {
            BinNode<int> pos = lst;
            while (pos != null && pos.HasLeft())
                pos = pos.GetLeft();

            Console.Write("[");
            while (pos != null)
            {
                Console.Write(pos.GetValue());
                pos = pos.GetRight();
                Console.Write((pos != null) ? ", " : "");
            }
            Console.WriteLine("]");
        }

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

        // הוספת חוליה לשרשרת דו כיוונית
        public static void Add(BinNode<int> posL, BinNode<int> posR, int num)
        {
            if (posL == null)
                posR.SetLeft(new BinNode<int>(null, num, posR));
            else if (posR == null)
                posL.SetRight(new BinNode<int>(posL, num, null));
            else
            {
                posL.SetRight(new BinNode<int>(posL, num, posR));
                posR.SetLeft(posL.GetRight());
            }
        }



        public static void Print(BinNode<int> lst)
        {
            Console.WriteLine();
            Show(lst);
            Console.WriteLine();
            ShowBackWord(lst);
            Console.WriteLine();
        }

        public static void RunTestQ4()
        {
            Random rnd = new Random();
            int size = rnd.Next(5, 11),
                from = rnd.Next(-100, 0),
                to = rnd.Next(101);

            Console.WriteLine($"size: {size}\nfrom: {from}\nto: {to}\n");
            BinNode<int> lst = GetList(size, from, to);
            Console.WriteLine(lst.ToPrint());

            Print(lst);

            // הכנסה איבר לתחילת הרשימה
            int num = rnd.Next(101);
            Console.WriteLine("num: " + num);
            BinNode<int> first = GetFirst(lst);
            Add(first.GetLeft(), first, num);
            Print(first);

            // הכנסת איבר לסוף רשימה
            num = rnd.Next(101);
            Console.WriteLine("num: " + num);
            BinNode<int> last = GetLast(lst);
            Add(last, last.GetRight(), num);
            Print(last);

            // הכנסת איבר לאמצע רשימה
            num = rnd.Next(101);
            Console.WriteLine("num: " + num);
            BinNode<int> middle = GetMiddle(lst);
            Add(middle.GetLeft(), middle, num);
            Print(middle);

        }       
    }
}
