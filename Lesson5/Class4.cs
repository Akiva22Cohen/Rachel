using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    public class Class4
    {
        public static void Print(Node<int> lst, Node<int> p)
        {
            Node<int> pos = lst;

            Console.ForegroundColor = (pos == p) ? ConsoleColor.Blue : ConsoleColor.Green;
            Console.Write(pos.GetValue() + " ");
            pos = pos.GetNext();
            while (pos.GetNext() != lst)
            {
                Console.ForegroundColor = (pos == p) ? ConsoleColor.Blue : ConsoleColor.White;
                Console.Write(pos.GetValue() + " ");
                pos = pos.GetNext();
            }
            Console.ForegroundColor = (pos == p) ? ConsoleColor.Blue : ConsoleColor.Red;
            Console.WriteLine(pos.GetValue() + " ");
            Console.ResetColor();
        }

        public static Node<int> FindPrev(Node<int> lst, Node<int> pos)
        {
            if (lst == null || pos == null)
                return null;

            Node<int> start = lst;

            // Traverse the list until we find the node whose next node is 'pos'
            // or we return to the start node, indicating 'pos' is not in the list
            do
            {
                if (start.GetNext() == pos)
                    return start;
                start = start.GetNext();
            } while (lst != start);

            // If 'pos' is not found, return null
            return null;
        }


        public static void GameSteps(Node<int> game)
        {
            Random rnd = new Random();
            int cube1, cube2;
            Node<int> pos = game;

            Console.WriteLine("Game start!");
            Console.WriteLine();
            while (pos.GetNext() != game)
            {
                cube1 = rnd.Next(1, 7);
                cube2 = rnd.Next(1, 7);
                Console.WriteLine($"Dice: {cube1}, {cube2}");

                Console.WriteLine("game board:");
                Console.WriteLine("previous =>");
                Print(game, pos);
                for (int i = 0; i < (cube1 + cube2); i++)
                    pos = pos.GetNext();

                if (pos.GetValue() == 0)
                {
                    Console.WriteLine("a step back!");
                    Print(game, pos);
                    pos = FindPrev(game, pos);
                }

                Console.WriteLine("current =>");
                Print(game, pos);
                Console.WriteLine("position: " + pos.GetValue());
                Console.WriteLine();
            }
            Console.WriteLine("end game!");
        }

        public static void RunTestQ4()
        {
            Random rnd = new Random();
            int num;
            Node<int>[] nodes = new Node<int>[rnd.Next(10, 20)];

            nodes[0] = new Node<int>(rnd.Next(1, 10));
            for (int i = 1; i < nodes.Length - 1; i++)
            {
                num = rnd.Next(5);
                while (num == 0 && nodes[i - 1].GetValue() == 0)
                    num = rnd.Next(1, 10);
                nodes[i] = new Node<int>(num);
            }
            nodes[nodes.Length - 1] = new Node<int>(rnd.Next(1, 10));

            for (int i = 0; i < nodes.Length - 1; i++)
                nodes[i].SetNext(nodes[i + 1]);
            nodes[nodes.Length - 1].SetNext(nodes[0]);

            Node<int> head = nodes[0];
            
            GameSteps(head);
        }
    }
}
