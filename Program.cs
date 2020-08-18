using System;

namespace MTG
{
    class Program
    {
        static void Main(string[] args)
        {
            var Deck = new Deck(new[] {
                new Card{CardType=CardType.LAND},
                new Card{CardType=CardType.LAND},
                new Card{CardType=CardType.LAND},
                new Card{CardType=CardType.LAND},
                new Card{CardType=CardType.LAND},
                new Card{CardType=CardType.LAND},
                new Card{CardType=CardType.LAND},
                new Card{CardType=CardType.LAND},
                new Card{CardType=CardType.LAND},
                new Card{CardType=CardType.LAND},
                new Card{CardType=CardType.LAND},
                new Card{CardType=CardType.LAND},
                new Card{CardType=CardType.LAND},
                new Card{CardType=CardType.LAND},
                new Card{CardType=CardType.LAND},
                new Card{CardType=CardType.LAND},
                new Card{CardType=CardType.LAND},
                new Card{CardType=CardType.LAND},
                new Card{CardType=CardType.LAND},
                new Card{CardType=CardType.LAND},
                new Card{CardType=CardType.LAND},
                new Card{CardType=CardType.NONLAND, Cost=1},
                new Card{CardType=CardType.NONLAND, Cost=1},
                new Card{CardType=CardType.NONLAND, Cost=1},
                new Card{CardType=CardType.NONLAND, Cost=1},
                new Card{CardType=CardType.NONLAND, Cost=8},
                new Card{CardType=CardType.NONLAND, Cost=8},
                new Card{CardType=CardType.NONLAND, Cost=2},
                new Card{CardType=CardType.NONLAND, Cost=2},
                new Card{CardType=CardType.NONLAND, Cost=2},
                new Card{CardType=CardType.NONLAND, Cost=2},
                new Card{CardType=CardType.NONLAND, Cost=2},
                new Card{CardType=CardType.NONLAND, Cost=2},
                new Card{CardType=CardType.NONLAND, Cost=2},
                new Card{CardType=CardType.NONLAND, Cost=2},
                new Card{CardType=CardType.NONLAND, Cost=3},
                new Card{CardType=CardType.NONLAND, Cost=3},
                new Card{CardType=CardType.NONLAND, Cost=3},
                new Card{CardType=CardType.NONLAND, Cost=3},
                new Card{CardType=CardType.NONLAND, Cost=3},
                new Card{CardType=CardType.NONLAND, Cost=3},
                new Card{CardType=CardType.NONLAND, Cost=3},
                new Card{CardType=CardType.NONLAND, Cost=3},
                new Card{CardType=CardType.NONLAND, Cost=10},
                new Card{CardType=CardType.NONLAND, Cost=9},
                new Card{CardType=CardType.NONLAND, Cost=3},
                new Card{CardType=CardType.NONLAND, Cost=3},
                new Card{CardType=CardType.NONLAND, Cost=3},
                new Card{CardType=CardType.NONLAND, Cost=4},
                new Card{CardType=CardType.NONLAND, Cost=4},
                new Card{CardType=CardType.NONLAND, Cost=4},
                new Card{CardType=CardType.NONLAND, Cost=4},
                new Card{CardType=CardType.NONLAND, Cost=5},
                new Card{CardType=CardType.NONLAND, Cost=5},
                new Card{CardType=CardType.NONLAND, Cost=5},
                new Card{CardType=CardType.NONLAND, Cost=5},
                new Card{CardType=CardType.NONLAND, Cost=5},
                new Card{CardType=CardType.NONLAND, Cost=5},
                new Card{CardType=CardType.NONLAND, Cost=6},
                new Card{CardType=CardType.NONLAND, Cost=6},
                new Card{CardType=CardType.NONLAND, Cost=6},
                new Card{CardType=CardType.NONLAND, Cost=7},



            });

            var probabilityCalculator = new ManaTurnProbabilityCalculator(Deck, c => c.Cost);
            probabilityCalculator.SimulateTurn();
            {
                System.Console.WriteLine(kvp.Key);
                System.Console.WriteLine((kvp.Value));
            }
        }
    }
}
