namespace MTG
{
    public class Board: CardCollection
    {
        public new Board Clone()
        {
            return new Board{Lands = Lands.Clone(), NonLands = NonLands.Clone()};
        }
    }
}