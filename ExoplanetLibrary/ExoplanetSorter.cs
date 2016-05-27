using System;
using System.Collections;

namespace ExoplanetLibrary
    {
    sealed public class SortByStarName : IComparer
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

    sealed public class SortByExoplanetName : IComparer
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
            //
            // needs_work look at embedded numerics wasp1 wasp2, ..., wasp9, wasp10, wasp11, ..., wasp19, wasp120
            //
            return ObjectCompare.Compare (exoplanet1.Name, exoplanet2.Name);
            }
        }

    sealed public class SortByExoplanetMass : IComparer
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

    sealed public class SortByExoplanetRadius : IComparer
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

    sealed public class SortByExoplanetOrbitalPeriod : IComparer
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

    sealed public class SortByExoplanetSemiMajorAxis : IComparer
        {
        public SortByExoplanetSemiMajorAxis ()
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

            if (double.TryParse (exoplanet1.SemiMajorAxis, out dx) && double.TryParse (exoplanet2.SemiMajorAxis, out dy))
                compareResults = ObjectCompare.Compare (dx, dy);
            else
                compareResults = ObjectCompare.Compare (exoplanet1.SemiMajorAxis, exoplanet2.SemiMajorAxis);

            return ( -compareResults );
            }
        }

    sealed public class SortByExoplanetEccentricity : IComparer
        {
        public SortByExoplanetEccentricity ()
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

            if (double.TryParse (exoplanet1.Eccentricity, out dx) && double.TryParse (exoplanet2.Eccentricity, out dy))
                compareResults = ObjectCompare.Compare (dx, dy);
            else
                compareResults = ObjectCompare.Compare (exoplanet1.Eccentricity, exoplanet2.Eccentricity);

            return ( -compareResults );
            }
        }

    sealed public class SortByExoplanetAngularDistance : IComparer
        {
        public SortByExoplanetAngularDistance ()
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

            if (double.TryParse (exoplanet1.AngularDistance, out dx) && double.TryParse (exoplanet2.AngularDistance, out dy))
                compareResults = ObjectCompare.Compare (dx, dy);
            else
                compareResults = ObjectCompare.Compare (exoplanet1.AngularDistance, exoplanet2.AngularDistance);

            return ( -compareResults );
            }
        }

    sealed public class SortByExoplanetInclination : IComparer
        {
        public SortByExoplanetInclination ()
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

            if (double.TryParse (exoplanet1.Inclination, out dx) && double.TryParse (exoplanet2.Inclination, out dy))
                compareResults = ObjectCompare.Compare (dx, dy);
            else
                compareResults = ObjectCompare.Compare (exoplanet1.Inclination, exoplanet2.Inclination);

            return ( -compareResults );
            }
        }

    sealed public class SortByExoplanetTzeroTr : IComparer
        {
        public SortByExoplanetTzeroTr ()
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

            if (double.TryParse (exoplanet1.TzeroTr, out dx) && double.TryParse (exoplanet2.TzeroTr, out dy))
                compareResults = ObjectCompare.Compare (dx, dy);
            else
                compareResults = ObjectCompare.Compare (exoplanet1.TzeroTr, exoplanet2.TzeroTr);

            return ( -compareResults );
            }
        }

    sealed public class SortByExoplanetTzeroTrSec : IComparer
        {
        public SortByExoplanetTzeroTrSec ()
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

            if (double.TryParse (exoplanet1.TzeroTrSec, out dx) && double.TryParse (exoplanet2.TzeroTrSec, out dy))
                compareResults = ObjectCompare.Compare (dx, dy);
            else
                compareResults = ObjectCompare.Compare (exoplanet1.TzeroTrSec, exoplanet2.TzeroTrSec);

            return ( -compareResults );
            }
        }

    sealed public class SortByExoplanetLambdaAngle : IComparer
        {
        public SortByExoplanetLambdaAngle ()
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

            if (double.TryParse (exoplanet1.LambdaAngle, out dx) && double.TryParse (exoplanet2.LambdaAngle, out dy))
                compareResults = ObjectCompare.Compare (dx, dy);
            else
                compareResults = ObjectCompare.Compare (exoplanet1.LambdaAngle, exoplanet2.LambdaAngle);

            return ( -compareResults );
            }
        }

    sealed public class SortByExoplanetTzeroVr : IComparer
        {
        public SortByExoplanetTzeroVr ()
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

            if (double.TryParse (exoplanet1.TzeroVr, out dx) && double.TryParse (exoplanet2.TzeroVr, out dy))
                compareResults = ObjectCompare.Compare (dx, dy);
            else
                compareResults = ObjectCompare.Compare (exoplanet1.TzeroVr, exoplanet2.TzeroVr);

            return ( -compareResults );
            }
        }

    sealed public class SortByExoplanetTemperatureCalculated : IComparer
        {
        public SortByExoplanetTemperatureCalculated ()
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

            if (double.TryParse (exoplanet1.TemperatureCalculated, out dx) && double.TryParse (exoplanet2.TemperatureCalculated, out dy))
                compareResults = ObjectCompare.Compare (dx, dy);
            else
                compareResults = ObjectCompare.Compare (exoplanet1.TemperatureCalculated, exoplanet2.TemperatureCalculated);

            return ( -compareResults );
            }
        }

    sealed public class SortByExoplanetTemperatureMeasured : IComparer
        {
        public SortByExoplanetTemperatureMeasured ()
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

            if (double.TryParse (exoplanet1.TemperatureMeasured, out dx) && double.TryParse (exoplanet2.TemperatureMeasured, out dy))
                compareResults = ObjectCompare.Compare (dx, dy);
            else
                compareResults = ObjectCompare.Compare (exoplanet1.TemperatureMeasured, exoplanet2.TemperatureMeasured);

            return ( -compareResults );
            }
        }

    sealed public class SortByExoplanetLogG : IComparer
        {
        public SortByExoplanetLogG ()
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

            if (double.TryParse (exoplanet1.LogG, out dx) && double.TryParse (exoplanet2.LogG, out dy))
                compareResults = ObjectCompare.Compare (dx, dy);
            else
                compareResults = ObjectCompare.Compare (exoplanet1.LogG, exoplanet2.LogG);

            return ( -compareResults );
            }
        }

    sealed public class SortByExoplanetOmega : IComparer
        {
        public SortByExoplanetOmega ()
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

            if (double.TryParse (exoplanet1.Omega, out dx) && double.TryParse (exoplanet2.Omega, out dy))
                compareResults = ObjectCompare.Compare (dx, dy);
            else
                compareResults = ObjectCompare.Compare (exoplanet1.Omega, exoplanet2.Omega);

            return ( -compareResults );
            }
        }

    sealed public class SortByExoplanetTperi : IComparer
        {
        public SortByExoplanetTperi ()
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

            if (double.TryParse (exoplanet1.Tperi, out dx) && double.TryParse (exoplanet2.Tperi, out dy))
                compareResults = ObjectCompare.Compare (dx, dy);
            else
                compareResults = ObjectCompare.Compare (exoplanet1.Tperi, exoplanet2.Tperi);

            return ( -compareResults );
            }
        }

    sealed public class SortByExoplanetVelocitySemiamplitude : IComparer
        {
        public SortByExoplanetVelocitySemiamplitude ()
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

            if (double.TryParse (exoplanet1.VelocitySemiamplitude, out dx) && double.TryParse (exoplanet2.VelocitySemiamplitude, out dy))
                compareResults = ObjectCompare.Compare (dx, dy);
            else
                compareResults = ObjectCompare.Compare (exoplanet1.VelocitySemiamplitude, exoplanet2.VelocitySemiamplitude);

            return ( -compareResults );
            }
        }

    sealed public class SortByExoplanetGeometricAlbedo : IComparer
        {
        public SortByExoplanetGeometricAlbedo ()
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

            if (double.TryParse (exoplanet1.GeometricAlbedo, out dx) && double.TryParse (exoplanet2.GeometricAlbedo, out dy))
                compareResults = ObjectCompare.Compare (dx, dy);
            else
                compareResults = ObjectCompare.Compare (exoplanet1.GeometricAlbedo, exoplanet2.GeometricAlbedo);

            return ( -compareResults );
            }
        }

    sealed public class SortByExoplanetTconj : IComparer
        {
        public SortByExoplanetTconj ()
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

            if (double.TryParse (exoplanet1.Tconj, out dx) && double.TryParse (exoplanet2.Tconj, out dy))
                compareResults = ObjectCompare.Compare (dx, dy);
            else
                compareResults = ObjectCompare.Compare (exoplanet1.Tconj, exoplanet2.Tconj);

            return ( -compareResults );
            }
        }
    }
