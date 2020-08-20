using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MTG
{
    public class MetaDeck
    {
        public Dictionary<int, int> deckDistribution = null;
        public int Count;

        public MetaDeck(Deck deck, Func<Card, int> groupFunc)
        {
            this.Count = deck.Count;
            deckDistribution = deck.GroupBy(groupFunc);
        }

        public BigInteger HandMicrostates(Hand hand)
        {
            var handDistribution = hand.CardDistribution;
            var keys = handDistribution.Keys;
            return keys.Aggregate(new BigInteger(1), (c, n) =>  c*Utils.NChooseK(deckDistribution[n], handDistribution[n]));
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
                    for (int i = 1; i <= Math.Min(uniqueProperty.Value, Globals.HAND_SIZE - hand.Count); i++)
                    {      
                        if (i < Globals.HAND_SIZE - hand.Count)  
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

        public Dictionary<int, int> Draw(Hand hand)
        {
            return deckDistribution.ToDictionary(kvp => kvp.Key, kvp => kvp.Value - hand[kvp.Key]);
        }
    }
}