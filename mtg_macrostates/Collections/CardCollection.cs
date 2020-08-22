//Simple class to maintain some state that shouldn't go other places.  

using System;
using System.Collections.Generic;
using System.Linq;

namespace MTG
{
    public class CardCollection
    {
        public LandCollection Lands = new LandCollection();
        public NonLandCollection NonLands = new NonLandCollection();

        public void Add(Card card)
        {
            if (card.CardType == CardType.NONLAND)
                NonLands.Add(card);
            else   
                Lands.Add(card);
        }

        public void Remove(Card card)
        {
            if (card.CardType == CardType.NONLAND)
                NonLands.Remove(card);
            else   
                Lands.Remove(card);
        }

        public int Count(Card card)
        {
            if (card.CardType == CardType.NONLAND)
            {
                return NonLands.Count(card);
            }
            return Lands.Count(card);
        }

        public int Count()
        {
            return Lands.Count() + NonLands.Count();
        }
        
        public CardCollection Clone()
        {
            return new CardCollection{Lands = Lands.Clone(), NonLands = NonLands.Clone()};
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is CardCollection)) return false;

            CardCollection c = (CardCollection)obj;
            return Lands.Equals(c.Lands) && NonLands.Equals(c.NonLands);
        }

        public override int GetHashCode()
        {   
            return Lands.GetHashCode() ^ NonLands.GetHashCode();
        }
    }
}
