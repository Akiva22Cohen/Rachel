using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    public class Garbage
    {
        private string num;
        private double capacity;
        private double quantity;
        private string neighbor;

        public Garbage(string num, double capacity, double quantity, string neighbor)
        {
            this.num = num;
            this.capacity = Math.Round(capacity, 2);
            this.quantity = Math.Round(quantity, 2);
            this.neighbor = neighbor;
        }

        public Garbage(Garbage garbage) : this(garbage.num, garbage.capacity, garbage.quantity, garbage.neighbor) { }

        public string GetNum() { return num; }
        public double GetCapacity() { return capacity; }
        public double GetQuantity() { return quantity; }
        public string GetNeighbor() { return neighbor; }

        public override string ToString()
        {
            return String.Format("{0, -20} {1, -20} {2, -20} {3, -20}", $"num: {num}", $"capacity: {capacity}", $"quantity: {quantity}", $"neighbor: {neighbor}\n");
        }
    }
}
