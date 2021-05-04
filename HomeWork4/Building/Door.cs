using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork4.Building
{
    class Door : IPart
    {
        public TimeSpan BuldingTime { get; set; } = new TimeSpan(1);

        public string Name { get; set; } = "door";
        public bool IsBuilted { get; set; } = false;

        public void Build()
        {
            var time = BuldingTime.Ticks;
            
            Console.ForegroundColor = ConsoleColor.DarkGray;

            for (int i = 0; i < time; i++)
            {
                Console.WriteLine("Door: Building...");
                Thread.Sleep(50);
            }
            Console.WriteLine("Door: Finished");
            IsBuilted = true;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
