using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3.Part3
{
    interface IWonder
    {
        string Name { get; set; }
        DateTime Сonstruction { get; set; }

        void DoStuff();
    }
}
