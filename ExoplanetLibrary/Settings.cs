using System.Windows.Forms;
using Microsoft.Win32;

namespace ExoplanetLibrary
    {
    public class Visualization
        {
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

        static private CheckState IncludeNames_ = CheckState.Unchecked;
        static public CheckState IncludeNames
            {
            get { return IncludeNames_; }
            set { IncludeNames_ = value; }
            }

        static private CheckState IncludeErrorBars_ = CheckState.Checked;
        static public CheckState IncludeErrorBars
            {
            get { return IncludeErrorBars_; }
            set { IncludeErrorBars_ = value; }
            }

        static private CheckState IncludeDuplicates_ = CheckState.Unchecked;
        static public CheckState IncludeDuplicates
            {
            get { return IncludeDuplicates_; }
            set { IncludeDuplicates_ = value; }
            }

        static private CheckState UtilizeQuery_ = CheckState.Unchecked;
        static public CheckState UtilizeQuery
            {
            get { return UtilizeQuery_; }
            set { UtilizeQuery_ = value; }
            }

        static private CheckState IncludeBestFitLine_ = CheckState.Unchecked;
        static public CheckState IncludeBestFitLine
            {
            get { return IncludeBestFitLine_; }
            set { IncludeBestFitLine_ = value; }
            }

        static private CheckState IncludeBestFitCurve_ = CheckState.Unchecked;
        static public CheckState IncludeBestFitCurve
            {
            get { return IncludeBestFitCurve_; }
            set { IncludeBestFitCurve_ = value; }
            }

        Visualization ()
            {
            LogXAxis = CheckState.Unchecked;
            LogYAxis = CheckState.Unchecked;

            IncludeNames = CheckState.Unchecked;
            IncludeErrorBars = CheckState.Unchecked;
            IncludeDuplicates = CheckState.Checked;

            UtilizeQuery = CheckState.Checked;

            IncludeBestFitLine = CheckState.Checked;
            IncludeBestFitCurve = CheckState.Checked;
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
            RegistryKey key = RegistryKey.OpenRemoteBaseKey (RegistryHive.CurrentUser, string.Empty);
            RegistryKey subkey = ( key != null ) ? key.CreateSubKey ("Software\\ExoplanetLibrary") : null;

            if (subkey != null)
                {
                subkey.SetValue ("LogXAxis", Visualization.LogXAxis == CheckState.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("LogYAxis", Visualization.LogYAxis == CheckState.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("IncludeNames", Visualization.IncludeNames == CheckState.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("IncludeErrorBars", Visualization.IncludeErrorBars == CheckState.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("IncludeDuplicates", Visualization.IncludeDuplicates == CheckState.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("UtilizeQuery", Visualization.UtilizeQuery == CheckState.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("IncludeBestFitLine", Visualization.IncludeBestFitLine == CheckState.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("IncludeBestFitCurve", Visualization.IncludeBestFitCurve == CheckState.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("OpenFileFilterIndex", Settings.FilterIndex, RegistryValueKind.String);

                Queries.WriteQueries ();
                }

            if (key != null)
                key.Close ();

            return 0;
            }

        static public void Read ()
            {
            RegistryKey key = RegistryKey.OpenRemoteBaseKey (RegistryHive.CurrentUser, string.Empty);
            RegistryKey subkey = key != null ? key.OpenSubKey ("Software\\ExoplanetLibrary") : null;

            if (subkey != null)
                {
                Visualization.LogXAxis = ReadValue (subkey, "LogXAxis");
                Visualization.LogYAxis = ReadValue (subkey, "LogYAxis");
                Visualization.IncludeNames = ReadValue (subkey, "IncludeNames");
                Visualization.IncludeErrorBars = ReadValue (subkey, "IncludeErrorBars");
                Visualization.IncludeDuplicates = ReadValue (subkey, "IncludeDuplicates");
                Visualization.UtilizeQuery = ReadValue (subkey, "UtilizeQuery");
                Visualization.IncludeBestFitLine = ReadValue (subkey, "IncludeBestFitLine");
                Visualization.IncludeBestFitCurve = ReadValue (subkey, "IncludeBestFitCurve");

                Settings.FilterIndex = ReadIntegerValue (subkey, "OpenFileFilterIndex");

                Queries.ReadQueries ();
                }

            if (key != null)
                key.Close ();
            }

        static public int WriteFileName (string xmlFileName)
            {
            RegistryKey key = RegistryKey.OpenRemoteBaseKey (RegistryHive.CurrentUser, string.Empty);
            RegistryKey subkey = ( key != null ) ? key.CreateSubKey ("Software\\ExoplanetLibrary") : null;

            if (subkey != null)
                subkey.SetValue ("XMLFileName", xmlFileName, RegistryValueKind.String);

            if (key != null)
                key.Close ();

            return 0;
            }

        static public string ReadFileName ()
            {
            string xmlFileName = string.Empty;
            RegistryKey key = RegistryKey.OpenRemoteBaseKey (RegistryHive.CurrentUser, string.Empty);
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
            return WriteLastVisit (Constant.LastExoplanetEUVisit, dateTime);
            }

        static public int WriteLastNASAVisit (System.DateTime dateTime)
            {
            return WriteLastVisit (Constant.LastNASAVisit, dateTime);
            }

        static public int WriteLastExoplanetsOrgVisit (System.DateTime dateTime)
            {
            return WriteLastVisit (Constant.LastExoplanetsOrgVisit, dateTime);
            }

        static private int WriteLastVisit (string keyValue, System.DateTime dateTime)
            {
            RegistryKey key = RegistryKey.OpenRemoteBaseKey (RegistryHive.CurrentUser, string.Empty);
            RegistryKey subkey = ( key != null ) ? key.CreateSubKey ("Software\\ExoplanetLibrary") : null;

            if (subkey != null)
                subkey.SetValue (keyValue, dateTime.ToString (), RegistryValueKind.String);

            if (key != null)
                key.Close ();

            return 0;
            }

        static public string ReadLastEUVisit ()
            {
            return ReadLastVisit (Constant.LastExoplanetEUVisit);
            }

        static public string ReadLastNASAVisit ()
            {
            return ReadLastVisit (Constant.LastNASAVisit);
            }

        static public string ReadLastExoplanetsOrgVisit ()
            {
            return ReadLastVisit (Constant.LastExoplanetsOrgVisit);
            }

        static private string ReadLastVisit (string keyValue)
            {
            string dateTime = string.Empty;
            RegistryKey key = RegistryKey.OpenRemoteBaseKey (RegistryHive.CurrentUser, string.Empty);
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
