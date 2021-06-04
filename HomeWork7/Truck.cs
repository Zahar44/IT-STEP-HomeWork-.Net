using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{
    class Truck : Car
    {
        public Truck()
        {
            Speed = 50;
        }

        public override int Drive(int x)
        {
            return base.Drive(x);
        }

        public override void Finish(object sender, FinishEventArg e)
        {
            if (e.Winner)
            {
                //Console.WriteLine($"{nameof(Truck)} is winner!");
            }
        }
    }
}
