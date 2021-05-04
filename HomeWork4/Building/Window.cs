using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork4.Building
{
    class Window : IPart
    {
        public TimeSpan BuldingTime { get; set; } = new TimeSpan(2);
        public bool IsBuilted { get; set; } = false;

        public string Name { get; set; } = "window";
        public void Build()
        {
            var time = BuldingTime.Ticks;

            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < time; i++)
            {
                Console.WriteLine("Window: Building...");
                Thread.Sleep(50);
            }
            Console.WriteLine("Window: Finished");
            IsBuilted = true;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
