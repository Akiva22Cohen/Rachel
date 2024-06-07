using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    public class PartA
    {
        public static void Print(IntNode lst)
        {
            IntNode pos = lst;

            while (pos != null)
            {
                // הדפס את האיבר
                Console.Write(pos.GetValue() + " --> ");
                // עבור לאיבר הבא
                pos = pos.GetNext();
            }

            Console.WriteLine();
        }

        public static void RunDemo()
        {
            //חלק א
            IntNode n1 = new IntNode(14);
            IntNode n2 = new IntNode(24);
            IntNode n3 = new IntNode(34);
            IntNode n4 = new IntNode(44);
            IntNode n5 = new IntNode(54);

            n1.SetNext(n2);
            n2.SetNext(n3);
            n3.SetNext(n4);
            n4.SetNext(n5);

            //Q1:
            //Draw the list.
            // n1 -> n2 -> n3 -> n4 -> n5
            // 14 -> 24 -> 34 -> 44 -> 54

            //Q2:
            //Print the list.
            Console.WriteLine("Q2:");
            Print(n1);
            Console.WriteLine();

            //Q3:
            //Create another link with the value 19.
            IntNode n6 = new IntNode(19);

            //Q4:
            //Add the link to the end of the list and print the list.
            n5.SetNext(n6);
            Console.WriteLine("Q4:");
            Print(n1);
            Console.WriteLine();


            //Q5:
            //Create another link with the value 23.
            IntNode newNode23 = new IntNode(23);

            //Q6:
            //Add the link to the second place on the list (after the 14th) and print the list.
            newNode23.SetNext(n1.GetNext()); // newNode's next is n2
            n1.SetNext(newNode23); // n1's next is newNode
            Console.WriteLine("Q6:");
            Print(n1);
            Console.WriteLine();

            //Q7:
            //Create another link with the value 63.
            IntNode newNode63 = new IntNode(63);

            //Q8:
            //Add the link to the top of the list (before the 14) and print the list.
            newNode63.SetNext(n1);
            Console.WriteLine("Q8:");
            Print(newNode63);
            Console.WriteLine();

            //Q9:
            //Remove the link n3 from the list and print the list.
            n2.SetNext(n4);
            Console.WriteLine("Q9:");
            Print(newNode63);
            Console.WriteLine();

            //Q10:
            //Change the value of the first link to 11 and print the list.
            newNode63.SetValue(11);
            Console.WriteLine("Q10:");
            Print(newNode63);
            Console.WriteLine();
        }
    }
}
