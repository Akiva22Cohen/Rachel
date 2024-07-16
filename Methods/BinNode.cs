using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Methods
{
    public class BinNode<T>
    {
        private T value;
        private BinNode<T> left;
        private BinNode<T> right;

        public BinNode(T value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
        }

        public BinNode(BinNode<T> left, T value, BinNode<T> right)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }

        public T GetValue() { return this.value; }
        public BinNode<T> GetLeft() { return this.left; }
        public BinNode<T> GetRight() { return this.right; }

        public void SetValue(T value) { this.value = value; }
        public void SetLeft(BinNode<T> left) { this.left = left; }
        public void SetRight(BinNode<T> right) { this.right = right; }

        public bool HasLeft() { return this.left != null; }
        public bool HasRight() { return this.right != null; }

        public override string ToString() { return " " + this.value; }
    }
}
