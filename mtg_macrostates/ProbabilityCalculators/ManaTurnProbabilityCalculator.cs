using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MTG
{
    public class ManaTurnProbabilityCalculator
    {
        MetaDeck metadeck;
        List<MetaGame> MetaGames;
        public ManaTurnStats Stats;
        private int turn = 0;

        public ManaTurnProbabilityCalculator(Deck deck, Func<Card, int> groupBy)
        {
            this.metadeck = new MetaDeck(deck, groupBy);
            var handDistribution = metadeck.HandDistribution();
            this.MetaGames = handDistribution.Select(hd => new MetaGame(this.metadeck, new Board(), hd.Key, hd.Value)).ToList();
            this.Stats = new ManaTurnStats();
        }

        public void SimulateTurn()
        {
            MetaGames = MetaGames.SelectMany(mg => mg.Draw()).ToList();
            CoalesceMetaGames();
            
            foreach (var game in MetaGames)
            {
                var turn = game.NewTurn();
                game.Draw();

                if (GetLandToPlay(game, out int land))
                    game.PlayLand(land);    

                var nonlandsToPlay = GetNonLandsToPlay(game);
                game.PlayNonLands(nonlandsToPlay);
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
        public void CoalesceMetaGames()
        {
            Console.WriteLine($"Grouping {MetaGames.Count} games");
            var groups = MetaGames.GroupBy(mg => new {mg.Board, mg.Hand});
            Console.WriteLine($"Collapsing to {groups.Count()} games");
            MetaGames = groups.Select(g => new MetaGame(metadeck, g.Key.Board, g.Key.Hand, g.Aggregate(new BigInteger(0), (c, n) => c + n.Microstates))).ToList();
        }

        #region Logic around what to play, specific to objectives of this calculator

        public bool GetLandToPlay(MetaGame game, out int land)
        {
            land = game.Hand[0] > 0 ? 0 : -1;
            return land == 0;
        }

        public List<int> GetNonLandsToPlay(MetaGame game)
        {
            var result = new List<int>();
            var availableMana = game.Board.Lands.Sum(l => l.Value);
            //Greedy.  Wrong.  With 5 mana, this could play a 4 instead of a 2 and 3.  
            foreach (var cost in game.Hand.CardDistribution.Keys.Where(c => c > 0).OrderByDescending(x => x))
            {
                var played = 0;
                while (cost <= availableMana && played < game.Hand.CardDistribution[cost])
                {
                    result.Add(cost);
                    availableMana -= cost;
                }
            }
            return result;
        }

        public bool GetDiscard(MetaGame game, out int discard)
        {
            discard = game.Hand.Count > 7 ? game.Hand.Keys.Max() : -1;
            return discard != -1;
        }
        #endregion
    }
}