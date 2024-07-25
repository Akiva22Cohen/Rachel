using Methods;
using System;

class Program
{
    static void Main(string[] args)
    {
        Node<int> lst = null;
        for (int i = 1; i <= 10; i++)
            lst = new Node<int>(i, lst);

        Universal_methods.PrintNode(lst);

        Node<int> lst2 = new Node<int>(1);
        Node<int> pos = lst2;
        for (int i = 2; i < 10; i++)
        {
            pos.SetNext(new Node<int>(i));
            pos = pos.GetNext();
        }

        Node<int> lst3 = new Node<int>(1);
        Node<int> pos2 = lst3;
        for (int i = 2; i < 15; i += 2)
        {
            pos2.SetNext(new Node<int>(i));
            pos2 = pos2.GetNext();
        }

        Universal_methods.PrintNode(lst2);
        Console.WriteLine(Universal_methods.IsUpOrder(lst2));
        Console.WriteLine(Universal_methods.IsUpOrder(lst));

        Console.WriteLine(Universal_methods.IsSidra(lst2));
        Console.WriteLine(Universal_methods.IsSidra(lst));

        Universal_methods.BubbleSort(lst);
        Universal_methods.PrintNode(lst);


        Universal_methods.PrintNode(lst3);
        Universal_methods.PrintNode(Universal_methods.Merge(lst2, lst3));

        Console.WriteLine(Universal_methods.FindPrev(lst2, lst2.GetNext().GetNext()).GetValue());

        Universal_methods.PrintNode(Universal_methods.Remove(lst2, lst2.GetNext().GetNext()));
    }
}