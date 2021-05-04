using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3.Part3
{
    class MachuPicchu : IWonder
    {
        public string Name { get; set; } = "Machu Picchu";
        public DateTime Сonstruction { get; set; } = new DateTime(1440, 2, 2);

        private void DoPrivateStuff()
        {
            Console.WriteLine("Holding inca in city!");
        }
        public void DoStuff()
        {
            Console.WriteLine($"{Name} - {Сonstruction.ToShortDateString()}");
        }
    }
}
