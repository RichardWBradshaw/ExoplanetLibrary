using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace ExoplanetLibrary
    {
    public class ReadCSV
        {
        public ReadCSV ()
            {
            }

        static private string Version_ = Constant.Version2;
        static private string Version
            {
            get { return Version_; }
            set { Version_ = value; }
            }

        static private bool IsCommaDelimited_ = true;
        static private bool IsCommaDelimited
            {
            get { return IsCommaDelimited_; }
            set { IsCommaDelimited_ = value; }
            }

        static private string ValidationErrors_ = "";
        static private string ReadErrors
            {
            get { return ValidationErrors_; }
            set { ValidationErrors_ = value; }
            }

        static public int Read (string csvFileName)
            {
            if (File.Exists (csvFileName))
                {
                XmlWriter writer = null;
                XmlWriterSettings settings = null;

                settings = new XmlWriterSettings ();

                settings.IndentChars = "\t";
                settings.NewLineHandling = NewLineHandling.Entitize;
                settings.Indent = true;
                settings.NewLineChars = "\n";

                string xmlFileName = "";

                if (csvFileName.EndsWith (".txt"))
                    xmlFileName = csvFileName.Replace (".txt", ".xml");
                else if (csvFileName.EndsWith (".dat"))
                    xmlFileName = csvFileName.Replace (".dat", ".xml");
                else
                    xmlFileName = csvFileName.Replace (".csv", ".xml");

                ReadErrors = "";

                if (IsValidVersion (csvFileName))
                    {
                    writer = XmlWriter.Create (xmlFileName, settings);

                    writer.WriteStartElement ("Exoplanets");
                    writer.WriteAttributeString ("version", Version);

                    SetDelimitor (csvFileName);

                    TextReader reader = null;

                    using (reader = File.OpenText (csvFileName))
                        {
                        string line = null;

                        for (;;)
                            {
                            if (( line = reader.ReadLine () ) != null)
                                WriteExoplanet (writer, line);
                            else
                                break;
                            }
                        }

                    writer.WriteEndElement ();
                    writer.Close ();
                    }

                if (ReadErrors.Length > 0)
                    MessageBox.Show (ReadErrors, "Format errors in " + csvFileName);
                }

            return 0;
            }

        static private bool IsValidVersion (string csvFileName)
            {
            TextReader reader = File.OpenText (csvFileName);

            Version = "";

            if (reader != null)
                {
                string firstLine = reader.ReadLine ();
                char [] delimiterChars = { ',', '\t' };

                if (firstLine.StartsWith ("# name,mass,") || firstLine.StartsWith ("# name, mass, ") || firstLine.StartsWith ("# name\tmass\t"))
                    {
                    string [] strings = firstLine.Split (delimiterChars);

                    if (strings.Length == Constant.Version1StringCount)
                        Version = Constant.Version1;
                    else if (strings.Length == Constant.Version2StringCount)
                        Version = Constant.Version2;
                    else if (strings.Length == Constant.Version3StringCount)
                        Version = Constant.Version3;

                    if (Version.Length > 0)
                        Indexer.SetAllIndex (firstLine);
                    }
                }

            reader.Close ();

            return Version.Length > 0 ? true : false;
            }

        static private void SetDelimitor (string csvFileName)
            {
            TextReader reader = File.OpenText (csvFileName);

            IsCommaDelimited = true;

            if (reader != null)
                {
                string firstLine = reader.ReadLine ();

                if (firstLine.StartsWith ("# name,mass,") || firstLine.StartsWith ("# name, mass, "))
                    IsCommaDelimited = true;
                else if (firstLine.StartsWith ("# name\tmass\t"))
                    IsCommaDelimited = false;
                }

            reader.Close ();
            }

        static private int WriteExoplanet (XmlWriter writer, string line)
            {
            if (line.StartsWith ("#"))
                return 0;

            //
            // kludge: .csv's can contain commas and / or tabs within in the data (i.e. not used as the separators)
            //

            if (IsCommaDelimited == true)
                {
                line = line.Replace ('\t', ' ');
                line = Helper.ReplaceInQuotedDelimitor (line);
                }
            else
                line = line.Replace (',', ';');

            char [] delimiterChars = { ',', '\t' };
            string [] strings = line.Split (delimiterChars);
            string xmlVersion = "";

            if (Version == Constant.Version1 && strings.Length == Constant.Version1StringCount)
                xmlVersion = Constant.Version1;
            else if (Version == Constant.Version2 && strings.Length == Constant.Version2StringCount)
                xmlVersion = Constant.Version2;
            else if (Version == Constant.Version3 && strings.Length == Constant.Version3StringCount)
                xmlVersion = Constant.Version2;

            if (xmlVersion.Length > 0)
                {
                Exoplanet exoplanet = new Exoplanet ();

                exoplanet.AssignFromSubstrings (strings);
                exoplanet.CorrectErrors ();
                WriteXML.WriteExoplanet (writer, exoplanet, xmlVersion);
                }
            else
                ReadErrors += line + "\r";

            return 0;
            }

        public static void StreamRead (string csvFileName)
            {
            if (File.Exists (csvFileName))
                {
                XmlWriter writer = null;
                XmlWriterSettings settings = null;

                settings = new XmlWriterSettings ();

                settings.IndentChars = "\t";
                settings.NewLineHandling = NewLineHandling.Entitize;
                settings.Indent = true;
                settings.NewLineChars = "\n";

                string xmlFileName = "";

                if (csvFileName.EndsWith (".txt"))
                    xmlFileName = csvFileName.Replace (".txt", ".xml");
                else
                    xmlFileName = csvFileName.Replace (".csv", ".xml");

                if (IsValidVersion (csvFileName))
                    {
                    writer = XmlWriter.Create (xmlFileName, settings);

                    writer.WriteStartElement ("Exoplanets");

                    if (Version == Constant.Version1)
                        writer.WriteAttributeString ("version", Constant.Version1);
                    else if (Version == Constant.Version2 || Version == Constant.Version3)
                        writer.WriteAttributeString ("version", Constant.Version2);

                    using (StreamReader stream = new StreamReader (csvFileName))
                        {
                        if (stream != null)
                            {
                            string line = null;

                            while (( line = stream.ReadLine () ) != null)
                                {
                                WriteExoplanet (writer, line);
                                }
                            }
                        }

                    writer.WriteEndElement ();
                    writer.Close ();
                    }
                }
            }
        }
    }
