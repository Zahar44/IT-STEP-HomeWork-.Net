using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    class Player
    {
        public string Name { get; set; }

        public Deck Deck { get; set; }

        public Player()
        {
            Deck = new Deck();
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
