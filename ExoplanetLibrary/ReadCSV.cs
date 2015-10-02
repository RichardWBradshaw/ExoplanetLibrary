using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace ExoplanetLibrary
    {
    class ReadCSV
        {
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

        static public int Read(string csvFileName)
            {
            if (System.IO.File.Exists (csvFileName))
                {
                XmlWriter writer = null;
                XmlWriterSettings settings = null;

                settings = new XmlWriterSettings ();

                settings.IndentChars = "\t";
                settings.NewLineHandling = System.Xml.NewLineHandling.Entitize;
                settings.Indent = true;
                settings.NewLineChars = "\n";

                string xmlFileName = "";

                if (csvFileName.EndsWith (".txt"))
                    xmlFileName = csvFileName.Replace (".txt", ".xml");
                else
                    xmlFileName = csvFileName.Replace (".csv", ".xml");

                IsValidVersion (csvFileName);

                if (string.Equals (Version, "1.0") || string.Equals (Version, "2.0"))
                    {
                    writer = XmlWriter.Create (xmlFileName, settings);

                    writer.WriteStartElement ("Exoplanets");
                    writer.WriteAttributeString ("version", Version);

                    TextReader reader = null;

                    using (reader = File.OpenText (csvFileName))
                        {
                        string line = null;

                        for (bool initialLine = true; ;)
                            {
                            line = reader.ReadLine ();

                            if (line != null)
                                if (!initialLine)
                                    WriteExoplanet (writer, line);
                                else
                                    initialLine = false;
                            else
                                break;
                            }
                        }

                    writer.WriteEndElement ();
                    writer.Close ();
                    }
                }

            return 0;
            }

        static private string IsValidVersion(string csvFileName)
            {
            TextReader reader = File.OpenText (csvFileName);

            Version = "";

            if (reader != null)
                {
                string firstLine = reader.ReadLine ();

                if (firstLine.Equals ("# name, mass, mass_error_min, mass_error_max, radius, radius_error_min, radius_error_max, " +
                        "orbital_period, orbital_period_err_min, orbital_period_err_max, " +
                        "semi_major_axis, semi_major_axis_error_min, semi_major_axis_error_max, eccentricity, " +
                        "eccentricity_error_min, eccentricity_error_max, angular_distance, inclination, inclination_error_min, " +
                        "inclination_error_max, tzero_tr, tzero_tr_error_min, tzero_tr_error_max, tzero_tr_sec, tzero_tr_sec_error_min, " +
                        "tzero_tr_sec_error_max, lambda_angle, lambda_angle_error_min, lambda_angle_error_max, tzero_vr, tzero_vr_error_min, " +
                        "tzero_vr_error_max, temp_calculated, temp_measured, hot_point_lon, log_g, publication_status, discovered, updated, " +
                        "omega, omega_error_min, omega_error_max, tperi, tperi_error_min, tperi_error_max, detection_type, molecules, " +
                        "star_name, ra, dec, mag_v, mag_i, mag_j, mag_h, mag_k, star_distance, star_metallicity, " +
                        "star_mass, star_radius, star_sp_type, star_age, star_teff"))
                    Version = "1.0";
                else if (firstLine.Equals ("# name,mass,mass_error_min,mass_error_max,radius,radius_error_min,radius_error_max," +
                    "orbital_period,orbital_period_error_min,orbital_period_error_max,semi_major_axis,semi_major_axis_error_min,semi_major_axis_error_max," +
                    "eccentricity,eccentricity_error_min,eccentricity_error_max,inclination,inclination_error_min,inclination_error_max," +
                    "angular_distance,discovered,updated,omega,omega_error_min,omega_error_max,tperi,tperi_error_min,tperi_error_max," +
                    "tconj,tconj_error_min,tconj_error_max,tzero_tr,tzero_tr_error_min,tzero_tr_error_max,tzero_tr_sec,tzero_tr_sec_error_min,tzero_tr_sec_error_max," +
                    "lambda_angle,lambda_angle_error_min,lambda_angle_error_max,impact_parameter,impact_parameter_error_min,impact_parameter_error_max," +
                    "tzero_vr,tzero_vr_error_min,tzero_vr_error_max,k,k_error_min,k_error_max,temp_calculated,temp_measured,hot_point_lon," +
                    "geometric_albedo,geometric_albedo_error_min,geometric_albedo_error_max,log_g,publication_status," +
                    "detection_type,mass_detection_type,radius_detection_type,alternate_names,molecules," +
                    "star_name,ra,dec,mag_v,mag_i,mag_j,mag_h,mag_k,star_distance,star_metallicity,star_mass,star_radius,star_sp_type,star_age,star_teff," +
                    "star_detected_disc,star_magnetic_field"))
                    Version = "2.0";
                else
                    Version = "";
                }

            reader.Close ();

            return Version;
            }

        static private int WriteExoplanet(XmlWriter writer, string line)
            {
            char [] delimiterChars = { ',', '\t' };
            string [] strings = line.Split (delimiterChars);
            int numberOfStrings = strings.Length;

            if (string.Equals (Version, "1.0"))
                {
                if (numberOfStrings == 62)
                    {
                    CExoplanet exoplanet = new CExoplanet ();

                    AssignFromVersion1 (strings, exoplanet);

                    WriteXML.WriteExoplanet (writer, exoplanet, Version);
                    }
                }
            else if (string.Equals (Version, "2.0"))
                {
                if (numberOfStrings == 79)
                    {
                    CExoplanet exoplanet = new CExoplanet ();

                    AssignFromVersion2 (strings, exoplanet);

                    WriteXML.WriteExoplanet (writer, exoplanet, Version);
                    }
                }

            return 0;
            }

        static private void AssignFromVersion1(String [] strings, CExoplanet exoplanet)
            {
            exoplanet.Name = strings [0].ToString ();

            exoplanet.Mass = ReplaceNonNumerics (strings [1].ToString ());
            exoplanet.MassErrorMin = ReplaceNonNumerics (strings [2].ToString ());
            exoplanet.MassErrorMax = ReplaceNonNumerics (strings [3].ToString ());

            exoplanet.Radius = ReplaceNonNumerics (strings [4].ToString ());
            exoplanet.RadiusErrorMin = ReplaceNonNumerics (strings [5].ToString ());
            exoplanet.RadiusErrorMax = ReplaceNonNumerics (strings [6].ToString ());

            exoplanet.OrbitalPeriod = ReplaceNonNumerics (strings [7].ToString ());
            exoplanet.OrbitalPeriodErrorMin = ReplaceNonNumerics (strings [8].ToString ());
            exoplanet.OrbitalPeriodErrorMax = ReplaceNonNumerics (strings [9].ToString ());

            exoplanet.SemiMajorAxis = ReplaceNonNumerics (strings [10].ToString ());
            exoplanet.SemiMajorAxisErrorMin = ReplaceNonNumerics (strings [11].ToString ());
            exoplanet.SemiMajorAxisErrorMax = ReplaceNonNumerics (strings [12].ToString ());

            exoplanet.Eccentricity = ReplaceNonNumerics (strings [13].ToString ());
            exoplanet.EccentricityErrorMin = ReplaceNonNumerics (strings [14].ToString ());
            exoplanet.EccentricityErrorMax = ReplaceNonNumerics (strings [15].ToString ());

            exoplanet.AngularDistance = ReplaceNonNumerics (strings [16].ToString ());

            exoplanet.Inclination = ReplaceNonNumerics (strings [17].ToString ());
            exoplanet.InclinationErrorMin = ReplaceNonNumerics (strings [18].ToString ());
            exoplanet.InclinationErrorMax = ReplaceNonNumerics (strings [19].ToString ());

            exoplanet.TzeroTr = ReplaceNonNumerics (strings [20].ToString ());
            exoplanet.TzeroTrErrorMin = ReplaceNonNumerics (strings [21].ToString ());
            exoplanet.TzeroTrErrorMax = ReplaceNonNumerics (strings [22].ToString ());

            exoplanet.TzeroTrSec = ReplaceNonNumerics (strings [23].ToString ());
            exoplanet.TzeroTrSecErrorMin = ReplaceNonNumerics (strings [24].ToString ());
            exoplanet.TzeroTrSecErrorMax = ReplaceNonNumerics (strings [25].ToString ());

            exoplanet.LambdaAngle = ReplaceNonNumerics (strings [26].ToString ());
            exoplanet.LambdaAngleErrorMin = ReplaceNonNumerics (strings [27].ToString ());
            exoplanet.LambdaAngleErrorMax = ReplaceNonNumerics (strings [28].ToString ());

            exoplanet.TzeroVr = ReplaceNonNumerics (strings [29].ToString ());
            exoplanet.TzeroVrErrorMin = ReplaceNonNumerics (strings [30].ToString ());
            exoplanet.TzeroVrErrorMax = ReplaceNonNumerics (strings [31].ToString ());

            exoplanet.TemperatureCalculated = ReplaceNonNumerics (strings [32].ToString ());
            exoplanet.TemperatureMeasured = ReplaceNonNumerics (strings [33].ToString ());
            exoplanet.TemperatureHotPointLo = ReplaceNonNumerics (strings [34].ToString ());

            exoplanet.LogG = ReplaceNonNumerics (strings [35].ToString ());

            exoplanet.Status = strings [36].ToString ();

            exoplanet.Discovered = strings [37].ToString ();

            exoplanet.Updated = strings [38].ToString ();

            exoplanet.Omega = ReplaceNonNumerics (strings [39].ToString ());
            exoplanet.OmegaErrorMin = ReplaceNonNumerics (strings [40].ToString ());
            exoplanet.OmegaErrorMax = ReplaceNonNumerics (strings [41].ToString ());

            exoplanet.Tperi = ReplaceNonNumerics (strings [42].ToString ());
            exoplanet.TperiErrorMin = ReplaceNonNumerics (strings [43].ToString ());
            exoplanet.TperiErrorMax = ReplaceNonNumerics (strings [44].ToString ());

            exoplanet.DetectionType = strings [45].ToString ();

            exoplanet.Molecules = strings [46].ToString ();

            exoplanet.Star.Name = strings [47].ToString ();
            exoplanet.Star.RightAccession = ReplaceNonNumerics (strings [48].ToString ());
            exoplanet.Star.Declination = ReplaceNonNumerics (strings [49].ToString ());

            exoplanet.Star.Magnitudes.V = ReplaceNonNumerics (strings [50].ToString ());
            exoplanet.Star.Magnitudes.I = ReplaceNonNumerics (strings [51].ToString ());
            exoplanet.Star.Magnitudes.J = ReplaceNonNumerics (strings [52].ToString ());
            exoplanet.Star.Magnitudes.H = ReplaceNonNumerics (strings [53].ToString ());
            exoplanet.Star.Magnitudes.K = ReplaceNonNumerics (strings [54].ToString ());

            exoplanet.Star.Properties.Distance = ReplaceNonNumerics (strings [55].ToString ());
            exoplanet.Star.Properties.Metallicity = ReplaceNonNumerics (strings [56].ToString ());
            exoplanet.Star.Properties.Mass = ReplaceNonNumerics (strings [57].ToString ());
            exoplanet.Star.Properties.Radius = ReplaceNonNumerics (strings [58].ToString ());
            exoplanet.Star.Properties.SPType = ReplaceNonNumerics (strings [59].ToString ());
            exoplanet.Star.Properties.Age = ReplaceNonNumerics (strings [60].ToString ());
            exoplanet.Star.Properties.Teff = ReplaceNonNumerics (strings [61].ToString ());
            }

        static private void AssignFromVersion2(String [] strings, CExoplanet exoplanet)
            {
            exoplanet.Name = strings [0].ToString ();

            exoplanet.Mass = ReplaceNonNumerics (strings [1].ToString ());
            exoplanet.MassErrorMin = ReplaceNonNumerics (strings [2].ToString ());
            exoplanet.MassErrorMax = ReplaceNonNumerics (strings [3].ToString ());

            exoplanet.Radius = ReplaceNonNumerics (strings [4].ToString ());
            exoplanet.RadiusErrorMin = ReplaceNonNumerics (strings [5].ToString ());
            exoplanet.RadiusErrorMax = ReplaceNonNumerics (strings [6].ToString ());

            exoplanet.OrbitalPeriod = ReplaceNonNumerics (strings [7].ToString ());
            exoplanet.OrbitalPeriodErrorMin = ReplaceNonNumerics (strings [8].ToString ());
            exoplanet.OrbitalPeriodErrorMax = ReplaceNonNumerics (strings [9].ToString ());

            exoplanet.SemiMajorAxis = ReplaceNonNumerics (strings [10].ToString ());
            exoplanet.SemiMajorAxisErrorMin = ReplaceNonNumerics (strings [11].ToString ());
            exoplanet.SemiMajorAxisErrorMax = ReplaceNonNumerics (strings [12].ToString ());

            exoplanet.Eccentricity = ReplaceNonNumerics (strings [13].ToString ());
            exoplanet.EccentricityErrorMin = ReplaceNonNumerics (strings [14].ToString ());
            exoplanet.EccentricityErrorMax = ReplaceNonNumerics (strings [15].ToString ());

            exoplanet.Inclination = ReplaceNonNumerics (strings [16].ToString ());
            exoplanet.InclinationErrorMin = ReplaceNonNumerics (strings [17].ToString ());
            exoplanet.InclinationErrorMax = ReplaceNonNumerics (strings [18].ToString ());

            exoplanet.AngularDistance = ReplaceNonNumerics (strings [19].ToString ());

            exoplanet.Discovered = strings [20].ToString ();

            exoplanet.Updated = strings [21].ToString ();

            exoplanet.Omega = ReplaceNonNumerics (strings [22].ToString ());
            exoplanet.OmegaErrorMin = ReplaceNonNumerics (strings [23].ToString ());
            exoplanet.OmegaErrorMax = ReplaceNonNumerics (strings [24].ToString ());

            exoplanet.Tperi = ReplaceNonNumerics (strings [25].ToString ());
            exoplanet.TperiErrorMin = ReplaceNonNumerics (strings [26].ToString ());
            exoplanet.TperiErrorMax = ReplaceNonNumerics (strings [27].ToString ());

            exoplanet.Tconj = ReplaceNonNumerics (strings [28].ToString ());
            exoplanet.TconjErrorMin = ReplaceNonNumerics (strings [29].ToString ());
            exoplanet.TconjErrorMax = ReplaceNonNumerics (strings [30].ToString ());

            exoplanet.TzeroTr = ReplaceNonNumerics (strings [31].ToString ());
            exoplanet.TzeroTrErrorMin = ReplaceNonNumerics (strings [32].ToString ());
            exoplanet.TzeroTrErrorMax = ReplaceNonNumerics (strings [33].ToString ());

            exoplanet.TzeroTrSec = ReplaceNonNumerics (strings [34].ToString ());
            exoplanet.TzeroTrSecErrorMin = ReplaceNonNumerics (strings [35].ToString ());
            exoplanet.TzeroTrSecErrorMax = ReplaceNonNumerics (strings [36].ToString ());

            exoplanet.LambdaAngle = ReplaceNonNumerics (strings [37].ToString ());
            exoplanet.LambdaAngleErrorMin = ReplaceNonNumerics (strings [38].ToString ());
            exoplanet.LambdaAngleErrorMax = ReplaceNonNumerics (strings [39].ToString ());

            exoplanet.ImpactParameter = ReplaceNonNumerics (strings [40].ToString ());
            exoplanet.ImpactParameterErrorMin = ReplaceNonNumerics (strings [41].ToString ());
            exoplanet.ImpactParameterErrorMax = ReplaceNonNumerics (strings [42].ToString ());

            exoplanet.TzeroVr = ReplaceNonNumerics (strings [43].ToString ());

            exoplanet.TzeroVrErrorMin = ReplaceNonNumerics (strings [44].ToString ());
            exoplanet.TzeroVrErrorMax = ReplaceNonNumerics (strings [45].ToString ());

            exoplanet.K = ReplaceNonNumerics (strings [46].ToString ());
            exoplanet.KErrorMin = ReplaceNonNumerics (strings [47].ToString ());
            exoplanet.KErrorMax = ReplaceNonNumerics (strings [48].ToString ());

            exoplanet.TemperatureCalculated = ReplaceNonNumerics (strings [49].ToString ());
            exoplanet.TemperatureMeasured = ReplaceNonNumerics (strings [50].ToString ());
            exoplanet.TemperatureHotPointLo = ReplaceNonNumerics (strings [51].ToString ());

            exoplanet.GeometricAlbedo = ReplaceNonNumerics (strings [52].ToString ());
            exoplanet.GeometricAlbedoErrorMin = ReplaceNonNumerics (strings [53].ToString ());
            exoplanet.GeometricAlbedoErrorMax = ReplaceNonNumerics (strings [54].ToString ());

            exoplanet.LogG = ReplaceNonNumerics (strings [55].ToString ());
            exoplanet.Status = strings [56].ToString ();
            exoplanet.DetectionType = strings [57].ToString ();

            exoplanet.MassDetectionType = strings [58].ToString ();

            exoplanet.RadiusDetectionType = strings [59].ToString ();

            exoplanet.AlternateNames = strings [60].ToString ();

            exoplanet.Molecules = strings [61].ToString ();

            exoplanet.Star.Name = strings [62].ToString ();
            exoplanet.Star.RightAccession = ReplaceNonNumerics (strings [63].ToString ());
            exoplanet.Star.Declination = ReplaceNonNumerics (strings [64].ToString ());

            exoplanet.Star.Magnitudes.V = ReplaceNonNumerics (strings [65].ToString ());
            exoplanet.Star.Magnitudes.I = ReplaceNonNumerics (strings [66].ToString ());
            exoplanet.Star.Magnitudes.J = ReplaceNonNumerics (strings [67].ToString ());
            exoplanet.Star.Magnitudes.H = ReplaceNonNumerics (strings [68].ToString ());
            exoplanet.Star.Magnitudes.K = ReplaceNonNumerics (strings [69].ToString ());

            exoplanet.Star.Properties.Distance = ReplaceNonNumerics (strings [70].ToString ());
            exoplanet.Star.Properties.Metallicity = ReplaceNonNumerics (strings [71].ToString ());
            exoplanet.Star.Properties.Mass = ReplaceNonNumerics (strings [72].ToString ());
            exoplanet.Star.Properties.Radius = ReplaceNonNumerics (strings [73].ToString ());
            exoplanet.Star.Properties.SPType = ReplaceNonNumerics (strings [74].ToString ());
            exoplanet.Star.Properties.Age = ReplaceNonNumerics (strings [75].ToString ());
            exoplanet.Star.Properties.Teff = ReplaceNonNumerics (strings [76].ToString ());
            exoplanet.Star.Properties.DetectedDisc = ReplaceNonNumerics (strings [77].ToString ());
            exoplanet.Star.Properties.MagneticField = ReplaceNonNumerics (strings [78].ToString ());
            }

        static private string ReplaceNonNumerics(string originalString)
            {
            if (originalString == "inf")
                return "";
            else if (originalString == "nan")
                return "";
            else
                return originalString;
            }
        }
    }

