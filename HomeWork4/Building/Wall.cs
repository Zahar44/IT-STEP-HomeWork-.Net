using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork4.Building
{
    class Wall : IPart
    {
        public TimeSpan BuldingTime { get; set; } = new TimeSpan(3);
        public bool IsBuilted { get; set; } = false;

        public string Name { get; set; } = "wall";
        public void Build()
        {
            var time = BuldingTime.Ticks;

            Console.ForegroundColor = ConsoleColor.Blue;

            for (int i = 0; i < time; i++)
            {
                Console.WriteLine("Wall: Building...");
                Thread.Sleep(50);
            }
            Console.WriteLine("Wall: Finished");
            IsBuilted = true;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
