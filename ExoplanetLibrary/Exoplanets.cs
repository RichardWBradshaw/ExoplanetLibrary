using System.Collections;

namespace ExoplanetLibrary
    {
    public class Exoplanets
        {
        static public ArrayList GetTypeOStars (ArrayList exoplanets)
            {
            return GetStars (exoplanets, 'O');
            }

        static public ArrayList GetTypeBStars (ArrayList exoplanets)
            {
            return GetStars (exoplanets, 'B');
            }

        static public ArrayList GetTypeAStars (ArrayList exoplanets)
            {
            return GetStars (exoplanets, 'A');
            }

        static public ArrayList GetTypeFStars (ArrayList exoplanets)
            {
            return GetStars (exoplanets, 'F');
            }

        static public ArrayList GetTypeGStars (ArrayList exoplanets)
            {
            return GetStars (exoplanets, 'G');
            }

        static public ArrayList GetTypeKStars (ArrayList exoplanets)
            {
            return GetStars (exoplanets, 'K');
            }

        static public ArrayList GetTypeMStars (ArrayList exoplanets)
            {
            return GetStars (exoplanets, 'M');
            }

        static private ArrayList GetStars (ArrayList exoplanets, char type)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                if (exoplanet.Star.Property.SPType != null)
                    if (exoplanet.Star.Property.SPType [0] == type)
                        array.Add (exoplanet);

            return array;
            }
        }
    }
