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
        private string Distance_;
        public string Distance
            {
            get
                {
                return Distance_;
                }
            set
                {
                Distance_ = value;
                }
            }

        private string Metallicity_;
        public string Metallicity
            {
            get
                {
                return Metallicity_;
                }
            set
                {
                Metallicity_ = value;
                }
            }

        private string Mass_;
        public string Mass
            {
            get
                {
                return Mass_;
                }
            set
                {
                Mass_ = value;
                }
            }

        private string Radius_;
        public string Radius
            {
            get
                {
                return Radius_;
                }
            set
                {
                Radius_ = value;
                }
            }

        private string SPType_;
        public string SPType
            {
            get
                {
                return SPType_;
                }
            set
                {
                SPType_ = value;
                }
            }

        private string Age_;
        public string Age
            {
            get
                {
                return Age_;
                }
            set
                {
                Age_ = value;
                }
            }

        private string Teff_;
        public string Teff
            {
            get
                {
                return Teff_;
                }
            set
                {
                Teff_ = value;
                }
            }

        private string DetectedDisc_;
        public string DetectedDisc
            {
            get
                {
                return DetectedDisc_;
                }
            set
                {
                DetectedDisc_ = value;
                }
            }

        private string MagneticField_;
        public string MagneticField
            {
            get
                {
                return MagneticField_;
                }
            set
                {
                MagneticField_ = value;
                }
            }
        };

    public class CStar
        {
        private string Name_;
        public string Name
            {
            get
                {
                return Name_;
                }
            set
                {
                Name_ = value;
                }
            }

        private string RightAccession_;
        public string RightAccession
            {
            get
                {
                return RightAccession_;
                }
            set
                {
                RightAccession_ = value;
                }
            }

        private string Declination_;
        public string Declination
            {
            get
                {
                return Declination_;
                }
            set
                {
                Declination_ = value;
                }
            }

        private CMagnitudes Magnitudes_;
        public CMagnitudes Magnitudes
            {
            get
                {
                return Magnitudes_;
                }
            set
                {
                Magnitudes_ = value;
                }
            }

        private CProperties Properties_;
        public CProperties Properties
            {
            get
                {
                return Properties_;
                }
            set
                {
                Properties_ = value;
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
        private string Name_;
        public string Name
            {
            get
                {
                return Name_;
                }
            set
                {
                Name_ = value;
                }
            }

        private string Mass_;
        public string Mass
            {
            get
                {
                return Mass_;
                }
            set
                {
                Mass_ = value;
                }
            }

        private string MassErrorMin_;
        public string MassErrorMin
            {
            get
                {
                return MassErrorMin_;
                }
            set
                {
                MassErrorMin_ = value;
                }
            }

        private string MassErrorMax_;
        public string MassErrorMax
            {
            get
                {
                return MassErrorMax_;
                }
            set
                {
                MassErrorMax_ = value;
                }
            }

        private string Radius_;
        public string Radius
            {
            get
                {
                return Radius_;
                }
            set
                {
                Radius_ = value;
                }
            }

        private string RadiusErrorMin_;
        public string RadiusErrorMin
            {
            get
                {
                return RadiusErrorMin_;
                }
            set
                {
                RadiusErrorMin_ = value;
                }
            }

        private string RadiusErrorMax_;
        public string RadiusErrorMax
            {
            get
                {
                return RadiusErrorMax_;
                }
            set
                {
                RadiusErrorMax_ = value;
                }
            }

        private string OrbitalPeriod_;
        public string OrbitalPeriod
            {
            get
                {
                return OrbitalPeriod_;
                }
            set
                {
                OrbitalPeriod_ = value;
                }
            }

        private string OrbitalPeriodErrorMin_;
        public string OrbitalPeriodErrorMin
            {
            get
                {
                return OrbitalPeriodErrorMin_;
                }
            set
                {
                OrbitalPeriodErrorMin_ = value;
                }
            }

        private string OrbitalPeriodErrorMax_;
        public string OrbitalPeriodErrorMax
            {
            get
                {
                return OrbitalPeriodErrorMax_;
                }
            set
                {
                OrbitalPeriodErrorMax_ = value;
                }
            }

        private string SemiMajorAxis_;
        public string SemiMajorAxis
            {
            get
                {
                return SemiMajorAxis_;
                }
            set
                {
                SemiMajorAxis_ = value;
                }
            }

        private string SemiMajorAxisErrorMin_;
        public string SemiMajorAxisErrorMin
            {
            get
                {
                return SemiMajorAxisErrorMin_;
                }
            set
                {
                SemiMajorAxisErrorMin_ = value;
                }
            }

        private string SemiMajorAxisErrorMax_;
        public string SemiMajorAxisErrorMax
            {
            get
                {
                return SemiMajorAxisErrorMax_;
                }
            set
                {
                SemiMajorAxisErrorMax_ = value;
                }
            }

        private string Eccentricity_;
        public string Eccentricity
            {
            get
                {
                return Eccentricity_;
                }
            set
                {
                Eccentricity_ = value;
                }
            }

        private string EccentricityErrorMin_;
        public string EccentricityErrorMin
            {
            get
                {
                return EccentricityErrorMin_;
                }
            set
                {
                EccentricityErrorMin_ = value;
                }
            }

        private string EccentricityErrorMax_;
        public string EccentricityErrorMax
            {
            get
                {
                return EccentricityErrorMax_;
                }
            set
                {
                EccentricityErrorMax_ = value;
                }
            }

        private string AngularDistance_;
        public string AngularDistance
            {
            get
                {
                return AngularDistance_;
                }
            set
                {
                AngularDistance_ = value;
                }
            }

        private string Inclination_;
        public string Inclination
            {
            get
                {
                return Inclination_;
                }
            set
                {
                Inclination_ = value;
                }
            }

        private string InclinationErrorMin_;
        public string InclinationErrorMin
            {
            get
                {
                return InclinationErrorMin_;
                }
            set
                {
                InclinationErrorMin_ = value;
                }
            }

        private string InclinationErrorMax_;
        public string InclinationErrorMax
            {
            get
                {
                return InclinationErrorMax_;
                }
            set
                {
                InclinationErrorMax_ = value;
                }
            }

        private string TzeroTr_;
        public string TzeroTr
            {
            get
                {
                return TzeroTr_;
                }
            set
                {
                TzeroTr_ = value;
                }
            }
        private string TzeroTrErrorMin_;
        public string TzeroTrErrorMin
            {
            get
                {
                return TzeroTrErrorMin_;
                }
            set
                {
                TzeroTrErrorMin_ = value;
                }
            }

        private string TzeroTrErrorMax_;
        public string TzeroTrErrorMax
            {
            get
                {
                return TzeroTrErrorMax_;
                }
            set
                {
                TzeroTrErrorMax_ = value;
                }
            }

        private string TzeroTrSec_;
        public string TzeroTrSec
            {
            get
                {
                return TzeroTrSec_;
                }
            set
                {
                TzeroTrSec_ = value;
                }
            }

        private string TzeroTrSecErrorMin_;
        public string TzeroTrSecErrorMin
            {
            get
                {
                return TzeroTrSecErrorMin_;
                }
            set
                {
                TzeroTrSecErrorMin_ = value;
                }
            }

        private string TzeroTrSecErrorMax_;
        public string TzeroTrSecErrorMax
            {
            get
                {
                return TzeroTrSecErrorMax_;
                }
            set
                {
                TzeroTrSecErrorMax_ = value;
                }
            }

        private string LambdaAngle_;
        public string LambdaAngle
            {
            get
                {
                return LambdaAngle_;
                }
            set
                {
                LambdaAngle_ = value;
                }
            }

        private string LambdaAngleErrorMin_;
        public string LambdaAngleErrorMin
            {
            get
                {
                return LambdaAngleErrorMin_;
                }
            set
                {
                LambdaAngleErrorMin_ = value;
                }
            }

        private string LambdaAngleErrorMax_;
        public string LambdaAngleErrorMax
            {
            get
                {
                return LambdaAngleErrorMax_;
                }
            set
                {
                LambdaAngleErrorMax_ = value;
                }
            }

        private string TzeroVr_;
        public string TzeroVr
            {
            get
                {
                return TzeroVr_;
                }
            set
                {
                TzeroVr_ = value;
                }
            }

        private string TzeroVrErrorMin_;
        public string TzeroVrErrorMin
            {
            get
                {
                return TzeroVrErrorMin_;
                }
            set
                {
                TzeroVrErrorMin_ = value;
                }
            }

        private string TzeroVrErrorMax_;
        public string TzeroVrErrorMax
            {
            get
                {
                return TzeroVrErrorMax_;
                }
            set
                {
                TzeroVrErrorMax_ = value;
                }
            }

        private string TemperatureCalculated_;
        public string TemperatureCalculated
            {
            get
                {
                return TemperatureCalculated_;
                }
            set
                {
                TemperatureCalculated_ = value;
                }
            }

        private string TemperatureMeasured_;
        public string TemperatureMeasured
            {
            get
                {
                return TemperatureMeasured_;
                }
            set
                {
                TemperatureMeasured_ = value;
                }
            }

        private string TemperatureHotPointLo_;
        public string TemperatureHotPointLo
            {
            get
                {
                return TemperatureHotPointLo_;
                }
            set
                {
                TemperatureHotPointLo_ = value;
                }
            }

        private string LogG_;
        public string LogG
            {
            get
                {
                return LogG_;
                }
            set
                {
                LogG_ = value;
                }
            }

        private string Status_;
        public string Status
            {
            get
                {
                return Status_;
                }
            set
                {
                Status_ = value;
                }
            }

        private string Discovered_;
        public string Discovered
            {
            get
                {
                return Discovered_;
                }
            set
                {
                Discovered_ = value;
                }
            }

        private string Updated_;
        public string Updated
            {
            get
                {
                return Updated_;
                }
            set
                {
                Updated_ = value;
                }
            }

        private string Omega_;
        public string Omega
            {
            get
                {
                return Omega_;
                }
            set
                {
                Omega_ = value;
                }
            }

        private string OmegaErrorMin_;
        public string OmegaErrorMin
            {
            get
                {
                return OmegaErrorMin_;
                }
            set
                {
                OmegaErrorMin_ = value;
                }
            }

        private string OmegaErrorMax_;
        public string OmegaErrorMax
            {
            get
                {
                return OmegaErrorMax_;
                }
            set
                {
                OmegaErrorMax_ = value;
                }
            }

        private string Tperi_;
        public string Tperi
            {
            get
                {
                return Tperi_;
                }
            set
                {
                Tperi_ = value;
                }
            }

        private string TperiErrorMin_;
        public string TperiErrorMin
            {
            get
                {
                return TperiErrorMin_;
                }
            set
                {
                TperiErrorMin_ = value;
                }
            }

        private string TperiErrorMax_;
        public string TperiErrorMax
            {
            get
                {
                return TperiErrorMax_;
                }
            set
                {
                TperiErrorMax_ = value;
                }
            }

        private string DetectionType_;
        public string DetectionType
            {
            get
                {
                return DetectionType_;
                }
            set
                {
                DetectionType_ = value;
                }
            }

        private string Molecules_;
        public string Molecules
            {
            get
                {
                return Molecules_;
                }
            set
                {
                Molecules_ = value;
                }
            }

        private string ImpactParameter_;
        public string ImpactParameter
            {
            get
                {
                return ImpactParameter_;
                }
            set
                {
                ImpactParameter_ = value;
                }
            }

        private string ImpactParameterErrorMin_;
        public string ImpactParameterErrorMin
            {
            get
                {
                return ImpactParameterErrorMin_;
                }
            set
                {
                ImpactParameterErrorMin_ = value;
                }
            }

        private string ImpactParameterErrorMax_;
        public string ImpactParameterErrorMax
            {
            get
                {
                return ImpactParameterErrorMax_;
                }
            set
                {
                ImpactParameterErrorMax_ = value;
                }
            }

        private string K_;
        public string K
            {
            get
                {
                return K_;
                }
            set
                {
                K_ = value;
                }
            }

        private string KErrorMin_;
        public string KErrorMin
            {
            get
                {
                return KErrorMin_;
                }
            set
                {
                KErrorMin_ = value;
                }
            }

        private string KErrorMax_;
        public string KErrorMax
            {
            get
                {
                return KErrorMax_;
                }
            set
                {
                KErrorMax_ = value;
                }
            }

        private string GeometricAlbedo_;
        public string GeometricAlbedo
            {
            get
                {
                return GeometricAlbedo_;
                }
            set
                {
                GeometricAlbedo_ = value;
                }
            }

        private string GeometricAlbedoErrorMin_;
        public string GeometricAlbedoErrorMin
            {
            get
                {
                return GeometricAlbedoErrorMin_;
                }
            set
                {
                GeometricAlbedoErrorMin_ = value;
                }
            }

        private string GeometricAlbedoErrorMax_;
        public string GeometricAlbedoErrorMax
            {
            get
                {
                return GeometricAlbedoErrorMax_;
                }
            set
                {
                GeometricAlbedoErrorMax_ = value;
                }
            }

        private string Tconj_;
        public string Tconj
            {
            get
                {
                return Tconj_;
                }
            set
                {
                Tconj_ = value;
                }
            }

        private string TconjErrorMin_;
        public string TconjErrorMin
            {
            get
                {
                return TconjErrorMin_;
                }
            set
                {
                TconjErrorMin_ = value;
                }
            }

        private string TconjErrorMax_;
        public string TconjErrorMax
            {
            get
                {
                return TconjErrorMax_;
                }
            set
                {
                TconjErrorMax_ = value;
                }
            }

        private string MassDetectionType_;
        public string MassDetectionType
            {
            get
                {
                return MassDetectionType_;
                }
            set
                {
                MassDetectionType_ = value;
                }
            }

        private string RadiusDetectionType_;
        public string RadiusDetectionType
            {
            get
                {
                return RadiusDetectionType_;
                }
            set
                {
                RadiusDetectionType_ = value;
                }
            }

        private string AlternateNames_;
        public string AlternateNames
            {
            get
                {
                return AlternateNames_;
                }
            set
                {
                AlternateNames_ = value;
                }
            }

        private CStar Star_;
        public CStar Star
            {
            get
                {
                return Star_;
                }
            set
                {
                Star_ = value;
                }
            }

        public CExoplanet ( )
            {
            Star_ = new CStar ( );
            }
        };

    class ReadXML : CExoplanet
        {
        static XmlReader Reader_ = null;
        static XmlReader Reader
            {
            get
                {
                return Reader_;
                }
            set
                {
                Reader_ = value;
                }
            }

        static private string Version_ = "2.0";
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

        static private string XsdVersion1FileName_ = "C:\\ProgramData\\Exoplanet Library\\schema\\EXOPLANET.V.1.xsd";
        static private string XsdVersion1FileName
            {
            get
                {
                return XsdVersion1FileName_;
                }
            set
                {
                XsdVersion1FileName_ = value;
                }
            }

        static private string XsdVersion2FileName_ = "C:\\ProgramData\\Exoplanet Library\\schema\\EXOPLANET.xsd";
        static private string XsdVersion2FileName
            {
            get
                {
                return XsdVersion2FileName_;
                }
            set
                {
                XsdVersion2FileName_ = value;
                }
            }

        static private string ValidationErrors_ = "";
        static private string ValidationErrors
            {
            get
                {
                return ValidationErrors_;
                }
            set
                {
                ValidationErrors_ = value;
                }
            }


        static private void SetVersion ( string xmlFileName )
            {
            if ( System.IO.File.Exists ( xmlFileName ) )
                {
                Reader = XmlReader.Create ( xmlFileName );
                Reader.ReadToFollowing ( "Exoplanets" );
                Reader.MoveToFirstAttribute ( );
                Version = Reader.Value;
                Reader.Close ( );
                }
            }

        static private void SetValidation ( FileStream fileStream, XmlReaderSettings settings )
            {
            ValidationEventHandler validationEventHandler = new ValidationEventHandler ( exoplanetSettingsValidationEventHandler );
            XmlSchema xmlSchema = null;

            if ( System.IO.File.Exists ( @XsdVersion2FileName ) || System.IO.File.Exists ( @XsdVersion1FileName ) )
                if ( string.Equals ( Version, "2.0" ) )
                    xmlSchema = XmlSchema.Read ( ( fileStream = File.Open ( @XsdVersion2FileName, FileMode.Open ) ), validationEventHandler );
                else if ( string.Equals ( Version, "1.0" ) )
                    xmlSchema = XmlSchema.Read ( ( fileStream = File.Open ( @XsdVersion1FileName, FileMode.Open ) ), validationEventHandler );

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
            }

        static public int Read ( string xmlFileName, ref ArrayList exoplanets )
            {
            ValidationErrors = "";

            exoplanets = new ArrayList ( );

            if ( System.IO.File.Exists ( xmlFileName ) )
                {
                FileStream fileStream = null;
                XmlReaderSettings settings = new XmlReaderSettings ( );

                SetVersion ( xmlFileName );
                SetValidation ( fileStream, settings );

                Reader = XmlReader.Create ( xmlFileName, settings );

                while ( Reader.Read ( ) )
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

                    if ( string.Equals ( Version, "2.0" ) )
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

                Reader.Close ( );
                }

            if ( ValidationErrors.Length > 0 )
                MessageBox.Show ( ValidationErrors );

            return 0;
            }

        static void ReadExoplanet ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "Exoplanet" );

            Reader.MoveToFirstAttribute ( );
            exoplanet.Name = Reader.Value;
            }

        static void ReadMass ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "Mass" );

            while ( Reader.MoveToNextAttribute ( ) )
                {
                switch ( Reader.Name )
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

        static void ReadRadius ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "Radius" );

            while ( Reader.MoveToNextAttribute ( ) )
                {
                switch ( Reader.Name )
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

        static void ReadOrbitalPeriod ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "OrbitalPeriod" );

            while ( Reader.MoveToNextAttribute ( ) )
                {
                switch ( Reader.Name )
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

        static void ReadSemiMajorAxis ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "SemiMajorAxis" );

            while ( Reader.MoveToNextAttribute ( ) )
                {
                switch ( Reader.Name )
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

        static void ReadEccentricity ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "Eccentricity" );

            while ( Reader.MoveToNextAttribute ( ) )
                {
                switch ( Reader.Name )
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

        static void ReadAngularDistance ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "AngularDistance" );
            Reader.MoveToFirstAttribute ( );
            exoplanet.AngularDistance = Reader.Value;
            }

        static void ReadInclination ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "Inclination" );

            while ( Reader.MoveToNextAttribute ( ) )
                {
                switch ( Reader.Name )
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

        static void ReadTzeroTr ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "TzeroTr" );

            while ( Reader.MoveToNextAttribute ( ) )
                {
                switch ( Reader.Name )
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

        static void ReadTzeroTrSec ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "TzeroTrSec" );

            while ( Reader.MoveToNextAttribute ( ) )
                {
                switch ( Reader.Name )
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

        static void ReadLambdaAngle ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "LambdaAngle" );

            while ( Reader.MoveToNextAttribute ( ) )
                {
                switch ( Reader.Name )
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

        static void ReadTzeroVr ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "TzeroVr" );

            while ( Reader.MoveToNextAttribute ( ) )
                {
                switch ( Reader.Name )
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

        static void ReadTemperature ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "Temperature" );

            while ( Reader.MoveToNextAttribute ( ) )
                {
                switch ( Reader.Name )
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

        static void ReadLogG ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "LogG" );
            Reader.MoveToFirstAttribute ( );
            exoplanet.LogG = Reader.Value;
            }

        static void ReadPublicationStatus ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "PublicationStatus" );
            Reader.MoveToFirstAttribute ( );
            exoplanet.Status = Reader.Value;
            }

        static void ReadDiscovered ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "Discovered" );
            Reader.MoveToFirstAttribute ( );
            exoplanet.Discovered = Reader.Value;
            }

        static void ReadUpdated ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "Updated" );
            Reader.MoveToFirstAttribute ( );
            exoplanet.Updated = Reader.Value;
            }

        static void ReadOmega ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "Omega" );

            while ( Reader.MoveToNextAttribute ( ) )
                {
                switch ( Reader.Name )
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

        static void ReadTperi ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "Tperi" );

            while ( Reader.MoveToNextAttribute ( ) )
                {
                switch ( Reader.Name )
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

        static void ReadDetectionType ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "DetectionType" );
            Reader.MoveToFirstAttribute ( );
            exoplanet.DetectionType = Reader.Value;
            }

        static void ReadMolecules ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "Molecules" );
            Reader.MoveToFirstAttribute ( );
            exoplanet.Molecules = Reader.Value;
            }

        static void ReadImpactParameter ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "ImpactParameter" );

            while ( Reader.MoveToNextAttribute ( ) )
                {
                switch ( Reader.Name )
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

        static void ReadK ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "K" );

            while ( Reader.MoveToNextAttribute ( ) )
                {
                switch ( Reader.Name )
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

        static void ReadGeometricAlbedo ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "GeometricAlbedo" );

            while ( Reader.MoveToNextAttribute ( ) )
                {
                switch ( Reader.Name )
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

        static void ReadTconj ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "Tconj" );

            while ( Reader.MoveToNextAttribute ( ) )
                {
                switch ( Reader.Name )
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

        static void ReadMassDetectionType ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "MassDetectionType" );
            Reader.MoveToFirstAttribute ( );
            exoplanet.MassDetectionType = Reader.Value;
            }

        static void ReadRadiusDetectionType ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "RadiusDetectionType" );
            Reader.MoveToFirstAttribute ( );
            exoplanet.RadiusDetectionType = Reader.Value;
            }

        static void ReadAlternateNames ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "AlternateNames" );
            Reader.MoveToFirstAttribute ( );
            exoplanet.AlternateNames = Reader.Value;
            }

        static void ReadStar ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "Star" );

            while ( Reader.MoveToNextAttribute ( ) )
                {
                switch ( Reader.Name )
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

        static void ReadMagnitudes ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "Magnitudes" );

            while ( Reader.MoveToNextAttribute ( ) )
                {
                switch ( Reader.Name )
                    {
                    case "V":
                        exoplanet.Star.Magnitudes.V = Reader.Value;
                        break;
                    case "I":
                        exoplanet.Star.Magnitudes.I = Reader.Value;
                        break;
                    case "J":
                        exoplanet.Star.Magnitudes.J = Reader.Value;
                        break;
                    case "H":
                        exoplanet.Star.Magnitudes.H = Reader.Value;
                        break;
                    case "K":
                        exoplanet.Star.Magnitudes.K = Reader.Value;
                        break;
                    }
                }
            }

        static void ReadProperties ( CExoplanet exoplanet )
            {
            Reader.ReadToFollowing ( "Properties" );

            while ( Reader.MoveToNextAttribute ( ) )
                {
                switch ( Reader.Name )
                    {
                    case "Distance":
                        exoplanet.Star.Properties.Distance = Reader.Value;
                        break;
                    case "Metallicity":
                        exoplanet.Star.Properties.Metallicity = Reader.Value;
                        break;
                    case "Mass":
                        exoplanet.Star.Properties.Mass = Reader.Value;
                        break;
                    case "Radius":
                        exoplanet.Star.Properties.Radius = Reader.Value;
                        break;
                    case "SPType":
                        exoplanet.Star.Properties.SPType = Reader.Value;
                        break;
                    case "Age":
                        exoplanet.Star.Properties.Age = Reader.Value;
                        break;
                    case "Teff":
                        exoplanet.Star.Properties.Teff = Reader.Value;
                        break;
                    case "DetectedDisc":
                        exoplanet.Star.Properties.DetectedDisc = Reader.Value;
                        break;
                    case "MagneticField":
                        exoplanet.Star.Properties.MagneticField = Reader.Value;
                        break;
                    }
                }
            }

        static void exoplanetSettingsValidationEventHandler ( object sender, ValidationEventArgs e )
            {
            if ( e.Severity == XmlSeverityType.Warning )
                {
                ValidationErrors_ += "WARNING: " + "\r";
                ValidationErrors_ += e.Message + "\r";
                }
            else if ( e.Severity == XmlSeverityType.Error )
                {
                ValidationErrors += "ERROR: " + "\r";
                ValidationErrors += e.Message + "\r";
                }
            }

        }
    }
