using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace ExoplanetLibrary
    {
    public partial class LibraryDialog : Form
        {
        private string XmlFileName_ = "C:\\ProgramData\\Exoplanet Library\\kepler.xml";
        public string XmlFileName
            {
            get { return XmlFileName_; }
            set { XmlFileName_ = value; }
            }

        private ExoplanetDetails ExoplanetDetails_ = null;
        public ExoplanetDetails ExoplanetDetails
            {
            get { return ExoplanetDetails_; }
            set { ExoplanetDetails_ = value; }
            }

        private AboutBox About_ = null;
        public AboutBox About
            {
            get { return About_; }
            set { About_ = value; }
            }

        private ListView ExoplanetListView_ = null;
        public ListView ExoplanetListView
            {
            get { return ExoplanetListView_; }
            set { ExoplanetListView_ = value; }
            }

        private ArrayList ExoplanetsArray_ = null;
        public ArrayList ExoplanetsArray
            {
            get { return ExoplanetsArray_; }
            set { ExoplanetsArray_ = value; }
            }

        private ListViewColumnSorter LvwColumnSorter_ = null;
        public ListViewColumnSorter LvwColumnSorter
            {
            get { return LvwColumnSorter_; }
            set { LvwColumnSorter_ = value; }
            }

        private bool AddPlanetDetails_ = false;
        public bool AddPlanetDetails
            {
            get { return AddPlanetDetails_; }
            set { AddPlanetDetails_ = value; }
            }

        private bool AddStarDetails_ = true;
        public bool AddStarDetails
            {
            get { return AddStarDetails_; }
            set { AddStarDetails_ = value; }
            }

        public LibraryDialog ()
            {
            InitializeComponent ();

            CreateExoplanetListView ();
            LvwColumnSorter = new ListViewColumnSorter ();
            ExoplanetListView.ListViewItemSorter = LvwColumnSorter;

            openMenuItem.Click += new EventHandler (open_Click);
            exitMenuItem.Click += new EventHandler (exit_Click);
            saveAsMenuItem.Click += new EventHandler (saveAs_Click);

            aboutMenuItem.Click += new EventHandler (about_Click);

            ResizeBegin += new System.EventHandler (MyResizeBegin);
            ResizeEnd += new System.EventHandler (MyResizeEnd);
            SizeChanged += new System.EventHandler (MyResize);
            }

        private void MyResizeBegin (object sender, System.EventArgs e)
            {
            }

        private void MyResizeEnd (object sender, System.EventArgs e)
            {
            }

        private void MyResize (object sender, System.EventArgs e)
            {
            Control control = ( Control )sender;

            if (ExoplanetListView != null)
                {
                ExoplanetListView.Height = Size.Height - ( 60 + 24 );
                ExoplanetListView.Width = Size.Width - 40;
                }
            }

        private void CreateExoplanetListView ()
            {
            ExoplanetListView = new ListView ();
            ExoplanetListView.Bounds = new Rectangle (new Point (10, 24), new Size (Width - 40, Height - ( 60 + 24 )));

            ExoplanetListView.View = View.Details;
            ExoplanetListView.LabelEdit = false;
            ExoplanetListView.AllowColumnReorder = true;
            ExoplanetListView.CheckBoxes = false;
            ExoplanetListView.FullRowSelect = true;
            ExoplanetListView.GridLines = true;
            ExoplanetListView.Sorting = SortOrder.Ascending;

            AddItemsToListView (ExoplanetListView, true);
            ExoplanetListView.ColumnClick += new ColumnClickEventHandler (ExoplanettListView_ColumnClick);
            ExoplanetListView.Click += new EventHandler (ExoplanettListView_Click);
            Controls.Add (ExoplanetListView);
            }

        private void UpdateExoplanetListView ()
            {
            for (int index = ExoplanetListView.Items.Count - 1; index >= 0; --index)
                ExoplanetListView.Items.RemoveAt (index);

            AddItemsToListView (ExoplanetListView, false);
            }

        private void AddItemsToListView (ListView listView, bool addColumns)
            {
            if (ExoplanetsArray != null)
                ExoplanetsArray.Clear ();

            ExoplanetsArray = null;
            ReadXML.Read (XmlFileName, ref ExoplanetsArray_);

            if (addColumns)
                {
                listView.Columns.Add ("Name", -2, HorizontalAlignment.Left);
                listView.Columns.Add ("M (Mjup)", -2, HorizontalAlignment.Left);
                listView.Columns.Add ("R (Rjup)", -2, HorizontalAlignment.Left);
                listView.Columns.Add ("Period (day)", -2, HorizontalAlignment.Left);
                listView.Columns.Add ("Semi-Major Axis (AU)", -2, HorizontalAlignment.Left);
                listView.Columns.Add ("Eccentricity", -2, HorizontalAlignment.Left);
                listView.Columns.Add ("Angular Distance", -2, HorizontalAlignment.Left);

                if (AddPlanetDetails)
                    {
                    listView.Columns.Add ("Inclination (deg)", -2, HorizontalAlignment.Left);
                    listView.Columns.Add ("T0 (JD)", -2, HorizontalAlignment.Left);
                    listView.Columns.Add ("T0-sec (JD)", -2, HorizontalAlignment.Left);
                    listView.Columns.Add ("Lambda Angle (deg)", -2, HorizontalAlignment.Left);
                    listView.Columns.Add ("Tvr (JD)", -2, HorizontalAlignment.Left);
                    listView.Columns.Add ("Tcalc. (K)", -2, HorizontalAlignment.Left);
                    listView.Columns.Add ("Tmeas. (K)", -2, HorizontalAlignment.Left);
                    listView.Columns.Add ("Hot pt (deg)", -2, HorizontalAlignment.Left);
                    listView.Columns.Add ("Log(g)", -2, HorizontalAlignment.Left);
                    listView.Columns.Add ("Pub. Status", -2, HorizontalAlignment.Left);
                    }

                listView.Columns.Add ("Discovered", -2, HorizontalAlignment.Left);
                listView.Columns.Add ("Updated", -2, HorizontalAlignment.Left);

                if (AddPlanetDetails)
                    {
                    listView.Columns.Add ("Omega (deg)", -2, HorizontalAlignment.Left);
                    listView.Columns.Add ("Detection Type", -2, HorizontalAlignment.Left);
                    listView.Columns.Add ("Molecules", -2, HorizontalAlignment.Left);
                    }

                listView.Columns.Add ("Star Name", -2, HorizontalAlignment.Left);
                listView.Columns.Add ("RA", -2, HorizontalAlignment.Left);
                listView.Columns.Add ("Declination", -2, HorizontalAlignment.Left);
                listView.Columns.Add ("SPType", -2, HorizontalAlignment.Left);

                if (AddStarDetails)
                    {

                    listView.Columns.Add ("Age", -2, HorizontalAlignment.Left);
                    listView.Columns.Add ("Distance", -2, HorizontalAlignment.Left);
                    listView.Columns.Add ("M (Msun)", -2, HorizontalAlignment.Left);
                    listView.Columns.Add ("R (Rsun)", -2, HorizontalAlignment.Left);
                    }
                }
#if walk_enumerator
            IEnumerator ExoplanettEnumerator = m_exoplanets.GetEnumerator ( );
            ExoplanettEnumerator.Reset();

            while ( ExoplanettEnumerator.MoveNext ( ) )
                {
                CExoplanet exoplanet = ExoplanettEnumerator.Current as CExoplanet;
                }
#else
            foreach (CExoplanet exoplanet in ExoplanetsArray)
                {
                ListViewItem item = new ListViewItem (exoplanet.Name, 0);

                item.SubItems.Add (exoplanet.Mass);
                item.SubItems.Add (exoplanet.Radius);
                item.SubItems.Add (exoplanet.OrbitalPeriod);
                item.SubItems.Add (exoplanet.SemiMajorAxis);
                item.SubItems.Add (exoplanet.Eccentricity);
                item.SubItems.Add (exoplanet.AngularDistance);

                if (AddPlanetDetails)
                    {
                    item.SubItems.Add (exoplanet.Inclination);
                    item.SubItems.Add (exoplanet.TzeroTr);
                    item.SubItems.Add (exoplanet.TzeroTrSec);
                    item.SubItems.Add (exoplanet.LambdaAngle);
                    item.SubItems.Add (exoplanet.TzeroVr);
                    item.SubItems.Add (exoplanet.TemperatureCalculated);
                    item.SubItems.Add (exoplanet.TemperatureMeasured);
                    item.SubItems.Add (exoplanet.TemperatureHotPointLo);
                    item.SubItems.Add (exoplanet.LogG);
                    item.SubItems.Add (exoplanet.Status);
                    }

                item.SubItems.Add (exoplanet.Discovered);
                item.SubItems.Add (exoplanet.Updated);

                if (AddPlanetDetails)
                    {
                    item.SubItems.Add (exoplanet.Omega);
                    item.SubItems.Add (exoplanet.DetectionType);
                    item.SubItems.Add (exoplanet.Molecules);
                    }

                item.SubItems.Add (exoplanet.Star.Name);
                item.SubItems.Add (Helper.FormatHMS (exoplanet.Star.RightAccession));
                item.SubItems.Add (Helper.FormatHMS (exoplanet.Star.Declination));
                item.SubItems.Add (exoplanet.Star.Properties.SPType);

                if (AddStarDetails)
                    {
                    item.SubItems.Add (exoplanet.Star.Properties.Age);
                    item.SubItems.Add (exoplanet.Star.Properties.Distance);
                    item.SubItems.Add (exoplanet.Star.Properties.Mass);
                    item.SubItems.Add (exoplanet.Star.Properties.Radius);
                    }

                item.Tag = exoplanet;
                listView.Items.Add (item);
                }
#endif
            }

        private void ExoplanettListView_ColumnClick (object sender, ColumnClickEventArgs e)
            {
            if (e.Column == LvwColumnSorter.SortColumn)
                {
                if (LvwColumnSorter.Order == SortOrder.Ascending)
                    LvwColumnSorter.Order = SortOrder.Descending;
                else
                    LvwColumnSorter.Order = SortOrder.Ascending;
                }
            else
                {
                LvwColumnSorter.SortColumn = e.Column;
                LvwColumnSorter.Order = SortOrder.Ascending;
                }

            ExoplanetListView.Sort ();
            }

        private void ExoplanettListView_Click (object sender, EventArgs e)
            {
            if (ExoplanetListView.SelectedItems.Count == 1)
                {
                CExoplanet exoplanet = ( CExoplanet )ExoplanetListView.SelectedItems [0].Tag;

                displayAllDetails (exoplanet);
                }
            }

        private void ExoplanettListView_DoubleClick (object sender, EventArgs e)
            {
            if (ExoplanetListView.SelectedItems.Count == 1)
                {
                ArrayList types = null;
                string StarTypesString = null;

                Helper.NumberOfStarTypes (ExoplanetsArray, ref types);

                for (int index = 0; index < types.Count; ++index )
                    {
                    StarTypes type = types[index] as StarTypes;

                    StarTypesString += "\rNumber of Type " +  type.Name + "   " + type.Count.ToString();
                    }

                    MessageBox.Show ("Number of Exoplanets " + ExoplanetsArray.Count + "\rMulti-Planet Stars " + Helper.NumberOfMultiPlanetStars (ExoplanetsArray) + StarTypesString );
                }
            }

        private void displayAllDetails (CExoplanet exoplanet)
            {
            if (ExoplanetDetails == null)
                ExoplanetDetails = new ExoplanetDetails (this);

            ExoplanetDetails.DisplayDetails (exoplanet);
            ExoplanetDetails.Show ();
            ExoplanetDetails.BringToFront ();
            }

        private void open_Click (object sender, System.EventArgs e)
            {
            OpenFileDialog openFileDialog = new OpenFileDialog ();

            openFileDialog.InitialDirectory = "c:\\ProgramData\\Exoplanet Library\\";
            openFileDialog.Filter = "xml files (*.xml)|*.xml|csv files (*.csv)|*.csv|vot files (*.vot)|*.vot|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog () == DialogResult.OK)
                {
                try
                    {
                    if (openFileDialog.OpenFile () != null)
                        {
                        string fileName = openFileDialog.FileName.ToLower ();

                        if (fileName.EndsWith (".csv"))
                            {
                            ReadCSV.Read (openFileDialog.FileName);
                            XmlFileName = openFileDialog.FileName.Replace (".csv", ".xml");
                            }
                        else if (fileName.EndsWith (".txt"))
                            {
                            ReadCSV.Read (openFileDialog.FileName);
                            XmlFileName = openFileDialog.FileName.Replace (".txt", ".xml");
                            }
                        else if (fileName.EndsWith (".vot"))
                            {
                            ReadVOT.Read (openFileDialog.FileName);
                            XmlFileName = openFileDialog.FileName.Replace (".vot", ".xml");
                            }
                        else if (fileName.EndsWith (".xml"))
                            {
                            XmlFileName = openFileDialog.FileName;
                            }

                        UpdateExoplanetListView ();
                        }
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show ("Error: " + ex.Message);
                    }
                }
            }

        private void exit_Click (object sender, System.EventArgs e)
            {
            Close ();
            }

        private void saveAs_Click (object sender, System.EventArgs e)
            {
            SaveFileDialog saveFileDialog = new SaveFileDialog ();

            saveFileDialog.InitialDirectory = "c:\\ProgramData\\Exoplanet Library\\";
            saveFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog () == DialogResult.OK)
                {
                try
                    {
                    Stream stream = null;

                    if (( stream = saveFileDialog.OpenFile () ) != null)
                        {
                        stream.Close ();
                        WriteCSV.Write (saveFileDialog.FileName, ExoplanetsArray);
                        }
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show ("Error: " + ex.Message);
                    }
                }
            }

        private void about_Click (object sender, System.EventArgs e)
            {
            About = new AboutBox ();
            About.ShowDialog ();     // modal
            }

        public void ExoplanetDetailsClosed ()
            {
            ExoplanetDetails = null;
            }
        }
    }
