using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Stack_of_train_objects
{
    public class Train_car
    {
        private int id;
        private int numOfPassengers;
        private const int maxNumOfPassengers = 50;

        public int Id { get => id; set => id = value; }
        public int NumOfPassengers { get => numOfPassengers; set => numOfPassengers = ((value + maxNumOfPassengers) > 50) ? 50 : value; }

        public static int MaxNumOfPassengers => maxNumOfPassengers;

        public Train_car(int id, int numOfPassengers)
        {
            this.Id = id;
            this.NumOfPassengers = numOfPassengers;
        }

        public override string ToString()
        {
            return $"Train car {id} with {numOfPassengers} passengers.";
        }
    }
}
