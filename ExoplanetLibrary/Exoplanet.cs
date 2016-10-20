namespace ExoplanetLibrary
    {
    public class Exoplanet
        {
        public Exoplanet ()
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

        private string MassSini_;
        public string MassSini
            {
            get { return MassSini_; }
            set { MassSini_ = value; }
            }

        private string MassSiniErrorMin_;
        public string MassSiniErrorMin
            {
            get { return MassSiniErrorMin_; }
            set { MassSiniErrorMin_ = value; }
            }

        private string MassSiniErrorMax_;
        public string MassSiniErrorMax
            {
            get { return MassSiniErrorMax_; }
            set { MassSiniErrorMax_ = value; }
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

        private string VelocitySemiamplitude_;
        public string VelocitySemiamplitude
            {
            get { return VelocitySemiamplitude_; }
            set { VelocitySemiamplitude_ = value; }
            }

        private string VelocitySemiamplitudeErrorMin_;
        public string VelocitySemiamplitudeErrorMin
            {
            get { return VelocitySemiamplitudeErrorMin_; }
            set { VelocitySemiamplitudeErrorMin_ = value; }
            }

        private string VelocitySemiamplitudeErrorMax_;
        public string VelocitySemiamplitudeErrorMax
            {
            get { return VelocitySemiamplitudeErrorMax_; }
            set { VelocitySemiamplitudeErrorMax_ = value; }
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

        public bool IsStarTypeDefined ()
            {
            return Star.Property.SPType != null ? true : false;
            }

        public bool IsTypeO ()
            {
            return IsType ("O");
            }

        public bool IsTypeB ()
            {
            return IsType ("B");
            }

        public bool IsTypeA ()
            {
            return IsType ("A");
            }

        public bool IsTypeF ()
            {
            return IsType ("F");
            }

        public bool IsTypeG ()
            {
            return IsType ("G");
            }

        public bool IsTypeK ()
            {
            return IsType ("K");
            }

        public bool IsTypeM ()
            {
            return IsType ("M");
            }

        public bool IsType (string type)
            {
            if (IsStarTypeDefined ())
                if (Star.Property.SPType != null)
                    if (Star.Property.SPType.Substring (0, 1) == type)
                        {
                        int value;

                        if (Star.Property.SPType.Length >= 2)
                            {
                            if (int.TryParse (Star.Property.SPType.Substring (1, 1), out value))
                                return true;
                            }
                        else
                            return true;
                        }

            return false;
            }

        private enum Flags
            {
            IsString,
            IsNumeric,
            IsUnsignedNumeric,
            AreStrings,
            }

        public void AssignFromSubstrings (string [] strings)
            {
            Name = GetSubstring (strings, Indexer.Name, Flags.IsString);

            Mass = GetSubstring (strings, Indexer.Mass);
            MassErrorMin = GetSubstring (strings, Indexer.MassErrorMin, Flags.IsUnsignedNumeric);
            MassErrorMax = GetSubstring (strings, Indexer.MassErrorMax);

            MassSini = GetSubstring (strings, Indexer.MassSini);
            MassSiniErrorMin = GetSubstring (strings, Indexer.MassSiniErrorMin, Flags.IsUnsignedNumeric);
            MassSiniErrorMax = GetSubstring (strings, Indexer.MassSiniErrorMax);

            Radius = GetSubstring (strings, Indexer.Radius);
            RadiusErrorMin = GetSubstring (strings, Indexer.RadiusErrorMin, Flags.IsUnsignedNumeric);
            RadiusErrorMax = GetSubstring (strings, Indexer.RadiusErrorMax);

            OrbitalPeriod = GetSubstring (strings, Indexer.OrbitalPeriod);
            OrbitalPeriodErrorMin = GetSubstring (strings, Indexer.OrbitalPeriodErrorMin, Flags.IsUnsignedNumeric);
            OrbitalPeriodErrorMax = GetSubstring (strings, Indexer.OrbitalPeriodErrorMax);

            SemiMajorAxis = GetSubstring (strings, Indexer.SemiMajorAxis);
            SemiMajorAxisErrorMin = GetSubstring (strings, Indexer.SemiMajorAxisErrorMin, Flags.IsUnsignedNumeric);
            SemiMajorAxisErrorMax = GetSubstring (strings, Indexer.SemiMajorAxisErrorMax);

            Eccentricity = GetSubstring (strings, Indexer.Eccentricity);
            EccentricityErrorMin = GetSubstring (strings, Indexer.EccentricityErrorMin, Flags.IsUnsignedNumeric);
            EccentricityErrorMax = GetSubstring (strings, Indexer.EccentricityErrorMax);

            Inclination = GetSubstring (strings, Indexer.Inclination);
            InclinationErrorMin = GetSubstring (strings, Indexer.InclinationErrorMin, Flags.IsUnsignedNumeric);
            InclinationErrorMax = GetSubstring (strings, Indexer.InclinationErrorMax);

            AngularDistance = GetSubstring (strings, Indexer.AngularDistance);

            Discovered = GetSubstring (strings, Indexer.Discovered, Flags.IsString);

            Updated = GetSubstring (strings, Indexer.Updated, Flags.IsString);

            Omega = GetSubstring (strings, Indexer.Omega);
            OmegaErrorMin = GetSubstring (strings, Indexer.OmegaErrorMin, Flags.IsUnsignedNumeric);
            OmegaErrorMax = GetSubstring (strings, Indexer.OmegaErrorMax);

            Tperi = GetSubstring (strings, Indexer.Tperi);
            TperiErrorMin = GetSubstring (strings, Indexer.TperiErrorMin, Flags.IsUnsignedNumeric);
            TperiErrorMax = GetSubstring (strings, Indexer.TperiErrorMax);

            Tconj = GetSubstring (strings, Indexer.Tconj);
            TconjErrorMin = GetSubstring (strings, Indexer.TconjErrorMin, Flags.IsUnsignedNumeric);
            TconjErrorMax = GetSubstring (strings, Indexer.TconjErrorMax);

            TzeroTr = GetSubstring (strings, Indexer.TzeroTr);
            TzeroTrErrorMin = GetSubstring (strings, Indexer.TzeroTrErrorMin, Flags.IsUnsignedNumeric);
            TzeroTrErrorMax = GetSubstring (strings, Indexer.TzeroTrErrorMax);

            TzeroTrSec = GetSubstring (strings, Indexer.TzeroTrSec);
            TzeroTrSecErrorMin = GetSubstring (strings, Indexer.TzeroTrSecErrorMin, Flags.IsUnsignedNumeric);
            TzeroTrSecErrorMax = GetSubstring (strings, Indexer.TzeroTrSecErrorMax);

            LambdaAngle = GetSubstring (strings, Indexer.LambdaAngle);
            LambdaAngleErrorMin = GetSubstring (strings, Indexer.LambdaAngleErrorMin, Flags.IsUnsignedNumeric);
            LambdaAngleErrorMax = GetSubstring (strings, Indexer.LambdaAngleErrorMax);

            ImpactParameter = GetSubstring (strings, Indexer.ImpactParameter);
            ImpactParameterErrorMin = GetSubstring (strings, Indexer.ImpactParameterErrorMin, Flags.IsUnsignedNumeric);
            ImpactParameterErrorMax = GetSubstring (strings, Indexer.ImpactParameterErrorMax);

            TzeroVr = GetSubstring (strings, Indexer.TzeroVr);
            TzeroVrErrorMin = GetSubstring (strings, Indexer.TzeroVrErrorMin, Flags.IsUnsignedNumeric);
            TzeroVrErrorMax = GetSubstring (strings, Indexer.TzeroVrErrorMax);

            VelocitySemiamplitude = GetSubstring (strings, Indexer.VelocitySemiamplitude);
            VelocitySemiamplitudeErrorMin = GetSubstring (strings, Indexer.VelocitySemiamplitudeErrorMin, Flags.IsUnsignedNumeric);
            VelocitySemiamplitudeErrorMax = GetSubstring (strings, Indexer.VelocitySemiamplitudeErrorMax);

            TemperatureCalculated = GetSubstring (strings, Indexer.TemperatureCalculated);
            TemperatureMeasured = GetSubstring (strings, Indexer.TemperatureMeasured);
            TemperatureHotPointLo = GetSubstring (strings, Indexer.TemperatureHotPointLo);

            GeometricAlbedo = GetSubstring (strings, Indexer.GeometricAlbedo);
            GeometricAlbedoErrorMin = GetSubstring (strings, Indexer.GeometricAlbedoErrorMin, Flags.IsUnsignedNumeric);
            GeometricAlbedoErrorMax = GetSubstring (strings, Indexer.GeometricAlbedoErrorMax);

            LogG = GetSubstring (strings, Indexer.LogG);

            Status = GetSubstring (strings, Indexer.Status, Flags.IsString);

            if (Indexer.DetectionTypeAstrometry != int.MinValue && strings [Indexer.DetectionTypeAstrometry] == "1")
                DetectionType = "Astrometry";
            else if (Indexer.DetectionTypeMicroLensing != int.MinValue && strings [Indexer.DetectionTypeMicroLensing] == "1")
                DetectionType = "MicroLensing";
            else if (Indexer.DetectionTypeTiming != int.MinValue && strings [Indexer.DetectionTypeTiming] == "1")
                DetectionType = "Timing";
            else if (Indexer.DetectionTypeImaging != int.MinValue && strings [Indexer.DetectionTypeImaging] == "1")
                DetectionType = "Timing";
            else
                DetectionType = GetSubstring (strings, Indexer.DetectionType, Flags.IsString);

            MassDetectionType = GetSubstring (strings, Indexer.MassDetectionType, Flags.IsString);

            RadiusDetectionType = GetSubstring (strings, Indexer.RadiusDetectionType, Flags.IsString);

            AlternateNames = GetSubstring (strings, Indexer.AlternateNames, Flags.AreStrings);

            Molecules = GetSubstring (strings, Indexer.Molecules, Flags.AreStrings);

            Star.Name = GetSubstring (strings, Indexer.StarName, Flags.IsString);
            Star.RightAccession = GetSubstring (strings, Indexer.StarRightAccession);
            Star.Declination = GetSubstring (strings, Indexer.StarDeclination);

            if (Indexer.HDName != int.MinValue && Indexer.HIPName != int.MinValue)
                Star.AlternateNames = GetSubstring (strings, Indexer.HDName, Flags.IsString) + ";" + GetSubstring (strings, Indexer.HIPName, Flags.IsString);
            else if (Indexer.HDName != int.MinValue)
                Star.AlternateNames = GetSubstring (strings, Indexer.HDName, Flags.IsString);
            else if (Indexer.HIPName != int.MinValue)
                Star.AlternateNames = GetSubstring (strings, Indexer.HIPName, Flags.IsString);
            else
                Star.AlternateNames = GetSubstring (strings, Indexer.StarAlternateNames, Flags.AreStrings);

            Star.Magnitude.V = GetSubstring (strings, Indexer.StarMagnitudeV);
            Star.Magnitude.I = GetSubstring (strings, Indexer.StarMagnitudeI);
            Star.Magnitude.J = GetSubstring (strings, Indexer.StarMagnitudeJ);
            Star.Magnitude.H = GetSubstring (strings, Indexer.StarMagnitudeH);
            Star.Magnitude.K = GetSubstring (strings, Indexer.StarMagnitudeK);

            Star.Property.Distance = GetSubstring (strings, Indexer.StarDistance);
            Star.Property.DistanceErrorMin = GetSubstring (strings, Indexer.StarDistanceErrorMin, Flags.IsUnsignedNumeric);
            Star.Property.DistanceErrorMax = GetSubstring (strings, Indexer.StarDistanceErrorMax);

            Star.Property.Metallicity = GetSubstring (strings, Indexer.StarMetallicity);
            Star.Property.MetallicityErrorMin = GetSubstring (strings, Indexer.StarMetallicityErrorMin, Flags.IsUnsignedNumeric);
            Star.Property.MetallicityErrorMax = GetSubstring (strings, Indexer.StarMetallicityErrorMax);

            Star.Property.Mass = GetSubstring (strings, Indexer.StarMass);
            Star.Property.MassErrorMin = GetSubstring (strings, Indexer.StarMassErrorMin, Flags.IsUnsignedNumeric);
            Star.Property.MassErrorMax = GetSubstring (strings, Indexer.StarMassErrorMax);

            Star.Property.Radius = GetSubstring (strings, Indexer.StarRadius);
            Star.Property.RadiusErrorMin = GetSubstring (strings, Indexer.StarRadiusErrorMin, Flags.IsUnsignedNumeric);
            Star.Property.RadiusErrorMax = GetSubstring (strings, Indexer.StarRadiusErrorMax);

            Star.Property.SPType = GetSubstring (strings, Indexer.StarSPType);

            Star.Property.Age = GetSubstring (strings, Indexer.StarAge);
            Star.Property.AgeErrorMin = GetSubstring (strings, Indexer.StarAgeErrorMin, Flags.IsUnsignedNumeric);
            Star.Property.AgeErrorMax = GetSubstring (strings, Indexer.StarAgeErrorMax);

            Star.Property.Teff = GetSubstring (strings, Indexer.StarTeff);
            Star.Property.TeffErrorMin = GetSubstring (strings, Indexer.StarTeffErrorMin, Flags.IsUnsignedNumeric);
            Star.Property.TeffErrorMax = GetSubstring (strings, Indexer.StarTeffErrorMax);

            Star.Property.DetectedDisc = GetSubstring (strings, Indexer.StarDetectedDisc, Flags.IsString);
            Star.Property.MagneticField = GetSubstring (strings, Indexer.StarMagneticField, Flags.IsString);
            }

        static private string GetSubstring (string [] substrings, int index)
            {
            return GetSubstring (substrings, index, Flags.IsNumeric);
            }

        static private string GetSubstring (string [] substrings, int index, Flags flag)
            {
            if (index >= 0 && index < substrings.Length)
                if (flag == Flags.IsNumeric)
                    {
                    return Helper.ReplaceNonNumerics (substrings [index].ToString ());
                    }
                else if (flag == Flags.IsUnsignedNumeric)
                    {
                    string stringer = Helper.ReplaceNonNumerics (substrings [index].ToString ());

                    if (stringer.StartsWith ("-"))
                        stringer = stringer.Substring (1);

                    return stringer;
                    }
                else if (flag == Flags.AreStrings)
                    {
                    string stringer = substrings [index].ToString ();
                    return stringer.Replace (',', ';');
                    }
                else
                    return substrings [index].ToString ();

            return string.Empty;
            }

        public void CorrectErrors ()
            {
            string [] errors = { "KO", "GOV", "KOV", "kov", "KOIII", "KOIV/V", "M4 V" };
            string [] corrections = { "K0", "G0V", "K0V", "K0V", "K0III", "K0IV/V", "M4V" };

            if (Star.Property.SPType != null)
                for (int index = 0; index < errors.Length; ++index)
                    {
                    int length = errors [index].Length;

                    if (Star.Property.SPType.Length == length)
                        if (Star.Property.SPType.Substring (0, length) == errors [index])
                            Star.Property.SPType = corrections [index];
                    }

            if (Star.Property.SPType != null)
                if (Star.Property.SPType == "Brown Dwarf")
                    {
                    }
                else if (Star.Property.SPType == "Catac. var.")
                    {
                    }
                else
                    {
                    Star.Property.SPType = Star.Property.SPType.Replace (" ", string.Empty);
                    }

            if (Helper.IsDefined (Eccentricity))
                {
                double value, maximumError, minimumError;

                if (double.TryParse (Eccentricity, out value) == true)
                    if (value == 0.0)
                        {
                        Eccentricity = string.Empty;
                        EccentricityErrorMax = string.Empty;
                        EccentricityErrorMin = string.Empty;
                        }
                    else
                        {
                        if (double.TryParse (EccentricityErrorMax, out maximumError) == true)
                            if (double.TryParse (EccentricityErrorMin, out minimumError) == true)
                                if (maximumError > 10.0 * value)
                                    {
                                    EccentricityErrorMax = string.Empty;
                                    EccentricityErrorMin = string.Empty;
                                    }
                        }
                }

            if (Helper.IsDefined (Updated))
                {
                Updated = Helper.FormatDateCSV2XML (Updated);
                }

            if (Helper.IsDefined (Name))
                Name = Name.Trim ();

            if (Helper.IsDefined (Star.Name))
                Star.Name = Star.Name.Trim ();

            Mass = TrimZeros (Mass);
            MassErrorMin = TrimZeros (MassErrorMin);
            MassErrorMax = TrimZeros (MassErrorMax);

            MassSini = TrimZeros (MassSini);
            MassSiniErrorMin = TrimZeros (MassSiniErrorMin);
            MassSiniErrorMax = TrimZeros (MassSiniErrorMax);

            Radius = TrimZeros (Radius);
            RadiusErrorMin = TrimZeros (RadiusErrorMin);
            RadiusErrorMax = TrimZeros (RadiusErrorMax);

            OrbitalPeriod = TrimZeros (OrbitalPeriod);
            OrbitalPeriodErrorMin = TrimZeros (OrbitalPeriodErrorMin);
            OrbitalPeriodErrorMax = TrimZeros (OrbitalPeriodErrorMax);

            SemiMajorAxis = TrimZeros (SemiMajorAxis);
            SemiMajorAxisErrorMin = TrimZeros (SemiMajorAxisErrorMin);
            SemiMajorAxisErrorMax = TrimZeros (SemiMajorAxisErrorMax);

            Eccentricity = TrimZeros (Eccentricity);
            EccentricityErrorMin = TrimZeros (EccentricityErrorMin);
            EccentricityErrorMax = TrimZeros (EccentricityErrorMax);

            Inclination = TrimZeros (Inclination);
            InclinationErrorMin = TrimZeros (InclinationErrorMin);
            InclinationErrorMax = TrimZeros (InclinationErrorMax);

            TzeroTr = TrimZeros (TzeroTr);
            TzeroTrErrorMin = TrimZeros (TzeroTrErrorMin);
            TzeroTrErrorMax = TrimZeros (TzeroTrErrorMax);

            TzeroTrSec = TrimZeros (TzeroTrSec);
            TzeroTrSecErrorMin = TrimZeros (TzeroTrSecErrorMin);
            TzeroTrSecErrorMax = TrimZeros (TzeroTrSecErrorMax);

            LambdaAngle = TrimZeros (LambdaAngle);
            LambdaAngleErrorMin = TrimZeros (LambdaAngleErrorMin);
            LambdaAngleErrorMax = TrimZeros (LambdaAngleErrorMax);

            TzeroVr = TrimZeros (TzeroVr);
            TzeroVrErrorMin = TrimZeros (TzeroVrErrorMin);
            TzeroVrErrorMax = TrimZeros (TzeroVrErrorMax);

            TemperatureCalculated = TrimZeros (TemperatureCalculated);

            TemperatureMeasured = TrimZeros (TemperatureMeasured);

            TemperatureHotPointLo = TrimZeros (TemperatureHotPointLo);

            LogG = TrimZeros (LogG);

            Omega = TrimZeros (Omega);
            OmegaErrorMin = TrimZeros (OmegaErrorMin);
            OmegaErrorMax = TrimZeros (OmegaErrorMax);

            Tperi = TrimZeros (Tperi);
            TperiErrorMin = TrimZeros (TperiErrorMin);
            TperiErrorMax = TrimZeros (TperiErrorMax);

            ImpactParameter = TrimZeros (ImpactParameter);
            ImpactParameterErrorMin = TrimZeros (ImpactParameterErrorMin);
            ImpactParameterErrorMax = TrimZeros (ImpactParameterErrorMax);

            VelocitySemiamplitude = TrimZeros (VelocitySemiamplitude);
            VelocitySemiamplitudeErrorMin = TrimZeros (VelocitySemiamplitudeErrorMin);
            VelocitySemiamplitudeErrorMax = TrimZeros (VelocitySemiamplitudeErrorMax);

            GeometricAlbedo = TrimZeros (GeometricAlbedo);
            GeometricAlbedoErrorMin = TrimZeros (GeometricAlbedoErrorMin);
            GeometricAlbedoErrorMax = TrimZeros (GeometricAlbedoErrorMax);

            Tconj = TrimZeros (Tconj);
            TconjErrorMin = TrimZeros (TconjErrorMin);
            TconjErrorMax = TrimZeros (TconjErrorMax);

            Star.Magnitude.V = TrimZeros (Star.Magnitude.V);
            Star.Magnitude.I = TrimZeros (Star.Magnitude.I);
            Star.Magnitude.J = TrimZeros (Star.Magnitude.J);
            Star.Magnitude.H = TrimZeros (Star.Magnitude.H);
            Star.Magnitude.K = TrimZeros (Star.Magnitude.K);

            Star.Property.Distance = TrimZeros (Star.Property.Distance);
            Star.Property.DistanceErrorMin = TrimZeros (Star.Property.DistanceErrorMin);
            Star.Property.DistanceErrorMax = TrimZeros (Star.Property.DistanceErrorMax);

            Star.Property.Distance = TrimZeros (Star.Property.Distance);
            Star.Property.DistanceErrorMin = TrimZeros (Star.Property.DistanceErrorMin);
            Star.Property.DistanceErrorMax = TrimZeros (Star.Property.DistanceErrorMax);

            Star.Property.Metallicity = TrimZeros (Star.Property.Metallicity);
            Star.Property.MetallicityErrorMin = TrimZeros (Star.Property.MetallicityErrorMin);
            Star.Property.MetallicityErrorMax = TrimZeros (Star.Property.MetallicityErrorMax);

            Star.Property.Mass = TrimZeros (Star.Property.Mass);
            Star.Property.MassErrorMin = TrimZeros (Star.Property.MassErrorMin);
            Star.Property.MassErrorMax = TrimZeros (Star.Property.MassErrorMax);

            Star.Property.Radius = TrimZeros (Star.Property.Radius);
            Star.Property.RadiusErrorMin = TrimZeros (Star.Property.RadiusErrorMin);
            Star.Property.RadiusErrorMax = TrimZeros (Star.Property.RadiusErrorMax);

            Star.Property.Age = TrimZeros (Star.Property.Age);
            Star.Property.AgeErrorMin = TrimZeros (Star.Property.AgeErrorMin);
            Star.Property.AgeErrorMax = TrimZeros (Star.Property.AgeErrorMax);

            Star.Property.Teff = TrimZeros (Star.Property.Teff);
            Star.Property.TeffErrorMin = TrimZeros (Star.Property.TeffErrorMin);
            Star.Property.TeffErrorMax = TrimZeros (Star.Property.TeffErrorMax);
            }

        public bool IsDetectionDefined ()
            {
            return DetectionType != null ? true : false;
            }

        public void TrimZeros (string value, string value2, string value3)
            {
            if (Helper.IsDefined (value))
                value = TrimZeros (value);

            if (Helper.IsDefined (value2))
                value2 = TrimZeros (value2);

            if (Helper.IsDefined (value3))
                value3 = TrimZeros (value3);
            }

        static private string TrimZeros (string value)
            {
            if (Helper.IsDefined (value))
                if (value.Contains ("e-"))
                    return value;
                else if (value.Contains ("e+"))
                    return value;
                else
                    {
                    string stringer = value.TrimEnd ('0');

                    if (stringer.EndsWith ("."))
                        stringer = stringer + "0";

                    return stringer;
                    }
            else
                return string.Empty;
            }
        }

    public class Star
        {
        public Star ()
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

        private string AlternateNames_;
        public string AlternateNames
            {
            get { return AlternateNames_; }
            set { AlternateNames_ = value; }
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
        public Magnitude ()
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
        public Property ()
            {
            }

        private string Distance_;
        public string Distance
            {
            get { return Distance_; }
            set { Distance_ = value; }
            }

        private string DistanceErrorMin_;
        public string DistanceErrorMin
            {
            get { return DistanceErrorMin_; }
            set { DistanceErrorMin_ = value; }
            }

        private string DistanceErrorMax_;
        public string DistanceErrorMax
            {
            get { return DistanceErrorMax_; }
            set { DistanceErrorMax_ = value; }
            }

        private string Metallicity_;
        public string Metallicity
            {
            get { return Metallicity_; }
            set { Metallicity_ = value; }
            }

        private string MetallicityErrorMin_;
        public string MetallicityErrorMin
            {
            get { return MetallicityErrorMin_; }
            set { MetallicityErrorMin_ = value; }
            }

        private string MetallicityErrorMax_;
        public string MetallicityErrorMax
            {
            get { return MetallicityErrorMax_; }
            set { MetallicityErrorMax_ = value; }
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

        private string AgeErrorMin_;
        public string AgeErrorMin
            {
            get { return AgeErrorMin_; }
            set { AgeErrorMin_ = value; }
            }

        private string AgeErrorMax_;
        public string AgeErrorMax
            {
            get { return AgeErrorMax_; }
            set { AgeErrorMax_ = value; }
            }

        private string Teff_;
        public string Teff
            {
            get { return Teff_; }
            set { Teff_ = value; }
            }

        private string TeffErrorMin_;
        public string TeffErrorMin
            {
            get { return TeffErrorMin_; }
            set { TeffErrorMin_ = value; }
            }

        private string TeffErrorMax_;
        public string TeffErrorMax
            {
            get { return TeffErrorMax_; }
            set { TeffErrorMax_ = value; }
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
