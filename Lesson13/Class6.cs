using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13
{
    public class Class6
    {
        public static bool IsLeaf(BinNode<int> node)
        {
            return !node.HasLeft() && !node.HasRight();
        }

        public static void Temp(BinNode<int> node)
        {

        }

        public static void Run()
        {

        }
    }
}
