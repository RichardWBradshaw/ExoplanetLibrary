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
    public partial class ExoplanetDetails : Form
        {
        LibraryDialog m_parent = null;

        public ExoplanetDetails ( LibraryDialog parent )
            {
            m_parent = parent;
            InitializeComponent ( );
            }

        private void ExoplanetDetails_FormClosing ( object sender, FormClosingEventArgs e )
            {
            if ( m_parent != null )
                m_parent.ExoplanetDetailsClosed ( );
            }

        public void DisplayDetails ( ExoplanetLibrary.CExoplanet exoplanet )
            {
            AddText ( nameTextBox, exoplanet.Name );
            AddText ( massTextBox, exoplanet.Mass );
            AddText ( massErrorTextBox, exoplanet.MassErrorMin, exoplanet.MassErrorMax );
            AddText ( radiusTextBox, exoplanet.Radius );
            AddText ( radiusErrorTextBox, exoplanet.RadiusErrorMin, exoplanet.RadiusErrorMax );
            AddText ( orbitalPeriodTextBox, exoplanet.OrbitalPeriod );
            AddText ( orbitalPeriodErrorTextBox, exoplanet.OrbitalPeriodErrorMin, exoplanet.OrbitalPeriodErrorMax );
            AddText ( semimajorAxisTextBox, exoplanet.SemiMajorAxis );
            AddText ( semimajorAxisErrorTextBox, exoplanet.SemiMajorAxisErrorMin, exoplanet.SemiMajorAxisErrorMax );
            AddText ( eccentricityTextBox, exoplanet.Eccentricity );
            AddText ( eccentricityErrorTextBox, exoplanet.EccentricityErrorMin, exoplanet.EccentricityErrorMax );
            AddText ( angularDistanceTextBox, exoplanet.AngularDistance );

            AddText ( inclinationTextBox, exoplanet.Inclination );
            AddText ( inclinationErrorTextBox, exoplanet.InclinationErrorMin, exoplanet.InclinationErrorMax );

            AddText ( eccentricityTextBox, exoplanet.Eccentricity );
            AddText ( eccentricityErrorTextBox, exoplanet.EccentricityErrorMin, exoplanet.EccentricityErrorMax );

            AddText ( tzeroTrTextBox, exoplanet.TzeroTr );
            AddText ( tzeroTrErrorTextBox, exoplanet.TzeroTrErrorMin, exoplanet.TzeroTrErrorMax );

            AddText ( tzeroTrSecTextBox, exoplanet.TzeroTrSec );
            AddText ( tzeroTrSecErrorTextBox, exoplanet.TzeroTrSecErrorMin, exoplanet.TzeroTrSecErrorMax );

            AddText ( lambdaAngleTextBox, exoplanet.LambdaAngle );
            AddText ( lambdaAngleErrorTextBox, exoplanet.LambdaAngleErrorMin, exoplanet.LambdaAngleErrorMax );

            AddText ( tzeroVrTextBox, exoplanet.TzeroVr );
            AddText ( tzeroVrTextBox, exoplanet.TzeroVrErrorMin, exoplanet.TzeroVrErrorMax );

            AddText ( calculatedTemperatureTextBox, exoplanet.TemperatureCalculated );

            AddText ( measuredTemperatureTextBox, exoplanet.TemperatureMeasured );

            AddText ( hotPointLonTextBox, exoplanet.TemperatureHotPointLo );

            AddText ( logGTextBox, exoplanet.LogG );

            AddText ( publicationStatusTextBox, exoplanet.Status );

            AddText ( updatedTextBox, exoplanet.Updated );

            AddText ( omegaTextBox, exoplanet.Omega );
            AddText ( omagaErrorTextBox, exoplanet.OmegaErrorMin, exoplanet.OmegaErrorMax );

            AddText ( tperiTextBox, exoplanet.Tperi );
            AddText ( tperiErrorTextBox, exoplanet.TperiErrorMin, exoplanet.TperiErrorMax );

            AddText ( detectionTypeTextBox, exoplanet.DetectionType );

            AddText ( moleculesTextBox, exoplanet.Molecules );

            AddText ( impactParameterTextBox, exoplanet.ImpactParameter );
            AddText ( impactParameterErrorTextBox, exoplanet.ImpactParameterErrorMin, exoplanet.ImpactParameterErrorMax );

            AddText ( kTextBox, exoplanet.K );
            AddText ( kErrorTextBox, exoplanet.KErrorMin, exoplanet.KErrorMax );

            AddText ( geometricAlbedoTextBox, exoplanet.GeometricAlbedo );
            AddText ( geometricAlbedoErrorTextBox, exoplanet.GeometricAlbedoErrorMin, exoplanet.GeometricAlbedoErrorMax );

            AddText ( tconjTextBox, exoplanet.Tconj );
            AddText ( tconjErrorTextBox, exoplanet.TconjErrorMin, exoplanet.TconjErrorMax );

            AddText ( massDetectionTextBox, exoplanet.MassDetectionType );

            AddText ( radiusDetectionTextBox, exoplanet.RadiusDetectionType );

            AddText ( alternateNamesTextBox, exoplanet.AlternateNames );
            }

        private static void AddText ( System.Windows.Forms.TextBox textBox, string stringer )
            {
            textBox.ResetText ( );

            if ( stringer != null )
                if ( stringer.Length > 0 )
                    textBox.AppendText ( stringer );
            }

        private static void AddText ( System.Windows.Forms.TextBox textBox, string stringer1, string stringer2 )
            {
            textBox.ResetText ( );

            if ( stringer1 != null && stringer2 != null )
                if ( stringer1.Length > 0 && stringer2.Length > 0 )
                    if ( stringer1 == stringer2 )
                        textBox.AppendText ( "+/- " + stringer1 );
                    else
                        textBox.AppendText ( stringer1 + " / " + stringer2 );
            }
        }
    }
