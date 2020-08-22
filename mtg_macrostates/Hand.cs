using System;
using System.Collections.Generic;
using System.Linq;

namespace MTG
{
     public class Hand : CardCollection
    {
        public Hand Add(Card card, int number)
        {
            for(int i = 0; i < number; i++)
                Add(card);

            return this;
        }

        public new Hand Clone()
        {
            return new Hand{Lands = Lands.Clone(), NonLands = NonLands.Clone()};
        }
        public bool IsFull => Count() == Globals.HAND_SIZE;
    }
}