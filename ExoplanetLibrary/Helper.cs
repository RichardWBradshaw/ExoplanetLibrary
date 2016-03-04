using System;
using System.Collections;
using System.Reflection;

namespace ExoplanetLibrary
    {
    public class StarTypes
        {
        private string Name_ = "";
        public string Name
            {
            get { return Name_; }
            set { Name_ = value; }
            }

        private int Count_ = 0;
        public int Count
            {
            get { return Count_; }
            set { Count_ = value; }
            }

        private int NumberOfPlanets_ = 0;
        public int NumberOfPlanets
            {
            get { return NumberOfPlanets_; }
            set { NumberOfPlanets_ = value; }
            }

        private bool IsSpectualType_ = false;
        public bool IsSpectualType
            {
            get { return IsSpectualType_; }
            set { IsSpectualType_ = value; }
            }
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

        public static bool IsDefined (string value)
            {
            if (value != null)
                if (value.Length > 0)
                    return true;

            return false;
            }

        public static bool IsNegativeOrZero (string value)
            {
            double x;

            if (value != null)
                if (value.Length > 0)
                    if (double.TryParse (value, out x))
                        if (x <= 0.0)
                            return true;

            return false;
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
