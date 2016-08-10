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

        static public int Read (string votFileName)
            {
            if (File.Exists (votFileName))
                {
                XmlWriter writer = null;
                XmlWriterSettings settings = null;

                settings = new XmlWriterSettings ();

                settings.IndentChars = "\t";
                settings.NewLineHandling = System.Xml.NewLineHandling.Entitize;
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

                    for (;;)
                        {
                        line = reader.ReadLine ();

                        if (line != null)
                            {
                            line = line.Trim ();

                            if (line.Length == 0)
                                {
                                ;
                                }
                            else if (line.StartsWith ("<TR>"))
                                {
                                ;
                                }
                            else if (line.StartsWith ("<TD>"))
                                {
                                WriteExoplanet (writer, line);
                                }
                            else if (line.StartsWith ("</TR>"))
                                {
                                ;
                                }
                            else if (line.StartsWith ("<VOTABLE"))
                                {
                                ;
                                }
                            else if (line.StartsWith ("<RESOURCE"))
                                {
                                ;
                                }
                            else if (line.StartsWith ("<INFO"))
                                {
                                ;
                                }
                            else if (line.StartsWith ("<COOSYS"))
                                {
                                ;
                                }
                            else if (line.StartsWith ("<TABLE"))
                                {
                                ;
                                }
                            else if (line.StartsWith ("<DESCRIPTION"))
                                {
                                ;
                                }
                            else if (line.StartsWith ("<FIELD"))
                                {
                                char [] delimiterChars = { ' ' };
                                string [] substrings = line.Split (delimiterChars);

                                if (substrings [1].StartsWith ("ID=\"col"))
                                    if (substrings [2].StartsWith ("name=\""))
                                        {
                                        string temporary, name;
                                        int index;

                                        temporary = substrings [1].Replace ("ID=\"col", "");
                                        temporary = temporary.Replace ("\"", "");
                                        index = int.Parse (temporary);

                                        name = substrings [2].Replace ("name=\"", "");
                                        name = name.Replace ("\"", "");

                                        Indexer.SetIndex (name, index - 1);
                                        }
                                }
                            else if (line.StartsWith ("</FIELD>"))
                                {
                                ;
                                }
                            else if (line.StartsWith ("<DATA"))
                                {
                                ;
                                }
                            else if (line.StartsWith ("</DATA>"))
                                {
                                ;
                                }
                            else if (line.StartsWith ("<TABLEDATA"))
                                {
                                ;
                                }
                            else if (line.StartsWith ("</TABLEDATA>"))
                                {
                                ;
                                }
                            else if (line.StartsWith ("</DATA"))
                                {
                                ;
                                }
                            else if (line.StartsWith ("</TABLE>"))
                                {
                                ;
                                }
                            else if (line.StartsWith ("<RESOURCE"))
                                {
                                ;
                                }
                            else if (line.StartsWith ("</VOTABLE>"))
                                {
                                ;
                                }
                            }
                        else
                            break;
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
                substrings [index] = substrings [index].Replace ("<TD>", "");
                substrings [index] = substrings [index].Replace ("</TD>", "");
                }

            exoplanet.AssignFromSubstrings (substrings);
            exoplanet.CorrectErrors ();
            WriteXML.WriteExoplanet (writer, exoplanet, Version);

            return 0;
            }
        }
    }
