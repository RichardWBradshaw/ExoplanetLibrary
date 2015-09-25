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
                int width = ( listView.Width - 10 ) / 4;

                listView.Columns.Add ( "Property", width, HorizontalAlignment.Left );
                listView.Columns.Add ( "Value", width, HorizontalAlignment.Left );
                listView.Columns.Add ( "Minimum Error", width, HorizontalAlignment.Left );
                listView.Columns.Add ( "Maximum Error", width, HorizontalAlignment.Left );
                }

            if ( exoplanet != null )
                {
                ListViewItem item = null;

                item = new ListViewItem ( "Name", 0 );
                item.SubItems.Add ( exoplanet.Name );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Mass", 0 );
                item.SubItems.Add ( exoplanet.Mass );
                item.SubItems.Add ( exoplanet.MassErrorMin );
                item.SubItems.Add ( exoplanet.MassErrorMax );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Radius", 0 );
                item.SubItems.Add ( exoplanet.Radius );
                item.SubItems.Add ( exoplanet.RadiusErrorMin );
                item.SubItems.Add ( exoplanet.RadiusErrorMax );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Orbitat Period ", 0 );
                item.SubItems.Add ( exoplanet.OrbitalPeriod );
                item.SubItems.Add ( exoplanet.OrbitalPeriodErrorMin );
                item.SubItems.Add ( exoplanet.OrbitalPeriodErrorMax );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "SemiMajorAxis", 0 );
                item.SubItems.Add ( exoplanet.SemiMajorAxis );
                item.SubItems.Add ( exoplanet.SemiMajorAxisErrorMin );
                item.SubItems.Add ( exoplanet.SemiMajorAxisErrorMax );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Eccentricity", 0 );
                item.SubItems.Add ( exoplanet.Eccentricity );
                item.SubItems.Add ( exoplanet.EccentricityErrorMin );
                item.SubItems.Add ( exoplanet.EccentricityErrorMax );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Inclination", 0 );
                item.SubItems.Add ( exoplanet.Inclination );
                item.SubItems.Add ( exoplanet.InclinationErrorMin );
                item.SubItems.Add ( exoplanet.InclinationErrorMax );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "TzeroTr", 0 );
                item.SubItems.Add ( exoplanet.TzeroTr );
                item.SubItems.Add ( exoplanet.TzeroTrErrorMin );
                item.SubItems.Add ( exoplanet.TzeroTrErrorMax );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "TzeroTrSec", 0 );
                item.SubItems.Add ( exoplanet.TzeroTrSec );
                item.SubItems.Add ( exoplanet.TzeroTrSecErrorMin );
                item.SubItems.Add ( exoplanet.TzeroTrSecErrorMax );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Lambda Angle", 0 );
                item.SubItems.Add ( exoplanet.LambdaAngle );
                item.SubItems.Add ( exoplanet.LambdaAngleErrorMin );
                item.SubItems.Add ( exoplanet.LambdaAngleErrorMax );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "TzeroVr", 0 );
                item.SubItems.Add ( exoplanet.TzeroVr );
                item.SubItems.Add ( exoplanet.TzeroVrErrorMin );
                item.SubItems.Add ( exoplanet.TzeroVrErrorMax );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Temp Cal", 0 );
                item.SubItems.Add ( exoplanet.TemperatureCalculated);
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Temp Meas", 0 );
                item.SubItems.Add ( exoplanet.TemperatureMeasured );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Temp Long", 0 );
                item.SubItems.Add ( exoplanet.TemperatureHotPointLo );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Log(g)", 0 );
                item.SubItems.Add ( exoplanet.LogG );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Status", 0 );
                item.SubItems.Add ( exoplanet.Status );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Discovered", 0 );
                item.SubItems.Add ( exoplanet.Discovered );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Updated", 0 );
                item.SubItems.Add ( exoplanet.Updated );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Omega", 0 );
                item.SubItems.Add ( exoplanet.Omega );
                item.SubItems.Add ( exoplanet.OmegaErrorMin );
                item.SubItems.Add ( exoplanet.OmegaErrorMax );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Tperi", 0 );
                item.SubItems.Add ( exoplanet.Tperi );
                item.SubItems.Add ( exoplanet.TperiErrorMin );
                item.SubItems.Add ( exoplanet.TperiErrorMax );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Detection Type", 0 );
                item.SubItems.Add ( exoplanet.DetectionType);
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Molecules", 0 );
                item.SubItems.Add ( exoplanet.Molecules );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Impact Parameter", 0 );
                item.SubItems.Add ( exoplanet.ImpactParameter );
                item.SubItems.Add ( exoplanet.ImpactParameterErrorMin );
                item.SubItems.Add ( exoplanet.ImpactParameterErrorMax );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "K", 0 );
                item.SubItems.Add ( exoplanet.K );
                item.SubItems.Add ( exoplanet.KErrorMin );
                item.SubItems.Add ( exoplanet.KErrorMax );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Geometric Albedo", 0 );
                item.SubItems.Add ( exoplanet.GeometricAlbedo );
                item.SubItems.Add ( exoplanet.GeometricAlbedoErrorMin );
                item.SubItems.Add ( exoplanet.GeometricAlbedoErrorMax );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Tconj", 0 );
                item.SubItems.Add ( exoplanet.Tconj );
                item.SubItems.Add ( exoplanet.TconjErrorMin );
                item.SubItems.Add ( exoplanet.TconjErrorMax );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Mass Detection Type", 0 );
                item.SubItems.Add ( exoplanet.MassDetectionType );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "Radius Detection Type", 0 );
                item.SubItems.Add ( exoplanet.RadiusDetectionType );
                m_exoplanetDetailsListView.Items.Add ( item );

                item = new ListViewItem ( "AlternateNames", 0 );
                item.SubItems.Add ( exoplanet.AlternateNames );
                m_exoplanetDetailsListView.Items.Add ( item );

                listView.Refresh ( );
                }
            }

        public void DisplayDetails ( ExoplanetLibrary.CExoplanet exoplanet )
            {
            for ( int index = m_exoplanetDetailsListView.Items.Count - 1; index >= 0; --index )
                m_exoplanetDetailsListView.Items.RemoveAt ( index );

            AddItemsToListView ( m_exoplanetDetailsListView, false, exoplanet );
            }
        }
    }
