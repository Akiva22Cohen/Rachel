using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    public class Class2
    {
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

        // יצירת שרשרת רדומלית
        static Node<char> CreateRndNodeChar(int len, char[] chs)
        {
            Node<char>[] nodes = new Node<char>[len];

            // יצירת צמתים ובניית שרשרת
            for (int i = 0; i < nodes.Length; i++)
                nodes[i] = new Node<char>(chs[PublicStaticOperations.rnd.Next(chs.Length)]);

            return PublicStaticOperations.CreateNode(nodes);
        }

        // בדיקה שאלה 2
        public static void TestQ2()
        {
            int len = PublicStaticOperations.rnd.Next(2, 11);
            char[] chars = { 'A', 'T', 'C', 'G' };
            Node<char> strand1 = CreateRndNodeChar(len, chars),
                       strand2 = CreateRndNodeChar(len, chars);

            Console.WriteLine("strand1:");
            PublicStaticOperations.PrintNode(strand1);
            Console.WriteLine();

            Console.WriteLine("strand2:");
            PublicStaticOperations.PrintNode(strand2);
            Console.WriteLine();

            Console.WriteLine("CheckDNA(strand1, strand2) => " + CheckDNA(strand1, strand2));
            Console.WriteLine();

            strand2 = CreatingTwinStrand(strand1);
            Console.WriteLine("strand2 = CreatingTwinStrand(strand1); =>");
            PublicStaticOperations.PrintNode(strand2);
            Console.WriteLine();

            Console.WriteLine("CheckDNA(strand1, strand2) => " + CheckDNA(strand1, strand2));
            Console.WriteLine();
        }
    }
}
