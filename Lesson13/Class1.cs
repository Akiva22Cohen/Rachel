using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13
{
    public class Class1
    {
        public static char DecodePath(BinNode<char> bin, string str)
        {
            BinNode<char> pos = bin;

            for (int i = 0; i < str.Length; i++)
            {
                switch (str[i])
                {
                    case '.':
                        pos = pos.GetRight();
                        break;
                    case '-':
                        pos = pos.GetLeft();
                        break;
                }
            }

            return pos.GetValue();
        }

        public static void Run()
        {
            BinNode<char> nO = new BinNode<char>(new BinNode<char>('2'), 'O', new BinNode<char>('3')),
                          nG = new BinNode<char>(new BinNode<char>('Q'), 'G', new BinNode<char>('Z')),
                          nM = new BinNode<char>(nO, 'M', nG),
                          nK = new BinNode<char>(new BinNode<char>('Y'), 'K', new BinNode<char>('C')),
                          nD = new BinNode<char>(new BinNode<char>('X'), 'D', new BinNode<char>('B')),
                          nN = new BinNode<char>(nK, 'N', nD),
                          nT = new BinNode<char>(nM, 'T', nN),
                          nW = new BinNode<char>(new BinNode<char>('J'), 'W', new BinNode<char>('P')),
                          nR = new BinNode<char>(new BinNode<char>('1'), 'R', new BinNode<char>('L')),
                          nA = new BinNode<char>(nW, 'A', nR),
                          nU = new BinNode<char>(new BinNode<char>('V'), 'U', new BinNode<char>('F')),
                          nS = new BinNode<char>(new BinNode<char>('0'), 'S', new BinNode<char>('H')),
                          nI = new BinNode<char>(nU, 'I', nS),
                          nE = new BinNode<char>(nA, 'E', nI),
                          root = new BinNode<char>(nT, ' ', nE);

            nW.GetRight().SetRight(new BinNode<char>('9'));
            nR.GetLeft().SetRight(new BinNode<char>('8'));
            nR.GetRight().SetRight(new BinNode<char>('7'));
            nU.GetLeft().SetRight(new BinNode<char>('6'));
            nU.GetRight().SetRight(new BinNode<char>('5'));
            nS.GetLeft().SetRight(new BinNode<char>('4'));

            string cA = ".-",
                   cK = "-.-",
                   cI = "..",
                   cV = "..--",
                   cC = "-.-.",
                   cO = "---",
                   cH = "....",
                   cE = ".",
                   cN = "-.",
                   c2 = "----",
                   c4 = "...-.",
                   AKIVA = "" + DecodePath(root, cA) + DecodePath(root, cK) + DecodePath(root, cI) + DecodePath(root, cV) + DecodePath(root, cA),
                   COHEN = "" + DecodePath(root, cC) + DecodePath(root, cO) + DecodePath(root, cH) + DecodePath(root, cE) + DecodePath(root, cN),
                   age24 = "" + DecodePath(root, c2) + DecodePath(root, c4);

            Console.WriteLine(AKIVA + " " + COHEN + ", age: " + age24);
        }
    }
}
