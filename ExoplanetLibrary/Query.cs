using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                string spectral = "";
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

                        if (query.StartsWith ("start") || query.StartsWith ("startswith"))
                            queryType = QueryTypes.StartsWith;
                        else if (query.StartsWith ("contains"))
                            queryType = QueryTypes.Contains;
                        else if (query.StartsWith ("end") || query.StartsWith ("endswith"))
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

                        if (query.StartsWith ("start") || query.StartsWith ("startswith"))
                            queryType = QueryTypes.StartsWith;
                        else if (query.StartsWith ("contains"))
                            queryType = QueryTypes.Contains;
                        else if (query.StartsWith ("end") || query.StartsWith ("endswith"))
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

                        if (query.StartsWith ("start") || query.StartsWith ("startswith"))
                            queryType = QueryTypes.StartsWith;
                        else if (query.StartsWith ("contains"))
                            queryType = QueryTypes.Contains;
                        else if (query.StartsWith ("end") || query.StartsWith ("endswith"))
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
            SpectralQueries = new ArrayList ();
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

        static public string [] Name = { "query 1", "query 2", "query 3", "query 4", "query 5", "query 6", "query 7", "query 8", "query 9", "query 10",
                                         "query 11", "query 12", "query 13", "query 14", "query 15", "query 16", "query 17", "query 18", "query 19", "query 20"};
        static public string [] WhereClause = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };

        public static int WriteQueries ()
            {
            RegistryKey key = RegistryKey.OpenRemoteBaseKey (RegistryHive.CurrentUser, "");
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
            RegistryKey key = RegistryKey.OpenRemoteBaseKey (RegistryHive.CurrentUser, "");
            RegistryKey subkey = ( key != null ) ? key.CreateSubKey ("Software\\ExoplanetLibrary\\Queries") : null;

            if (subkey != null)
                for (int index = 0; index < Name.Length; ++index)
                    {
                    object obj = subkey.GetValue ("Name" + index.ToString ());

                    if (obj != null)
                        Name [index] = obj as string;

                    obj = subkey.GetValue ("WhereClause" + index.ToString ());

                    if (obj != null)
                        WhereClause [index] = obj as string;
                    }

            if (key != null)
                key.Close ();

            return 0;
            }
        }
    }
