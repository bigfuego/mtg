using System;

namespace MTG
{
    public class Card
    {
        public int Cost;
        public CardType CardType;

        public override bool Equals(Object obj)
        {
            if (!(obj is Card)) return false;

            Card c = (Card) obj;
            return c.Cost == Cost && c.CardType == CardType;
        }

        public override int GetHashCode()
        {   
            return Cost.GetHashCode() ^ CardType.GetHashCode();
        }
    }

    public enum CardType
    {
        MOUNTAIN = 1,
        SWAMP = 1 << (1 * Globals.BIT_WIDTH),
        PLAINS = 1 << (2 * Globals.BIT_WIDTH),
        FOREST = 1 << (3 * Globals.BIT_WIDTH),
        ISLAND = 1 << (4 * Globals.BIT_WIDTH),
        NONLAND = 1 << (5 * Globals.BIT_WIDTH),
    }
}