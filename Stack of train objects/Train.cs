using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Stack_of_train_objects
{
    public class Train
    {
        private Train_locomotive train_Locomotive;
        private Stack<Train_car> stack;
        private int currentNumOfWagons;

        public Train(Train_locomotive train_Locomotive)
        {
            this.train_Locomotive = train_Locomotive;
            stack = new Stack<Train_car>();
            currentNumOfWagons = 0;
        }

        public void Add(Train_car train_car)
        {
            stack.Push(train_car);
            currentNumOfWagons++;
        }

        public void Remove(int id)
        {
            Stack<Train_car> temp = new Stack<Train_car>();
            Train_car train_Car;
            while (!stack.IsEmpty())
            {
                train_Car = stack.Pop();
                if (!(train_Car.Id == id))
                    temp.Push(train_Car);
                else
                    currentNumOfWagons--;
            }

            while (!temp.IsEmpty())
                stack.Push(temp.Pop());
        }

        public Train Reduction(Train_locomotive train_Locomotive)
        {
            Train train = new Train(train_Locomotive);
            Stack<Train_car> temp = new Stack<Train_car>();
            Stack<Train_car> newStark = new Stack<Train_car>();
            int sum = 0;

            // סוכם את כל הנוסעים שיש ברכבת
            while (!stack.IsEmpty())
            {
                sum += stack.Top().NumOfPassengers;
                stack.Top().NumOfPassengers = 0;
                temp.Push(stack.Pop());
            }

            while (!temp.IsEmpty())
                stack.Push(temp.Pop());

            int x = sum / Train_car.MaxNumOfPassengers, // בודק כמה קרונות מלאים יש שאפשר למלאות
                y = sum % Train_car.MaxNumOfPassengers; // בודק אם יש שארית, אם צריך עוד קרון בשביל היתר שנשאר

            // מעמיס קרונות מלאים
            for (int i = 0; i < x; i++)
            {
                stack.Top().NumOfPassengers = 50;
                temp.Push(stack.Pop());
            }

            // מוסיף את שארית הנוסעים שנשארו, אם צריך
            if (!stack.IsEmpty())
            {
                stack.Top().NumOfPassengers = y;
                temp.Push(stack.Pop());
            }

            while (!temp.IsEmpty())
                stack.Push(temp.Pop());

            // מעיף את הקרונות הרקים לרכבת החדשה
            while (!stack.IsEmpty())
            {
                if (stack.Top().NumOfPassengers == 0)
                {
                    newStark.Push(stack.Pop());
                    currentNumOfWagons--;
                }
                else
                    temp.Push(stack.Pop());
            }

            while (!temp.IsEmpty())
                stack.Push(temp.Pop());

            while (!newStark.IsEmpty())
                train.Add(newStark.Pop());

            return train;
        }

        public override string ToString()
        {
            Stack<Train_car> temp = new Stack<Train_car>();
            Train_car train_Car;

            string str = "";
            str += train_Locomotive.ToString();
            str += $"\nThere are {currentNumOfWagons} train cars:\n";

            for (int i = 0; i < currentNumOfWagons; i++)
            {
                train_Car = stack.Top();
                str += "\t" + train_Car.ToString() + "\n";
                temp.Push(stack.Pop());
            }

            while (!temp.IsEmpty())
                stack.Push(temp.Pop());

            return str;
        }

    }
}
