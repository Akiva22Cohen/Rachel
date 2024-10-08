﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9
{
    public class Class2
    {
        public static Queue<int> CopyTor(Queue<int> queue)
        {
            Queue<int> temp = new Queue<int>();
            Queue<int> newQueue = new Queue<int>();

            while (!queue.IsEmpty())
                temp.Insert(queue.Remove());

            while (!temp.IsEmpty())
            {
                newQueue.Insert(temp.Head());
                queue.Insert(temp.Remove());
            }

            return newQueue;
        }

        public static void Run()
        {
            Random rnd = new Random();
            int len = rnd.Next(2, 20);

            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < len; queue.Insert(rnd.Next(100)), i++) ;

            Console.WriteLine("queue: " + queue);

            Console.WriteLine();
            Console.WriteLine("CopyTor(queue): " + CopyTor(queue));

            Console.WriteLine();
            Console.WriteLine("queue: " + queue);
        }
    }
}
