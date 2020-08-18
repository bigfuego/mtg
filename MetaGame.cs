using System.Collections.Generic;
using System.Numerics;

namespace MTG
{
    public class MetaGame
    {
        public MetaDeck Deck;
        public Board Board;
        public Hand Hand;

        public BigInteger Microstates;

        public MetaGame(MetaDeck deck, Board board, Hand hand, BigInteger microstates)
        {
            this.Deck = deck;
            this.Board = board;
            this.Hand = hand;
            this.Microstates = microstates;
        }

        public bool Draw()
        {
                var key = Deck.Draw(Hand);
                if (key < 0)
                    return false;
                Hand.Add(key, 1);
                return true;
        }

        public void PlayLand(int land)
        {
            Hand[land]--;
            Board.AddLand(land);
        }

        public void PlayNonLands(List<int> nonlands)
        {
            foreach(var nonland in nonlands)
            {
                Hand[nonland]--;
                Board.AddNonLand(nonland);
            }
        }

        public void Discard(int card)
        {
            Hand[card]--;
        }

    }
}