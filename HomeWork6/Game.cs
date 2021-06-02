using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork6
{
    class Game
    {
        private const int playerCapacity = 2;
        private const int deckCapacity = 36;

        public int Speed { get; set; }

        public List<Player> Players { get; private set; }
        public Deck Deck { get; private set; }

        public Game()
        {
            Players = new List<Player>(playerCapacity);
            Deck = new Deck { Cards = new List<Card>(deckCapacity) };
            InitDeck();
        }

        public void InitPlayers(Player first, Player second)
        {
            if (Players.Count > 0)
                throw new InvalidOperationException("Players already initialized");

            Players.AddRange(new Player[] { first, second });
            SetCardsToPlayers();
        }

        public void Display()
        {
            // With StringBuilder I can't change color of cards :(

            Console.Clear();
            Console.WriteLine($"{Players[0]}\t|\tDesk\t\t|\t{Players[1]}");
            var size = Math.Max(Players[0].Deck.Cards.Count,
                Math.Max(Players[1].Deck.Cards.Count,
                Deck.Cards.Count));

            for (int i = 0; i < size; i++)
            {
                TryToShow(Players[0].Deck, i);
                Console.Write("\t|\t");
                TryToShow(Deck, i);
                Console.Write("\t\t|\t");
                TryToShow(Players[1].Deck, i);
                Console.Write('\n');
            }
        }

        public void Play()
        {
            Player winner = null;

            while (winner is null)
            {
                Play(Players);
                winner = FindWinner();
            }

            Console.WriteLine($"\n\nWinner is: {winner}!!!");
        }

        private void Play(List<Player> players)
        {
            foreach (var p in players)
            {
                Play(p);
                Thread.Sleep(Speed);
            }
        }

        private void Play(Player p)
        {
            if (p.Deck.Cards.Count == 0)
                return;

            var playerCard = p.Deck.Cards[0];
            var deckCardValue = Deck.Cards.Count > 0 ? Deck.Cards.Last().Value : 0;

            Deck.Cards.Add(playerCard);
            p.Deck.Cards.Remove(playerCard);

            if (playerCard.Value < deckCardValue)
            {
                p.Deck.Cards.AddRange(Deck.Cards);
                Deck.Cards.Clear();
            }

            Display();
        }

        private Player FindWinner()
        {
            foreach (var player in Players)
            {
                if (player.Deck.Cards.Count == deckCapacity)
                    return player;
            }
            return null;
        }

        private void SetCardsToPlayers()
        {
            foreach (var player in Players)
            {
                player.Deck.Cards.AddRange(GetInitCardsForPlayer());
            }

            Display();
        }

        private List<Card> GetInitCardsForPlayer()
        {
            var resSize = deckCapacity / playerCapacity;
            var res = new List<Card>(resSize);
            var random = new Random();

            for (int i = 0; i < resSize; i++)
            {
                var card = Deck.Cards[random.Next(0, Deck.Cards.Count)];
                res.Add(card);
                Deck.Cards.Remove(card);
            }

            return res;
        }

        private void InitDeck()
        {
            Card.CardState cardState = Card.CardState.Six;
            Card.Suit cardSiut = 0;

            for (int i = 0; i < deckCapacity; i++)
            {
                Deck.Cards.Add(new Card(cardState, cardSiut++));
                if((int)cardSiut > 3)
                {
                    cardState++;
                    cardSiut = 0;
                }
            }
        }
        private void TryToShow(Deck deck, int i)
        {
            if (deck.Cards.Count <= i)
                return;

            deck.Cards[i].DisplayOnConsole();
        }
    }
}
