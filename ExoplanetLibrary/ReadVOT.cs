using System.IO;
using System.Xml;

namespace ExoplanetLibrary
    {
    class ReadVOT : CExoplanet
        {
        static private string Version_ = "2.0";
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
            if (System.IO.File.Exists (votFileName))
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

                if (string.Equals (Version, "1.0") || string.Equals (Version, "2.0"))
                    {
                    writer = XmlWriter.Create (xmlFileName, settings);

                    writer.WriteStartElement ("Exoplanets");
                    writer.WriteAttributeString ("version", Version);

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
                                    ;
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

        static private int WriteExoplanet (XmlWriter writer, string line)
            {
            CExoplanet exoplanet = new CExoplanet ();
            bool done = false;
            int column = 1;
            int startIndex = -1, endIndex = -1;

            for (int index = 0; index < line.Length - 4 && done == false; ++index)
                {
                if (line.Substring (index, 4) == "<TD>")
                    {
                    startIndex = index + 4;
                    }
                else if (line.Substring (index, 5) == "</TD>")
                    {
                    endIndex = index - 1;

                    if (endIndex > startIndex)
                        {
                        int length = ( endIndex - startIndex ) + 1;
                        string stringer = line.Substring (startIndex, length);

                        switch (column)
                            {
                            case 1: exoplanet.Name = stringer; break;

                            case 2: exoplanet.Mass = ReplaceNonNumerics (stringer); break;
                            case 3: exoplanet.MassErrorMin = ReplaceNonNumerics (stringer); break;
                            case 4: exoplanet.MassErrorMax = ReplaceNonNumerics (stringer); break;

                            case 5: exoplanet.Radius = ReplaceNonNumerics (stringer); break;
                            case 6: exoplanet.RadiusErrorMin = ReplaceNonNumerics (stringer); break;
                            case 7: exoplanet.RadiusErrorMax = ReplaceNonNumerics (stringer); break;

                            case 8: exoplanet.OrbitalPeriod = ReplaceNonNumerics (stringer); break;
                            case 9: exoplanet.OrbitalPeriodErrorMin = ReplaceNonNumerics (stringer); break;
                            case 10: exoplanet.OrbitalPeriodErrorMax = ReplaceNonNumerics (stringer); break;

                            case 11: exoplanet.SemiMajorAxis = ReplaceNonNumerics (stringer); break;
                            case 12: exoplanet.SemiMajorAxisErrorMin = ReplaceNonNumerics (stringer); break;
                            case 13: exoplanet.SemiMajorAxisErrorMax = ReplaceNonNumerics (stringer); break;

                            case 14: exoplanet.Eccentricity = ReplaceNonNumerics (stringer); break;
                            case 15: exoplanet.EccentricityErrorMin = ReplaceNonNumerics (stringer); break;
                            case 16: exoplanet.EccentricityErrorMax = ReplaceNonNumerics (stringer); break;

                            case 17: exoplanet.Inclination = ReplaceNonNumerics (stringer); break;
                            case 18: exoplanet.InclinationErrorMin = ReplaceNonNumerics (stringer); break;
                            case 19: exoplanet.InclinationErrorMax = ReplaceNonNumerics (stringer); break;

                            case 20: exoplanet.AngularDistance = ReplaceNonNumerics (stringer); break;

                            case 21: exoplanet.Discovered = stringer; break;

                            case 22: exoplanet.Updated = stringer; break;

                            case 23: exoplanet.Omega = ReplaceNonNumerics (stringer); break;
                            case 24: exoplanet.OmegaErrorMin = ReplaceNonNumerics (stringer); break;
                            case 25: exoplanet.OmegaErrorMax = ReplaceNonNumerics (stringer); break;

                            case 26: exoplanet.Tperi = ReplaceNonNumerics (stringer); break;
                            case 27: exoplanet.TperiErrorMin = ReplaceNonNumerics (stringer); break;
                            case 28: exoplanet.TperiErrorMax = ReplaceNonNumerics (stringer); break;

                            case 29: exoplanet.Tconj = ReplaceNonNumerics (stringer); break;
                            case 30: exoplanet.TconjErrorMin = ReplaceNonNumerics (stringer); break;
                            case 31: exoplanet.TconjErrorMax = ReplaceNonNumerics (stringer); break;

                            case 32: exoplanet.TzeroTr = ReplaceNonNumerics (stringer); break;
                            case 33: exoplanet.TzeroTrErrorMin = ReplaceNonNumerics (stringer); break;
                            case 34: exoplanet.TzeroTrErrorMax = ReplaceNonNumerics (stringer); break;

                            case 35: exoplanet.TzeroTrSec = ReplaceNonNumerics (stringer); break;
                            case 36: exoplanet.TzeroTrSecErrorMin = ReplaceNonNumerics (stringer); break;
                            case 37: exoplanet.TzeroTrSecErrorMax = ReplaceNonNumerics (stringer); break;

                            case 38: exoplanet.LambdaAngle = ReplaceNonNumerics (stringer); break;
                            case 39: exoplanet.LambdaAngleErrorMin = ReplaceNonNumerics (stringer); break;
                            case 40: exoplanet.LambdaAngleErrorMax = ReplaceNonNumerics (stringer); break;

                            case 41: exoplanet.ImpactParameter = ReplaceNonNumerics (stringer); break;
                            case 42: exoplanet.ImpactParameterErrorMin = ReplaceNonNumerics (stringer); break;
                            case 43: exoplanet.ImpactParameterErrorMax = ReplaceNonNumerics (stringer); break;

                            case 44: exoplanet.TzeroVr = ReplaceNonNumerics (stringer); break;
                            case 45: exoplanet.TzeroVrErrorMin = ReplaceNonNumerics (stringer); break;
                            case 46: exoplanet.TzeroVrErrorMax = ReplaceNonNumerics (stringer); break;

                            case 47: exoplanet.K = ReplaceNonNumerics (stringer); break;
                            case 48: exoplanet.KErrorMin = ReplaceNonNumerics (stringer); break;
                            case 49: exoplanet.KErrorMax = ReplaceNonNumerics (stringer); break;

                            case 50: exoplanet.TemperatureMeasured = ReplaceNonNumerics (stringer); break;

                            case 51: exoplanet.TemperatureCalculated = ReplaceNonNumerics (stringer); break;

                            case 52: exoplanet.TemperatureHotPointLo = ReplaceNonNumerics (stringer); break;

                            case 53: exoplanet.GeometricAlbedo = ReplaceNonNumerics (stringer); break;
                            case 54: exoplanet.GeometricAlbedoErrorMin = ReplaceNonNumerics (stringer); break;
                            case 55: exoplanet.GeometricAlbedoErrorMax = ReplaceNonNumerics (stringer); break;

                            case 56: exoplanet.LogG = ReplaceNonNumerics (stringer); break;

                            case 57: exoplanet.Status = stringer; break;

                            case 58: exoplanet.DetectionType = stringer; break;

                            case 59: exoplanet.MassDetectionType = stringer; break;

                            case 60: exoplanet.RadiusDetectionType = stringer; break;

                            case 61: exoplanet.AlternateNames = stringer; break;

                            case 62: exoplanet.Molecules = stringer; break;

                            case 63: exoplanet.Star.Name = stringer; break;

                            case 64: exoplanet.Star.RightAccession = ReplaceNonNumerics (stringer); break;

                            case 65: exoplanet.Star.Declination = ReplaceNonNumerics (stringer); break;

                            case 66: exoplanet.Star.Magnitudes.V = ReplaceNonNumerics (stringer); break;
                            case 67: exoplanet.Star.Magnitudes.I = ReplaceNonNumerics (stringer); break;
                            case 68: exoplanet.Star.Magnitudes.J = ReplaceNonNumerics (stringer); break;
                            case 69: exoplanet.Star.Magnitudes.H = ReplaceNonNumerics (stringer); break;
                            case 70: exoplanet.Star.Magnitudes.K = ReplaceNonNumerics (stringer); break;

                            case 71: exoplanet.Star.Properties.Distance = ReplaceNonNumerics (stringer); break;
                            case 72: exoplanet.Star.Properties.Metallicity = ReplaceNonNumerics (stringer); break;
                            case 73: exoplanet.Star.Properties.Mass = ReplaceNonNumerics (stringer); break;
                            case 74: exoplanet.Star.Properties.Radius = ReplaceNonNumerics (stringer); break;
                            case 75: exoplanet.Star.Properties.SPType = ReplaceNonNumerics (stringer); break;
                            case 76: exoplanet.Star.Properties.Age = stringer; break;
                            case 77: exoplanet.Star.Properties.Teff = ReplaceNonNumerics (stringer); break;
                            case 78: exoplanet.Star.Properties.DetectedDisc = stringer; break;
                            case 79: exoplanet.Star.Properties.MagneticField = stringer; break;
                            }
                        }

                    if (column == 79)
                        done = true;
                    else
                        ++column;
                    }
                }

            WriteXML.WriteExoplanet (writer, exoplanet, Version);

            return 0;
            }

        static private string ReplaceNonNumerics (string originalString)
            {
            if (originalString == "inf")
                return "";
            else if (originalString == "nan")
                return "";
            else
                return originalString;
            }

        }
    }
