using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Windows.Forms;
using System.Collections;

namespace ExoplanetLibrary
    {
    public class ReadXML
        {
        public ReadXML ()
            {
            }

        static private XmlReader Reader_ = null;
        static private XmlReader Reader
            {
            get { return Reader_; }
            set { Reader_ = value; }
            }

        static private string Version_ = Constant.Version2;
        static private string Version
            {
            get { return Version_; }
            set { Version_ = value; }
            }

        static private string XsdVersion1FileName_ = Constant.SchemaFolder + "EXOPLANET.V.1.xsd";
        static private string XsdVersion1FileName
            {
            get { return XsdVersion1FileName_; }
            set { XsdVersion1FileName_ = value; }
            }

        static private string XsdVersion2FileName_ = Constant.SchemaFolder + "EXOPLANET.xsd";
        static private string XsdVersion2FileName
            {
            get { return XsdVersion2FileName_; }
            set { XsdVersion2FileName_ = value; }
            }

        static private string ValidationErrors_ = "";
        static private string ValidationErrors
            {
            get { return ValidationErrors_; }
            set { ValidationErrors_ = value; }
            }

        static private void SetVersion (string xmlFileName)
            {
            if (File.Exists (xmlFileName))
                {
                Reader = XmlReader.Create (xmlFileName);
                Reader.ReadToFollowing ("Exoplanets");
                Reader.MoveToFirstAttribute ();
                Version = Reader.Value;
                Reader.Close ();
                }
            }

        static private void SetValidation (FileStream fileStream, XmlReaderSettings settings, bool skipValidation)
            {
            ValidationEventHandler validationEventHandler = new ValidationEventHandler (exoplanetSettingsValidationEventHandler);
            XmlSchema xmlSchema = null;

            if (skipValidation == false)
                if (File.Exists (@XsdVersion2FileName) || File.Exists (@XsdVersion1FileName))
                    if (string.Equals (Version, Constant.Version2))
                        xmlSchema = XmlSchema.Read (( fileStream = File.Open (@XsdVersion2FileName, FileMode.Open) ), validationEventHandler);
                    else if (string.Equals (Version, Constant.Version1))
                        xmlSchema = XmlSchema.Read (( fileStream = File.Open (@XsdVersion1FileName, FileMode.Open) ), validationEventHandler);

            settings.ConformanceLevel = ConformanceLevel.Document;
            settings.CheckCharacters = true;
            settings.IgnoreComments = true;
            settings.IgnoreWhitespace = true;
            settings.DtdProcessing = DtdProcessing.Ignore;

            if (xmlSchema != null)
                {
                settings.ValidationType = ValidationType.Schema;
                settings.ValidationFlags = XmlSchemaValidationFlags.ProcessInlineSchema;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
                settings.Schemas.Add (xmlSchema);
                settings.ValidationEventHandler += new ValidationEventHandler (exoplanetSettingsValidationEventHandler);
                }
            else
                settings.ValidationType = ValidationType.None;
            }

        static public int Read (string xmlFileName, ref ArrayList exoplanets, bool skipValidation = false)
            {
            ValidationErrors = "";

            exoplanets = new ArrayList ();

            if (File.Exists (xmlFileName))
                {
                FileStream fileStream = null;
                XmlReaderSettings settings = new XmlReaderSettings ();

                SetVersion (xmlFileName);
                SetValidation (fileStream, settings, skipValidation);

                Reader = XmlReader.Create (xmlFileName, settings);

                while (Reader.Read ())
                    {
                    Exoplanet exoplanet = new Exoplanet ();

                    ReadExoplanet (exoplanet);
                    ReadMass (exoplanet);
                    ReadRadius (exoplanet);
                    ReadOrbitalPeriod (exoplanet);
                    ReadSemiMajorAxis (exoplanet);
                    ReadEccentricity (exoplanet);
                    ReadAngularDistance (exoplanet);
                    ReadInclination (exoplanet);
                    ReadTzeroTr (exoplanet);
                    ReadTzeroTrSec (exoplanet);
                    ReadLambdaAngle (exoplanet);
                    ReadTzeroVr (exoplanet);
                    ReadTemperature (exoplanet);
                    ReadLogG (exoplanet);
                    ReadPublicationStatus (exoplanet);
                    ReadDiscovered (exoplanet);
                    ReadUpdated (exoplanet);
                    ReadOmega (exoplanet);
                    ReadTperi (exoplanet);
                    ReadDetectionType (exoplanet);
                    ReadMolecules (exoplanet);

                    if (string.Equals (Version, Constant.Version2))
                        {
                        ReadImpactParameter (exoplanet);
                        ReadK (exoplanet);
                        ReadGeometricAlbedo (exoplanet);
                        ReadTconj (exoplanet);
                        ReadMassDetectionType (exoplanet);
                        ReadRadiusDetectionType (exoplanet);
                        ReadAlternateNames (exoplanet);
                        }

                    ReadStar (exoplanet);
                    ReadMagnitudes (exoplanet);
                    ReadProperties (exoplanet);

                    if (!string.IsNullOrEmpty (exoplanet.Name))
                        exoplanets.Add (( object )exoplanet);
                    }

                if (fileStream != null)
                    fileStream.Close ();

                Reader.Close ();
                }

            if (ValidationErrors.Length > 0)
                MessageBox.Show (ValidationErrors);

            return 0;
            }

        static void ReadExoplanet (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("Exoplanet");

            Reader.MoveToFirstAttribute ();
            exoplanet.Name = Reader.Value;
            }

        static void ReadMass (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("Mass");

            while (Reader.MoveToNextAttribute ())
                {
                switch (Reader.Name)
                    {
                    case "mass":
                        exoplanet.Mass = Reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.MassErrorMin = Reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.MassErrorMax = Reader.Value;
                        break;
                    }
                }
            }

        static void ReadRadius (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("Radius");

            while (Reader.MoveToNextAttribute ())
                {
                switch (Reader.Name)
                    {
                    case "radius":
                        exoplanet.Radius = Reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.RadiusErrorMin = Reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.RadiusErrorMax = Reader.Value;
                        break;
                    }
                }
            }

        static void ReadOrbitalPeriod (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("OrbitalPeriod");

            while (Reader.MoveToNextAttribute ())
                {
                switch (Reader.Name)
                    {
                    case "orbitalPeriod":
                        exoplanet.OrbitalPeriod = Reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.OrbitalPeriodErrorMin = Reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.OrbitalPeriodErrorMax = Reader.Value;
                        break;
                    }
                }
            }

        static void ReadSemiMajorAxis (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("SemiMajorAxis");

            while (Reader.MoveToNextAttribute ())
                {
                switch (Reader.Name)
                    {
                    case "semiMajorAxis":
                        exoplanet.SemiMajorAxis = Reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.SemiMajorAxisErrorMin = Reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.SemiMajorAxisErrorMax = Reader.Value;
                        break;
                    }
                }
            }

        static void ReadEccentricity (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("Eccentricity");

            while (Reader.MoveToNextAttribute ())
                {
                switch (Reader.Name)
                    {
                    case "eccentricity":
                        exoplanet.Eccentricity = Reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.EccentricityErrorMin = Reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.EccentricityErrorMax = Reader.Value;
                        break;
                    }
                }
            }

        static void ReadAngularDistance (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("AngularDistance");
            Reader.MoveToFirstAttribute ();
            exoplanet.AngularDistance = Reader.Value;
            }

        static void ReadInclination (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("Inclination");

            while (Reader.MoveToNextAttribute ())
                {
                switch (Reader.Name)
                    {
                    case "inclination":
                        exoplanet.Inclination = Reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.InclinationErrorMin = Reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.InclinationErrorMax = Reader.Value;
                        break;
                    }
                }
            }

        static void ReadTzeroTr (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("TzeroTr");

            while (Reader.MoveToNextAttribute ())
                {
                switch (Reader.Name)
                    {
                    case "tzero_tr":
                        exoplanet.TzeroTr = Reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.TzeroTrErrorMin = Reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.TzeroTrErrorMax = Reader.Value;
                        break;
                    }
                }
            }

        static void ReadTzeroTrSec (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("TzeroTrSec");

            while (Reader.MoveToNextAttribute ())
                {
                switch (Reader.Name)
                    {
                    case "tzero_trSec":
                        exoplanet.TzeroTrSec = Reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.TzeroTrSecErrorMin = Reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.TzeroTrSecErrorMax = Reader.Value;
                        break;
                    }
                }
            }

        static void ReadLambdaAngle (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("LambdaAngle");

            while (Reader.MoveToNextAttribute ())
                {
                switch (Reader.Name)
                    {
                    case "lambdaAngle":
                        exoplanet.LambdaAngle = Reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.LambdaAngleErrorMin = Reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.LambdaAngleErrorMax = Reader.Value;
                        break;
                    }
                }
            }

        static void ReadTzeroVr (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("TzeroVr");

            while (Reader.MoveToNextAttribute ())
                {
                switch (Reader.Name)
                    {
                    case "tzero_vr":
                        exoplanet.TzeroVr = Reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.TzeroVrErrorMin = Reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.TzeroVrErrorMax = Reader.Value;
                        break;
                    }
                }
            }

        static void ReadTemperature (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("Temperature");

            while (Reader.MoveToNextAttribute ())
                {
                switch (Reader.Name)
                    {
                    case "Calculated":
                        exoplanet.TemperatureCalculated = Reader.Value;
                        break;
                    case "Measured":
                        exoplanet.TemperatureMeasured = Reader.Value;
                        break;
                    case "HotPointLon":
                        exoplanet.TemperatureHotPointLo = Reader.Value;
                        break;
                    }
                }
            }

        static void ReadLogG (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("LogG");
            Reader.MoveToFirstAttribute ();
            exoplanet.LogG = Reader.Value;
            }

        static void ReadPublicationStatus (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("PublicationStatus");
            Reader.MoveToFirstAttribute ();
            exoplanet.Status = Reader.Value;
            }

        static void ReadDiscovered (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("Discovered");
            Reader.MoveToFirstAttribute ();
            exoplanet.Discovered = Reader.Value;
            }

        static void ReadUpdated (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("Updated");
            Reader.MoveToFirstAttribute ();
            exoplanet.Updated = Reader.Value;
            }

        static void ReadOmega (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("Omega");

            while (Reader.MoveToNextAttribute ())
                {
                switch (Reader.Name)
                    {
                    case "Omega":
                        exoplanet.Omega = Reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.OmegaErrorMin = Reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.OmegaErrorMax = Reader.Value;
                        break;
                    }
                }
            }

        static void ReadTperi (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("Tperi");

            while (Reader.MoveToNextAttribute ())
                {
                switch (Reader.Name)
                    {
                    case "tperi":
                        exoplanet.Tperi = Reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.TperiErrorMin = Reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.TperiErrorMax = Reader.Value;
                        break;
                    }
                }
            }

        static void ReadDetectionType (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("DetectionType");
            Reader.MoveToFirstAttribute ();
            exoplanet.DetectionType = Reader.Value;
            }

        static void ReadMolecules (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("Molecules");
            Reader.MoveToFirstAttribute ();
            exoplanet.Molecules = Reader.Value;
            }

        static void ReadImpactParameter (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("ImpactParameter");

            while (Reader.MoveToNextAttribute ())
                {
                switch (Reader.Name)
                    {
                    case "impactParameter":
                        exoplanet.ImpactParameter = Reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.ImpactParameterErrorMin = Reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.ImpactParameterErrorMax = Reader.Value;
                        break;
                    }
                }
            }

        static void ReadK (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("K");

            while (Reader.MoveToNextAttribute ())
                {
                switch (Reader.Name)
                    {
                    case "k":
                        exoplanet.K = Reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.KErrorMin = Reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.KErrorMax = Reader.Value;
                        break;
                    }
                }
            }

        static void ReadGeometricAlbedo (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("GeometricAlbedo");

            while (Reader.MoveToNextAttribute ())
                {
                switch (Reader.Name)
                    {
                    case "geometricAlbedo":
                        exoplanet.GeometricAlbedo = Reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.GeometricAlbedoErrorMin = Reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.GeometricAlbedoErrorMax = Reader.Value;
                        break;
                    }
                }
            }

        static void ReadTconj (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("Tconj");

            while (Reader.MoveToNextAttribute ())
                {
                switch (Reader.Name)
                    {
                    case "tconj":
                        exoplanet.Tconj = Reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.TconjErrorMin = Reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.TconjErrorMax = Reader.Value;
                        break;
                    }
                }
            }

        static void ReadMassDetectionType (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("MassDetectionType");
            Reader.MoveToFirstAttribute ();
            exoplanet.MassDetectionType = Reader.Value;
            }

        static void ReadRadiusDetectionType (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("RadiusDetectionType");
            Reader.MoveToFirstAttribute ();
            exoplanet.RadiusDetectionType = Reader.Value;
            }

        static void ReadAlternateNames (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("AlternateNames");
            Reader.MoveToFirstAttribute ();
            exoplanet.AlternateNames = Reader.Value;
            }

        static void ReadStar (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("Star");

            while (Reader.MoveToNextAttribute ())
                {
                switch (Reader.Name)
                    {
                    case "Name":
                        exoplanet.Star.Name = Reader.Value;
                        break;
                    case "ra":
                        exoplanet.Star.RightAccession = Reader.Value;
                        break;
                    case "dec":
                        exoplanet.Star.Declination = Reader.Value;
                        break;
                    }
                }
            }

        static void ReadMagnitudes (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("Magnitude");

            while (Reader.MoveToNextAttribute ())
                {
                switch (Reader.Name)
                    {
                    case "V":
                        exoplanet.Star.Magnitude.V = Reader.Value;
                        break;
                    case "I":
                        exoplanet.Star.Magnitude.I = Reader.Value;
                        break;
                    case "J":
                        exoplanet.Star.Magnitude.J = Reader.Value;
                        break;
                    case "H":
                        exoplanet.Star.Magnitude.H = Reader.Value;
                        break;
                    case "K":
                        exoplanet.Star.Magnitude.K = Reader.Value;
                        break;
                    }
                }
            }

        static void ReadProperties (Exoplanet exoplanet)
            {
            Reader.ReadToFollowing ("Property");

            while (Reader.MoveToNextAttribute ())
                {
                switch (Reader.Name)
                    {
                    case "Distance":
                        exoplanet.Star.Property.Distance = Reader.Value;
                        break;
                    case "Metallicity":
                        exoplanet.Star.Property.Metallicity = Reader.Value;
                        break;
                    case "Mass":
                        exoplanet.Star.Property.Mass = Reader.Value;
                        break;
                    case "Radius":
                        exoplanet.Star.Property.Radius = Reader.Value;
                        break;
                    case "SPType":
                        exoplanet.Star.Property.SPType = Reader.Value;
                        break;
                    case "Age":
                        exoplanet.Star.Property.Age = Reader.Value;
                        break;
                    case "Teff":
                        exoplanet.Star.Property.Teff = Reader.Value;
                        break;
                    case "DetectedDisc":
                        exoplanet.Star.Property.DetectedDisc = Reader.Value;
                        break;
                    case "MagneticField":
                        exoplanet.Star.Property.MagneticField = Reader.Value;
                        break;
                    }
                }
            }

        static void exoplanetSettingsValidationEventHandler (object sender, ValidationEventArgs e)
            {
            if (e.Severity == XmlSeverityType.Warning)
                {
                ValidationErrors_ += "WARNING: " + "\r";
                ValidationErrors_ += e.Message + "\r";
                }
            else if (e.Severity == XmlSeverityType.Error)
                {
                ValidationErrors += "ERROR: " + "\r";
                ValidationErrors += e.Message + "\r";
                }
            }

        }
    }
