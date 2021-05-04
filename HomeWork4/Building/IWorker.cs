using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4.Building
{
    interface IWorker
    {
        string Name { get; set; }

        void Work(House house);
    }
}
