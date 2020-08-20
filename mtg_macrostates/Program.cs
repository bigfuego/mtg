using System;
using System.Linq;

namespace MTG
{
    class Program
    {
        static void Main(string[] args)
        {
            var Deck = new Deck(new[] {
                new Card{CardType=CardType.PLAINS},
                new Card{CardType=CardType.PLAINS},
                new Card{CardType=CardType.PLAINS},
                new Card{CardType=CardType.PLAINS},
                new Card{CardType=CardType.PLAINS},
                new Card{CardType=CardType.PLAINS},
                new Card{CardType=CardType.PLAINS},
                new Card{CardType=CardType.PLAINS},
                new Card{CardType=CardType.PLAINS},
                new Card{CardType=CardType.PLAINS},
                new Card{CardType=CardType.PLAINS},
                new Card{CardType=CardType.PLAINS},
                new Card{CardType=CardType.PLAINS},
                new Card{CardType=CardType.PLAINS},
                new Card{CardType=CardType.PLAINS},
                new Card{CardType=CardType.PLAINS},
                new Card{CardType=CardType.PLAINS},
                new Card{CardType=CardType.PLAINS},
                new Card{CardType=CardType.PLAINS},
                new Card{CardType=CardType.PLAINS},
                new Card{CardType=CardType.PLAINS},
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

            var morePredictableDeck =  new Deck(new[] {
                new Card{CardType=CardType.PLAINS},
                new Card{CardType=CardType.NONLAND, Cost=1},
                new Card{CardType=CardType.NONLAND, Cost=1},
                new Card{CardType=CardType.NONLAND, Cost=1},
                new Card{CardType=CardType.NONLAND, Cost=1},
                new Card{CardType=CardType.NONLAND, Cost=1},
                new Card{CardType=CardType.NONLAND, Cost=1},
                new Card{CardType=CardType.NONLAND, Cost=1},
                new Card{CardType=CardType.NONLAND, Cost=2},
                new Card{CardType=CardType.NONLAND, Cost=2},
                
            });

            var probabilityCalculator = new ManaTurnProbabilityCalculator(Deck, c => c.Cost);
            probabilityCalculator.SimulateTurn();
            probabilityCalculator.SimulateTurn();
            //probabilityCalculator.SimulateTurn();
            //probabilityCalculator.SimulateTurn();

            var stats = probabilityCalculator.Stats;
            var landStats = stats.GetLandStats();
            var spendStats = stats.GetSpendStats();

            var count = 0;
            foreach(var turn in landStats)
            {
                System.Console.WriteLine(count);
                count++;
                foreach(var land in turn.OrderBy(x => x.Key))
                {
                    System.Console.WriteLine($"{land.Key}: {land.Value}");
                }
            }
            
            count = 0;
            foreach(var turn in spendStats)
            {
                System.Console.WriteLine(count);
                count++;
                foreach(var spend in turn.OrderBy(x => x.Key))
                {
                    System.Console.WriteLine($"{spend.Key}: {spend.Value}");
                }
            }

        }
    }
}
