using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    public class Class4
    {
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

        public static Node<int> ListSqr(Node<int> lst1, Node<int> lst2)
        {
            Node<int> lst3 = new Node<int>(0);
            Node<int> pos1 = lst1;
            Node<int> pos2 = lst2;
            Node<int> pos3 = lst3;
            int num;

            while (pos1 != null)
            {
                num = pos1.GetValue();
                while (pos2 != null && (num * num) != pos2.GetValue())
                    pos2 = pos2.GetNext();
                if (pos2 != null)
                {
                    pos3.SetNext(new Node<int>(num));
                    pos3 = pos3.GetNext();
                }
                pos2 = lst2;
                pos1 = pos1.GetNext();
            }

            lst3 = lst3.GetNext();
            return lst3;
        }

        public static void RunTestQ4()
        {
            Random rnd = new Random();

            Node<int>[] nodes1;
            Node<int>[] nodes2;

            Node<int> lst1;
            Node<int> lst2;
            Node<int> lst3;

            do
            {
                nodes1 = new Node<int>[rnd.Next(5, 11)];
                nodes2 = new Node<int>[rnd.Next(3, 11)];

                for (int i = 0; i < nodes1.Length; i++)
                    nodes1[i] = new Node<int>(rnd.Next(11));

                for (int i = 0; i < nodes1.Length - 1; i++)
                    nodes1[i].SetNext(nodes1[i + 1]);

                for (int i = 0; i < nodes2.Length; i++)
                    nodes2[i] = new Node<int>(rnd.Next(101));

                for (int i = 0; i < nodes2.Length - 1; i++)
                    nodes2[i].SetNext(nodes2[i + 1]);

                lst1 = nodes1[0];
                lst2 = nodes2[0];
                lst3 = ListSqr(lst1, lst2);

            } while (lst3 == null || CountNode(lst3) < nodes1.Length / 2 + 1);

            Console.WriteLine("lst1.ToPrint():");
            Console.WriteLine(lst1.ToPrint());
            Console.WriteLine();

            Console.WriteLine("lst2.ToPrint():");
            Console.WriteLine(lst2.ToPrint());
            Console.WriteLine();

            Console.WriteLine(lst3.ToPrint());

        }
    }
}
