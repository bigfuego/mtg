using System;

namespace MTG
{
    public class Card
    {
        public int Cost;
        public CardType CardType;
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