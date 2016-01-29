using System;
using System.Collections;
using System.Reflection;

namespace ExoplanetLibrary
    {
    public class StarTypes
        {
        public string Name;
        public int Count;
        }

    static public class Helper      // can not be instantiated, use for a utility class
        {
#if Singleton                       // needs to be instantiated, but only once
       private static Helper instance;

       private Helper()
           {
           }

       public static Helper Instance
           {
           get
               {
               if (instance == null)
                   {
                   instance = new Helper ();
                   }

               return instance;
               }
           }
#else
#endif

        static public string Format (string value, string minimumError, string maximumError)
            {
            if (minimumError != null && maximumError != null && minimumError.Length > 0 && maximumError.Length > 0)
                {
                if (string.Equals (minimumError, maximumError))
                    return value + " (+/-" + maximumError + ")";
                else
                    return value + " (+" + maximumError + "/-" + minimumError + ")";
                }
            else if (value != null && value.Length > 0)
                return value;
            else
                return " - ";
            }

        static public string Format (string value)
            {
            if (value != null && value.Length > 0)
                return value;
            else
                return " - ";
            }

        static public string ReplaceNonNumerics (string originalString)
            {
            if (originalString == "inf")
                return "";
            else if (originalString == "nan")
                return "";
            else
                return originalString;
            }

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

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (exoplanet.Star.Property.SPType != null)
                    if (exoplanet.Star.Property.SPType [0] == type)
                        ++matches;
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

                        types.Add (type);
                        }
                    }
                }

            return types;
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
#if more_code
                Exoplanet exoplanet1 = exoplanetArray1 [index] as Exoplanet;
                Exoplanet exoplanet2 = exoplanetArray2 [index] as Exoplanet;

                if (!CompareEquals (exoplanet1, exoplanet2))
                   return false;
#else
                object object1 = exoplanetArray1 [index];
                object object2 = exoplanetArray2 [index];

                if (!CompareEquals (object1, object2))
                    return false;
#endif
                }

            return true;
            }

#if more_code
        public static bool CompareEquals (Exoplanet objectFromCompare, Exoplanet objectToCompare)
            {
            if (objectFromCompare == null && objectToCompare == null)
                return true;
            else if (objectFromCompare == null && objectToCompare != null)
                return false;
            else if (objectFromCompare != null && objectToCompare == null)
                return false;

            PropertyInfo [] propertyInfoArray = objectFromCompare.GetType ().GetProperties (BindingFlags.Instance | BindingFlags.Public);

            foreach (PropertyInfo propertyInfo in propertyInfoArray)
                {
                object dataFromCompare = objectFromCompare.GetType ().GetProperty (propertyInfo.Name).GetValue (objectFromCompare, null);
                object dataToCompare = objectToCompare.GetType ().GetProperty (propertyInfo.Name).GetValue (objectToCompare, null);

                if (dataFromCompare != null && dataToCompare != null)
                    {
                    Type type = objectFromCompare.GetType ().GetProperty (propertyInfo.Name).GetValue (objectToCompare, null).GetType ();

                    if (propertyInfo.PropertyType.IsClass && !propertyInfo.PropertyType.FullName.Contains ("System.String"))
                        {
                        dynamic convertedFromValue = Convert.ChangeType (dataFromCompare, type);
                        dynamic convertedToValue = Convert.ChangeType (dataToCompare, type);

                        object result = CompareEquals (convertedFromValue, convertedToValue);

                        if (!( bool )result)
                            return false;
                        }
                    else if (!dataFromCompare.Equals (dataToCompare))
                        return false;
                    }
                else if (dataFromCompare != null && dataToCompare == null)
                    return false;
                else if (dataFromCompare == null && dataToCompare != null)
                    return false;
                }

            return true;
            }

        public static bool CompareEquals (Star objectFromCompare, Star objectToCompare)
            {
            if (objectFromCompare == null && objectToCompare == null)
                return true;
            else if (objectFromCompare == null && objectToCompare != null)
                return false;
            else if (objectFromCompare != null && objectToCompare == null)
                return false;

            PropertyInfo [] propertyInfoArray = objectFromCompare.GetType ().GetProperties (BindingFlags.Instance | BindingFlags.Public);

            foreach (PropertyInfo propertyInfo in propertyInfoArray)
                {
                object dataFromCompare = objectFromCompare.GetType ().GetProperty (propertyInfo.Name).GetValue (objectFromCompare, null);
                object dataToCompare = objectToCompare.GetType ().GetProperty (propertyInfo.Name).GetValue (objectToCompare, null);

                if (dataFromCompare != null && dataToCompare != null)
                    {
                    Type type = objectFromCompare.GetType ().GetProperty (propertyInfo.Name).GetValue (objectToCompare, null).GetType ();

                    if (propertyInfo.PropertyType.IsClass && !propertyInfo.PropertyType.FullName.Contains ("System.String"))
                        {
                        dynamic convertedFromValue = Convert.ChangeType (dataFromCompare, type);
                        dynamic convertedToValue = Convert.ChangeType (dataToCompare, type);

                        object result = CompareEquals (convertedFromValue, convertedToValue);

                        if (!( bool )result)
                            return false;
                        }
                    else if (!dataFromCompare.Equals (dataToCompare))
                        return false;
                    }
                else if (dataFromCompare != null && dataToCompare == null)
                    return false;
                else if (dataFromCompare == null && dataToCompare != null)
                    return false;
                }

            return true;
            }

        public static bool CompareEquals (Magnitude objectFromCompare, Magnitude objectToCompare)
            {
            if (objectFromCompare == null && objectToCompare == null)
                return true;
            else if (objectFromCompare == null && objectToCompare != null)
                return false;
            else if (objectFromCompare != null && objectToCompare == null)
                return false;

            PropertyInfo [] propertyInfoArray = objectFromCompare.GetType ().GetProperties (BindingFlags.Instance | BindingFlags.Public);

            foreach (PropertyInfo propertyInfo in propertyInfoArray)
                {
                object dataFromCompare = objectFromCompare.GetType ().GetProperty (propertyInfo.Name).GetValue (objectFromCompare, null);
                object dataToCompare = objectToCompare.GetType ().GetProperty (propertyInfo.Name).GetValue (objectToCompare, null);

                if (dataFromCompare != null && dataToCompare != null)
                    {
                    Type type = objectFromCompare.GetType ().GetProperty (propertyInfo.Name).GetValue (objectToCompare, null).GetType ();

                    if (propertyInfo.PropertyType.IsClass && !propertyInfo.PropertyType.FullName.Contains ("System.String"))
                        {
                        dynamic convertedFromValue = Convert.ChangeType (dataFromCompare, type);
                        dynamic convertedToValue = Convert.ChangeType (dataToCompare, type);

                        object result = CompareEquals (convertedFromValue, convertedToValue);

                        if (!( bool )result)
                            return false;
                        }
                    else if (!dataFromCompare.Equals (dataToCompare))
                        return false;
                    }
                else if (dataFromCompare != null && dataToCompare == null)
                    return false;
                else if (dataFromCompare == null && dataToCompare != null)
                    return false;
                }

            return true;
            }

        public static bool CompareEquals (Property objectFromCompare, Property objectToCompare)
            {
            if (objectFromCompare == null && objectToCompare == null)
                return true;
            else if (objectFromCompare == null && objectToCompare != null)
                return false;
            else if (objectFromCompare != null && objectToCompare == null)
                return false;

            PropertyInfo [] propertyInfoArray = objectFromCompare.GetType ().GetProperties (BindingFlags.Instance | BindingFlags.Public);

            foreach (PropertyInfo propertyInfo in propertyInfoArray)
                {
                object dataFromCompare = objectFromCompare.GetType ().GetProperty (propertyInfo.Name).GetValue (objectFromCompare, null);
                object dataToCompare = objectToCompare.GetType ().GetProperty (propertyInfo.Name).GetValue (objectToCompare, null);

                if (dataFromCompare != null && dataToCompare != null)
                    {
                    Type type = objectFromCompare.GetType ().GetProperty (propertyInfo.Name).GetValue (objectToCompare, null).GetType ();

                    if (propertyInfo.PropertyType.IsClass && !propertyInfo.PropertyType.FullName.Contains ("System.String"))
                        {
                        dynamic convertedFromValue = Convert.ChangeType (dataFromCompare, type);
                        dynamic convertedToValue = Convert.ChangeType (dataToCompare, type);

                        object result = CompareEquals (convertedFromValue, convertedToValue);

                        if (!( bool )result)
                            return false;
                        }
                    else if (!dataFromCompare.Equals (dataToCompare))
                        return false;
                    }
                else if (dataFromCompare != null && dataToCompare == null)
                    return false;
                else if (dataFromCompare == null && dataToCompare != null)
                    return false;
                }

            return true;
            }
#else
        public static bool CompareEquals (object objectFromCompare, object objectToCompare)
            {
            if (objectFromCompare == null && objectToCompare == null)
                return true;
            else if (objectFromCompare == null && objectToCompare != null)
                return false;
            else if (objectFromCompare != null && objectToCompare == null)
                return false;

            PropertyInfo [] propertyInfoArray = objectFromCompare.GetType ().GetProperties (BindingFlags.Instance | BindingFlags.Public);

            foreach (PropertyInfo propertyInfo in propertyInfoArray)
                {
                object dataFromCompare = objectFromCompare.GetType ().GetProperty (propertyInfo.Name).GetValue (objectFromCompare, null);
                object dataToCompare = objectToCompare.GetType ().GetProperty (propertyInfo.Name).GetValue (objectToCompare, null);

                if (dataFromCompare != null && dataToCompare != null)
                    {
                    if (propertyInfo.PropertyType.IsClass && !propertyInfo.PropertyType.FullName.Contains ("System.String"))
                        {
                        object result = CompareEquals (dataFromCompare, dataToCompare);

                        if (!( bool )result)
                            return false;
                        }
                    else if (!dataFromCompare.Equals (dataToCompare))
                        return false;
                    }
                else if (dataFromCompare != null && dataToCompare == null)
                    return false;
                else if (dataFromCompare == null && dataToCompare != null)
                    return false;
                }

            return true;
            }
#endif

        public static bool IsPlotable (string property)
            {
            if (property == "Mass")
                return true;
            else if (property == "Radius")
                return true;
            else if (property == "OrbitalPeriod")
                return true;
            else if (property == "SemiMajorAxis")
                return true;
            else if (property == "Eccentricity")
                return true;
            else if (property == "AngularDistance")
                return true;
            else if (property == "Inclination")
                return true;
            else if (property == "TzeroTr")
                return true;
            else if (property == "TzeroTrSec")
                return true;
            else if (property == "LambdaAngle")
                return true;
            else if (property == "TzeroVr")
                return true;
            else if (property == "LogG")
                return true;
            else if (property == "Omega")
                return true;
            else if (property == "Tperi")
                return true;
            else if (property == "ImpactParameter")
                return true;
            else if (property == "K")
                return true;
            else if (property == "GeometricAlbedo")
                return true;
            else if (property == "Tconj")
                return true;

            return false;
            }

        public static void GetMinimum (string str, ref double minimum)
            {
            if (str != null && str.Length > 0)
                {
                double value = 0.0;

                if (double.TryParse (str, out value))
                    if (value < minimum)
                        minimum = value;
                }
            }

        public static double GetMinimum (ArrayList exoplanets, string property)
            {
            double minimum = double.MaxValue;

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (property == "Mass")
                    GetMinimum (exoplanet.Mass, ref minimum);
                else if (property == "Radius")
                    GetMinimum (exoplanet.Radius, ref minimum);
                else if (property == "OrbitalPeriod")
                    GetMinimum (exoplanet.OrbitalPeriod, ref minimum);
                else if (property == "SemiMajorAxis")
                    GetMinimum (exoplanet.SemiMajorAxis, ref minimum);
                else if (property == "Eccentricity")
                    GetMinimum (exoplanet.Eccentricity, ref minimum);
                else if (property == "AngularDistance")
                    GetMinimum (exoplanet.AngularDistance, ref minimum);
                else if (property == "Inclination")
                    GetMinimum (exoplanet.Inclination, ref minimum);
                else if (property == "TzeroTr")
                    GetMinimum (exoplanet.TzeroTr, ref minimum);
                else if (property == "TzeroTrSec")
                    GetMinimum (exoplanet.TzeroTrSec, ref minimum);
                else if (property == "LambdaAngle")
                    GetMinimum (exoplanet.LambdaAngle, ref minimum);
                else if (property == "TzeroVr")
                    GetMinimum (exoplanet.TzeroVr, ref minimum);
                else if (property == "LogG")
                    GetMinimum (exoplanet.LogG, ref minimum);
                else if (property == "Omega")
                    GetMinimum (exoplanet.Omega, ref minimum);
                else if (property == "Tperi")
                    GetMinimum (exoplanet.Tperi, ref minimum);
                else if (property == "ImpactParameter")
                    GetMinimum (exoplanet.ImpactParameter, ref minimum);
                else if (property == "K")
                    GetMinimum (exoplanet.K, ref minimum);
                else if (property == "GeometricAlbedo")
                    GetMinimum (exoplanet.GeometricAlbedo, ref minimum);
                else if (property == "Tconj")
                    GetMinimum (exoplanet.Tconj, ref minimum);
                }

            return minimum;
            }

        public static void GetMaximum (string str, ref double maximum)
            {
            if (str != null && str.Length > 0)
                {
                double value = 0.0;

                if (double.TryParse (str, out value))
                    if (value > maximum)
                        maximum = value;
                }
            }

        public static double GetMaximum (ArrayList exoplanets, string property)
            {
            double maximum = double.MinValue;

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (property == "Mass")
                    GetMaximum (exoplanet.Mass, ref maximum);
                else if (property == "Radius")
                    GetMaximum (exoplanet.Radius, ref maximum);
                else if (property == "OrbitalPeriod")
                    GetMaximum (exoplanet.OrbitalPeriod, ref maximum);
                else if (property == "SemiMajorAxis")
                    GetMaximum (exoplanet.SemiMajorAxis, ref maximum);
                else if (property == "Eccentricity")
                    GetMaximum (exoplanet.Eccentricity, ref maximum);
                else if (property == "AngularDistance")
                    GetMaximum (exoplanet.AngularDistance, ref maximum);
                else if (property == "Inclination")
                    GetMaximum (exoplanet.Inclination, ref maximum);
                else if (property == "TzeroTr")
                    GetMaximum (exoplanet.TzeroTr, ref maximum);
                else if (property == "TzeroTrSec")
                    GetMaximum (exoplanet.TzeroTrSec, ref maximum);
                else if (property == "LambdaAngle")
                    GetMaximum (exoplanet.LambdaAngle, ref maximum);
                else if (property == "TzeroVr")
                    GetMaximum (exoplanet.TzeroVr, ref maximum);
                else if (property == "LogG")
                    GetMaximum (exoplanet.LogG, ref maximum);
                else if (property == "Omega")
                    GetMaximum (exoplanet.Omega, ref maximum);
                else if (property == "Tperi")
                    GetMaximum (exoplanet.Tperi, ref maximum);
                else if (property == "ImpactParameter")
                    GetMaximum (exoplanet.ImpactParameter, ref maximum);
                else if (property == "K")
                    GetMaximum (exoplanet.K, ref maximum);
                else if (property == "GeometricAlbedo")
                    GetMaximum (exoplanet.GeometricAlbedo, ref maximum);
                else if (property == "Tconj")
                    GetMaximum (exoplanet.Tconj, ref maximum);
                else if (property == "GeometricAlbedo")
                    GetMaximum (exoplanet.GeometricAlbedo, ref maximum);
                }

            return maximum;
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

        static bool IsDefined (string value)
            {
            if (value != null)
                if (value.Length > 0)
                    return true;

            return false;
            }

        static bool IsNegativeOrZero (string value)
            {
            double x;

            if (value != null)
                if (value.Length > 0)
                    if( double.TryParse(value, out x))
                        if( x <= 0.0)
                            return true;

            return false;
            }

        public static ArrayList PlanetsWithMass (ArrayList exoplanets, bool includeErrors)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (IsDefined (exoplanet.Mass))
                    if (includeErrors)
                        {
                        if (IsDefined (exoplanet.MassErrorMax))
                            if (IsDefined (exoplanet.MassErrorMin))
                                array.Add (exoplanet);
                        }
                    else
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetMass ());

            return array;
            }

        public static ArrayList PlanetsWithRadius (ArrayList exoplanets, bool includeErrors)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (IsDefined (exoplanet.Radius))
                    if (includeErrors)
                        {
                        if (IsDefined (exoplanet.RadiusErrorMax))
                            if (IsDefined (exoplanet.RadiusErrorMin))
                                array.Add (exoplanet);
                        }
                    else
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetRadius ());

            return array;
            }

        public static ArrayList PlanetsWithOrbitalPeriods (ArrayList exoplanets, bool includeErrors)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (IsDefined (exoplanet.OrbitalPeriod))
                    if (includeErrors)
                        {
                        if (IsDefined (exoplanet.OrbitalPeriodErrorMax))
                            if (IsDefined (exoplanet.OrbitalPeriodErrorMin))
                                array.Add (exoplanet);
                        }
                    else
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetOrbitalPeriod ());

            return array;
            }

        public static ArrayList PlanetsWithSemiMajorAxis (ArrayList exoplanets, bool includeErrors)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (IsDefined (exoplanet.SemiMajorAxis))
                    if (includeErrors)
                        {
                        if (IsDefined (exoplanet.SemiMajorAxisErrorMax))
                            if (IsDefined (exoplanet.SemiMajorAxisErrorMin))
                                array.Add (exoplanet);
                        }
                    else
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetSemiMajorAxis ());

            return array;
            }

        public static ArrayList PlanetsWithEccentrity (ArrayList exoplanets, bool includeErrors)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (IsDefined (exoplanet.Eccentricity))
                    if (includeErrors)
                        {
                        if (IsDefined (exoplanet.EccentricityErrorMax))
                            if (IsDefined (exoplanet.EccentricityErrorMin))
                                array.Add (exoplanet);
                        }
                    else
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetEccentricity ());

            return array;
            }

        public static ArrayList PlanetsWithAngularDistance (ArrayList exoplanets)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (IsDefined (exoplanet.AngularDistance))
                    array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetAngularDistance ());

            return array;
            }

        public static ArrayList PlanetsWithInclination (ArrayList exoplanets, bool includeErrors)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (IsDefined (exoplanet.Inclination))
                    if (includeErrors)
                        {
                        if (IsDefined (exoplanet.InclinationErrorMax))
                            if (IsDefined (exoplanet.InclinationErrorMin))
                                array.Add (exoplanet);
                        }
                    else
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetInclination ());

            return array;
            }

        public static ArrayList PlanetsWithTzeroTr (ArrayList exoplanets, bool includeErrors)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (IsDefined (exoplanet.TzeroTr))
                    if (includeErrors)
                        {
                        if (IsDefined (exoplanet.TzeroTrErrorMax))
                            if (IsDefined (exoplanet.TzeroTrErrorMin))
                                array.Add (exoplanet);
                        }
                    else
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetTzeroTr ());

            return array;
            }

        public static ArrayList PlanetsWithTzeroTrSec (ArrayList exoplanets, bool includeErrors)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (IsDefined (exoplanet.TzeroTrSec))
                    if (includeErrors)
                        {
                        if (IsDefined (exoplanet.TzeroTrSecErrorMax))
                            if (IsDefined (exoplanet.TzeroTrSecErrorMin))
                                array.Add (exoplanet);
                        }
                    else
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetTzeroTrSec ());

            return array;
            }

        public static ArrayList PlanetsWithLambdaAngle (ArrayList exoplanets, bool includeErrors)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (IsDefined (exoplanet.LambdaAngle))
                    if (includeErrors)
                        {
                        if (IsDefined (exoplanet.LambdaAngleErrorMax))
                            if (IsDefined (exoplanet.LambdaAngleErrorMin))
                                array.Add (exoplanet);
                        }
                    else
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetLambdaAngle ());

            return array;
            }

        public static ArrayList PlanetsWithTzeroVr (ArrayList exoplanets, bool includeErrors)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (IsDefined (exoplanet.TzeroVr))
                    if (includeErrors)
                        {
                        if (IsDefined (exoplanet.TzeroVrErrorMax))
                            if (IsDefined (exoplanet.TzeroVrErrorMin))
                                array.Add (exoplanet);
                        }
                    else
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetTzeroVr ());

            return array;
            }

        public static ArrayList PlanetsWithTemperatureCalculated (ArrayList exoplanets)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (IsDefined (exoplanet.TemperatureCalculated))
                    array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetTemperatureCalculated ());

            return array;
            }

        public static ArrayList PlanetsWithTemperatureMeasured (ArrayList exoplanets)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (IsDefined (exoplanet.TemperatureMeasured))
                    array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetTemperatureMeasured ());

            return array;
            }

        public static ArrayList PlanetsWithLogG (ArrayList exoplanets)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (IsDefined (exoplanet.LogG))
                    array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetLogG ());

            return array;
            }

        public static ArrayList PlanetsWithOmega (ArrayList exoplanets, bool includeErrors)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (IsDefined (exoplanet.Omega))
                    if (includeErrors)
                        {
                        if (IsDefined (exoplanet.OmegaErrorMax))
                            if (IsDefined (exoplanet.OmegaErrorMin))
                                array.Add (exoplanet);
                        }
                    else
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetOmega ());

            return array;
            }

        public static ArrayList PlanetsWithTperi (ArrayList exoplanets, bool includeErrors)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (IsDefined (exoplanet.Tperi))
                    if (includeErrors)
                        {
                        if (IsDefined (exoplanet.TperiErrorMax))
                            if (IsDefined (exoplanet.TperiErrorMin))
                                array.Add (exoplanet);
                        }
                    else
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetTperi ());

            return array;
            }

        public static ArrayList PlanetsWithK (ArrayList exoplanets, bool includeErrors, bool excludeNegatives)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (IsDefined (exoplanet.K))
                    if (excludeNegatives && IsNegativeOrZero (exoplanet.K))
                        {
                        ;
                        }
                    else if (includeErrors)
                        {
                        if (IsDefined (exoplanet.KErrorMax))
                            if (IsDefined (exoplanet.KErrorMin))
                                array.Add (exoplanet);
                        }
                    else
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetK ());

            return array;
            }

        public static ArrayList PlanetsWithGeometricAlbedo (ArrayList exoplanets, bool includeErrors)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (IsDefined (exoplanet.GeometricAlbedo))
                    if (includeErrors)
                        {
                        if (IsDefined (exoplanet.GeometricAlbedoErrorMax))
                            if (IsDefined (exoplanet.GeometricAlbedoErrorMin))
                                array.Add (exoplanet);
                        }
                    else
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetGeometricAlbedo ());

            return array;
            }

        public static ArrayList PlanetsWithTconj (ArrayList exoplanets, bool includeErrors)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (IsDefined (exoplanet.Tconj))
                    if (includeErrors)
                        {
                        if (IsDefined (exoplanet.TconjErrorMax))
                            if (IsDefined (exoplanet.TconjErrorMin))
                                array.Add (exoplanet);
                        }
                    else
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetTconj ());

            return array;
            }

        public static ArrayList PlanetsWithEccentricityAndMass (ArrayList exoplanets)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (IsDefined (exoplanet.Eccentricity))
                    if (IsDefined (exoplanet.Mass))
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetEccentricity ());

            return array;
            }

        public static ArrayList PlanetsWithMassAndRadius (ArrayList exoplanets)
            {
            ArrayList array = new ArrayList ();

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (IsDefined (exoplanet.Mass))
                    if (IsDefined (exoplanet.Radius))
                        array.Add (exoplanet);
                }

            array.Sort (new SortByExoplanetMass ());

            return array;
            }

        public static double GetMinimum (double [] values)
            {
            double minimum = double.MaxValue;

            foreach (double value in values)
                if (value < minimum)
                    minimum = value;

            return minimum;
            }

        public static double GetMaximum (double [] values)
            {
            double maximum = double.MinValue;

            foreach (double value in values)
                if (value > maximum)
                    maximum = value;

            return maximum;
            }
        }
    }
