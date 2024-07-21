using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lesson6
{
    public class Class5
    {
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

        public static void Print(BinNode<int> lst)
        {
            Console.WriteLine();
            Show(lst);
            Console.WriteLine();
            ShowBackWord(lst);
            Console.WriteLine();
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

        // פעולה חיפוש בשרשרת דו כיוונית
        public static BinNode<int> FindNode(BinNode<int> lst, int num)
        {
            BinNode<int> pos = lst;

            while (pos != null)
            {
                if (pos.GetValue() == num)
                    return pos;
                pos = pos.GetRight();
            }

            pos = lst.GetLeft();
            while (pos != null)
            {
                if (pos.GetValue() == num)
                    return pos;
                pos = pos.GetLeft();
            }

            return null;
        }

        // מחיקה חוליה משרשרת דו כיוונית
        public static BinNode<int> Delete(BinNode<int> lst, int num)
        {
            BinNode<int> pos = FindNode(lst, num);
            if (pos == null)
                // The node with the given value was not found
                return lst;

            BinNode<int> posL = pos.GetLeft();
            BinNode<int> posR = pos.GetRight();

            // If the node to be deleted is the head of the list
            if (pos == lst)
                lst = posR;


            // Update the left and right nodes to skip the node to be deleted
            if (posL != null)
                posL.SetRight(posR);

            if (posR != null)
                posR.SetLeft(posL);


            // Clean up the node to be deleted (optional)
            pos.SetLeft(null);
            pos.SetRight(null);

            return lst;
        }

        // מוחקת את כל האיברים הגדולים מהמספר המתקבל כפרמטר
        public static BinNode<int> DeleteAboveNum(BinNode<int> lst, int num)
        {
            BinNode<int> pos = lst;
            BinNode<int> next;

            // Traverse and delete nodes with values greater than num
            while (pos != null)
            {
                next = pos.GetRight(); // Store next node before deletion
                if (pos.GetValue() > num)
                    lst = Delete(lst, pos.GetValue());
                
                pos = next;
            }
            
            pos = lst.GetLeft();
            while (pos != null)
            {
                next = pos.GetLeft(); // Store next node before deletion
                if (pos.GetValue() > num)
                    lst = Delete(lst, pos.GetValue());
                
                pos = next;
            }

            return lst;
        }


        public static void RunTestQ5()
        {
            Random rnd = new Random();
            int size = rnd.Next(1, 11),
                from = rnd.Next(-100, 0),
                to = rnd.Next(101),
                num = rnd.Next(from, to + 1);

            Console.WriteLine($"size: {size}\nfrom: {from}\nto: {to}\nnum: {num}\n");
            BinNode<int> lst = GetList(size, from, to);
            Console.WriteLine(lst.ToPrint());

            lst = DeleteAboveNum(lst, num);
            Print(lst);
        }
    }
}
