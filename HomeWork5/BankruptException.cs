using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    class BankruptException : Exception
    {
        public override string Message => "Money cannot be negative number";

    }
}
