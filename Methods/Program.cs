using Methods;
using System;

class Program
{
    static void Temp(Node<int> lst)
    {
        Node<int> pos = lst;

        int num = 0;
        while (pos != null && pos.HasNext())
        {
            while (pos.HasNext() && pos.GetValue() != -1)
            {
                num = (num + pos.GetValue()) * 10;
                pos = pos.GetNext();
            }
            Console.WriteLine(num / 10);
            pos = pos.GetNext();
            num = 0;
        }
    }

    static void Main(string[] args)
    {
        int[] ints = { 2, 6, -1, 8, -1 };
        Node<int> node = new Node<int>(ints[0]);
        for (int i = ints.Length - 2; i >= 0; i--)
            node = new Node<int>(ints[i], node);

        Console.WriteLine(node.ToPrint());

        Temp(node);
    }
}