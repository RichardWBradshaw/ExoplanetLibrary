using System;
using System.Collections;

namespace ExoplanetLibrary
    {
    public class SortByStarName : IComparer
        {
        private CaseInsensitiveComparer ObjectCompare = new CaseInsensitiveComparer ();

        int IComparer.Compare (Object x, Object y)
            {
            CExoplanet exoplanet1, exoplanet2;

            exoplanet1 = ( CExoplanet )x;
            exoplanet2 = ( CExoplanet )y;

            return ObjectCompare.Compare (exoplanet1.Star.Name, exoplanet2.Star.Name);
            }
        }

    public class SortByExoplanetName : IComparer
        {
        private CaseInsensitiveComparer ObjectCompare = new CaseInsensitiveComparer ();

        int IComparer.Compare (Object x, Object y)
            {
            CExoplanet exoplanet1, exoplanet2;

            exoplanet1 = ( CExoplanet )x;
            exoplanet2 = ( CExoplanet )y;

            return ObjectCompare.Compare (exoplanet1.Name, exoplanet2.Name);
            }
        }
    }
