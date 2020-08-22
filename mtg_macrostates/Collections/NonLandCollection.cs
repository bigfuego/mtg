using System;

namespace MTG
{
    //Collection of nonlands.  Ignores Type.
    public class NonLandCollection
    {
        public static long mask = (1 << Globals.BIT_WIDTH)-1;

        long cards = 0;
        public int count = 0;

        public void Add(Card card)
        {
            Add(card.Cost);
        }
        
        public void Add(int cost)
        {
            cards += 1L << (cost * Globals.BIT_WIDTH);
            count++;
        }

        public void Remove(Card card)
        {
            Remove(card.Cost);
        }

        public void Remove(int cost)
        {
            cards -= 1L << (cost * Globals.BIT_WIDTH);
            count--;
        }

        public int Count(Card card)
        {
            return Count(card.Cost);
        }

        public int Count(int cost)
        {
            long val = 1L << (cost * Globals.BIT_WIDTH);
            return (int)(((mask * val) & cards)/val);
        }

        public int Count()
        {
            return count;
        }

        public NonLandCollection Clone()
        {
            return new NonLandCollection{cards = cards, count = count};
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is NonLandCollection)) return false;

            NonLandCollection c = (NonLandCollection) obj;
            return c.cards == cards;
        }

        public override int GetHashCode()
        {   
            return (int)(cards % Int32.MaxValue);
        }
    }
}