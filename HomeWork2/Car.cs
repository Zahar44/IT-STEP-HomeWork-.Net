using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork2
{
    class Car
    {
        private string number;
        private int power;
        private double price;
        private int speed;
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Number
        {
            get => number;
            set
            {
                if (value.Length < 6)
                    number = "unset";
                else
                    number = value;
            }
        }
        public double Price
        {
            get => price;
            set
            {
                if (value < 1)
                    throw new Exception("Price should be > 0");
                price = value;
            }
        }
        public int Power
        {
            get => power;
            set
            {
                if (value < 1)
                    throw new Exception("Power should be > 0");
                power = value;
            }
        }

        public static int CreatedCnt { get; set; }

        static Car()
        {
            CreatedCnt = 0;
        }
        public Car()
        {
            CreatedCnt++;
        }
        public Car(string _name, string _color = "unset", int _power = 100, double _price = 123)
        {
            Name = _name;
            Color = _color;
            Power = _power;
            Price = _price;
            Id = CreatedCnt++;
        }
        public void Acceleration(int _speed)
        {
            int _time = 0;
            for (int i = speed / 10; i < _speed / 10; i++)
            {
                Console.WriteLine($"Accelerating... Current speed: {i * 10}");
                Thread.Sleep(1000 / Power);
                _time += 1000 / Power;
            }
            speed = _speed;
            Console.WriteLine($"Accelerated! Current speed: {speed}\nTime spend {_time}\n");
        }
        public void Stop()
        {
            if (speed == 0)
                Console.WriteLine("Car already stopped");
            for (int i = speed / 10; i >= 0; i--)
            {
                Console.WriteLine($"Decelerating... Current speed: {i * 10}");
                Thread.Sleep(1000 / Power);
            }
            speed = 0;
            Console.WriteLine($"Car stopped!\n");
        }

        public override string ToString()
        {
            return $"{Id} - {Name} {Color} {Power} {Price}";
        }
    }
}
