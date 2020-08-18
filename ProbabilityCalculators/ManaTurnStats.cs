

using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MTG
{
    public class ManaTurnStats
    {
        public List<Dictionary<string, Dictionary<int, BigInteger>>> StatsPerTurn = new List<Dictionary<string, Dictionary<int, BigInteger>>>();

        public void AddLandStats(IEnumerable<MetaGame> games, int turn)
        {
            Grow(turn);
            StatsPerTurn[turn]["Mana"] = games.GroupBy(g => g.Board.Lands.Sum(kvp => kvp.Value)) //only one color in this one for now.  Need to fix later.
                                              .ToDictionary(g => g.Key, g => g.Aggregate(new BigInteger(0), (c, n) => c + n.Microstates));
        }

        public void AddSpendStats(IEnumerable<MetaGame> games, int turn)
        {
            Grow(turn);
            StatsPerTurn[turn]["Spend"] = games.GroupBy(g => g.Board.Nonlands.Sum(kvp => kvp.Key * kvp.Value))
                                              .ToDictionary(g => g.Key, g => g.Aggregate(new BigInteger(0), (c, n) => c + n.Microstates));
        }

        private void Grow(int turn)
        {
            while (StatsPerTurn.Count <= turn)
                StatsPerTurn.Add(new Dictionary<string, Dictionary<int, BigInteger>>());
        }

        public IEnumerable<Dictionary<int, BigInteger>> GetLandStats()
        {
            return StatsPerTurn.Select(s => s["Mana"]);
        }

        public IEnumerable<Dictionary<int, BigInteger>> GetSpendStats()
        {
            return StatsPerTurn.Select(s => s["Spend"]);
        }
    }
}