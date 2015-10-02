using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Collections;

namespace ExoplanetLibrary
    {
    class WriteCSV
        {
        static public int Write(string csvFileName, ArrayList exoplanets)
            {
            TextWriter writer = null;

            using (writer = File.CreateText (csvFileName))
                {
                WriteFirstLine (writer);

                foreach (CExoplanet exoplanet in exoplanets)
                    if (exoplanet.Name.Length > 0)
                        Write (writer, exoplanet);
                }

            return 0;
            }

        static private int WriteFirstLine(TextWriter textWriter)
            {
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

            return 0;
            }

        static public int Write(TextWriter textWriter, CExoplanet exoplanet)
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
            WriteLine (textWriter, exoplanet.Star.Magnitudes.V);
            WriteLine (textWriter, exoplanet.Star.Magnitudes.I);
            WriteLine (textWriter, exoplanet.Star.Magnitudes.J);
            WriteLine (textWriter, exoplanet.Star.Magnitudes.H);
            WriteLine (textWriter, exoplanet.Star.Magnitudes.K);
            WriteLine (textWriter, exoplanet.Star.Properties.Distance);
            WriteLine (textWriter, exoplanet.Star.Properties.Metallicity);
            WriteLine (textWriter, exoplanet.Star.Properties.Mass);
            WriteLine (textWriter, exoplanet.Star.Properties.Radius);
            WriteLine (textWriter, exoplanet.Star.Properties.SPType);
            WriteLine (textWriter, exoplanet.Star.Properties.Age);
            WriteLastLine (textWriter, exoplanet.Star.Properties.Teff);

            return 0;
            }

        static private int WriteLine(TextWriter textWriter, string stringer)
            {
            textWriter.Write (stringer + ",");

            return 0;
            }

        static private int WriteLastLine(TextWriter textWriter, string stringer)
            {
            textWriter.Write (stringer + "\r");

            return 0;
            }
        }
    }
