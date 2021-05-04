using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4.Building
{
    interface IPart
    {
        TimeSpan BuldingTime { get; set; }

        string Name { get; set; }

        bool IsBuilted { get; set; }

        void Build();
    }
}
