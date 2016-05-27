using System.Xml;

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

        static public int WriteExoplanet (XmlWriter writer, Exoplanet exoplanet, string version)
            {
            Writer = writer;
            Version = version;

            exoplanet.CorrectErrors ();

            WriteExoplanet (exoplanet);

            return 0;
            }

        static private void WriteExoplanet (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Exoplanet");

            Writer.WriteAttributeString ("name", exoplanet.Name.Trim ());

            WriteMass (exoplanet);
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
            WriteTemperature (exoplanet);
            WriteLogG (exoplanet);
            WritePublicationStatus (exoplanet);
            WriteDiscovered (exoplanet);
            WriteUpdated (exoplanet);
            WriteOmega (exoplanet);
            WriteTperi (exoplanet);
            WriteDetectionType (exoplanet);
            WriteMolecules (exoplanet);

            WriteImpactParameter (exoplanet);
            WriteK (exoplanet);
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

            if (IsDefine (exoplanet.Mass))
                Writer.WriteAttributeString ("mass", exoplanet.Mass);

            if (IsDefine (exoplanet.MassErrorMin))
                Writer.WriteAttributeString ("errorMin", exoplanet.MassErrorMin);

            if (IsDefine (exoplanet.MassErrorMax))
                Writer.WriteAttributeString ("errorMax", exoplanet.MassErrorMax);

            Writer.WriteEndElement ();
            }

        static private void WriteRadius (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Radius");

            if (IsDefine (exoplanet.Radius))
                Writer.WriteAttributeString ("radius", exoplanet.Radius);

            if (IsDefine (exoplanet.RadiusErrorMin))
                Writer.WriteAttributeString ("errorMin", exoplanet.RadiusErrorMin);

            if (IsDefine (exoplanet.RadiusErrorMax))
                Writer.WriteAttributeString ("errorMax", exoplanet.RadiusErrorMax);

            Writer.WriteEndElement ();
            }

        static private void WriteOrbitalPeriod (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("OrbitalPeriod");

            if (IsDefine (exoplanet.OrbitalPeriod))
                Writer.WriteAttributeString ("orbitalPeriod", exoplanet.OrbitalPeriod);

            if (IsDefine (exoplanet.OrbitalPeriodErrorMin))
                Writer.WriteAttributeString ("errorMin", exoplanet.OrbitalPeriodErrorMin);

            if (IsDefine (exoplanet.OrbitalPeriodErrorMax))
                Writer.WriteAttributeString ("errorMax", exoplanet.OrbitalPeriodErrorMax);

            Writer.WriteEndElement ();
            }

        static private void WriteSemiMajorAxis (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("SemiMajorAxis");

            if (IsDefine (exoplanet.SemiMajorAxis))
                Writer.WriteAttributeString ("semiMajorAxis", exoplanet.SemiMajorAxis);

            if (IsDefine (exoplanet.SemiMajorAxisErrorMin))
                Writer.WriteAttributeString ("errorMin", exoplanet.SemiMajorAxisErrorMin);

            if (IsDefine (exoplanet.SemiMajorAxisErrorMax))
                Writer.WriteAttributeString ("errorMax", exoplanet.SemiMajorAxisErrorMax);

            Writer.WriteEndElement ();
            }

        static private void WriteEccentricity (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Eccentricity");

            if (IsDefine (exoplanet.Eccentricity))
                Writer.WriteAttributeString ("eccentricity", exoplanet.Eccentricity);

            if (IsDefine (exoplanet.EccentricityErrorMin))
                Writer.WriteAttributeString ("errorMin", exoplanet.EccentricityErrorMin);

            if (IsDefine (exoplanet.EccentricityErrorMax))
                Writer.WriteAttributeString ("errorMax", exoplanet.EccentricityErrorMax);

            Writer.WriteEndElement ();
            }

        static private void WriteAngularDistance (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("AngularDistance");

            if (IsDefine (exoplanet.AngularDistance))
                Writer.WriteAttributeString ("angularDistance", exoplanet.AngularDistance);

            Writer.WriteEndElement ();
            }

        static private void WriteInclination (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Inclination");

            if (IsDefine (exoplanet.Inclination))
                Writer.WriteAttributeString ("inclination", exoplanet.Inclination);

            if (IsDefine (exoplanet.InclinationErrorMin))
                Writer.WriteAttributeString ("errorMin", exoplanet.InclinationErrorMin);

            if (IsDefine (exoplanet.InclinationErrorMax))
                Writer.WriteAttributeString ("errorMax", exoplanet.InclinationErrorMax);

            Writer.WriteEndElement ();
            }

        static private void WriteTzeroTr (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("TzeroTr");

            if (IsDefine (exoplanet.TzeroTr))
                Writer.WriteAttributeString ("tzero_tr", exoplanet.TzeroTr);

            if (IsDefine (exoplanet.TzeroTrErrorMin))
                Writer.WriteAttributeString ("errorMin", exoplanet.TzeroTrErrorMin);

            if (IsDefine (exoplanet.TzeroTrErrorMax))
                Writer.WriteAttributeString ("errorMax", exoplanet.TzeroTrErrorMax);

            Writer.WriteEndElement ();
            }

        static private void WriteTzeroTrSec (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("TzeroTrSec");

            if (IsDefine (exoplanet.TzeroTrSec))
                Writer.WriteAttributeString ("tzero_trSec", exoplanet.TzeroTrSec);

            if (IsDefine (exoplanet.TzeroTrSecErrorMin))
                Writer.WriteAttributeString ("errorMin", exoplanet.TzeroTrSecErrorMin);

            if (IsDefine (exoplanet.TzeroTrSecErrorMax))
                Writer.WriteAttributeString ("errorMax", exoplanet.TzeroTrSecErrorMax);

            Writer.WriteEndElement ();
            }

        static private void WriteLambdaAngle (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("LambdaAngle");

            if (IsDefine (exoplanet.LambdaAngle))
                Writer.WriteAttributeString ("lambdaAngle", exoplanet.LambdaAngle);

            if (IsDefine (exoplanet.LambdaAngleErrorMin))
                Writer.WriteAttributeString ("errorMin", exoplanet.LambdaAngleErrorMin);

            if (IsDefine (exoplanet.LambdaAngleErrorMax))
                Writer.WriteAttributeString ("errorMax", exoplanet.LambdaAngleErrorMax);

            Writer.WriteEndElement ();
            }

        static private void WriteTzeroVr (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("TzeroVr");

            if (IsDefine (exoplanet.TzeroVr))
                Writer.WriteAttributeString ("tzero_vr", exoplanet.TzeroVr);

            if (IsDefine (exoplanet.TzeroVrErrorMin))
                Writer.WriteAttributeString ("errorMin", exoplanet.TzeroVrErrorMin);

            if (IsDefine (exoplanet.TzeroVrErrorMax))
                Writer.WriteAttributeString ("errorMax", exoplanet.TzeroVrErrorMax);

            Writer.WriteEndElement ();
            }

        static private void WriteTemperature (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Temperature");

            if (IsDefine (exoplanet.TemperatureCalculated))
                Writer.WriteAttributeString ("Calculated", exoplanet.TemperatureCalculated);

            if (IsDefine (exoplanet.TemperatureMeasured))
                Writer.WriteAttributeString ("Measured", exoplanet.TemperatureMeasured);

            if (IsDefine (exoplanet.TemperatureHotPointLo))
                Writer.WriteAttributeString ("HotPointLon", exoplanet.TemperatureHotPointLo);

            Writer.WriteEndElement ();
            }

        static private void WriteLogG (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("LogG");

            if (IsDefine (exoplanet.LogG))
                Writer.WriteAttributeString ("logG", exoplanet.LogG);

            Writer.WriteEndElement ();
            }

        static private void WritePublicationStatus (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("PublicationStatus");

            if (IsDefine (exoplanet.Status))
                Writer.WriteAttributeString ("Status", exoplanet.Status);

            Writer.WriteEndElement ();
            }

        static private void WriteDiscovered (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Discovered");

            if (IsDefine (exoplanet.Discovered))
                Writer.WriteAttributeString ("discovered", exoplanet.Discovered);

            Writer.WriteEndElement ();
            }

        static private void WriteUpdated (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Updated");

            if (IsDefine (exoplanet.Updated))
                Writer.WriteAttributeString ("updated", exoplanet.Updated);

            Writer.WriteEndElement ();
            }

        static private void WriteOmega (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Omega");

            if (IsDefine (exoplanet.Omega))
                Writer.WriteAttributeString ("Omega", exoplanet.Omega);

            if (IsDefine (exoplanet.OmegaErrorMin))
                Writer.WriteAttributeString ("errorMin", exoplanet.OmegaErrorMin);

            if (IsDefine (exoplanet.OmegaErrorMax))
                Writer.WriteAttributeString ("errorMax", exoplanet.OmegaErrorMax);

            Writer.WriteEndElement ();
            }

        static private void WriteTperi (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Tperi");

            if (IsDefine (exoplanet.Tperi))
                Writer.WriteAttributeString ("tperi", exoplanet.Tperi);

            if (IsDefine (exoplanet.TperiErrorMin))
                Writer.WriteAttributeString ("errorMin", exoplanet.TperiErrorMin);

            if (IsDefine (exoplanet.TperiErrorMax))
                Writer.WriteAttributeString ("errorMax", exoplanet.TperiErrorMax);

            Writer.WriteEndElement ();
            }

        static private void WriteDetectionType (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("DetectionType");

            if (IsDefine (exoplanet.DetectionType))
                Writer.WriteAttributeString ("Type", exoplanet.DetectionType);

            Writer.WriteEndElement ();
            }

        static private void WriteMolecules (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Molecules");

            if (IsDefine (exoplanet.Molecules))
                Writer.WriteAttributeString ("molecules", exoplanet.Molecules);

            Writer.WriteEndElement ();
            }

        static private void WriteImpactParameter (Exoplanet exoplanet)
            {
            if (string.Equals (Version, Constant.Version2))
                {
                Writer.WriteStartElement ("ImpactParameter");

                if (IsDefine (exoplanet.ImpactParameter))
                    Writer.WriteAttributeString ("impactParameter", exoplanet.ImpactParameter);

                if (IsDefine (exoplanet.ImpactParameterErrorMin))
                    Writer.WriteAttributeString ("errorMin", exoplanet.ImpactParameterErrorMin);

                if (IsDefine (exoplanet.ImpactParameterErrorMax))
                    Writer.WriteAttributeString ("errorMax", exoplanet.ImpactParameterErrorMax);

                Writer.WriteEndElement ();
                }
            }

        static private void WriteK (Exoplanet exoplanet)
            {
            if (string.Equals (Version, Constant.Version2))
                {
                Writer.WriteStartElement ("K");

                if (IsDefine (exoplanet.VelocitySemiamplitude))
                    Writer.WriteAttributeString ("k", exoplanet.VelocitySemiamplitude);

                if (IsDefine (exoplanet.VelocitySemiamplitudeErrorMin))
                    Writer.WriteAttributeString ("errorMin", exoplanet.VelocitySemiamplitudeErrorMin);

                if (IsDefine (exoplanet.VelocitySemiamplitudeErrorMax))
                    Writer.WriteAttributeString ("errorMax", exoplanet.VelocitySemiamplitudeErrorMax);

                Writer.WriteEndElement ();
                }
            }

        static private void WriteGeometricAlbedo (Exoplanet exoplanet)
            {
            if (string.Equals (Version, Constant.Version2))
                {
                Writer.WriteStartElement ("GeometricAlbedo");

                if (IsDefine (exoplanet.GeometricAlbedo))
                    Writer.WriteAttributeString ("geometricAlbedo", exoplanet.GeometricAlbedo);

                if (IsDefine (exoplanet.GeometricAlbedoErrorMin))
                    Writer.WriteAttributeString ("errorMin", exoplanet.GeometricAlbedoErrorMin);

                if (IsDefine (exoplanet.GeometricAlbedoErrorMax))
                    Writer.WriteAttributeString ("errorMax", exoplanet.GeometricAlbedoErrorMax);

                Writer.WriteEndElement ();
                }
            }

        static private void WriteTconj (Exoplanet exoplanet)
            {
            if (string.Equals (Version, Constant.Version2))
                {
                Writer.WriteStartElement ("Tconj");

                if (IsDefine (exoplanet.Tconj))
                    Writer.WriteAttributeString ("tconj", exoplanet.Tconj);

                if (IsDefine (exoplanet.TconjErrorMin))
                    Writer.WriteAttributeString ("errorMin", exoplanet.TconjErrorMin);

                if (IsDefine (exoplanet.TconjErrorMax))
                    Writer.WriteAttributeString ("errorMax", exoplanet.TconjErrorMax);

                Writer.WriteEndElement ();
                }
            }

        static private void WriteMassDetectionType (Exoplanet exoplanet)
            {
            if (string.Equals (Version, Constant.Version2))
                {
                Writer.WriteStartElement ("MassDetectionType");

                if (IsDefine (exoplanet.MassDetectionType))
                    Writer.WriteAttributeString ("massDetectionType", exoplanet.MassDetectionType);

                Writer.WriteEndElement ();
                }
            }

        static private void WriteRadiusDetectionType (Exoplanet exoplanet)
            {
            if (string.Equals (Version, Constant.Version2))
                {
                Writer.WriteStartElement ("RadiusDetectionType");

                if (IsDefine (exoplanet.RadiusDetectionType))
                    Writer.WriteAttributeString ("radiusDetectionType", exoplanet.RadiusDetectionType);

                Writer.WriteEndElement ();
                }
            }

        static private void WriteAlternateNames (Exoplanet exoplanet)
            {
            if (string.Equals (Version, Constant.Version2))
                {
                Writer.WriteStartElement ("AlternateNames");

                if (IsDefine (exoplanet.AlternateNames))
                    Writer.WriteAttributeString ("alternateNames", exoplanet.AlternateNames);

                Writer.WriteEndElement ();
                }
            }

        static private void WriteStar (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Star");

            Writer.WriteAttributeString ("Name", exoplanet.Star.Name);
            Writer.WriteAttributeString ("ra", exoplanet.Star.RightAccession);
            Writer.WriteAttributeString ("dec", exoplanet.Star.Declination);

            WriteMagnitudes (exoplanet);
            WriteProperties (exoplanet);

            Writer.WriteEndElement ();
            }

        static private void WriteMagnitudes (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Magnitudes");

            if (IsDefine (exoplanet.Star.Magnitude.V))
                Writer.WriteAttributeString ("V", exoplanet.Star.Magnitude.V);

            if (IsDefine (exoplanet.Star.Magnitude.I))
                Writer.WriteAttributeString ("I", exoplanet.Star.Magnitude.I);

            if (IsDefine (exoplanet.Star.Magnitude.J))
                Writer.WriteAttributeString ("J", exoplanet.Star.Magnitude.J);

            if (IsDefine (exoplanet.Star.Magnitude.H))
                Writer.WriteAttributeString ("H", exoplanet.Star.Magnitude.H);

            if (IsDefine (exoplanet.Star.Magnitude.K))
                Writer.WriteAttributeString ("K", exoplanet.Star.Magnitude.K);

            Writer.WriteEndElement ();
            }

        static private void WriteProperties (Exoplanet exoplanet)
            {
            Writer.WriteStartElement ("Properties");

            if (IsDefine (exoplanet.Star.Property.Distance))
                Writer.WriteAttributeString ("Distance", exoplanet.Star.Property.Distance);

            if (IsDefine (exoplanet.Star.Property.Metallicity))
                Writer.WriteAttributeString ("Metallicity", exoplanet.Star.Property.Metallicity);

            if (IsDefine (exoplanet.Star.Property.Mass))
                Writer.WriteAttributeString ("Mass", exoplanet.Star.Property.Mass);

            if (IsDefine (exoplanet.Star.Property.Radius))
                Writer.WriteAttributeString ("Radius", exoplanet.Star.Property.Radius);

            if (IsDefine (exoplanet.Star.Property.SPType))
                Writer.WriteAttributeString ("SPType", exoplanet.Star.Property.SPType);

            if (IsDefine (exoplanet.Star.Property.Age))
                Writer.WriteAttributeString ("Age", exoplanet.Star.Property.Age);

            if (IsDefine (exoplanet.Star.Property.Teff))
                Writer.WriteAttributeString ("Teff", exoplanet.Star.Property.Teff);

            if (string.Equals (Version, Constant.Version2))
                {
                if (IsDefine (exoplanet.Star.Property.DetectedDisc))
                    Writer.WriteAttributeString ("DetectedDisc", exoplanet.Star.Property.DetectedDisc);

                if (IsDefine (exoplanet.Star.Property.MagneticField))
                    Writer.WriteAttributeString ("MagneticField", exoplanet.Star.Property.MagneticField);
                }

            Writer.WriteEndElement ();
            }

        static private bool IsDefine (string string1, string string2, string string3)
            {
            if (IsDefine (string1) && IsDefine (string2) && IsDefine (string3))
                return true;
            else
                return false;
            }

        static private bool IsDefine (string string1)
            {
            if (string1 != null)
                return string1.Length > 0 ? true : false;
            else
                return false;
            }
        }
    }