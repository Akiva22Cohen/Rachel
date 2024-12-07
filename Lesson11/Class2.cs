using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11
{
    public class Class2
    {
        public static int Schum(Node<int> lst, Node<int> p)
        {
            Node<int> p1 = p.GetNext();

            if (p1 == null)
                return 0;
            else
            {
                if (p1.GetValue() > p.GetValue())
                    return 0;
                else
                    return Schum(lst, p.GetNext()) + p.GetValue();
            }
        }

        public static void Run()
        {
            // List 1: 3 → 4 → 5 → 6 → 7 → 5 → 7 → 1 → 6
            Node<int> n1 = new Node<int>(3);
            Node<int> n2 = new Node<int>(4);
            Node<int> n3 = new Node<int>(5);
            Node<int> n4 = new Node<int>(6);
            Node<int> n5 = new Node<int>(7);
            Node<int> n6 = new Node<int>(5);
            Node<int> n7 = new Node<int>(7);
            Node<int> n8 = new Node<int>(1);
            Node<int> n9 = new Node<int>(6);

            n1.SetNext(n2);
            n2.SetNext(n3);
            n3.SetNext(n4);
            n4.SetNext(n5);
            n5.SetNext(n6);
            n6.SetNext(n7);
            n7.SetNext(n8);
            n8.SetNext(n9);

            Console.WriteLine("List 1: " + n1.ToPrint());
            Console.WriteLine("Schum for List 1: " + Schum(n1, n1)); // Expected: 0

            // List 2: 7 → 6 → 5 → 4 → 8 → 10
            Node<int> m1 = new Node<int>(7);
            Node<int> m2 = new Node<int>(6);
            Node<int> m3 = new Node<int>(5);
            Node<int> m4 = new Node<int>(4);
            Node<int> m5 = new Node<int>(8);
            Node<int> m6 = new Node<int>(10);

            m1.SetNext(m2);
            m2.SetNext(m3);
            m3.SetNext(m4);
            m4.SetNext(m5);
            m5.SetNext(m6);

            Console.WriteLine("\nList 2: " + m1.ToPrint());
            Console.WriteLine("Schum for List 2: " + Schum(m1, m1)); // Expected: 18
        }
    }
}
