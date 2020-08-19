using System;
using System.Collections.Generic;
using System.Linq;

namespace MTG
{
     public class Hand
    {
        public Dictionary<int, int> CardDistribution;

        public Hand()
        {
            CardDistribution = new Dictionary<int, int>();
        }

        public Hand(Dictionary<int, int> values)
        {
            CardDistribution = values;
        }

        public Hand(int property, int count)
        {
            CardDistribution = new Dictionary<int, int>{{property, count}};
        }

        public Hand Clone()
        {
            return new Hand(CardDistribution.ToDictionary(kvp => kvp.Key, kvp => kvp.Value));
        }
        
        public Hand Add(int property, int number)
        {
            this[property] = this[property] + number;
            return this;
        }

        public int Count => CardDistribution.Sum(x => x.Value);
        public bool IsFull => Count == Globals.HAND_SIZE;
        public IEnumerable<int> Keys => CardDistribution.Keys;

        public int this[int i]
        {
            get { return CardDistribution.ContainsKey(i) ? CardDistribution[i] : 0; }
            set { CardDistribution[i] = value; }
        }
    }
}