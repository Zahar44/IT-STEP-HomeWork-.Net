using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork4.Building
{
    class Basement : IPart
    {
        public TimeSpan BuldingTime { get; set; } = new TimeSpan(10);
        public bool IsBuilted { get; set; } = false;
        public string Name { get; set; } = "basement";

        public void Build()
        {
            var time = BuldingTime.Ticks;

            Console.ForegroundColor = ConsoleColor.Gray;

            for (int i = 0; i < time; i++)
            {
                Console.WriteLine("Basement: Building...");
                Thread.Sleep(50);
            }
            Console.WriteLine("Basement: Finished");
            IsBuilted = true;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
