using System.Reflection;
using System.Windows.Forms;

namespace ExoplanetLibrary
    {
    public partial class AboutBox : Form
        {
        public AboutBox ()
            {
            InitializeComponent ();
            Text = string.Format ("About {0}", AssemblyTitle);
            labelProductName.Text = AssemblyProduct;
            labelVersion.Text = string.Format ("Version {0}", AssemblyVersion);
            labelCopyright.Text = AssemblyCopyright;
            labelCompanyName.Text = AssemblyCompany;
            textBoxDescription.Text = AssemblyDescription;
            }

        public string AssemblyTitle
            {
            get
                {
                object [] attributes = Assembly.GetExecutingAssembly ().GetCustomAttributes (typeof (AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                    {
                    AssemblyTitleAttribute titleAttribute = ( AssemblyTitleAttribute )attributes [0];
                    if (titleAttribute.Title != "")
                        {
                        return titleAttribute.Title;
                        }
                    }
                return System.IO.Path.GetFileNameWithoutExtension (Assembly.GetExecutingAssembly ().CodeBase);
                }
            }

        public string AssemblyVersion
            {
            get
                {
                return Assembly.GetExecutingAssembly ().GetName ().Version.ToString ();
                }
            }

        public string AssemblyDescription
            {
            get
                {
                object [] attributes = Assembly.GetExecutingAssembly ().GetCustomAttributes (typeof (AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                    {
                    return "";
                    }
                return ( ( AssemblyDescriptionAttribute )attributes [0] ).Description +
                       "This program uses VOTable data from:\r\n" +
                       "    o http://exoplanet.eu (last visited on " + Settings.ReadLastEUVisit () + ")\r\n" +
                       "    o http://exoplanetarchive.ipac.caltech.edu/ (last visited on " + Settings.ReadLastNASAVisit () + ")\r\n" +
                       "\r\n" +
                       "This program uses CSV data from:\r\n" +
                       "    o http://exoplanets.org (last visited on " + Settings.ReadLastExoplanetsOrgVisit () + ")\r\n" +
                       "\r\n" +
                       "Graphics utilizes 'NPlot' a free .NET library.  More details can be found at http://www.netcontrols.org/nplot \r\n";
                }
            }

        public string AssemblyProduct
            {
            get
                {
                object [] attributes = Assembly.GetExecutingAssembly ().GetCustomAttributes (typeof (AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                    {
                    return "";
                    }
                return ( ( AssemblyProductAttribute )attributes [0] ).Product;
                }
            }

        public string AssemblyCopyright
            {
            get
                {
                object [] attributes = Assembly.GetExecutingAssembly ().GetCustomAttributes (typeof (AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                    {
                    return "";
                    }
                return ( ( AssemblyCopyrightAttribute )attributes [0] ).Copyright;
                }
            }

        public string AssemblyCompany
            {
            get
                {
                object [] attributes = Assembly.GetExecutingAssembly ().GetCustomAttributes (typeof (AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                    {
                    return "";
                    }
                return ( ( AssemblyCompanyAttribute )attributes [0] ).Company;
                }
            }
        }
    }
