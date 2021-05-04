using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    enum Priority
    {
        Lowest = -2,
        Low = -1,
        Average = 0,
        Hight = 1,
        Highest = 2,
    }
    class ClientType
    {
        public Priority Priority { get; set; } = Priority.Average; // default
        public string Description { get; set; }
    }
}
