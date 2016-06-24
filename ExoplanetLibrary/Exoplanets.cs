using System.Collections;

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
            string stringer = "";
            bool initial;

            array1.Sort (new SortByExoplanetName ());
            array2.Sort (new SortByExoplanetName ());

            initial = true;

            for (int index = 0; index < array1.Count; ++index)
                {
                object object1 = array1 [index];
                object object2 = GetByName (array2, ( array1 [index] as Exoplanet ).Name);

                if (object2 == null)
                    {
                    if(initial)
                        stringer += "Added:\r\n";

                    stringer += "\t" + ( array1 [index] as Exoplanet ).Name + "\r\n";
                    initial = false;
                    }
                }

            initial = true;

            for (int index = 0; index < array1.Count; ++index)
                {
                object object1 = array1 [index];
                object object2 = GetByName (array2, ( array1 [index] as Exoplanet ).Name);

                if (object2 != null && !Helper.CompareEquals (object1, object2))
                    {
                    if (initial)
                        stringer += "Updated:\r\n";

                    stringer += "\t" + ( array1 [index] as Exoplanet ).Name + "\r\n";
                    initial = false;
                    }
                }

            initial = true;

            for (int index = 0; index < array2.Count; ++index)
                {
                object object1 = array2 [index];
                object object2 = GetByName (array1, ( array2 [index] as Exoplanet ).Name);

                if (object2 == null)
                    {
                    if (initial)
                        stringer += "Missing:\r\n";

                    stringer += "\t" + ( array2 [index] as Exoplanet ).Name + "\r\n";
                    initial = false;
                    }
                }

            return stringer;
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

        }
    }
