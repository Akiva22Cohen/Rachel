using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    /* 
            תוכן עניינים:
        - הדפסת שרשרות
        - סריקת שרשרת - סכום ערכים
        - סריקת שרשרת - מספר חוליות
        - סריקת שרשרת - חיפוש ערך
        - סריקת שרשרת – חיפוש חוליה
        - הוספה כחוליה ראשונה
        - פעולה המחזירה הפניה לחוליה האחרונה
        - הוספה כחוליה אחרונה
        - מחזירה שרשרת חדשה המכילה רק את הערכים הזוגיים בשרשרת המקורית
        - מציאת החוליה שלפניה
        - פעולת מחיקה חוליה
        - צמצום
        - שרשרת ממויינת – בדיקה (int)
        - שרשרת ממויינת – בדיקה (char)
        - שרשרת ממויינת – בדיקה (strhng)
        - שרשרת ממויינת – סידרה
        - מיון שרשרת חוליות
        - מיון שרשרת חוליות – מיון הכנסה
        - להפוך שרשרת חוליות רגילה למעגלית
        - פעולת הסריקה - ספירת חוליות מעגלית
        - שרשרת חוליות מעגלית – הבדיקה
        - פעולה שמקבלת שרשרת מעגלית ומוסיפה בין כל שתי חוליות חוליה חדשה שערכה כסכום שכנותיה
        - הוספה לתחילת השרשרת המעגלית
        - מחיקת חוליות בשרשרת מעגלית
        - מיזוג רשימות
    */

    public class Universal_methods
    {
        // הדפסת שרשרות
        public static void PrintNode(Node<int> lst)
        {
            if (lst == null)
            {
                Console.WriteLine("The Node is empty!");
                return;
            }
            Node<int> pos = lst;

            while (pos.HasNext())
            {
                Console.Write(pos.GetValue() + " --> ");
                pos = pos.GetNext();
            }
            Console.Write(pos.GetValue());
            Console.WriteLine();
        }


        // סריקת שרשרת - סכום ערכים
        public static int SumValue(Node<int> a)
        {
            int sum = 0;

            while (a != null)
            {
                sum += a.GetValue();
                a = a.GetNext();
            }

            return sum;
        }


        // סריקת שרשרת - מספר חוליות
        public static int CountNode(Node<int> a)
        {
            int count = 0;

            while (a != null)
            {
                count++;
                a = a.GetNext();
            }

            return count;
        }


        // סריקת שרשרת - חיפוש ערך
        public static bool FindNum(Node<int> n, int num)
        {
            while (n != null)
            {
                if (n.GetValue() == num) return true;
                n = n.GetNext();
            }

            return false;
        }


        // סריקת שרשרת – חיפוש חוליה
        public static Node<int> FindNode(Node<int> n, int num)
        {
            while (n != null)
            {
                if (n.GetValue() == num) return n;
                n = n.GetNext();
            }

            return null;
        }


        // הוספה כחוליה ראשונה
        public static Node<int> Add(Node<int> lst, int num)
        {
            if (lst == null)
                lst = new Node<int>(num);
            else
                lst = new Node<int>(num, lst);

            return lst;
        }


        // פעולה המחזירה הפניה לחוליה האחרונה
        public static Node<int> GetLast(Node<int> lst)
        {
            while (lst.HasNext())
                lst = lst.GetNext();

            return lst;
        }


        // הוספה כחוליה אחרונה
        public static Node<int> AddLast(Node<int> lst, int num)
        {
            Node<int> after = GetLast(lst);
            after.SetNext(new Node<int>(num));
            return after;
        }


        // מחזירה שרשרת חדשה המכילה רק את הערכים הזוגיים בשרשרת המקורית
        public static Node<int> NewZugi(Node<int> chain)
        {
            Node<int> first = null; // הפניות לשרשרת החדשה
            Node<int> last = null;

            while (chain != null) // לולאה לסריקת השרשרת המקורית
            {
                if (chain.GetValue() % 2 == 0) // תנאי לביצוע ההוספה
                {
                    if (first == null) // אם השרשרת ריקה
                    {
                        first = new Node<int>(chain.GetValue());
                        last = first;
                    }
                    else // אם השרשרת לא ריקה
                    {
                        last.SetNext(new Node<int>(chain.GetValue()));
                        last = last.GetNext(); // קידום לחוליה האחרונה
                    }
                }
                chain = chain.GetNext(); // קידום על השרשרת המקורית
            }

            return first; // החזרת השרשרת החדשה
        }


        // מציאת החוליה שלפניה
        public static Node<int> FindPrev(Node<int> lst, Node<int> pos)
        {
            while (lst.GetNext() != pos)
                lst = lst.GetNext();

            return lst;
        }


        // פעולת מחיקה חוליה
        public static Node<int> Remove(Node<int> lst, Node<int> pos)
        {
            if (lst == pos)
                return lst.GetNext();

            Node<int> prev = FindPrev(lst, pos);
            prev.SetNext(pos.GetNext());
            pos.SetNext(null);

            return lst;
        }


        // צמצום
        // 4 🡪 4 🡪 4 🡪 3 🡪 9 🡪 9 => 12🡪 3 🡪 18
        public static Node<int> Reduction(Node<int> lst)
        {
            Node<int> pos = lst;
            Node<int> place = pos; // הפניה לתחילת קבוצה

            int count = 1; int num;

            while (pos != null) // סריקת כל השרשרת
            {
                num = pos.GetValue(); // איתחול המספר של הקבוצה
                pos = pos.GetNext();

                while (pos != null && pos.GetValue() == num) // מעבר על הקבוצה
                {
                    count++;
                    pos = pos.GetNext();
                }

                place.SetValue(num * count); // עידכון החוליה הראשונה בקבוצה
                place.SetNext(pos); // מחיקת החוליות הכפולות

                place = pos; // הזזה לתחילת הקבוצה הבאה
                count = 1; // איתחול המונה לקבוצה הבאה
            }

            return lst;
        }


        // שרשרת ממויינת – בדיקה (int)
        public static bool IsUpOrder(Node<int> lst)
        {
            while (lst.HasNext())
            {
                if (lst.GetValue() >= lst.GetNext().GetValue())
                    return false;

                lst = lst.GetNext();
            }

            return true;
        }


        // שרשרת ממויינת – בדיקה (char)
        public static bool IsUpOrder(Node<char> lst)
        {
            while (lst.HasNext())
            {
                if (lst.GetValue() >= lst.GetNext().GetValue())
                    return false;

                lst = lst.GetNext();
            }

            return true;
        }


        // שרשרת ממויינת – בדיקה (string)
        public static bool IsUpOrder(Node<string> lst)
        {
            while (lst.HasNext())
            {
                if (lst.GetValue().CompareTo(lst.GetNext().GetValue()) >= 0)
                    return false;

                lst = lst.GetNext();
            }

            return true;
        }


        // שרשרת ממויינת – סידרה
        public static bool IsSidra(Node<int> lst)
        {
            int delta = lst.GetNext().GetValue() - lst.GetValue();
            lst = lst.GetNext();

            while (lst.HasNext())
            {
                if ((lst.GetValue() + delta) != lst.GetNext().GetValue())
                    return false;

                lst = lst.GetNext();
            }

            return true;
        }


        // מיון שרשרת חוליות
        public static void BubbleSort(Node<int> lst)
        {
            int num, temp;
            Node<int> pos;

            while (lst.HasNext())
            {
                num = lst.GetValue();
                pos = lst.GetNext();

                while (pos != null)
                {
                    if (num > pos.GetValue())
                    {
                        temp = num;
                        num = pos.GetValue();
                        pos.SetValue(temp);
                    }

                    pos = pos.GetNext();
                }

                lst.SetValue(num);
                lst = lst.GetNext();
            }
        }


        // מיון שרשרת חוליות – מיון הכנסה
        public static Node<int> AddToSortChain(Node<int> lst, int num)
        {
            if (lst == null) // אם שרשרת ריקה 
                return new Node<int>(num);

            if (num < lst.GetValue()) // הכנסה החוליה ראשונה
                return new Node<int>(num, lst);

            Node<int> pos = lst; //חיפוש מקום

            while (pos.HasNext() && num > pos.GetNext().GetValue())
                pos = pos.GetNext();

            pos.SetNext(new Node<int>(num, pos.GetNext()));

            return lst; //הוספה והחזרת השרשרת
        }


        // להפוך שרשרת חוליות רגילה למעגלית
        public static void TurnChainIntoCircular(Node<int> lst)
        {
            Node<int> last = GetLast(lst);

            last.SetNext(lst);
        }


        // פעולת הסריקה - ספירת חוליות מעגלית
        public static int CountCircleChain(Node<int> lst)
        {
            Node<int> pos = lst.GetNext();
            int count = 1;

            while (pos != lst)
            {
                count++;

                pos = pos.GetNext();
            }

            return count;
        }


        // שרשרת חוליות מעגלית – הבדיקה
        public static bool IsCircleChain(Node<int> lst)
        {
            if (lst == null) return false; // שרשרת ריקה

            Node<int> pos = lst.GetNext();

            while (pos != null && pos != lst)
                pos = pos.GetNext();

            return pos == lst;
        }


        // פעולה שמקבלת שרשרת מעגלית ומוסיפה בין כל שתי חוליות חוליה חדשה שערכה כסכום שכנותיה
        public static void AddToCircleChain(Node<int> lst)
        {
            int s;
            Node<int> first = lst;
            Node<int> pos = lst.GetNext();

            while (pos != lst)
            {
                s = first.GetValue() + pos.GetValue();
                first.SetNext(new Node<int>(s, pos));
                first = pos;
                pos = pos.GetNext();
            }

            s = first.GetValue() + pos.GetValue();
            first.SetNext(new Node<int>(s, pos));
        }


        // הוספה לתחילת השרשרת המעגלית
        public static Node<int> AddFirst(Node<int> lst, int num)
        {
            Node<int> last = lst;

            while (last.GetNext() != lst)
                last = last.GetNext();

            lst = new Node<int>(num, lst);
            last.SetNext(lst);

            return lst;
        }


        // מחיקת חוליות בשרשרת מעגלית
        public static Node<int> DeleteNodeCircleChain(Node<int> lst, int num)
        {
            Node<int> prev = lst;

            if (lst.GetValue() == num)
            {
                while (prev.GetNext() != lst)
                    prev = prev.GetNext();

                prev.SetNext(lst.GetNext());
                lst.SetNext(null);
                lst = prev;
            }
            else
            {
                while (prev.GetNext().GetValue() != num)
                    prev = prev.GetNext();

                prev.SetNext(prev.GetNext().GetNext());
            }

            return lst;
        }


        // מיזוג רשימות
        public static Node<int> Merge(Node<int> lst1, Node<int> lst2)
        {
            Node<int> lst3 = new Node<int>(0);
            Node<int> q = lst3;

            while (lst1 != null && lst2 != null)
            {
                if (lst1.GetValue() < lst2.GetValue())
                {
                    q.SetNext(new Node<int>(lst1.GetValue()));
                    lst1 = lst1.GetNext();
                }
                else
                {
                    q.SetNext(new Node<int>(lst2.GetValue()));
                    lst2 = lst2.GetNext();
                }
                q = q.GetNext();
            }

            if (lst1 != null)
                q.SetNext(lst1);
            else if (lst2 != null)
                q.SetNext(lst2);

            lst3 = lst3.GetNext();

            return lst3;
        }

    }
}
