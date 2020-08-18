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
            return Cost == c.Cost & CardType == c.CardType;
        }

        public override int GetHashCode()
        {
            return (int)CardType + 1000*(Cost + 1);
        }
    }

    public enum CardType
    {
        MOUNTAIN,
        SWAMP,
        PLAINS,
        FOREST,
        ISLAND,
        NONLAND
    }
}