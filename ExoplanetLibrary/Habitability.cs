using System;

namespace ExoplanetLibrary
    {
    // reference: http://planetarybiology.com
    // reference http://www.planetarybiology.com/calculating_habitable_zone.html

    public enum Zone
        {
        Habitable = 0,
        Cold = 1,
        Hot = 2,
        Unknown = 3,
        }

    class Habitability
        {
        static public Zone GetHabitability (Exoplanet exoplanet)
            {
            if (IsComputable (exoplanet) == true)
                {
                double innerRadius = ComputeInnerRadius (exoplanet);        // AU
                double outerRadius = ComputeOuterRadius (exoplanet);        // AU
                double distance = double.Parse (exoplanet.SemiMajorAxis);

                if (distance < innerRadius)
                    return Zone.Hot;
                else if (distance > outerRadius)
                    return Zone.Cold;
                else if (distance >= innerRadius && distance <= outerRadius)
                    return Zone.Habitable;
                }

            return Zone.Unknown;
            }

        static private bool IsComputable (Exoplanet exoplanet)
            {
            if (exoplanet != null)
                if (exoplanet.Star != null)
                    if (Helper.IsDefined (exoplanet.Star.Property.SPType))
                        {
                        string spectral = exoplanet.Star.Property.SPType.Substring (0, 1);

                        if (spectral == "B" || spectral == "A" || spectral == "F" || spectral == "G" || spectral == "K" || spectral == "M")
                            if (Helper.IsDefined (exoplanet.Star.Magnitude.V))
                                if (Helper.IsDefined (exoplanet.Star.Property.Distance))
                                    if (Helper.IsDefined (exoplanet.SemiMajorAxis))
                                        return true;
                        }

            return false;
            }

        static private double ComputeInnerRadius (Exoplanet exoplanet)
            {
            return Math.Sqrt (ComputeAbsoluteLuminosity (exoplanet) / 1.1);
            }

        static private double ComputeOuterRadius (Exoplanet exoplanet)
            {
            return Math.Sqrt (ComputeAbsoluteLuminosity (exoplanet) / 0.53);
            }

        static private double ComputeAbsoluteLuminosity (Exoplanet exoplanet)
            {
            double mv = double.Parse (exoplanet.Star.Magnitude.V);
            double distance = double.Parse (exoplanet.Star.Property.Distance);

            double Mv = mv - 5.0 * Math.Log (distance / 10.0);

            double Mbol = Mv + Correction (exoplanet);

            double absLuminosity = Math.Pow (10.0, ( Mbol - 4.72 ) / -2.5);

            return absLuminosity;
            }

        static private double Correction (Exoplanet exoplanet)
            {
            switch (exoplanet.Star.Property.SPType.Substring (0, 1))
                {
                case "B": return -2.0;
                case "A": return -0.3;
                case "F": return -0.15;
                case "G": return -0.4;
                case "K": return -0.8;
                case "M": return -2.0;
                default: return 0.0;
                }
            }
        }
    }
