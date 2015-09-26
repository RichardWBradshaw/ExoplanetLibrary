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
        public ListView m_exoplanetDetailsListView = null;

        public ExoplanetDetails ( LibraryDialog parent )
            {
            m_parent = parent;
            InitializeComponent ( );
            CreatePlanetListView ( );
            }

        private void PlanetNStarDetails_FormClosing ( object sender, FormClosingEventArgs e )
            {
            if ( m_parent != null )
                m_parent.ExoplanetDetailsClosed ( );
            }

        private void CreatePlanetListView ( )
            {
            m_exoplanetDetailsListView = new ListView ( );
            m_exoplanetDetailsListView.Bounds = new Rectangle ( new Point ( 10, 10 ), new Size ( Width - 45, Height - ( 60 ) ) );

            m_exoplanetDetailsListView.View = View.Details;
            m_exoplanetDetailsListView.LabelEdit = false;
            m_exoplanetDetailsListView.AllowColumnReorder = false;
            m_exoplanetDetailsListView.CheckBoxes = false;
            m_exoplanetDetailsListView.FullRowSelect = true;
            m_exoplanetDetailsListView.GridLines = true;
            m_exoplanetDetailsListView.Sorting = SortOrder.None;

            AddItemsToListView ( m_exoplanetDetailsListView, true, null );
            Controls.Add ( m_exoplanetDetailsListView );
            }

        private void UpdatePlanetsListView ( )
            {
            for ( int index = m_exoplanetDetailsListView.Items.Count - 1; index >= 0; --index )
                m_exoplanetDetailsListView.Items.RemoveAt ( index );

            AddItemsToListView ( m_exoplanetDetailsListView, false, null );
            }

        private void AddItemsToListView ( ListView listView, bool addColumns, ExoplanetLibrary.CExoplanet exoplanet )
            {
            if ( addColumns )
                {
                int width = ( listView.Width - 10 ) / 2;

                listView.Columns.Add ( "Property", width, HorizontalAlignment.Left );
                listView.Columns.Add ( "Value", width, HorizontalAlignment.Left );
                }

            if ( exoplanet != null )
                {
                ListViewItem item = null;

                item = new ListViewItem ( "Planet", 0 );
                item.SubItems.Add ( exoplanet.Name );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Mass (Mjup)", 0 );
                item.SubItems.Add ( Format ( exoplanet.Mass, exoplanet.MassErrorMin, exoplanet.MassErrorMax ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Radius (Rjup)", 0 );
                item.SubItems.Add ( Format ( exoplanet.Radius, exoplanet.RadiusErrorMin, exoplanet.RadiusErrorMax ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Orbitat Period (day)", 0 );
                item.SubItems.Add ( Format ( exoplanet.OrbitalPeriod, exoplanet.OrbitalPeriodErrorMin, exoplanet.OrbitalPeriodErrorMax ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Semi-Major Axis (AU)", 0 );
                item.SubItems.Add ( Format ( exoplanet.SemiMajorAxis, exoplanet.SemiMajorAxisErrorMin, exoplanet.SemiMajorAxisErrorMax ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Eccentricity", 0 );
                item.SubItems.Add ( Format ( exoplanet.Eccentricity, exoplanet.EccentricityErrorMin, exoplanet.EccentricityErrorMax ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Inclination (deg)", 0 );
                item.SubItems.Add ( Format ( exoplanet.Inclination, exoplanet.InclinationErrorMin, exoplanet.InclinationErrorMax ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "T0 (JD)", 0 );
                item.SubItems.Add ( Format ( exoplanet.TzeroTr, exoplanet.TzeroTrErrorMin, exoplanet.TzeroTrErrorMax ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "T0-sec (JD)", 0 );
                item.SubItems.Add ( Format ( exoplanet.TzeroTrSec, exoplanet.TzeroTrSecErrorMin, exoplanet.TzeroTrSecErrorMax ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Lambda Angle (deg)", 0 );
                item.SubItems.Add ( Format ( exoplanet.LambdaAngle, exoplanet.LambdaAngleErrorMin, exoplanet.LambdaAngleErrorMax ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Tvr (JD)", 0 );
                item.SubItems.Add ( Format ( exoplanet.TzeroVr, exoplanet.TzeroVrErrorMin, exoplanet.TzeroVrErrorMax ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Tcalc (K)", 0 );
                item.SubItems.Add ( Format ( exoplanet.TemperatureCalculated ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Tmeas (K)", 0 );
                item.SubItems.Add ( Format ( exoplanet.TemperatureMeasured ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Hot pt (deg)", 0 );
                item.SubItems.Add ( Format ( exoplanet.TemperatureHotPointLo ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Log(g)", 0 );
                item.SubItems.Add ( Format ( exoplanet.LogG ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Publication Status", 0 );
                item.SubItems.Add ( Format ( exoplanet.Status ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Discovered", 0 );
                item.SubItems.Add ( Format ( exoplanet.Discovered ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Updated", 0 );
                item.SubItems.Add ( Format ( exoplanet.Updated ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Omega (deg)", 0 );
                item.SubItems.Add ( Format ( exoplanet.Omega, exoplanet.OmegaErrorMin, exoplanet.OmegaErrorMax ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Tperi (JD)", 0 );
                item.SubItems.Add ( Format ( exoplanet.Tperi, exoplanet.TperiErrorMin, exoplanet.TperiErrorMax ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Detection Type", 0 );
                item.SubItems.Add ( exoplanet.DetectionType );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Molecules", 0 );
                item.SubItems.Add ( Format ( exoplanet.Molecules ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Impact Parameter b(%)", 0 );
                item.SubItems.Add ( Format ( exoplanet.ImpactParameter, exoplanet.ImpactParameterErrorMin, exoplanet.ImpactParameterErrorMax ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "K (m/s)", 0 );
                item.SubItems.Add ( Format ( exoplanet.K, exoplanet.KErrorMin, exoplanet.KErrorMax ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Geometric Albedo", 0 );
                item.SubItems.Add ( Format ( exoplanet.GeometricAlbedo, exoplanet.GeometricAlbedoErrorMin, exoplanet.GeometricAlbedoErrorMax ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Tconj", 0 );
                item.SubItems.Add ( Format ( exoplanet.Tconj, exoplanet.TconjErrorMin, exoplanet.TconjErrorMax ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Mass Detection Type", 0 );
                item.SubItems.Add ( Format ( exoplanet.MassDetectionType ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Radius Detection Type", 0 );
                item.SubItems.Add ( Format ( exoplanet.RadiusDetectionType ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "AlternateNames", 0 );
                item.SubItems.Add ( Format ( exoplanet.AlternateNames ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Star", 0 );
                item.SubItems.Add ( exoplanet.Star.Name );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Right Accession", 0 );
                item.SubItems.Add ( Format ( exoplanet.Star.RightAccession ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Declination", 0 );
                item.SubItems.Add ( Format ( exoplanet.Star.Declination ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "SPType", 0 );
                item.SubItems.Add ( Format ( exoplanet.Star.Properties.SPType ) );
                m_exoplanetDetailsListView.Items.Add ( item );

                listView.Refresh ( );
                }
            }

        private string Format ( string value, string minimumError, string maximumError )
            {
            if ( minimumError != null && maximumError != null && minimumError.Length > 0 && maximumError.Length > 0 )
                {
                if ( string.Equals ( minimumError, maximumError ) )
                    return value + " (+/-" + maximumError + ")";
                else
                    return value + " (+" + maximumError + "/-" + minimumError + ")";
                }
            else if ( value != null && value.Length > 0 )
                return value;
            else
                return " - ";
            }

        private string Format ( string value )
            {
            if ( value != null && value.Length > 0 )
                return value;
            else
                return " - ";
            }

        public void DisplayDetails ( ExoplanetLibrary.CExoplanet exoplanet )
            {
            for ( int index = m_exoplanetDetailsListView.Items.Count - 1; index >= 0; --index )
                m_exoplanetDetailsListView.Items.RemoveAt ( index );

            AddItemsToListView ( m_exoplanetDetailsListView, false, exoplanet );
            }
        }
    }
