using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lesson2
{
    // Q4
    public class Point
    {
        double x;
        double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double GetX() { return x; }
        public double GetY() { return y; }

        public void SetX(double x) { this.x = x; }
        public void SetY(double y) { this.y = y; }

        public override string ToString()
        {
            return $"(y, x): ({y}, {x})";
        }
    }

    public class Circle
    {
        Point center;

        public Circle(Point center) { this.center = center; }

        public Point GetCenter() { return center; }
    }

    public class Class4
    {
        static int CountPointInCircle(Node<Circle> circle, Point point)
        {
            int count = 0;
            Node<Circle> pos = circle;
            Point p;
            double x, y;

            while (pos != null)
            {
                p = pos.GetValue().GetCenter();
                x = p.GetX();
                y = p.GetY();

                if (x == point.GetX() && y == point.GetY())
                    count++;
                pos = pos.GetNext();
            }
            return count;
        }

        static void PrintAllCirclesCenters(Node<Circle> circles)
        {
            Node<Circle> pos = circles;
            Point point;

            while (pos != null)
            {
                point = pos.GetValue().GetCenter();
                Console.WriteLine(point.ToString());
                pos = pos.GetNext();
            }
        }

        // בדיקה שאלה 4
        public static void TestQ4()
        {
            Node<Circle>[] circles =
            {
                new Node<Circle>(new Circle(new Point(8, 4))),
                new Node<Circle>(new Circle(new Point(4, 8))),
                new Node<Circle>(new Circle(new Point(4, 8))),
                new Node<Circle>(new Circle(new Point(4, 8))),
            };

            Node<Circle> head = PublicStaticOperations.CreateNode(circles);
            Point point = new Point(4, 8);

            Console.WriteLine("the point:");
            Console.WriteLine(point.ToString());
            Console.WriteLine();

            Console.WriteLine("Centers of all circles in the chain:");
            PrintAllCirclesCenters(head);
            Console.WriteLine();

            int countPointsInCircle = CountPointInCircle(head, point);
            Console.WriteLine("How many of the circles is the point in the center: " + countPointsInCircle);
        }
    }
}
