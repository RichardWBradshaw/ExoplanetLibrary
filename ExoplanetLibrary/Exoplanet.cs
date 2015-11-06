﻿namespace ExoplanetLibrary
    {
    public class Exoplanet
        {
            public Exoplanet()
                {
                Star_ = new Star ();
                }

            private string Name_;
            public string Name
                {
                get { return Name_; }
                set { Name_ = value; }
                }

            private string Mass_;
            public string Mass
                {
                get { return Mass_; }
                set { Mass_ = value; }
                }

            private string MassErrorMin_;
            public string MassErrorMin
                {
                get { return MassErrorMin_; }
                set { MassErrorMin_ = value; }
                }

            private string MassErrorMax_;
            public string MassErrorMax
                {
                get { return MassErrorMax_; }
                set { MassErrorMax_ = value; }
                }

            private string Radius_;
            public string Radius
                {
                get { return Radius_; }
                set { Radius_ = value; }
                }

            private string RadiusErrorMin_;
            public string RadiusErrorMin
                {
                get { return RadiusErrorMin_; }
                set { RadiusErrorMin_ = value; }
                }

            private string RadiusErrorMax_;
            public string RadiusErrorMax
                {
                get { return RadiusErrorMax_; }
                set { RadiusErrorMax_ = value; }
                }

            private string OrbitalPeriod_;
            public string OrbitalPeriod
                {
                get { return OrbitalPeriod_; }
                set { OrbitalPeriod_ = value; }
                }

            private string OrbitalPeriodErrorMin_;
            public string OrbitalPeriodErrorMin
                {
                get { return OrbitalPeriodErrorMin_; }
                set { OrbitalPeriodErrorMin_ = value; }
                }

            private string OrbitalPeriodErrorMax_;
            public string OrbitalPeriodErrorMax
                {
                get { return OrbitalPeriodErrorMax_; }
                set { OrbitalPeriodErrorMax_ = value; }
                }

            private string SemiMajorAxis_;
            public string SemiMajorAxis
                {
                get { return SemiMajorAxis_; }
                set { SemiMajorAxis_ = value; }
                }

            private string SemiMajorAxisErrorMin_;
            public string SemiMajorAxisErrorMin
                {
                get { return SemiMajorAxisErrorMin_; }
                set { SemiMajorAxisErrorMin_ = value; }
                }

            private string SemiMajorAxisErrorMax_;
            public string SemiMajorAxisErrorMax
                {
                get { return SemiMajorAxisErrorMax_; }
                set { SemiMajorAxisErrorMax_ = value; }
                }

            private string Eccentricity_;
            public string Eccentricity
                {
                get { return Eccentricity_; }
                set { Eccentricity_ = value; }
                }

            private string EccentricityErrorMin_;
            public string EccentricityErrorMin
                {
                get { return EccentricityErrorMin_; }
                set { EccentricityErrorMin_ = value; }
                }

            private string EccentricityErrorMax_;
            public string EccentricityErrorMax
                {
                get { return EccentricityErrorMax_; }
                set { EccentricityErrorMax_ = value; }
                }

            private string AngularDistance_;
            public string AngularDistance
                {
                get { return AngularDistance_; }
                set { AngularDistance_ = value; }
                }

            private string Inclination_;
            public string Inclination
                {
                get { return Inclination_; }
                set { Inclination_ = value; }
                }

            private string InclinationErrorMin_;
            public string InclinationErrorMin
                {
                get { return InclinationErrorMin_; }
                set { InclinationErrorMin_ = value; }
                }

            private string InclinationErrorMax_;
            public string InclinationErrorMax
                {
                get { return InclinationErrorMax_; }
                set { InclinationErrorMax_ = value; }
                }

            private string TzeroTr_;
            public string TzeroTr
                {
                get { return TzeroTr_; }
                set { TzeroTr_ = value; }
                }
            private string TzeroTrErrorMin_;
            public string TzeroTrErrorMin
                {
                get { return TzeroTrErrorMin_; }
                set { TzeroTrErrorMin_ = value; }
                }

            private string TzeroTrErrorMax_;
            public string TzeroTrErrorMax
                {
                get { return TzeroTrErrorMax_; }
                set { TzeroTrErrorMax_ = value; }
                }

            private string TzeroTrSec_;
            public string TzeroTrSec
                {
                get { return TzeroTrSec_; }
                set { TzeroTrSec_ = value; }
                }

            private string TzeroTrSecErrorMin_;
            public string TzeroTrSecErrorMin
                {
                get { return TzeroTrSecErrorMin_; }
                set { TzeroTrSecErrorMin_ = value; }
                }

            private string TzeroTrSecErrorMax_;
            public string TzeroTrSecErrorMax
                {
                get { return TzeroTrSecErrorMax_; }
                set { TzeroTrSecErrorMax_ = value; }
                }

            private string LambdaAngle_;
            public string LambdaAngle
                {
                get { return LambdaAngle_; }
                set { LambdaAngle_ = value; }
                }

            private string LambdaAngleErrorMin_;
            public string LambdaAngleErrorMin
                {
                get { return LambdaAngleErrorMin_; }
                set { LambdaAngleErrorMin_ = value; }
                }

            private string LambdaAngleErrorMax_;
            public string LambdaAngleErrorMax
                {
                get { return LambdaAngleErrorMax_; }
                set { LambdaAngleErrorMax_ = value; }
                }

            private string TzeroVr_;
            public string TzeroVr
                {
                get { return TzeroVr_; }
                set { TzeroVr_ = value; }
                }

            private string TzeroVrErrorMin_;
            public string TzeroVrErrorMin
                {
                get { return TzeroVrErrorMin_; }
                set { TzeroVrErrorMin_ = value; }
                }

            private string TzeroVrErrorMax_;
            public string TzeroVrErrorMax
                {
                get { return TzeroVrErrorMax_; }
                set { TzeroVrErrorMax_ = value; }
                }

            private string TemperatureCalculated_;
            public string TemperatureCalculated
                {
                get { return TemperatureCalculated_; }
                set { TemperatureCalculated_ = value; }
                }

            private string TemperatureMeasured_;
            public string TemperatureMeasured
                {
                get { return TemperatureMeasured_; }
                set { TemperatureMeasured_ = value; }
                }

            private string TemperatureHotPointLo_;
            public string TemperatureHotPointLo
                {
                get { return TemperatureHotPointLo_; }
                set { TemperatureHotPointLo_ = value; }
                }

            private string LogG_;
            public string LogG
                {
                get { return LogG_; }
                set { LogG_ = value; }
                }

            private string Status_;
            public string Status
                {
                get { return Status_; }
                set { Status_ = value; }
                }

            private string Discovered_;
            public string Discovered
                {
                get { return Discovered_; }
                set { Discovered_ = value; }
                }

            private string Updated_;
            public string Updated
                {
                get { return Updated_; }
                set { Updated_ = value; }
                }

            private string Omega_;
            public string Omega
                {
                get { return Omega_; }
                set { Omega_ = value; }
                }

            private string OmegaErrorMin_;
            public string OmegaErrorMin
                {
                get { return OmegaErrorMin_; }
                set { OmegaErrorMin_ = value; }
                }

            private string OmegaErrorMax_;
            public string OmegaErrorMax
                {
                get { return OmegaErrorMax_; }
                set { OmegaErrorMax_ = value; }
                }

            private string Tperi_;
            public string Tperi
                {
                get { return Tperi_; }
                set { Tperi_ = value; }
                }

            private string TperiErrorMin_;
            public string TperiErrorMin
                {
                get { return TperiErrorMin_; }
                set { TperiErrorMin_ = value; }
                }

            private string TperiErrorMax_;
            public string TperiErrorMax
                {
                get { return TperiErrorMax_; }
                set { TperiErrorMax_ = value; }
                }

            private string DetectionType_;
            public string DetectionType
                {
                get { return DetectionType_; }
                set { DetectionType_ = value; }
                }

            private string Molecules_;
            public string Molecules
                {
                get { return Molecules_; }
                set { Molecules_ = value; }
                }

            private string ImpactParameter_;
            public string ImpactParameter
                {
                get { return ImpactParameter_; }
                set { ImpactParameter_ = value; }
                }

            private string ImpactParameterErrorMin_;
            public string ImpactParameterErrorMin
                {
                get { return ImpactParameterErrorMin_; }
                set { ImpactParameterErrorMin_ = value; }
                }

            private string ImpactParameterErrorMax_;
            public string ImpactParameterErrorMax
                {
                get { return ImpactParameterErrorMax_; }
                set { ImpactParameterErrorMax_ = value; }
                }

            private string K_;
            public string K
                {
                get { return K_; }
                set { K_ = value; }
                }

            private string KErrorMin_;
            public string KErrorMin
                {
                get { return KErrorMin_; }
                set { KErrorMin_ = value; }
                }

            private string KErrorMax_;
            public string KErrorMax
                {
                get { return KErrorMax_; }
                set { KErrorMax_ = value; }
                }

            private string GeometricAlbedo_;
            public string GeometricAlbedo
                {
                get { return GeometricAlbedo_; }
                set { GeometricAlbedo_ = value; }
                }

            private string GeometricAlbedoErrorMin_;
            public string GeometricAlbedoErrorMin
                {
                get { return GeometricAlbedoErrorMin_; }
                set { GeometricAlbedoErrorMin_ = value; }
                }

            private string GeometricAlbedoErrorMax_;
            public string GeometricAlbedoErrorMax
                {
                get { return GeometricAlbedoErrorMax_; }
                set { GeometricAlbedoErrorMax_ = value; }
                }

            private string Tconj_;
            public string Tconj
                {
                get { return Tconj_; }
                set { Tconj_ = value; }
                }

            private string TconjErrorMin_;
            public string TconjErrorMin
                {
                get { return TconjErrorMin_; }
                set { TconjErrorMin_ = value; }
                }

            private string TconjErrorMax_;
            public string TconjErrorMax
                {
                get { return TconjErrorMax_; }
                set { TconjErrorMax_ = value; }
                }

            private string MassDetectionType_;
            public string MassDetectionType
                {
                get { return MassDetectionType_; }
                set { MassDetectionType_ = value; }
                }

            private string RadiusDetectionType_;
            public string RadiusDetectionType
                {
                get { return RadiusDetectionType_; }
                set { RadiusDetectionType_ = value; }
                }

            private string AlternateNames_;
            public string AlternateNames
                {
                get { return AlternateNames_; }
                set { AlternateNames_ = value; }
                }

            private Star Star_;
            public Star Star
                {
                get { return Star_; }
                set { Star_ = value; }
                }
        }

    public class Star
        {
        public Star()
            {
            Magnitude = new Magnitude ();
            Property = new Property ();
            }

        private string Name_;
        public string Name
            {
            get { return Name_; }
            set { Name_ = value; }
            }

        private string RightAccession_;
        public string RightAccession
            {
            get { return RightAccession_; }
            set { RightAccession_ = value; }
            }

        private string Declination_;
        public string Declination
            {
            get { return Declination_; }
            set { Declination_ = value; }
            }

        private Magnitude Magnitude_;
        public Magnitude Magnitude
            {
            get { return Magnitude_; }
            set { Magnitude_ = value; }
            }

        private Property Property_;
        public Property Property
            {
            get { return Property_; }
            set { Property_ = value; }
            }
        };

    public class Magnitude
        {
        public Magnitude()
            {
            }

        private string V_;
        public string V
            {
            get { return V_; }
            set { V_ = value; }
            }

        private string I_;
        public string I
            {
            get { return I_; }
            set { I_ = value; }
            }

        private string J_;
        public string J
            {
            get { return J_; }
            set { J_ = value; }
            }

        private string H_;
        public string H
            {
            get { return H_; }
            set { H_ = value; }
            }

        private string K_;
        public string K
            {
            get { return K_; }
            set { K_ = value; }
            }
        };

    public class Property
        {
        public Property()
            {
            }

        private string Distance_;
        public string Distance
            {
            get { return Distance_; }
            set { Distance_ = value; }
            }

        private string Metallicity_;
        public string Metallicity
            {
            get { return Metallicity_; }
            set { Metallicity_ = value; }
            }

        private string Mass_;
        public string Mass
            {
            get { return Mass_; }
            set { Mass_ = value; }
            }

        private string Radius_;
        public string Radius
            {
            get { return Radius_; }
            set { Radius_ = value; }
            }

        private string SPType_;
        public string SPType
            {
            get { return SPType_; }
            set { SPType_ = value; }
            }

        private string Age_;
        public string Age
            {
            get { return Age_; }
            set { Age_ = value; }
            }

        private string Teff_;
        public string Teff
            {
            get { return Teff_; }
            set { Teff_ = value; }
            }

        private string DetectedDisc_;
        public string DetectedDisc
            {
            get { return DetectedDisc_; }
            set { DetectedDisc_ = value; }
            }

        private string MagneticField_;
        public string MagneticField
            {
            get { return MagneticField_; }
            set { MagneticField_ = value; }
            }
        };

    }