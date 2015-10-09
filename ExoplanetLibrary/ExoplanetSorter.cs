using System;
using System.Collections;

namespace ExoplanetLibrary
    {
    public class SortByStarName : IComparer
        {
        private CaseInsensitiveComparer ObjectCompare = new CaseInsensitiveComparer ();

        int IComparer.Compare (Object x, Object y)
            {
            CExoplanet exoplanetX, exoplanetY;

            exoplanetX = ( CExoplanet )x;
            exoplanetY = ( CExoplanet )y;

            return ObjectCompare.Compare (exoplanetX.Star.Name, exoplanetY.Star.Name);
            }
        }

    public class SortByExoplanetName : IComparer
        {
        private CaseInsensitiveComparer ObjectCompare = new CaseInsensitiveComparer ();

        int IComparer.Compare (Object x, Object y)
            {
            CExoplanet exoplanetX, exoplanetY;

            exoplanetX = ( CExoplanet )x;
            exoplanetY = ( CExoplanet )y;

            return ObjectCompare.Compare (exoplanetX.Name, exoplanetY.Name);
            }
        }
    }
