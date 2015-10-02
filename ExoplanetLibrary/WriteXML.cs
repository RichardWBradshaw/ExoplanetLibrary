using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace ExoplanetLibrary
    {
    class WriteXML
        {
        static private XmlWriter Writer_ = null;
        static private XmlWriter Writer
            {
            get
                {
                return Writer_;
                }
            set
                {
                Writer_ = value;
                }
            }

        static private string Version_ = "";
        static private string Version
            {
            get
                {
                return Version_;
                }
            set
                {
                Version_ = value;
                }
            }

        static public int WriteExoplanet ( XmlWriter writer, CExoplanet exoplanet, string version )
            {
            Writer = writer;
            Version = version;

            WriteExoplanet ( exoplanet );

            return 0;
            }

        static private void WriteExoplanet ( CExoplanet exoplanet )
            {
            Writer.WriteStartElement ( "Exoplanet" );

            Writer.WriteAttributeString ( "name", exoplanet.Name );

            WriteMass ( exoplanet );
            WriteRadius ( exoplanet );
            WriteOrbitalPeriod ( exoplanet );
            WriteSemiMajorAxis ( exoplanet );
            WriteEccentricity ( exoplanet );
            WriteAngularDistance ( exoplanet );
            WriteInclination ( exoplanet );
            WriteTzeroTr ( exoplanet );
            WriteTzeroTrSec ( exoplanet );
            WriteLambdaAngle ( exoplanet );
            WriteTzeroVr ( exoplanet );
            WriteTemperature ( exoplanet );
            WriteLogG ( exoplanet );
            WritePublicationStatus ( exoplanet );
            WriteDiscovered ( exoplanet );
            WriteUpdated ( exoplanet );
            WriteOmega ( exoplanet );
            WriteTperi ( exoplanet );
            WriteDetectionType ( exoplanet );
            WriteMolecules ( exoplanet );

            if ( string.Equals ( Version, "2.0" ) )
                {
                WriteImpactParameter ( exoplanet );
                WriteK ( exoplanet );
                WriteGeometricAlbedo ( exoplanet );
                WriteTconj ( exoplanet );
                WriteMassDetectionType ( exoplanet );
                WriteRadiusDetectionType ( exoplanet );
                WriteAlternateNames ( exoplanet );
                }

            WriteStar ( exoplanet );

            Writer.WriteEndElement ( );
            }

        static private void WriteMass ( CExoplanet exoplanet )
            {
            Writer.WriteStartElement ( "Mass" );

            if ( IsDefine ( exoplanet.Mass ) )
                Writer.WriteAttributeString ( "mass", exoplanet.Mass );

            if ( IsDefine ( exoplanet.MassErrorMin ) )
                Writer.WriteAttributeString ( "errorMin", exoplanet.MassErrorMin );

            if ( IsDefine ( exoplanet.MassErrorMax ) )
                Writer.WriteAttributeString ( "errorMax", exoplanet.MassErrorMax );

            Writer.WriteEndElement ( );
            }

        static private void WriteRadius ( CExoplanet exoplanet )
            {
            Writer.WriteStartElement ( "Radius" );

            if ( IsDefine ( exoplanet.Radius ) )
                Writer.WriteAttributeString ( "radius", exoplanet.Radius );

            if ( IsDefine ( exoplanet.RadiusErrorMin ) )
                Writer.WriteAttributeString ( "errorMin", exoplanet.RadiusErrorMin );

            if ( IsDefine ( exoplanet.RadiusErrorMax ) )
                Writer.WriteAttributeString ( "errorMax", exoplanet.RadiusErrorMax );

            Writer.WriteEndElement ( );
            }

        static private void WriteOrbitalPeriod ( CExoplanet exoplanet )
            {
            Writer.WriteStartElement ( "OrbitalPeriod" );

            if ( IsDefine ( exoplanet.OrbitalPeriod ) )
                Writer.WriteAttributeString ( "orbitalPeriod", exoplanet.OrbitalPeriod );

            if ( IsDefine ( exoplanet.OrbitalPeriodErrorMin ) )
                Writer.WriteAttributeString ( "errorMin", exoplanet.OrbitalPeriodErrorMin );

            if ( IsDefine ( exoplanet.OrbitalPeriodErrorMax ) )
                Writer.WriteAttributeString ( "errorMax", exoplanet.OrbitalPeriodErrorMax );

            Writer.WriteEndElement ( );
            }

        static private void WriteSemiMajorAxis ( CExoplanet exoplanet )
            {
            Writer.WriteStartElement ( "SemiMajorAxis" );

            if ( IsDefine ( exoplanet.SemiMajorAxis ) )
                Writer.WriteAttributeString ( "semiMajorAxis", exoplanet.SemiMajorAxis );

            if ( IsDefine ( exoplanet.SemiMajorAxisErrorMin ) )
                Writer.WriteAttributeString ( "errorMin", exoplanet.SemiMajorAxisErrorMin );

            if ( IsDefine ( exoplanet.SemiMajorAxisErrorMax ) )
                Writer.WriteAttributeString ( "errorMax", exoplanet.SemiMajorAxisErrorMax );

            Writer.WriteEndElement ( );
            }

        static private void WriteEccentricity ( CExoplanet exoplanet )
            {
            Writer.WriteStartElement ( "Eccentricity" );

            if ( IsDefine ( exoplanet.Eccentricity ) )
                Writer.WriteAttributeString ( "eccentricity", exoplanet.Eccentricity );

            if ( IsDefine ( exoplanet.EccentricityErrorMin ) )
                Writer.WriteAttributeString ( "errorMin", exoplanet.EccentricityErrorMin );

            if ( IsDefine ( exoplanet.EccentricityErrorMax ) )
                Writer.WriteAttributeString ( "errorMax", exoplanet.EccentricityErrorMax );

            Writer.WriteEndElement ( );
            }

        static private void WriteAngularDistance ( CExoplanet exoplanet )
            {
            Writer.WriteStartElement ( "AngularDistance" );

            if ( IsDefine ( exoplanet.AngularDistance ) )
                Writer.WriteAttributeString ( "angularDistance", exoplanet.AngularDistance );

            Writer.WriteEndElement ( );
            }

        static private void WriteInclination ( CExoplanet exoplanet )
            {
            Writer.WriteStartElement ( "Inclination" );

            if ( IsDefine ( exoplanet.Inclination ) )
                Writer.WriteAttributeString ( "inclination", exoplanet.Inclination );

            if ( IsDefine ( exoplanet.InclinationErrorMin ) )
                Writer.WriteAttributeString ( "errorMin", exoplanet.InclinationErrorMin );

            if ( IsDefine ( exoplanet.InclinationErrorMax ) )
                Writer.WriteAttributeString ( "errorMax", exoplanet.InclinationErrorMax );

            Writer.WriteEndElement ( );
            }

        static private void WriteTzeroTr ( CExoplanet exoplanet )
            {
            Writer.WriteStartElement ( "TzeroTr" );

            if ( IsDefine ( exoplanet.TzeroTr ) )
                Writer.WriteAttributeString ( "tzero_tr", exoplanet.TzeroTr );

            if ( IsDefine ( exoplanet.TzeroTrErrorMin ) )
                Writer.WriteAttributeString ( "errorMin", exoplanet.TzeroTrErrorMin );

            if ( IsDefine ( exoplanet.TzeroTrErrorMax ) )
                Writer.WriteAttributeString ( "errorMax", exoplanet.TzeroTrErrorMax );

            Writer.WriteEndElement ( );
            }

        static private void WriteTzeroTrSec ( CExoplanet exoplanet )
            {
            Writer.WriteStartElement ( "TzeroTrSec" );

            if ( IsDefine ( exoplanet.TzeroTrSec ) )
                Writer.WriteAttributeString ( "tzero_trSec", exoplanet.TzeroTrSec );

            if ( IsDefine ( exoplanet.TzeroTrSecErrorMin ) )
                Writer.WriteAttributeString ( "errorMin", exoplanet.TzeroTrSecErrorMin );

            if ( IsDefine ( exoplanet.TzeroTrSecErrorMax ) )
                Writer.WriteAttributeString ( "errorMax", exoplanet.TzeroTrSecErrorMax );

            Writer.WriteEndElement ( );
            }

        static private void WriteLambdaAngle ( CExoplanet exoplanet )
            {
            Writer.WriteStartElement ( "LambdaAngle" );

            if ( IsDefine ( exoplanet.LambdaAngle ) )
                Writer.WriteAttributeString ( "lambdaAngle", exoplanet.LambdaAngle );

            if ( IsDefine ( exoplanet.LambdaAngleErrorMin ) )
                Writer.WriteAttributeString ( "errorMin", exoplanet.LambdaAngleErrorMin );

            if ( IsDefine ( exoplanet.LambdaAngleErrorMax ) )
                Writer.WriteAttributeString ( "errorMax", exoplanet.LambdaAngleErrorMax );

            Writer.WriteEndElement ( );
            }

        static private void WriteTzeroVr ( CExoplanet exoplanet )
            {
            Writer.WriteStartElement ( "TzeroVr" );

            if ( IsDefine ( exoplanet.TzeroVr ) )
                Writer.WriteAttributeString ( "tzero_vr", exoplanet.TzeroVr );

            if ( IsDefine ( exoplanet.TzeroVrErrorMin ) )
                Writer.WriteAttributeString ( "errorMin", exoplanet.TzeroVrErrorMin );

            if ( IsDefine ( exoplanet.TzeroVrErrorMax ) )
                Writer.WriteAttributeString ( "errorMax", exoplanet.TzeroVrErrorMax );

            Writer.WriteEndElement ( );
            }

        static private void WriteTemperature ( CExoplanet exoplanet )
            {
            Writer.WriteStartElement ( "Temperature" );

            if ( IsDefine ( exoplanet.TemperatureCalculated ) )
                Writer.WriteAttributeString ( "Calculated", exoplanet.TemperatureCalculated );

            if ( IsDefine ( exoplanet.TemperatureMeasured ) )
                Writer.WriteAttributeString ( "Measured", exoplanet.TemperatureMeasured );

            if ( IsDefine ( exoplanet.TemperatureHotPointLo ) )
                Writer.WriteAttributeString ( "HotPointLon", exoplanet.TemperatureHotPointLo );

            Writer.WriteEndElement ( );
            }

        static private void WriteLogG ( CExoplanet exoplanet )
            {
            Writer.WriteStartElement ( "LogG" );

            if ( IsDefine ( exoplanet.LogG ) )
                Writer.WriteAttributeString ( "logG", exoplanet.LogG );

            Writer.WriteEndElement ( );
            }

        static private void WritePublicationStatus ( CExoplanet exoplanet )
            {
            Writer.WriteStartElement ( "PublicationStatus" );

            if ( IsDefine ( exoplanet.Status ) )
                Writer.WriteAttributeString ( "Status", exoplanet.Status );

            Writer.WriteEndElement ( );
            }

        static private void WriteDiscovered ( CExoplanet exoplanet )
            {
            Writer.WriteStartElement ( "Discovered" );

            if ( IsDefine ( exoplanet.Discovered ) )
                Writer.WriteAttributeString ( "discovered", exoplanet.Discovered );

            Writer.WriteEndElement ( );
            }

        static private void WriteUpdated ( CExoplanet exoplanet )
            {
            Writer.WriteStartElement ( "Updated" );

            if ( IsDefine ( exoplanet.Updated ) )
                Writer.WriteAttributeString ( "updated", exoplanet.Updated );

            Writer.WriteEndElement ( );
            }

        static private void WriteOmega ( CExoplanet exoplanet )
            {
            Writer.WriteStartElement ( "Omega" );

            if ( IsDefine ( exoplanet.Omega ) )
                Writer.WriteAttributeString ( "Omega", exoplanet.Omega );

            if ( IsDefine ( exoplanet.OmegaErrorMin ) )
                Writer.WriteAttributeString ( "errorMin", exoplanet.OmegaErrorMin );

            if ( IsDefine ( exoplanet.OmegaErrorMax ) )
                Writer.WriteAttributeString ( "errorMax", exoplanet.OmegaErrorMax );

            Writer.WriteEndElement ( );
            }

        static private void WriteTperi ( CExoplanet exoplanet )
            {
            Writer.WriteStartElement ( "Tperi" );

            if ( IsDefine ( exoplanet.Tperi ) )
                Writer.WriteAttributeString ( "tperi", exoplanet.Tperi );

            if ( IsDefine ( exoplanet.TperiErrorMin ) )
                Writer.WriteAttributeString ( "errorMin", exoplanet.TperiErrorMin );

            if ( IsDefine ( exoplanet.TperiErrorMax ) )
                Writer.WriteAttributeString ( "errorMax", exoplanet.TperiErrorMax );

            Writer.WriteEndElement ( );
            }

        static private void WriteDetectionType ( CExoplanet exoplanet )
            {
            Writer.WriteStartElement ( "DetectionType" );

            if ( IsDefine ( exoplanet.DetectionType ) )
                Writer.WriteAttributeString ( "Type", exoplanet.DetectionType );

            Writer.WriteEndElement ( );
            }

        static private void WriteMolecules ( CExoplanet exoplanet )
            {
            Writer.WriteStartElement ( "Molecules" );

            if ( IsDefine ( exoplanet.Molecules ) )
                Writer.WriteAttributeString ( "molecules", exoplanet.Molecules );

            Writer.WriteEndElement ( );
            }

        static private void WriteImpactParameter ( CExoplanet exoplanet )
            {
            if ( string.Equals ( Version, "2.0" ) )
                {
                Writer.WriteStartElement ( "ImpactParameter" );

                if ( IsDefine ( exoplanet.ImpactParameter ) )
                    Writer.WriteAttributeString ( "impactParameter", exoplanet.ImpactParameter );

                if ( IsDefine ( exoplanet.ImpactParameterErrorMin ) )
                    Writer.WriteAttributeString ( "errorMin", exoplanet.ImpactParameterErrorMin );

                if ( IsDefine ( exoplanet.ImpactParameterErrorMax ) )
                    Writer.WriteAttributeString ( "errorMax", exoplanet.ImpactParameterErrorMax );

                Writer.WriteEndElement ( );
                }
            }

        static private void WriteK ( CExoplanet exoplanet )
            {
            if ( string.Equals ( Version, "2.0" ) )
                {
                Writer.WriteStartElement ( "K" );

                if ( IsDefine ( exoplanet.K ) )
                    Writer.WriteAttributeString ( "k", exoplanet.K );

                if ( IsDefine ( exoplanet.KErrorMin ) )
                    Writer.WriteAttributeString ( "errorMin", exoplanet.KErrorMin );

                if ( IsDefine ( exoplanet.KErrorMax ) )
                    Writer.WriteAttributeString ( "errorMax", exoplanet.KErrorMax );

                Writer.WriteEndElement ( );
                }
            }

        static private void WriteGeometricAlbedo ( CExoplanet exoplanet )
            {
            if ( string.Equals ( Version, "2.0" ) )
                {
                Writer.WriteStartElement ( "GeometricAlbedo" );

                if ( IsDefine ( exoplanet.GeometricAlbedo ) )
                    Writer.WriteAttributeString ( "geometricAlbedo", exoplanet.GeometricAlbedo );

                if ( IsDefine ( exoplanet.GeometricAlbedoErrorMin ) )
                    Writer.WriteAttributeString ( "errorMin", exoplanet.GeometricAlbedoErrorMin );

                if ( IsDefine ( exoplanet.GeometricAlbedoErrorMax ) )
                    Writer.WriteAttributeString ( "errorMax", exoplanet.GeometricAlbedoErrorMax );

                Writer.WriteEndElement ( );
                }
            }

        static private void WriteTconj ( CExoplanet exoplanet )
            {
            if ( string.Equals ( Version, "2.0" ) )
                {
                Writer.WriteStartElement ( "Tconj" );

                if ( IsDefine ( exoplanet.Tconj ) )
                    Writer.WriteAttributeString ( "tconj", exoplanet.Tconj );

                if ( IsDefine ( exoplanet.TconjErrorMin ) )
                    Writer.WriteAttributeString ( "errorMin", exoplanet.TconjErrorMin );

                if ( IsDefine ( exoplanet.TconjErrorMax ) )
                    Writer.WriteAttributeString ( "errorMax", exoplanet.TconjErrorMax );

                Writer.WriteEndElement ( );
                }
            }

        static private void WriteMassDetectionType ( CExoplanet exoplanet )
            {
            if ( string.Equals ( Version, "2.0" ) )
                {
                Writer.WriteStartElement ( "MassDetectionType" );

                if ( IsDefine ( exoplanet.MassDetectionType ) )
                    Writer.WriteAttributeString ( "massDetectionType", exoplanet.MassDetectionType );

                Writer.WriteEndElement ( );
                }
            }

        static private void WriteRadiusDetectionType ( CExoplanet exoplanet )
            {
            if ( string.Equals ( Version, "2.0" ) )
                {
                Writer.WriteStartElement ( "RadiusDetectionType" );

                if ( IsDefine ( exoplanet.RadiusDetectionType ) )
                    Writer.WriteAttributeString ( "radiusDetectionType", exoplanet.RadiusDetectionType );

                Writer.WriteEndElement ( );
                }
            }

        static private void WriteAlternateNames ( CExoplanet exoplanet )
            {
            if ( string.Equals ( Version, "2.0" ) )
                {
                Writer.WriteStartElement ( "AlternateNames" );

                if ( IsDefine ( exoplanet.AlternateNames ) )
                    Writer.WriteAttributeString ( "alternateNames", exoplanet.AlternateNames );

                Writer.WriteEndElement ( );
                }
            }

        static private void WriteStar ( CExoplanet exoplanet )
            {
            Writer.WriteStartElement ( "Star" );

            Writer.WriteAttributeString ( "Name", exoplanet.Star.Name );
            Writer.WriteAttributeString ( "ra", exoplanet.Star.RightAccession );
            Writer.WriteAttributeString ( "dec", exoplanet.Star.Declination );

            WriteMagnitudes ( exoplanet );
            WriteProperties ( exoplanet );

            Writer.WriteEndElement ( );
            }

        static private void WriteMagnitudes ( CExoplanet exoplanet )
            {
            Writer.WriteStartElement ( "Magnitudes" );

            if ( IsDefine ( exoplanet.Star.Magnitudes.V ) )
                Writer.WriteAttributeString ( "V", exoplanet.Star.Magnitudes.V );

            if ( IsDefine ( exoplanet.Star.Magnitudes.I ) )
                Writer.WriteAttributeString ( "I", exoplanet.Star.Magnitudes.I );

            if ( IsDefine ( exoplanet.Star.Magnitudes.J ) )
                Writer.WriteAttributeString ( "J", exoplanet.Star.Magnitudes.J );

            if ( IsDefine ( exoplanet.Star.Magnitudes.H ) )
                Writer.WriteAttributeString ( "H", exoplanet.Star.Magnitudes.H );

            if ( IsDefine ( exoplanet.Star.Magnitudes.K ) )
                Writer.WriteAttributeString ( "K", exoplanet.Star.Magnitudes.K );

            Writer.WriteEndElement ( );
            }

        static private void WriteProperties ( CExoplanet exoplanet )
            {
            Writer.WriteStartElement ( "Properties" );

            if ( IsDefine ( exoplanet.Star.Properties.Distance ) )
                Writer.WriteAttributeString ( "Distance", exoplanet.Star.Properties.Distance );

            if ( IsDefine ( exoplanet.Star.Properties.Metallicity ) )
                Writer.WriteAttributeString ( "Metallicity", exoplanet.Star.Properties.Metallicity );

            if ( IsDefine ( exoplanet.Star.Properties.Mass ) )
                Writer.WriteAttributeString ( "Mass", exoplanet.Star.Properties.Mass );

            if ( IsDefine ( exoplanet.Star.Properties.Radius ) )
                Writer.WriteAttributeString ( "Radius", exoplanet.Star.Properties.Radius );

            if ( IsDefine ( exoplanet.Star.Properties.SPType ) )
                Writer.WriteAttributeString ( "SPType", exoplanet.Star.Properties.SPType );

            if ( IsDefine ( exoplanet.Star.Properties.Age ) )
                Writer.WriteAttributeString ( "Age", exoplanet.Star.Properties.Age );

            if ( IsDefine ( exoplanet.Star.Properties.Teff ) )
                Writer.WriteAttributeString ( "Teff", exoplanet.Star.Properties.Teff );

            if ( string.Equals ( Version, "2.0" ) )
                {
                if ( IsDefine ( exoplanet.Star.Properties.DetectedDisc ) )
                    Writer.WriteAttributeString ( "DetectedDisc", exoplanet.Star.Properties.DetectedDisc );

                if ( IsDefine ( exoplanet.Star.Properties.MagneticField ) )
                    Writer.WriteAttributeString ( "MagneticField", exoplanet.Star.Properties.MagneticField );
                }

            Writer.WriteEndElement ( );
            }

        static private bool IsDefine ( string string1, string string2, string string3 )
            {
            if ( IsDefine ( string1 ) && IsDefine ( string2 ) && IsDefine ( string3 ) )
                return true;
            else
                return false;
            }

        static private bool IsDefine ( string string1 )
            {
            if ( string1 != null )
                return string1.Length > 0 ? true : false;
            else
                return false;
            }
        }
    }