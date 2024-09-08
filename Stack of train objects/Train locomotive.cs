using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_of_train_objects
{
    public class Train_locomotive
    {
        private int id;
        private int yearOfManufacture;

        public Train_locomotive(int id, int yearOfManufacture)
        {
            this.Id = id;
            YearOfManufacture = yearOfManufacture;
        }

        public int Id { get => id; set => id = value; }
        public int YearOfManufacture { get => yearOfManufacture; set => yearOfManufacture = value; }

        public override string ToString()
        {
            return $"Train locomotive {id} was created in {yearOfManufacture}.";
        }
    }
}
