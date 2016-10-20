using System.Collections;
using System.Collections.Generic;

namespace ExoplanetLibrary
    {
    public class Exoplanets
        {
        static private ArrayList ExoplanetsArray_ = null;
        static public ArrayList ExoplanetsArray
            {
            get { return ExoplanetsArray_; }
            set { ExoplanetsArray_ = value; }
            }

        public Exoplanets ()
            {
            ExoplanetsArray_ = null;
            }

        public static ArrayList PlanetsWithMass (ArrayList exoplanets, bool includeErrors, bool includeDuplicates)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (Helper.IsDefined (exoplanet.Mass))
                    if (includeErrors)
                        {
                        if (Helper.IsDefined (exoplanet.MassSiniErrorMax))
                            if (Helper.IsDefined (exoplanet.MassErrorMin))
                                array.Add (exoplanet);
                        }
                    else
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetMass ());

            return RemoveDuplicates (array, includeDuplicates, PlotTypes.Mass);
            }

        public static ArrayList PlanetsWithRadius (ArrayList exoplanets, bool includeErrors, bool includeDuplicates)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (Helper.IsDefined (exoplanet.Radius))
                    if (includeErrors)
                        {
                        if (Helper.IsDefined (exoplanet.RadiusErrorMax))
                            if (Helper.IsDefined (exoplanet.RadiusErrorMin))
                                array.Add (exoplanet);
                        }
                    else
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetRadius ());

            return RemoveDuplicates (array, includeDuplicates, PlotTypes.Radius);
            }

        public static ArrayList PlanetsWithOrbitalPeriods (ArrayList exoplanets, bool includeErrors, bool includeDuplicates)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (Helper.IsDefined (exoplanet.OrbitalPeriod))
                    if (includeErrors)
                        {
                        if (Helper.IsDefined (exoplanet.OrbitalPeriodErrorMax))
                            if (Helper.IsDefined (exoplanet.OrbitalPeriodErrorMin))
                                array.Add (exoplanet);
                        }
                    else
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetOrbitalPeriod ());

            return RemoveDuplicates (array, includeDuplicates, PlotTypes.OrbitalPeriod);
            }

        public static ArrayList PlanetsWithSemiMajorAxis (ArrayList exoplanets, bool includeErrors, bool includeDuplicates)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (Helper.IsDefined (exoplanet.SemiMajorAxis))
                    if (includeErrors)
                        {
                        if (Helper.IsDefined (exoplanet.SemiMajorAxisErrorMax))
                            if (Helper.IsDefined (exoplanet.SemiMajorAxisErrorMin))
                                array.Add (exoplanet);
                        }
                    else
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetSemiMajorAxis ());

            return RemoveDuplicates (array, includeDuplicates, PlotTypes.SemiMajorAxis);
            }

        public static ArrayList PlanetsWithEccentricity (ArrayList exoplanets, bool includeErrors, bool includeDuplicates)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (Helper.IsDefined (exoplanet.Eccentricity))
                    if (includeErrors)
                        {
                        if (Helper.IsDefined (exoplanet.EccentricityErrorMax))
                            if (Helper.IsDefined (exoplanet.EccentricityErrorMin))
                                array.Add (exoplanet);
                        }
                    else
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetEccentricity ());

            return RemoveDuplicates (array, includeDuplicates, PlotTypes.Eccentricity);
            }

        public static ArrayList PlanetsWithAngularDistance (ArrayList exoplanets, bool includeDuplicates)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (Helper.IsDefined (exoplanet.AngularDistance))
                    array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetAngularDistance ());

            return RemoveDuplicates (array, includeDuplicates, PlotTypes.AngularDistance);
            }

        public static ArrayList PlanetsWithInclination (ArrayList exoplanets, bool includeErrors, bool includeDuplicates)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (Helper.IsDefined (exoplanet.Inclination))
                    if (includeErrors)
                        {
                        if (Helper.IsDefined (exoplanet.InclinationErrorMax))
                            if (Helper.IsDefined (exoplanet.InclinationErrorMin))
                                array.Add (exoplanet);
                        }
                    else
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetInclination ());

            return RemoveDuplicates (array, includeDuplicates, PlotTypes.Inclination);
            }

        public static ArrayList PlanetsWithTemperatureCalculated (ArrayList exoplanets, bool includeDuplicates)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (Helper.IsDefined (exoplanet.TemperatureCalculated))
                    array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetTemperatureCalculated ());

            return RemoveDuplicates (array, includeDuplicates, PlotTypes.TemperatureCalculated);
            }

        public static ArrayList PlanetsWithOmega (ArrayList exoplanets, bool includeErrors, bool includeDuplicates)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (Helper.IsDefined (exoplanet.Omega))
                    if (includeErrors)
                        {
                        if (Helper.IsDefined (exoplanet.OmegaErrorMax))
                            if (Helper.IsDefined (exoplanet.OmegaErrorMin))
                                array.Add (exoplanet);
                        }
                    else
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetOmega ());

            return RemoveDuplicates (array, includeDuplicates, PlotTypes.Omega);
            }

        public static ArrayList PlanetsWithVelocitySemiamplitude (ArrayList exoplanets, bool includeErrors, bool excludeNegatives, bool includeDuplicates)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (Helper.IsDefined (exoplanet.VelocitySemiamplitude))
                    if (excludeNegatives && Helper.IsNegativeOrZero (exoplanet.VelocitySemiamplitude))
                        {
                        ;
                        }
                    else if (includeErrors)
                        {
                        if (Helper.IsDefined (exoplanet.VelocitySemiamplitudeErrorMax))
                            if (Helper.IsDefined (exoplanet.VelocitySemiamplitudeErrorMin))
                                array.Add (exoplanet);
                        }
                    else
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetVelocitySemiamplitude ());

            return RemoveDuplicates (array, includeDuplicates, PlotTypes.VelocitySemiamplitude);
            }

        static private ArrayList RemoveDuplicates (ArrayList exoplanets, bool includeDuplicates, PlotTypes plotType)
            {
            ArrayList array = new ArrayList ();

            if (includeDuplicates == false)
                {
                Exoplanet previous = null;

                foreach (Exoplanet exoplanet in exoplanets)
                    {
                    if (previous == null)
                        array.Add (exoplanet);
                    else
                        {
                        switch (plotType)
                            {
                            case PlotTypes.Mass:
                                if (previous.Eccentricity != exoplanet.Eccentricity)
                                    array.Add (exoplanet);
                                break;

                            case PlotTypes.Radius:
                                if (previous.Radius != exoplanet.Radius)
                                    array.Add (exoplanet);
                                break;

                            case PlotTypes.OrbitalPeriod:
                                if (previous.OrbitalPeriod != exoplanet.OrbitalPeriod)
                                    array.Add (exoplanet);
                                break;

                            case PlotTypes.SemiMajorAxis:
                                if (previous.SemiMajorAxis != exoplanet.SemiMajorAxis)
                                    array.Add (exoplanet);
                                break;

                            case PlotTypes.Eccentricity:
                                if (previous.Eccentricity != exoplanet.Eccentricity)
                                    array.Add (exoplanet);
                                break;

                            case PlotTypes.AngularDistance:
                                if (previous.SemiMajorAxis != exoplanet.AngularDistance)
                                    array.Add (exoplanet);
                                break;

                            case PlotTypes.Inclination:
                                if (previous.Inclination != exoplanet.Inclination)
                                    array.Add (exoplanet);
                                break;

                            case PlotTypes.TemperatureCalculated:
                                if (previous.TemperatureCalculated != exoplanet.TemperatureCalculated)
                                    array.Add (exoplanet);
                                break;

                            case PlotTypes.Omega:
                                if (previous.Omega != exoplanet.Omega)
                                    array.Add (exoplanet);
                                break;

                            case PlotTypes.VelocitySemiamplitude:
                                if (previous.VelocitySemiamplitude != exoplanet.VelocitySemiamplitude)
                                    array.Add (exoplanet);
                                break;
                            }
                        }

                    previous = exoplanet;
                    }
                }
            else
                array = exoplanets;

            return array;
            }

        public static ArrayList PlanetsWithMassAndRadius (ArrayList exoplanets)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (Helper.IsDefined (exoplanet.Mass))
                    if (Helper.IsDefined (exoplanet.Radius))
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetMass ());

            return array;
            }

        public static ArrayList PlanetsWithMassBetween (ArrayList exoplanets, double value1, double value2)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (Helper.IsDefined (exoplanet.Mass))
                    {
                    double mass = double.Parse (exoplanet.Mass);

                    if (mass >= value1 && mass <= value2)
                        array.Add (exoplanet);
                    }
                }

            array.Sort (new SortByExoplanetMass ());

            return array;
            }

        public static ArrayList PlanetsWithMassLessThan (ArrayList exoplanets, double value)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (Helper.IsDefined (exoplanet.Mass))
                    {
                    double mass = double.Parse (exoplanet.Mass);

                    if (mass <= value)
                        array.Add (exoplanet);
                    }
                }

            array.Sort (new SortByExoplanetMass ());

            return array;
            }

        public static ArrayList PlanetsWithMassGreaterThan (ArrayList exoplanets, double value)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (Helper.IsDefined (exoplanet.Mass))
                    {
                    double mass = double.Parse (exoplanet.Mass);

                    if (mass <= value)
                        array.Add (exoplanet);
                    }
                }

            array.Sort (new SortByExoplanetMass ());

            return array;
            }

        static public ArrayList GetTypeOStars (ArrayList exoplanets)
            {
            return GetStars (exoplanets, "O");
            }

        static public ArrayList GetTypeBStars (ArrayList exoplanets)
            {
            return GetStars (exoplanets, "B");
            }

        static public ArrayList GetTypeAStars (ArrayList exoplanets)
            {
            return GetStars (exoplanets, "A");
            }

        static public ArrayList GetTypeFStars (ArrayList exoplanets)
            {
            return GetStars (exoplanets, "F");
            }

        static public ArrayList GetTypeGStars (ArrayList exoplanets)
            {
            return GetStars (exoplanets, "G");
            }

        static public ArrayList GetTypeKStars (ArrayList exoplanets)
            {
            return GetStars (exoplanets, "K");
            }

        static public ArrayList GetTypeMStars (ArrayList exoplanets)
            {
            return GetStars (exoplanets, "M");
            }

        static private ArrayList GetStars (ArrayList exoplanets, string type)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                if (exoplanet.IsType (type))
                    array.Add (exoplanet);

            return array;
            }

        public static ArrayList GetStars (ArrayList exoplanets)
            {
            ArrayList stars = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                bool add = true;

                if (stars.Count > 0)
                    foreach (Star star in stars)
                        {
                        if (exoplanet.Star.Name == star.Name)
                            {
                            add = false;
                            break;
                            }
                        }

                if (add)
                    stars.Add (exoplanet.Star);
                }

            return stars;
            }

        static public int NumberOfExoplanets (ArrayList exoplanets)
            {
            return exoplanets != null ? exoplanets.Count : 0;
            }

        static public int NumberOfExoplanets (ArrayList exoplanets, string name)
            {
            int numberOfPlanets = 0;

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (exoplanet.Star != null)
                    if (string.Equals (exoplanet.Star.Name, name))
                        ++numberOfPlanets;
                }

            return numberOfPlanets;
            }

        static public int NumberOfMultiPlanetStars (ArrayList exoplanets)
            {
            exoplanets.Sort (new SortByStarName ());

            Exoplanet previousExoplanet = null;
            int multiPlanetStars = 0;

            foreach (Exoplanet exoplanet in exoplanets)
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
            return NumberOfStars (exoplanets, "O");
            }

        static public int NumberOfTypeBStars (ArrayList exoplanets)
            {
            return NumberOfStars (exoplanets, "B");
            }

        static public int NumberOfTypeAStars (ArrayList exoplanets)
            {
            return NumberOfStars (exoplanets, "A");
            }

        static public int NumberOfTypeFStars (ArrayList exoplanets)
            {
            return NumberOfStars (exoplanets, "F");
            }

        static public int NumberOfTypeGStars (ArrayList exoplanets)
            {
            return NumberOfStars (exoplanets, "G");
            }

        static public int NumberOfTypeKStars (ArrayList exoplanets)
            {
            return NumberOfStars (exoplanets, "K");
            }

        static public int NumberOfTypeMStars (ArrayList exoplanets)
            {
            return NumberOfStars (exoplanets, "M");
            }

        static private int NumberOfStars (ArrayList exoplanets, string type)
            {
            int matches = 0;

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (exoplanet.IsType (type))
                    {
                    int value;

                    if (exoplanet.Star.Property.SPType.Length >= 2)
                        {
                        if (int.TryParse (exoplanet.Star.Property.SPType.Substring (1, 1), out value))
                            ++matches;
                        }
                    else
                        ++matches;
                    }
                }

            return matches;
            }

        static public ArrayList NumberOfStarTypes (ArrayList exoplanets)
            {
            ArrayList types = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (exoplanet.Star.Property.SPType != null)
                    {
                    bool addType = true;

                    for (int index = 0; index < types.Count && addType; ++index)
                        {
                        StarTypes type = types [index] as StarTypes;

                        if (exoplanet.Star.Property.SPType.Substring (0, 1) == type.Name)
                            {
                            ++type.Count;
                            addType = false;
                            }
                        }

                    if (addType)
                        {
                        StarTypes type = new StarTypes ();
                        type.Name = exoplanet.Star.Property.SPType.Substring (0, 1);
                        type.Count = 1;
                        type.IsSpectualType = ( type.Name == "O" || type.Name == "B" || type.Name == "A" ||
                                                type.Name == "F" || type.Name == "G" || type.Name == "K" ||
                                                type.Name == "M" )
                                                ? true : false;
                        types.Add (type);
                        }
                    }
                }

            return types;
            }

        static public ArrayList NumberOfStarsOfType (ArrayList exoplanets, string type)
            {
            ArrayList stars = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (exoplanet.IsType (type))
                    if (exoplanet.Star.Name != null)
                        {
                        bool addStar = true;

                        for (int index = 0; index < stars.Count && addStar; ++index)
                            {
                            StarTypes star = stars [index] as StarTypes;

                            if (exoplanet.Star.Name == star.Name)
                                {
                                ++star.Count;
                                addStar = false;
                                }
                            }

                        if (addStar)
                            {
                            StarTypes star = new StarTypes ();
                            star.Name = exoplanet.Star.Name;
                            star.Count = 0;
                            star.IsSpectualType = false;
                            stars.Add (star);
                            }
                        }
                }

            foreach (Exoplanet exoplanet in exoplanets)
                {
                for (int index = 0; index < stars.Count; ++index)
                    {
                    StarTypes star = stars [index] as StarTypes;

                    if (exoplanet.Star.Name == star.Name)
                        {
                        ++star.NumberOfPlanets;
                        }
                    }
                }

            return stars;
            }

        static public int GetNumberOfExoplanetsByNumberOfExoplanetsStars (ArrayList stars, int numberOfPlanets)
            {
            int counter = 0;

            foreach (StarTypes star in stars)
                {
                if (star.NumberOfPlanets == numberOfPlanets)
                    ++counter;
                }

            return counter;
            }

        static public bool AreEqual (ArrayList array1, ArrayList array2)
            {
            if (array1 == null)
                return false;

            if (array2 == null)
                return false;

            if (array1.Count != array2.Count)
                return false;

            for (int index = 0; index < array1.Count; ++index)
                {
                object object1 = array1 [index];
                object object2 = array2 [index];

                if (!Helper.CompareEquals (object1, object2))
                    return false;
                }

            return true;
            }

        static public string Compare (ArrayList array1, ArrayList array2)
            {
            string added = string.Empty, updated = string.Empty, missing = string.Empty;
            int numberOfLines = 0;
            bool initial;

            array1.Sort (new SortByExoplanetName ());
            array2.Sort (new SortByExoplanetName ());

            initial = true;
            numberOfLines = 0;

            for (int index = 0; index < array1.Count && numberOfLines < 10; ++index)
                {
                object object1 = array1 [index];
                object object2 = GetByName (array2, ( array1 [index] as Exoplanet ).Name);

                if (object2 == null)
                    {
                    if (initial)
                        added += "Added:\r\n";

                    added += "\t" + ( array1 [index] as Exoplanet ).Name + "\r\n";
                    initial = false;

                    ++numberOfLines;

                    if (numberOfLines == 10)
                        added += "\tmore...\r\n";
                    }
                }

            initial = true;
            numberOfLines = 0;

            for (int index = 0; index < array1.Count && numberOfLines < 10; ++index)
                {
                object object1 = array1 [index];
                object object2 = GetByName (array2, ( array1 [index] as Exoplanet ).Name);

                if (object2 != null && !Helper.CompareEquals (object1, object2))
                    {
                    if (initial)
                        updated += "Updated:\r\n";

                    updated += "\t" + ( array1 [index] as Exoplanet ).Name + "\r\n";
                    initial = false;

                    ++numberOfLines;

                    if (numberOfLines == 10)
                        updated += "\tmore...\r\n";
                    }
                }

            initial = true;
            numberOfLines = 0;

            for (int index = 0; index < array2.Count && numberOfLines < 10; ++index)
                {
                object object1 = array2 [index];
                object object2 = GetByName (array1, ( array2 [index] as Exoplanet ).Name);

                if (object2 == null)
                    {
                    if (initial)
                        missing += "Missing:\r\n";

                    missing += "\t" + ( array2 [index] as Exoplanet ).Name + "\r\n";
                    initial = false;

                    ++numberOfLines;

                    if (numberOfLines == 10)
                        missing += "\tmore...\r\n";
                    }
                }

            return added + updated + missing;
            }

        static private string Merge ( string string1, string string2)
            {
            if (!Helper.IsDefined (string1))
                if (Helper.IsDefined (string2))
                    string1 = string2;

            return string1;
            }

        static public ArrayList Merge (ArrayList array1, ArrayList array2)
            {
            foreach (Exoplanet exoplanet1 in array1)
                {
                foreach (Exoplanet exoplanet2 in array2)
                    {
                    if (Helper.Equals (exoplanet1.Star.Name, exoplanet2.Star.Name))
                        {
                        exoplanet1.Star.AlternateNames = Merge (exoplanet1.Star.AlternateNames, exoplanet2.Star.AlternateNames);
                        exoplanet1.Star.RightAccession = Merge (exoplanet1.Star.RightAccession, exoplanet2.Star.RightAccession);
                        exoplanet1.Star.Declination = Merge (exoplanet1.Star.Declination, exoplanet2.Star.Declination);

                        exoplanet1.Star.Property.Age = Merge (exoplanet1.Star.Property.Age, exoplanet2.Star.Property.Age);
                        exoplanet1.Star.Property.AgeErrorMin = Merge (exoplanet1.Star.Property.AgeErrorMin, exoplanet2.Star.Property.AgeErrorMin);
                        exoplanet1.Star.Property.AgeErrorMax = Merge (exoplanet1.Star.Property.AgeErrorMax, exoplanet2.Star.Property.AgeErrorMax);

                        exoplanet1.Star.Property.Distance = Merge (exoplanet1.Star.Property.Distance, exoplanet2.Star.Property.Distance);
                        exoplanet1.Star.Property.DistanceErrorMin = Merge (exoplanet1.Star.Property.DistanceErrorMin, exoplanet2.Star.Property.DistanceErrorMin);
                        exoplanet1.Star.Property.DistanceErrorMax = Merge (exoplanet1.Star.Property.DistanceErrorMax, exoplanet2.Star.Property.DistanceErrorMax);

                        exoplanet1.Star.Property.Metallicity = Merge (exoplanet1.Star.Property.Metallicity, exoplanet2.Star.Property.Metallicity);
                        exoplanet1.Star.Property.MetallicityErrorMin = Merge (exoplanet1.Star.Property.MetallicityErrorMin, exoplanet2.Star.Property.MetallicityErrorMin);
                        exoplanet1.Star.Property.MetallicityErrorMax = Merge (exoplanet1.Star.Property.MetallicityErrorMax, exoplanet2.Star.Property.MetallicityErrorMax);

                        exoplanet1.Star.Property.Mass = Merge (exoplanet1.Star.Property.Mass, exoplanet2.Star.Property.Mass);
                        exoplanet1.Star.Property.Distance = Merge (exoplanet1.Star.Property.Distance, exoplanet2.Star.Property.Distance);
                        exoplanet1.Star.Property.Distance = Merge (exoplanet1.Star.Property.Distance, exoplanet2.Star.Property.Distance);

                        exoplanet1.Star.Property.Mass = Merge (exoplanet1.Star.Property.Mass, exoplanet2.Star.Property.Distance);
                        exoplanet1.Star.Property.MassErrorMin = Merge (exoplanet1.Star.Property.MassErrorMin, exoplanet2.Star.Property.MassErrorMin);
                        exoplanet1.Star.Property.MassErrorMax = Merge (exoplanet1.Star.Property.MassErrorMax, exoplanet2.Star.Property.MassErrorMax);

                        exoplanet1.Star.Property.Radius = Merge (exoplanet1.Star.Property.Radius, exoplanet2.Star.Property.Radius);
                        exoplanet1.Star.Property.RadiusErrorMin = Merge (exoplanet1.Star.Property.RadiusErrorMin, exoplanet2.Star.Property.RadiusErrorMin);
                        exoplanet1.Star.Property.RadiusErrorMax = Merge (exoplanet1.Star.Property.RadiusErrorMax, exoplanet2.Star.Property.RadiusErrorMax);

                        exoplanet1.Star.Property.SPType = Merge (exoplanet1.Star.Property.SPType, exoplanet2.Star.Property.SPType);

                        exoplanet1.Star.Property.Age = Merge (exoplanet1.Star.Property.Age, exoplanet2.Star.Property.Age);
                        exoplanet1.Star.Property.AgeErrorMin = Merge (exoplanet1.Star.Property.AgeErrorMin, exoplanet2.Star.Property.AgeErrorMin);
                        exoplanet1.Star.Property.AgeErrorMax = Merge (exoplanet1.Star.Property.AgeErrorMax, exoplanet2.Star.Property.AgeErrorMax);

                        exoplanet1.Star.Property.Teff = Merge (exoplanet1.Star.Property.Teff, exoplanet2.Star.Property.Teff);
                        exoplanet1.Star.Property.TeffErrorMin = Merge (exoplanet1.Star.Property.TeffErrorMin, exoplanet2.Star.Property.TeffErrorMin);
                        exoplanet1.Star.Property.TeffErrorMax = Merge (exoplanet1.Star.Property.TeffErrorMax, exoplanet2.Star.Property.TeffErrorMax);

                        exoplanet1.Star.Property.DetectedDisc = Merge (exoplanet1.Star.Property.DetectedDisc, exoplanet2.Star.Property.DetectedDisc);

                        exoplanet1.Star.Property.MagneticField = Merge (exoplanet1.Star.Property.MagneticField, exoplanet2.Star.Property.MagneticField);

                        exoplanet1.Star.Magnitude.V = Merge (exoplanet1.Star.Magnitude.V, exoplanet2.Star.Magnitude.V);
                        exoplanet1.Star.Magnitude.I = Merge (exoplanet1.Star.Magnitude.I, exoplanet2.Star.Magnitude.I);
                        exoplanet1.Star.Magnitude.J = Merge (exoplanet1.Star.Magnitude.J, exoplanet2.Star.Magnitude.J);
                        exoplanet1.Star.Magnitude.H = Merge (exoplanet1.Star.Magnitude.H, exoplanet2.Star.Magnitude.H);
                        exoplanet1.Star.Magnitude.K = Merge (exoplanet1.Star.Magnitude.K, exoplanet2.Star.Magnitude.K);

                        break;
                        }
                    }
                }

            return array1;
            }

        static public string VerifyNames (ArrayList array)
            {
            string misnamed = string.Empty;

            array.Sort (new SortByExoplanetName ());

            for (int index = 0; index < array.Count; ++index)
                {
                Exoplanet exoplanet = array [index] as Exoplanet;

                if (Queries.CurrentQueries != null)
                    if (!Queries.CurrentQueries.MatchesQuery (exoplanet))
                        continue;

                bool mismatch = true;

                List<string> planetNames = new List<string> ();

                planetNames.Add (exoplanet.Name.Trim ());

                if (!string.IsNullOrEmpty (exoplanet.AlternateNames))
                    {
                    char [] delimiterChars = { ';' };
                    string [] alternateNames = exoplanet.AlternateNames.Split (delimiterChars);

                    for (int jndex = 0; jndex < alternateNames.Length; ++jndex)
                        planetNames.Add (alternateNames [jndex].Trim ());
                    }

                List<string> starNames = new List<string> ();

                starNames.Add (exoplanet.Star.Name.Trim ());

                if (!string.IsNullOrEmpty (exoplanet.Star.AlternateNames))
                    {
                    char [] delimiterChars = { ';' };
                    string [] alternateNames = exoplanet.Star.AlternateNames.Split (delimiterChars);

                    for (int jndex = 0; jndex < alternateNames.Length; ++jndex)
                        starNames.Add (alternateNames [jndex].Trim ());
                    }

                for (int jndex = 0; jndex < starNames.Count; ++jndex)
                    for (int kndex = 0; kndex < planetNames.Count; ++kndex)
                        if (IsMismatch (starNames [jndex], planetNames [kndex]) == false)
                            {
                            mismatch = false;
                            break;
                            }

                if (mismatch)
                    misnamed += "'" + exoplanet.Name + "' (" + exoplanet.AlternateNames + ")" +
                                " may be misnamed " +
                                "'" + exoplanet.Star.Name + "' (" + exoplanet.Star.AlternateNames + ")" +
                                "'\r\n";
                }

            return misnamed;
            }

        static private bool IsMismatch (string starName, string planetName)
            {
            return ( planetName.StartsWith (starName) ) ? false : true;
            }

        static private object GetByName (ArrayList array, string name)
            {
            foreach (Exoplanet exoplanet in array)
                {
                if (exoplanet.Name == name)
                    return exoplanet;
                }

            return null;
            }

        static public bool IsPlotable (ArrayList array, PlotTypes plotType)
            {
            foreach (Exoplanet exoplanet in array)
                {
                switch (plotType)
                    {
                    case PlotTypes.Mass:
                        if (Helper.IsDefined (exoplanet.Mass))
                            return true;

                        break;

                    case PlotTypes.Radius:
                        if (Helper.IsDefined (exoplanet.Radius))
                            return true;

                        break;

                    case PlotTypes.OrbitalPeriod:
                        if (Helper.IsDefined (exoplanet.OrbitalPeriod))
                            return true;

                        break;

                    case PlotTypes.SemiMajorAxis:
                        if (Helper.IsDefined (exoplanet.SemiMajorAxis))
                            return true;

                        break;

                    case PlotTypes.Eccentricity:
                        if (Helper.IsDefined (exoplanet.Eccentricity))
                            return true;

                        break;

                    case PlotTypes.AngularDistance:
                        if (Helper.IsDefined (exoplanet.AngularDistance))
                            return true;

                        break;

                    case PlotTypes.Inclination:
                        if (Helper.IsDefined (exoplanet.Inclination))
                            return true;

                        break;

                    case PlotTypes.Omega:
                        if (Helper.IsDefined (exoplanet.Omega))
                            return true;

                        break;

                    case PlotTypes.VelocitySemiamplitude:
                        if (Helper.IsDefined (exoplanet.VelocitySemiamplitude))
                            return true;

                        break;

                    case PlotTypes.TemperatureCalculated:
                        if (Helper.IsDefined (exoplanet.TemperatureCalculated))
                            return true;

                        break;


                    case PlotTypes.MassAndRadius:
                    case PlotTypes.MassAndOrbitalPeriod:
                    case PlotTypes.MassAndSemiMajorAxis:
                    case PlotTypes.MassAndEccentricity:
                    case PlotTypes.MassAndAngularDistance:
                    case PlotTypes.MassAndInclination:
                    case PlotTypes.MassAndOmega:
                    case PlotTypes.MassAndVelocitySemiamplitude:

                    case PlotTypes.RadiusAndMass:
                    case PlotTypes.RadiusAndOrbitalPeriod:
                    case PlotTypes.RadiusAndSemiMajorAxis:
                    case PlotTypes.RadiusAndEccentricity:
                    case PlotTypes.RadiusAndAngularDistance:
                    case PlotTypes.RadiusAndInclination:
                    case PlotTypes.RadiusAndOmega:
                    case PlotTypes.RadiusAndVelocitySemiamplitude:
                        break;
                    }
                }

            return false;
            }
        }
    }
