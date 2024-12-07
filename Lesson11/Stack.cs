using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11
{
    public class Stack<T>
    {
        private Node<T> head;

        public Stack()
        {
            this.head = null;
        }
        public bool IsEmpty()
        {
            return this.head == null;
        }
        public T Top()
        {
            return this.head.GetValue();
        }
        public void Push(T x)
        {
            this.head = new Node<T>(x, this.head);
        }
        public T Pop()
        {
            T x = this.head.GetValue();
            this.head = this.head.GetNext();
            return x;
        }
        public override string ToString()
        {
            Node<T> temp = head;
            string st = "[";

            while (temp != null)
            {
                st += temp.GetValue();
                if (temp.HasNext())
                    st += ", ";
                temp = temp.GetNext();
            }

            st += "]";
            return st;
        }
    }
}
