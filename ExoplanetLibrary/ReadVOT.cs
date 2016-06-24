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
            set { Version_ = value; }
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

                string xmlFileName = "";

                if (votFileName.EndsWith (".vot"))
                    xmlFileName = votFileName.Replace (".vot", ".xml");
                else
                    xmlFileName = votFileName.Replace (".dat", ".xml");

                Version = GetVersion (votFileName);

                if (string.Equals (Version, Constant.Version1) ||
                    string.Equals (Version, Constant.Version2) ||
                    string.Equals (Version, Constant.Version3))
                    {
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
                    }

                writer.WriteEndElement ();
                writer.Close ();
                }

            return 0;
            }

        static private string GetVersion (string votFileName)
            {
            string version = "";

            if (File.Exists (votFileName))
                {
                TextReader reader = null;

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
                                break;
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
                                    {
                                    string temporary;
                                    int index;

                                    temporary = substrings [1].Replace ("ID=\"col", "");
                                    temporary = temporary.Replace ("\"", "");
                                    index = int.Parse (temporary);

                                    if (index == Constant.Version1StringCount)
                                        version = Constant.Version1;
                                    else if (index == Constant.Version2StringCount)
                                        version = Constant.Version2;
                                    else if (index == Constant.Version3StringCount)
                                        version = Constant.Version3;
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
                                break;
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
                }

            return version;
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
