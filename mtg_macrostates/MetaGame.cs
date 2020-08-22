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
        public CardCollection Graveyard;
        public int turn = 0;
        public BigInteger Microstates;

        public MetaGame(MetaDeck deck, Board board, CardCollection graveyard, Hand hand, BigInteger microstates)
        {
            this.Deck = deck;
            this.Board = board;
            this.Hand = hand;
            this.Microstates = microstates;
            this.Graveyard = graveyard;
        }

        public int NewTurn()
        {
            turn++;
            return turn;
        }

        public IEnumerable<MetaGame> Draw() //Drawing creates a whole new set of metagames
        {
            var draws = Deck.Draw(Hand, Board, Graveyard);
            return draws.Select(c => new MetaGame(Deck, Board.Clone(), Graveyard.Clone(), Hand.Clone().Add(c.Item1, 1), Microstates*c.Item2));
        }

        public void Play(Card card)
        {
            Hand.Remove(card);
            Board.Add(card);
        }

        public void Play(IEnumerable<int> costs)
        {
            foreach(var cost in costs)
            {
                Hand.NonLands.Remove(cost);
                Board.NonLands.Add(cost);
            }
        }

        public void Discard(int cost)
        {
            Hand.NonLands.Remove(cost);
            Graveyard.NonLands.Add(cost);
        }

         public override bool Equals(Object obj)
        {
            if (!(obj is MetaGame)) return false;

            var g = (MetaGame)obj;
            return g.Board.Equals(Board) && g.Hand.Equals(Hand) && g.turn == turn;
        }

        public override int GetHashCode()
        {   
            return Board.GetHashCode() ^ Hand.GetHashCode() + turn;
        }

    }
}