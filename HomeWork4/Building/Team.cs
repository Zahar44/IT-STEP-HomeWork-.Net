using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4.Building
{
    class Team
    {
        IWorker[] Workers;
        House House { get; set; }

        public Team(IWorker worker1, IWorker worker2, IWorker worker3, House house)
        {
            Workers = new IWorker[3];
            Workers[0] = worker1;
            Workers[1] = worker2;
            Workers[2] = worker3;
            House = house;
        }

        public void Work()
        {
            int i = 0;
            while(!House.IsBuilted)
            {
                Workers[i++].Work(House);
                if (i == Workers.Length)
                    i = 0;
            }
        }
    }
}
