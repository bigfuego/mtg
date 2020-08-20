using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MTG
{
    public class MetaGame
    {
        public MetaDeck Deck;
        public Board Board;
        public Hand Hand;
        public int turn = 0;
        public BigInteger Microstates;

        public MetaGame(MetaDeck deck, Board board, Hand hand, BigInteger microstates)
        {
            this.Deck = deck;
            this.Board = board;
            this.Hand = hand;
            this.Microstates = microstates;
        }

        public int NewTurn()
        {
            turn++;
            return turn;
        }

        public IEnumerable<MetaGame> Draw() //Drawing creates a whole new set of metagames
        {
            var draws = Deck.Draw(Hand);
            return draws.Select(c => new MetaGame(Deck, Board.Clone(), Hand.Clone().Add(c.Key, 1), Microstates*c.Value));
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

         public override bool Equals(Object obj)
        {
            if (!(obj is MetaGame)) return false;

            var g = (MetaGame)obj;
            return g.Board.Equals(Board) && g.Hand.Equals(Hand) && g.turn == turn;
        }

        public override int GetHashCode()
        {   
            return Board.GetHashCode() + Hand.GetHashCode() + Deck.GetHashCode() + turn;
        }

    }
}