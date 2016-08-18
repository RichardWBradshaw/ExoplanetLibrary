﻿using System.IO;
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

        static private bool IsNasaVot_ = false;
        static private bool IsNasaVot
            {
            get { return IsNasaVot_; }
            set { IsNasaVot_ = value; }
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
                settings.NewLineHandling = NewLineHandling.Entitize;
                settings.Indent = true;
                settings.NewLineChars = "\n";

                string xmlFileName = votFileName.Replace (".vot", ".xml");

                writer = XmlWriter.Create (xmlFileName, settings);
                writer.WriteStartElement ("Exoplanets");
                writer.WriteAttributeString ("version", Version);

                TextReader reader = null;
                IsNasaVot = false;

                Indexer.Initialize ();

                using (reader = File.OpenText (votFileName))
                    {
                    string line = null;
                    int index = 0;                                  // used by NASA VOT

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
                            else if (line.StartsWith ("<TR>"))      // NASA VOT
                                {
                                line = line.Replace ("<TR>", "");
                                WriteExoplanet (writer, line);
                                }
                            else if (line.StartsWith ("<TD>"))      // EU VOT
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
                                    {                               // EU VOT
                                    if (substrings [2].StartsWith ("name=\""))
                                        {
                                        string temporary, name;
                                        int column = 0;

                                        temporary = substrings [1].Replace ("ID=\"col", "");
                                        temporary = temporary.Replace ("\"", "");
                                        column = int.Parse (temporary);

                                        name = substrings [2].Replace ("name=\"", "");
                                        name = name.Replace ("\"", "");

                                        Indexer.SetIndex (name, column - 1);
                                        }
                                    }
                                else
                                    {
                                    if (substrings [1].StartsWith ("name=\""))
                                        {                           // NASA VOT
                                        string name;

                                        name = substrings [1].Replace ("name=\"", "");
                                        name = name.Replace ("\"", "");

                                        Indexer.SetIndex (name, index);
                                        ++index;

                                        IsNasaVot = true;
                                        }
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
            exoplanet.CorrectErrors (IsNasaVot);
            WriteXML.WriteExoplanet (writer, exoplanet, Version);

            return 0;
            }
        }
    }
