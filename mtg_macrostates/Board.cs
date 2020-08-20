//Simple class to maintain some state that shouldn't go other places.  

using System;
using System.Collections.Generic;
using System.Linq;

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
        
         public Board Clone()
        {
            return new Board{Lands = Lands.ToDictionary(kvp => kvp.Key, kvp => kvp.Value), Nonlands = Nonlands.ToDictionary(kvp => kvp.Key, kvp => kvp.Value)};
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is Board)) return false;

            Board b = (Board)obj;
            return Utils.DictionaryEquals(b.Lands, this.Lands) && Utils.DictionaryEquals(b.Nonlands, this.Nonlands);
        }

        public override int GetHashCode()
        {   
            int hc=Lands.Count + 10*Nonlands.Count;
            foreach(var kvp in Lands)
            {
                hc=unchecked(hc*11 + kvp.GetHashCode());
            }
            foreach(var kvp in Nonlands)
            {
                hc=unchecked(hc*11 + kvp.GetHashCode());
            }
            return hc;
        }
    }
}
