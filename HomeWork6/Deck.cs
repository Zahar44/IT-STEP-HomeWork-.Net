using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    class Deck
    {
        public List<Card> Cards { get; set; }

        public Deck()
        {
            Cards = new List<Card>();
        }

        public void RandomShuffle()
        {
            var random = new Random();
            for (int i = Cards.Count - 1; i > 0; i--)
            {
                int randomIndex = random.Next(0, i + 1);

                Card temp = Cards[i];
                Cards[i] = Cards[randomIndex];
                Cards[randomIndex] = temp;
            }
        }

        public void DisplayAllCards()
        {
            foreach (var card in Cards)
            {
                card.DisplayOnConsole();
            }
        }
    }
}
