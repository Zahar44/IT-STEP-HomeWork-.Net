using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    static class Run
    {
        internal static void Test()
        {
            Car car = new Car
            {
                Name = "asd",
            };

            car.Power = 10;
            car.Acceleration(50);
            car.Power = 60;
            car.Acceleration(100);
            car.Stop();

            Car car2 = new Car();
            Car car3 = new Car();
            Car car4 = new Car();

            Console.WriteLine($"Cars count: {Car.CreatedCnt}");

            Car[] cars = new Car[5];
            for (int i = 0; i < cars.Length; i++)
            {
                cars[i] = new Car($"test {i + 1}");
            }
            for (int i = 0; i < cars.Length; i++)
            {
                Console.WriteLine(cars[i]);
            }
        }
    }
}
