using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork7
{
    class Game
    {
        private delegate int DriveRace(int x);
        private DriveRace StartRace;
        private bool running;

        public event Car.FinishDelegate FinishEvent;

        public int TraceLength { get; set; }

        public int Speed { get; set; }

        //private List<Car> cars;

        public Game(Car car)
        {
            StartRace = new DriveRace(car.Drive);
            FinishEvent += car.Finish;
        }

        public Game(List<Car> cars)
        {
            StartRace = new DriveRace(cars.First().Drive);
            FinishEvent += cars.First().Finish;

            for (int i = 1; i < cars.Count; i++)
            {
                AddCar(cars[i]);
            }
        }

        public void AddCar(Car car)
        {
            //cars.Add(car);
            StartRace += car.Drive;
            FinishEvent += car.Finish;
        }

        public void AddCar(List<Car> cars)
        {
            //cars.Add(car);
            foreach (var car in cars)
            {
                StartRace += car.Drive;
                FinishEvent += car.Finish;
            }
        }

        public void BeginRace()
        {
            running = true;
            DrowRace();
            while (running)
            {
                Thread.Sleep(Speed);
                Race();
            }
        }

        private void Race()
        {
            int i = 0;
            foreach (var item in StartRace.GetInvocationList())
            {
                var response = item.DynamicInvoke((3 * i++) + 1);
                if ((int)response > TraceLength)
                    Finish();
            }
        }

        private void Finish()
        {
            FinishEvent?.Invoke(this, new FinishEventArg { Winner = false });
            running = false;

            Console.WriteLine();
        }

        private void DrowRace()
        {
            int carCount = StartRace.GetInvocationList().Length;
            
            for (int i = 0; i < carCount + 1; i++)
            {
                DrowBorder(i * 3);
            }
        }

        private void DrowBorder(int x)
        {
            for (int i = 0; i < TraceLength; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write("|");
            }
        }
    }
}
