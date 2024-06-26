using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    public class Class3
    {
        public static Node<Garbage> EmptyingGarbage(Node<Garbage> garbages)
        {
            Node<Garbage> newGarbage = null;
            Node<Garbage> posNewGarbage;
            Node<Garbage> pos = garbages;

            double capacity, quantity;

            while (pos != null)
            {
                capacity = pos.GetValue().GetCapacity();
                quantity = pos.GetValue().GetQuantity();

                if ((quantity / capacity * 100) >= 80)
                {
                    if(newGarbage == null)
                    {
                        newGarbage = new Node<Garbage>(new Garbage(pos.GetValue()));
                        posNewGarbage = newGarbage;
                    }
                    else
                    {
                        newGarbage.SetNext(new Node<Garbage>(new Garbage(pos.GetValue())));
                        posNewGarbage = newGarbage.GetNext();
                    }
                }
                pos = pos.GetNext();
            }

            return newGarbage;
        }

        public static Node<Garbage> BinsOfNeighborhood(Node<Garbage> garbages, string neighbor)
        {
            Node<Garbage> newGarbage = new Node<Garbage>(new Garbage("", 0, 0, ""));
            Node<Garbage> posNewGarbage = newGarbage;
            Node<Garbage> pos = garbages;

            string neighborhood;

            while (pos != null)
            {
                neighborhood = pos.GetValue().GetNeighbor();
                if (neighborhood.Equals(neighbor))
                {
                    posNewGarbage.SetNext(new Node<Garbage>(new Garbage(pos.GetValue())));
                    posNewGarbage = posNewGarbage.GetNext();
                }
                pos = pos.GetNext();
            }

            newGarbage = newGarbage.GetNext();
            return newGarbage;
        }
        
        public static Node<Garbage> SmallBins(Node<Garbage> garbages)
        {
            Node<Garbage> newGarbage = new Node<Garbage>(new Garbage("", 0, 0, ""));
            Node<Garbage> posNewGarbage = newGarbage;
            Node<Garbage> pos = garbages;

            double capacity;

            while (pos != null)
            {
                capacity = pos.GetValue().GetCapacity();
                if (capacity < 1000)
                {
                    posNewGarbage.SetNext(new Node<Garbage>(new Garbage(pos.GetValue())));
                    posNewGarbage = posNewGarbage.GetNext();
                }
                pos = pos.GetNext();
            }

            newGarbage = newGarbage.GetNext();
            return newGarbage;
        }

        public static int CountNode(Node<Garbage> a)
        {
            int count = 0;

            while (a != null)
            {
                count++;
                a = a.GetNext();
            }

            return count;
        }

        public static string MaxNeighborhood(Node<Garbage> garbages)
        {
            Node<Garbage> pos = garbages;

            string maxNeighbor = pos.GetValue().GetNeighbor();
            int maxGarbage = CountNode(BinsOfNeighborhood(garbages, maxNeighbor));
            pos = pos.GetNext();

            string neighbor;
            int temp;
            while (pos != null)
            {
                neighbor = pos.GetValue().GetNeighbor();
                temp = CountNode(BinsOfNeighborhood(garbages, neighbor));
                if (temp > maxGarbage)
                {
                    maxGarbage = temp;
                    maxNeighbor = neighbor;
                }
                pos = pos.GetNext();
            }

            return maxNeighbor;
        }

        public static void PrintNode(Node<Garbage> lst)
        {
            if (lst == null)
            {
                Console.WriteLine("The Node is empty!");
                return;
            }
            Node<Garbage> pos = lst;

            while (pos.HasNext())
            {
                Console.WriteLine(pos.GetValue().ToString());
                pos = pos.GetNext();
            }
            Console.WriteLine(pos.GetValue().ToString());
            Console.WriteLine();
        }

        public static void RunTestQ3()
        {
            int arraySize = 20; // Define the size of the array
            Node<Garbage>[] garbages = new Node<Garbage>[arraySize];
            Random random = new Random();

            // Initialize each element in the array with dynamic details
            for (int i = 0; i < arraySize; i++)
            {
                string num = "G" + (i + 1);
                double capacity = random.Next(500, 1510); // Capacity between 50 and 150
                double quantity = random.NextDouble() * capacity; // Quantity between 0 and capacity
                string neighbor = "Neighbor" + (random.Next(1, 6)); // Random neighbor between 1 and 5

                Garbage garbage = new Garbage(num, capacity, quantity, neighbor);
                garbages[i] = new Node<Garbage>(garbage);
            }

            for (int i = 0; i < arraySize - 1; i++) 
                garbages[i].SetNext(garbages[i + 1]);

            Node<Garbage> head = garbages[0];

            PrintNode(garbages[0]);
            PrintNode(EmptyingGarbage(head));
            PrintNode(SmallBins(head));
            Console.WriteLine(MaxNeighborhood(head));
        }

    }
}
