using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

// A simple C# library for graph plotting

namespace ExoplanetLibrary
    {
    public partial class LibraryDialog : Form
        {
        public ListView m_exoplanetListView = null;
        private bool m_addPlanetDetails = false;
        private bool m_addStarDetails = false;
        private ListViewColumnSorter lvwColumnSorter;
        private string m_xmlFileName = "C:\\ProgramData\\Exoplanet Library\\kepler.xml";

        private ArrayList m_exoplanets = null;

        private ExoplanetDetails m_exoplanetDetails = null;

        private AboutBox m_about = null;

        public LibraryDialog ( )
            {
            InitializeComponent ( );

            CreateExoplanetListView ( );
            lvwColumnSorter = new ListViewColumnSorter ( );
            m_exoplanetListView.ListViewItemSorter = lvwColumnSorter;

            openMenuItem.Click += new EventHandler ( open_Click );
            exitMenuItem.Click += new EventHandler ( exit_Click );
#if not_used
            openXMLMenuItem.Click += new EventHandler ( openXML_Click );
            openCSVMenuItem.Click += new EventHandler ( openCSV_Click );
#endif
            saveAsMenuItem.Click += new EventHandler ( saveAs_Click );

            aboutMenuItem.Click += new EventHandler ( about_Click );

            ResizeBegin += new System.EventHandler ( MyResizeBegin );
            ResizeEnd += new System.EventHandler ( MyResizeEnd );
            SizeChanged += new System.EventHandler ( MyResize );
            }

        private void MyResizeBegin ( object sender, System.EventArgs e )
            {
            }

        private void MyResizeEnd ( object sender, System.EventArgs e )
            {
            }

        private void MyResize ( object sender, System.EventArgs e )
            {
            Control control = ( Control )sender;

            if ( m_exoplanetListView != null )
                {
                m_exoplanetListView.Height = Size.Height - ( 60 + 24 );
                m_exoplanetListView.Width = Size.Width - 40;
                }
            }

        private void CreateExoplanetListView ( )
            {
            m_exoplanetListView = new ListView ( );
            m_exoplanetListView.Bounds = new Rectangle ( new Point ( 10, 24 ), new Size ( Width - 40, Height - ( 60 + 24 ) ) );

            m_exoplanetListView.View = View.Details;
            m_exoplanetListView.LabelEdit = false;
            m_exoplanetListView.AllowColumnReorder = true;
            m_exoplanetListView.CheckBoxes = false;
            m_exoplanetListView.FullRowSelect = true;
            m_exoplanetListView.GridLines = true;
            m_exoplanetListView.Sorting = SortOrder.Ascending;

            AddItemsToListView ( m_exoplanetListView, true );
            m_exoplanetListView.ColumnClick += new ColumnClickEventHandler ( ExoplanentListView_ColumnClick );
            m_exoplanetListView.Click += new EventHandler ( ExoplanentListView_Click );
            m_exoplanetListView.DoubleClick += new EventHandler ( ExoplanentListView_DoubleClick );
            //m_exoplanetListView.KeyDown += new KeyEventHandler ( ExoplanentListView_KeyDown );
            //m_exoplanetListView.KeyUp += new KeyEventHandler ( ExoplanentListView_KeyUp );
            Controls.Add ( m_exoplanetListView );
            }

        private void UpdateExoplanetListView ( )
            {
            for ( int index = m_exoplanetListView.Items.Count - 1; index >= 0; --index )
                m_exoplanetListView.Items.RemoveAt ( index );

            AddItemsToListView ( m_exoplanetListView, false );
            }

        private void AddItemsToListView ( ListView listView, bool addColumns )
            {
            if ( m_exoplanets != null )
                m_exoplanets.Clear ( );

            m_exoplanets = null;
            ReadXML.Read ( m_xmlFileName, ref m_exoplanets );

            if ( addColumns )
                {
                listView.Columns.Add ( "Name", -2, HorizontalAlignment.Left );
                listView.Columns.Add ( "M (Mjup)", -2, HorizontalAlignment.Left );
                listView.Columns.Add ( "R (Rjup)", -2, HorizontalAlignment.Left );
                listView.Columns.Add ( "Period (day)", -2, HorizontalAlignment.Left);
                listView.Columns.Add ( "Semi-Major Axis (AU)", -2, HorizontalAlignment.Left );
                listView.Columns.Add ( "Eccentricity", -2, HorizontalAlignment.Left );
                listView.Columns.Add ( "Angular Distance", -2, HorizontalAlignment.Left );

                if ( m_addPlanetDetails )
                    {
                    listView.Columns.Add ( "Inclination (deg)", -2, HorizontalAlignment.Left );
                    listView.Columns.Add ( "T0 (JD)", -2, HorizontalAlignment.Left );
                    listView.Columns.Add ( "T0-sec (JD)", -2, HorizontalAlignment.Left );
                    listView.Columns.Add ( "Lambda Angle (deg)", -2, HorizontalAlignment.Left );
                    listView.Columns.Add ( "Tvr (JD)", -2, HorizontalAlignment.Left );
                    listView.Columns.Add ( "Tcalc. (K)", -2, HorizontalAlignment.Left );
                    listView.Columns.Add ( "Tmeas. (K)", -2, HorizontalAlignment.Left );
                    listView.Columns.Add ( "Hot pt (deg)", -2, HorizontalAlignment.Left);
                    listView.Columns.Add ( "Log(g)", -2, HorizontalAlignment.Left );
                    listView.Columns.Add ( "Pub. Status", -2, HorizontalAlignment.Left );
                    }

                listView.Columns.Add ( "Discovered", -2, HorizontalAlignment.Left );
                listView.Columns.Add ( "Updated", -2, HorizontalAlignment.Left );

                if ( m_addPlanetDetails )
                    {
                    listView.Columns.Add ( "Omega (deg)", -2, HorizontalAlignment.Left );
                    listView.Columns.Add ( "Detection Type", -2, HorizontalAlignment.Left );
                    listView.Columns.Add ( "Molecules", -2, HorizontalAlignment.Left );
                    }

                listView.Columns.Add ( "Star Name", -2, HorizontalAlignment.Left );
                listView.Columns.Add ( "RA", -2, HorizontalAlignment.Left );
                listView.Columns.Add ( "Declination", -2, HorizontalAlignment.Left );

                if ( m_addStarDetails )
                    {
                    listView.Columns.Add ( "SPType", -2, HorizontalAlignment.Left );
                    listView.Columns.Add ( "Age", -2, HorizontalAlignment.Left );
                    listView.Columns.Add ( "Distance", -2, HorizontalAlignment.Left );
                    listView.Columns.Add ( "M (Msun)", -2, HorizontalAlignment.Left );
                    listView.Columns.Add ( "R (Rsun)", -2, HorizontalAlignment.Left );
                    }
                }
#if walk_enumerator
            IEnumerator exoplanentEnumerator = m_exoplanets.GetEnumerator ( );
            exoplanentEnumerator.Reset();

            CExoplanet exoplanetList[] = new CExoplanet(m_exoplanets);
            while ( exoplanentEnumerator.MoveNext ( ) )
                {
                CExoplanet exoplanet = exoplanentEnumerator.Current as CExoplanet;
                }
#else
            foreach ( CExoplanet exoplanet in m_exoplanets )
                {
                ListViewItem item = new ListViewItem ( exoplanet.Name, 0 );

                item.SubItems.Add ( exoplanet.Mass );
                item.SubItems.Add ( exoplanet.Radius );
                item.SubItems.Add ( exoplanet.OrbitalPeriod );
                item.SubItems.Add ( exoplanet.SemiMajorAxis );
                item.SubItems.Add ( exoplanet.Eccentricity );
                item.SubItems.Add ( exoplanet.AngularDistance );

                if ( m_addPlanetDetails )
                    {
                    item.SubItems.Add ( exoplanet.Inclination );
                    item.SubItems.Add ( exoplanet.TzeroTr );
                    item.SubItems.Add ( exoplanet.TzeroTrSec );
                    item.SubItems.Add ( exoplanet.LambdaAngle );
                    item.SubItems.Add ( exoplanet.TzeroVr );
                    item.SubItems.Add ( exoplanet.TemperatureCalculated );
                    item.SubItems.Add ( exoplanet.TemperatureMeasured );
                    item.SubItems.Add ( exoplanet.TemperatureHotPointLo );
                    item.SubItems.Add ( exoplanet.LogG );
                    item.SubItems.Add ( exoplanet.Status );
                    }

                item.SubItems.Add ( exoplanet.Discovered );
                item.SubItems.Add ( exoplanet.Updated );

                if ( m_addPlanetDetails )
                    {
                    item.SubItems.Add ( exoplanet.Omega );
                    item.SubItems.Add ( exoplanet.DetectionType );
                    item.SubItems.Add ( exoplanet.Molecules );
                    }

                item.SubItems.Add ( exoplanet.Star.Name );
                item.SubItems.Add ( Helper.FormatHMS ( exoplanet.Star.RightAccession ) );
                item.SubItems.Add ( Helper.FormatHMS ( exoplanet.Star.Declination ) );

                if ( m_addStarDetails )
                    {
                    item.SubItems.Add ( exoplanet.Star.Properties.SPType );
                    item.SubItems.Add ( exoplanet.Star.Properties.Age );
                    item.SubItems.Add ( exoplanet.Star.Properties.Distance );
                    item.SubItems.Add ( exoplanet.Star.Properties.Mass );
                    item.SubItems.Add ( exoplanet.Star.Properties.Radius );
                    }

                item.Tag = exoplanet;
                listView.Items.Add ( item );
                }
#endif
            }

        private void ExoplanentListView_ColumnClick ( object sender, ColumnClickEventArgs e )
            {
            if ( e.Column == lvwColumnSorter.SortColumn )
                {
                if ( lvwColumnSorter.Order == SortOrder.Ascending )
                    lvwColumnSorter.Order = SortOrder.Descending;
                else
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            else
                {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
                }

            m_exoplanetListView.Sort ( );
            }

        private void ExoplanentListView_Click ( object sender, EventArgs e )
            {
            if (m_exoplanetListView.SelectedItems.Count == 1)
                {
                CExoplanet exoplanet = ( CExoplanet )m_exoplanetListView.SelectedItems [0].Tag;

#if display_as_modal_dialog
                if ( m_exoplanetDetails == null )
                    m_exoplanetDetails = new Details ( );

                m_exoplanetDetails.ExoplanetDetails ( exoplanet );
                m_exoplanetDetails.ShowDialog ( );
#else
                displayAllDetails (exoplanet);
#endif
                }
            }

        private void ExoplanentListView_DoubleClick ( object sender, EventArgs e )
            {
            if (m_exoplanetListView.SelectedItems.Count == 1)
                {
                m_exoplanetListView.Sort ();
                Refresh ();

                CExoplanet previousExoplanet = null;
                int multiPlanetStars = 0;

                foreach ( CExoplanet exoplanet in m_exoplanets )
                    {
                    if (previousExoplanet != null)
                        if (string.Equals (exoplanet.Star.Name, previousExoplanet.Star.Name))
                            ++multiPlanetStars;

                    previousExoplanet = exoplanet;
                    }

                    MessageBox.Show ("Number of Exoplanets " + m_exoplanets.Count +
                                     "\rMulti-Planet Stars " + multiPlanetStars);

                //CExoplanet exoplanet = ( CExoplanet )m_exoplanetListView.SelectedItems [0].Tag;
                //MessageBox.Show ("Name: " + exoplanet.Name +
                //    "\rMass: " + exoplanet.Mass + "(" + exoplanet.MassErrorMin + " " + exoplanet.MassErrorMax + ")" +
                //    "\rRadius: " + exoplanet.Radius + "(" + exoplanet.RadiusErrorMin + " " + exoplanet.RadiusErrorMax + ")" +
                //    "\rOrbital Period: " + exoplanet.OrbitalPeriod + "(" + exoplanet.OrbitalPeriodErrorMin + " " + exoplanet.OrbitalPeriodErrorMax + ")" +
                //    "\rSemi Major Axis: " + exoplanet.SemiMajorAxis + "(" + exoplanet.SemiMajorAxisErrorMin + " " + exoplanet.SemiMajorAxisErrorMax + ")" +
                //    "\rEccentricity: " + exoplanet.Eccentricity + "(" + exoplanet.EccentricityErrorMin + " " + exoplanet.EccentricityErrorMax + ")" +
                //    "\rAngular Distance: " + exoplanet.OrbitalPeriod +
                //    "\rInclination: " + exoplanet.Inclination + "(" + exoplanet.InclinationErrorMin + " " + exoplanet.InclinationErrorMax + ")" +
                //    "\rTzero Tr: " + exoplanet.TzeroTr + "(" + exoplanet.TzeroTrErrorMin + " " + exoplanet.TzeroTrErrorMax + ")" +
                //    "\rTzero Tr Sec: " + exoplanet.TzeroTrSec + "(" + exoplanet.TzeroTrSecErrorMin + " " + exoplanet.TzeroTrSecErrorMax + ")" +
                //    "\rLambda Angle: " + exoplanet.LambdaAngle + "(" + exoplanet.LambdaAngleErrorMin + " " + exoplanet.LambdaAngleErrorMax + ")" +
                //    "\rTzero Vr: " + exoplanet.TzeroVr + "(" + exoplanet.TzeroVrErrorMin + " " + exoplanet.TzeroVrErrorMax + ")" +
                //    "\rTemp. Calc.: " + exoplanet.TemperatureCalculated +
                //    "\rTemp. Meas.: " + exoplanet.TemperatureMeasured +
                //    "\rTemp. HPL: " + exoplanet.TemperatureHotPointLo +
                //    "\rLogG: " + exoplanet.LogG +
                //    "\rPublication Status: " + exoplanet.Status +
                //    "\rDiscovered: " + exoplanet.Discovered +
                //    "\rUpdated: " + exoplanet.Updated +
                //    "\rOmega: " + exoplanet.Omega + "(" + exoplanet.OmegaErrorMin + " " + exoplanet.OmegaErrorMax + ")" +
                //    "\rTperi: " + exoplanet.Tperi + "(" + exoplanet.TperiErrorMin + " " + exoplanet.TperiErrorMax + ")" +
                //    "\rDetection Type: " + exoplanet.DetectionType +
                //    "\rMolecules: " + exoplanet.Molecules
                //);
                }
            }

        private void ExoplanentListView_KeyDown ( object sender, EventArgs e )
            {
            if ( m_exoplanetListView.SelectedItems.Count == 1 )
                {
                displayAllDetails ( ( CExoplanet )m_exoplanetListView.SelectedItems[0].Tag );
                m_exoplanetListView.SelectedItems[0].Selected = true;
                }
            }

        private void ExoplanentListView_KeyUp ( object sender, EventArgs e )
            {
            if ( m_exoplanetListView.SelectedItems.Count == 1 )
                {
                displayAllDetails ( ( CExoplanet )m_exoplanetListView.SelectedItems[0].Tag );
                m_exoplanetListView.SelectedItems[0].Selected = true;
                }
            }

        private void displayAllDetails ( CExoplanet exoplanet )
            {
            if ( m_exoplanetDetails == null )
                m_exoplanetDetails = new ExoplanetDetails ( this );

            m_exoplanetDetails.DisplayDetails ( exoplanet );
            m_exoplanetDetails.Show ( );
            m_exoplanetDetails.BringToFront ( );
            }

        private void open_Click ( object sender, System.EventArgs e )
            {
            OpenFileDialog openFileDialog = new OpenFileDialog ( );

            openFileDialog.InitialDirectory = "c:\\ProgramData\\Exoplanet Library\\";
            openFileDialog.Filter = "xml files (*.xml)|*.xml|csv files (*.csv)|*.csv|vot files (*.vot)|*.vot|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if ( openFileDialog.ShowDialog ( ) == DialogResult.OK )
                {
                try
                    {
                    if ( openFileDialog.OpenFile ( ) != null )
                        {
                        string fileName = openFileDialog.FileName.ToLower ( );

                        if ( fileName.EndsWith ( ".csv" ) )
                            {
                            ReadCSV.Read ( openFileDialog.FileName );
                            m_xmlFileName = openFileDialog.FileName.Replace ( ".csv", ".xml" );
                            }
                        else if ( fileName.EndsWith ( ".txt" ) )
                            {
                            ReadCSV.Read ( openFileDialog.FileName );
                            m_xmlFileName = openFileDialog.FileName.Replace ( ".txt", ".xml" );
                            }
                        else if ( fileName.EndsWith ( ".vot" ) )
                            {
                            ReadVOT.Read ( openFileDialog.FileName );
                            m_xmlFileName = openFileDialog.FileName.Replace ( ".vot", ".xml" );
                            }
                        else if ( fileName.EndsWith ( ".xml" ) )
                            {
                            m_xmlFileName = openFileDialog.FileName;
                            }

                        UpdateExoplanetListView ( );
                        }
                    }
                catch ( Exception ex )
                    {
                    MessageBox.Show ( "Error: " + ex.Message );
                    }
                }
            }

        private void exit_Click ( object sender, System.EventArgs e )
            {
            Close ( );
            }

#if not_used
        private void openXML_Click ( object sender, System.EventArgs e )
            {
            OpenFileDialog openFileDialog = new OpenFileDialog ( );

            openFileDialog.InitialDirectory = "c:\\ProgramData\\Exoplanet Library\\";
            openFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if ( openFileDialog.ShowDialog ( ) == DialogResult.OK )
                {
                try
                    {
                    if ( openFileDialog.OpenFile ( ) != null )
                        {
                        m_xmlFileName = openFileDialog.FileName;
                        UpdateExoplanetListView ( );
                        }
                    }
                catch ( Exception ex )
                    {
                    MessageBox.Show ( "Error: Could not read file from disk. Original error: " + ex.Message );
                    }
                }
            }

        private void openCSV_Click ( object sender, System.EventArgs e )
            {
            OpenFileDialog openFileDialog = new OpenFileDialog ( );

            openFileDialog.InitialDirectory = "c:\\ProgramData\\Exoplanet Library\\";
            openFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if ( openFileDialog.ShowDialog ( ) == DialogResult.OK )
                {
                try
                    {
                    if ( openFileDialog.OpenFile ( ) != null )
                        {
                        WriteXML.Read ( openFileDialog.FileName );
                        m_xmlFileName = openFileDialog.FileName.Replace ( ".csv", ".xml" );
                        UpdateExoplanetListView ( );
                        }
                    }
                catch ( Exception ex )
                    {
                    MessageBox.Show ( "Error: Could not read file from disk. Original error: " + ex.Message );
                    }
                }
            }
#endif
        private void saveAs_Click ( object sender, System.EventArgs e )
            {
            SaveFileDialog saveFileDialog = new SaveFileDialog ( );

            saveFileDialog.InitialDirectory = "c:\\ProgramData\\Exoplanet Library\\";
            saveFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if ( saveFileDialog.ShowDialog ( ) == DialogResult.OK )
                {
                try
                    {
                    Stream stream = null;

                    if ( ( stream = saveFileDialog.OpenFile ( ) ) != null )
                        {
                        stream.Close ( );
                        WriteCSV.Write ( saveFileDialog.FileName, m_exoplanets );
                        }
                    }
                catch ( Exception ex )
                    {
                    MessageBox.Show ( "Error: " + ex.Message );
                    }
                }
            }

        private void about_Click ( object sender, System.EventArgs e )
            {
            m_about = new AboutBox ( );
            m_about.ShowDialog ( );     // modal
            }

        public void ExoplanetDetailsClosed ( )
            {
            m_exoplanetDetails = null;
            }
        }
    }
