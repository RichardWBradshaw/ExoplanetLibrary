using System.Windows.Forms;
using Microsoft.Win32;
using System.Collections;

namespace ExoplanetLibrary
    {
    public class NameQuery
        {
        public string Name;

        public NameQuery ()
            {
            }

        public NameQuery (string name)
            {
            Name = name;
            }
        }

    public class DetectionQuery
        {
        public string Detection;

        public DetectionQuery ()
            {
            }

        public DetectionQuery (string detection)
            {
            Detection = detection;
            }
        }

    public class BetweenQuery
        {
        public PlotTypes PlotType;
        public double LoValue;
        public double HiValue;

        public BetweenQuery ()
            {
            }

        public BetweenQuery (PlotTypes plotType, double loValue, double hiValue)
            {
            PlotType = plotType;
            LoValue = loValue;
            HiValue = hiValue;
            }
        }

    public class LessThanQuery
        {
        public PlotTypes PlotType;
        public double Value;

        public LessThanQuery ()
            {
            }

        public LessThanQuery (PlotTypes plotType, double value)
            {
            PlotType = plotType;
            Value = value;
            }
        }

    public class GreaterThanQuery
        {
        public PlotTypes PlotType;
        public double Value;

        public GreaterThanQuery ()
            {
            }

        public GreaterThanQuery (PlotTypes plotType, double value)
            {
            PlotType = plotType;
            Value = value;
            }
        }

    public class Queries
        {
        static public Queries CurrentQueries = new Queries ();

        private ArrayList NameQueries = new ArrayList ();
        private ArrayList DetectionQueries = new ArrayList ();
        private ArrayList BetweenQueries = new ArrayList ();
        private ArrayList LessThanQueries = new ArrayList ();
        private ArrayList GreaterThanQueries = new ArrayList ();

        public Queries ()
            {
            }

        public Queries (string text) : this ()
            {
            char [] delimiterChars = { '\r' };
            string query = text.Replace ('\n', ' ');
            string [] queries = query.Split (delimiterChars);

            for (int index = 0; index < queries.Length; ++index)
                {
                char [] delimiter2Chars = { ' ' };
                string [] strings = queries [index].Trim ().Split (delimiter2Chars);

                PlotTypes plotType = PlotTypes.Default;
                double value = 0.0, value1 = 0.0, value2 = 0.0;
                string name = "";
                string detection = "";

                if (ParseName (strings, ref name) == true)
                    {
                    AddName (name);
                    }
                else if (ParseDetection (strings, ref detection) == true)
                    {
                    AddDetection (detection);
                    }
                else if (ParseBetweenQuery (strings, ref plotType, ref value1, ref value2) == true)
                    {
                    AddBetween (plotType, value1, value2);
                    }
                else if (ParseLessThanQuery (strings, ref plotType, ref value) == true)
                    {
                    AddLessThan (plotType, value);
                    }
                else if (ParseGreaterThanQuery (strings, ref plotType, ref value) == true)
                    {
                    AddGreaterThan (plotType, value);
                    }
                }
            }

        //
        // "where name Kelper"
        //

        private bool ParseName (string [] strings, ref string value)
            {
            if (strings [0] == "where")
                if (strings [1] == "name")
                    {
                    value = strings [2].ToLower ();
                    return true;
                    }

            return false;
            }

        //
        // "where detection PrimaryTransit"
        //

        private bool ParseDetection (string [] strings, ref string value)
            {
            if (strings [0] == "where")
                if (strings [1] == "detection")
                        {
                        value = strings [2].ToLower ();
                        return true;
                        }

            return false;
            }

        //private DetectionType GetDetectionType (string stringer)
        //    {
        //    stringer = stringer.ToLower ();

        //    if(stringer.Contains( ))
        //    if (stringer.StartsWith ("pri") || stringer == "primarytransit")
        //        {
        //        return DetectionType.PrimaryTransit;
        //        }
        //    else if (stringer.StartsWith ("rad") || stringer == "radialvelocity")
        //        {
        //        return DetectionType.RadialVelocity;
        //        }
        //    else if (stringer.StartsWith ("mic") || stringer == "microlensing")
        //        {
        //        return DetectionType.MicroLensing;
        //        }
        //    else if (stringer.StartsWith ("ima") || stringer == "imaging")
        //        {
        //        return DetectionType.Imaging;
        //        }
        //    else if (stringer.StartsWith ("pul") || stringer == "pulsar")
        //        {
        //        return DetectionType.Pulsar;
        //        }
        //    else if (stringer.StartsWith ("ast") || stringer == "astrometry")
        //        {
        //        return DetectionType.Astrometry;
        //        }
        //    else if (stringer.StartsWith ("ttv") || stringer == "ttv")
        //        {
        //        return DetectionType.TTV;
        //        }
        //    else if (stringer.StartsWith ("unk") || stringer == "unknown")
        //        {
        //        return DetectionType.Unknown;
        //        }

        //    return DetectionType.Unknown;
        //    }

        //
        // "where mass between '0.1' and '1.0'" or "where mass between 0.1 and 1.0"
        //

        private bool ParseBetweenQuery (string [] strings, ref PlotTypes plotType, ref double value1, ref double value2)
            {
            if (strings [0] == "where")
                if (( plotType = GetPlotType (strings [1]) ) != PlotTypes.Default)
                    if (strings [2] == "between")
                        if (strings [4] == "and")
                            {
                            string string3 = strings [3].Replace ("'", " ");
                            string string5 = strings [5].Replace ("'", " ");

                            if (double.TryParse (string3.Trim (), out value1))
                                if (double.TryParse (string5.Trim (), out value2))
                                    {
                                    if (value1 > value2)
                                        {
                                        double temp = value1;
                                        value1 = value2;
                                        value2 = temp;
                                        }

                                    return true;
                                    }
                            }

            return false;
            }

        //
        // "where eccentricity < '0.1'" or "where eccentricity < 0.1"
        //

        private bool ParseLessThanQuery (string [] strings, ref PlotTypes plotType, ref double value)
            {
            if (strings [0] == "where")
                if (( plotType = GetPlotType (strings [1]) ) != PlotTypes.Default)
                    if (strings [2] == "<" || strings [2] == "<=")
                        {
                        string string3 = strings [3].Replace ("'", " ");

                        if (double.TryParse (string3.Trim (), out value))
                            return true;
                        }

            return false;
            }

        //
        // "where eccentricity > '0.1'" or "where eccentricity > 0.1"
        //

        private bool ParseGreaterThanQuery (string [] strings, ref PlotTypes plotType, ref double value)
            {
            if (strings [0] == "where")
                if (( plotType = GetPlotType (strings [1]) ) != PlotTypes.Default)
                    if (strings [2] == ">" || strings [2] == ">=")
                        {
                        string string3 = strings [3].Replace ("'", " ");

                        if (double.TryParse (string3.Trim (), out value))
                            return true;
                        }

            return false;
            }

        private PlotTypes GetPlotType (string stringer)
            {
            stringer = stringer.ToLower ();

            if (stringer.StartsWith ("mas") || stringer == "mass")
                {
                return PlotTypes.Mass;
                }
            else if (stringer.StartsWith ("rad") || stringer == "radius")
                {
                return PlotTypes.Radius;
                }
            else if (stringer.StartsWith ("orb") || stringer == "orbitalperiod")
                {
                return PlotTypes.OrbitalPeriod;
                }
            else if (stringer.StartsWith ("sem") || stringer == "semimajoraxis")
                {
                return PlotTypes.SemiMajorAxis;
                }
            else if (stringer.StartsWith ("ecc") || stringer == "eccentricity")
                {
                return PlotTypes.Eccentricity;
                }
            else if (stringer.StartsWith ("ang") || stringer == "angulardistance")
                {
                return PlotTypes.AngularDistance;
                }
            else if (stringer.StartsWith ("inc") || stringer == "inclination")
                {
                return PlotTypes.Inclination;
                }
            else if (stringer.StartsWith ("tem") || stringer == "temperaturecalculated")
                {
                return PlotTypes.TemperatureCalculated;
                }
            else if (stringer.StartsWith ("ome") || stringer == "omega")
                {
                return PlotTypes.Omega;
                }
            else if (stringer.StartsWith ("vel") || stringer == "velocitysemiamplitude")
                {
                return PlotTypes.VelocitySemiamplitude;
                }

            return PlotTypes.Default;
            }

        private void Initialize ()
            {
            NameQueries = new ArrayList ();
            DetectionQueries = new ArrayList ();
            BetweenQueries = new ArrayList ();
            LessThanQueries = new ArrayList ();
            GreaterThanQueries = new ArrayList ();
            }

        private void AddName (string name)
            {
            NameQueries.Add (new NameQuery (name.ToLower ()));
            }

        private void AddDetection (string detection)
            {
            DetectionQueries.Add (new DetectionQuery (detection));
            }

        private void AddBetween (PlotTypes plotType, double value1, double value2)
            {
            BetweenQueries.Add (new BetweenQuery (plotType, value1, value2));
            }

        private void AddLessThan (PlotTypes plotType, double value)
            {
            LessThanQueries.Add (new LessThanQuery (plotType, value));
            }

        private void AddGreaterThan (PlotTypes plotType, double value)
            {
            GreaterThanQueries.Add (new GreaterThanQuery (plotType, value));
            }

        public bool MatchesQuery (Exoplanet exoplanet)
            {
            if (NameQueries.Count > 0)
                foreach (NameQuery query in NameQueries)
                    {
                    string name = exoplanet.Name.ToLower ();

                    if (!name.StartsWith (query.Name))
                        return false;
                    }

            if (DetectionQueries.Count > 0)
                foreach (DetectionQuery query in DetectionQueries)
                    {
                    string detection = exoplanet.DetectionType.ToLower ();

                    if (!detection.Contains( query.Detection))
                        return false;
                    }

            if (BetweenQueries.Count > 0)
                foreach (BetweenQuery query in BetweenQueries)
                    {
                    double value = 0.0;

                    if (Parse (exoplanet, query.PlotType, out value))
                        if (value < query.LoValue || value > query.HiValue)
                            return false;
                    }

            if (LessThanQueries.Count > 0)
                foreach (LessThanQuery query in LessThanQueries)
                    {
                    double value = 0.0;

                    if (Parse (exoplanet, query.PlotType, out value))
                        if (value > query.Value)
                            return false;
                    }

            if (GreaterThanQueries.Count > 0)
                foreach (GreaterThanQuery query in GreaterThanQueries)
                    {
                    double value = 0.0;

                    if (Parse (exoplanet, query.PlotType, out value))
                        if (value < query.Value)
                            return false;
                    }

            return true;
            }

        private bool Parse (Exoplanet exoplanet, PlotTypes plotType, out double value)
            {
            bool isValid = false;

            value = 0.0;

            switch (plotType)
                {
                case PlotTypes.Mass:
                    isValid = double.TryParse (exoplanet.Mass, out value);
                    break;

                case PlotTypes.Radius:
                    isValid = double.TryParse (exoplanet.Radius, out value);
                    break;

                case PlotTypes.OrbitalPeriod:
                    isValid = double.TryParse (exoplanet.OrbitalPeriod, out value);
                    break;

                case PlotTypes.SemiMajorAxis:
                    isValid = double.TryParse (exoplanet.SemiMajorAxis, out value);
                    break;

                case PlotTypes.Eccentricity:
                    isValid = double.TryParse (exoplanet.Eccentricity, out value);
                    break;

                case PlotTypes.AngularDistance:
                    isValid = double.TryParse (exoplanet.AngularDistance, out value);
                    break;

                case PlotTypes.Inclination:
                    isValid = double.TryParse (exoplanet.Inclination, out value);
                    break;

                case PlotTypes.TemperatureCalculated:
                    isValid = double.TryParse (exoplanet.TemperatureCalculated, out value);
                    break;

                case PlotTypes.Omega:
                    isValid = double.TryParse (exoplanet.Omega, out value);
                    break;

                case PlotTypes.VelocitySemiamplitude:
                    isValid = double.TryParse (exoplanet.VelocitySemiamplitude, out value);
                    break;
                }

            return isValid;
            }
        }

    //
    //
    //

    public class Visualization
        {
        static private CheckState IncludeErrorBars_ = CheckState.Checked;
        static public CheckState IncludeErrorBars
            {
            get { return IncludeErrorBars_; }
            set { IncludeErrorBars_ = value; }
            }

        static private CheckState ColorFromStarType_ = CheckState.Checked;
        static public CheckState ColorFromStarType
            {
            get { return ColorFromStarType_; }
            set { ColorFromStarType_ = value; }
            }

        static private CheckState LogXAxis_ = CheckState.Checked;
        static public CheckState LogXAxis
            {
            get { return LogXAxis_; }
            set { LogXAxis_ = value; }
            }

        static private CheckState LogYAxis_ = CheckState.Checked;
        static public CheckState LogYAxis
            {
            get { return LogYAxis_; }
            set { LogYAxis_ = value; }
            }

        static private CheckState IncludeDuplicates_ = CheckState.Unchecked;
        static public CheckState IncludeDuplicates
            {
            get { return IncludeDuplicates_; }
            set { IncludeDuplicates_ = value; }
            }

        Visualization ()
            {
            IncludeErrorBars = CheckState.Unchecked;
            ColorFromStarType = CheckState.Unchecked;
            LogXAxis = CheckState.Unchecked;
            LogYAxis = CheckState.Unchecked;
            }
        }

    //
    //
    //

    public class Settings
        {
        static private int FilterIndex_ = 1;
        static public int FilterIndex
            {
            get { return FilterIndex_; }
            set { FilterIndex_ = value; }
            }

        static public int Write ()
            {
            RegistryKey key = RegistryKey.OpenRemoteBaseKey (RegistryHive.CurrentUser, "");
            RegistryKey subkey = ( key != null ) ? key.CreateSubKey ("Software\\ExoplanetLibrary") : null;

            if (subkey != null)
                {
                subkey.SetValue ("IncudeErrorBars", Visualization.IncludeErrorBars == CheckState.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("ColorFromStarType", Visualization.ColorFromStarType == CheckState.Checked ? "True" : "False", RegistryValueKind.String);

                subkey.SetValue ("LogXAxis", Visualization.LogXAxis == CheckState.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("LogYAxis", Visualization.LogYAxis == CheckState.Checked ? "True" : "False", RegistryValueKind.String);

                subkey.SetValue ("IncludeDuplicates", Visualization.IncludeDuplicates == CheckState.Checked ? "True" : "False", RegistryValueKind.String);

                subkey.SetValue ("OpenFileFilterIndex", Settings.FilterIndex, RegistryValueKind.String);
                }

            if (key != null)
                key.Close ();

            return 0;
            }

        static public void Read ()
            {
            RegistryKey key = RegistryKey.OpenRemoteBaseKey (RegistryHive.CurrentUser, "");
            RegistryKey subkey = key != null ? key.OpenSubKey ("Software\\ExoplanetLibrary") : null;

            if (subkey != null)
                {
                Visualization.IncludeErrorBars = ReadValue (subkey, "IncudeErrorBars");
                Visualization.ColorFromStarType = ReadValue (subkey, "ColorFromStarType");
                Visualization.LogXAxis = ReadValue (subkey, "LogXAxis");
                Visualization.LogYAxis = ReadValue (subkey, "LogYAxis");
                Visualization.IncludeDuplicates = ReadValue (subkey, "IncludeDuplicates");

                Settings.FilterIndex = ReadIntegerValue (subkey, "OpenFileFilterIndex");
                }

            if (key != null)
                key.Close ();
            }

        static public int WriteFileName (string xmlFileName)
            {
            RegistryKey key = RegistryKey.OpenRemoteBaseKey (RegistryHive.CurrentUser, "");
            RegistryKey subkey = ( key != null ) ? key.CreateSubKey ("Software\\ExoplanetLibrary") : null;

            if (subkey != null)
                subkey.SetValue ("XMLFileName", xmlFileName, RegistryValueKind.String);

            if (key != null)
                key.Close ();

            return 0;
            }

        static public string ReadFileName ()
            {
            string xmlFileName = "";
            RegistryKey key = RegistryKey.OpenRemoteBaseKey (RegistryHive.CurrentUser, "");
            RegistryKey subkey = key != null ? key.OpenSubKey ("Software\\ExoplanetLibrary") : null;

            if (subkey != null)
                {
                object obj = subkey.GetValue ("XMLFileName");

                if (obj != null)
                    xmlFileName = obj as string;
                }

            if (key != null)
                key.Close ();

            return xmlFileName;
            }

        static public int WriteLastEUVisit (System.DateTime dateTime)
            {
            return WriteLastVisit ("LastEUVisit", dateTime);
            }

        static public int WriteLastNASAVisit (System.DateTime dateTime)
            {
            return WriteLastVisit ("LastNASAVisit", dateTime);
            }

        static private int WriteLastVisit (string keyValue, System.DateTime dateTime)
            {
            RegistryKey key = RegistryKey.OpenRemoteBaseKey (RegistryHive.CurrentUser, "");
            RegistryKey subkey = ( key != null ) ? key.CreateSubKey ("Software\\ExoplanetLibrary") : null;

            if (subkey != null)
                subkey.SetValue (keyValue, dateTime.ToString (), RegistryValueKind.String);

            if (key != null)
                key.Close ();

            return 0;
            }

        static public string ReadLastEUVisit ()
            {
            return ReadLastVisit ("LastEUVisit");
            }

        static public string ReadLastNASAVisit ()
            {
            return ReadLastVisit ("LastNASAVisit");
            }

        static private string ReadLastVisit (string keyValue)
            {
            string dateTime = "";
            RegistryKey key = RegistryKey.OpenRemoteBaseKey (RegistryHive.CurrentUser, "");
            RegistryKey subkey = key != null ? key.OpenSubKey ("Software\\ExoplanetLibrary") : null;

            if (subkey != null)
                {
                object obj = subkey.GetValue (keyValue);

                if (obj != null)
                    dateTime = obj as string;
                }

            if (key != null)
                key.Close ();

            return dateTime;
            }

        static private CheckState ReadValue (RegistryKey subkey, string name)
            {
            object obj = subkey.GetValue (name);

            if (obj != null)
                {
                string value = obj as string;

                if (value.Equals ("True"))
                    return CheckState.Checked;
                else if (value.Equals ("False"))
                    return CheckState.Unchecked;
                }

            return CheckState.Unchecked;
            }

        static private int ReadIntegerValue (RegistryKey subkey, string name)
            {
            object obj = subkey.GetValue (name);

            if (obj != null)
                {
                return int.Parse (obj as string);
                }

            return 0;
            }
        }
    }
