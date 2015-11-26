using System.Windows.Forms;
using Microsoft.Win32;

namespace ExoplanetLibrary
    {
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
        }
    }
