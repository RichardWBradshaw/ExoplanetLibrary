namespace ExoplanetLibrary
    {

    public class Indexer
        {
        static public int Name;

        static public int Mass;
        static public int MassErrorMin;
        static public int MassErrorMax;

        static public int MassSini;
        static public int MassSiniErrorMin;
        static public int MassSiniErrorMax;

        static public int Radius;
        static public int RadiusErrorMin;
        static public int RadiusErrorMax;

        static public int OrbitalPeriod;
        static public int OrbitalPeriodErrorMin;
        static public int OrbitalPeriodErrorMax;

        static public int SemiMajorAxis;
        static public int SemiMajorAxisErrorMin;
        static public int SemiMajorAxisErrorMax;

        static public int Eccentricity;
        static public int EccentricityErrorMin;
        static public int EccentricityErrorMax;

        static public int AngularDistance;

        static public int Inclination;
        static public int InclinationErrorMin;
        static public int InclinationErrorMax;

        static public int TzeroTr;
        static public int TzeroTrErrorMin;
        static public int TzeroTrErrorMax;

        static public int TzeroTrSec;
        static public int TzeroTrSecErrorMin;
        static public int TzeroTrSecErrorMax;

        static public int LambdaAngle;
        static public int LambdaAngleErrorMin;
        static public int LambdaAngleErrorMax;

        static public int TzeroVr;
        static public int TzeroVrErrorMin;
        static public int TzeroVrErrorMax;

        static public int TemperatureCalculated;

        static public int TemperatureMeasured;

        static public int TemperatureHotPointLo;

        static public int LogG;

        static public int Status;

        static public int Discovered;

        static public int Updated;

        static public int Omega;
        static public int OmegaErrorMin;
        static public int OmegaErrorMax;

        static public int Tperi;
        static public int TperiErrorMin;
        static public int TperiErrorMax;

        static public int DetectionType;
        static public int DetectionTypeAstrometry;
        static public int DetectionTypeMicroLensing;
        static public int DetectionTypeTiming;
        static public int DetectionTypeImaging;

        static public int Molecules;

        static public int ImpactParameter;
        static public int ImpactParameterErrorMin;
        static public int ImpactParameterErrorMax;

        static public int VelocitySemiamplitude;
        static public int VelocitySemiamplitudeErrorMin;
        static public int VelocitySemiamplitudeErrorMax;

        static public int GeometricAlbedo;
        static public int GeometricAlbedoErrorMin;
        static public int GeometricAlbedoErrorMax;

        static public int Tconj;
        static public int TconjErrorMin;
        static public int TconjErrorMax;

        static public int MassDetectionType;

        static public int RadiusDetectionType;

        static public int AlternateNames;

        static public int StarName;
        static public int StarRightAccession;
        static public int StarDeclination;

        static public int StarMagnitudeV;
        static public int StarMagnitudeI;
        static public int StarMagnitudeJ;
        static public int StarMagnitudeH;
        static public int StarMagnitudeK;

        static public int StarDistance;
        static public int StarDistanceErrorMin;
        static public int StarDistanceErrorMax;

        static public int StarMetallicity;
        static public int StarMetallicityErrorMin;
        static public int StarMetallicityErrorMax;

        static public int StarMass;
        static public int StarMassErrorMin;
        static public int StarMassErrorMax;

        static public int StarRadius;
        static public int StarRadiusErrorMin;
        static public int StarRadiusErrorMax;

        static public int StarSPType;

        static public int StarAge;
        static public int StarAgeErrorMin;
        static public int StarAgeErrorMax;

        static public int StarTeff;
        static public int StarTeffErrorMin;
        static public int StarTeffErrorMax;

        static public int StarDetectedDisc;

        static public int StarMagneticField;

        static public int StarAlternateNames;

        static public int HDName;

        static public int HIPName;

        static public void Initialize ()
            {
            Name = int.MinValue;

            Mass = int.MinValue;
            MassErrorMin = int.MinValue;
            MassErrorMax = int.MinValue;

            MassSini = int.MinValue;
            MassSiniErrorMin = int.MinValue;
            MassSiniErrorMax = int.MinValue;

            Radius = int.MinValue;
            RadiusErrorMin = int.MinValue;
            RadiusErrorMax = int.MinValue;

            OrbitalPeriod = int.MinValue;
            OrbitalPeriodErrorMin = int.MinValue;
            OrbitalPeriodErrorMax = int.MinValue;

            SemiMajorAxis = int.MinValue;
            SemiMajorAxisErrorMin = int.MinValue;
            SemiMajorAxisErrorMax = int.MinValue;

            Eccentricity = int.MinValue;
            EccentricityErrorMin = int.MinValue;
            EccentricityErrorMax = int.MinValue;

            AngularDistance = int.MinValue;

            Inclination = int.MinValue;
            InclinationErrorMin = int.MinValue;
            InclinationErrorMax = int.MinValue;

            TzeroTr = int.MinValue;
            TzeroTrErrorMin = int.MinValue;
            TzeroTrErrorMax = int.MinValue;

            TzeroTrSec = int.MinValue;
            TzeroTrSecErrorMin = int.MinValue;
            TzeroTrSecErrorMax = int.MinValue;

            LambdaAngle = int.MinValue;
            LambdaAngleErrorMin = int.MinValue;
            LambdaAngleErrorMax = int.MinValue;

            TzeroVr = int.MinValue;
            TzeroVrErrorMin = int.MinValue;
            TzeroVrErrorMax = int.MinValue;

            TemperatureCalculated = int.MinValue;

            TemperatureMeasured = int.MinValue;

            TemperatureHotPointLo = int.MinValue;

            LogG = int.MinValue;

            Status = int.MinValue;

            Discovered = int.MinValue;

            Updated = int.MinValue;

            Omega = int.MinValue;
            OmegaErrorMin = int.MinValue;
            OmegaErrorMax = int.MinValue;

            Tperi = int.MinValue;
            TperiErrorMin = int.MinValue;
            TperiErrorMax = int.MinValue;

            DetectionType = int.MinValue;
            DetectionTypeAstrometry = int.MinValue;
            DetectionTypeMicroLensing = int.MinValue;
            DetectionTypeTiming = int.MinValue;
            DetectionTypeImaging = int.MinValue;

            Molecules = int.MinValue;

            ImpactParameter = int.MinValue;
            ImpactParameterErrorMin = int.MinValue;
            ImpactParameterErrorMax = int.MinValue;

            VelocitySemiamplitude = int.MinValue;
            VelocitySemiamplitudeErrorMin = int.MinValue;
            VelocitySemiamplitudeErrorMax = int.MinValue;

            GeometricAlbedo = int.MinValue;
            GeometricAlbedoErrorMin = int.MinValue;
            GeometricAlbedoErrorMax = int.MinValue;

            Tconj = int.MinValue;
            TconjErrorMin = int.MinValue;
            TconjErrorMax = int.MinValue;

            MassDetectionType = int.MinValue;

            RadiusDetectionType = int.MinValue;

            AlternateNames = int.MinValue;

            StarName = int.MinValue;
            StarRightAccession = int.MinValue;
            StarDeclination = int.MinValue;

            StarMagnitudeV = int.MinValue;
            StarMagnitudeI = int.MinValue;
            StarMagnitudeJ = int.MinValue;
            StarMagnitudeH = int.MinValue;
            StarMagnitudeK = int.MinValue;

            StarDistance = int.MinValue;
            StarDistanceErrorMin = int.MinValue;
            StarDistanceErrorMax = int.MinValue;

            StarMetallicity = int.MinValue;
            StarMetallicityErrorMin = int.MinValue;
            StarMetallicityErrorMax = int.MinValue;

            StarMass = int.MinValue;
            StarMassErrorMin = int.MinValue;
            StarMassErrorMax = int.MinValue;

            StarRadius = int.MinValue;
            StarRadiusErrorMin = int.MinValue;
            StarRadiusErrorMax = int.MinValue;

            StarSPType = int.MinValue;

            StarAge = int.MinValue;
            StarAgeErrorMin = int.MinValue;
            StarAgeErrorMax = int.MinValue;

            StarTeff = int.MinValue;
            StarTeffErrorMin = int.MinValue;
            StarTeffErrorMax = int.MinValue;

            StarDetectedDisc = int.MinValue;

            StarMagneticField = int.MinValue;

            StarAlternateNames = int.MinValue;
            }

        static public void SetAllIndex (string stringer)
            {
            char [] delimiterChars = { ',', '\t' };
            string [] strings = stringer.Split (delimiterChars);
            int numberOfStrings = strings.Length;

            if (strings [0].StartsWith ("# "))
                strings [0] = strings [0].Replace ("# ", string.Empty);

            Initialize ();

            for (int index = 0; index < numberOfStrings; ++index)
                SetIndex (strings [index], index);
            }

        static public void SetIndex (string substring, int index)
            {
            switch (substring.Trim ())
                {
                case "name": Name = index; break;

                case "mass": Mass = index; break;
                case "mass_err_min": MassErrorMin = index; break;
                case "mass_err_max": MassErrorMax = index; break;
                case "mass_error_min": MassErrorMin = index; break;
                case "mass_error_max": MassErrorMax = index; break;

                case "mass_sini": MassSini = index; break;
                case "mass_sini_error_min": MassSiniErrorMin = index; break;
                case "mass_sini_error_max": MassSiniErrorMax = index; break;

                case "radius": Radius = index; break;
                case "radius_error_min": RadiusErrorMin = index; break;
                case "radius_error_max": RadiusErrorMax = index; break;

                case "orbital_period": OrbitalPeriod = index; break;
                case "orbital_period_err_min": OrbitalPeriodErrorMin = index; break;
                case "orbital_period_err_max": OrbitalPeriodErrorMax = index; break;
                case "orbital_period_error_min": OrbitalPeriodErrorMin = index; break;
                case "orbital_period_error_max": OrbitalPeriodErrorMax = index; break;

                case "semi_major_axis": SemiMajorAxis = index; break;
                case "semi_major_axis_error_min": SemiMajorAxisErrorMin = index; break;
                case "semi_major_axis_error_max": SemiMajorAxisErrorMax = index; break;

                case "eccentricity": Eccentricity = index; break;
                case "eccentricity_error_min": EccentricityErrorMin = index; break;
                case "eccentricity_error_max": EccentricityErrorMax = index; break;

                case "inclination": Inclination = index; break;
                case "inclination_error_min": InclinationErrorMin = index; break;
                case "inclination_error_max": InclinationErrorMax = index; break;

                case "angular_distance": AngularDistance = index; break;

                case "discovered": Discovered = index; break;

                case "updated": Updated = index; break;

                case "omega": Omega = index; break;
                case "omega_error_min": OmegaErrorMin = index; break;
                case "omega_error_max": OmegaErrorMax = index; break;

                case "tperi": Tperi = index; break;
                case "tperi_error_min": TperiErrorMin = index; break;
                case "tperi_error_max": TperiErrorMax = index; break;

                case "tconj": Tconj = index; break;
                case "tconj_error_min": TconjErrorMin = index; break;
                case "tconj_error_max": TconjErrorMax = index; break;

                case "tzero_tr": TzeroTr = index; break;
                case "tzero_tr_error_min": TzeroTrErrorMin = index; break;
                case "tzero_tr_error_max": TzeroTrErrorMax = index; break;

                case "tzero_tr_sec": TzeroTrSec = index; break;
                case "tzero_tr_sec_error_min": TzeroTrSecErrorMin = index; break;
                case "tzero_tr_sec_error_max": TzeroTrSecErrorMax = index; break;

                case "lambda_angle": LambdaAngle = index; break;
                case "lambda_angle_error_min": LambdaAngleErrorMin = index; break;
                case "lambda_angle_error_max": LambdaAngleErrorMax = index; break;

                case "impact_parameter": ImpactParameter = index; break;
                case "impact_parameter_error_min": ImpactParameterErrorMin = index; break;
                case "impact_parameter_error_max": ImpactParameterErrorMax = index; break;

                case "tzero_vr": TzeroVr = index; break;
                case "tzero_vr_error_min": TzeroVrErrorMin = index; break;
                case "tzero_vr_error_max": TzeroVrErrorMax = index; break;

                case "k": VelocitySemiamplitude = index; break;
                case "k_error_min": VelocitySemiamplitudeErrorMin = index; break;
                case "k_error_max": VelocitySemiamplitudeErrorMax = index; break;

                case "temp_calculated": TemperatureCalculated = index; break;

                case "temp_measured": TemperatureMeasured = index; break;

                case "hot_point_lon": TemperatureHotPointLo = index; break;

                case "geometric_albedo": GeometricAlbedo = index; break;
                case "geometric_albedo_error_min": GeometricAlbedoErrorMin = index; break;
                case "geometric_albedo_error_max": GeometricAlbedoErrorMax = index; break;

                case "log_g": LogG = index; break;

                case "publication_status": Status = index; break;

                case "detection_type": DetectionType = index; break;

                case "mass_detection_type": MassDetectionType = index; break;

                case "radius_detection_type": RadiusDetectionType = index; break;

                case "alternate_names":                         // .csv and .dat use the save name for planet and stellar alternate names
                    if (AlternateNames == int.MinValue)         // planet alternate name
                        AlternateNames = index;
                    else
                        StarAlternateNames = index;             // star alternate name

                    break;

                case "molecules": Molecules = index; break;

                case "star_name": StarName = index; break;
                case "ra": StarRightAccession = index; break;
                case "dec": StarDeclination = index; break;

                case "mag_v": StarMagnitudeV = index; break;
                case "mag_i": StarMagnitudeI = index; break;
                case "mag_j": StarMagnitudeJ = index; break;
                case "mag_h": StarMagnitudeH = index; break;
                case "mag_k": StarMagnitudeK = index; break;

                case "star_distance": StarDistance = index; break;
                case "star_distance_error_min": StarDistanceErrorMin = index; break;
                case "star_distance_error_max": StarDistanceErrorMax = index; break;

                case "star_metallicity": StarMetallicity = index; break;
                case "star_metallicity_error_min": StarMetallicityErrorMin = index; break;
                case "star_metallicity_error_max": StarMetallicityErrorMax = index; break;

                case "star_mass": StarMass = index; break;
                case "star_mass_error_min": StarMassErrorMin = index; break;
                case "star_mass_error_max": StarMassErrorMax = index; break;

                case "star_radius": StarRadius = index; break;
                case "star_radius_error_min": StarRadiusErrorMin = index; break;
                case "star_radius_error_max": StarRadiusErrorMax = index; break;

                case "star_sp_type": StarSPType = index; break;

                case "star_age": StarAge = index; break;
                case "star_age_error_min": StarAgeErrorMin = index; break;
                case "star_age_error_max": StarAgeErrorMax = index; break;

                case "star_teff": StarTeff = index; break;
                case "star_teff_error_min": StarTeffErrorMin = index; break;
                case "star_teff_error_max": StarTeffErrorMax = index; break;

                case "star_detected_disc": StarDetectedDisc = index; break;

                case "star_magnetic_field": StarMagneticField = index; break;

                case "star_alternate_names": StarAlternateNames = index; break;

                //

                case "rowid": break;

                case "pl_hostname": StarName = index; break;
                case "pl_letter": break;

                case "pl_discmethod": DetectionType = index; break;

                case "pl_pnum": break;

                case "pl_orbper": OrbitalPeriod = index; break;
                case "pl_orbpererr1": OrbitalPeriodErrorMax = index; break;
                case "pl_orbpererr2": OrbitalPeriodErrorMin = index; break;
                case "pl_orbperlim": break;

                case "pl_orbsmax": SemiMajorAxis = index; break;
                case "pl_orbsmaxerr1": SemiMajorAxisErrorMax = index; break;
                case "pl_orbsmaxerr2": SemiMajorAxisErrorMin = index; break;
                case "pl_orbsmaxlim": break;

                case "pl_orbeccen": Eccentricity = index; break;
                case "pl_orbeccenerr1": EccentricityErrorMax = index; break;
                case "pl_orbeccenerr2": EccentricityErrorMin = index; break;
                case "pl_orbeccenlim": break;

                case "pl_orbincl": Inclination = index; break;
                case "pl_orbinclerr1": InclinationErrorMax = index; break;
                case "pl_orbinclerr2": InclinationErrorMin = index; break;
                case "pl_orbincllim": break;

                case "pl_bmassj": break;
                case "pl_bmassjerr1": break;
                case "pl_bmassjerr2": break;
                case "pl_bmassjlim": break;
                case "pl_bmassprov": break;

                case "pl_radj": Radius = index; break;
                case "pl_radjerr1": RadiusErrorMax = index; break;
                case "pl_radjerr2": RadiusErrorMin = index; break;
                case "pl_radjlim": break;

                case "pl_dens": break;
                case "pl_denserr1": break;
                case "pl_denserr2": break;
                case "pl_denslim": break;

                case "pl_ttvflag": break;

                case "pl_kepflag": break;

                case "pl_k2flag": break;

                case "pl_nnotes": break;

                case "pl_name": Name = index; break;

                case "pl_tranflag": break;

                case "pl_rvflag": break;

                case "pl_imgflag": break;

                case "pl_astflag": break;

                case "pl_omflag": break;

                case "pl_cbflag": break;

                case "pl_orbtper": break;
                case "pl_orbtpererr1": break;
                case "pl_orbtpererr2": break;
                case "pl_orbtperlim": break;

                case "pl_orblper": break;
                case "pl_orblpererr1": break;
                case "pl_orblpererr2": break;
                case "pl_orblperlim": break;

                case "pl_rvamp": break;
                case "pl_rvamperr1": break;
                case "pl_rvamperr2": break;
                case "pl_rvamplim": break;

                case "pl_eqt": break;
                case "pl_eqterr1": break;
                case "pl_eqterr2": break;
                case "pl_eqtlim": break;

                case "pl_insol": break;
                case "pl_insolerr1": break;
                case "pl_insolerr2": break;
                case "pl_insollim": break;

                case "pl_massj": Mass = index; break;
                case "pl_massjerr1": MassErrorMax = index; break;
                case "pl_massjerr2": MassErrorMin = index; break;
                case "pl_massjlim": break;

                case "pl_msinij": MassSini = index; break;
                case "pl_msinijerr1": MassSiniErrorMax = index; break;
                case "pl_msinijerr2": MassSiniErrorMin = index; break;
                case "pl_msinijlim": break;

                case "pl_masse": break;
                case "pl_masseerr1": break;
                case "pl_masseerr2": break;
                case "pl_masselim": break;

                case "pl_msinie": break;
                case "pl_msinieerr1": break;
                case "pl_msinieerr2": break;
                case "pl_msinielim": break;

                case "pl_bmasse": break;
                case "pl_bmasseerr1": break;
                case "pl_bmasseerr2": break;
                case "pl_bmasselim": break;

                case "pl_rade": break;
                case "pl_radeerr1": break;
                case "pl_radeerr2": break;
                case "pl_radelim": break;

                case "pl_rads": break;
                case "pl_radserr1": break;
                case "pl_radserr2": break;
                case "pl_radslim": break;

                case "pl_trandep": break;
                case "pl_trandeperr1": break;
                case "pl_trandeperr2": break;
                case "pl_trandeplim": break;

                case "pl_trandur": break;
                case "pl_trandurerr1": break;
                case "pl_trandurerr2": break;
                case "pl_trandurlim": break;

                case "pl_tranmid": break;
                case "pl_tranmiderr1": break;
                case "pl_tranmiderr2": break;
                case "pl_tranmidlim": break;

                case "pl_tsystemref": break;

                case "pl_imppar": ImpactParameter = index; break;
                case "pl_impparerr1": ImpactParameterErrorMax = index; break;
                case "pl_impparerr2": ImpactParameterErrorMin = index; break;
                case "pl_impparlim": break;

                case "pl_occdep": break;
                case "pl_occdeperr1": break;
                case "pl_occdeperr2": break;
                case "pl_occdeplim": break;

                case "pl_ratdor": break;
                case "pl_ratdorerr1": break;
                case "pl_ratdorerr2": break;
                case "pl_ratdorlim": break;

                case "pl_ratror": break;
                case "pl_ratrorerr1": break;
                case "pl_ratrorerr2": break;
                case "pl_ratrorlim": break;

                case "pl_def_reflink": break;

                case "pl_disc": Discovered = index; break;

                case "pl_disc_reflink": break;

                case "pl_locale": break;
                case "pl_facility": break;
                case "pl_telescope": break;
                case "pl_instrument": break;
                case "pl_status": break;
                case "pl_mnum": break;
                case "pl_st_npar": break;
                case "pl_st_nref": break;
                case "pl_pelink": break;
                case "pl_edelink": break;
                case "pl_publ_date": break;

                case "st_dist": StarDistance = index; break;
                case "st_disterr1": StarDistanceErrorMax = index; break;
                case "st_disterr2": StarDistanceErrorMin = index; break;
                case "st_distlim": break;

                case "st_optmag": break;
                case "st_optmagerr": break;
                case "st_optmaglim": break;
                case "st_optmagblend": break;
                case "st_optband": break;

                case "st_teff": StarTeff = index; break;
                case "st_tefferr1": StarTeffErrorMax = index; break;
                case "st_tefferr2": StarTeffErrorMin = index; break;
                case "st_tefflim": break;
                case "st_teffblend": break;

                case "st_mass": StarMass = index; break;
                case "st_masserr1": StarMassErrorMax = index; break;
                case "st_masserr2": StarMassErrorMin = index; break;
                case "st_masslim": break;
                case "st_massblend": break;

                case "st_rad": StarRadius = index; break;
                case "st_raderr1": StarRadiusErrorMax = index; break;
                case "st_raderr2": StarRadiusErrorMin = index; break;
                case "st_radlim": break;
                case "st_radblend": break;

                case "st_rah": break;

                case "st_glon": break;
                case "st_glat": break;
                case "st_elon": break;
                case "st_elat": break;

                case "st_plx": break;
                case "st_plxerr1": break;
                case "st_plxerr2": break;
                case "st_plxlim": break;
                case "st_plxblend": break;

                case "st_pmra": break;
                case "st_pmraerr": break;
                case "st_pmralim": break;

                case "st_pmdec": break;
                case "st_pmdecerr": break;
                case "st_pmdeclim": break;

                case "st_pm": break;
                case "st_pmerr": break;
                case "st_pmlim": break;
                case "st_pmblend": break;

                case "st_radv": break;
                case "st_radverr1": break;
                case "st_radverr2": break;
                case "st_radvlim": break;
                case "st_radvblend": break;

                case "st_sp": break;
                case "st_spstr": StarSPType = index; break;
                case "st_sperr": break;
                case "st_splim": break;
                case "st_spblend": break;

                case "st_logg": break;
                case "st_loggerr1": break;
                case "st_loggerr2": break;
                case "st_logglim": break;
                case "st_loggblend": break;

                case "st_lum": break;
                case "st_lumerr1": break;
                case "st_lumerr2": break;
                case "st_lumlim": break;
                case "st_lumblend": break;

                case "st_dens": break;
                case "st_denserr1": break;
                case "st_denserr2": break;
                case "st_denslim": break;

                case "st_metfe": StarMetallicity = index; break;
                case "st_metfeerr1": StarMetallicityErrorMax = index; break;
                case "st_metfeerr2": StarMetallicityErrorMin = index; break;
                case "st_metfelim": break;
                case "st_metfeblend": break;
                case "st_metratio": break;

                case "st_age": StarAge = index; break;
                case "st_ageerr1": StarAgeErrorMax = index; break;
                case "st_ageerr2": StarAgeErrorMin = index; break;
                case "st_agelim": break;

                case "st_vsini": break;
                case "st_vsinierr1": break;
                case "st_vsinierr2": break;
                case "st_vsinilim": break;
                case "st_vsiniblend": break;
                case "st_acts": break;
                case "st_actserr": break;
                case "st_actslim": break;
                case "st_actsblend": break;
                case "st_actr": break;
                case "st_actrerr": break;
                case "st_actrlim": break;
                case "st_actrblend": break;
                case "st_actlx": break;
                case "st_actlxerr": break;
                case "st_actlxlim": break;
                case "st_actlxblend": break;
                case "st_nts": break;
                case "st_nplc": break;
                case "st_nglc": break;
                case "st_nrvc": break;
                case "st_naxa": break;
                case "st_nimg": break;
                case "st_nspec": break;

                case "st_uj": break;
                case "st_ujerr": break;
                case "st_ujlim": break;
                case "st_ujblend": break;

                case "st_vj": StarMagnitudeV = index; break;
                case "st_vjerr": break;
                case "st_vjlim": break;
                case "st_vjblend": break;

                case "st_bj": break;
                case "st_bjerr": break;
                case "st_bjlim": break;
                case "st_bjblend": break;

                case "st_rc": break;
                case "st_rcerr": break;
                case "st_rclim": break;
                case "st_rcblend": break;

                case "st_ic": StarMagnitudeI = index; break;
                case "st_icerr": break;
                case "st_iclim": break;
                case "st_icblend": break;

                case "st_j": StarMagnitudeJ = index; break;
                case "st_jerr": break;
                case "st_jlim": break;
                case "st_jblend": break;

                case "st_h": StarMagnitudeH = index; break;
                case "st_herr": break;
                case "st_hlim": break;
                case "st_hblend": break;

                case "st_k": StarMagnitudeK = index; break;
                case "st_kerr": break;
                case "st_klim": break;
                case "st_kblend": break;

                case "st_wise1": break;
                case "st_wise1err": break;
                case "st_wise1lim": break;
                case "st_wise1blend": break;
                case "st_wise2": break;
                case "st_wise2err": break;
                case "st_wise2lim": break;
                case "st_wise2blend": break;
                case "st_wise3": break;
                case "st_wise3err": break;
                case "st_wise3lim": break;
                case "st_wise3blend": break;
                case "st_wise4": break;
                case "st_wise4err": break;
                case "st_wise4lim": break;
                case "st_wise4blend": break;
                case "st_irac1": break;
                case "st_irac1err": break;
                case "st_irac1lim": break;
                case "st_irac1blend": break;
                case "st_irac2": break;
                case "st_irac2err": break;
                case "st_irac2lim": break;
                case "st_irac2blend": break;
                case "st_irac3": break;
                case "st_irac3err": break;
                case "st_irac3lim": break;
                case "st_irac3blend": break;
                case "st_irac4": break;
                case "st_irac4err": break;
                case "st_irac4lim": break;
                case "st_irac4blend": break;
                case "st_mips1": break;
                case "st_mips1err": break;
                case "st_mips1lim": break;
                case "st_mips1blend": break;
                case "st_mips2": break;
                case "st_mips2err": break;
                case "st_mips2lim": break;
                case "st_mips2blend": break;
                case "st_mips3": break;
                case "st_mips3err": break;
                case "st_mips3lim": break;
                case "st_mips3blend": break;
                case "st_iras1": break;
                case "st_iras1err": break;
                case "st_iras1lim": break;
                case "st_iras1blend": break;
                case "st_iras2": break;
                case "st_iras2err": break;
                case "st_iras2lim": break;
                case "st_iras2blend": break;
                case "st_iras3": break;
                case "st_iras3err": break;
                case "st_iras3lim": break;
                case "st_iras3blend": break;
                case "st_iras4": break;
                case "st_iras4err": break;
                case "st_iras4lim": break;
                case "st_iras4blend": break;
                case "st_photn": break;
                case "st_umbj": break;
                case "st_umbjerr": break;
                case "st_umbjlim": break;
                case "st_umbjblend": break;
                case "st_bmvj": break;
                case "st_bmvjerr": break;
                case "st_bmvjlim": break;
                case "st_bmvjblend": break;
                case "st_vjmic": break;
                case "st_vjmicerr": break;
                case "st_vjmiclim": break;
                case "st_vjmicblend": break;
                case "st_vjmrc": break;
                case "st_vjmrcerr": break;
                case "st_vjmrclim": break;
                case "st_vjmrcblend": break;
                case "st_jmh2": break;
                case "st_jmh2err": break;
                case "st_jmh2lim": break;
                case "st_jmh2blend": break;
                case "st_hmk2": break;
                case "st_hmk2err": break;
                case "st_hmk2lim": break;
                case "st_hmk2blend": break;
                case "st_jmk2": break;
                case "st_jmk2err": break;
                case "st_jmk2lim": break;
                case "st_jmk2blend": break;
                case "st_bmy": break;
                case "st_bmyerr": break;
                case "st_bmylim": break;
                case "st_bmyblend": break;
                case "st_m1": break;
                case "st_m1err": break;
                case "st_m1lim": break;
                case "st_m1blend": break;
                case "st_c1": break;
                case "st_c1err": break;
                case "st_c1lim": break;
                case "st_c1blend": break;
                case "st_colorn": break;

                case "ra_str": break;
                case "dec_str": break;
                case "rowupdate": Updated = index; break;

                case "swasp_id": break;
                case "hd_name": HDName = index; break;
                case "hip_name": HIPName = index; break;
                case "id": break;

                //

                case "kepid": break;
                case "kepoi_name": StarName = index; break;
                case "kepler_name": Name = index; break;
                case "koi_disposition": break;
                case "koi_vet_stat": break;
                case "koi_vet_date": break;
                case "koi_pdisposition": break;
                case "koi_fpflag_nt": break;
                case "koi_fpflag_ss": break;
                case "koi_fpflag_co": break;
                case "koi_fpflag_ec": break;
                case "koi_disp_prov": break;
                case "koi_comment": break;

                case "koi_period": OrbitalPeriod = index; break;
                case "koi_period_err1": OrbitalPeriodErrorMax = index; break;
                case "koi_period_err2": OrbitalPeriodErrorMin = index; break;

                case "koi_time0bk": break;
                case "koi_time0bk_err1": break;
                case "koi_time0bk_err2": break;
                case "koi_time0": break;
                case "koi_time0_err1": break;
                case "koi_time0_err2": break;

                case "koi_eccen": Eccentricity = index; break;
                case "koi_eccen_err1": EccentricityErrorMax = index; break;
                case "koi_eccen_err2": EccentricityErrorMin = index; break;

                case "koi_longp": break;
                case "koi_longp_err1": break;
                case "koi_longp_err2": break;

                case "koi_impact": ImpactParameter = index; break;
                case "koi_impact_err1": ImpactParameterErrorMax = index; break;
                case "koi_impact_err2": ImpactParameterErrorMin = index; break;

                case "koi_duration": break;
                case "koi_duration_err1": break;
                case "koi_duration_err2": break;
                case "koi_ingress": break;
                case "koi_ingress_err1": break;
                case "koi_ingress_err2": break;
                case "koi_depth": break;
                case "koi_depth_err1": break;
                case "koi_depth_err2": break;
                case "koi_ror": break;
                case "koi_ror_err1": break;
                case "koi_ror_err2": break;
                case "koi_srho": break;
                case "koi_srho_err1": break;
                case "koi_srho_err2": break;
                case "koi_fittype": break;

                case "koi_prad": Radius = index; break;                // needs_work Rearth
                case "koi_prad_err1": RadiusErrorMax = index; break;
                case "koi_prad_err2": RadiusErrorMin = index; break;

                case "koi_sma": SemiMajorAxis = index; break;
                case "koi_sma_err1": SemiMajorAxisErrorMax = index; break;
                case "koi_sma_err2": SemiMajorAxisErrorMin = index; break;

                case "koi_incl": Inclination = index; break;
                case "koi_incl_err1": InclinationErrorMax = index; break;
                case "koi_incl_err2": InclinationErrorMin = index; break;

                case "koi_teq": TemperatureMeasured = index; break;
                case "koi_teq_err1": break;
                case "koi_teq_err2": break;

                case "koi_insol": break;
                case "koi_insol_err1": break;
                case "koi_insol_err2": break;
                case "koi_dor": break;
                case "koi_dor_err1": break;
                case "koi_dor_err2": break;
                case "koi_limbdark_mod": break;
                case "koi_ldm_coeff4": break;
                case "koi_ldm_coeff3": break;
                case "koi_ldm_coeff2": break;
                case "koi_ldm_coeff1": break;
                case "koi_parm_prov": break;
                case "koi_max_sngle_ev": break;
                case "koi_max_mult_ev": break;
                case "koi_model_snr": break;
                case "koi_count": break;
                case "koi_num_transits": break;
                case "koi_tce_plnt_num": break;
                case "koi_tce_delivname": break;
                case "koi_quarters": break;
                case "koi_bin_oedp_sig": break;
                case "koi_trans_mod": break;
                case "koi_model_dof": break;
                case "koi_model_chisq": break;
                case "koi_datalink_dvr": break;
                case "koi_datalink_dvs": break;
                case "koi_steff": break;
                case "koi_steff_err1": break;
                case "koi_steff_err2": break;
                case "koi_slogg": break;
                case "koi_slogg_err1": break;
                case "koi_slogg_err2": break;
                case "koi_smet": break;
                case "koi_smet_err1": break;
                case "koi_smet_err2": break;

                case "koi_srad": StarRadius = index; break;
                case "koi_srad_err1": StarRadiusErrorMax = index; break;
                case "koi_srad_err2": StarRadiusErrorMin = index; break;

                case "koi_smass": StarMass = index; break;
                case "koi_smass_err1": StarMassErrorMax = index; break;
                case "koi_smass_err2": StarMassErrorMin = index; break;

                case "koi_sage": StarAge = index; break;
                case "koi_sage_err1": StarAgeErrorMax = index; break;
                case "koi_sage_err2": StarAgeErrorMin = index; break;

                case "koi_sparprov": break;
                case "koi_kepmag": break;
                case "koi_gmag": break;
                case "koi_rmag": break;
                case "koi_imag": StarMagnitudeI = index; break;
                case "koi_zmag": break;
                case "koi_jmag": StarMagnitudeJ = index; break;
                case "koi_hmag": StarMagnitudeH = index; break;
                case "koi_kmag": StarMagnitudeK = index; break;

                case "koi_fwm_stat_sig": break;
                case "koi_fwm_sra": break;
                case "koi_fwm_sra_err": break;
                case "koi_fwm_sdec": break;
                case "koi_fwm_sdec_err": break;
                case "koi_fwm_srao": break;
                case "koi_fwm_srao_err": break;
                case "koi_fwm_sdeco": break;
                case "koi_fwm_sdeco_err": break;
                case "koi_fwm_prao": break;
                case "koi_fwm_prao_err": break;
                case "koi_fwm_pdeco": break;
                case "koi_fwm_pdeco_err": break;
                case "koi_dicco_mra": break;
                case "koi_dicco_mra_err": break;
                case "koi_dicco_mdec": break;
                case "koi_dicco_mdec_err": break;
                case "koi_dicco_msky": break;
                case "koi_dicco_msky_err": break;
                case "koi_dicco_fra": break;
                case "koi_dicco_fra_err": break;
                case "koi_dicco_fdec": break;
                case "koi_dicco_fdec_err": break;
                case "koi_dicco_fsky": break;
                case "koi_dicco_fsky_err": break;
                case "koi_dikco_mra": break;
                case "koi_dikco_mra_err": break;
                case "koi_dikco_mdec": break;
                case "koi_dikco_mdec_err": break;
                case "koi_dikco_msky": break;
                case "koi_dikco_msky_err": break;
                case "koi_dikco_fra": break;
                case "koi_dikco_fra_err": break;
                case "koi_dikco_fdec": break;
                case "koi_dikco_fdec_err": break;
                case "koi_dikco_fsky": break;
                case "koi_dikco_fsky_err": break;

                //
                // Exoplanet.org key words
                //

                case "A": Indexer.SemiMajorAxis = index; break;
                case "AUPPER": Indexer.SemiMajorAxisErrorMax = index; break;
                case "ALOWER": Indexer.SemiMajorAxisErrorMin = index; break;

                case "UA": break;
                case "AREF": break;
                case "AURL": break;
                case "AR": break;
                case "ARUPPER": break;
                case "ARLOWER": break;
                case "UAR": break;
                case "ARREF": break;
                case "ARURL": break;

                case "ASTROMETRY": Indexer.DetectionTypeAstrometry = index; break;
                case "MICROLENSING": Indexer.DetectionTypeMicroLensing = index; break;
                case "TIMING": Indexer.DetectionTypeTiming = index; break;
                case "IMAGING": Indexer.DetectionTypeImaging = index; break;

                case "B": Indexer.ImpactParameter = index; break;
                case "BUPPER": Indexer.ImpactParameterErrorMax = index; break;
                case "BLOWER": Indexer.ImpactParameterErrorMin = index; break;

                case "UB": break;
                case "BREF": break;
                case "BURL": break;
                case "BIGOM": break;
                case "BIGOMUPPER": break;
                case "BIGOMLOWER": break;
                case "UBIGOM": break;
                case "BIGOMREF": break;
                case "BIGOMURL": break;
                case "BINARY": break;
                case "BINARYREF": break;
                case "BINARYURL": break;

                case "BMV": break;

                case "CHI2": break;
                case "COMP": break;

                case "DATE": Indexer.Discovered = index; break;

                case "DENSITY": break;
                case "DENSITYUPPER": break;
                case "DENSITYLOWER": break;
                case "UDENSITY": break;
                case "DENSITYREF": break;
                case "DENSITYURL": break;
                case "DEPTH": break;
                case "DEPTHUPPER": break;
                case "DEPTHLOWER": break;
                case "UDEPTH": break;
                case "DEPTHREF": break;
                case "DEPTHURL": break;

                case "DIST": Indexer.StarDistance = index; break;
                case "DISTUPPER": Indexer.StarDistanceErrorMax = index; break;
                case "DISTLOWER": Indexer.StarDistanceErrorMin = index; break;

                case "UDIST": break;
                case "DISTREF": break;
                case "DISTURL": break;
                case "DR": break;
                case "DRUPPER": break;
                case "DRLOWER": break;
                case "UDR": break;
                case "DRREF": break;
                case "DRURL": break;
                case "DVDT": break;
                case "DVDTUPPER": break;
                case "DVDTLOWER": break;
                case "UDVDT": break;
                case "DVDTREF": break;
                case "DVDTURL": break;
                case "EANAME": break;
                case "EAURL": break;

                case "ECC": Indexer.Eccentricity = index; break;
                case "ECCUPPER": Indexer.EccentricityErrorMax = index; break;
                case "ECCLOWER": Indexer.EccentricityErrorMin = index; break;

                case "UECC": break;
                case "ECCREF": break;
                case "ECCURL": break;
                case "EOD": break;
                case "ETDNAME": break;
                case "ETDURL": break;
                case "FE": break;
                case "FEUPPER": break;
                case "FELOWER": break;
                case "UFE": break;
                case "FEREF": break;
                case "FEURL": break;
                case "FIRSTREF": break;
                case "FIRSTURL": break;
                case "FREEZE_ECC": break;
                case "GAMMA": break;
                case "GAMMAUPPER": break;
                case "GAMMALOWER": break;
                case "UGAMMA": break;
                case "GAMMAREF": break;
                case "GAMMAURL": break;

                case "GRAVITY": break;
                case "GRAVITYUPPER": break;
                case "GRAVITYLOWER": break;
                case "UGRAVITY": break;
                case "GRAVITYREF": break;
                case "GRAVITYURL": break;

                case "GL": Indexer.StarAlternateNames = index; break;
                case "HD": Indexer.StarAlternateNames = index; break;
                case "HIPP": Indexer.StarAlternateNames = index; break;
                case "HR": Indexer.StarAlternateNames = index; break;
                case "SAO": Indexer.StarAlternateNames = index; break;

                case "I": Indexer.Inclination = index; break;
                case "IUPPER": Indexer.InclinationErrorMax = index; break;
                case "ILOWER": Indexer.InclinationErrorMin = index; break;

                case "UI": break;
                case "IREF": break;
                case "IURL": break;

                case "J": Indexer.StarMagnitudeJ = index; break;
                case "H": Indexer.StarMagnitudeH = index; break;
                case "V": Indexer.StarMagnitudeV = index; break;

                case "JSNAME": break;
                case "EPEURL": break;

                case "K": Indexer.VelocitySemiamplitude = index; break;
                case "KUPPER": Indexer.VelocitySemiamplitudeErrorMax = index; break;
                case "KLOWER": Indexer.VelocitySemiamplitudeErrorMin = index; break;

                case "UK": break;
                case "KREF": break;
                case "KURL": break;
                case "KOI": break;
                case "KS": break;
                case "KP": break;

                case "LAMBDA": Indexer.LambdaAngle = index; break;
                case "LAMBDAUPPER": Indexer.LambdaAngleErrorMax = index; break;
                case "LAMBDALOWER": Indexer.LambdaAngleErrorMin = index; break;

                case "ULAMBDA": break;
                case "LAMBDAREF": break;
                case "LAMBDAURL": break;

                case "LOGG": Indexer.LogG = index; break;
                case "LOGGUPPER": break;
                case "LOGGLOWER": break;

                case "ULOGG": break;
                case "LOGGREF": break;
                case "LOGGURL": break;

                case "MASS": Indexer.Mass = index; break;
                case "MASSUPPER": Indexer.MassErrorMax = index; break;
                case "MASSLOWER": Indexer.MassErrorMin = index; break;

                case "UMASS": break;
                case "MASSREF": break;
                case "MASSURL": break;

                case "MSINI": Indexer.MassSini = index; break;
                case "MSINIUPPER": Indexer.MassSiniErrorMin = index; break;
                case "MSINILOWER": Indexer.MassSiniErrorMin = index; break;

                case "UMSINI": break;
                case "MSINIREF": break;
                case "MSINIURL": break;

                case "MSTAR": Indexer.StarMass = index; break;
                case "MSTARUPPER": Indexer.StarMassErrorMax = index; break;
                case "MSTARLOWER": Indexer.StarMassErrorMin = index; break;

                case "UMSTAR": break;
                case "MSTARREF": break;
                case "MSTARURL": break;
                case "MULT": break;

                case "NAME": Indexer.Name = index; break;
                case "OTHERNAME": Indexer.AlternateNames = index; break;

                case "NCOMP": break;
                case "NOBS": break;
                case "OM": break;
                case "OMUPPER": break;
                case "OMLOWER": break;
                case "UOM": break;
                case "OMREF": break;
                case "OMURL": break;
                case "ORBREF": break;
                case "ORBURL": break;

                case "PAR": break;
                case "PARUPPER": break;
                case "PARLOWER": break;
                case "UPAR": break;

                case "PER": Indexer.OrbitalPeriod = index; break;
                case "PERUPPER": Indexer.OrbitalPeriodErrorMax = index; break;
                case "PERLOWER": Indexer.OrbitalPeriodErrorMin = index; break;

                case "UPER": break;
                case "PERREF": break;
                case "PERURL": break;
                case "PLANETDISCMETH": break;

                case "R": Indexer.Radius = index; break;
                case "RUPPER": Indexer.RadiusErrorMax = index; break;
                case "RLOWER": Indexer.RadiusErrorMin = index; break;

                case "UR": break;
                case "RREF": break;
                case "RURL": break;

                case "RA": Indexer.StarRightAccession = index; break;
                case "RA_STRING": break;
                case "DEC": Indexer.StarDeclination = index; break;
                case "DEC_STRING": break;

                case "RHK": break;
                case "RHOSTAR": break;
                case "RHOSTARUPPER": break;
                case "RHOSTARLOWER": break;
                case "URHOSTAR": break;
                case "RHOSTARREF": break;
                case "RHOSTARURL": break;
                case "RMS": break;
                case "RR": break;
                case "RRUPPER": break;
                case "RRLOWER": break;
                case "URR": break;
                case "RRREF": break;
                case "RRURL": break;

                case "RSTAR": Indexer.StarRadius = index; break;
                case "RSTARUPPER": Indexer.StarRadiusErrorMax = index; break;
                case "RSTARLOWER": Indexer.StarRadiusErrorMin = index; break;

                case "URSTAR": break;
                case "RSTARREF": break;
                case "RSTARURL": break;

                case "SE": break;
                case "SEREF": break;
                case "SEURL": break;
                case "SEDEPTHJ": break;
                case "SEDEPTHJUPPER": break;
                case "SEDEPTHJLOWER": break;
                case "USEDEPTHJ": break;
                case "SEDEPTHJREF": break;
                case "SEDEPTHJURL": break;
                case "SEDEPTHH": break;
                case "SEDEPTHHUPPER": break;
                case "SEDEPTHHLOWER": break;
                case "USEDEPTHH": break;
                case "SEDEPTHHREF": break;
                case "SEDEPTHHURL": break;
                case "SEDEPTHKS": break;
                case "SEDEPTHKSUPPER": break;
                case "SEDEPTHKSLOWER": break;
                case "USEDEPTHKS": break;
                case "SEDEPTHKSREF": break;
                case "SEDEPTHKSURL": break;
                case "SEDEPTHKP": break;
                case "SEDEPTHKPUPPER": break;
                case "SEDEPTHKPLOWER": break;
                case "USEDEPTHKP": break;
                case "SEDEPTHKPREF": break;
                case "SEDEPTHKPURL": break;
                case "SEDEPTH36": break;
                case "SEDEPTH36UPPER": break;
                case "SEDEPTH36LOWER": break;
                case "USEDEPTH36": break;
                case "SEDEPTH36REF": break;
                case "SEDEPTH36URL": break;
                case "SEDEPTH45": break;
                case "SEDEPTH45UPPER": break;
                case "SEDEPTH45LOWER": break;
                case "USEDEPTH45": break;
                case "SEDEPTH45REF": break;
                case "SEDEPTH45URL": break;
                case "SEDEPTH58": break;
                case "SEDEPTH58UPPER": break;
                case "SEDEPTH58LOWER": break;
                case "USEDEPTH58": break;
                case "SEDEPTH58REF": break;
                case "SEDEPTH58URL": break;
                case "SEDEPTH80": break;
                case "SEDEPTH80UPPER": break;
                case "SEDEPTH80LOWER": break;
                case "USEDEPTH80": break;
                case "SEDEPTH80REF": break;
                case "SEDEPTH80URL": break;
                case "SEP": break;
                case "SEPUPPER": break;
                case "SEPLOWER": break;
                case "USEP": break;
                case "SEPREF": break;
                case "SEPURL": break;
                case "SET": break;
                case "SETUPPER": break;
                case "SETLOWER": break;
                case "USET": break;
                case "SETREF": break;
                case "SETURL": break;
                case "SHK": break;
                case "SIMBADNAME": break;
                case "SIMBADURL": break;
                case "SPECREF": break;
                case "SPECURL": break;

                case "STAR": Indexer.StarName = index; break;

                case "STARDISCMETH": break;
                case "T0": break;
                case "T0UPPER": break;
                case "T0LOWER": break;
                case "UT0": break;
                case "T0REF": break;
                case "T0URL": break;
                case "T14": break;
                case "T14UPPER": break;
                case "T14LOWER": break;
                case "UT14": break;
                case "T14REF": break;
                case "T14URL": break;

                case "TEFF": Indexer.StarTeff = index; break;
                case "TEFFUPPER": Indexer.StarTeffErrorMax = index; break;
                case "TEFFLOWER": Indexer.StarTeffErrorMin = index; break;

                case "UTEFF": break;
                case "TEFFREF": break;
                case "TEFFURL": break;

                case "TRANSIT": break;
                case "TRANSITREF": break;
                case "TRANSITURL": break;
                case "TREND": break;
                case "TT": break;
                case "TTUPPER": break;
                case "TTLOWER": break;
                case "UTT": break;
                case "TTREF": break;
                case "TTURL": break;

                case "VREF": break;
                case "VURL": break;
                case "VSINI": break;
                case "VSINIUPPER": break;
                case "VSINILOWER": break;
                case "UVSINI": break;
                case "VSINIREF": break;
                case "VSINIURL": break;
                case "KEPID": break;
                case "KDE": break;

                case "": break;

                default:
                    System.Windows.Forms.MessageBox.Show ("Error: " + substring);
                    break;
                }
            }
        }

    }
