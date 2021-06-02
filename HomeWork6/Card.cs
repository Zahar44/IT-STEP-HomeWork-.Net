using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    class Card
    {
        public enum CardState
        {
            Six = 6,
            Seven = 7,
            Eigth = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Lady = 12,
            King = 13,
            Ace = 14
        }

        public enum Suit
        {
            Hearts = 0,
            Tiles = 1,
            Clovers = 2,
            Pikes = 3
        }

        public CardState State { get; private set; }

        public Suit Type { get; private set; }

        public int Value => (int)State;

        public Card(CardState state, Suit type)
        {
            State = state;
            Type = type;
        }

        public void DisplayOnConsole()
        {
            if (Type == Suit.Hearts || Type == Suit.Tiles)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write(this.ToString());
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override string ToString()
        {
            return $"{State} {Type.ToString().First()}";
        }
    }
}
