using NUnit.Framework;
using MTG;
using System.Linq;

namespace mtg_tests
{
    public class Tests
    {
        public Deck deck = new Deck(new[] {
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

        public Deck PredictableDeck = new Deck(new[] {
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

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConsistentMetaDecksTest()
        {
            var meta1 = new MetaDeck(deck, c => c);
            deck.Shuffle();
            var meta2 = new MetaDeck(deck, c => c);

            Assert.IsTrue(meta1.deckDistribution.Count == meta2.deckDistribution.Count && ! meta1.deckDistribution.Except(meta2.deckDistribution).Any());
        }

        [Test]
        public void ConsistentHandDistribution()
        {
            var metadeck1 = new MetaDeck(deck, c => c);
            var handDistribution1 = metadeck1.HandDistribution();
            deck.Shuffle();
            var metadeck2 = new MetaDeck(deck, c => c);
            var handDistribution2 = metadeck2.HandDistribution();

            Assert.IsTrue(handDistribution1.Count == handDistribution2.Count);
            Assert.IsTrue(!handDistribution1.Except(handDistribution2).Any());
        
        }

         [Test]
        public void RightMicrostates()
        {

            var metadeck1 = new MetaDeck(PredictableDeck, c => c);
            var handDistribution1 = metadeck1.HandDistribution();

            System.Console.WriteLine(handDistribution1);
            Assert.IsTrue(handDistribution1.Count > 0);
        
        }
    }
}