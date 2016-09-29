using System;
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

        static public string Format (string value, string minimumError, string maximumError, string units)
            {
            if (minimumError != null && maximumError != null && minimumError.Length > 0 && maximumError.Length > 0)
                {
                if (string.Equals (minimumError, maximumError))
                    return value + " (+/-" + maximumError + ") " + units;
                else
                    return value + " (+" + maximumError + "/-" + minimumError + ") " + units;
                }
            else if (value != null && value.Length > 0)
                return value + " " + units;
            else
                return " - ";
            }

        static public string Format (string value, string units)
            {
            if (value != null && value.Length > 0)
                return value + " " + units;
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
            else if (originalString == "null")
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

        //
        // CSV date format is 02/23/2016, where as XML date format is 2016-02-23
        //

        static public string FormatDateCSV2XML (string text)
            {
            if (!string.IsNullOrEmpty (text))
                {
                char [] delimiterChars = { '/' };
                string [] strings = text.Split (delimiterChars);

                if (strings.Length == 3)
                    {
                    text = strings [2] + "-" + strings [0] + "-" + strings [1];
                    }
                }

            return text;
            }

        static public string FormatDateXML2CSV (string text)
            {
            if (!string.IsNullOrEmpty (text))
                {
                char [] delimiterChars = { '-' };
                string [] strings = text.Split (delimiterChars);

                if (strings.Length == 3)
                    {
                    text = strings [2] + "/" + strings [0] + "/" + strings [1];
                    }
                }

            return text;
            }

        public static string ReplaceInQuotedDelimitor (string text)
            {
            bool withinQuotes = false;
            string replacement = "";

            for (int index = 0; index < text.Length; ++index)
                {
                if (text [index] == '"')
                    withinQuotes = withinQuotes == true ? false : true;
                else if (withinQuotes == true)
                    {
                    if (text [index] == ',')
                        replacement += ';';
                    else if (text [index] == '\t')
                        replacement += ' ';
                    else
                        replacement += text [index];
                    }
                else
                    replacement += text [index];
                }

            return replacement;
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
                        {
                        string fromString = dataFromCompare as string;
                        string toString = dataToCompare as string;
                        double fromDouble, toDouble;

                        if (double.TryParse (fromString, out fromDouble))
                            if (double.TryParse (toString, out toDouble))
                                {
                                double tolerence = 0.0001;

                                switch (fromString.Length - fromString.IndexOf ('.') - 1)
                                    {
                                    case 0: tolerence = 0.0; break;
                                    case 1: tolerence = 0.0; break;
                                    case 2: tolerence = 0.1; break;
                                    case 3: tolerence = 0.01; break;
                                    case 4: tolerence = 0.001; break;
                                    case 5: tolerence = 0.0001; break;
                                    case 6: tolerence = 0.00001; break;
                                    }

                                if (Math.Abs (fromDouble - toDouble) > tolerence)
                                    return false;
                                }
                            else
                                return false;
                        else
                            return false;
                        }
                    }
                else if (dataFromCompare != null && dataToCompare == null)
                    {
                    string fromString = dataFromCompare as string;
                    double fromDouble;
                    // kludge: if one value is null and the other value is 0.0 then treat as equal
                    if (!( double.TryParse (fromString, out fromDouble) && fromDouble == 0.0 ))
                        return false;
                    }
                else if (dataFromCompare == null && dataToCompare != null)
                    {
                    string toString = dataToCompare as string;
                    double toDouble;
                    // kludge: if one value is null and the other value is 0.0 then treat as equal
                    if (!( double.TryParse (toString, out toDouble) && toDouble == 0.0 ))
                        return false;
                    }
                }

            return true;
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

        //
        // look at embedded numerics Kepler-1 a, Kepler-1 b, ..., Kepler-2 c, Kepler-3 c, Kepler-10 a, Kepler-11 a, ..., Kepler-100 a, Kepler-101 a
        //

        static public int AlphaNumericSort (string string1, string string2)
            {
            int [] firstNumeric = { -1, -1 };
            int [] lastNumeric = { -1, -1 };

            if (string2.StartsWith (FindNumericRange (string1, out firstNumeric [0], out lastNumeric [0])))
                if (firstNumeric [0] > 0)
                    {
                    FindNumericRange (string2, out firstNumeric [1], out lastNumeric [1]);

                    if (firstNumeric [0] > 0 && lastNumeric [0] > 0)
                        if (firstNumeric [1] > 0 && lastNumeric [1] > 0)
                            {
                            string numeric1 = string1.Substring (firstNumeric [0], lastNumeric [0] - firstNumeric [0] + 1);
                            string numeric2 = string2.Substring (firstNumeric [1], lastNumeric [1] - firstNumeric [1] + 1);
                            int i1, i2;

                            if (int.TryParse (numeric1, out i1) && int.TryParse (numeric2, out i2))
                                if (i1 != i2)
                                    return ( i1 < i2 ) ? -1 : 1;
                            }
                    }

            return 0;
            }

        static private string FindNumericRange (string stringer, out int firstNumeric, out int lastNumeric)
            {
            string name = "";

            firstNumeric = lastNumeric = -1;

            if (( stringer [0] >= 'a' && stringer [0] <= 'z' ) || ( stringer [0] >= 'A' && stringer [0] <= 'Z' ))
                for (int index = 0; index < stringer.Length; ++index)
                    if (stringer [index] >= '0' && stringer [index] <= '9')
                        {
                        if (firstNumeric == -1)
                            {
                            firstNumeric = index;
                            lastNumeric = index;
                            }
                        else
                            lastNumeric = index;
                        }
                    else
                        {
                        if (firstNumeric == -1)
                            name += stringer [index];
                        else
                            break;
                        }

            return name;
            }
        }

    public enum BestFitType
        {
        Line = 0,
        Curve = 1,
        }

    public class BestFit
        {
        static private BestFitLine Line = new BestFitLine ();
        static private BestFitCurve Curve = new BestFitCurve ();
        static private BestFitType Type = BestFitType.Line;

        public BestFit (BestFitType type)
            {
            Type = type;
            }

        public void Compute (double [] x, double [] y)
            {
            if (Type == BestFitType.Line)
                Line.Compute (x, y);
            else if (Type == BestFitType.Curve)
                Curve.Compute (x, y);
            }

        public double ComputeYAtX (double x)
            {
            if (Type == BestFitType.Line)
                return Line.ComputeYAtX ( x);
            else if (Type == BestFitType.Curve)
                return Curve.ComputeYAtX ( x);
            else
                return 0.0;
            }
        }

    public class BestFitLine
        {
        private static double A;
        private static double B;

        public BestFitLine ()
            {
            A = 0.0;
            B = 0.0;
            }

        public void Compute (double [] x, double [] y)
            {
            double sumX = 0.0, sumY = 0.0;

            for (int index = 0; index < x.Length; ++index)
                {
                sumX += x [index];
                sumY += y [index];
                }

            double meanX = sumX / x.Length;
            double meanY = sumY / x.Length;

            double sumXSquared = 0.0;
            double sumXY = 0.0;

            for (int index = 0; index < x.Length; ++index)
                {
                sumXSquared += x [index] * x [index];
                sumXY += x [index] * y [index];
                }

            A = ( sumXY / x.Length - meanX * meanY ) / ( sumXSquared / x.Length - meanX * meanX );
            B = ( A * meanX - meanY );
            }

        public double ComputeYAtX (double x)
            {
            return A * x - B;
            }
        }

    public class BestFitCurve
        {
        private static double A;
        private static double B;

        public BestFitCurve ()
            {
            A = 0.0;
            B = 0.0;
            }

        public void Compute (double [] x, double [] y)
            {
            double sumX = 0.0, sumY = 0.0, sumxY = 0.0, sumXX = 0.0, b;

            for (int index = 0; index < x.Length; ++index)
                {
                sumX += x [index];
                sumY += Math.Log (y [index]);
                sumxY += x [index] * Math.Log (y [index]);
                sumXX += x [index] * x [index];
                }

            A = ( x.Length * sumxY - sumX * sumY ) / ( x.Length * sumXX - sumX * sumX );
            b = ( sumY - A * sumX ) / x.Length;
            B = Math.Pow (Math.E, b);
            }

        public double ComputeYAtX (double x)
            {
            return B * Math.Pow (Math.E, A * x);
            }
        }
    }
