using System;

namespace MTG
{
    //Collection of lands.  Ignores costs.
    public class LandCollection
    {
        public static int mask = (1 << Globals.BIT_WIDTH)-1;

        int cards = 0;
        public int count = 0;

        public void Add(Card card)
        {
            cards += (int)(card.CardType);
            count++;
        }

        public void Remove(Card card)
        {
            cards -= (int)(card.CardType);
            count--;
        }

        public int Count(Card card)
        {
            var val = (int)(card.CardType);
            return ((mask * val) & cards)/val;
        }

        public int Count()
        {
            return count;
        }

        public LandCollection Clone()
        {
            return new LandCollection{cards = cards, count = count};
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is LandCollection)) return false;

            LandCollection c = (LandCollection) obj;
            return c.cards == cards;
        }

        public override int GetHashCode()
        {   
            return cards;
        }
    }
}