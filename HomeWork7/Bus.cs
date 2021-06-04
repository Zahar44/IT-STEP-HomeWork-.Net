using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{
    class Bus : Car
    {
        public Bus()
        {
            Speed = 30;
        }

        public override int Drive(int x)
        {
            return base.Drive(x);
        }

        public override void Finish(object sender, FinishEventArg e)
        {
            if (e.Winner)
            {
                //Console.WriteLine($"{nameof(Bus)} is winner!");
            }
        }
    }
}
