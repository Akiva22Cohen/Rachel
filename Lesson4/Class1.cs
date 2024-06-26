using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    public class Item
    {
        private int from;
        private int to;

        public Item(int from, int to)
        {
            this.from = from;
            this.to = to;
        }

        public int GetFrom() { return from; }
        public int GetTo() { return to; }

        public void SetFrom(int from) { this.from = from; }
        public void SetTo(int to) { this.to = to; }

        public override string ToString()
        {
            return $"from {from} to {to}";
        }
    }

    public class Class1
    {
        public static void Check(bool[] rainyDays, Node<Item> item)
        {
            Node<Item> pos = item;
            int from, to;
            bool flag = false;

            for (int i = 1; i < rainyDays.Length; i++)
            {
                while (pos != null && !flag)
                {
                    from = pos.GetValue().GetFrom();
                    to = pos.GetValue().GetTo();
                    if (from <= i && i <= to)
                        flag = true;
                    pos = pos.GetNext();
                }

                if ((!flag && rainyDays[i]) || (flag && !rainyDays[i]))
                    Console.Write(i + " ");

                flag = false;
                pos = item;
            }
        }

        public static void RunTestQ1()
        {
            bool[] rainyDays = { true, true, true, true, false, false, true, false };
            Node<Item>[] items =
            {
                new Node<Item>(new Item(1, 1)),
                new Node<Item>(new Item(3, 4)),
                new Node<Item>(new Item(6, 7))
            };
            for (int i = 0; i < items.Length - 1; i++)
                items[i].SetNext(items[i + 1]);
            Console.WriteLine(items[0].ToPrint());
            Check(rainyDays, items[0]);
        }

    }
}
