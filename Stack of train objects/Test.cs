using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_of_train_objects
{
    public class Test
    {
        public static void PrintColorText(string mes, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(mes);
            Console.ResetColor();
        }

        public static void RunTest()
        {
            Random rnd = new Random();
            int id = rnd.Next(100, 1000),
                yearOfManufacture = rnd.Next(2015, 2024),
                numOfPassengers;
            Train_locomotive trainLocomotive = new Train_locomotive(id, yearOfManufacture);
            Train train = new Train(trainLocomotive);

            Train_car train_Car;
            for (int i = 0; i < 10; i++)
            {
                numOfPassengers = rnd.Next(5, 51);
                train_Car = new Train_car(100 + i, numOfPassengers);
                train.Add(train_Car);
            }

            PrintColorText("The train that was created:", ConsoleColor.Red);
            Console.WriteLine(train);

            // בדיקת הסרה
            int n = rnd.Next(100, 110);
            train.Remove(n);
            Console.WriteLine();
            PrintColorText($"The train after removing car {n}:", ConsoleColor.Red);
            Console.WriteLine(train);


            // בדיקת צמצום
            id = rnd.Next(100, 1000);
            yearOfManufacture = rnd.Next(2015, 2024);
            Train_locomotive trainLocomotive2 = new Train_locomotive(id, yearOfManufacture);
            Train newTrain = train.Reduction(trainLocomotive2);
            Console.WriteLine();
            PrintColorText("The train after reducing:", ConsoleColor.Red);
            Console.WriteLine(train);
            Console.WriteLine();
            PrintColorText("The new train that received the empty cars:", ConsoleColor.Red);
            Console.WriteLine(newTrain);
        }
    }
}
