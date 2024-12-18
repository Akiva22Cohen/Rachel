using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class ClassCount7
    {
        public static bool IsLeaf(BinNode<int> node)
        {
            return !node.HasLeft() && !node.HasRight();
        }

        public static void Run()
        {

        }
    }
}
