using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace End_of_semester_exam
{
    public class Queue<T>
    {
        private Node<T> first;
        private Node<T> last;

        public Queue()
        {
            first = null;
            last = null;
        }

        public void Insert(T x)
        {
            if (last == null)
            {
                first = new Node<T>(x);
                last = first;
            }
            else
            {
                last.SetNext(new Node<T>(x));
                last = last.GetNext();
            }
        }

        public T Remove()
        {
            T t = first.GetValue();
            if (first != last)
                first = first.GetNext();
            else
            {
                first = null;
                last = null;
            }
            return t;
        }

        public T Head() { return first.GetValue(); }
        public bool IsEmpty() { return first == null; }

        public override string ToString()
        {
            Node<T> temp = first;
            string st = "[";
            while (temp != null)
            {
                st += temp.GetValue() + ",";
                temp = temp.GetNext();
            }
            st += "\b]";
            return st;
        }
    }
}