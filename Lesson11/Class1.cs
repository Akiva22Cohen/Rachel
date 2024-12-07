using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11
{
    public class Class1
    {
        public static bool Mystery(Node<int> p)
        {
            int n1, n2;
            if (p.GetNext() != null)
            {
                n1 = p.GetValue();
                p = p.GetNext();
                n2 = p.GetValue();

                if (n1 < n2)
                    return false;
                else
                    return Mystery(p);
            }
            return true;
        }

        public static void Run()
        {
            // רשימה בסדר יורד
            Node<int> n1 = new Node<int>(5);
            Node<int> n2 = new Node<int>(3);
            Node<int> n3 = new Node<int>(3);
            n1.SetNext(n2);
            n2.SetNext(n3);

            // רשימה בסדר עולה
            Node<int> n4 = new Node<int>(1);
            Node<int> n5 = new Node<int>(2);
            Node<int> n6 = new Node<int>(3);
            n4.SetNext(n5);
            n5.SetNext(n6);

            // רשימה לא מסודרת
            Node<int> n7 = new Node<int>(4);
            Node<int> n8 = new Node<int>(1);
            Node<int> n9 = new Node<int>(6);
            n7.SetNext(n8);
            n8.SetNext(n9);

            // בדיקות
            Console.WriteLine("List in descending order: " + Mystery(n1)); // true
            Console.WriteLine("List in ascending order: " + Mystery(n4)); // false
            Console.WriteLine("Unordered list: " + Mystery(n7)); // false
        }
    }
}
