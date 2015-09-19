using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExoplanetLibrary
    {
    public partial class StarDetails : Form
        {
        LibraryDialog m_parent = null;

        public StarDetails ( LibraryDialog parent )
            {
            m_parent = parent;
            InitializeComponent ( );
            }

        private void StarDetails_FormClosing ( object sender, FormClosingEventArgs e )
            {
            if ( m_parent != null )
                m_parent.StarDetailsClosed ( );
            }

        public void DisplayDetails ( ExoplanetLibrary.CExoplanet exoplanet )
            {
            AddText ( nameTextBox, exoplanet.Star.Name );
            AddText ( raTextBox, Helper.FormatHMS ( exoplanet.Star.RightAccession ) );
            AddText ( decTextBox, Helper.FormatHMS ( exoplanet.Star.Declination ) );

            AddText ( magnitudeVTextBox, exoplanet.Star.Magnitudes.V );
            AddText ( magnitudeITextBox, exoplanet.Star.Magnitudes.I );
            AddText ( magnitudeJTextBox, exoplanet.Star.Magnitudes.J );
            AddText ( magnitudeHTextBox, exoplanet.Star.Magnitudes.H );
            AddText ( magnitudeKTextBox, exoplanet.Star.Magnitudes.K );

            AddText ( spTypeTextBox, exoplanet.Star.Properties.SPType );
            AddText ( ageTextBox, exoplanet.Star.Properties.Age );
            AddText ( distanceTextBox, exoplanet.Star.Properties.Distance );
            AddText ( massTextBox, exoplanet.Star.Properties.Mass );
            AddText ( radiusTextBox, exoplanet.Star.Properties.Radius );
            AddText ( metallicityTextBox, exoplanet.Star.Properties.Metallicity );
            AddText ( teffTextBox, exoplanet.Star.Properties.Teff );
            AddText ( detectedDiscTextBox, exoplanet.Star.Properties.DetectedDisc );
            AddText ( magneticFieldTextBox, exoplanet.Star.Properties.MagneticField );
            }

        private static void AddText ( System.Windows.Forms.TextBox textBox, string stringer )
            {
            textBox.ResetText ( );

            if ( stringer != null )
                if ( stringer.Length > 0 )
                    textBox.AppendText ( stringer );
            }
        }
    }
