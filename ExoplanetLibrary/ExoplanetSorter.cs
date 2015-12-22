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

    public class SortByExoplanetMass : IComparer
        {
        public SortByExoplanetMass ()
            {
            }

        private CaseInsensitiveComparer ObjectCompare = new CaseInsensitiveComparer ();

        int IComparer.Compare (Object x, Object y)
            {
            Exoplanet exoplanet1, exoplanet2;
            double dx, dy;
            int compareResults;

            exoplanet1 = ( Exoplanet )x;
            exoplanet2 = ( Exoplanet )y;

            if (double.TryParse (exoplanet1.Mass, out dx) && double.TryParse (exoplanet2.Mass, out dy))
                compareResults = ObjectCompare.Compare (dx, dy);
            else
                compareResults = ObjectCompare.Compare (exoplanet1.Mass, exoplanet2.Mass);

            return ( -compareResults );
            }
        }

    public class SortByExoplanetRadius : IComparer
        {
        public SortByExoplanetRadius ()
            {
            }

        private CaseInsensitiveComparer ObjectCompare = new CaseInsensitiveComparer ();

        int IComparer.Compare (Object x, Object y)
            {
            Exoplanet exoplanet1, exoplanet2;
            double dx, dy;
            int compareResults;

            exoplanet1 = ( Exoplanet )x;
            exoplanet2 = ( Exoplanet )y;

            if (double.TryParse (exoplanet1.Radius, out dx) && double.TryParse (exoplanet2.Radius, out dy))
                compareResults = ObjectCompare.Compare (dx, dy);
            else
                compareResults = ObjectCompare.Compare (exoplanet1.Radius, exoplanet2.Radius);

            return ( -compareResults );
            }
        }

    public class SortByExoplanetOrbitalPeriod : IComparer
        {
        public SortByExoplanetOrbitalPeriod ()
            {
            }

        private CaseInsensitiveComparer ObjectCompare = new CaseInsensitiveComparer ();

        int IComparer.Compare (Object x, Object y)
            {
            Exoplanet exoplanet1, exoplanet2;
            double dx, dy;
            int compareResults;

            exoplanet1 = ( Exoplanet )x;
            exoplanet2 = ( Exoplanet )y;

            if (double.TryParse (exoplanet1.OrbitalPeriod, out dx) && double.TryParse (exoplanet2.OrbitalPeriod, out dy))
                compareResults = ObjectCompare.Compare (dx, dy);
            else
                compareResults = ObjectCompare.Compare (exoplanet1.OrbitalPeriod, exoplanet2.OrbitalPeriod);

            return ( -compareResults );
            }
        }
    }
