using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MTG
{
    public class Deck
    {
        public List<Card> Cards { get; set; }
        public int Count => Cards.Count;

        public Deck(IEnumerable<Card> cards)
        {
            Cards = cards.ToList();
            Shuffle();
        }

        static Random _random = new Random();
        public void Shuffle()
        {
            int n = Cards.Count;
            for (int i = 0; i < (n - 1); i++)
            {

                int r = i + _random.Next(n - i);
                var t = Cards[r];
                Cards[r] = Cards[i];
                Cards[i] = t;
            }
        }
    }
}