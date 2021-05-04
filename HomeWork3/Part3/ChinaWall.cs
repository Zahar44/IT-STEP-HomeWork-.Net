using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork3.Part3
{
    class ChinaWall : IWonder
    {
        public string Name { get; set; } = "Great Wall of China";
        public DateTime Сonstruction { get; set; } = new DateTime(1368, 2, 12);

        private void BuildTheWall()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Building of Great wall...");
                Thread.Sleep(50);
            }
        }
        public void DoStuff()
        {
            BuildTheWall();
            Console.WriteLine($"{Name} is built! It was built at {Сonstruction.ToShortDateString()}, and was building around 200 years!");
        }
    }
}
