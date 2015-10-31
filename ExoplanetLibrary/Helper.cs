using System;
using System.Collections;

namespace ExoplanetLibrary
    {
    public class StarTypes
        {
        public string Name;
        public int Count;
        }

   public class Helper
        {
        static public string FormatHMS (string text)
            {
            if (!string.IsNullOrEmpty (text))
                {
                double hms = Double.Parse (text);
                double signage = ( hms < 0.0 ) ? -1.0 : 1.0;

                if (hms < 0.0)
                    hms = Math.Abs (hms);

                double hour = ( int )hms;
                double ms = 60.0 * ( hms - hour );
                double minute = ( int )ms;
                double seconds = ( int )( 60.0 * ( ms - minute ) );

                return string.Format ("{0}:{1}:{2}", signage * hour, minute, seconds);
                }

            return text;
            }

        static public bool ParseHMS (string text, out double hms)
            {
            hms = 0.0;

            if (!string.IsNullOrEmpty (text))
                {
                char [] delimiterChars = { ':' };
                string [] strings = text.Split (delimiterChars);

                if (strings.Length == 3)
                    {
                    hms = double.Parse (strings [0]) + double.Parse (strings [1]) / 60.0 + double.Parse (strings [2]) / 3600.0;
                    return true;
                    }
                }

            return false;
            }

        static public int NumberOfMultiPlanetStars (ArrayList exoplanets)
            {
            exoplanets.Sort (new SortByStarName ());

            CExoplanet previousExoplanet = null;
            int multiPlanetStars = 0;

            foreach (CExoplanet exoplanet in exoplanets)
                {
                if (previousExoplanet != null)
                    if (string.Equals (exoplanet.Star.Name, previousExoplanet.Star.Name))
                        ++multiPlanetStars;

                previousExoplanet = exoplanet;
                }

            return multiPlanetStars;
            }

        static public int NumberOfTypeOStars (ArrayList exoplanets)
            {
            return NumberOfStars (exoplanets, 'O');
            }

        static public int NumberOfTypeBStars (ArrayList exoplanets)
            {
            return NumberOfStars (exoplanets, 'B');
            }

        static public int NumberOfTypeAStars (ArrayList exoplanets)
            {
            return NumberOfStars (exoplanets, 'A');
            }

        static public int NumberOfTypeFStars (ArrayList exoplanets)
            {
            return NumberOfStars (exoplanets, 'F');
            }

        static public int NumberOfTypeGStars (ArrayList exoplanets)
            {
            return NumberOfStars (exoplanets, 'G');
            }

        static public int NumberOfTypeKStars (ArrayList exoplanets)
            {
            return NumberOfStars (exoplanets, 'K');
            }

        static public int NumberOfTypeMStars (ArrayList exoplanets)
            {
            return NumberOfStars (exoplanets, 'M');
            }

        static private int NumberOfStars (ArrayList exoplanets, char type)
            {
            int matches = 0;

            foreach (CExoplanet exoplanet in exoplanets)
                {
                if (exoplanet.Star.Properties.SPType != null)
                    if (exoplanet.Star.Properties.SPType [0] == type)
                        ++matches;
                }

            return matches;
            }

        static public int NumberOfStarTypes (ArrayList exoplanets, ref ArrayList types)
            {
            types = new ArrayList ();

            foreach (CExoplanet exoplanet in exoplanets)
                {
                if (exoplanet.Star.Properties.SPType != null)
                    {
                    bool addType = true;

                    for (int index = 0; index < types.Count && addType; ++index)
                        {
                        StarTypes type = types [index] as StarTypes;

                        if (exoplanet.Star.Properties.SPType.Substring (0, 1) == type.Name)
                            {
                            ++type.Count;
                            addType = false;
                            }
                        }

                    if (addType)
                        {
                        StarTypes type = new StarTypes ();
                        type.Name = exoplanet.Star.Properties.SPType.Substring (0, 1);
                        type.Count = 1;

                        types.Add (type);
                        }
                    }
                }

            return 0;
            }

        static public bool AreEqual (ArrayList exoplanetArray1, ArrayList exoplanetArray2)
            {
            if (exoplanetArray1 == null)
                return false;

            if (exoplanetArray2 == null)
                return false;

            if (exoplanetArray1.Count != exoplanetArray2.Count)
                return false;

            for (int index = 0; index < exoplanetArray1.Count; ++index)
                {
                CExoplanet exoplanet1 = exoplanetArray1 [index] as CExoplanet;
                CExoplanet exoplanet2 = exoplanetArray2 [index] as CExoplanet;

                if (!AreEqual (exoplanet1, exoplanet2))
                    return false;
                }

            return true;
            }

        static private bool AreEqual (CExoplanet exoplanet1, CExoplanet exoplanet2)
            {
            if (!string.Equals (exoplanet1.Name, exoplanet2.Name))
                return false;

            if (!string.Equals (exoplanet1.Mass, exoplanet2.Mass))
                return false;

            if (!string.Equals (exoplanet1.Radius, exoplanet2.Radius))
                return false;

            if (!string.Equals (exoplanet1.OrbitalPeriod, exoplanet2.OrbitalPeriod))
                return false;

            if (!string.Equals (exoplanet1.SemiMajorAxis, exoplanet2.SemiMajorAxis))
                return false;

            if (!string.Equals (exoplanet1.Eccentricity, exoplanet2.Eccentricity))
                return false;

            if (!string.Equals (exoplanet1.AngularDistance, exoplanet2.AngularDistance))
                return false;

            if (!string.Equals (exoplanet1.TzeroTr, exoplanet2.TzeroTr))
                return false;

            if (!string.Equals (exoplanet1.TzeroTrSec, exoplanet2.TzeroTrSec))
                return false;

            if (!string.Equals (exoplanet1.LambdaAngle, exoplanet2.LambdaAngle))
                return false;

            if (!string.Equals (exoplanet1.TzeroVr, exoplanet2.TzeroVr))
                return false;

            if (!string.Equals (exoplanet1.TemperatureCalculated, exoplanet2.TemperatureCalculated))
                return false;

            if (!string.Equals (exoplanet1.LogG, exoplanet2.LogG))
                return false;

            if (!string.Equals (exoplanet1.Status, exoplanet2.Status))
                return false;

            if (!string.Equals (exoplanet1.Discovered, exoplanet2.Discovered))
                return false;

            if (!string.Equals (exoplanet1.Updated, exoplanet2.Updated))
                return false;

            if (!string.Equals (exoplanet1.Omega, exoplanet2.Omega))
                return false;

            if (!string.Equals (exoplanet1.Tperi, exoplanet2.Tperi))
                return false;

            if (!string.Equals (exoplanet1.DetectionType, exoplanet2.DetectionType))
                return false;

            if (!string.Equals (exoplanet1.ImpactParameter, exoplanet2.ImpactParameter))
                return false;

            if (!string.Equals (exoplanet1.K, exoplanet2.K))
                return false;

            if (!string.Equals (exoplanet1.GeometricAlbedo, exoplanet2.GeometricAlbedo))
                return false;

            if (!string.Equals (exoplanet1.Tconj, exoplanet2.Tconj))
                return false;

            if (!string.Equals (exoplanet1.MassDetectionType, exoplanet2.MassDetectionType))
                return false;

            if (!string.Equals (exoplanet1.RadiusDetectionType, exoplanet2.RadiusDetectionType))
                return false;

            if (!string.Equals (exoplanet1.AlternateNames, exoplanet2.AlternateNames))
                return false;

            if (!string.Equals (exoplanet1.ImpactParameter, exoplanet2.ImpactParameter))
                return false;

            if (!string.Equals (exoplanet1.K, exoplanet2.K))
                return false;

            if (!string.Equals (exoplanet1.GeometricAlbedo, exoplanet2.GeometricAlbedo))
                return false;

            if (!string.Equals (exoplanet1.Tconj, exoplanet2.Tconj))
                return false;

            if (!string.Equals (exoplanet1.MassDetectionType, exoplanet2.MassDetectionType))
                return false;

            if (!string.Equals (exoplanet1.RadiusDetectionType, exoplanet2.RadiusDetectionType))
                return false;

            return true;
            }
        }
    }
