using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork4.Building
{
    class Roof : IPart
    {
        public TimeSpan BuldingTime { get; set; } = new TimeSpan(4);
        public bool IsBuilted { get; set; } = false;

        public string Name { get; set; } = "roof";
        public void Build()
        {
            var time = BuldingTime.Ticks;

            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i < time; i++)
            {
                Console.WriteLine("Roof: Building...");
                Thread.Sleep(50);
            }
            Console.WriteLine("Roof: Finished");
            IsBuilted = true;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
