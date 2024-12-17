using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class ClassCount2
    {
        public static int Temp(BinNode<int> node)
        {
            if (node == null) return 0;

            if (node.GetValue() % 2 == 0) 
                return node.GetValue() + Temp(node.GetLeft()) + Temp(node.GetRight());

            return Temp(node.GetLeft()) + Temp(node.GetRight());
        }

        public static void Run()
        {

        }
    }
}
