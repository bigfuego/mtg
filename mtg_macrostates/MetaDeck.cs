using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MTG
{
    public class MetaDeck
    {
        public Dictionary<Card, int> deckDistribution = null;
        public int Count;

        public MetaDeck(Deck deck, Func<Card, Card> groupBy)
        {
            this.Count = deck.Count;
            deckDistribution = deck.Cards.GroupBy(groupBy).ToDictionary(g => g.Key, g => g.Count());
        }

        public BigInteger HandMicrostates(Hand hand)
        {
            var keys = deckDistribution.Keys;
            return keys.Aggregate(new BigInteger(1), (c, n) =>  c*Utils.NChooseK(deckDistribution[n], hand.Count(n)));
        }

        public Dictionary<Hand, BigInteger> HandDistribution()
        {
            var hands = new List<Hand>{new Hand()};
            var finishedHands = new List<Hand>();
            foreach (var uniqueProperty in deckDistribution.Where(p => p.Value > 0))
            {
                var toAdd = new List<Hand>();

                foreach (var hand in hands)
                {
                    for (int i = 1; i <= Math.Min(uniqueProperty.Value, Globals.HAND_SIZE - hand.Count()); i++)
                    {      
                        if (i < Globals.HAND_SIZE - hand.Count())  
                            toAdd.Add(hand.Clone().Add(uniqueProperty.Key, i));
                        else
                        {
                            finishedHands.Add(hand.Clone().Add(uniqueProperty.Key, i));
                        }
                    }

                }

                
                hands.AddRange(toAdd);
            }

            return finishedHands.ToDictionary(h => h, h => HandMicrostates(h));
        }

        public IEnumerable<(Card, int)> Draw(Hand hand, Board board, CardCollection graveyard)
        {
            return deckDistribution.Select(kvp => (kvp.Key, kvp.Value - hand.Count(kvp.Key) - board.Count(kvp.Key) - graveyard.Count(kvp.Key))).Where(x => x.Item2 > 0);
        }
    }
}