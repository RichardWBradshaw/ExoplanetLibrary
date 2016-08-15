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

        static public void Initialize ()
            {
            Name = int.MinValue;

            Mass = int.MinValue;
            MassErrorMin = int.MinValue;
            MassErrorMax = int.MinValue;

            MassSini = int.MinValue;
            MassSiniErrorMin = int.MinValue;
            MassSiniErrorMax = int.MinValue;

            Radius = int.MinValue;
            RadiusErrorMin = int.MinValue;
            RadiusErrorMax = int.MinValue;

            OrbitalPeriod = int.MinValue;
            OrbitalPeriodErrorMin = int.MinValue;
            OrbitalPeriodErrorMax = int.MinValue;

            SemiMajorAxis = int.MinValue;
            SemiMajorAxisErrorMin = int.MinValue;
            SemiMajorAxisErrorMax = int.MinValue;

            Eccentricity = int.MinValue;
            EccentricityErrorMin = int.MinValue;
            EccentricityErrorMax = int.MinValue;

            AngularDistance = int.MinValue;

            Inclination = int.MinValue;
            InclinationErrorMin = int.MinValue;
            InclinationErrorMax = int.MinValue;

            TzeroTr = int.MinValue;
            TzeroTrErrorMin = int.MinValue;
            TzeroTrErrorMax = int.MinValue;

            TzeroTrSec = int.MinValue;
            TzeroTrSecErrorMin = int.MinValue;
            TzeroTrSecErrorMax = int.MinValue;

            LambdaAngle = int.MinValue;
            LambdaAngleErrorMin = int.MinValue;
            LambdaAngleErrorMax = int.MinValue;

            TzeroVr = int.MinValue;
            TzeroVrErrorMin = int.MinValue;
            TzeroVrErrorMax = int.MinValue;

            TemperatureCalculated = int.MinValue;

            TemperatureMeasured = int.MinValue;

            TemperatureHotPointLo = int.MinValue;

            LogG = int.MinValue;

            Status = int.MinValue;

            Discovered = int.MinValue;

            Updated = int.MinValue;

            Omega = int.MinValue;
            OmegaErrorMin = int.MinValue;
            OmegaErrorMax = int.MinValue;

            Tperi = int.MinValue;
            TperiErrorMin = int.MinValue;
            TperiErrorMax = int.MinValue;

            DetectionType = int.MinValue;

            Molecules = int.MinValue;

            ImpactParameter = int.MinValue;
            ImpactParameterErrorMin = int.MinValue;
            ImpactParameterErrorMax = int.MinValue;

            VelocitySemiamplitude = int.MinValue;
            VelocitySemiamplitudeErrorMin = int.MinValue;
            VelocitySemiamplitudeErrorMax = int.MinValue;

            GeometricAlbedo = int.MinValue;
            GeometricAlbedoErrorMin = int.MinValue;
            GeometricAlbedoErrorMax = int.MinValue;

            Tconj = int.MinValue;
            TconjErrorMin = int.MinValue;
            TconjErrorMax = int.MinValue;

            MassDetectionType = int.MinValue;

            RadiusDetectionType = int.MinValue;

            AlternateNames = int.MinValue;

            StarName = int.MinValue;
            StarRightAccession = int.MinValue;
            StarDeclination = int.MinValue;

            StarMagnitudeV = int.MinValue;
            StarMagnitudeI = int.MinValue;
            StarMagnitudeJ = int.MinValue;
            StarMagnitudeH = int.MinValue;
            StarMagnitudeK = int.MinValue;

            StarDistance = int.MinValue;
            StarDistanceErrorMin = int.MinValue;
            StarDistanceErrorMax = int.MinValue;

            StarMetallicity = int.MinValue;
            StarMetallicityErrorMin = int.MinValue;
            StarMetallicityErrorMax = int.MinValue;

            StarMass = int.MinValue;
            StarMassErrorMin = int.MinValue;
            StarMassErrorMax = int.MinValue;

            StarRadius = int.MinValue;
            StarRadiusErrorMin = int.MinValue;
            StarRadiusErrorMax = int.MinValue;

            StarSPType = int.MinValue;

            StarAge = int.MinValue;
            StarAgeErrorMin = int.MinValue;
            StarAgeErrorMax = int.MinValue;

            StarTeff = int.MinValue;
            StarTeffErrorMin = int.MinValue;
            StarTeffErrorMax = int.MinValue;

            StarDetectedDisc = int.MinValue;

            StarMagneticField = int.MinValue;

            StarAlternateNames = int.MinValue;
            }

        static public void SetAllIndex (string stringer)
            {
            char [] delimiterChars = { ',', '\t' };
            string [] strings = stringer.Split (delimiterChars);
            int numberOfStrings = strings.Length;

            if (strings [0].StartsWith ("# "))
                strings [0] = strings [0].Replace ("# ", "");

            Initialize ();

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

                case "alternate_names":                         // .csv and .dat use the save name for plaent and stellar alternate names
                    if (AlternateNames == int.MinValue)         // planet alternate name
                        AlternateNames = index;
                    else
                        StarAlternateNames = index;             // star alternate name

                    break;

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

                case "star_alternate_names": StarAlternateNames = index; break;

                //

                case "rowid": break;

                case "pl_hostname": StarName = index; break;
                case "pl_letter": break;

                case "pl_discmethod": DetectionType = index; break;

                case "pl_pnum": break;

                case "pl_orbper": OrbitalPeriod = index; break;
                case "pl_orbpererr1": OrbitalPeriodErrorMax = index; break;
                case "pl_orbpererr2": OrbitalPeriodErrorMin = index; break;
                case "pl_orbperlim": break;

                case "pl_orbsmax": SemiMajorAxis = index; break;
                case "pl_orbsmaxerr1": SemiMajorAxisErrorMax = index; break;
                case "pl_orbsmaxerr2": SemiMajorAxisErrorMin = index; break;
                case "pl_orbsmaxlim": break;

                case "pl_orbeccen": Eccentricity = index; break;
                case "pl_orbeccenerr1": EccentricityErrorMax = index; break;
                case "pl_orbeccenerr2": EccentricityErrorMin = index; break;
                case "pl_orbeccenlim": break;

                case "pl_orbincl": Inclination = index; break;
                case "pl_orbinclerr1": InclinationErrorMax = index; break;
                case "pl_orbinclerr2": InclinationErrorMin = index; break;
                case "pl_orbincllim": break;

                case "pl_bmassj": break;
                case "pl_bmassjerr1": break;
                case "pl_bmassjerr2":  break;
                case "pl_bmassjlim": break;
                case "pl_bmassprov": break;

                case "pl_radj": Radius = index; break;
                case "pl_radjerr1": RadiusErrorMax = index; break;
                case "pl_radjerr2": RadiusErrorMin = index; break;
                case "pl_radjlim": break;

                case "pl_dens": break;
                case "pl_denserr1": break;
                case "pl_denserr2": break;
                case "pl_denslim": break;

                case "pl_ttvflag": break;

                case "pl_kepflag": break;

                case "pl_k2flag": break;

                case "pl_nnotes": break;

                case "pl_name": Name = index; break;

                case "pl_tranflag": break;

                case "pl_rvflag": break;

                case "pl_imgflag": break;

                case "pl_astflag": break;

                case "pl_omflag": break;

                case "pl_cbflag": break;

                case "pl_orbtper": break;
                case "pl_orbtpererr1": break;
                case "pl_orbtpererr2": break;
                case "pl_orbtperlim": break;

                case "pl_orblper": break;
                case "pl_orblpererr1": break;
                case "pl_orblpererr2": break;
                case "pl_orblperlim": break;

                case "pl_rvamp": break;
                case "pl_rvamperr1": break;
                case "pl_rvamperr2": break;
                case "pl_rvamplim": break;

                case "pl_eqt": break;
                case "pl_eqterr1": break;
                case "pl_eqterr2": break;
                case "pl_eqtlim": break;

                case "pl_insol": break;
                case "pl_insolerr1": break;
                case "pl_insolerr2": break;
                case "pl_insollim": break;

                case "pl_massj": Mass = index; break;
                case "pl_massjerr1": MassErrorMax = index; break;
                case "pl_massjerr2": MassErrorMin = index; break;
                case "pl_massjlim": break;

                case "pl_msinij": MassSini = index; break;
                case "pl_msinijerr1": MassSiniErrorMax = index; break;
                case "pl_msinijerr2": MassSiniErrorMin = index; break;
                case "pl_msinijlim": break;

                case "pl_masse": break;
                case "pl_masseerr1": break;
                case "pl_masseerr2": break;
                case "pl_masselim": break;

                case "pl_msinie": break;
                case "pl_msinieerr1": break;
                case "pl_msinieerr2": break;
                case "pl_msinielim": break;

                case "pl_bmasse": break;
                case "pl_bmasseerr1": break;
                case "pl_bmasseerr2": break;
                case "pl_bmasselim": break;

                case "pl_rade": break;
                case "pl_radeerr1": break;
                case "pl_radeerr2": break;
                case "pl_radelim": break;

                case "pl_rads": break;
                case "pl_radserr1": break;
                case "pl_radserr2": break;
                case "pl_radslim": break;

                case "pl_trandep": break;
                case "pl_trandeperr1": break;
                case "pl_trandeperr2": break;
                case "pl_trandeplim": break;

                case "pl_trandur": break;
                case "pl_trandurerr1": break;
                case "pl_trandurerr2": break;
                case "pl_trandurlim": break;

                case "pl_tranmid": break;
                case "pl_tranmiderr1": break;
                case "pl_tranmiderr2": break;
                case "pl_tranmidlim": break;

                case "pl_tsystemref": break;

                case "pl_imppar": ImpactParameter = index; break;
                case "pl_impparerr1": ImpactParameterErrorMin = index; break;
                case "pl_impparerr2": ImpactParameterErrorMax = index; break;
                case "pl_impparlim": break;

                case "pl_occdep": break;
                case "pl_occdeperr1": break;
                case "pl_occdeperr2": break;
                case "pl_occdeplim": break;

                case "pl_ratdor": break;
                case "pl_ratdorerr1": break;
                case "pl_ratdorerr2": break;
                case "pl_ratdorlim": break;

                case "pl_ratror": break;
                case "pl_ratrorerr1": break;
                case "pl_ratrorerr2": break;
                case "pl_ratrorlim": break;

                case "pl_def_reflink": break;

                case "pl_disc": Discovered = index; break;

                case "pl_disc_reflink": break;

                case "pl_locale": break;
                case "pl_facility": break;
                case "pl_telescope": break;
                case "pl_instrument": break;
                case "pl_status": break;
                case "pl_mnum": break;
                case "pl_st_npar": break;
                case "pl_st_nref": break;
                case "pl_pelink": break;
                case "pl_edelink": break;
                case "pl_publ_date": break;

                case "st_dist": StarDistance = index; break;
                case "st_disterr1": StarDistanceErrorMin = index; break;
                case "st_disterr2": StarDistanceErrorMax = index; break;
                case "st_distlim": break;

                case "st_optmag": break;
                case "st_optmagerr": break;
                case "st_optmaglim": break;
                case "st_optmagblend": break;
                case "st_optband": break;

                case "st_teff": StarTeff = index; break;
                case "st_tefferr1": StarTeffErrorMin = index; break;
                case "st_tefferr2": StarTeffErrorMax = index; break;
                case "st_tefflim": break;
                case "st_teffblend": break;

                case "st_mass": StarMass = index; break;
                case "st_masserr1": StarMassErrorMin = index; break;
                case "st_masserr2": StarMassErrorMax = index; break;
                case "st_masslim": break;
                case "st_massblend": break;

                case "st_rad": StarRadius = index; break;
                case "st_raderr1": StarRadiusErrorMin = index; break;
                case "st_raderr2": StarRadiusErrorMax = index; break;
                case "st_radlim": break;
                case "st_radblend": break;

                case "st_rah": break;

                case "st_glon": break;
                case "st_glat": break;
                case "st_elon": break;
                case "st_elat": break;

                case "st_plx": break;
                case "st_plxerr1": break;
                case "st_plxerr2": break;
                case "st_plxlim": break;
                case "st_plxblend": break;

                case "st_pmra": break;
                case "st_pmraerr": break;
                case "st_pmralim": break;

                case "st_pmdec": break;
                case "st_pmdecerr": break;
                case "st_pmdeclim": break;

                case "st_pm": break;
                case "st_pmerr": break;
                case "st_pmlim": break;
                case "st_pmblend": break;

                case "st_radv": break;
                case "st_radverr1": break;
                case "st_radverr2": break;
                case "st_radvlim": break;
                case "st_radvblend": break;

                case "st_sp": break;
                case "st_spstr": StarSPType = index; break;
                case "st_sperr": break;
                case "st_splim": break;
                case "st_spblend": break;

                case "st_logg": break;
                case "st_loggerr1": break;
                case "st_loggerr2": break;
                case "st_logglim": break;
                case "st_loggblend": break;

                case "st_lum": break;
                case "st_lumerr1": break;
                case "st_lumerr2": break;
                case "st_lumlim": break;
                case "st_lumblend": break;

                case "st_dens": break;
                case "st_denserr1": break;
                case "st_denserr2": break;
                case "st_denslim": break;

                case "st_metfe": StarMetallicity = index; break;
                case "st_metfeerr1": StarMetallicityErrorMin = index; break;
                case "st_metfeerr2": StarMetallicityErrorMax = index; break;
                case "st_metfelim": break;
                case "st_metfeblend": break;
                case "st_metratio": break;

                case "st_age": StarAge = index; break;
                case "st_ageerr1": StarAgeErrorMin = index; break;
                case "st_ageerr2": StarAgeErrorMax = index; break;
                case "st_agelim": break;

                case "st_vsini": break;
                case "st_vsinierr1": break;
                case "st_vsinierr2": break;
                case "st_vsinilim": break;
                case "st_vsiniblend": break;
                case "st_acts": break;
                case "st_actserr": break;
                case "st_actslim": break;
                case "st_actsblend": break;
                case "st_actr": break;
                case "st_actrerr": break;
                case "st_actrlim": break;
                case "st_actrblend": break;
                case "st_actlx": break;
                case "st_actlxerr": break;
                case "st_actlxlim": break;
                case "st_actlxblend": break;
                case "st_nts": break;
                case "st_nplc": break;
                case "st_nglc": break;
                case "st_nrvc": break;
                case "st_naxa": break;
                case "st_nimg": break;
                case "st_nspec": break;

                case "st_uj": break;
                case "st_ujerr": break;
                case "st_ujlim": break;
                case "st_ujblend": break;

                case "st_vj": StarMagnitudeV = index; break;
                case "st_vjerr": break;
                case "st_vjlim": break;
                case "st_vjblend": break;

                case "st_bj": break;
                case "st_bjerr": break;
                case "st_bjlim": break;
                case "st_bjblend": break;

                case "st_rc": break;
                case "st_rcerr": break;
                case "st_rclim": break;
                case "st_rcblend": break;

                case "st_ic": StarMagnitudeI = index; break;
                case "st_icerr": break;
                case "st_iclim": break;
                case "st_icblend": break;

                case "st_j": StarMagnitudeJ = index; break;
                case "st_jerr": break;
                case "st_jlim": break;
                case "st_jblend": break;

                case "st_h": StarMagnitudeH = index; break;
                case "st_herr": break;
                case "st_hlim": break;
                case "st_hblend": break;

                case "st_k": StarMagnitudeK = index; break;
                case "st_kerr": break;
                case "st_klim": break;
                case "st_kblend": break;

                case "st_wise1": break;
                case "st_wise1err": break;
                case "st_wise1lim": break;
                case "st_wise1blend": break;
                case "st_wise2": break;
                case "st_wise2err": break;
                case "st_wise2lim": break;
                case "st_wise2blend": break;
                case "st_wise3": break;
                case "st_wise3err": break;
                case "st_wise3lim": break;
                case "st_wise3blend": break;
                case "st_wise4": break;
                case "st_wise4err": break;
                case "st_wise4lim": break;
                case "st_wise4blend": break;
                case "st_irac1": break;
                case "st_irac1err": break;
                case "st_irac1lim": break;
                case "st_irac1blend": break;
                case "st_irac2": break;
                case "st_irac2err": break;
                case "st_irac2lim": break;
                case "st_irac2blend": break;
                case "st_irac3": break;
                case "st_irac3err": break;
                case "st_irac3lim": break;
                case "st_irac3blend": break;
                case "st_irac4": break;
                case "st_irac4err": break;
                case "st_irac4lim": break;
                case "st_irac4blend": break;
                case "st_mips1": break;
                case "st_mips1err": break;
                case "st_mips1lim": break;
                case "st_mips1blend": break;
                case "st_mips2": break;
                case "st_mips2err": break;
                case "st_mips2lim": break;
                case "st_mips2blend": break;
                case "st_mips3": break;
                case "st_mips3err": break;
                case "st_mips3lim": break;
                case "st_mips3blend": break;
                case "st_iras1": break;
                case "st_iras1err": break;
                case "st_iras1lim": break;
                case "st_iras1blend": break;
                case "st_iras2": break;
                case "st_iras2err": break;
                case "st_iras2lim": break;
                case "st_iras2blend": break;
                case "st_iras3": break;
                case "st_iras3err": break;
                case "st_iras3lim": break;
                case "st_iras3blend": break;
                case "st_iras4": break;
                case "st_iras4err": break;
                case "st_iras4lim": break;
                case "st_iras4blend": break;
                case "st_photn": break;
                case "st_umbj": break;
                case "st_umbjerr": break;
                case "st_umbjlim": break;
                case "st_umbjblend": break;
                case "st_bmvj": break;
                case "st_bmvjerr": break;
                case "st_bmvjlim": break;
                case "st_bmvjblend": break;
                case "st_vjmic": break;
                case "st_vjmicerr": break;
                case "st_vjmiclim": break;
                case "st_vjmicblend": break;
                case "st_vjmrc": break;
                case "st_vjmrcerr": break;
                case "st_vjmrclim": break;
                case "st_vjmrcblend": break;
                case "st_jmh2": break;
                case "st_jmh2err": break;
                case "st_jmh2lim": break;
                case "st_jmh2blend": break;
                case "st_hmk2": break;
                case "st_hmk2err": break;
                case "st_hmk2lim": break;
                case "st_hmk2blend": break;
                case "st_jmk2": break;
                case "st_jmk2err": break;
                case "st_jmk2lim": break;
                case "st_jmk2blend": break;
                case "st_bmy": break;
                case "st_bmyerr": break;
                case "st_bmylim": break;
                case "st_bmyblend": break;
                case "st_m1": break;
                case "st_m1err": break;
                case "st_m1lim": break;
                case "st_m1blend": break;
                case "st_c1": break;
                case "st_c1err": break;
                case "st_c1lim": break;
                case "st_c1blend": break;
                case "st_colorn": break;

                case "ra_str": break;
                case "dec_str": break;
                case "rowupdate": Updated = index;  break;

                case "swasp_id": break;
                case "hd_name": break;
                case "hip_name": break;
                case "id": break;

                default:
                    System.Windows.Forms.MessageBox.Show ("Error: " + substring);
                    break;
                }
            }
        }
    }

