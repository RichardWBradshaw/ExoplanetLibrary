using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Windows.Forms;
using System.Collections;

namespace ExoplanetLibrary
    {
    public class CMagnitudes
        {
        public string V;
        public string I;
        public string J;
        public string H;
        public string K;
        };

    public class CProperties
        {
        private string m_distance;
        public string Distance
            {
            get
                {
                return m_distance;
                }
            set
                {
                m_distance = value;
                }
            }

        private string m_metallicity;
        public string Metallicity
            {
            get
                {
                return m_metallicity;
                }
            set
                {
                m_metallicity = value;
                }
            }

        private string m_mass;
        public string Mass
            {
            get
                {
                return m_mass;
                }
            set
                {
                m_mass = value;
                }
            }

        private string m_radius;
        public string Radius
            {
            get
                {
                return m_radius;
                }
            set
                {
                m_radius = value;
                }
            }

        private string m_SPType;
        public string SPType
            {
            get
                {
                return m_SPType;
                }
            set
                {
                m_SPType = value;
                }
            }

        private string m_age;
        public string Age
            {
            get
                {
                return m_age;
                }
            set
                {
                m_age = value;
                }
            }

        private string m_teff;
        public string Teff
            {
            get
                {
                return m_teff;
                }
            set
                {
                m_teff = value;
                }
            }

        private string m_detectedDisc;
        public string DetectedDisc
            {
            get
                {
                return m_detectedDisc;
                }
            set
                {
                m_detectedDisc = value;
                }
            }

        private string m_magneticField;
        public string MagneticField
            {
            get
                {
                return m_magneticField;
                }
            set
                {
                m_magneticField = value;
                }
            }
        };

    public class CStar
        {
        private string m_name;
        public string Name
            {
            get
                {
                return m_name;
                }
            set
                {
                m_name = value;
                }
            }

        private string m_rightAccession;
        public string RightAccession
            {
            get
                {
                return m_rightAccession;
                }
            set
                {
                m_rightAccession = value;
                }
            }

        private string m_declination;
        public string Declination
            {
            get
                {
                return m_declination;
                }
            set
                {
                m_declination = value;
                }
            }

        private CMagnitudes m_magnitudes;
        public CMagnitudes Magnitudes
            {
            get
                {
                return m_magnitudes;
                }
            set
                {
                m_magnitudes = value;
                }
            }

        private CProperties m_properties;
        public CProperties Properties
            {
            get
                {
                return m_properties;
                }
            set
                {
                m_properties = value;
                }
            }

        public CStar ( )
            {
            Magnitudes = new CMagnitudes ( );
            Properties = new CProperties ( );
            }
        };

    /****
http://exoplanet.eu/readme//
Data
Planet data
Planet data are the latest data known. They are taken from:
Latest published papers or professional preprints and conferences
First-hand updated data on professional websites. These presently are:
 Anglo-Australian Planet Search
California & Carnegie Planet Search
Geneva Extrasolar Planet Search Programmes
Transatlantic Exoplanet Survey
University of Texas - Dept. of Astronomy
HAT and HATS
WASP
NASA Exoplanet Archive
Kepler

Planet parameters :
    Mass (MJup/MEarth) : mass of the planet
    soon coming Msini (MJup/MEarth) : minimum mass of the planet due to inclination effect
    Radius (RJup/Rearth) : radius of the planet
    Period (day) : orbital period of the planet
    a (AU) : semi-major axis of the planet orbit
    e : eccentrity of the planet orbit from 0, circular orbit, to almost 1, very elongated orbit
    i (deg) : inclination of planet orbit, angle between the planet orbit and the sky plane 
    Ang. dist.(arcsec) : formal star-planet angular separation given by a/Distance
    Discovery : year of discovery at the time of acceptance of a paper
    Update : date of the update of data
    ω (deg) : periapse longitude : angle between the periapse and the line nodes in the orbit plane
    Tperi (JD) : time of passage at the periapse for eccentric orbits
    Tconj(JD) : time of the star-planet upper conjunction 
    T0 (JD) : time of passage at the center of the transit light curve for the primary transit
    T0-sec (JD) : time of passage at the center of the transit light curve for the secondary transit
    λ Ang. (deg) :  sky-projected angle between the planetary orbital spin and the stellar rotational spin (Rossiter-McLaughlin anomaly).
    Impact Param b (%) : minimum, in stellar radius units, of distance of the planet to the stellar center for transiting planets 
    TVR (JD) : time of zero, increasing, radial velocity (i.e. when the planet moves toward the observer) for circular orbits 
    K (m/s) :semi-amplitude of the radial velocity curve
    Tcalc (K) :planet temperature as calculated by authors, based on a planet model
    Tmeas (K) : planet temperature as measured by authors
    Hot pt (deg) : longitude of the planet hottest point
    Ag : Albedo
    Log(g) : Surface gravity
    Disc./Det Method : Methods of discovery/detection of the planet (RV, transit, TTV, lensing, astrometry, imaging. The first method is the discovery one.
    Mass Meas method : Method of measurement of the planet mass (RV, astrometry, planet model for direct imaging)
    Radius Meas method : Method of measurement of the planet radius (transit, 
    planet model for direct imaging)
    Alternate names : alternatives names of the same planet
    Molecules : Species detected in the planet

    Number of planets in the system :

Stellar data
Stellar data (positions, distances, V mag, mass, metallicities etc) are taken from Simbad or from professional papers on exoplanets.
Stellar parameters :
    Star name :
    α2000 (hh :mm :ss) : Right Ascension
    δ2000 (hh :mm :ss) : Declination
    mV : apparent magnitude in the V band
    mI : apparent magnitude in the I band
    mJ : apparent magnitude in the J band
    mH : apparent magnitude in the H band
    mK : apparent magnitude in the K band
    Distance (pc) : distance of the star to the observer
    Metallicity : decimal logarithm of the massive elements (« metals ») to hydrogen ratio in solar units  (i.e. Log [(metals/H)star/(metals/H)Sun] )
    Mass (Msun) : star mas in solar units
    Radius (Rsun) : star radius in solar units
    Sp. Type : stellar spectral type
    Age (Gy) : stellar age
    Teff : effective stellar temperature  
    Detected disc :  (direct imaging or IR excess) disc detected
    Magnetic field (Yes/No) : stellar magnetic field detected

◦Errors
When a value is known only by its maximum or minimum its prefix is « < » or « > ». e.g. : < 89.9 or > 0.067.
*****/

    public class CExoplanet
        {
        private string m_name;

        public string Name
            {
            get
                {
                return m_name;
                }
            set
                {
                m_name = value;
                }
            }

        private string m_mass;
        public string Mass
            {
            get
                {
                return m_mass;
                }
            set
                {
                m_mass = value;
                }
            }

        private string m_massErrorMin;
        public string MassErrorMin
            {
            get
                {
                return m_massErrorMin;
                }
            set
                {
                m_massErrorMin = value;
                }
            }

        private string m_massErrorMax;
        public string MassErrorMax
            {
            get
                {
                return m_massErrorMax;
                }
            set
                {
                m_massErrorMax = value;
                }
            }

        private string m_radius;
        public string Radius
            {
            get
                {
                return m_radius;
                }
            set
                {
                m_radius = value;
                }
            }

        private string m_radiusErrorMin;
        public string RadiusErrorMin
            {
            get
                {
                return m_radiusErrorMin;
                }
            set
                {
                m_radiusErrorMin = value;
                }
            }

        private string m_radiusErrorMax;
        public string RadiusErrorMax
            {
            get
                {
                return m_radiusErrorMax;
                }
            set
                {
                m_radiusErrorMax = value;
                }
            }

        private string m_orbitalPeriod;
        public string OrbitalPeriod
            {
            get
                {
                return m_orbitalPeriod;
                }
            set
                {
                m_orbitalPeriod = value;
                }
            }

        private string m_orbitalPeriodErrorMin;
        public string OrbitalPeriodErrorMin
            {
            get
                {
                return m_orbitalPeriodErrorMin;
                }
            set
                {
                m_orbitalPeriodErrorMin = value;
                }
            }

        private string m_orbitalPeriodErrorMax;
        public string OrbitalPeriodErrorMax
            {
            get
                {
                return m_orbitalPeriodErrorMax;
                }
            set
                {
                m_orbitalPeriodErrorMax = value;
                }
            }

        private string m_semiMajorAxis;
        public string SemiMajorAxis
            {
            get
                {
                return m_semiMajorAxis;
                }
            set
                {
                m_semiMajorAxis = value;
                }
            }

        private string m_semiMajorAxisErrorMin;
        public string SemiMajorAxisErrorMin
            {
            get
                {
                return m_semiMajorAxisErrorMin;
                }
            set
                {
                m_semiMajorAxisErrorMin = value;
                }
            }

        private string m_semiMajorAxisErrorMax;
        public string SemiMajorAxisErrorMax
            {
            get
                {
                return m_semiMajorAxisErrorMax;
                }
            set
                {
                m_semiMajorAxisErrorMax = value;
                }
            }

        private string m_eccentricity;
        public string Eccentricity
            {
            get
                {
                return m_eccentricity;
                }
            set
                {
                m_eccentricity = value;
                }
            }

        private string m_eccentricityErrorMin;
        public string EccentricityErrorMin
            {
            get
                {
                return m_eccentricityErrorMin;
                }
            set
                {
                m_eccentricityErrorMin = value;
                }
            }

        private string m_eccentricityErrorMax;
        public string EccentricityErrorMax
            {
            get
                {
                return m_eccentricityErrorMax;
                }
            set
                {
                m_eccentricityErrorMax = value;
                }
            }

        private string m_angularDistance;
        public string AngularDistance
            {
            get
                {
                return m_angularDistance;
                }
            set
                {
                m_angularDistance = value;
                }
            }

        private string m_inclination;
        public string Inclination
            {
            get
                {
                return m_inclination;
                }
            set
                {
                m_inclination = value;
                }
            }

        private string m_inclinationErrorMin;
        public string InclinationErrorMin
            {
            get
                {
                return m_inclinationErrorMin;
                }
            set
                {
                m_inclinationErrorMin = value;
                }
            }

        private string m_inclinationErrorMax;
        public string InclinationErrorMax
            {
            get
                {
                return m_inclinationErrorMax;
                }
            set
                {
                m_inclinationErrorMax = value;
                }
            }

        private string m_tzeroTr;
        public string TzeroTr
            {
            get
                {
                return m_tzeroTr;
                }
            set
                {
                m_tzeroTr = value;
                }
            }
        private string m_zeroTrErrorMin;
        public string TzeroTrErrorMin
            {
            get
                {
                return m_zeroTrErrorMin;
                }
            set
                {
                m_zeroTrErrorMin = value;
                }
            }

        private string m_zeroTrErrorMax;
        public string TzeroTrErrorMax
            {
            get
                {
                return m_zeroTrErrorMax;
                }
            set
                {
                m_zeroTrErrorMax = value;
                }
            }

        private string m_tzeroTrSec;
        public string TzeroTrSec
            {
            get
                {
                return m_tzeroTrSec;
                }
            set
                {
                m_tzeroTrSec = value;
                }
            }

        private string m_tzeroTrSecErrorMin;
        public string TzeroTrSecErrorMin
            {
            get
                {
                return m_tzeroTrSecErrorMin;
                }
            set
                {
                m_tzeroTrSecErrorMin = value;
                }
            }

        private string m_tzeroTrSecErrorMax;
        public string TzeroTrSecErrorMax
            {
            get
                {
                return m_tzeroTrSecErrorMax;
                }
            set
                {
                m_tzeroTrSecErrorMax = value;
                }
            }

        private string m_lambdaAngle;
        public string LambdaAngle
            {
            get
                {
                return m_lambdaAngle;
                }
            set
                {
                m_lambdaAngle = value;
                }
            }
        private string m_lambdaAngleErrorMin;
        public string LambdaAngleErrorMin
            {
            get
                {
                return m_lambdaAngleErrorMin;
                }
            set
                {
                m_lambdaAngleErrorMin = value;
                }
            }

        private string m_lambdaAngleErrorMax;
        public string LambdaAngleErrorMax
            {
            get
                {
                return m_lambdaAngleErrorMax;
                }
            set
                {
                m_lambdaAngleErrorMax = value;
                }
            }

        private string m_tzeroVr;
        public string TzeroVr
            {
            get
                {
                return m_tzeroVr;
                }
            set
                {
                m_tzeroVr = value;
                }
            }

        private string m_tzeroVrErrorMin;
        public string TzeroVrErrorMin
            {
            get
                {
                return m_tzeroVrErrorMin;
                }
            set
                {
                m_tzeroVrErrorMin = value;
                }
            }

        private string m_tzeroVrErrorMax;
        public string TzeroVrErrorMax
            {
            get
                {
                return m_tzeroVrErrorMax;
                }
            set
                {
                m_tzeroVrErrorMax = value;
                }
            }

        private string m_temperatureCalculated;
        public string TemperatureCalculated
            {
            get
                {
                return m_temperatureCalculated;
                }
            set
                {
                m_temperatureCalculated = value;
                }
            }

        private string m_temperatureMeasured;
        public string TemperatureMeasured
            {
            get
                {
                return m_temperatureMeasured;
                }
            set
                {
                m_temperatureMeasured = value;
                }
            }

        private string m_temperatureHotPointLo;
        public string TemperatureHotPointLo
            {
            get
                {
                return m_temperatureHotPointLo;
                }
            set
                {
                m_temperatureHotPointLo = value;
                }
            }

        private string m_logG;
        public string LogG
            {
            get
                {
                return m_logG;
                }
            set
                {
                m_logG = value;
                }
            }

        private string m_status;
        public string Status
            {
            get
                {
                return m_status;
                }
            set
                {
                m_status = value;
                }
            }

        private string m_discovered;
        public string Discovered
            {
            get
                {
                return m_discovered;
                }
            set
                {
                m_discovered = value;
                }
            }

        private string m_updated;
        public string Updated
            {
            get
                {
                return m_updated;
                }
            set
                {
                m_updated = value;
                }
            }

        private string m_omega;
        public string Omega
            {
            get
                {
                return m_omega;
                }
            set
                {
                m_omega = value;
                }
            }

        private string m_omegaErrorMin;
        public string OmegaErrorMin
            {
            get
                {
                return m_omegaErrorMin;
                }
            set
                {
                m_omegaErrorMin = value;
                }
            }

        private string m_omegaErrorMax;
        public string OmegaErrorMax
            {
            get
                {
                return m_omegaErrorMax;
                }
            set
                {
                m_omegaErrorMax = value;
                }
            }

        private string m_tperi;
        public string Tperi
            {
            get
                {
                return m_tperi;
                }
            set
                {
                m_tperi = value;
                }
            }

        private string m_tperiErrorMin;
        public string TperiErrorMin
            {
            get
                {
                return m_tperiErrorMin;
                }
            set
                {
                m_tperiErrorMin = value;
                }
            }

        private string m_tperiErrorMax;
        public string TperiErrorMax
            {
            get
                {
                return m_tperiErrorMax;
                }
            set
                {
                m_tperiErrorMax = value;
                }
            }

        private string m_detectionType;
        public string DetectionType
            {
            get
                {
                return m_detectionType;
                }
            set
                {
                m_detectionType = value;
                }
            }

        private string m_molecules;
        public string Molecules
            {
            get
                {
                return m_molecules;
                }
            set
                {
                m_molecules = value;
                }
            }

        private string m_impactParameter;
        public string ImpactParameter
            {
            get
                {
                return m_impactParameter;
                }
            set
                {
                m_impactParameter = value;
                }
            }

        private string m_impactParameterErrorMin;
        public string ImpactParameterErrorMin
            {
            get
                {
                return m_impactParameterErrorMin;
                }
            set
                {
                m_impactParameterErrorMin = value;
                }
            }

        private string m_impactParameterErrorMax;
        public string ImpactParameterErrorMax
            {
            get
                {
                return m_impactParameterErrorMax;
                }
            set
                {
                m_impactParameterErrorMax = value;
                }
            }

        private string m_k;
        public string K
            {
            get
                {
                return m_k;
                }
            set
                {
                m_k = value;
                }
            }

        private string m_kErrorMin;
        public string KErrorMin
            {
            get
                {
                return m_kErrorMin;
                }
            set
                {
                m_kErrorMin = value;
                }
            }

        private string m_kErrorMax;
        public string KErrorMax
            {
            get
                {
                return m_kErrorMax;
                }
            set
                {
                m_kErrorMax = value;
                }
            }

        private string m_geometricAlbedo;
        public string GeometricAlbedo
            {
            get
                {
                return m_geometricAlbedo;
                }
            set
                {
                m_geometricAlbedo = value;
                }
            }

        private string m_geometricAlbedoErrorMin;
        public string GeometricAlbedoErrorMin
            {
            get
                {
                return m_geometricAlbedoErrorMin;
                }
            set
                {
                m_geometricAlbedoErrorMin = value;
                }
            }

        private string m_geometricAlbedoErrorMax;
        public string GeometricAlbedoErrorMax
            {
            get
                {
                return m_geometricAlbedoErrorMax;
                }
            set
                {
                m_geometricAlbedoErrorMax = value;
                }
            }

        private string m_tconj;
        public string Tconj
            {
            get
                {
                return m_tconj;
                }
            set
                {
                m_tconj = value;
                }
            }

        private string m_tconjErrorMin;
        public string TconjErrorMin
            {
            get
                {
                return m_tconjErrorMin;
                }
            set
                {
                m_tconjErrorMin = value;
                }
            }

        private string m_tconjErrorMax;
        public string TconjErrorMax
            {
            get
                {
                return m_tconjErrorMax;
                }
            set
                {
                m_tconjErrorMax = value;
                }
            }

        private string m_massDetectionType;
        public string MassDetectionType
            {
            get
                {
                return m_massDetectionType;
                }
            set
                {
                m_massDetectionType = value;
                }
            }

        private string m_radiusDetectionType;
        public string RadiusDetectionType
            {
            get
                {
                return m_radiusDetectionType;
                }
            set
                {
                m_radiusDetectionType = value;
                }
            }

        private string m_alternateNames;
        public string AlternateNames
            {
            get
                {
                return m_alternateNames;
                }
            set
                {
                m_alternateNames = value;
                }
            }

        private CStar m_star;
        public CStar Star
            {
            get
                {
                return m_star;
                }
            set
                {
                m_star = value;
                }
            }

        public CExoplanet ( )
            {
            m_star = new CStar ( );
            }
        };

    class ReadXML : CExoplanet
        {
        static XmlReader m_reader = null;

        static private string m_version = "2.0";
        static string m_xsdVersion1FileName = "C:\\ProgramData\\Exoplanet Library\\schema\\EXOPLANET.V.1.xsd";
        static string m_xsdVersion2FileName = "C:\\ProgramData\\Exoplanet Library\\schema\\EXOPLANET.xsd";
        static string m_validationErrors = "";

        static private void SetVersion ( string xmlFileName )
            {
            if ( System.IO.File.Exists ( xmlFileName ) )
                {
                m_reader = XmlReader.Create ( xmlFileName );
                m_reader.ReadToFollowing ( "Exoplanets" );
                m_reader.MoveToFirstAttribute ( );
                m_version = m_reader.Value;
                m_reader.Close ( );
                }
            }

        static public int Read ( string xmlFileName, ref ArrayList exoplanets )
            {
            m_validationErrors = "";

            exoplanets = new ArrayList ( );

            if ( System.IO.File.Exists ( xmlFileName ) )
                {
                SetVersion ( xmlFileName );

                FileStream fileStream = null;
                ValidationEventHandler validationEventHandler = new ValidationEventHandler ( exoplanetSettingsValidationEventHandler );
                XmlSchema xmlSchema = null;

                if ( System.IO.File.Exists ( @m_xsdVersion2FileName ) || System.IO.File.Exists ( @m_xsdVersion1FileName ) )
                    if ( string.Equals ( m_version, "2.0" ) )
                        xmlSchema = XmlSchema.Read ( ( fileStream = File.Open ( @m_xsdVersion2FileName, FileMode.Open ) ), validationEventHandler );
                    else if ( string.Equals ( m_version, "1.0" ) )
                        xmlSchema = XmlSchema.Read ( ( fileStream = File.Open ( @m_xsdVersion1FileName, FileMode.Open ) ), validationEventHandler );

                XmlReaderSettings settings = new XmlReaderSettings ( );
                settings.ConformanceLevel = ConformanceLevel.Document;
                settings.CheckCharacters = true;
                settings.IgnoreComments = true;
                settings.IgnoreWhitespace = true;
                settings.DtdProcessing = DtdProcessing.Ignore;

                if ( xmlSchema != null )
                    {
                    settings.ValidationType = ValidationType.Schema;
                    settings.ValidationFlags = XmlSchemaValidationFlags.ProcessInlineSchema;
                    settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
                    settings.Schemas.Add ( xmlSchema );
                    settings.ValidationEventHandler += new ValidationEventHandler ( exoplanetSettingsValidationEventHandler );
                    }
                else
                    settings.ValidationType = ValidationType.None;

                m_reader = XmlReader.Create ( xmlFileName, settings );

                while ( m_reader.Read ( ) )
                    {
                    CExoplanet exoplanet = new CExoplanet ( );

                    ReadExoplanet ( exoplanet );
                    ReadMass ( exoplanet );
                    ReadRadius ( exoplanet );
                    ReadOrbitalPeriod ( exoplanet );
                    ReadSemiMajorAxis ( exoplanet );
                    ReadEccentricity ( exoplanet );
                    ReadAngularDistance ( exoplanet );
                    ReadInclination ( exoplanet );
                    ReadTzeroTr ( exoplanet );
                    ReadTzeroTrSec ( exoplanet );
                    ReadLambdaAngle ( exoplanet );
                    ReadTzeroVr ( exoplanet );
                    ReadTemperature ( exoplanet );
                    ReadLogG ( exoplanet );
                    ReadPublicationStatus ( exoplanet );
                    ReadDiscovered ( exoplanet );
                    ReadUpdated ( exoplanet );
                    ReadOmega ( exoplanet );
                    ReadTperi ( exoplanet );
                    ReadDetectionType ( exoplanet );
                    ReadMolecules ( exoplanet );

                    if ( string.Equals ( m_version, "2.0" ) )
                        {
                        ReadImpactParameter ( exoplanet );
                        ReadK ( exoplanet );
                        ReadGeometricAlbedo ( exoplanet );
                        ReadTconj ( exoplanet );
                        ReadMassDetectionType ( exoplanet );
                        ReadRadiusDetectionType ( exoplanet );
                        ReadAlternateNames ( exoplanet );
                        }

                    ReadStar ( exoplanet );
                    ReadMagnitudes ( exoplanet );
                    ReadProperties ( exoplanet );

                    if ( !string.IsNullOrEmpty ( exoplanet.Name ) )
                        exoplanets.Add ( ( object )exoplanet );
                    }

                if ( fileStream != null )
                    fileStream.Close ( );

                m_reader.Close ( );
                }

            if ( m_validationErrors.Length > 0 )
                MessageBox.Show ( m_validationErrors );

            return 0;
            }

        static void ReadExoplanet ( CExoplanet exoplanet )
            {
            m_reader.ReadToFollowing ( "Exoplanet" );

            m_reader.MoveToFirstAttribute ( );
            exoplanet.Name = m_reader.Value;
            }

        static void ReadMass ( CExoplanet exoplanet )
            {
            m_reader.ReadToFollowing ( "Mass" );

            while ( m_reader.MoveToNextAttribute ( ) )
                {
                switch ( m_reader.Name )
                    {
                    case "mass":
                        exoplanet.Mass = m_reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.MassErrorMin = m_reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.MassErrorMax = m_reader.Value;
                        break;
                    }
                }
            }

        static void ReadRadius ( CExoplanet exoplanet )
            {
            m_reader.ReadToFollowing ( "Radius" );

            while ( m_reader.MoveToNextAttribute ( ) )
                {
                switch ( m_reader.Name )
                    {
                    case "radius":
                        exoplanet.Radius = m_reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.RadiusErrorMin = m_reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.RadiusErrorMax = m_reader.Value;
                        break;
                    }
                }
            }

        static void ReadOrbitalPeriod ( CExoplanet exoplanet )
            {
            m_reader.ReadToFollowing ( "OrbitalPeriod" );

            while ( m_reader.MoveToNextAttribute ( ) )
                {
                switch ( m_reader.Name )
                    {
                    case "orbitalPeriod":
                        exoplanet.OrbitalPeriod = m_reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.OrbitalPeriodErrorMin = m_reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.OrbitalPeriodErrorMax = m_reader.Value;
                        break;
                    }
                }
            }

        static void ReadSemiMajorAxis ( CExoplanet exoplanet )
            {
            m_reader.ReadToFollowing ( "SemiMajorAxis" );

            while ( m_reader.MoveToNextAttribute ( ) )
                {
                switch ( m_reader.Name )
                    {
                    case "semiMajorAxis":
                        exoplanet.SemiMajorAxis = m_reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.SemiMajorAxisErrorMin = m_reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.SemiMajorAxisErrorMax = m_reader.Value;
                        break;
                    }
                }
            }

        static void ReadEccentricity ( CExoplanet exoplanet )
            {
            m_reader.ReadToFollowing ( "Eccentricity" );

            while ( m_reader.MoveToNextAttribute ( ) )
                {
                switch ( m_reader.Name )
                    {
                    case "eccentricity":
                        exoplanet.Eccentricity = m_reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.EccentricityErrorMin = m_reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.EccentricityErrorMax = m_reader.Value;
                        break;
                    }
                }
            }

        static void ReadAngularDistance ( CExoplanet exoplanet )
            {
            m_reader.ReadToFollowing ( "AngularDistance" );
            m_reader.MoveToFirstAttribute ( );
            exoplanet.AngularDistance = m_reader.Value;
            }

        static void ReadInclination ( CExoplanet exoplanet )
            {
            m_reader.ReadToFollowing ( "Inclination" );

            while ( m_reader.MoveToNextAttribute ( ) )
                {
                switch ( m_reader.Name )
                    {
                    case "inclination":
                        exoplanet.Inclination = m_reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.InclinationErrorMin = m_reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.InclinationErrorMax = m_reader.Value;
                        break;
                    }
                }
            }

        static void ReadTzeroTr ( CExoplanet exoplanet )
            {
            m_reader.ReadToFollowing ( "TzeroTr" );

            while ( m_reader.MoveToNextAttribute ( ) )
                {
                switch ( m_reader.Name )
                    {
                    case "tzero_tr":
                        exoplanet.TzeroTr = m_reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.TzeroTrErrorMin = m_reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.TzeroTrErrorMax = m_reader.Value;
                        break;
                    }
                }
            }

        static void ReadTzeroTrSec ( CExoplanet exoplanet )
            {
            m_reader.ReadToFollowing ( "TzeroTrSec" );

            while ( m_reader.MoveToNextAttribute ( ) )
                {
                switch ( m_reader.Name )
                    {
                    case "tzero_trSec":
                        exoplanet.TzeroTrSec = m_reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.TzeroTrSecErrorMin = m_reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.TzeroTrSecErrorMax = m_reader.Value;
                        break;
                    }
                }
            }

        static void ReadLambdaAngle ( CExoplanet exoplanet )
            {
            m_reader.ReadToFollowing ( "LambdaAngle" );

            while ( m_reader.MoveToNextAttribute ( ) )
                {
                switch ( m_reader.Name )
                    {
                    case "lambdaAngle":
                        exoplanet.LambdaAngle = m_reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.LambdaAngleErrorMin = m_reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.LambdaAngleErrorMax = m_reader.Value;
                        break;
                    }
                }
            }

        static void ReadTzeroVr ( CExoplanet exoplanet )
            {
            m_reader.ReadToFollowing ( "TzeroVr" );

            while ( m_reader.MoveToNextAttribute ( ) )
                {
                switch ( m_reader.Name )
                    {
                    case "tzero_vr":
                        exoplanet.TzeroVr = m_reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.TzeroVrErrorMin = m_reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.TzeroVrErrorMax = m_reader.Value;
                        break;
                    }
                }
            }

        static void ReadTemperature ( CExoplanet exoplanet )
            {
            m_reader.ReadToFollowing ( "Temperature" );

            while ( m_reader.MoveToNextAttribute ( ) )
                {
                switch ( m_reader.Name )
                    {
                    case "Calculated":
                        exoplanet.TemperatureCalculated = m_reader.Value;
                        break;
                    case "Measured":
                        exoplanet.TemperatureMeasured = m_reader.Value;
                        break;
                    case "HotPointLon":
                        exoplanet.TemperatureHotPointLo = m_reader.Value;
                        break;
                    }
                }
            }

        static void ReadLogG ( CExoplanet exoplanet )
            {
            m_reader.ReadToFollowing ( "LogG" );
            m_reader.MoveToFirstAttribute ( );
            exoplanet.LogG = m_reader.Value;
            }

        static void ReadPublicationStatus ( CExoplanet exoplanet )
            {
            m_reader.ReadToFollowing ( "PublicationStatus" );
            m_reader.MoveToFirstAttribute ( );
            exoplanet.Status = m_reader.Value;
            }

        static void ReadDiscovered ( CExoplanet exoplanet )
            {
            m_reader.ReadToFollowing ( "Discovered" );
            m_reader.MoveToFirstAttribute ( );
            exoplanet.Discovered = m_reader.Value;
            }

        static void ReadUpdated ( CExoplanet exoplanet )
            {
            m_reader.ReadToFollowing ( "Updated" );
            m_reader.MoveToFirstAttribute ( );
            exoplanet.Updated = m_reader.Value;
            }

        static void ReadOmega ( CExoplanet exoplanet )
            {
            m_reader.ReadToFollowing ( "Omega" );

            while ( m_reader.MoveToNextAttribute ( ) )
                {
                switch ( m_reader.Name )
                    {
                    case "Omega":
                        exoplanet.Omega = m_reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.OmegaErrorMin = m_reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.OmegaErrorMax = m_reader.Value;
                        break;
                    }
                }
            }

        static void ReadTperi ( CExoplanet exoplanet )
            {
            m_reader.ReadToFollowing ( "Tperi" );

            while ( m_reader.MoveToNextAttribute ( ) )
                {
                switch ( m_reader.Name )
                    {
                    case "tperi":
                        exoplanet.Tperi = m_reader.Value;
                        break;
                    case "errorMin":
                        exoplanet.TperiErrorMin = m_reader.Value;
                        break;
                    case "errorMax":
                        exoplanet.TperiErrorMax = m_reader.Value;
                        break;
                    }
                }
            }

        static void ReadDetectionType ( CExoplanet exoplanet )
            {
            m_reader.ReadToFollowing ( "DetectionType" );
            m_reader.MoveToFirstAttribute ( );
            exoplanet.DetectionType = m_reader.Value;
            }

        static void ReadMolecules ( CExoplanet exoplanet )
            {
            m_reader.ReadToFollowing ( "Molecules" );
            m_reader.MoveToFirstAttribute ( );
            exoplanet.Molecules = m_reader.Value;
            }

        static void ReadImpactParameter ( CExoplanet exoplanet )
            {
            if ( string.Equals ( m_version, "2.0" ) )
                {
                m_reader.ReadToFollowing ( "ImpactParameter" );

                while ( m_reader.MoveToNextAttribute ( ) )
                    {
                    switch ( m_reader.Name )
                        {
                        case "impactParameter":
                            exoplanet.ImpactParameter = m_reader.Value;
                            break;
                        case "errorMin":
                            exoplanet.ImpactParameterErrorMin = m_reader.Value;
                            break;
                        case "errorMax":
                            exoplanet.ImpactParameterErrorMax = m_reader.Value;
                            break;
                        }
                    }
                }
            }

        static void ReadK ( CExoplanet exoplanet )
            {
            if ( string.Equals ( m_version, "2.0" ) )
                {
                m_reader.ReadToFollowing ( "K" );

                while ( m_reader.MoveToNextAttribute ( ) )
                    {
                    switch ( m_reader.Name )
                        {
                        case "k":
                            exoplanet.K = m_reader.Value;
                            break;
                        case "errorMin":
                            exoplanet.KErrorMin = m_reader.Value;
                            break;
                        case "errorMax":
                            exoplanet.KErrorMax = m_reader.Value;
                            break;
                        }
                    }
                }
            }

        static void ReadGeometricAlbedo ( CExoplanet exoplanet )
            {
            if ( string.Equals ( m_version, "2.0" ) )
                {
                m_reader.ReadToFollowing ( "GeometricAlbedo" );

                while ( m_reader.MoveToNextAttribute ( ) )
                    {
                    switch ( m_reader.Name )
                        {
                        case "geometricAlbedo":
                            exoplanet.GeometricAlbedo = m_reader.Value;
                            break;
                        case "errorMin":
                            exoplanet.GeometricAlbedoErrorMin = m_reader.Value;
                            break;
                        case "errorMax":
                            exoplanet.GeometricAlbedoErrorMax = m_reader.Value;
                            break;
                        }
                    }
                }
            }

        static void ReadTconj ( CExoplanet exoplanet )
            {
            if ( string.Equals ( m_version, "2.0" ) )
                {
                m_reader.ReadToFollowing ( "Tconj" );

                while ( m_reader.MoveToNextAttribute ( ) )
                    {
                    switch ( m_reader.Name )
                        {
                        case "tconj":
                            exoplanet.Tconj = m_reader.Value;
                            break;
                        case "errorMin":
                            exoplanet.TconjErrorMin = m_reader.Value;
                            break;
                        case "errorMax":
                            exoplanet.TconjErrorMax = m_reader.Value;
                            break;
                        }
                    }
                }
            }

        static void ReadMassDetectionType ( CExoplanet exoplanet )
            {
            if ( string.Equals ( m_version, "2.0" ) )
                {
                m_reader.ReadToFollowing ( "MassDetectionType" );
                m_reader.MoveToFirstAttribute ( );
                exoplanet.MassDetectionType = m_reader.Value;
                }
            }

        static void ReadRadiusDetectionType ( CExoplanet exoplanet )
            {
            if ( string.Equals ( m_version, "2.0" ) )
                {
                m_reader.ReadToFollowing ( "RadiusDetectionType" );
                m_reader.MoveToFirstAttribute ( );
                exoplanet.RadiusDetectionType = m_reader.Value;
                }
            }

        static void ReadAlternateNames ( CExoplanet exoplanet )
            {
            if ( string.Equals ( m_version, "2.0" ) )
                {
                m_reader.ReadToFollowing ( "AlternateNames" );
                m_reader.MoveToFirstAttribute ( );
                exoplanet.AlternateNames = m_reader.Value;
                }
            }

        static void ReadStar ( CExoplanet exoplanet )
            {
            m_reader.ReadToFollowing ( "Star" );

            while ( m_reader.MoveToNextAttribute ( ) )
                {
                switch ( m_reader.Name )
                    {
                    case "Name":
                        exoplanet.Star.Name = m_reader.Value;
                        break;
                    case "ra":
                        exoplanet.Star.RightAccession = m_reader.Value;
                        break;
                    case "dec":
                        exoplanet.Star.Declination = m_reader.Value;
                        break;
                    }
                }
            }

        static void ReadMagnitudes ( CExoplanet exoplanet )
            {
            m_reader.ReadToFollowing ( "Magnitudes" );

            while ( m_reader.MoveToNextAttribute ( ) )
                {
                switch ( m_reader.Name )
                    {
                    case "V":
                        exoplanet.Star.Magnitudes.V = m_reader.Value;
                        break;
                    case "I":
                        exoplanet.Star.Magnitudes.I = m_reader.Value;
                        break;
                    case "J":
                        exoplanet.Star.Magnitudes.J = m_reader.Value;
                        break;
                    case "H":
                        exoplanet.Star.Magnitudes.H = m_reader.Value;
                        break;
                    case "K":
                        exoplanet.Star.Magnitudes.K = m_reader.Value;
                        break;
                    }
                }
            }

        static void ReadProperties ( CExoplanet exoplanet )
            {
            m_reader.ReadToFollowing ( "Properties" );

            while ( m_reader.MoveToNextAttribute ( ) )
                {
                switch ( m_reader.Name )
                    {
                    case "Distance":
                        exoplanet.Star.Properties.Distance = m_reader.Value;
                        break;
                    case "Metallicity":
                        exoplanet.Star.Properties.Metallicity = m_reader.Value;
                        break;
                    case "Mass":
                        exoplanet.Star.Properties.Mass = m_reader.Value;
                        break;
                    case "Radius":
                        exoplanet.Star.Properties.Radius = m_reader.Value;
                        break;
                    case "SPType":
                        exoplanet.Star.Properties.SPType = m_reader.Value;
                        break;
                    case "Age":
                        exoplanet.Star.Properties.Age = m_reader.Value;
                        break;
                    case "Teff":
                        exoplanet.Star.Properties.Teff = m_reader.Value;
                        break;
                    case "DetectedDisc":
                        exoplanet.Star.Properties.DetectedDisc = m_reader.Value;
                        break;
                    case "MagneticField":
                        exoplanet.Star.Properties.MagneticField = m_reader.Value;
                        break;
                    }
                }
            }

        static void exoplanetSettingsValidationEventHandler ( object sender, ValidationEventArgs e )
            {
            if ( e.Severity == XmlSeverityType.Warning )
                {
                m_validationErrors += "WARNING: " + "\r";
                m_validationErrors += e.Message + "\r";
                }
            else if ( e.Severity == XmlSeverityType.Error )
                {
                m_validationErrors += "ERROR: " + "\r";
                m_validationErrors += e.Message + "\r";
                }
            }

        }
    }
