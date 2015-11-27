using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ExoplanetLibrary
    {
    public class Filters
        {
        //
        // “Oh Be A Fine Girl, Kiss Me.”
        //

        private CheckState TypeOEnabled_ = CheckState.Checked;
        public CheckState TypeOEnabled
            {
            get { return TypeOEnabled_; }
            set { TypeOEnabled_ = value; }
            }

        private CheckState TypeBEnabled_ = CheckState.Checked;
        public CheckState TypeBEnabled
            {
            get { return TypeBEnabled_; }
            set { TypeBEnabled_ = value; }
            }

        private CheckState TypeAEnabled_ = CheckState.Checked;
        public CheckState TypeAEnabled
            {
            get { return TypeAEnabled_; }
            set { TypeAEnabled_ = value; }
            }

        private CheckState TypeFEnabled_ = CheckState.Checked;
        public CheckState TypeFEnabled
            {
            get { return TypeFEnabled_; }
            set { TypeFEnabled_ = value; }
            }

        private CheckState TypeGEnabled_ = CheckState.Checked;
        public CheckState TypeGEnabled
            {
            get { return TypeGEnabled_; }
            set { TypeGEnabled_ = value; }
            }

        private CheckState TypeKEnabled_ = CheckState.Checked;
        public CheckState TypeKEnabled
            {
            get { return TypeKEnabled_; }
            set { TypeKEnabled_ = value; }
            }

        private CheckState TypeMEnabled_ = CheckState.Checked;
        public CheckState TypeMEnabled
            {
            get { return TypeMEnabled_; }
            set { TypeMEnabled_ = value; }
            }

        private CheckState UnknownStarEnabled_ = CheckState.Checked;
        public CheckState UnknownStarEnabled
            {
            get { return UnknownStarEnabled_; }
            set { UnknownStarEnabled_ = value; }
            }

        ///

        private CheckState PrimaryTransitEnabled_ = CheckState.Checked;
        public CheckState PrimaryTransitEnabled
            {
            get { return PrimaryTransitEnabled_; }
            set { PrimaryTransitEnabled_ = value; }
            }

        private CheckState RadialVelocityEnabled_ = CheckState.Checked;
        public CheckState RadialVelocityEnabled
            {
            get { return RadialVelocityEnabled_; }
            set { RadialVelocityEnabled_ = value; }
            }

        private CheckState MicrolensingEnabled_ = CheckState.Checked;
        public CheckState MicrolensingEnabled
            {
            get { return MicrolensingEnabled_; }
            set { MicrolensingEnabled_ = value; }
            }

        private CheckState ImagingEnabled_ = CheckState.Checked;
        public CheckState ImagingEnabled
            {
            get { return ImagingEnabled_; }
            set { ImagingEnabled_ = value; }
            }

        private CheckState PulsarEnabled_ = CheckState.Checked;
        public CheckState PulsarEnabled
            {
            get { return PulsarEnabled_; }
            set { PulsarEnabled_ = value; }
            }

        private CheckState AstrometryEnabled_ = CheckState.Checked;
        public CheckState AstrometryEnabled
            {
            get { return AstrometryEnabled_; }
            set { AstrometryEnabled_ = value; }
            }

        private CheckState TTVEnabled_ = CheckState.Checked;
        public CheckState TTVEnabled
            {
            get { return TTVEnabled_; }
            set { TTVEnabled_ = value; }
            }

        public CheckState UnknownDetectionEnabled_ = CheckState.Checked;
        public CheckState UnknownDetectionEnabled
            {
            get { return UnknownDetectionEnabled_; }
            set { UnknownDetectionEnabled_ = value; }
            }
        }

    public class Settings
        {
        static public int WriteFilter (Filters filter)
            {
            RegistryKey key = RegistryKey.OpenRemoteBaseKey (RegistryHive.CurrentUser, "");
            RegistryKey subkey = ( key != null ) ? key.CreateSubKey ("Software\\ExoplanetLibrary") : null;

            if (subkey != null)
                {
                subkey.SetValue ("StarTypeOEnabled", filter.TypeOEnabled == CheckState.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("StarTypeBEnabled", filter.TypeBEnabled == CheckState.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("StarTypeAEnabled", filter.TypeAEnabled == CheckState.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("StarTypeFEnabled", filter.TypeFEnabled == CheckState.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("StarTypeGEnabled", filter.TypeGEnabled == CheckState.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("StarTypeKEnabled", filter.TypeKEnabled == CheckState.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("StarTypeMEnabled", filter.TypeMEnabled == CheckState.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("UnknownStarEnabled", filter.UnknownStarEnabled == CheckState.Checked ? "True" : "False", RegistryValueKind.String);

                subkey.SetValue ("PrimaryTransitEnabled", filter.PrimaryTransitEnabled == CheckState.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("RadialVelocityEnabled", filter.RadialVelocityEnabled == CheckState.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("MicrolensingEnabled", filter.MicrolensingEnabled == CheckState.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("ImagingEnabled", filter.ImagingEnabled == CheckState.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("PulsarEnabled", filter.PulsarEnabled == CheckState.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("AstrometryEnabled", filter.AstrometryEnabled == CheckState.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("TTVEnabled", filter.TTVEnabled == CheckState.Checked ? "True" : "False", RegistryValueKind.String);
                subkey.SetValue ("UnknownDetectionEnabled", filter.UnknownDetectionEnabled == CheckState.Checked ? "True" : "False", RegistryValueKind.String);
                }

            if (key != null)
                key.Close ();

            return 0;
            }

        static public Filters ReadFilter ()
            {
            Filters filter = new Filters ();
            RegistryKey key = RegistryKey.OpenRemoteBaseKey (RegistryHive.CurrentUser, "");
            RegistryKey subkey = key != null ? key.OpenSubKey ("Software\\ExoplanetLibrary") : null;

            if (subkey != null)
                {
                filter.TypeOEnabled = ReadValue (subkey, "StarTypeOEnabled");
                filter.TypeBEnabled = ReadValue (subkey, "StarTypeBEnabled");
                filter.TypeAEnabled = ReadValue (subkey, "StarTypeAEnabled");
                filter.TypeFEnabled = ReadValue (subkey, "StarTypeFEnabled");
                filter.TypeGEnabled = ReadValue (subkey, "StarTypeGEnabled");
                filter.TypeKEnabled = ReadValue (subkey, "StarTypeKEnabled");
                filter.TypeMEnabled = ReadValue (subkey, "StarTypeKEnabled");
                filter.UnknownStarEnabled = ReadValue (subkey, "UnknownStarEnabled");

                filter.PrimaryTransitEnabled = ReadValue (subkey, "PrimaryTransitEnabled");
                filter.RadialVelocityEnabled = ReadValue (subkey, "RadialVelocityEnabled");
                filter.MicrolensingEnabled = ReadValue (subkey, "MicrolensingEnabled");
                filter.ImagingEnabled = ReadValue (subkey, "ImagingEnabled");
                filter.PulsarEnabled = ReadValue (subkey, "PulsarEnabled");
                filter.AstrometryEnabled = ReadValue (subkey, "AstrometryEnabled");
                filter.TTVEnabled = ReadValue (subkey, "TTVEnabled");
                filter.UnknownDetectionEnabled = ReadValue (subkey, "UnknownDetectionEnabled");
                }

            if (key != null)
                key.Close ();

            return filter;
            }

        static public int WriteFileName (string xmlFileName)
            {
            RegistryKey key = RegistryKey.OpenRemoteBaseKey (RegistryHive.CurrentUser, "");
            RegistryKey subkey = ( key != null ) ? key.CreateSubKey ("Software\\ExoplanetLibrary") : null;

            if (subkey != null)
                subkey.SetValue ("XMLFileName", xmlFileName, RegistryValueKind.String);

            if (key != null)
                key.Close ();

            return 0;
            }

        static public string ReadFileName ()
            {
            string xmlFileName = "";
            RegistryKey key = RegistryKey.OpenRemoteBaseKey (RegistryHive.CurrentUser, "");
            RegistryKey subkey = key != null ? key.OpenSubKey ("Software\\ExoplanetLibrary") : null;

            if (subkey != null)
                {
                object obj = subkey.GetValue ("XMLFileName");

                if (obj != null)
                    xmlFileName = obj as string;
                }

            if (key != null)
                key.Close ();

            return xmlFileName;
            }

        static private CheckState ReadValue (RegistryKey subkey, string name)
            {
            object obj = subkey.GetValue (name);

            if (obj != null)
                {
                string value = obj as string;

                if (value.Equals ("True"))
                    return CheckState.Checked;
                else if (value.Equals ("False"))
                    return CheckState.Unchecked;
                }

            return CheckState.Unchecked;
            }

        public static bool MatchesFilter (Exoplanet exoplanet, Filters filter)
            {
            return MatchesStarFilter (exoplanet, filter) && MatchesDetectionFilter (exoplanet, filter) ? true : false;
            }

        public static bool MatchesStarFilter (Exoplanet exoplanet, Filters filter)
            {
            if (filter == null)
                return true;
            else
                {
                if (filter.UnknownStarEnabled == CheckState.Checked)
                    return true;
                else if (!IsStarTypeDefined (exoplanet))
                    return false;
                else if (IsTypeO (exoplanet))
                    return filter.TypeOEnabled == CheckState.Checked ? true : false;
                else if (IsTypeB (exoplanet))
                    return filter.TypeBEnabled == CheckState.Checked ? true : false;
                else if (IsTypeA (exoplanet))
                    return filter.TypeAEnabled == CheckState.Checked ? true : false;
                else if (IsTypeF (exoplanet))
                    return filter.TypeFEnabled == CheckState.Checked ? true : false;
                else if (IsTypeG (exoplanet))
                    return filter.TypeGEnabled == CheckState.Checked ? true : false;
                else if (IsTypeK (exoplanet))
                    return filter.TypeKEnabled == CheckState.Checked ? true : false;
                else if (IsTypeM (exoplanet))
                    return filter.TypeMEnabled == CheckState.Checked ? true : false;
                }

            return false;
            }

        public static bool MatchesDetectionFilter (Exoplanet exoplanet, Filters filter)
            {
            if (filter == null)
                return true;
            else
                {
                if (filter.UnknownDetectionEnabled == CheckState.Checked)
                    return true;
                else if (!IsDetectionDefined (exoplanet))
                    return false;
                else if (IsPrimaryTransit (exoplanet))
                    return filter.PrimaryTransitEnabled == CheckState.Checked ? true : false;
                else if (IsRadialVelocity (exoplanet))
                    return filter.RadialVelocityEnabled == CheckState.Checked ? true : false;
                else if (IsMicrolensing (exoplanet))
                    return filter.MicrolensingEnabled == CheckState.Checked ? true : false;
                else if (IsImaging (exoplanet))
                    return filter.ImagingEnabled == CheckState.Checked ? true : false;
                else if (IsPulsar (exoplanet))
                    return filter.PulsarEnabled == CheckState.Checked ? true : false;
                else if (IsAstrometry (exoplanet))
                    return filter.AstrometryEnabled == CheckState.Checked ? true : false;
                else if (IsTTV (exoplanet))
                    return filter.TTVEnabled == CheckState.Checked ? true : false;
                }

            return false;
            }

        public static bool IsStarTypeDefined (Exoplanet exoplanet)
            {
            return exoplanet.Star.Property.SPType != null ? true : false;
            }

        public static bool IsTypeO (Exoplanet exoplanet)
            {
            return exoplanet.Star.Property.SPType.Substring (0, 1) == "O" ? true : false;
            }

        public static bool IsTypeB (Exoplanet exoplanet)
            {
            return exoplanet.Star.Property.SPType.Substring (0, 1) == "B" ? true : false;
            }

        public static bool IsTypeA (Exoplanet exoplanet)
            {
            return exoplanet.Star.Property.SPType.Substring (0, 1) == "A" ? true : false;
            }

        public static bool IsTypeF (Exoplanet exoplanet)
            {
            return exoplanet.Star.Property.SPType.Substring (0, 1) == "F" ? true : false;
            }

        public static bool IsTypeG (Exoplanet exoplanet)
            {
            return exoplanet.Star.Property.SPType.Substring (0, 1) == "G" ? true : false;
            }

        public static bool IsTypeK (Exoplanet exoplanet)
            {
            return exoplanet.Star.Property.SPType.Substring (0, 1) == "K" ? true : false;
            }

        public static bool IsTypeM (Exoplanet exoplanet)
            {
            return exoplanet.Star.Property.SPType.Substring (0, 1) == "M" ? true : false;
            }

        public static bool IsDetectionDefined (Exoplanet exoplanet)
            {
            return exoplanet.DetectionType != null ? true : false;
            }

        public static bool IsPrimaryTransit (Exoplanet exoplanet)
            {
            return exoplanet.DetectionType.Equals ("Primary Transit", StringComparison.OrdinalIgnoreCase) ? true : false;
            }

        public static bool IsRadialVelocity (Exoplanet exoplanet)
            {
            return exoplanet.DetectionType.Equals ("Radial Velocity", StringComparison.OrdinalIgnoreCase) ? true : false;
            }

        public static bool IsMicrolensing (Exoplanet exoplanet)
            {
            return exoplanet.DetectionType.Equals ("Microlensing", StringComparison.OrdinalIgnoreCase) ? true : false;
            }

        public static bool IsImaging (Exoplanet exoplanet)
            {
            return exoplanet.DetectionType.Equals ("Imaging", StringComparison.OrdinalIgnoreCase) ? true : false;
            }

        public static bool IsPulsar (Exoplanet exoplanet)
            {
            return exoplanet.DetectionType.Equals ("Pulsar", StringComparison.OrdinalIgnoreCase) ? true : false;
            }

        public static bool IsAstrometry (Exoplanet exoplanet)
            {
            return exoplanet.DetectionType.Equals ("Astrometry", StringComparison.OrdinalIgnoreCase) ? true : false;
            }

        public static bool IsTTV (Exoplanet exoplanet)
            {
            return exoplanet.DetectionType.Equals ("TTV", StringComparison.OrdinalIgnoreCase) ? true : false;
            }
        }
    }
