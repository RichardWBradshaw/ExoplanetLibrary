using System.IO;
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
                else
                    xmlFileName = csvFileName.Replace (".csv", ".xml");

                if (IsValidVersion (csvFileName))
                    {
                    writer = XmlWriter.Create (xmlFileName, settings);

                    writer.WriteStartElement ("Exoplanets");
                    writer.WriteAttributeString ("version", Version);

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

                if (firstLine.StartsWith ("# name,mass,") || firstLine.StartsWith ("# name, mass, "))
                    {
                    string [] strings = firstLine.Split (delimiterChars);

                    if (strings.Length == Constant.Version1StringCount)
                        Version = Constant.Version1;
                    else if (strings.Length == Constant.Version2StringCount)
                        Version = Constant.Version2;    // xml version not ascii version
                    else if (strings.Length == Constant.Version3StringCount)
                        Version = Constant.Version2;    // xml version not ascii version

                    if (Version.Length > 0)
                        Indexer.SetAllIndex (firstLine);
                    }
                }

            reader.Close ();

            return Version.Length > 0 ? true : false;
            }

        static private int WriteExoplanet (XmlWriter writer, string line)
            {
            if (line.StartsWith ("#"))
                return 0;

            char [] delimiterChars = { ',', '\t' };
            string [] strings = line.Split (delimiterChars);

            Exoplanet exoplanet = new Exoplanet ();

            exoplanet.AssignFromSubstrings (strings);
            exoplanet.CorrectErrors ();
            WriteXML.WriteExoplanet (writer, exoplanet, Version);

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

                ;

                if (IsValidVersion (csvFileName))
                    {
                    writer = XmlWriter.Create (xmlFileName, settings);

                    writer.WriteStartElement ("Exoplanets");
                    writer.WriteAttributeString ("version", Version);

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
