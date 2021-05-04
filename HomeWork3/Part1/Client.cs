using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Client
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ClientType Type { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public int OrdersAmount { get; set; }
        public int FullPrice { get; set; }
    }
}
