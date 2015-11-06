using System.IO;
using System.Xml;

namespace ExoplanetLibrary
    {
    public class ReadVOT
        {
        public ReadVOT ()
            {
            }

        static private string Version_ = Constant.Version2;
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

                if (string.Equals (Version, Constant.Version1) || string.Equals (Version, Constant.Version2))
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
            Exoplanet exoplanet = new Exoplanet ();
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

                            case 2: exoplanet.Mass = Helper.ReplaceNonNumerics (stringer); break;
                            case 3: exoplanet.MassErrorMin = Helper.ReplaceNonNumerics (stringer); break;
                            case 4: exoplanet.MassErrorMax = Helper.ReplaceNonNumerics (stringer); break;

                            case 5: exoplanet.Radius = Helper.ReplaceNonNumerics (stringer); break;
                            case 6: exoplanet.RadiusErrorMin = Helper.ReplaceNonNumerics (stringer); break;
                            case 7: exoplanet.RadiusErrorMax = Helper.ReplaceNonNumerics (stringer); break;

                            case 8: exoplanet.OrbitalPeriod = Helper.ReplaceNonNumerics (stringer); break;
                            case 9: exoplanet.OrbitalPeriodErrorMin = Helper.ReplaceNonNumerics (stringer); break;
                            case 10: exoplanet.OrbitalPeriodErrorMax = Helper.ReplaceNonNumerics (stringer); break;

                            case 11: exoplanet.SemiMajorAxis = Helper.ReplaceNonNumerics (stringer); break;
                            case 12: exoplanet.SemiMajorAxisErrorMin = Helper.ReplaceNonNumerics (stringer); break;
                            case 13: exoplanet.SemiMajorAxisErrorMax = Helper.ReplaceNonNumerics (stringer); break;

                            case 14: exoplanet.Eccentricity = Helper.ReplaceNonNumerics (stringer); break;
                            case 15: exoplanet.EccentricityErrorMin = Helper.ReplaceNonNumerics (stringer); break;
                            case 16: exoplanet.EccentricityErrorMax = Helper.ReplaceNonNumerics (stringer); break;

                            case 17: exoplanet.Inclination = Helper.ReplaceNonNumerics (stringer); break;
                            case 18: exoplanet.InclinationErrorMin = Helper.ReplaceNonNumerics (stringer); break;
                            case 19: exoplanet.InclinationErrorMax = Helper.ReplaceNonNumerics (stringer); break;

                            case 20: exoplanet.AngularDistance = Helper.ReplaceNonNumerics (stringer); break;

                            case 21: exoplanet.Discovered = stringer; break;

                            case 22: exoplanet.Updated = stringer; break;

                            case 23: exoplanet.Omega = Helper.ReplaceNonNumerics (stringer); break;
                            case 24: exoplanet.OmegaErrorMin = Helper.ReplaceNonNumerics (stringer); break;
                            case 25: exoplanet.OmegaErrorMax = Helper.ReplaceNonNumerics (stringer); break;

                            case 26: exoplanet.Tperi = Helper.ReplaceNonNumerics (stringer); break;
                            case 27: exoplanet.TperiErrorMin = Helper.ReplaceNonNumerics (stringer); break;
                            case 28: exoplanet.TperiErrorMax = Helper.ReplaceNonNumerics (stringer); break;

                            case 29: exoplanet.Tconj = Helper.ReplaceNonNumerics (stringer); break;
                            case 30: exoplanet.TconjErrorMin = Helper.ReplaceNonNumerics (stringer); break;
                            case 31: exoplanet.TconjErrorMax = Helper.ReplaceNonNumerics (stringer); break;

                            case 32: exoplanet.TzeroTr = Helper.ReplaceNonNumerics (stringer); break;
                            case 33: exoplanet.TzeroTrErrorMin = Helper.ReplaceNonNumerics (stringer); break;
                            case 34: exoplanet.TzeroTrErrorMax = Helper.ReplaceNonNumerics (stringer); break;

                            case 35: exoplanet.TzeroTrSec = Helper.ReplaceNonNumerics (stringer); break;
                            case 36: exoplanet.TzeroTrSecErrorMin = Helper.ReplaceNonNumerics (stringer); break;
                            case 37: exoplanet.TzeroTrSecErrorMax = Helper.ReplaceNonNumerics (stringer); break;

                            case 38: exoplanet.LambdaAngle = Helper.ReplaceNonNumerics (stringer); break;
                            case 39: exoplanet.LambdaAngleErrorMin = Helper.ReplaceNonNumerics (stringer); break;
                            case 40: exoplanet.LambdaAngleErrorMax = Helper.ReplaceNonNumerics (stringer); break;

                            case 41: exoplanet.ImpactParameter = Helper.ReplaceNonNumerics (stringer); break;
                            case 42: exoplanet.ImpactParameterErrorMin = Helper.ReplaceNonNumerics (stringer); break;
                            case 43: exoplanet.ImpactParameterErrorMax = Helper.ReplaceNonNumerics (stringer); break;

                            case 44: exoplanet.TzeroVr = Helper.ReplaceNonNumerics (stringer); break;
                            case 45: exoplanet.TzeroVrErrorMin = Helper.ReplaceNonNumerics (stringer); break;
                            case 46: exoplanet.TzeroVrErrorMax = Helper.ReplaceNonNumerics (stringer); break;

                            case 47: exoplanet.K = Helper.ReplaceNonNumerics (stringer); break;
                            case 48: exoplanet.KErrorMin = Helper.ReplaceNonNumerics (stringer); break;
                            case 49: exoplanet.KErrorMax = Helper.ReplaceNonNumerics (stringer); break;

                            case 50: exoplanet.TemperatureMeasured = Helper.ReplaceNonNumerics (stringer); break;

                            case 51: exoplanet.TemperatureCalculated = Helper.ReplaceNonNumerics (stringer); break;

                            case 52: exoplanet.TemperatureHotPointLo = Helper.ReplaceNonNumerics (stringer); break;

                            case 53: exoplanet.GeometricAlbedo = Helper.ReplaceNonNumerics (stringer); break;
                            case 54: exoplanet.GeometricAlbedoErrorMin = Helper.ReplaceNonNumerics (stringer); break;
                            case 55: exoplanet.GeometricAlbedoErrorMax = Helper.ReplaceNonNumerics (stringer); break;

                            case 56: exoplanet.LogG = Helper.ReplaceNonNumerics (stringer); break;

                            case 57: exoplanet.Status = stringer; break;

                            case 58: exoplanet.DetectionType = stringer; break;

                            case 59: exoplanet.MassDetectionType = stringer; break;

                            case 60: exoplanet.RadiusDetectionType = stringer; break;

                            case 61: exoplanet.AlternateNames = stringer; break;

                            case 62: exoplanet.Molecules = stringer; break;

                            case 63: exoplanet.Star.Name = stringer; break;

                            case 64: exoplanet.Star.RightAccession = Helper.ReplaceNonNumerics (stringer); break;

                            case 65: exoplanet.Star.Declination = Helper.ReplaceNonNumerics (stringer); break;

                            case 66: exoplanet.Star.Magnitude.V = Helper.ReplaceNonNumerics (stringer); break;
                            case 67: exoplanet.Star.Magnitude.I = Helper.ReplaceNonNumerics (stringer); break;
                            case 68: exoplanet.Star.Magnitude.J = Helper.ReplaceNonNumerics (stringer); break;
                            case 69: exoplanet.Star.Magnitude.H = Helper.ReplaceNonNumerics (stringer); break;
                            case 70: exoplanet.Star.Magnitude.K = Helper.ReplaceNonNumerics (stringer); break;

                            case 71: exoplanet.Star.Property.Distance = Helper.ReplaceNonNumerics (stringer); break;
                            case 72: exoplanet.Star.Property.Metallicity = Helper.ReplaceNonNumerics (stringer); break;
                            case 73: exoplanet.Star.Property.Mass = Helper.ReplaceNonNumerics (stringer); break;
                            case 74: exoplanet.Star.Property.Radius = Helper.ReplaceNonNumerics (stringer); break;
                            case 75: exoplanet.Star.Property.SPType = Helper.ReplaceNonNumerics (stringer); break;
                            case 76: exoplanet.Star.Property.Age = stringer; break;
                            case 77: exoplanet.Star.Property.Teff = Helper.ReplaceNonNumerics (stringer); break;
                            case 78: exoplanet.Star.Property.DetectedDisc = stringer; break;
                            case 79: exoplanet.Star.Property.MagneticField = stringer; break;
                            }
                        }

                    if (column == Constant.Version2StringCount)
                        done = true;
                    else
                        ++column;
                    }
                }

            WriteXML.WriteExoplanet (writer, exoplanet, Version);

            return 0;
            }

        }
    }
