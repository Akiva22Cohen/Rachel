using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    public class Point
    {
        private int x;
        private int y;

        public Point(int y = 0, int x = 0)
        {
            SetY(y);
            SetX(x);
        }

        public int GetX() { return x; }
        public int GetY() { return y; }

        public void SetX(int x) { this.x = x; }
        public void SetY(int y) { this.y = y; }

        public bool Equals(Point other) { return this.x == other.GetX() && this.y == other.GetY(); }

        public override string ToString() { return $"({y},{x})"; }

    }
}
