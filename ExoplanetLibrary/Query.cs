using Microsoft.Win32;
using System.Collections;

namespace ExoplanetLibrary
    {
    public enum QueryTypes
        {
        StartsWith = 0,
        Contains = 1,
        EndsWith = 2
        }

    public class NameQuery
        {
        public string Name;

        private QueryTypes QueryType_ = QueryTypes.StartsWith;
        public QueryTypes QueryType
            {
            get { return QueryType_; }
            set { QueryType_ = value; }
            }

        public NameQuery ()
            {
            }

        public NameQuery (string name, QueryTypes queryType)
            {
            Name = name;
            QueryType = queryType;
            }
        }

    public class DetectionQuery
        {
        public string Detection;

        private QueryTypes QueryType_ = QueryTypes.StartsWith;
        public QueryTypes QueryType
            {
            get { return QueryType_; }
            set { QueryType_ = value; }
            }

        public DetectionQuery ()
            {
            }

        public DetectionQuery (string detection, QueryTypes queryType)
            {
            Detection = detection;
            QueryType = queryType;
            }
        }

    public class SpectralQuery
        {
        public string Spectral;

        private QueryTypes QueryType_ = QueryTypes.StartsWith;
        public QueryTypes QueryType
            {
            get { return QueryType_; }
            set { QueryType_ = value; }
            }

        public SpectralQuery ()
            {
            }

        public SpectralQuery (string spectral, QueryTypes queryType)
            {
            Spectral = spectral;
            QueryType = queryType;
            }
        }

    public class HabitabilityQuery
        {
        public string Habitability;

        private QueryTypes QueryType_ = QueryTypes.StartsWith;
        public QueryTypes QueryType
            {
            get { return QueryType_; }
            set { QueryType_ = value; }
            }

        public HabitabilityQuery ()
            {
            }

        public HabitabilityQuery (string habitability, QueryTypes queryType)
            {
            Habitability = habitability;
            QueryType = queryType;
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
        private ArrayList SpectralQueries = new ArrayList ();
        private ArrayList HabitabilityQueries = new ArrayList ();
        private ArrayList BetweenQueries = new ArrayList ();
        private ArrayList LessThanQueries = new ArrayList ();
        private ArrayList GreaterThanQueries = new ArrayList ();

        static public string [] Name = new string [20];
        static public string [] WhereClause = new string [20];

        public Queries ()
            {
            }

        public Queries (string text) : this ()
            {
            char [] delimiterChars = { '\r' };
            string query = text.Replace ('\n', ' ');
            query = query.ToLower ();
            string [] queries = query.Split (delimiterChars);

            for (int index = 0; index < queries.Length; ++index)
                {
                char [] delimiter2Chars = { ' ' };
                string [] strings = queries [index].Trim ().Split (delimiter2Chars);

                PlotTypes plotType = PlotTypes.Default;
                double value = 0.0, value1 = 0.0, value2 = 0.0;
                string name = string.Empty;
                string detection = string.Empty;
                string spectral = string.Empty;
                string habitability = string.Empty;
                QueryTypes queryType = QueryTypes.StartsWith;

                if (ParseName (strings, ref name, ref queryType) == true)
                    {
                    AddName (name, queryType);
                    }
                else if (ParseDetection (strings, ref detection, ref queryType) == true)
                    {
                    AddDetection (detection, queryType);
                    }
                else if (ParseSpectral (strings, ref spectral, ref queryType) == true)
                    {
                    AddSpectral (spectral, queryType);
                    }
                else if (ParseHabitability (strings, ref habitability, ref queryType) == true)
                    {
                    AddHabitability (habitability, queryType);
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
        // "where name Kepler" or "where name startswith Kepler"
        //

        private bool ParseName (string [] strings, ref string value, ref QueryTypes queryType)
            {
            queryType = QueryTypes.StartsWith;

            if (strings [0] == "where")
                if (strings [1] == "name")
                    {
                    if (strings.Length == 3)
                        {
                        value = strings [2].ToLower ();
                        return true;
                        }
                    else if (strings.Length == 4)
                        {
                        string query = strings [2].ToLower ();

                        if (query.StartsWith ("starts") || query.StartsWith ("startswith"))
                            queryType = QueryTypes.StartsWith;
                        else if (query.StartsWith ("contains"))
                            queryType = QueryTypes.Contains;
                        else if (query.StartsWith ("ends") || query.StartsWith ("endswith"))
                            queryType = QueryTypes.EndsWith;

                        value = strings [3].ToLower ();
                        return true;
                        }
                    }

            return false;
            }

        //
        // "where detection PrimaryTransit"
        //

        private bool ParseDetection (string [] strings, ref string value, ref QueryTypes queryType)
            {
            queryType = QueryTypes.StartsWith;

            if (strings [0] == "where")
                if (strings [1] == "detection")
                    {
                    if (strings.Length == 3)
                        {
                        value = strings [2].ToLower ();
                        return true;
                        }
                    else if (strings.Length == 4)
                        {
                        string query = strings [2].ToLower ();

                        if (query.StartsWith ("starts") || query.StartsWith ("startswith"))
                            queryType = QueryTypes.StartsWith;
                        else if (query.StartsWith ("contains"))
                            queryType = QueryTypes.Contains;
                        else if (query.StartsWith ("ends") || query.StartsWith ("endswith"))
                            queryType = QueryTypes.EndsWith;

                        value = strings [3].ToLower ();
                        return true;
                        }
                    }

            return false;
            }

        //
        // "where spectral startswith A"
        //

        private bool ParseSpectral (string [] strings, ref string value, ref QueryTypes queryType)
            {
            queryType = QueryTypes.StartsWith;

            if (strings [0] == "where")
                if (strings [1] == "spectral")
                    {
                    if (strings.Length == 3)
                        {
                        value = strings [2].ToLower ();
                        return true;
                        }
                    else if (strings.Length == 4)
                        {
                        string query = strings [2].ToLower ();

                        if (query.StartsWith ("starts") || query.StartsWith ("startswith"))
                            queryType = QueryTypes.StartsWith;
                        else if (query.StartsWith ("contains"))
                            queryType = QueryTypes.Contains;
                        else if (query.StartsWith ("ends") || query.StartsWith ("endswith"))
                            queryType = QueryTypes.EndsWith;

                        value = strings [3].ToLower ();
                        return true;
                        }
                    }

            return false;
            }

        //
        // "where habitability startswith cold"
        //

        private bool ParseHabitability (string [] strings, ref string value, ref QueryTypes queryType)
            {
            queryType = QueryTypes.StartsWith;

            if (strings [0] == "where")
                if (strings [1] == "habitability")
                    {
                    if (strings.Length == 3)
                        {
                        value = strings [2].ToLower ();
                        return true;
                        }
                    else if (strings.Length == 4)
                        {
                        string query = strings [2].ToLower ();

                        if (query.StartsWith ("starts") || query.StartsWith ("startswith"))
                            queryType = QueryTypes.StartsWith;
                        else if (query.StartsWith ("contains"))
                            queryType = QueryTypes.Contains;
                        else if (query.StartsWith ("ends") || query.StartsWith ("endswith"))
                            queryType = QueryTypes.EndsWith;

                        value = strings [3].ToLower ();
                        return true;
                        }
                    }

            return false;
            }
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
            PlotTypes [] plotType = { PlotTypes.Mass,
                                      PlotTypes.Radius,
                                      PlotTypes.OrbitalPeriod,
                                      PlotTypes.SemiMajorAxis,
                                      PlotTypes.Eccentricity,
                                      PlotTypes.AngularDistance,
                                      PlotTypes.Inclination,
                                      PlotTypes.TemperatureCalculated,
                                      PlotTypes.Omega,
                                      PlotTypes.VelocitySemiamplitude };

            stringer = stringer.ToLower ();

            for (int index = 0; index < plotType.Length; ++index)
                {
                string keyword = plotType [index].ToString ().ToLower ();

                if (stringer.StartsWith (keyword.Substring (0, 3)) || stringer == keyword)
                    return plotType [index];
                }

            return PlotTypes.Default;
            }

        private void Initialize ()
            {
            NameQueries = new ArrayList ();
            DetectionQueries = new ArrayList ();
            SpectralQueries = new ArrayList ();
            HabitabilityQueries = new ArrayList ();
            BetweenQueries = new ArrayList ();
            LessThanQueries = new ArrayList ();
            GreaterThanQueries = new ArrayList ();
            }

        private void AddName (string name, QueryTypes queryType)
            {
            NameQueries.Add (new NameQuery (name.ToLower (), queryType));
            }

        private void AddDetection (string detection, QueryTypes queryType)
            {
            DetectionQueries.Add (new DetectionQuery (detection, queryType));
            }

        private void AddSpectral (string spectual, QueryTypes queryType)
            {
            SpectralQueries.Add (new SpectralQuery (spectual, queryType));
            }

        private void AddHabitability (string habitability, QueryTypes queryType)
            {
            HabitabilityQueries.Add (new HabitabilityQuery (habitability, queryType));
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
                {
                bool matches = false;

                foreach (NameQuery query in NameQueries)
                    {
                    string name = exoplanet.Name.ToLower ();

                    if (query.QueryType == QueryTypes.StartsWith)
                        {
                        if (name.StartsWith (query.Name))
                            matches = true;
                        }
                    else if (query.QueryType == QueryTypes.EndsWith)
                        {
                        if (name.EndsWith (query.Name))
                            matches = true;
                        }
                    else if (query.QueryType == QueryTypes.Contains)
                        {
                        if (name.Contains (query.Name))
                            matches = true;
                        }
                    }

                if (!matches)
                    return false;
                }

            if (DetectionQueries.Count > 0)
                {
                bool matches = false;

                foreach (DetectionQuery query in DetectionQueries)
                    {
                    string detection = exoplanet.DetectionType.ToLower ();

                    if (query.QueryType == QueryTypes.StartsWith)
                        {
                        if (detection.StartsWith (query.Detection))
                            matches = true;
                        }
                    else if (query.QueryType == QueryTypes.EndsWith)
                        {
                        if (detection.EndsWith (query.Detection))
                            matches = true;
                        }
                    else if (query.QueryType == QueryTypes.Contains)
                        {
                        if (detection.Contains (query.Detection))
                            matches = true;
                        }
                    }

                if (!matches)
                    return false;
                }

            if (SpectralQueries.Count > 0)
                {
                bool matches = false;

                foreach (SpectralQuery query in SpectralQueries)
                    if (Helper.IsDefined (exoplanet.Star.Property.SPType))
                        {
                        string spectual = exoplanet.Star.Property.SPType.ToLower ();

                        if (query.QueryType == QueryTypes.StartsWith)
                            {
                            if (spectual.StartsWith (query.Spectral))
                                matches = true;
                            }
                        else if (query.QueryType == QueryTypes.EndsWith)
                            {
                            if (spectual.EndsWith (query.Spectral))
                                matches = true;
                            }
                        else if (query.QueryType == QueryTypes.Contains)
                            {
                            if (spectual.Contains (query.Spectral))
                                matches = true;
                            }
                        }

                if (!matches)
                    return false;
                }

            if (HabitabilityQueries.Count > 0)
                {
                bool matches = false;

                foreach (HabitabilityQuery query in HabitabilityQueries)
                    {
                    string habitability = Habitability.GetHabitability (exoplanet).ToString ().ToLower();

                    if (query.QueryType == QueryTypes.StartsWith)
                        {
                        if (habitability.StartsWith (query.Habitability))
                            matches = true;
                        }
                    else if (query.QueryType == QueryTypes.EndsWith)
                        {
                        if (habitability.EndsWith (query.Habitability))
                            matches = true;
                        }
                    else if (query.QueryType == QueryTypes.Contains)
                        {
                        if (habitability.Contains (query.Habitability))
                            matches = true;
                        }
                    }

                if (!matches)
                    return false;
                }

            if (BetweenQueries.Count > 0)
                {
                bool matches = false;

                foreach (BetweenQuery query in BetweenQueries)
                    {
                    double value = 0.0;

                    if (Parse (exoplanet, query.PlotType, out value))
                        if (value >= query.LoValue && value <= query.HiValue)
                            matches = true;
                    }

                if (!matches)
                    return false;
                }

            if (LessThanQueries.Count > 0)
                {
                bool matches = false;

                foreach (LessThanQuery query in LessThanQueries)
                    {
                    double value = 0.0;

                    if (Parse (exoplanet, query.PlotType, out value))
                        if (value <= query.Value)
                            matches = true;
                    }

                if (!matches)
                    return false;
                }

            if (GreaterThanQueries.Count > 0)
                {
                bool matches = false;

                foreach (GreaterThanQuery query in GreaterThanQueries)
                    {
                    double value = 0.0;

                    if (Parse (exoplanet, query.PlotType, out value))
                        if (value >= query.Value)
                            matches = true;
                    }

                if (!matches)
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

        public static int WriteQueries ()
            {
            RegistryKey key = RegistryKey.OpenRemoteBaseKey (RegistryHive.CurrentUser, string.Empty);
            RegistryKey subkey = ( key != null ) ? key.CreateSubKey ("Software\\ExoplanetLibrary\\Queries") : null;

            if (subkey != null)
                for (int index = 0; index < Name.Length; ++index)
                    {
                    subkey.SetValue ("Name" + index.ToString (), Name [index], RegistryValueKind.String);
                    subkey.SetValue ("WhereClause" + index.ToString (), WhereClause [index], RegistryValueKind.String);
                    }

            if (key != null)
                key.Close ();

            return 0;
            }

        public static int ReadQueries ()
            {
            RegistryKey key = RegistryKey.OpenRemoteBaseKey (RegistryHive.CurrentUser, string.Empty);
            RegistryKey subkey = ( key != null ) ? key.CreateSubKey ("Software\\ExoplanetLibrary\\Queries") : null;

            if (subkey != null)
                for (int index = 0; index < Name.Length; ++index)
                    {
                    object obj = subkey.GetValue ("Name" + index.ToString ());
                    Name [index] = obj != null ? obj as string : "query" + ( index + 1 ).ToString ();

                    obj = subkey.GetValue ("WhereClause" + index.ToString ());
                    WhereClause [index] = obj != null ? obj as string : string.Empty;
                    }

            if (key != null)
                key.Close ();

            return 0;
            }
        }
    }
