using System.IO;
using System.Xml;

namespace ExoplanetLibrary
    {
    public class ReadVOT
        {
        public ReadVOT ()
            {
            }

        static private string Version_ = Constant.Version3;
        static private string Version
            {
            get { return Version_; }
            }

        static XmlReader Reader_ = null;
        static XmlReader Reader
            {
            get { return Reader_; }
            set { Reader_ = value; }
            }

        static private string [] Extensions_ = { ".vot" };
        static private string [] Extensions
            {
            get { return Extensions_; }
            }

        static public bool IsVOT (string fileName)
            {
            for (int index = 0; index < Extensions.Length; ++index)
                if (fileName.EndsWith (Extensions [index]))
                    return true;

            return false;
            }

        static public string ReplaceExtension (string fileName)
            {
            for (int index = 0; index < Extensions.Length; ++index)
                if (fileName.EndsWith (Extensions [index]))
                    return fileName.Replace (Extensions [index], ".xml");

            return fileName;
            }

        static public int Read (string votFileName)
            {
            if (File.Exists (votFileName))
                {
                XmlWriter writer = null;
                XmlWriterSettings settings = null;

                settings = new XmlWriterSettings ();

                settings.IndentChars = "\t";
                settings.NewLineHandling = NewLineHandling.Entitize;
                settings.Indent = true;
                settings.NewLineChars = "\n";

                string xmlFileName = votFileName.Replace (".vot", ".xml");

                writer = XmlWriter.Create (xmlFileName, settings);
                writer.WriteStartElement ("Exoplanets");
                writer.WriteAttributeString ("version", Version);

                TextReader reader = null;
                Indexer.Initialize ();

                using (reader = File.OpenText (votFileName))
                    {
                    string line = null;
                    int index = 0;                                  // used by NASA VOT

                    for (;;)
                        {
                        line = reader.ReadLine ();

                        if (line == null)
                            break;

                        line = line.Trim ();

                        if (line.Length == 0)
                            {
                            ;
                            }
                        else if (line.StartsWith ("<TR>"))          // NASA VOT
                            {
                            line = line.Replace ("<TR>", string.Empty);
                            WriteExoplanet (writer, line);
                            }
                        else if (line.StartsWith ("<TD>"))          // EU VOT
                            {
                            WriteExoplanet (writer, line);
                            }
                        else if (line.StartsWith ("<FIELD"))
                            {
                            char [] delimiterChars = { ' ' };
                            string [] substrings = line.Split (delimiterChars);

                            if (substrings [1].StartsWith ("ID=\"col"))
                                {                                   // EU VOT
                                if (substrings [2].StartsWith ("name=\""))
                                    {
                                    string temporary, name;
                                    int column = 0;

                                    temporary = substrings [1].Replace ("ID=\"col", string.Empty);
                                    temporary = temporary.Replace ("\"", string.Empty);
                                    column = int.Parse (temporary);

                                    name = substrings [2].Replace ("name=\"", string.Empty);
                                    name = name.Replace ("\"", string.Empty);

                                    Indexer.SetIndex (name, column - 1);
                                    }
                                }
                            else
                                {
                                if (substrings [1].StartsWith ("name=\""))
                                    {                               // NASA VOT
                                    string name;

                                    name = substrings [1].Replace ("name=\"", string.Empty);
                                    name = name.Replace ("\"", string.Empty);

                                    Indexer.SetIndex (name, index);
                                    ++index;
                                    }
                                }
                            }
                        }
                    }

                writer.WriteEndElement ();
                writer.Close ();
                }

            return 0;
            }

        static private int WriteExoplanet (XmlWriter writer, string line)
            {
            Exoplanet exoplanet = new Exoplanet ();
            char [] delimiterChars = { '|' };

            string stringer = line.Replace ("</TD><TD>", "</TD>|<TD>");
            string [] substrings = stringer.Split (delimiterChars);

            for (int index = 0; index < substrings.Length; ++index)
                {
                substrings [index] = substrings [index].Replace ("<TD>", string.Empty);
                substrings [index] = substrings [index].Replace ("</TD>", string.Empty);
                }

            exoplanet.AssignFromSubstrings (substrings);
            exoplanet.CorrectErrors ();
            WriteXML.WriteExoplanet (writer, exoplanet, Version);

            return 0;
            }
        }
    }
