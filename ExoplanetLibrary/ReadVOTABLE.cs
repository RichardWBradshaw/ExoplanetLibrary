using System.IO;
using System.Xml;

namespace ExoplanetLibrary
    {
    public class ReadVOTABLE
        {
        public ReadVOTABLE ()
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

                string xmlFileName = "";

                if (votFileName.EndsWith (".votable"))
                    xmlFileName = votFileName.Replace (".votable", ".xml");
                else if (votFileName.EndsWith (".vot"))
                    xmlFileName = votFileName.Replace (".vot", ".xml");

                writer = XmlWriter.Create (xmlFileName, settings);

                writer.WriteStartElement ("Exoplanets");
                writer.WriteAttributeString ("version", Version);

                TextReader reader = null;

                Indexer.Initialize ();

                using (reader = File.OpenText (votFileName))
                    {
                    int index = 0;
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
                                WriteExoplanet (writer, line);
                                }
                            else if (line.StartsWith ("<TD>"))
                                {
                                ;
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

                                if (substrings [1].StartsWith ("name=\""))
                                    {
                                    string name;

                                    name = substrings [1].Replace ("name=\"", "");
                                    name = name.Replace ("\"", "");

                                    Indexer.SetIndex (name, index);
                                    ++index;
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

/*
 *             case "rowid": break;
            case "pl_hostname": break;
            case "pl_letter": break;
            case "pl_discmethod": break;
            case "pl_pnum": break;
            case "pl_orbper": break;
            case "pl_orbpererr1": break;
            case "pl_orbpererr2": break;
            case "pl_orbperlim": break;
            case "pl_orbsmax": break;
            case "pl_orbsmaxerr1": break;
            case "pl_orbsmaxerr2": break;
            case "pl_orbsmaxlim": break;
            case "pl_orbeccen": break;
            case "pl_orbeccenerr1": break;
            case "pl_orbeccenerr2": break;
            case "pl_orbeccenlim": break;
            case "pl_orbincl": break;
            case "pl_orbinclerr1": break;
            case "pl_orbinclerr2": break;
            case "pl_orbincllim": break;
            case "pl_bmassj": break;
            case "pl_bmassjerr1": break;
            case "pl_bmassjerr2": break;
            case "pl_bmassjlim": break;
            case "pl_bmassprov": break;
            case "pl_radj": break;
            case "pl_radjerr1": break;
            case "pl_radjerr2": break;
            case "pl_radjlim": break;
            case "pl_dens": break;
            case "pl_denserr1": break;
            case "pl_denserr2": break;
            case "pl_denslim": break;
            case "pl_ttvflag": break;
            case "pl_kepflag": break;
            case "pl_kcase flag": break;
            case "pl_nnotes": break;
            case "pl_name": break;
            case "pl_tranflag": break;
            case "pl_rvflag": break;
            case "pl_imgflag": break;
            case "pl_astflag": break;
            case "pl_omflag": break;
            case "pl_cbflag": break;
            case "pl_orbtper": break;
            case "pl_orbtpererrc1": break;
            case "pl_orbtpererrc2": break;
            case "pl_orbtperlim": break;
            case "pl_orblper": break;
            case "pl_orblpererr1": break;
            case "pl_orblpererr2": break;
            case "pl_orblperlim": break;
            case "pl_rvamp": break;
            case "pl_rvamperr1": break;
            case "pl_rvamperr2": break;
            case "pl_rvamplim": break;
            case "pl_eqt": break;
            case "pl_eqterr1": break;
            case "pl_eqterr2": break;
            case "pl_eqtlim": break;
            case "pl_insol": break;
            case "pl_insolerr1": break;
            case "pl_insolerr2": break;
            case "pl_insollim": break;
            case "pl_massj": break;
            case "pl_massjerr1": break;
            case "pl_massjerr2": break;
            case "pl_massjlim": break;
            case "pl_msinij": break;
            case "pl_msinijerr1": break;
            case "pl_msinijerr2": break;
            case "pl_msinijlim": break;
            case "pl_masse": break;
            case "pl_masseerr1": break;
            case "pl_masseerr2": break;
            case "pl_masselim": break;
            case "pl_msinie": break;
            case "pl_msinieerr1": break;
            case "pl_msinieerr2": break;
            case "pl_msinielim": break;
            case "pl_bmasse": break;
            case "pl_bmasseerr1": break;
            case "pl_bmasseerr2": break;
            case "pl_bmasselim": break;
            case "pl_rade": break;
            case "pl_radeerr1": break;
            case "pl_radeerr2": break;
            case "pl_radelim": break;
            case "pl_rads": break;
            case "pl_radserr1": break;
            case "pl_radserr2": break;
            case "pl_radslim": break;
            case "pl_trandep": break;
            case "pl_trandeperr1": break;
            case "pl_trandeperr2": break;
            case "pl_trandeplim": break;
            case "pl_trandur": break;
            case "pl_trandurerr1": break;
            case "pl_trandurerr2": break;
            case "pl_trandurlim": break;
            case "pl_tranmid": break;
            case "pl_tranmiderr1": break;
            case "pl_tranmiderr2": break;
            case "pl_tranmidlim": break;
            case "pl_tsystemref": break;
            case "pl_imppar": break;
            case "pl_impparerr1": break;
            case "pl_impparerr2": break;
            case "pl_impparlim": break;
            case "pl_occdep": break;
            case "pl_occdeperr1": break;
            case "pl_occdeperr2": break;
            case "pl_occdeplim": break;
            case "pl_ratdor": break;
            case "pl_ratdorerr1": break;
            case "pl_ratdorerr2": break;
            case "pl_ratdorlim": break;
            case "pl_ratror": break;
            case "pl_ratrorerr1": break;
            case "pl_ratrorerr2": break;
            case "pl_ratrorlim": break;
            case "pl_def_reflink": break;
            case "pl_disc": break;
            case "pl_disc_reflink": break;
            case "pl_locale": break;
            case "pl_facility": break;
            case "pl_telescope": break;
            case "pl_instrument": break;
            case "pl_status": break;
            case "pl_mnum": break;
            case "pl_st_npar": break;
            case "pl_st_nref": break;
            case "pl_pelink": break;
            case "pl_edelink": break;
            case "pl_publ_date": break;
            */
