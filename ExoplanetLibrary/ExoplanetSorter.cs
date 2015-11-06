using System;
using System.Collections;

namespace ExoplanetLibrary
    {
    public class SortByStarName : IComparer
        {
        public SortByStarName ()
            {
            }

        private CaseInsensitiveComparer ObjectCompare = new CaseInsensitiveComparer ();

        int IComparer.Compare (Object x, Object y)
            {
            Exoplanet exoplanet1, exoplanet2;

            exoplanet1 = ( Exoplanet )x;
            exoplanet2 = ( Exoplanet )y;

            return ObjectCompare.Compare (exoplanet1.Star.Name, exoplanet2.Star.Name);
            }
        }

    public class SortByExoplanetName : IComparer
        {
        public SortByExoplanetName ()
            {
            }

        private CaseInsensitiveComparer ObjectCompare = new CaseInsensitiveComparer ();

        int IComparer.Compare (Object x, Object y)
            {
            Exoplanet exoplanet1, exoplanet2;

            exoplanet1 = ( Exoplanet )x;
            exoplanet2 = ( Exoplanet )y;

            return ObjectCompare.Compare (exoplanet1.Name, exoplanet2.Name);
            }
        }
    }
