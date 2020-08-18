//Simple class to maintain some state that shouldn't go other places.  

using System.Collections.Generic;

namespace MTG
{
    public class Board
    {
        public Dictionary<int, int> Lands = new Dictionary<int, int>();
        public Dictionary<int, int> Nonlands = new Dictionary<int, int>();

        public void AddLand(int land)
        {
            if (Lands.TryGetValue(land, out int existing))
                Lands[land]++;
            else
                Lands[land] = 1;
        }

        public void AddNonLand(int nonland)
        {
            if (Nonlands.TryGetValue(nonland, out int existing))
                Nonlands[nonland]++;
            else
                Nonlands[nonland] = 1;
        }
    }
}
