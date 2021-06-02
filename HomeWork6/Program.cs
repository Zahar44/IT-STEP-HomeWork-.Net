using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game { Speed = 100 };
            Player p1 = new Player { Name = "Bob" };
            Player p2 = new Player { Name = "Jon" };
            
            game.Deck.RandomShuffle();
            game.InitPlayers(p1, p2);

            game.Play();
        }
    }
}
