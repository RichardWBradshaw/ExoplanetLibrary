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
        }
    }
