using System.IO;
using System.Collections;

namespace ExoplanetLibrary
    {
    public class WriteCSV
        {
        public WriteCSV ()
            {
            }

        static private string Version_ = Constant.Version2;
        static private string Version
            {
            get { return Version_; }
            set { Version_ = value; }
            }

        static public int Write (string csvFileName, ArrayList exoplanets, string version)
            {
            Version = version;

            if (string.Equals (Version, Constant.Version1) || string.Equals (Version, Constant.Version2) || string.Equals (Version, Constant.Version3))
                {
                TextWriter writer = null;

                using (writer = File.CreateText (csvFileName))
                    {
                    WriteFirstLine (writer);

                    foreach (Exoplanet exoplanet in exoplanets)
                        if (exoplanet.Name.Length > 0)
                            Write (writer, exoplanet);
                    }
                }

            return 0;
            }

        static private int WriteFirstLine (TextWriter textWriter)
            {
            if (string.Equals (Version, Constant.Version1))
                textWriter.WriteLine ("# name, mass, mass_error_min, mass_error_max, radius, radius_error_min, " +
                                "radius_error_max, orbital_period, orbital_period_err_min, orbital_period_err_max, " +
                                "semi_major_axis, semi_major_axis_error_min, semi_major_axis_error_max, eccentricity, " +
                                "eccentricity_error_min, eccentricity_error_max, angular_distance, inclination, inclination_error_min, " +
                                "inclination_error_max, tzero_tr, tzero_tr_error_min, tzero_tr_error_max, tzero_tr_sec, tzero_tr_sec_error_min, " +
                                "tzero_tr_sec_error_max, lambda_angle, lambda_angle_error_min, lambda_angle_error_max, tzero_vr, tzero_vr_error_min, " +
                                "tzero_vr_error_max, temp_calculated, temp_measured, hot_point_lon, log_g, publication_status, discovered, updated, " +
                                "omega, omega_error_min, omega_error_max, tperi, tperi_error_min, tperi_error_max, detection_type, molecules, " +
                                "star_name, ra, dec, mag_v, mag_i, mag_j, mag_h, mag_k, star_distance, star_metallicity, " +
                                "star_mass, star_radius, star_sp_type, star_age, star_teff");
            else if (string.Equals (Version, Constant.Version2))
                textWriter.WriteLine ("# name,mass,mass_error_min,mass_error_max,radius,radius_error_min," +
                                "radius_error_max,orbital_period,orbital_period_error_min,orbital_period_error_max," +
                                "semi_major_axis,semi_major_axis_error_min,semi_major_axis_error_max,eccentricity," +
                                "eccentricity_error_min,eccentricity_error_max,inclination,inclination_error_min," +
                                "inclination_error_max,angular_distance,discovered,updated,omega,omega_error_min,omega_error_max," +
                                "tperi,tperi_error_min,tperi_error_max,tconj,tconj_error_min,tconj_error_max,tzero_tr,tzero_tr_error_min," +
                                "tzero_tr_error_max,tzero_tr_sec,tzero_tr_sec_error_min,tzero_tr_sec_error_max,lambda_angle,lambda_angle_error_min," +
                                "lambda_angle_error_max,impact_parameter,impact_parameter_error_min,impact_parameter_error_max,tzero_vr," +
                                "tzero_vr_error_min,tzero_vr_error_max,k,k_error_min,k_error_max,temp_calculated,temp_measured,hot_point_lon,geometric_albedo," +
                                "geometric_albedo_error_min,geometric_albedo_error_max,log_g,publication_status,detection_type,mass_detection_type," +
                                "radius_detection_type,alternate_names,molecules,star_name,ra,dec,mag_v,mag_i,mag_j,mag_h,mag_k,star_distance,star_metallicity," +
                                "star_mass,star_radius,star_sp_type,star_age,star_teff,star_detected_disc,star_magnetic_field");
            else if (string.Equals (Version, Constant.Version3))
                textWriter.WriteLine ("# name,mass,mass_error_min,mass_error_max,mass_sini,mass_sini_error_min,mass_sini_error_max,radius,radius_error_min," +
                                "radius_error_max,orbital_period,orbital_period_error_min,orbital_period_error_max," +
                                "semi_major_axis,semi_major_axis_error_min,semi_major_axis_error_max,eccentricity," +
                                "eccentricity_error_min,eccentricity_error_max,inclination,inclination_error_min," +
                                "inclination_error_max,angular_distance,discovered,updated,omega,omega_error_min,omega_error_max," +
                                "tperi,tperi_error_min,tperi_error_max,tconj,tconj_error_min,tconj_error_max,tzero_tr,tzero_tr_error_min," +
                                "tzero_tr_error_max,tzero_tr_sec,tzero_tr_sec_error_min,tzero_tr_sec_error_max,lambda_angle,lambda_angle_error_min," +
                                "lambda_angle_error_max,impact_parameter,impact_parameter_error_min,impact_parameter_error_max,tzero_vr," +
                                "tzero_vr_error_min,tzero_vr_error_max,k,k_error_min,k_error_max,temp_calculated,temp_measured,hot_point_lon,geometric_albedo" +
                                ",geometric_albedo_error_min,geometric_albedo_error_max,log_g,publication_status,detection_type,mass_detection_type," +
                                "radius_detection_type,alternate_names,molecules,star_name,ra,dec,mag_v,mag_i,mag_j,mag_h,mag_k,star_distance," +
                                "star_distance_error_min,star_distance_error_max,star_metallicity,star_metallicity_error_min,star_metallicity_error_max," +
                                "star_mass,star_mass_error_min,star_mass_error_max,star_radius,star_radius_error_min,star_radius_error_max,star_sp_type," +
                                "star_age,star_age_error_min,star_age_error_max,star_teff,star_teff_error_min,star_teff_error_max,star_detected_disc," +
                                "star_magnetic_field,alternate_names");

            return 0;
            }

        static public int Write (TextWriter textWriter, Exoplanet exoplanet)
            {
            if (string.Equals (Version, Constant.Version1))
                return WriteVersion1 (textWriter, exoplanet);
            else if (string.Equals (Version, Constant.Version2))
                return WriteVersion2 (textWriter, exoplanet);
            else if (string.Equals (Version, Constant.Version3))
                return WriteVersion3 (textWriter, exoplanet);

            return 0;
            }

        static public int WriteVersion1 (TextWriter textWriter, Exoplanet exoplanet)
            {
            WriteLine (textWriter, exoplanet.Name);
            WriteLine (textWriter, exoplanet.Mass);
            WriteLine (textWriter, exoplanet.MassErrorMin);
            WriteLine (textWriter, exoplanet.MassErrorMax);
            WriteLine (textWriter, exoplanet.Radius);
            WriteLine (textWriter, exoplanet.RadiusErrorMin);
            WriteLine (textWriter, exoplanet.RadiusErrorMax);
            WriteLine (textWriter, exoplanet.OrbitalPeriod);
            WriteLine (textWriter, exoplanet.OrbitalPeriodErrorMin);
            WriteLine (textWriter, exoplanet.OrbitalPeriodErrorMax);
            WriteLine (textWriter, exoplanet.SemiMajorAxis);
            WriteLine (textWriter, exoplanet.SemiMajorAxisErrorMin);
            WriteLine (textWriter, exoplanet.SemiMajorAxisErrorMax);
            WriteLine (textWriter, exoplanet.Eccentricity);
            WriteLine (textWriter, exoplanet.EccentricityErrorMin);
            WriteLine (textWriter, exoplanet.EccentricityErrorMax);
            WriteLine (textWriter, exoplanet.AngularDistance);
            WriteLine (textWriter, exoplanet.Inclination);
            WriteLine (textWriter, exoplanet.InclinationErrorMin);
            WriteLine (textWriter, exoplanet.InclinationErrorMax);
            WriteLine (textWriter, exoplanet.TzeroTr);
            WriteLine (textWriter, exoplanet.TzeroTrErrorMin);
            WriteLine (textWriter, exoplanet.TzeroTrErrorMax);
            WriteLine (textWriter, exoplanet.TzeroTrSec);
            WriteLine (textWriter, exoplanet.TzeroTrSecErrorMin);
            WriteLine (textWriter, exoplanet.TzeroTrSecErrorMax);
            WriteLine (textWriter, exoplanet.LambdaAngle);
            WriteLine (textWriter, exoplanet.LambdaAngleErrorMin);
            WriteLine (textWriter, exoplanet.LambdaAngleErrorMax);
            WriteLine (textWriter, exoplanet.TzeroVr);
            WriteLine (textWriter, exoplanet.TzeroVrErrorMin);
            WriteLine (textWriter, exoplanet.TzeroVrErrorMax);
            WriteLine (textWriter, exoplanet.TemperatureCalculated);
            WriteLine (textWriter, exoplanet.TemperatureMeasured);
            WriteLine (textWriter, exoplanet.TemperatureHotPointLo);
            WriteLine (textWriter, exoplanet.LogG);
            WriteLine (textWriter, exoplanet.Status);
            WriteLine (textWriter, exoplanet.Discovered);
            WriteLine (textWriter, exoplanet.Updated);
            WriteLine (textWriter, exoplanet.Omega);
            WriteLine (textWriter, exoplanet.OmegaErrorMin);
            WriteLine (textWriter, exoplanet.OmegaErrorMax);
            WriteLine (textWriter, exoplanet.Tperi);
            WriteLine (textWriter, exoplanet.TperiErrorMin);
            WriteLine (textWriter, exoplanet.TperiErrorMax);
            WriteLine (textWriter, exoplanet.DetectionType);
            WriteLine (textWriter, exoplanet.Molecules);
            WriteLine (textWriter, exoplanet.Star.Name);
            WriteLine (textWriter, exoplanet.Star.RightAccession);
            WriteLine (textWriter, exoplanet.Star.Declination);
            WriteLine (textWriter, exoplanet.Star.Magnitude.V);
            WriteLine (textWriter, exoplanet.Star.Magnitude.I);
            WriteLine (textWriter, exoplanet.Star.Magnitude.J);
            WriteLine (textWriter, exoplanet.Star.Magnitude.H);
            WriteLine (textWriter, exoplanet.Star.Magnitude.K);
            WriteLine (textWriter, exoplanet.Star.Property.Distance);
            WriteLine (textWriter, exoplanet.Star.Property.Metallicity);
            WriteLine (textWriter, exoplanet.Star.Property.Mass);
            WriteLine (textWriter, exoplanet.Star.Property.Radius);
            WriteLine (textWriter, exoplanet.Star.Property.SPType);
            WriteLine (textWriter, exoplanet.Star.Property.Age);
            WriteLastLine (textWriter, exoplanet.Star.Property.Teff);

            return 0;
            }

        static public int WriteVersion2 (TextWriter textWriter, Exoplanet exoplanet)
            {
            WriteLine (textWriter, exoplanet.Name);
            WriteLine (textWriter, exoplanet.Mass);
            WriteLine (textWriter, exoplanet.MassErrorMin);
            WriteLine (textWriter, exoplanet.MassErrorMax);
            WriteLine (textWriter, exoplanet.Radius);
            WriteLine (textWriter, exoplanet.RadiusErrorMin);
            WriteLine (textWriter, exoplanet.RadiusErrorMax);
            WriteLine (textWriter, exoplanet.OrbitalPeriod);
            WriteLine (textWriter, exoplanet.OrbitalPeriodErrorMin);
            WriteLine (textWriter, exoplanet.OrbitalPeriodErrorMax);
            WriteLine (textWriter, exoplanet.SemiMajorAxis);
            WriteLine (textWriter, exoplanet.SemiMajorAxisErrorMin);
            WriteLine (textWriter, exoplanet.SemiMajorAxisErrorMax);
            WriteLine (textWriter, exoplanet.Eccentricity);
            WriteLine (textWriter, exoplanet.EccentricityErrorMin);
            WriteLine (textWriter, exoplanet.EccentricityErrorMax);
            WriteLine (textWriter, exoplanet.Inclination);
            WriteLine (textWriter, exoplanet.InclinationErrorMin);
            WriteLine (textWriter, exoplanet.InclinationErrorMax);
            WriteLine (textWriter, exoplanet.AngularDistance);
            WriteLine (textWriter, Helper.FormatDateXML2CSV (exoplanet.Discovered));
            WriteLine (textWriter, exoplanet.Updated);
            WriteLine (textWriter, exoplanet.Omega);
            WriteLine (textWriter, exoplanet.OmegaErrorMin);
            WriteLine (textWriter, exoplanet.OmegaErrorMax);
            WriteLine (textWriter, exoplanet.Tperi);
            WriteLine (textWriter, exoplanet.TperiErrorMin);
            WriteLine (textWriter, exoplanet.TperiErrorMax);
            WriteLine (textWriter, exoplanet.Tconj);
            WriteLine (textWriter, exoplanet.TconjErrorMin);
            WriteLine (textWriter, exoplanet.TconjErrorMax);
            WriteLine (textWriter, exoplanet.TzeroTr);
            WriteLine (textWriter, exoplanet.TzeroTrErrorMin);
            WriteLine (textWriter, exoplanet.TzeroTrErrorMax);
            WriteLine (textWriter, exoplanet.TzeroTrSec);
            WriteLine (textWriter, exoplanet.TzeroTrSecErrorMin);
            WriteLine (textWriter, exoplanet.TzeroTrSecErrorMax);
            WriteLine (textWriter, exoplanet.LambdaAngle);
            WriteLine (textWriter, exoplanet.LambdaAngleErrorMin);
            WriteLine (textWriter, exoplanet.LambdaAngleErrorMax);
            WriteLine (textWriter, exoplanet.ImpactParameter);
            WriteLine (textWriter, exoplanet.ImpactParameterErrorMin);
            WriteLine (textWriter, exoplanet.ImpactParameterErrorMax);
            WriteLine (textWriter, exoplanet.TzeroVr);
            WriteLine (textWriter, exoplanet.TzeroVrErrorMin);
            WriteLine (textWriter, exoplanet.TzeroVrErrorMax);
            WriteLine (textWriter, exoplanet.VelocitySemiamplitude);
            WriteLine (textWriter, exoplanet.VelocitySemiamplitudeErrorMin);
            WriteLine (textWriter, exoplanet.VelocitySemiamplitudeErrorMax);
            WriteLine (textWriter, exoplanet.TemperatureCalculated);
            WriteLine (textWriter, exoplanet.TemperatureMeasured);
            WriteLine (textWriter, exoplanet.TemperatureHotPointLo);
            WriteLine (textWriter, exoplanet.GeometricAlbedo);
            WriteLine (textWriter, exoplanet.GeometricAlbedoErrorMin);
            WriteLine (textWriter, exoplanet.GeometricAlbedoErrorMax);
            WriteLine (textWriter, exoplanet.LogG);
            WriteLine (textWriter, exoplanet.Status);
            WriteLine (textWriter, exoplanet.DetectionType);
            WriteLine (textWriter, exoplanet.MassDetectionType);
            WriteLine (textWriter, exoplanet.RadiusDetectionType);
            WriteLine (textWriter, exoplanet.AlternateNames);
            WriteLine (textWriter, exoplanet.Molecules);
            WriteLine (textWriter, exoplanet.Star.Name);
            WriteLine (textWriter, exoplanet.Star.RightAccession);
            WriteLine (textWriter, exoplanet.Star.Declination);
            WriteLine (textWriter, exoplanet.Star.Magnitude.V);
            WriteLine (textWriter, exoplanet.Star.Magnitude.I);
            WriteLine (textWriter, exoplanet.Star.Magnitude.J);
            WriteLine (textWriter, exoplanet.Star.Magnitude.H);
            WriteLine (textWriter, exoplanet.Star.Magnitude.K);
            WriteLine (textWriter, exoplanet.Star.Property.Distance);
            WriteLine (textWriter, exoplanet.Star.Property.Metallicity);
            WriteLine (textWriter, exoplanet.Star.Property.Mass);
            WriteLine (textWriter, exoplanet.Star.Property.Radius);
            WriteLine (textWriter, exoplanet.Star.Property.SPType);
            WriteLine (textWriter, exoplanet.Star.Property.Age);
            WriteLine (textWriter, exoplanet.Star.Property.Teff);
            WriteLine (textWriter, exoplanet.Star.Property.DetectedDisc);
            WriteLastLine (textWriter, exoplanet.Star.Property.MagneticField);

            return 0;
            }

        static public int WriteVersion3 (TextWriter textWriter, Exoplanet exoplanet)
            {
            WriteLine (textWriter, exoplanet.Name);
            WriteLine (textWriter, exoplanet.Mass);
            WriteLine (textWriter, exoplanet.MassErrorMin);
            WriteLine (textWriter, exoplanet.MassErrorMax);
            WriteLine (textWriter, exoplanet.MassSini);
            WriteLine (textWriter, exoplanet.MassSiniErrorMin);
            WriteLine (textWriter, exoplanet.MassSiniErrorMax);
            WriteLine (textWriter, exoplanet.Radius);
            WriteLine (textWriter, exoplanet.RadiusErrorMin);
            WriteLine (textWriter, exoplanet.RadiusErrorMax);
            WriteLine (textWriter, exoplanet.OrbitalPeriod);
            WriteLine (textWriter, exoplanet.OrbitalPeriodErrorMin);
            WriteLine (textWriter, exoplanet.OrbitalPeriodErrorMax);
            WriteLine (textWriter, exoplanet.SemiMajorAxis);
            WriteLine (textWriter, exoplanet.SemiMajorAxisErrorMin);
            WriteLine (textWriter, exoplanet.SemiMajorAxisErrorMax);
            WriteLine (textWriter, exoplanet.Eccentricity);
            WriteLine (textWriter, exoplanet.EccentricityErrorMin);
            WriteLine (textWriter, exoplanet.EccentricityErrorMax);
            WriteLine (textWriter, exoplanet.Inclination);
            WriteLine (textWriter, exoplanet.InclinationErrorMin);
            WriteLine (textWriter, exoplanet.InclinationErrorMax);
            WriteLine (textWriter, exoplanet.AngularDistance);
            WriteLine (textWriter, Helper.FormatDateXML2CSV (exoplanet.Discovered));
            WriteLine (textWriter, exoplanet.Updated);
            WriteLine (textWriter, exoplanet.Omega);
            WriteLine (textWriter, exoplanet.OmegaErrorMin);
            WriteLine (textWriter, exoplanet.OmegaErrorMax);
            WriteLine (textWriter, exoplanet.Tperi);
            WriteLine (textWriter, exoplanet.TperiErrorMin);
            WriteLine (textWriter, exoplanet.TperiErrorMax);
            WriteLine (textWriter, exoplanet.Tconj);
            WriteLine (textWriter, exoplanet.TconjErrorMin);
            WriteLine (textWriter, exoplanet.TconjErrorMax);
            WriteLine (textWriter, exoplanet.TzeroTr);
            WriteLine (textWriter, exoplanet.TzeroTrErrorMin);
            WriteLine (textWriter, exoplanet.TzeroTrErrorMax);
            WriteLine (textWriter, exoplanet.TzeroTrSec);
            WriteLine (textWriter, exoplanet.TzeroTrSecErrorMin);
            WriteLine (textWriter, exoplanet.TzeroTrSecErrorMax);
            WriteLine (textWriter, exoplanet.LambdaAngle);
            WriteLine (textWriter, exoplanet.LambdaAngleErrorMin);
            WriteLine (textWriter, exoplanet.LambdaAngleErrorMax);
            WriteLine (textWriter, exoplanet.ImpactParameter);
            WriteLine (textWriter, exoplanet.ImpactParameterErrorMin);
            WriteLine (textWriter, exoplanet.ImpactParameterErrorMax);
            WriteLine (textWriter, exoplanet.TzeroVr);
            WriteLine (textWriter, exoplanet.TzeroVrErrorMin);
            WriteLine (textWriter, exoplanet.TzeroVrErrorMax);
            WriteLine (textWriter, exoplanet.VelocitySemiamplitude);
            WriteLine (textWriter, exoplanet.VelocitySemiamplitudeErrorMin);
            WriteLine (textWriter, exoplanet.VelocitySemiamplitudeErrorMax);
            WriteLine (textWriter, exoplanet.TemperatureCalculated);
            WriteLine (textWriter, exoplanet.TemperatureMeasured);
            WriteLine (textWriter, exoplanet.TemperatureHotPointLo);
            WriteLine (textWriter, exoplanet.GeometricAlbedo);
            WriteLine (textWriter, exoplanet.GeometricAlbedoErrorMin);
            WriteLine (textWriter, exoplanet.GeometricAlbedoErrorMax);
            WriteLine (textWriter, exoplanet.LogG);
            WriteLine (textWriter, exoplanet.Status);
            WriteLine (textWriter, exoplanet.DetectionType);
            WriteLine (textWriter, exoplanet.MassDetectionType);
            WriteLine (textWriter, exoplanet.RadiusDetectionType);
            WriteLine (textWriter, exoplanet.AlternateNames);
            WriteLine (textWriter, exoplanet.Molecules);
            WriteLine (textWriter, exoplanet.Star.Name);
            WriteLine (textWriter, exoplanet.Star.RightAccession);
            WriteLine (textWriter, exoplanet.Star.Declination);
            WriteLine (textWriter, exoplanet.Star.Magnitude.V);
            WriteLine (textWriter, exoplanet.Star.Magnitude.I);
            WriteLine (textWriter, exoplanet.Star.Magnitude.J);
            WriteLine (textWriter, exoplanet.Star.Magnitude.H);
            WriteLine (textWriter, exoplanet.Star.Magnitude.K);
            WriteLine (textWriter, exoplanet.Star.Property.Distance);
            WriteLine (textWriter, exoplanet.Star.Property.DistanceErrorMin);
            WriteLine (textWriter, exoplanet.Star.Property.DistanceErrorMax);
            WriteLine (textWriter, exoplanet.Star.Property.Metallicity);
            WriteLine (textWriter, exoplanet.Star.Property.MetallicityErrorMin);
            WriteLine (textWriter, exoplanet.Star.Property.MetallicityErrorMax);
            WriteLine (textWriter, exoplanet.Star.Property.Mass);
            WriteLine (textWriter, exoplanet.Star.Property.MassErrorMin);
            WriteLine (textWriter, exoplanet.Star.Property.MassErrorMax);
            WriteLine (textWriter, exoplanet.Star.Property.Radius);
            WriteLine (textWriter, exoplanet.Star.Property.RadiusErrorMin);
            WriteLine (textWriter, exoplanet.Star.Property.RadiusErrorMax);
            WriteLine (textWriter, exoplanet.Star.Property.SPType);
            WriteLine (textWriter, exoplanet.Star.Property.Age);
            WriteLine (textWriter, exoplanet.Star.Property.AgeErrorMin);
            WriteLine (textWriter, exoplanet.Star.Property.AgeErrorMax);
            WriteLine (textWriter, exoplanet.Star.Property.Teff);
            WriteLine (textWriter, exoplanet.Star.Property.TeffErrorMin);
            WriteLine (textWriter, exoplanet.Star.Property.TeffErrorMax);
            WriteLine (textWriter, exoplanet.Star.Property.DetectedDisc);
            WriteLine (textWriter, exoplanet.Star.Property.MagneticField);
            WriteLastLine (textWriter, exoplanet.Star.AlternateNames);

            return 0;
            }
        static private int WriteLine (TextWriter textWriter, string stringer)
            {
            textWriter.Write (stringer + ",");

            return 0;
            }

        static private int WriteLastLine (TextWriter textWriter, string stringer)
            {
            textWriter.Write (stringer + "\r");

            return 0;
            }
        }
    }
