using System.Xml;
using System.Collections;

namespace ExoplanetLibrary
    {
    public class WriteXML
        {
        public WriteXML ()
            {
            }

        static private XmlWriter Writer_ = null;
        static private XmlWriter Writer
            {
            get { return Writer_; }
            set { Writer_ = value; }
            }

        static private string Version_ = "";
        static private string Version
            {
            get { return Version_; }
            set { Version_ = value; }
            }

        static public void WriteExoplanets (string xmlFileName, ArrayList array)
            {
            XmlWriterSettings settings = null;

            settings = new XmlWriterSettings ();

            settings.IndentChars = "\t";
            settings.NewLineHandling = NewLineHandling.Entitize;
            settings.Indent = true;
            settings.NewLineChars = "\n";

            Version = Constant.LastestVersion;

            using (Writer = XmlWriter.Create (xmlFileName, settings))
                {
                Writer.WriteStartElement ("Exoplanets");
                Writer.WriteAttributeString ("version", Version);

                foreach (Exoplanet exoplanet in array)
                    WriteExoplanet (exoplanet);

                Writer.WriteEndElement ();
                Writer.Close ();
                }
            }

        static public int WriteExoplanet (XmlWriter writer, Exoplanet exoplanet, string version)
            {
            Writer = writer;
            Version = version;

            exoplanet.CorrectErrors (false);

            WriteExoplanet (exoplanet);

            return 0;
            }

        static private void WriteExoplanet (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Exoplanet");

            Writer.WriteAttributeString ("name", exoplanet.Name.Trim ());

            WriteMass (exoplanet);
            WriteMassSini (exoplanet);
            WriteRadius (exoplanet);
            WriteOrbitalPeriod (exoplanet);
            WriteSemiMajorAxis (exoplanet);
            WriteEccentricity (exoplanet);
            WriteAngularDistance (exoplanet);
            WriteInclination (exoplanet);
            WriteTzeroTr (exoplanet);
            WriteTzeroTrSec (exoplanet);
            WriteLambdaAngle (exoplanet);
            WriteTzeroVr (exoplanet);
            WriteTemperatures (exoplanet);
            WriteLogG (exoplanet);
            WritePublicationStatus (exoplanet);
            WriteDiscovered (exoplanet);
            WriteUpdated (exoplanet);
            WriteOmega (exoplanet);
            WriteTperi (exoplanet);
            WriteDetectionType (exoplanet);
            WriteMolecules (exoplanet);

            WriteImpactParameter (exoplanet);
            WriteVelocitySemiamplitude (exoplanet);
            WriteGeometricAlbedo (exoplanet);
            WriteTconj (exoplanet);
            WriteMassDetectionType (exoplanet);
            WriteRadiusDetectionType (exoplanet);
            WriteAlternateNames (exoplanet);

            WriteStar (exoplanet);

            Writer.WriteEndElement ();
            }

        static private void WriteMass (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Mass");

            if (IsDefined (exoplanet.Mass))
                Writer.WriteAttributeString ("value", exoplanet.Mass);

            if (IsDefined (exoplanet.MassErrorMin))
                Writer.WriteAttributeString ("errorMin", exoplanet.MassErrorMin);

            if (IsDefined (exoplanet.MassErrorMax))
                Writer.WriteAttributeString ("errorMax", exoplanet.MassErrorMax);

            Writer.WriteEndElement ();
            }

        static private void WriteMassSini (Exoplanet exoplanet)
            {
            if (string.Equals (Version, Constant.Version2) || string.Equals (Version, Constant.Version3))
                {
                Writer.WriteStartElement ("MassSini");

                if (IsDefined (exoplanet.MassSini))
                    Writer.WriteAttributeString ("value", exoplanet.MassSini);

                if (IsDefined (exoplanet.MassSiniErrorMin))
                    Writer.WriteAttributeString ("errorMin", exoplanet.MassSiniErrorMin);

                if (IsDefined (exoplanet.MassSiniErrorMax))
                    Writer.WriteAttributeString ("errorMax", exoplanet.MassSiniErrorMax);

                Writer.WriteEndElement ();
                }
            }

        static private void WriteRadius (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Radius");

            if (IsDefined (exoplanet.Radius))
                Writer.WriteAttributeString ("value", exoplanet.Radius);

            if (IsDefined (exoplanet.RadiusErrorMin))
                Writer.WriteAttributeString ("errorMin", exoplanet.RadiusErrorMin);

            if (IsDefined (exoplanet.RadiusErrorMax))
                Writer.WriteAttributeString ("errorMax", exoplanet.RadiusErrorMax);

            Writer.WriteEndElement ();
            }

        static private void WriteOrbitalPeriod (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("OrbitalPeriod");

            if (IsDefined (exoplanet.OrbitalPeriod))
                Writer.WriteAttributeString ("value", exoplanet.OrbitalPeriod);

            if (IsDefined (exoplanet.OrbitalPeriodErrorMin))
                Writer.WriteAttributeString ("errorMin", exoplanet.OrbitalPeriodErrorMin);

            if (IsDefined (exoplanet.OrbitalPeriodErrorMax))
                Writer.WriteAttributeString ("errorMax", exoplanet.OrbitalPeriodErrorMax);

            Writer.WriteEndElement ();
            }

        static private void WriteSemiMajorAxis (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("SemiMajorAxis");

            if (IsDefined (exoplanet.SemiMajorAxis))
                Writer.WriteAttributeString ("value", exoplanet.SemiMajorAxis);

            if (IsDefined (exoplanet.SemiMajorAxisErrorMin))
                Writer.WriteAttributeString ("errorMin", exoplanet.SemiMajorAxisErrorMin);

            if (IsDefined (exoplanet.SemiMajorAxisErrorMax))
                Writer.WriteAttributeString ("errorMax", exoplanet.SemiMajorAxisErrorMax);

            Writer.WriteEndElement ();
            }

        static private void WriteEccentricity (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Eccentricity");

            if (IsDefined (exoplanet.Eccentricity))
                Writer.WriteAttributeString ("value", exoplanet.Eccentricity);

            if (IsDefined (exoplanet.EccentricityErrorMin))
                Writer.WriteAttributeString ("errorMin", exoplanet.EccentricityErrorMin);

            if (IsDefined (exoplanet.EccentricityErrorMax))
                Writer.WriteAttributeString ("errorMax", exoplanet.EccentricityErrorMax);

            Writer.WriteEndElement ();
            }

        static private void WriteAngularDistance (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("AngularDistance");

            if (IsDefined (exoplanet.AngularDistance))
                Writer.WriteAttributeString ("value", exoplanet.AngularDistance);

            Writer.WriteEndElement ();
            }

        static private void WriteInclination (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Inclination");

            if (IsDefined (exoplanet.Inclination))
                Writer.WriteAttributeString ("value", exoplanet.Inclination);

            if (IsDefined (exoplanet.InclinationErrorMin))
                Writer.WriteAttributeString ("errorMin", exoplanet.InclinationErrorMin);

            if (IsDefined (exoplanet.InclinationErrorMax))
                Writer.WriteAttributeString ("errorMax", exoplanet.InclinationErrorMax);

            Writer.WriteEndElement ();
            }

        static private void WriteTzeroTr (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("TzeroTr");

            if (IsDefined (exoplanet.TzeroTr))
                Writer.WriteAttributeString ("value", exoplanet.TzeroTr);

            if (IsDefined (exoplanet.TzeroTrErrorMin))
                Writer.WriteAttributeString ("errorMin", exoplanet.TzeroTrErrorMin);

            if (IsDefined (exoplanet.TzeroTrErrorMax))
                Writer.WriteAttributeString ("errorMax", exoplanet.TzeroTrErrorMax);

            Writer.WriteEndElement ();
            }

        static private void WriteTzeroTrSec (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("TzeroTrSec");

            if (IsDefined (exoplanet.TzeroTrSec))
                Writer.WriteAttributeString ("value", exoplanet.TzeroTrSec);

            if (IsDefined (exoplanet.TzeroTrSecErrorMin))
                Writer.WriteAttributeString ("errorMin", exoplanet.TzeroTrSecErrorMin);

            if (IsDefined (exoplanet.TzeroTrSecErrorMax))
                Writer.WriteAttributeString ("errorMax", exoplanet.TzeroTrSecErrorMax);

            Writer.WriteEndElement ();
            }

        static private void WriteLambdaAngle (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("LambdaAngle");

            if (IsDefined (exoplanet.LambdaAngle))
                Writer.WriteAttributeString ("value", exoplanet.LambdaAngle);

            if (IsDefined (exoplanet.LambdaAngleErrorMin))
                Writer.WriteAttributeString ("errorMin", exoplanet.LambdaAngleErrorMin);

            if (IsDefined (exoplanet.LambdaAngleErrorMax))
                Writer.WriteAttributeString ("errorMax", exoplanet.LambdaAngleErrorMax);

            Writer.WriteEndElement ();
            }

        static private void WriteTzeroVr (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("TzeroVr");

            if (IsDefined (exoplanet.TzeroVr))
                Writer.WriteAttributeString ("value", exoplanet.TzeroVr);

            if (IsDefined (exoplanet.TzeroVrErrorMin))
                Writer.WriteAttributeString ("errorMin", exoplanet.TzeroVrErrorMin);

            if (IsDefined (exoplanet.TzeroVrErrorMax))
                Writer.WriteAttributeString ("errorMax", exoplanet.TzeroVrErrorMax);

            Writer.WriteEndElement ();
            }

        static private void WriteTemperatures (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Temperatures");

            if (IsDefined (exoplanet.TemperatureCalculated))
                Writer.WriteAttributeString ("Calculated", exoplanet.TemperatureCalculated);

            if (IsDefined (exoplanet.TemperatureMeasured))
                Writer.WriteAttributeString ("Measured", exoplanet.TemperatureMeasured);

            if (IsDefined (exoplanet.TemperatureHotPointLo))
                Writer.WriteAttributeString ("HotPointLon", exoplanet.TemperatureHotPointLo);

            Writer.WriteEndElement ();
            }

        static private void WriteLogG (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("LogG");

            if (IsDefined (exoplanet.LogG))
                Writer.WriteAttributeString ("value", exoplanet.LogG);

            Writer.WriteEndElement ();
            }

        static private void WritePublicationStatus (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("PublicationStatus");

            if (IsDefined (exoplanet.Status))
                Writer.WriteAttributeString ("value", exoplanet.Status);

            Writer.WriteEndElement ();
            }

        static private void WriteDiscovered (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Discovered");

            if (IsDefined (exoplanet.Discovered))
                Writer.WriteAttributeString ("value", exoplanet.Discovered);

            Writer.WriteEndElement ();
            }

        static private void WriteUpdated (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Updated");

            if (IsDefined (exoplanet.Updated))
                Writer.WriteAttributeString ("value", exoplanet.Updated);

            Writer.WriteEndElement ();
            }

        static private void WriteOmega (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Omega");

            if (IsDefined (exoplanet.Omega))
                Writer.WriteAttributeString ("value", exoplanet.Omega);

            if (IsDefined (exoplanet.OmegaErrorMin))
                Writer.WriteAttributeString ("errorMin", exoplanet.OmegaErrorMin);

            if (IsDefined (exoplanet.OmegaErrorMax))
                Writer.WriteAttributeString ("errorMax", exoplanet.OmegaErrorMax);

            Writer.WriteEndElement ();
            }

        static private void WriteTperi (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Tperi");

            if (IsDefined (exoplanet.Tperi))
                Writer.WriteAttributeString ("value", exoplanet.Tperi);

            if (IsDefined (exoplanet.TperiErrorMin))
                Writer.WriteAttributeString ("errorMin", exoplanet.TperiErrorMin);

            if (IsDefined (exoplanet.TperiErrorMax))
                Writer.WriteAttributeString ("errorMax", exoplanet.TperiErrorMax);

            Writer.WriteEndElement ();
            }

        static private void WriteDetectionType (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("DetectionType");

            if (IsDefined (exoplanet.DetectionType))
                Writer.WriteAttributeString ("value", exoplanet.DetectionType);

            Writer.WriteEndElement ();
            }

        static private void WriteMolecules (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Molecules");

            if (IsDefined (exoplanet.Molecules))
                Writer.WriteAttributeString ("value", exoplanet.Molecules);

            Writer.WriteEndElement ();
            }

        static private void WriteImpactParameter (Exoplanet exoplanet)
            {
            if (string.Equals (Version, Constant.Version2) || string.Equals (Version, Constant.Version3))
                {
                Writer.WriteStartElement ("ImpactParameter");

                if (IsDefined (exoplanet.ImpactParameter))
                    Writer.WriteAttributeString ("value", exoplanet.ImpactParameter);

                if (IsDefined (exoplanet.ImpactParameterErrorMin))
                    Writer.WriteAttributeString ("errorMin", exoplanet.ImpactParameterErrorMin);

                if (IsDefined (exoplanet.ImpactParameterErrorMax))
                    Writer.WriteAttributeString ("errorMax", exoplanet.ImpactParameterErrorMax);

                Writer.WriteEndElement ();
                }
            }

        static private void WriteVelocitySemiamplitude (Exoplanet exoplanet)
            {
            if (string.Equals (Version, Constant.Version2) || string.Equals (Version, Constant.Version3))
                {
                Writer.WriteStartElement ("VelocitySemiamplitude");

                if (IsDefined (exoplanet.VelocitySemiamplitude))
                    Writer.WriteAttributeString ("value", exoplanet.VelocitySemiamplitude);

                if (IsDefined (exoplanet.VelocitySemiamplitudeErrorMin))
                    Writer.WriteAttributeString ("errorMin", exoplanet.VelocitySemiamplitudeErrorMin);

                if (IsDefined (exoplanet.VelocitySemiamplitudeErrorMax))
                    Writer.WriteAttributeString ("errorMax", exoplanet.VelocitySemiamplitudeErrorMax);

                Writer.WriteEndElement ();
                }
            }

        static private void WriteGeometricAlbedo (Exoplanet exoplanet)
            {
            if (string.Equals (Version, Constant.Version2) || string.Equals (Version, Constant.Version3))
                {
                Writer.WriteStartElement ("GeometricAlbedo");

                if (IsDefined (exoplanet.GeometricAlbedo))
                    Writer.WriteAttributeString ("value", exoplanet.GeometricAlbedo);

                if (IsDefined (exoplanet.GeometricAlbedoErrorMin))
                    Writer.WriteAttributeString ("errorMin", exoplanet.GeometricAlbedoErrorMin);

                if (IsDefined (exoplanet.GeometricAlbedoErrorMax))
                    Writer.WriteAttributeString ("errorMax", exoplanet.GeometricAlbedoErrorMax);

                Writer.WriteEndElement ();
                }
            }

        static private void WriteTconj (Exoplanet exoplanet)
            {
            if (string.Equals (Version, Constant.Version2) || string.Equals (Version, Constant.Version3))
                {
                Writer.WriteStartElement ("Tconj");

                if (IsDefined (exoplanet.Tconj))
                    Writer.WriteAttributeString ("value", exoplanet.Tconj);

                if (IsDefined (exoplanet.TconjErrorMin))
                    Writer.WriteAttributeString ("errorMin", exoplanet.TconjErrorMin);

                if (IsDefined (exoplanet.TconjErrorMax))
                    Writer.WriteAttributeString ("errorMax", exoplanet.TconjErrorMax);

                Writer.WriteEndElement ();
                }
            }

        static private void WriteMassDetectionType (Exoplanet exoplanet)
            {
            if (string.Equals (Version, Constant.Version2) || string.Equals (Version, Constant.Version3))
                {
                Writer.WriteStartElement ("MassDetectionType");

                if (IsDefined (exoplanet.MassDetectionType))
                    Writer.WriteAttributeString ("value", exoplanet.MassDetectionType);

                Writer.WriteEndElement ();
                }
            }

        static private void WriteRadiusDetectionType (Exoplanet exoplanet)
            {
            if (string.Equals (Version, Constant.Version2) || string.Equals (Version, Constant.Version3))
                {
                Writer.WriteStartElement ("RadiusDetectionType");

                if (IsDefined (exoplanet.RadiusDetectionType))
                    Writer.WriteAttributeString ("value", exoplanet.RadiusDetectionType);

                Writer.WriteEndElement ();
                }
            }

        static private void WriteAlternateNames (Exoplanet exoplanet)
            {
            if (string.Equals (Version, Constant.Version2) || string.Equals (Version, Constant.Version3))
                {
                Writer.WriteStartElement ("AlternateNames");

                if (IsDefined (exoplanet.AlternateNames))
                    Writer.WriteAttributeString ("value", exoplanet.AlternateNames);

                Writer.WriteEndElement ();
                }
            }

        static private void WriteStar (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Star");

            Writer.WriteAttributeString ("Name", exoplanet.Star.Name);
            Writer.WriteAttributeString ("RightAccession", exoplanet.Star.RightAccession);
            Writer.WriteAttributeString ("Declination", exoplanet.Star.Declination);

            if (string.Equals (Version, Constant.Version3))
                Writer.WriteAttributeString ("AlternateNames", exoplanet.Star.AlternateNames);

            WriteMagnitudes (exoplanet);
            WriteProperties (exoplanet);

            Writer.WriteEndElement ();
            }

        static private void WriteMagnitudes (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Magnitudes");

            if (IsDefined (exoplanet.Star.Magnitude.V))
                Writer.WriteAttributeString ("V", exoplanet.Star.Magnitude.V);

            if (IsDefined (exoplanet.Star.Magnitude.I))
                Writer.WriteAttributeString ("I", exoplanet.Star.Magnitude.I);

            if (IsDefined (exoplanet.Star.Magnitude.J))
                Writer.WriteAttributeString ("J", exoplanet.Star.Magnitude.J);

            if (IsDefined (exoplanet.Star.Magnitude.H))
                Writer.WriteAttributeString ("H", exoplanet.Star.Magnitude.H);

            if (IsDefined (exoplanet.Star.Magnitude.K))
                Writer.WriteAttributeString ("K", exoplanet.Star.Magnitude.K);

            Writer.WriteEndElement ();
            }

        static private void WriteProperties (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Properties");

            if (IsDefined (exoplanet.Star.Property.Distance))
                Writer.WriteAttributeString ("Distance", exoplanet.Star.Property.Distance);

            if (string.Equals (Version, Constant.Version3))
                {
                if (IsDefined (exoplanet.Star.Property.DistanceErrorMin))
                    Writer.WriteAttributeString ("DistanceErrorMin", exoplanet.Star.Property.DistanceErrorMin);

                if (IsDefined (exoplanet.Star.Property.DistanceErrorMax))
                    Writer.WriteAttributeString ("DistanceErrorMax", exoplanet.Star.Property.DistanceErrorMax);
                }

            if (IsDefined (exoplanet.Star.Property.Metallicity))
                Writer.WriteAttributeString ("Metallicity", exoplanet.Star.Property.Metallicity);

            if (string.Equals (Version, Constant.Version3))
                {
                if (IsDefined (exoplanet.Star.Property.MetallicityErrorMin))
                    Writer.WriteAttributeString ("MetallicityErrorMin", exoplanet.Star.Property.MetallicityErrorMin);

                if (IsDefined (exoplanet.Star.Property.MetallicityErrorMax))
                    Writer.WriteAttributeString ("MetallicityErrorMax", exoplanet.Star.Property.MetallicityErrorMax);
                }

            if (IsDefined (exoplanet.Star.Property.Mass))
                Writer.WriteAttributeString ("Mass", exoplanet.Star.Property.Mass);

            if (string.Equals (Version, Constant.Version3))
                {
                if (IsDefined (exoplanet.Star.Property.MassErrorMin))
                    Writer.WriteAttributeString ("MassErrorMin", exoplanet.Star.Property.MassErrorMin);

                if (IsDefined (exoplanet.Star.Property.MassErrorMax))
                    Writer.WriteAttributeString ("MassErrorMax", exoplanet.Star.Property.MassErrorMax);
                }

            if (IsDefined (exoplanet.Star.Property.Radius))
                Writer.WriteAttributeString ("Radius", exoplanet.Star.Property.Radius);

            if (string.Equals (Version, Constant.Version3))
                {
                if (IsDefined (exoplanet.Star.Property.RadiusErrorMin))
                    Writer.WriteAttributeString ("RadiusErrorMin", exoplanet.Star.Property.RadiusErrorMin);

                if (IsDefined (exoplanet.Star.Property.RadiusErrorMax))
                    Writer.WriteAttributeString ("RadiusErrorMax", exoplanet.Star.Property.RadiusErrorMax);
                }

            if (IsDefined (exoplanet.Star.Property.SPType))
                Writer.WriteAttributeString ("SPType", exoplanet.Star.Property.SPType);

            if (IsDefined (exoplanet.Star.Property.Age))
                Writer.WriteAttributeString ("Age", exoplanet.Star.Property.Age);

            if (string.Equals (Version, Constant.Version3))
                {
                if (IsDefined (exoplanet.Star.Property.AgeErrorMin))
                    Writer.WriteAttributeString ("AgeErrorMin", exoplanet.Star.Property.AgeErrorMin);

                if (IsDefined (exoplanet.Star.Property.AgeErrorMax))
                    Writer.WriteAttributeString ("AgeErrorMax", exoplanet.Star.Property.AgeErrorMax);
                }

            if (IsDefined (exoplanet.Star.Property.Teff))
                Writer.WriteAttributeString ("Teff", exoplanet.Star.Property.Teff);

            if (string.Equals (Version, Constant.Version3))
                {
                if (IsDefined (exoplanet.Star.Property.TeffErrorMin))
                    Writer.WriteAttributeString ("TeffErrorMin", exoplanet.Star.Property.TeffErrorMin);

                if (IsDefined (exoplanet.Star.Property.TeffErrorMax))
                    Writer.WriteAttributeString ("TeffErrorMax", exoplanet.Star.Property.TeffErrorMax);
                }

            if (string.Equals (Version, Constant.Version2) || string.Equals (Version, Constant.Version3))
                {
                if (IsDefined (exoplanet.Star.Property.DetectedDisc))
                    Writer.WriteAttributeString ("DetectedDisc", exoplanet.Star.Property.DetectedDisc);

                if (IsDefined (exoplanet.Star.Property.MagneticField))
                    Writer.WriteAttributeString ("MagneticField", exoplanet.Star.Property.MagneticField);
                }

            Writer.WriteEndElement ();
            }

        static private bool IsDefined (string string1, string string2, string string3)
            {
            if (IsDefined (string1) && IsDefined (string2) && IsDefined (string3))
                return true;
            else
                return false;
            }

        static private bool IsDefined (string string1)
            {
            if (string1 != null)
                return string1.Length > 0 ? true : false;
            else
                return false;
            }
        }
    }