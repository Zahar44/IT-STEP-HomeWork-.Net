using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{
    class DB
    {
        public static List<Car> GetCars()
        {
            return new List<Car>
            {
                new Bus{ Name = "@" },
                new Truck{ Name = "#" },
                new LightCar{ Name = "%" },
                new SportCar{ Name = "$" },
            };
        }

    }
}
