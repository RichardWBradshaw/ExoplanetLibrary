using System;
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

                IsValidVersion (csvFileName);

                if (string.Equals (Version, Constant.Version1) || string.Equals (Version, Constant.Version2))
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

        static private string IsValidVersion (string csvFileName)
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
                        Version = Constant.Version2;
                    }
                }

            reader.Close ();

            return Version;
            }

        static private int WriteExoplanet (XmlWriter writer, string line)
            {
            if (line.StartsWith ("#") || line.StartsWith ("rowid"))
                return 0;

            char [] delimiterChars = { ',', '\t' };
            string [] strings = line.Split (delimiterChars);
            int numberOfStrings = strings.Length;

            if (string.Equals (Version, Constant.Version1))
                {
                if (numberOfStrings == Constant.Version1StringCount)
                    {
                    Exoplanet exoplanet = new Exoplanet ();

                    AssignFromVersion1 (strings, exoplanet);

                    WriteXML.WriteExoplanet (writer, exoplanet, Version);
                    }
                }
            else if (string.Equals (Version, Constant.Version2))
                {
                if (numberOfStrings == Constant.Version2StringCount)
                    {
                    Exoplanet exoplanet = new Exoplanet ();

                    AssignFromVersion2 (strings, exoplanet);

                    WriteXML.WriteExoplanet (writer, exoplanet, Version);
                    }
                }

            return 0;
            }

        static private void AssignFromVersion1 (string [] strings, Exoplanet exoplanet)
            {
            exoplanet.Name = strings [0].ToString ();

            exoplanet.Mass = Helper.ReplaceNonNumerics (strings [1].ToString ());
            exoplanet.MassErrorMin = Helper.ReplaceNonNumerics (strings [2].ToString ());
            exoplanet.MassErrorMax = Helper.ReplaceNonNumerics (strings [3].ToString ());

            exoplanet.Radius = Helper.ReplaceNonNumerics (strings [4].ToString ());
            exoplanet.RadiusErrorMin = Helper.ReplaceNonNumerics (strings [5].ToString ());
            exoplanet.RadiusErrorMax = Helper.ReplaceNonNumerics (strings [6].ToString ());

            exoplanet.OrbitalPeriod = Helper.ReplaceNonNumerics (strings [7].ToString ());
            exoplanet.OrbitalPeriodErrorMin = Helper.ReplaceNonNumerics (strings [8].ToString ());
            exoplanet.OrbitalPeriodErrorMax = Helper.ReplaceNonNumerics (strings [9].ToString ());

            exoplanet.SemiMajorAxis = Helper.ReplaceNonNumerics (strings [10].ToString ());
            exoplanet.SemiMajorAxisErrorMin = Helper.ReplaceNonNumerics (strings [11].ToString ());
            exoplanet.SemiMajorAxisErrorMax = Helper.ReplaceNonNumerics (strings [12].ToString ());

            exoplanet.Eccentricity = Helper.ReplaceNonNumerics (strings [13].ToString ());
            exoplanet.EccentricityErrorMin = Helper.ReplaceNonNumerics (strings [14].ToString ());
            exoplanet.EccentricityErrorMax = Helper.ReplaceNonNumerics (strings [15].ToString ());

            exoplanet.AngularDistance = Helper.ReplaceNonNumerics (strings [16].ToString ());

            exoplanet.Inclination = Helper.ReplaceNonNumerics (strings [17].ToString ());
            exoplanet.InclinationErrorMin = Helper.ReplaceNonNumerics (strings [18].ToString ());
            exoplanet.InclinationErrorMax = Helper.ReplaceNonNumerics (strings [19].ToString ());

            exoplanet.TzeroTr = Helper.ReplaceNonNumerics (strings [20].ToString ());
            exoplanet.TzeroTrErrorMin = Helper.ReplaceNonNumerics (strings [21].ToString ());
            exoplanet.TzeroTrErrorMax = Helper.ReplaceNonNumerics (strings [22].ToString ());

            exoplanet.TzeroTrSec = Helper.ReplaceNonNumerics (strings [23].ToString ());
            exoplanet.TzeroTrSecErrorMin = Helper.ReplaceNonNumerics (strings [24].ToString ());
            exoplanet.TzeroTrSecErrorMax = Helper.ReplaceNonNumerics (strings [25].ToString ());

            exoplanet.LambdaAngle = Helper.ReplaceNonNumerics (strings [26].ToString ());
            exoplanet.LambdaAngleErrorMin = Helper.ReplaceNonNumerics (strings [27].ToString ());
            exoplanet.LambdaAngleErrorMax = Helper.ReplaceNonNumerics (strings [28].ToString ());

            exoplanet.TzeroVr = Helper.ReplaceNonNumerics (strings [29].ToString ());
            exoplanet.TzeroVrErrorMin = Helper.ReplaceNonNumerics (strings [30].ToString ());
            exoplanet.TzeroVrErrorMax = Helper.ReplaceNonNumerics (strings [31].ToString ());

            exoplanet.TemperatureCalculated = Helper.ReplaceNonNumerics (strings [32].ToString ());
            exoplanet.TemperatureMeasured = Helper.ReplaceNonNumerics (strings [33].ToString ());
            exoplanet.TemperatureHotPointLo = Helper.ReplaceNonNumerics (strings [34].ToString ());

            exoplanet.LogG = Helper.ReplaceNonNumerics (strings [35].ToString ());

            exoplanet.Status = strings [36].ToString ();

            exoplanet.Discovered = strings [37].ToString ();

            exoplanet.Updated = strings [38].ToString ();

            exoplanet.Omega = Helper.ReplaceNonNumerics (strings [39].ToString ());
            exoplanet.OmegaErrorMin = Helper.ReplaceNonNumerics (strings [40].ToString ());
            exoplanet.OmegaErrorMax = Helper.ReplaceNonNumerics (strings [41].ToString ());

            exoplanet.Tperi = Helper.ReplaceNonNumerics (strings [42].ToString ());
            exoplanet.TperiErrorMin = Helper.ReplaceNonNumerics (strings [43].ToString ());
            exoplanet.TperiErrorMax = Helper.ReplaceNonNumerics (strings [44].ToString ());

            exoplanet.DetectionType = strings [45].ToString ();

            exoplanet.Molecules = strings [46].ToString ();

            exoplanet.Star.Name = strings [47].ToString ();
            exoplanet.Star.RightAccession = Helper.ReplaceNonNumerics (strings [48].ToString ());
            exoplanet.Star.Declination = Helper.ReplaceNonNumerics (strings [49].ToString ());

            exoplanet.Star.Magnitude.V = Helper.ReplaceNonNumerics (strings [50].ToString ());
            exoplanet.Star.Magnitude.I = Helper.ReplaceNonNumerics (strings [51].ToString ());
            exoplanet.Star.Magnitude.J = Helper.ReplaceNonNumerics (strings [52].ToString ());
            exoplanet.Star.Magnitude.H = Helper.ReplaceNonNumerics (strings [53].ToString ());
            exoplanet.Star.Magnitude.K = Helper.ReplaceNonNumerics (strings [54].ToString ());

            exoplanet.Star.Property.Distance = Helper.ReplaceNonNumerics (strings [55].ToString ());
            exoplanet.Star.Property.Metallicity = Helper.ReplaceNonNumerics (strings [56].ToString ());
            exoplanet.Star.Property.Mass = Helper.ReplaceNonNumerics (strings [57].ToString ());
            exoplanet.Star.Property.Radius = Helper.ReplaceNonNumerics (strings [58].ToString ());
            exoplanet.Star.Property.SPType = Helper.ReplaceNonNumerics (strings [59].ToString ());
            exoplanet.Star.Property.Age = Helper.ReplaceNonNumerics (strings [60].ToString ());
            exoplanet.Star.Property.Teff = Helper.ReplaceNonNumerics (strings [61].ToString ());
            }

        static private void AssignFromVersion2 (string [] strings, Exoplanet exoplanet)
            {
            exoplanet.Name = strings [0].ToString ();

            exoplanet.Mass = Helper.ReplaceNonNumerics (strings [1].ToString ());
            exoplanet.MassErrorMin = Helper.ReplaceNonNumerics (strings [2].ToString ());
            exoplanet.MassErrorMax = Helper.ReplaceNonNumerics (strings [3].ToString ());

            exoplanet.Radius = Helper.ReplaceNonNumerics (strings [4].ToString ());
            exoplanet.RadiusErrorMin = Helper.ReplaceNonNumerics (strings [5].ToString ());
            exoplanet.RadiusErrorMax = Helper.ReplaceNonNumerics (strings [6].ToString ());

            exoplanet.OrbitalPeriod = Helper.ReplaceNonNumerics (strings [7].ToString ());
            exoplanet.OrbitalPeriodErrorMin = Helper.ReplaceNonNumerics (strings [8].ToString ());
            exoplanet.OrbitalPeriodErrorMax = Helper.ReplaceNonNumerics (strings [9].ToString ());

            exoplanet.SemiMajorAxis = Helper.ReplaceNonNumerics (strings [10].ToString ());
            exoplanet.SemiMajorAxisErrorMin = Helper.ReplaceNonNumerics (strings [11].ToString ());
            exoplanet.SemiMajorAxisErrorMax = Helper.ReplaceNonNumerics (strings [12].ToString ());

            exoplanet.Eccentricity = Helper.ReplaceNonNumerics (strings [13].ToString ());
            exoplanet.EccentricityErrorMin = Helper.ReplaceNonNumerics (strings [14].ToString ());
            exoplanet.EccentricityErrorMax = Helper.ReplaceNonNumerics (strings [15].ToString ());

            exoplanet.Inclination = Helper.ReplaceNonNumerics (strings [16].ToString ());
            exoplanet.InclinationErrorMin = Helper.ReplaceNonNumerics (strings [17].ToString ());
            exoplanet.InclinationErrorMax = Helper.ReplaceNonNumerics (strings [18].ToString ());

            exoplanet.AngularDistance = Helper.ReplaceNonNumerics (strings [19].ToString ());

            exoplanet.Discovered = strings [20].ToString ();

            exoplanet.Updated = strings [21].ToString ();

            exoplanet.Omega = Helper.ReplaceNonNumerics (strings [22].ToString ());
            exoplanet.OmegaErrorMin = Helper.ReplaceNonNumerics (strings [23].ToString ());
            exoplanet.OmegaErrorMax = Helper.ReplaceNonNumerics (strings [24].ToString ());

            exoplanet.Tperi = Helper.ReplaceNonNumerics (strings [25].ToString ());
            exoplanet.TperiErrorMin = Helper.ReplaceNonNumerics (strings [26].ToString ());
            exoplanet.TperiErrorMax = Helper.ReplaceNonNumerics (strings [27].ToString ());

            exoplanet.Tconj = Helper.ReplaceNonNumerics (strings [28].ToString ());
            exoplanet.TconjErrorMin = Helper.ReplaceNonNumerics (strings [29].ToString ());
            exoplanet.TconjErrorMax = Helper.ReplaceNonNumerics (strings [30].ToString ());

            exoplanet.TzeroTr = Helper.ReplaceNonNumerics (strings [31].ToString ());
            exoplanet.TzeroTrErrorMin = Helper.ReplaceNonNumerics (strings [32].ToString ());
            exoplanet.TzeroTrErrorMax = Helper.ReplaceNonNumerics (strings [33].ToString ());

            exoplanet.TzeroTrSec = Helper.ReplaceNonNumerics (strings [34].ToString ());
            exoplanet.TzeroTrSecErrorMin = Helper.ReplaceNonNumerics (strings [35].ToString ());
            exoplanet.TzeroTrSecErrorMax = Helper.ReplaceNonNumerics (strings [36].ToString ());

            exoplanet.LambdaAngle = Helper.ReplaceNonNumerics (strings [37].ToString ());
            exoplanet.LambdaAngleErrorMin = Helper.ReplaceNonNumerics (strings [38].ToString ());
            exoplanet.LambdaAngleErrorMax = Helper.ReplaceNonNumerics (strings [39].ToString ());

            exoplanet.ImpactParameter = Helper.ReplaceNonNumerics (strings [40].ToString ());
            exoplanet.ImpactParameterErrorMin = Helper.ReplaceNonNumerics (strings [41].ToString ());
            exoplanet.ImpactParameterErrorMax = Helper.ReplaceNonNumerics (strings [42].ToString ());

            exoplanet.TzeroVr = Helper.ReplaceNonNumerics (strings [43].ToString ());
            exoplanet.TzeroVrErrorMin = Helper.ReplaceNonNumerics (strings [44].ToString ());
            exoplanet.TzeroVrErrorMax = Helper.ReplaceNonNumerics (strings [45].ToString ());

            exoplanet.K = Helper.ReplaceNonNumerics (strings [46].ToString ());
            exoplanet.KErrorMin = Helper.ReplaceNonNumerics (strings [47].ToString ());
            exoplanet.KErrorMax = Helper.ReplaceNonNumerics (strings [48].ToString ());

            exoplanet.TemperatureCalculated = Helper.ReplaceNonNumerics (strings [49].ToString ());
            exoplanet.TemperatureMeasured = Helper.ReplaceNonNumerics (strings [50].ToString ());
            exoplanet.TemperatureHotPointLo = Helper.ReplaceNonNumerics (strings [51].ToString ());

            exoplanet.GeometricAlbedo = Helper.ReplaceNonNumerics (strings [52].ToString ());
            exoplanet.GeometricAlbedoErrorMin = Helper.ReplaceNonNumerics (strings [53].ToString ());
            exoplanet.GeometricAlbedoErrorMax = Helper.ReplaceNonNumerics (strings [54].ToString ());

            exoplanet.LogG = Helper.ReplaceNonNumerics (strings [55].ToString ());
            exoplanet.Status = strings [56].ToString ();
            exoplanet.DetectionType = strings [57].ToString ();

            exoplanet.MassDetectionType = strings [58].ToString ();

            exoplanet.RadiusDetectionType = strings [59].ToString ();

            exoplanet.AlternateNames = strings [60].ToString ();

            exoplanet.Molecules = strings [61].ToString ();

            exoplanet.Star.Name = strings [62].ToString ();
            exoplanet.Star.RightAccession = Helper.ReplaceNonNumerics (strings [63].ToString ());
            exoplanet.Star.Declination = Helper.ReplaceNonNumerics (strings [64].ToString ());

            exoplanet.Star.Magnitude.V = Helper.ReplaceNonNumerics (strings [65].ToString ());
            exoplanet.Star.Magnitude.I = Helper.ReplaceNonNumerics (strings [66].ToString ());
            exoplanet.Star.Magnitude.J = Helper.ReplaceNonNumerics (strings [67].ToString ());
            exoplanet.Star.Magnitude.H = Helper.ReplaceNonNumerics (strings [68].ToString ());
            exoplanet.Star.Magnitude.K = Helper.ReplaceNonNumerics (strings [69].ToString ());

            exoplanet.Star.Property.Distance = Helper.ReplaceNonNumerics (strings [70].ToString ());
            exoplanet.Star.Property.Metallicity = Helper.ReplaceNonNumerics (strings [71].ToString ());
            exoplanet.Star.Property.Mass = Helper.ReplaceNonNumerics (strings [72].ToString ());
            exoplanet.Star.Property.Radius = Helper.ReplaceNonNumerics (strings [73].ToString ());
            exoplanet.Star.Property.SPType = strings [74].ToString ();
            exoplanet.Star.Property.Age = Helper.ReplaceNonNumerics (strings [75].ToString ());
            exoplanet.Star.Property.Teff = Helper.ReplaceNonNumerics (strings [76].ToString ());
            exoplanet.Star.Property.DetectedDisc = strings [77].ToString ();
            exoplanet.Star.Property.MagneticField = strings [78].ToString ();
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

                IsValidVersion (csvFileName);

                if (string.Equals (Version, Constant.Version1) || string.Equals (Version, Constant.Version2))
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

