using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MTG
{
    public class ManaTurnProbabilityCalculator
    {
        MetaDeck metadeck;
        IEnumerable<MetaGame> MetaGames;
        public ManaTurnStats Stats;
        private int turn = 0;

        public ManaTurnProbabilityCalculator(Deck deck, Func<Card, int> groupBy)
        {
            this.metadeck = new MetaDeck(deck, c => c);
            var handDistribution = metadeck.HandDistribution();
            this.MetaGames = handDistribution.Select(hd => new MetaGame(this.metadeck, new Board(), new CardCollection(), hd.Key, hd.Value));
            this.Stats = new ManaTurnStats();
        }

        public void SimulateTurn()
        {
            Draw();
            foreach (var game in MetaGames)
            {
                var turn = game.NewTurn();

                if (GetLandToPlay(game, out Card land))
                    game.Play(land);    

                var nonlandsToPlay = GetNonLandsToPlay(game);
                game.Play(nonlandsToPlay);
                if (GetDiscard(game, out int discard))
                {
                    game.Discard(discard);
                }
            }
            Stats.AddLandStats(MetaGames, turn);
            Stats.AddSpendStats(MetaGames, turn);
            turn++;
        }

        //Assumes they all have the same deck.  
        public void Draw()
        {
            var afterDraw = new Dictionary<(Board, Hand), MetaGame>();
            foreach(var metagame in MetaGames)
                foreach(var newGame in metagame.Draw())
                {
                    if(afterDraw.TryGetValue((newGame.Board, newGame.Hand), out MetaGame existing))
                        existing.Microstates += newGame.Microstates;
                    else 
                        afterDraw.Add((newGame.Board, newGame.Hand), newGame);
                }
            MetaGames = afterDraw.Values;
        }

        #region Logic around what to play, specific to objectives of this calculator

        public bool GetLandToPlay(MetaGame game, out Card land)
        {
            var card =  new Card{CardType=CardType.PLAINS}; //TODO: Be smarter.
            var count = game.Hand.Lands.Count( new Card{CardType=CardType.PLAINS});
            land = count > 0 ? card : null;
            return count > 0;
        }

        public List<int> GetNonLandsToPlay(MetaGame game)
        {
            var result = new List<int>();
            var availableMana = game.Board.Lands.Count(); //TODO: Multiple colors
            //Greedy.  Wrong.  With 5 mana, this could play a 4 instead of a 2 and 3.  
            foreach (var cost in Globals.MANA_COSTS)
            {
                var played = 0;
                while (cost <= availableMana && played < game.Hand.NonLands.Count(cost))
                {
                    result.Add(cost);
                    availableMana -= cost;
                }
            }
            return result;
        }

        public bool GetDiscard(MetaGame game, out int discard)
        {
            discard = game.Hand.Count() > 7 ? Globals.MANA_COSTS.First(c => game.Hand.NonLands.Count(c) > 0) : -1;
            return discard != -1;
        }
        #endregion
    }
}