using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    public class PublicStaticOperations
    {
        public static Random rnd = new Random();

        // יצירת חוליות
        public static Node<int> CreateNode(Node<int>[] nodes)
        {
            for (int i = 0; i < nodes.Length - 1; i++)
                nodes[i].SetNext(nodes[i + 1]);
            return nodes[0];
        }
        
        public static Node<char> CreateNode(Node<char>[] nodes)
        {
            for (int i = 0; i < nodes.Length - 1; i++)
                nodes[i].SetNext(nodes[i + 1]);
            return nodes[0];
        }
        
        public static Node<Circle> CreateNode(Node<Circle>[] nodes)
        {
            for (int i = 0; i < nodes.Length - 1; i++)
                nodes[i].SetNext(nodes[i + 1]);
            return nodes[0];
        }
        
        public static Node<Expr> CreateNode(Node<Expr>[] nodes)
        {
            for (int i = 0; i < nodes.Length - 1; i++)
                nodes[i].SetNext(nodes[i + 1]);
            return nodes[0];
        }

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
        
        public static void PrintNode(Node<char> lst)
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
    }
}
