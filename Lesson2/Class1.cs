using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    public class Class1
    {
        // Q1
        static Node<int> CreateEventArr(Node<int> node, string order = "normal")
        {
            if (order != "normal" && order != "reverse") return null;
            Node<int> pos = node;

            // למצוא תערך הזוגי הראשון בשרשרת ולשמור אותו במשתנה, אם יש בכלל
            int num = 0;
            bool hesEvent = false;
            while (pos != null && !hesEvent)
            {
                if (pos.GetValue() % 2 == 0)
                {
                    num = pos.GetValue();
                    hesEvent = true;
                }

                pos = pos.GetNext();
            }
            // אם לא מצא בשרשרת ערך זוגי בכלל מחזיר ריק
            if (!hesEvent) return null;

            Node<int> arr = new Node<int>(num);
            Node<int> pos2 = arr;
            while (pos != null)
            {
                if (pos.GetValue() % 2 == 0)
                {
                    if (order == "normal")
                    {
                        // פתרון א
                        pos2.SetNext(new Node<int>(pos.GetValue()));
                        pos2 = pos2.GetNext();
                    }
                    else if (order == "reverse")
                    {
                        // פתרון ב
                        arr = new Node<int>(pos.GetValue(), arr);
                    }
                }

                pos = pos.GetNext();
            }
            return arr;
        }

        // יצירת שרשרת רדומלית
        static Node<int> CreateRndNode(int len, int maxValue, int minValue = 0)
        {
            Node<int>[] nodes = new Node<int>[len];

            // יצירת צמתים ובניית שרשרת
            for (int i = 0; i < nodes.Length; i++)
                nodes[i] = new Node<int>(PublicStaticOperations.rnd.Next(minValue, maxValue));
            
            return PublicStaticOperations.CreateNode(nodes);
        }

        // בדיקה שאלה 1
        public static void TestQ1()
        {
            // ראש השרשרת
            Node<int> headNode = CreateRndNode(PublicStaticOperations.rnd.Next(2, 11), 101);

            // הדפסה שרשרת מקורית
            Console.WriteLine("Original Node:");
            PublicStaticOperations.PrintNode(headNode);
            Console.WriteLine();

            // בדיקה והדפסה שרשרת פתרון א
            Console.WriteLine("Event Node:");
            Node<int> arrEvent = CreateEventArr(headNode);
            PublicStaticOperations.PrintNode(arrEvent);
            Console.WriteLine();

            // בדיקה והדפסה שרשרת פתרון ב
            Console.WriteLine("Event Node (reverse order):");
            Node<int> arrEvent2 = CreateEventArr(headNode, "reverse");
            PublicStaticOperations.PrintNode(arrEvent2);
            Console.WriteLine();
        }
    }
}
