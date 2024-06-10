using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lesson2
{
    public class Expr
    {
        double num1;
        double num2;
        char op;

        // Q5.1.1
        public Expr(double num1, double num2, char op)
        {
            this.num1 = num1;
            this.num2 = num2;
            this.op = op;
        }

        // Q5.1.2
        public double GetNum1() { return num1; }
        public double GetNum2() { return num2; }
        public char GetOp() { return op; }

        // Q5.1.3
        public override string ToString() { return $"{num1} {op} {num2}"; }

        // Q5.2
        public double Calculate()
        {
            switch (this.op)
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
    }

    public class Class5
    {
        // Q5.3
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

        static void PrintAllExpr(Node<Expr> node)
        {
            Node<Expr> pos = node;
            while (pos != null)
            {
                Console.WriteLine(pos.GetValue().ToString());
                pos = pos.GetNext();
            }
        }

        // בדיקה שאלה 5
        public static void TestQ5()
        {
            Node<Expr>[] nodes =
            {
                new Node<Expr>(new Expr(3,   4, '+')),
                new Node<Expr>(new Expr(8,   2, '/')),
                new Node<Expr>(new Expr(7,  10, '-')),
                new Node<Expr>(new Expr(9, 100, '*')),
            };

            Node<Expr> head = PublicStaticOperations.CreateNode(nodes);

            Console.WriteLine("List of invoices:");
            PrintAllExpr(head);
            Console.WriteLine();

            double res = SumExpressions(head);
            Console.WriteLine("The sum of all the values of the arithmetic expressions in the list: " + res);
            Console.WriteLine();
        }
    }
}
