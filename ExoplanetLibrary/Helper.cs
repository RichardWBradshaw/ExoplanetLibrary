using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ExoplanetLibrary
    {
    class Helper
        {
        static public string FormatHMS(string text)
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

        static public bool ParseHMS(string text, out double hms)
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

        static public int NumberOfMultiPlanetStars(ArrayList exoplanets)
            {
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

        static public int NumberOfTypeOStars(ArrayList exoplanets)
            {
            return NumberOfStars (exoplanets, 'O');
            }

        static public int NumberOfTypeBStars(ArrayList exoplanets)
            {
            return NumberOfStars (exoplanets, 'B');
            }

        static public int NumberOfTypeAStars(ArrayList exoplanets)
            {
            return NumberOfStars (exoplanets, 'A');
            }

        static public int NumberOfTypeFStars(ArrayList exoplanets)
            {
            return NumberOfStars (exoplanets, 'F');
            }

        static public int NumberOfTypeGStars(ArrayList exoplanets)
            {
            return NumberOfStars (exoplanets, 'G');
            }

        static public int NumberOfTypeKStars(ArrayList exoplanets)
            {
            return NumberOfStars (exoplanets, 'K');
            }

        static public int NumberOfTypeMStars(ArrayList exoplanets)
            {
            return NumberOfStars (exoplanets, 'M');
            }

        static private int NumberOfStars(ArrayList exoplanets, char type)
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

        }
    }
