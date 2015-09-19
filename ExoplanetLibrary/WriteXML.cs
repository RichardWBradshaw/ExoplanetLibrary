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
        static private XmlWriter m_writer = null;
        static private String m_version = "";

        static public int WriteExoplanet ( XmlWriter writer, CExoplanet exoplanet, string version )
            {
            m_writer = writer;
            m_version = version;

            WriteExoplanet ( exoplanet );

            return 0;
            }

        static private void WriteExoplanet ( CExoplanet exoplanet )
            {
            m_writer.WriteStartElement ( "Exoplanet" );

            m_writer.WriteAttributeString ( "name", exoplanet.Name );

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
            WriteImpactParameter ( exoplanet );
            WriteTperi ( exoplanet );

            if ( string.Equals ( m_version, "2.0" ) )
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

            m_writer.WriteEndElement ( );
            }

        static private void WriteMass ( CExoplanet exoplanet )
            {
            m_writer.WriteStartElement ( "Mass" );

            if ( IsDefine ( exoplanet.Mass ) )
                m_writer.WriteAttributeString ( "mass", exoplanet.Mass );

            if ( IsDefine ( exoplanet.MassErrorMin ) )
                m_writer.WriteAttributeString ( "errorMin", exoplanet.MassErrorMin );

            if ( IsDefine ( exoplanet.MassErrorMax ) )
                m_writer.WriteAttributeString ( "errorMax", exoplanet.MassErrorMax );

            m_writer.WriteEndElement ( );
            }

        static private void WriteRadius ( CExoplanet exoplanet )
            {
            m_writer.WriteStartElement ( "Radius" );

            if ( IsDefine ( exoplanet.Radius ) )
                m_writer.WriteAttributeString ( "radius", exoplanet.Radius );

            if ( IsDefine ( exoplanet.RadiusErrorMin ) )
                m_writer.WriteAttributeString ( "errorMin", exoplanet.RadiusErrorMin );

            if ( IsDefine ( exoplanet.RadiusErrorMax ) )
                m_writer.WriteAttributeString ( "errorMax", exoplanet.RadiusErrorMax );

            m_writer.WriteEndElement ( );
            }

        static private void WriteOrbitalPeriod ( CExoplanet exoplanet )
            {
            m_writer.WriteStartElement ( "OrbitalPeriod" );

            if ( IsDefine ( exoplanet.OrbitalPeriod ) )
                m_writer.WriteAttributeString ( "orbitalPeriod", exoplanet.OrbitalPeriod );

            if ( IsDefine ( exoplanet.OrbitalPeriodErrorMin ) )
                m_writer.WriteAttributeString ( "errorMin", exoplanet.OrbitalPeriodErrorMin );

            if ( IsDefine ( exoplanet.OrbitalPeriodErrorMax ) )
                m_writer.WriteAttributeString ( "errorMax", exoplanet.OrbitalPeriodErrorMax );

            m_writer.WriteEndElement ( );
            }

        static private void WriteSemiMajorAxis ( CExoplanet exoplanet )
            {
            m_writer.WriteStartElement ( "SemiMajorAxis" );

            if ( IsDefine ( exoplanet.SemiMajorAxis ) )
                m_writer.WriteAttributeString ( "semiMajorAxis", exoplanet.SemiMajorAxis );

            if ( IsDefine ( exoplanet.SemiMajorAxisErrorMin ) )
                m_writer.WriteAttributeString ( "errorMin", exoplanet.SemiMajorAxisErrorMin );

            if ( IsDefine ( exoplanet.SemiMajorAxisErrorMax ) )
                m_writer.WriteAttributeString ( "errorMax", exoplanet.SemiMajorAxisErrorMax );

            m_writer.WriteEndElement ( );
            }

        static private void WriteEccentricity ( CExoplanet exoplanet )
            {
            m_writer.WriteStartElement ( "Eccentricity" );

            if ( IsDefine ( exoplanet.Eccentricity ) )
                m_writer.WriteAttributeString ( "eccentricity", exoplanet.Eccentricity );

            if ( IsDefine ( exoplanet.EccentricityErrorMin ) )
                m_writer.WriteAttributeString ( "errorMin", exoplanet.EccentricityErrorMin );

            if ( IsDefine ( exoplanet.EccentricityErrorMax ) )
                m_writer.WriteAttributeString ( "errorMax", exoplanet.EccentricityErrorMax );

            m_writer.WriteEndElement ( );
            }

        static private void WriteAngularDistance ( CExoplanet exoplanet )
            {
            m_writer.WriteStartElement ( "AngularDistance" );

            if ( IsDefine ( exoplanet.AngularDistance ) )
                m_writer.WriteAttributeString ( "angularDistance", exoplanet.AngularDistance );

            m_writer.WriteEndElement ( );
            }

        static private void WriteInclination ( CExoplanet exoplanet )
            {
            m_writer.WriteStartElement ( "Inclination" );

            if ( IsDefine ( exoplanet.Inclination ) )
                m_writer.WriteAttributeString ( "inclination", exoplanet.Inclination );

            if ( IsDefine ( exoplanet.InclinationErrorMin ) )
                m_writer.WriteAttributeString ( "errorMin", exoplanet.InclinationErrorMin );

            if ( IsDefine ( exoplanet.InclinationErrorMax ) )
                m_writer.WriteAttributeString ( "errorMax", exoplanet.InclinationErrorMax );

            m_writer.WriteEndElement ( );
            }

        static private void WriteTzeroTr ( CExoplanet exoplanet )
            {
            m_writer.WriteStartElement ( "TzeroTr" );

            if ( IsDefine ( exoplanet.TzeroTr ) )
                m_writer.WriteAttributeString ( "tzero_tr", exoplanet.TzeroTr );

            if ( IsDefine ( exoplanet.TzeroTrErrorMin ) )
                m_writer.WriteAttributeString ( "errorMin", exoplanet.TzeroTrErrorMin );

            if ( IsDefine ( exoplanet.TzeroTrErrorMax ) )
                m_writer.WriteAttributeString ( "errorMax", exoplanet.TzeroTrErrorMax );

            m_writer.WriteEndElement ( );
            }

        static private void WriteTzeroTrSec ( CExoplanet exoplanet )
            {
            m_writer.WriteStartElement ( "TzeroTrSec" );

            if ( IsDefine ( exoplanet.TzeroTrSec ) )
                m_writer.WriteAttributeString ( "tzero_trSec", exoplanet.TzeroTrSec );

            if ( IsDefine ( exoplanet.TzeroTrSecErrorMin ) )
                m_writer.WriteAttributeString ( "errorMin", exoplanet.TzeroTrSecErrorMin );

            if ( IsDefine ( exoplanet.TzeroTrSecErrorMax ) )
                m_writer.WriteAttributeString ( "errorMax", exoplanet.TzeroTrSecErrorMax );

            m_writer.WriteEndElement ( );
            }

        static private void WriteLambdaAngle ( CExoplanet exoplanet )
            {
            m_writer.WriteStartElement ( "LambdaAngle" );

            if ( IsDefine ( exoplanet.LambdaAngle ) )
                m_writer.WriteAttributeString ( "lambdaAngle", exoplanet.LambdaAngle );

            if ( IsDefine ( exoplanet.LambdaAngleErrorMin ) )
                m_writer.WriteAttributeString ( "errorMin", exoplanet.LambdaAngleErrorMin );

            if ( IsDefine ( exoplanet.LambdaAngleErrorMax ) )
                m_writer.WriteAttributeString ( "errorMax", exoplanet.LambdaAngleErrorMax );

            m_writer.WriteEndElement ( );
            }

        static private void WriteTzeroVr ( CExoplanet exoplanet )
            {
            m_writer.WriteStartElement ( "TzeroVr" );

            if ( IsDefine ( exoplanet.TzeroVr ) )
                m_writer.WriteAttributeString ( "tzero_vr", exoplanet.TzeroVr );

            if ( IsDefine ( exoplanet.TzeroVrErrorMin ) )
                m_writer.WriteAttributeString ( "errorMin", exoplanet.TzeroVrErrorMin );

            if ( IsDefine ( exoplanet.TzeroVrErrorMax ) )
                m_writer.WriteAttributeString ( "errorMax", exoplanet.TzeroVrErrorMax );

            m_writer.WriteEndElement ( );
            }

        static private void WriteTemperature ( CExoplanet exoplanet )
            {
            m_writer.WriteStartElement ( "Temperature" );

            if ( IsDefine ( exoplanet.TemperatureCalculated ) )
                m_writer.WriteAttributeString ( "Calculated", exoplanet.TemperatureCalculated );

            if ( IsDefine ( exoplanet.TemperatureMeasured ) )
                m_writer.WriteAttributeString ( "Measured", exoplanet.TemperatureMeasured );

            if ( IsDefine ( exoplanet.TemperatureHotPointLo ) )
                m_writer.WriteAttributeString ( "HotPointLon", exoplanet.TemperatureHotPointLo );

            m_writer.WriteEndElement ( );
            }

        static private void WriteLogG ( CExoplanet exoplanet )
            {
            m_writer.WriteStartElement ( "LogG" );

            if ( IsDefine ( exoplanet.LogG ) )
                m_writer.WriteAttributeString ( "logG", exoplanet.LogG );

            m_writer.WriteEndElement ( );
            }

        static private void WritePublicationStatus ( CExoplanet exoplanet )
            {
            m_writer.WriteStartElement ( "PublicationStatus" );

            if ( IsDefine ( exoplanet.Status ) )
                m_writer.WriteAttributeString ( "Status", exoplanet.Status );

            m_writer.WriteEndElement ( );
            }

        static private void WriteDiscovered ( CExoplanet exoplanet )
            {
            m_writer.WriteStartElement ( "Discovered" );

            if ( IsDefine ( exoplanet.Discovered ) )
                m_writer.WriteAttributeString ( "discovered", exoplanet.Discovered );

            m_writer.WriteEndElement ( );
            }

        static private void WriteUpdated ( CExoplanet exoplanet )
            {
            m_writer.WriteStartElement ( "Updated" );

            if ( IsDefine ( exoplanet.Updated ) )
                m_writer.WriteAttributeString ( "updated", exoplanet.Updated );

            m_writer.WriteEndElement ( );
            }

        static private void WriteOmega ( CExoplanet exoplanet )
            {
            m_writer.WriteStartElement ( "Omega" );

            if ( IsDefine ( exoplanet.Omega ) )
                m_writer.WriteAttributeString ( "Omega", exoplanet.Omega );

            if ( IsDefine ( exoplanet.OmegaErrorMin ) )
                m_writer.WriteAttributeString ( "errorMin", exoplanet.OmegaErrorMin );

            if ( IsDefine ( exoplanet.OmegaErrorMax ) )
                m_writer.WriteAttributeString ( "errorMax", exoplanet.OmegaErrorMax );

            m_writer.WriteEndElement ( );
            }

        static private void WriteTperi ( CExoplanet exoplanet )
            {
            m_writer.WriteStartElement ( "Tperi" );

            if ( IsDefine ( exoplanet.Tperi ) )
                m_writer.WriteAttributeString ( "tperi", exoplanet.Tperi );

            if ( IsDefine ( exoplanet.TperiErrorMin ) )
                m_writer.WriteAttributeString ( "errorMin", exoplanet.TperiErrorMin );

            if ( IsDefine ( exoplanet.TperiErrorMax ) )
                m_writer.WriteAttributeString ( "errorMax", exoplanet.TperiErrorMax );

            m_writer.WriteEndElement ( );
            }

        static private void WriteDetectionType ( CExoplanet exoplanet )
            {
            m_writer.WriteStartElement ( "DetectionType" );

            if ( IsDefine ( exoplanet.DetectionType ) )
                m_writer.WriteAttributeString ( "Type", exoplanet.DetectionType );

            m_writer.WriteEndElement ( );
            }

        static private void WriteMolecules ( CExoplanet exoplanet )
            {
            m_writer.WriteStartElement ( "Molecules" );

            if ( IsDefine ( exoplanet.Molecules ) )
                m_writer.WriteAttributeString ( "molecules", exoplanet.Molecules );

            m_writer.WriteEndElement ( );
            }

        static private void WriteImpactParameter ( CExoplanet exoplanet )
            {
            if ( string.Equals ( m_version, "2.0" ) )
                {
                m_writer.WriteStartElement ( "ImpactParameter" );

                if ( IsDefine ( exoplanet.ImpactParameter ) )
                    m_writer.WriteAttributeString ( "impactParameter", exoplanet.ImpactParameter );

                if ( IsDefine ( exoplanet.ImpactParameterErrorMin ) )
                    m_writer.WriteAttributeString ( "errorMin", exoplanet.ImpactParameterErrorMin );

                if ( IsDefine ( exoplanet.ImpactParameterErrorMax ) )
                    m_writer.WriteAttributeString ( "errorMax", exoplanet.ImpactParameterErrorMax );

                m_writer.WriteEndElement ( );
                }
            }

        static private void WriteK ( CExoplanet exoplanet )
            {
            if ( string.Equals ( m_version, "2.0" ) )
                {
                m_writer.WriteStartElement ( "K" );

                if ( IsDefine ( exoplanet.K ) )
                    m_writer.WriteAttributeString ( "k", exoplanet.K );

                if ( IsDefine ( exoplanet.KErrorMin ) )
                    m_writer.WriteAttributeString ( "errorMin", exoplanet.KErrorMin );

                if ( IsDefine ( exoplanet.KErrorMax ) )
                    m_writer.WriteAttributeString ( "errorMax", exoplanet.KErrorMax );

                m_writer.WriteEndElement ( );
                }
            }

        static private void WriteGeometricAlbedo ( CExoplanet exoplanet )
            {
            if ( string.Equals ( m_version, "2.0" ) )
                {
                m_writer.WriteStartElement ( "GeometricAlbedo" );

                if ( IsDefine ( exoplanet.GeometricAlbedo ) )
                    m_writer.WriteAttributeString ( "geometricAlbedo", exoplanet.GeometricAlbedo );

                if ( IsDefine ( exoplanet.GeometricAlbedoErrorMin ) )
                    m_writer.WriteAttributeString ( "errorMin", exoplanet.GeometricAlbedoErrorMin );

                if ( IsDefine ( exoplanet.GeometricAlbedoErrorMax ) )
                    m_writer.WriteAttributeString ( "errorMax", exoplanet.GeometricAlbedoErrorMax );

                m_writer.WriteEndElement ( );
                }
            }

        static private void WriteTconj ( CExoplanet exoplanet )
            {
            if ( string.Equals ( m_version, "2.0" ) )
                {
                m_writer.WriteStartElement ( "Tconj" );

                if ( IsDefine ( exoplanet.Tconj ) )
                    m_writer.WriteAttributeString ( "tconj", exoplanet.Tconj );

                if ( IsDefine ( exoplanet.TconjErrorMin ) )
                    m_writer.WriteAttributeString ( "errorMin", exoplanet.TconjErrorMin );

                if ( IsDefine ( exoplanet.TconjErrorMax ) )
                    m_writer.WriteAttributeString ( "errorMax", exoplanet.TconjErrorMax );

                m_writer.WriteEndElement ( );
                }
            }

        static private void WriteMassDetectionType ( CExoplanet exoplanet )
            {
            if ( string.Equals ( m_version, "2.0" ) )
                {
                m_writer.WriteStartElement ( "MassDetectionType" );

                if ( IsDefine ( exoplanet.MassDetectionType ) )
                    m_writer.WriteAttributeString ( "massDetectionType", exoplanet.MassDetectionType );

                m_writer.WriteEndElement ( );
                }
            }

        static private void WriteRadiusDetectionType ( CExoplanet exoplanet )
            {
            if ( string.Equals ( m_version, "2.0" ) )
                {
                m_writer.WriteStartElement ( "RadiusDetectionType" );

                if ( IsDefine ( exoplanet.RadiusDetectionType ) )
                    m_writer.WriteAttributeString ( "radiusDetectionType", exoplanet.RadiusDetectionType );

                m_writer.WriteEndElement ( );
                }
            }

        static private void WriteAlternateNames ( CExoplanet exoplanet )
            {
            if ( string.Equals ( m_version, "2.0" ) )
                {
                m_writer.WriteStartElement ( "AlternateNames" );

                if ( IsDefine ( exoplanet.AlternateNames ) )
                    m_writer.WriteAttributeString ( "alternateNames", exoplanet.AlternateNames );

                m_writer.WriteEndElement ( );
                }
            }

        static private void WriteStar ( CExoplanet exoplanet )
            {
            m_writer.WriteStartElement ( "Star" );

            m_writer.WriteAttributeString ( "Name", exoplanet.Star.Name );
            m_writer.WriteAttributeString ( "ra", exoplanet.Star.RightAccession );
            m_writer.WriteAttributeString ( "dec", exoplanet.Star.Declination );

            WriteMagnitudes ( exoplanet );
            WriteProperties ( exoplanet );

            m_writer.WriteEndElement ( );
            }

        static private void WriteMagnitudes ( CExoplanet exoplanet )
            {
            m_writer.WriteStartElement ( "Magnitudes" );

            if ( IsDefine ( exoplanet.Star.Magnitudes.V ) )
                m_writer.WriteAttributeString ( "V", exoplanet.Star.Magnitudes.V );

            if ( IsDefine ( exoplanet.Star.Magnitudes.I ) )
                m_writer.WriteAttributeString ( "I", exoplanet.Star.Magnitudes.I );

            if ( IsDefine ( exoplanet.Star.Magnitudes.J ) )
                m_writer.WriteAttributeString ( "J", exoplanet.Star.Magnitudes.J );

            if ( IsDefine ( exoplanet.Star.Magnitudes.H ) )
                m_writer.WriteAttributeString ( "H", exoplanet.Star.Magnitudes.H );

            if ( IsDefine ( exoplanet.Star.Magnitudes.K ) )
                m_writer.WriteAttributeString ( "K", exoplanet.Star.Magnitudes.K );

            m_writer.WriteEndElement ( );
            }

        static private void WriteProperties ( CExoplanet exoplanet )
            {
            m_writer.WriteStartElement ( "Properties" );

            if ( IsDefine ( exoplanet.Star.Properties.Distance ) )
                m_writer.WriteAttributeString ( "Distance", exoplanet.Star.Properties.Distance );

            if ( IsDefine ( exoplanet.Star.Properties.Metallicity ) )
                m_writer.WriteAttributeString ( "Metallicity", exoplanet.Star.Properties.Metallicity );

            if ( IsDefine ( exoplanet.Star.Properties.Mass ) )
                m_writer.WriteAttributeString ( "Mass", exoplanet.Star.Properties.Mass );

            if ( IsDefine ( exoplanet.Star.Properties.Radius ) )
                m_writer.WriteAttributeString ( "Radius", exoplanet.Star.Properties.Radius );

            if ( IsDefine ( exoplanet.Star.Properties.SPType ) )
                m_writer.WriteAttributeString ( "SPType", exoplanet.Star.Properties.SPType );

            if ( IsDefine ( exoplanet.Star.Properties.Age ) )
                m_writer.WriteAttributeString ( "Age", exoplanet.Star.Properties.Age );

            if ( IsDefine ( exoplanet.Star.Properties.Teff ) )
                m_writer.WriteAttributeString ( "Teff", exoplanet.Star.Properties.Teff );

            if ( string.Equals ( m_version, "2.0" ) )
                {
                if ( IsDefine ( exoplanet.Star.Properties.DetectedDisc ) )
                    m_writer.WriteAttributeString ( "DetectedDisc", exoplanet.Star.Properties.DetectedDisc );

                if ( IsDefine ( exoplanet.Star.Properties.MagneticField ) )
                    m_writer.WriteAttributeString ( "MagneticField", exoplanet.Star.Properties.MagneticField );
                }

            m_writer.WriteEndElement ( );
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