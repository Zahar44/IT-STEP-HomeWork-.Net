using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4.Building
{
    class TeamLeader : IWorker
    {
        public string Name { get; set; }

        public void Work(House house)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            if(house.IsBuilted)
            {
                Console.WriteLine("House is builted!");
                return;
            }

            Console.WriteLine($"Basement is builted: {house.Basement.IsBuilted}");

            for (int i = 0; i < house.Walls.Length; i++)
            {
                if(house.Walls[i].IsBuilted == false)
                {
                    Console.WriteLine($"{i} walls are builted");
                    break;
                }
                if (i == house.Walls.Length - 1 && house.Walls[i].IsBuilted)
                    Console.WriteLine($"All walls are builted");

            }

            for (int i = 0; i < house.Windows.Length; i++)
            {
                if (house.Windows[i].IsBuilted == false)
                {
                    Console.WriteLine($"{i} windows are builted");
                    break;
                }
                if (i == house.Windows.Length - 1 && house.Windows[i].IsBuilted)
                    Console.WriteLine($"All windows are builted");
            }

            Console.WriteLine($"Door is builted: {house.Door.IsBuilted}");
            Console.WriteLine($"Roof is builted: {house.Roof.IsBuilted}");
            
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
