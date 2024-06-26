using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    public class Class1
    {
        static void PrintNode(Node<Point> lst)
        {
            if (lst == null)
            {
                Console.WriteLine("The Node is empty!");
                return;
            }
            Node<Point> pos = lst;

            while (pos.HasNext())
            {
                Console.Write(pos.GetValue().ToString() + " --> ");
                pos = pos.GetNext();
            }
            Console.Write(pos.GetValue().ToString());
            Console.WriteLine();
        }

        public static Node<Point> MergeNodes(Node<Point> list1, Node<Point> list2)
        {
            Node<Point> newNode = new Node<Point>(new Point());
            Point point1 = list1.GetValue(),
                  point2 = list2.GetValue();

            if (point1.GetX() > point2.GetX())
            {
                newNode.SetValue(point1);
                list1 = list1.GetNext();
            }
            else if (point1.GetX() < point2.GetX())
            {
                newNode.SetValue(point2);
                list2 = list2.GetNext();
            }
            else
            {
                newNode.SetValue(new Point(point1.GetY() + point2.GetY(), point1.GetX()));
                list1 = list1.GetNext();
                list2 = list2.GetNext();
            }

            Node<Point> last = newNode;

            while (list1 != null && list2 != null)
            {
                point1 = list1.GetValue();
                point2 = list2.GetValue();
                if (point1.GetX() > point2.GetX())
                {
                    last.SetNext(new Node<Point>(point1));

                    list1 = list1.GetNext();
                }
                else if (point1.GetX() < point2.GetX())
                {
                    last.SetNext(new Node<Point>(point2));

                    list2 = list2.GetNext();
                }
                else
                {
                    last.SetNext(new Node<Point>(new Point(point1.GetY() + point2.GetY(), point1.GetX())));
                    list1 = list1.GetNext();
                    list2 = list2.GetNext();
                }
                last = last.GetNext();
            }

            while (list1 != null)
            {
                last.SetNext(list1);

                list1 = list1.GetNext();

                last = last.GetNext();

            }

            while (list2 != null)
            {
                last.SetNext(list2);

                list2 = list2.GetNext();

                last = last.GetNext();
            }

            return newNode;
        }

        public static void RunTestQ1()
        {
            Node<Point> list1 = new Node<Point>(new Point(1, 5), new Node<Point>(new Point(5, 3), new Node<Point>(new Point(-16, 0))));
            Node<Point> list2 = new Node<Point>(new Point(2, 4), new Node<Point>(new Point(6, 3), new Node<Point>(new Point(24, 1))));

            PrintNode(MergeNodes(list1, list2));
        }
    }
}
