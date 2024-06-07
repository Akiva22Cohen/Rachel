using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    public class PartB
    {
        //חלק ב
        //Q1
        public static int Sum(IntNode lst)
        {
            IntNode pos = lst;
            int sum = 0;

            while (pos != null)
            {
                sum += pos.GetValue();
                pos = pos.GetNext();
            }

            return sum;
        }

        //Q2
        public static bool IsExsist(IntNode lst, int num)
        {
            IntNode pos = lst;

            while (pos != null)
            {
                if (pos.GetValue() == num)
                    return true;
                pos = pos.GetNext();
            }
            return false;
        }

        //Q3
        public static void EnterLast(IntNode lst, IntNode num)
        {
            if (lst == null)
                lst = num;

            else
            {
                IntNode current = lst;

                while (current.GetNext() != null)
                    current = current.GetNext();

                current.SetNext(num);
            }
        }

        //Q4
        public static void EnterSecond(IntNode lst, IntNode num)
        {
            if (lst == null)
                lst = num;

            else
            {
                num.SetNext(lst.GetNext()); // Set num's next to the current second node
                lst.SetNext(num); // Set the head's next to num
            }
        }

        //Q5
        public static int Size(IntNode lst)
        {
            IntNode current = lst;
            int count = 0;

            while (current != null)
            {
                count++;
                current = current.GetNext();
            }

            return count;
        }

        //Q6
        public static int HowMany(IntNode lst, int num)
        {
            IntNode current = lst;
            int count = 0;

            while (current != null)
            {
                if (current.GetValue() == num)
                    count++;
                current = current.GetNext();
            }

            return count;
        }

        //7
        public static bool InOrder(IntNode lst)
        {
            IntNode current = lst;
            IntNode next = current.GetNext();

            while (next != null)
            {
                if (current.GetValue() > next.GetValue())
                    return false;

                current = next;
                next = current.GetNext();
            }

            return true;
        }

        //Q8
        public static int SumOdd(IntNode lst)
        {
            IntNode current = lst;
            int i = 0,
                sum = 0;

            while (current != null)
            {
                if (i++ % 2 != 0)
                    sum += current.GetValue();

                current = current.GetNext();
            }

            return sum;
        }

        //Q9
        public static void EnterInOrder(IntNode lst, int num)
        {
            IntNode current = lst,
                    next = current.GetNext();

            bool flag = false;

            while (next != null && (!flag))
            {
                if (current.GetValue() <= num && num <= next.GetValue())
                {
                    current.SetNext(new IntNode(num, next));
                    flag = true;
                }
                else
                {
                    current = next;
                    next = current.GetNext();

                }
            }
        }

        //Q10
        public static bool IsSerial(IntNode lst)
        {
            // Check if the list is empty
            if (lst == null)
                return false;

            // Initialize variables to track the current and previous values
            int current = lst.GetValue();
            int prev = current;

            // Iterate through the linked list
            IntNode currNode = lst;
            while (currNode.GetNext() != null)
            {
                currNode = currNode.GetNext();
                prev = current;
                current = currNode.GetValue();

                // Check if the difference between consecutive values is not 1
                if (current - prev != 1)
                    return false;
            }

            // If the loop completes, all differences were 1, so it's a serial
            return true;
        }

        //Q11
        public static IntNode RemovePos(IntNode lst, int num)
        {
            if (lst == null || num < 0)
                return lst; // If the list is empty or position is invalid, return the list unchanged

            if (num == 0)
                return lst.GetNext(); // Remove the head of the list

            IntNode current = lst;
            for (int i = 0; i < num - 1; i++)
            {
                if (current.GetNext() == null)
                    return lst; // If the position is out of bounds, return the list unchanged

                current = current.GetNext();
            }

            if (current.GetNext() != null)
                current.SetNext(current.GetNext().GetNext()); // Remove the nth node

            return lst;
        }

        //Q12
        public static IntNode ReturnAtPos(IntNode lst, int step)
        {
            if (lst == null || step < 0)
                return null; // If the list is empty or position is invalid, return null

            IntNode current = lst;
            for (int i = 0; i < step; i++)
            {
                if (current.GetNext() == null)
                    return null; // If the position is out of bounds, return null

                current = current.GetNext();
            }

            return current; // Return the node at the specified position
        }

        //Q13
        public static IntNode ReturnNum(IntNode lst, int num)
        {
            IntNode pos = lst;

            while (pos != null)
            {
                if (pos.GetValue() == num)
                    return pos;
                pos = pos.GetNext();
            }

            return null;
        }

        //Q14
        public static int Max(IntNode lst)
        {
            IntNode max = lst,
                    pos = max.GetNext();

            while (pos != null)
            {
                if (pos.GetValue() > max.GetValue())
                    max = pos;

                pos = pos.GetNext();
            }

            return max.GetValue();
        }

        //Q15
        public static IntNode Prev(IntNode lst, IntNode num)
        {
            if (lst == null || lst == num)
                return null; // If the list is empty or num is the head, there's no previous node

            IntNode current = lst;
            IntNode previous = null;

            while (current != null)
            {
                if (current.GetNext() == num)
                    return current; // Return the node before the given node

                previous = current;
                current = current.GetNext();
            }

            return null; // If num is not found in the list
        }

        public static void RunDemo()
        {
            IntNode n1 = new IntNode(14);
            IntNode n2 = new IntNode(24);
            IntNode n3 = new IntNode(34);
            IntNode n4 = new IntNode(44);
            IntNode n5 = new IntNode(54);

            n1.SetNext(n2);
            n2.SetNext(n3);
            n3.SetNext(n4);
            n4.SetNext(n5);

            Console.WriteLine("Check Q1:");
            Console.WriteLine("Sum - " + Sum(n1));
            Console.WriteLine();

            Console.WriteLine("Check Q2:");
            Console.WriteLine("IsExsist 10 - " + IsExsist(n1, 10));
            Console.WriteLine("IsExsist 24 - " + IsExsist(n1, 24));
            Console.WriteLine("IsExsist 30 - " + IsExsist(n1, 30));
            Console.WriteLine("IsExsist 44 - " + IsExsist(n1, 44));
            Console.WriteLine();

            Console.WriteLine("Check Q3:");
            IntNode num64 = new IntNode(64);
            Console.WriteLine("EnterLast num16 - ");
            EnterLast(n1, num64);
            PartA.Print(n1);
            Console.WriteLine();
            
            Console.WriteLine("Check Q4:");
            IntNode num14 = new IntNode(14);
            Console.WriteLine("EnterSecond num14 - ");
            EnterSecond(n1, num14);
            PartA.Print(n1);
            Console.WriteLine();
            
            Console.WriteLine("Check Q5:");
            Console.WriteLine("Size - " + Size(n1));
            Console.WriteLine();
            
            Console.WriteLine("Check Q6:");
            Console.WriteLine("HowMany 14 - " + HowMany(n1, 14));
            Console.WriteLine("HowMany 34 - " + HowMany(n1, 34));
            Console.WriteLine();
            
            Console.WriteLine("Check Q7:");
            Console.WriteLine("InOrder - " + InOrder(n1));
            Console.WriteLine();
            
            Console.WriteLine("Check Q8:");
            Console.WriteLine("SumOdd - " + SumOdd(n1));
            Console.WriteLine();
            
            Console.WriteLine("Check Q9:");
            Console.WriteLine("EnterInOrder 30 - ");
            EnterInOrder(n1, 30);
            PartA.Print(n1);
            Console.WriteLine();
            
            Console.WriteLine("Check Q10:");
            IntNode intNode = new IntNode(1, new IntNode(2, new IntNode(3, new IntNode(4, new IntNode(5)))));
            PartA.Print(n1);
            Console.WriteLine("IsSerial - " + IsSerial(n1));
            PartA.Print(intNode);
            Console.WriteLine("IsSerial - " + IsSerial(intNode));
            Console.WriteLine();

            Console.WriteLine("Check Q11:");
            Console.WriteLine("RemovePos 4 - ");
            PartA.Print(RemovePos(n1, 4));
            Console.WriteLine();
            
            Console.WriteLine("Check Q12:");
            Console.WriteLine("ReturnAtPos 3 - ");
            PartA.Print(ReturnAtPos(n1, 3));
            Console.WriteLine();
            
            Console.WriteLine("Check Q13:");
            Console.WriteLine("ReturnNum 30 - ");
            PartA.Print(ReturnNum(n1, 30));
            Console.WriteLine();

            Console.WriteLine("Check Q14:");
            Console.WriteLine("Max - " + Max(n1));
            Console.WriteLine();

            Console.WriteLine("Check Q15:");
            IntNode intNode2 = new IntNode(3, new IntNode(4, new IntNode(5)));
            Console.WriteLine("Prev - ");
            PartA.Print(Prev(n1, new IntNode(74)));
            Console.WriteLine();
        }
    }
}
