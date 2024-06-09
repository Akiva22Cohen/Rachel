using Lesson2;
using System;
using System.Drawing;

class Point
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
}

class Circle
{
    Point center;

    public Circle(Point center) { this.center = center; }

    public Point GetCenter() { return center; }
}

class Expr
{
    double num1;
    double num2;
    char op;

    public Expr(double num1, double num2, char op)
    {
        this.num1 = num1;
        this.num2 = num2;
        this.op = op;
    }

    public double GetNum1() { return num1; }
    public double GetNum2() { return num2; }
    public char GetOp() { return op; }

    public void SetNum1(double num1) { this.num1 = num1; }
    public void SetNum2(double num2) { this.num2 = num2; }
    public void SetOp(char op) { this.op = op; }

    public double Calculate()
    {
        switch(this.op)
        {
            case '+': 
                return num1 + num2;
            case '-':
                return num1 - num2;
            case '*':
                return num1 * num2;
            case '/':
                return num1 / num2;
            default:
                return 0;
        }
    }

    public override string ToString()
    {
        return $"{num1} {op} {num2}";
    }
} 

class Program
{
    // Q1
    static Node<int> CreateEventArr(Node<int> node, string order = "normal")
    {
        if (order != "normal" && order != "reverse") return null;
        Node<int> pos = node;

        // למצוא תערך הזוגי הראשון בשרשרת ולשמור אותו במשתנה, אם יש בכלל
        int num = 0;
        bool hesEvent = false;
        while (pos != null && !hesEvent)
        {
            if (pos.GetValue() % 2 == 0)
            {
                num = pos.GetValue();
                hesEvent = true;
            }

            pos = pos.GetNext();
        }
        // אם לא מצא בשרשרת ערך זוגי בכלל מחזיר ריק
        if (!hesEvent) return null;

        Node<int> arr = new Node<int>(num);
        Node<int> pos2 = arr;
        while (pos != null)
        {
            if (pos.GetValue() % 2 == 0)
            {
                if (order == "normal")
                {
                    // פתרון א
                    pos2.SetNext(new Node<int>(pos.GetValue()));
                    pos2 = pos2.GetNext();
                }
                else if (order == "reverse")
                {
                    // פתרון ב
                    arr = new Node<int>(pos.GetValue(), arr);
                }
            }

            pos = pos.GetNext();
        }
        return arr;
    }

    // Q2.1
    static bool CheckDNA(Node<char> strand1, Node<char> strand2)
    {
        Node<char> posStrand1 = strand1,
                   posStrand2 = strand2;
        char chStrand1, chStrand2;
        while (posStrand1 != null && posStrand2 != null)
        {
            chStrand1 = posStrand1.GetValue();
            chStrand2 = posStrand2.GetValue();
            switch (chStrand1)
            {
                case 'A':
                    if (chStrand2 != 'T') return false;
                    break;
                case 'T':
                    if (chStrand2 != 'A') return false;
                    break;
                case 'C':
                    if (chStrand2 != 'G') return false;
                    break;
                case 'G':
                    if (chStrand2 != 'C') return false;
                    break;
                default:
                    return false;
            }

            posStrand1 = posStrand1.GetNext();
            posStrand2 = posStrand2.GetNext();
        }

        if (posStrand1 == null && posStrand2 == null)
            return true;
        return false;
    }

    // Q2.2
    static Node<char> CreatingTwinStrand(Node<char> strand)
    {
        if (strand == null) return null;

        Node<char> posStrand = strand,
                   newStrand = new Node<char>(' '),
                   posNewStrand = newStrand;
        char chStrand;
        while (posStrand != null)
        {
            chStrand = posStrand.GetValue();
            switch (chStrand)
            {
                case 'A':
                    posNewStrand.SetValue('T');
                    break;
                case 'T':
                    posNewStrand.SetValue('A');
                    break;
                case 'C':
                    posNewStrand.SetValue('G');
                    break;
                case 'G':
                    posNewStrand.SetValue('C');
                    break;
                default:
                    return null;
            }

            posStrand = posStrand.GetNext();
            if (posStrand != null)
            {
                posNewStrand.SetNext(new Node<char>(' '));
                posNewStrand = posNewStrand.GetNext();
            }
        }

        return newStrand;
    }

    // Q3
    static Node<int> RemoveNumFromNode(Node<int> chain, int num, string mode = "normal")
    {
        if (mode.Equals("start"))
        {
            Node<int> pos = chain;
            while (pos.GetValue() == num)
                pos = pos.GetNext();

            return pos;
        }
        else if (mode.Equals("normal"))
        {
            Node<int> first = null;
            Node<int> last = null;
            while (chain != null)
            {
                if (chain.GetValue() != num)
                {
                    if (first == null)
                    {
                        first = new Node<int>(chain.GetValue());
                        last = first;
                    }
                    else
                    {
                        last.SetNext(new Node<int>(chain.GetValue()));
                        last = last.GetNext();
                    }
                }
                chain = chain.GetNext();
            }
            return first;
        }
        return null;
    }

    // Q4
    static int CountPointInCircle(Node<Circle> circle, Point point)
    {
        int count = 0;
        Node<Circle> pos = circle;
        double x, y;

        while (pos != null)
        {
            x = pos.GetValue().GetCenter().GetX();
            y = pos.GetValue().GetCenter().GetY();

            if (x == point.GetX() && y == point.GetY())
                count++;
            pos = pos.GetNext();
        }
        return count;
    }

    // Q5
    static double SumExpressions(Node<Expr> node)
    {
        double sum = 0;
        Node<Expr> pos = node;

        while (pos != null)
        {
            sum += pos.GetValue().Calculate();
            pos = pos.GetNext();
        }

        return sum;
    }

    // הדפסת שרשרת
    static void Print(Node<int> lst)
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

    static void Print(Node<char> lst)
    {
        if (lst == null)
        {
            Console.WriteLine("The Node is empty!");
            return;
        }
        Node<char> pos = lst;

        while (pos.HasNext())
        {
            Console.Write(pos.GetValue() + " --> ");
            pos = pos.GetNext();
        }
        Console.Write(pos.GetValue());
        Console.WriteLine();
    }

    // יצירת שרשרת רדומלית
    static Node<int> CreateRndNode()
    {
        Random rnd = new Random();
        Node<int>[] nodes = new Node<int>[rnd.Next(2, 11)];

        // יצירת צמתים ובניית שרשרת
        nodes[0] = new Node<int>(rnd.Next(101));
        for (int i = 1; i < nodes.Length; i++)
        {
            nodes[i] = new Node<int>(rnd.Next(101));
            nodes[i - 1].SetNext(nodes[i]);
        }
        return nodes[0];
    }

    static Node<char> CreateRndNodeDNA(int len)
    {
        Random rnd = new Random();
        Node<char>[] nodes = new Node<char>[len];
        char[] chars = { 'A', 'T', 'C', 'G' };

        // יצירת צמתים ובניית שרשרת
        nodes[0] = new Node<char>(chars[rnd.Next(chars.Length)]);
        for (int i = 1; i < nodes.Length; i++)
        {
            nodes[i] = new Node<char>(chars[rnd.Next(chars.Length)]);
            nodes[i - 1].SetNext(nodes[i]);
        }
        return nodes[0];
    }

    // בדיקה שאלה 1
    static void TestQ1()
    {
        // ראש השרשרת
        Node<int> headNode = CreateRndNode();

        // הדפסה שרשרת מקורית
        Console.WriteLine("Original Node:");
        Print(headNode);
        Console.WriteLine();

        // בדיקה והדפסה שרשרת פתרון א
        Console.WriteLine("Event Node:");
        Node<int> arrEvent = CreateEventArr(headNode);
        Print(arrEvent);
        Console.WriteLine();

        // בדיקה והדפסה שרשרת פתרון ב
        Console.WriteLine("Event Node (reverse order):");
        Node<int> arrEvent2 = CreateEventArr(headNode, "reverse");
        Print(arrEvent2);
        Console.WriteLine();
    }

    // בדיקה שאלה 2
    static void TestQ2()
    {
        Random rnd = new Random();
        int len = rnd.Next(2, 11);

        Node<char> strand1 = CreateRndNodeDNA(len),
                   strand2 = CreateRndNodeDNA(len);

        Console.WriteLine("strand1:");
        Print(strand1);
        Console.WriteLine();

        Console.WriteLine("strand2:");
        Print(strand2);
        Console.WriteLine();

        Console.WriteLine("CheckDNA(strand1, strand2) => " + CheckDNA(strand1, strand2));
        Console.WriteLine();

        strand2 = CreatingTwinStrand(strand1);
        Console.WriteLine("strand2 = CreatingTwinStrand(strand1); =>");
        Print(strand2);
        Console.WriteLine();

        Console.WriteLine("CheckDNA(strand1, strand2) => " + CheckDNA(strand1, strand2));
    }

    // בדיקה שאלה 3
    static void TestQ3()
    {
        Node<int> n1 = new Node<int>(8);
        Node<int> n2 = new Node<int>(8);
        Node<int> n3 = new Node<int>(5);
        Node<int> n4 = new Node<int>(8);
        Node<int> n5 = new Node<int>(2);
        Node<int> n6 = new Node<int>(8);
        Node<int> n7 = new Node<int>(4);
        Node<int> n8 = new Node<int>(3);
        Node<int> n9 = new Node<int>(8);
        // [8,8,5,8,2,8,4,3,8]
        n1.SetNext(n2);
        n2.SetNext(n3);
        n3.SetNext(n4);
        n4.SetNext(n5);
        n5.SetNext(n6);
        n6.SetNext(n7);
        n7.SetNext(n8);
        n8.SetNext(n9);

        Console.WriteLine("Node:");
        Print(n1);
        Console.WriteLine("RemoveNumFromNode(n1, 8, start):");
        Print(RemoveNumFromNode(n1, 8, "start"));
        Console.WriteLine("RemoveNumFromNode(n1, 8):");
        Print(RemoveNumFromNode(n1, 8));
    }

    static void Main(string[] args)
    {
        //TestQ1();
        //TestQ2();
        //TestQ3();
    }
}