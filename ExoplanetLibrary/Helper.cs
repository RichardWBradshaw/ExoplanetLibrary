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
                    return false;
                else if (dataFromCompare == null && dataToCompare != null)
                    return false;
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

    public class Indexer
        {
        static public int Name;

        static public int Mass;
        static public int MassErrorMin;
        static public int MassErrorMax;

        static public int MassSini;
        static public int MassSiniErrorMin;
        static public int MassSiniErrorMax;

        static public int Radius;
        static public int RadiusErrorMin;
        static public int RadiusErrorMax;

        static public int OrbitalPeriod;
        static public int OrbitalPeriodErrorMin;
        static public int OrbitalPeriodErrorMax;

        static public int SemiMajorAxis;
        static public int SemiMajorAxisErrorMin;
        static public int SemiMajorAxisErrorMax;

        static public int Eccentricity;
        static public int EccentricityErrorMin;
        static public int EccentricityErrorMax;

        static public int AngularDistance;

        static public int Inclination;
        static public int InclinationErrorMin;
        static public int InclinationErrorMax;

        static public int TzeroTr;
        static public int TzeroTrErrorMin;
        static public int TzeroTrErrorMax;

        static public int TzeroTrSec;
        static public int TzeroTrSecErrorMin;
        static public int TzeroTrSecErrorMax;

        static public int LambdaAngle;
        static public int LambdaAngleErrorMin;
        static public int LambdaAngleErrorMax;

        static public int TzeroVr;
        static public int TzeroVrErrorMin;
        static public int TzeroVrErrorMax;

        static public int TemperatureCalculated;

        static public int TemperatureMeasured;

        static public int TemperatureHotPointLo;

        static public int LogG;

        static public int Status;

        static public int Discovered;

        static public int Updated;

        static public int Omega;
        static public int OmegaErrorMin;
        static public int OmegaErrorMax;

        static public int Tperi;
        static public int TperiErrorMin;
        static public int TperiErrorMax;

        static public int DetectionType;

        static public int Molecules;

        static public int ImpactParameter;
        static public int ImpactParameterErrorMin;
        static public int ImpactParameterErrorMax;

        static public int VelocitySemiamplitude;
        static public int VelocitySemiamplitudeErrorMin;
        static public int VelocitySemiamplitudeErrorMax;

        static public int GeometricAlbedo;
        static public int GeometricAlbedoErrorMin;
        static public int GeometricAlbedoErrorMax;

        static public int Tconj;
        static public int TconjErrorMin;
        static public int TconjErrorMax;

        static public int MassDetectionType;

        static public int RadiusDetectionType;

        static public int AlternateNames;

        static public int StarName;
        static public int StarRightAccession;
        static public int StarDeclination;

        static public int StarMagnitudeV;
        static public int StarMagnitudeI;
        static public int StarMagnitudeJ;
        static public int StarMagnitudeH;
        static public int StarMagnitudeK;

        static public int StarDistance;
        static public int StarDistanceErrorMin;
        static public int StarDistanceErrorMax;

        static public int StarMetallicity;
        static public int StarMetallicityErrorMin;
        static public int StarMetallicityErrorMax;

        static public int StarMass;
        static public int StarMassErrorMin;
        static public int StarMassErrorMax;

        static public int StarRadius;
        static public int StarRadiusErrorMin;
        static public int StarRadiusErrorMax;

        static public int StarSPType;

        static public int StarAge;
        static public int StarAgeErrorMin;
        static public int StarAgeErrorMax;

        static public int StarTeff;
        static public int StarTeffErrorMin;
        static public int StarTeffErrorMax;

        static public int StarDetectedDisc;

        static public int StarMagneticField;

        static public int StarAlternateNames;

        static public void SetAllIndex (string stringer)
            {
            char [] delimiterChars = { ',', '\t' };
            string [] strings = stringer.Split (delimiterChars);
            int numberOfStrings = strings.Length;

            if (strings [0].StartsWith ("# "))
                strings [0] = strings [0].Replace ("# ", "");

            for (int index = 0; index < numberOfStrings; ++index)
                SetIndex (strings [index], index);
            }

        static public void SetIndex (string substring, int index)
            {
            switch (substring.Trim ())
                {
                case "name": Name = index; break;

                case "mass": Mass = index; break;
                case "mass_err_min": MassErrorMin = index; break;
                case "mass_err_max": MassErrorMax = index; break;
                case "mass_error_min": MassErrorMin = index; break;
                case "mass_error_max": MassErrorMax = index; break;

                case "mass_sini": MassSini = index; break;
                case "mass_sini_error_min": MassSiniErrorMin = index; break;
                case "mass_sini_error_max": MassSiniErrorMax = index; break;

                case "radius": Radius = index; break;
                case "radius_error_min": RadiusErrorMin = index; break;
                case "radius_error_max": RadiusErrorMax = index; break;

                case "orbital_period": OrbitalPeriod = index; break;
                case "orbital_period_err_min": OrbitalPeriodErrorMin = index; break;
                case "orbital_period_err_max": OrbitalPeriodErrorMax = index; break;
                case "orbital_period_error_min": OrbitalPeriodErrorMin = index; break;
                case "orbital_period_error_max": OrbitalPeriodErrorMax = index; break;

                case "semi_major_axis": SemiMajorAxis = index; break;
                case "semi_major_axis_error_min": SemiMajorAxisErrorMin = index; break;
                case "semi_major_axis_error_max": SemiMajorAxisErrorMax = index; break;

                case "eccentricity": Eccentricity = index; break;
                case "eccentricity_error_min": EccentricityErrorMin = index; break;
                case "eccentricity_error_max": EccentricityErrorMax = index; break;

                case "inclination": Inclination = index; break;
                case "inclination_error_min": InclinationErrorMin = index; break;
                case "inclination_error_max": InclinationErrorMax = index; break;

                case "angular_distance": AngularDistance = index; break;

                case "discovered": Discovered = index; break;

                case "updated": Updated = index; break;

                case "omega": Omega = index; break;
                case "omega_error_min": OmegaErrorMin = index; break;
                case "omega_error_max": OmegaErrorMax = index; break;

                case "tperi": Tperi = index; break;
                case "tperi_error_min": TperiErrorMin = index; break;
                case "tperi_error_max": TperiErrorMax = index; break;

                case "tconj": Tconj = index; break;
                case "tconj_error_min": TconjErrorMin = index; break;
                case "tconj_error_max": TconjErrorMax = index; break;

                case "tzero_tr": TzeroTr = index; break;
                case "tzero_tr_error_min": TzeroTrErrorMin = index; break;
                case "tzero_tr_error_max": TzeroTrErrorMax = index; break;

                case "tzero_tr_sec": TzeroTrSec = index; break;
                case "tzero_tr_sec_error_min": TzeroTrSecErrorMin = index; break;
                case "tzero_tr_sec_error_max": TzeroTrSecErrorMax = index; break;

                case "lambda_angle": LambdaAngle = index; break;
                case "lambda_angle_error_min": LambdaAngleErrorMin = index; break;
                case "lambda_angle_error_max": LambdaAngleErrorMax = index; break;

                case "impact_parameter": ImpactParameter = index; break;
                case "impact_parameter_error_min": ImpactParameterErrorMin = index; break;
                case "impact_parameter_error_max": ImpactParameterErrorMax = index; break;

                case "tzero_vr": TzeroVr = index; break;
                case "tzero_vr_error_min": TzeroVrErrorMin = index; break;
                case "tzero_vr_error_max": TzeroVrErrorMax = index; break;

                case "k": VelocitySemiamplitude = index; break;
                case "k_error_min": VelocitySemiamplitudeErrorMin = index; break;
                case "k_error_max": VelocitySemiamplitudeErrorMax = index; break;

                case "temp_calculated": TemperatureCalculated = index; break;

                case "temp_measured": TemperatureMeasured = index; break;

                case "hot_point_lon": TemperatureHotPointLo = index; break;

                case "geometric_albedo": GeometricAlbedo = index; break;
                case "geometric_albedo_error_min": GeometricAlbedoErrorMin = index; break;
                case "geometric_albedo_error_max": GeometricAlbedoErrorMax = index; break;

                case "log_g": LogG = index; break;

                case "publication_status": Status = index; break;

                case "detection_type": DetectionType = index; break;

                case "mass_detection_type": MassDetectionType = index; break;

                case "radius_detection_type": RadiusDetectionType = index; break;

                case "alternate_names": AlternateNames = index; break;

                case "molecules": Molecules = index; break;

                case "star_name": StarName = index; break;
                case "ra": StarRightAccession = index; break;
                case "dec": StarDeclination = index; break;

                case "mag_v": StarMagnitudeV = index; break;
                case "mag_i": StarMagnitudeI = index; break;
                case "mag_j": StarMagnitudeJ = index; break;
                case "mag_h": StarMagnitudeH = index; break;
                case "mag_k": StarMagnitudeK = index; break;

                case "star_distance": StarDistance = index; break;
                case "star_distance_error_min": StarDistanceErrorMin = index; break;
                case "star_distance_error_max": StarDistanceErrorMax = index; break;

                case "star_metallicity": StarMetallicity = index; break;
                case "star_metallicity_error_min": StarMetallicityErrorMin = index; break;
                case "star_metallicity_error_max": StarMetallicityErrorMax = index; break;

                case "star_mass": StarMass = index; break;
                case "star_mass_error_min": StarMassErrorMin = index; break;
                case "star_mass_error_max": StarMassErrorMax = index; break;

                case "star_radius": StarRadius = index; break;
                case "star_radius_error_min": StarRadiusErrorMin = index; break;
                case "star_radius_error_max": StarRadiusErrorMax = index; break;

                case "star_sp_type": StarSPType = index; break;

                case "star_age": StarAge = index; break;
                case "star_age_error_min": StarAgeErrorMin = index; break;
                case "star_age_error_max": StarAgeErrorMax = index; break;

                case "star_teff": StarTeff = index; break;
                case "star_teff_error_min": StarTeffErrorMin = index; break;
                case "star_teff_error_max": StarTeffErrorMax = index; break;

                case "star_detected_disc": StarDetectedDisc = index; break;

                case "star_magnetic_field": StarMagneticField = index; break;

                // added star_ to avoid conflict
                case "star_alternate_names": StarAlternateNames = index; break;

                default:
                    System.Windows.Forms.MessageBox.Show ("Error: " + substring);
                    break;
                }
            }
        }
    }
