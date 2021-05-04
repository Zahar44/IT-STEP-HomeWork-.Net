using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4.Building
{
    class Worker : IWorker
    {
        public string Name { get; set; }

        public void Work(House house)
        {
            var part = house.Next();
            Console.WriteLine($"{Name} is building {part.Name}");
            part.Build();

            if (part is Roof)
                house.IsBuilted = true;
        }
    }
}
