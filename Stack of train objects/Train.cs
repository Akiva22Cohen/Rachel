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
                {
                    temp.Push(train_Car);
                }
                else
                    currentNumOfWagons--;
            }

            while (!temp.IsEmpty())
                stack.Push(stack.Pop());
        } 

        public Train Reduction(Train_locomotive train_Locomotive)
        {
            Train train = new Train(train_Locomotive);
            Stack<Train_car> temp = new Stack<Train_car>();
            Stack<Train_car> newStark = new Stack<Train_car>();
            int sum = 0;

            while (!stack.IsEmpty())
            {
                sum += stack.Top().NumOfPassengers;
                temp.Push(stack.Pop());
            }

            while (!temp.IsEmpty())
                stack.Push(temp.Pop());

            int x = sum / Train_car.MaxNumOfPassengers,
                y = sum % Train_car.MaxNumOfPassengers;

            for (int i = 0; i < x; i++)
            {
                stack.Top().NumOfPassengers = 50;
                temp.Push(stack.Pop());
            }

            if (!stack.IsEmpty())
            {
                stack.Top().NumOfPassengers = y;
                temp.Push(stack.Pop());
            }

            while (!temp.IsEmpty())
                stack.Push(temp.Pop());

            while (!stack.IsEmpty())
            {
                if (stack.Top().NumOfPassengers == 0)
                    newStark.Push(stack.Pop());
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
            return $"";
        }

    }
}
