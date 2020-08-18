namespace MTG
{
    public class Card
    {
        public int Cost;
        public CardType CardType;
    }

    public enum CardType
    {
        LAND,
        NONLAND
    }
}