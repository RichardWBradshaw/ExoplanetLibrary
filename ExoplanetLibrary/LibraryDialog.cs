using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace ExoplanetLibrary
    {
    public partial class LibraryDialog : Form
        {
        public LibraryDialog ()
            {
            InitializeComponent ();

            ReadLastUsedSettings ();

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

        private string XmlFileName_ = "";
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

        private CheckState AddPlanetDetails_ = CheckState.Unchecked;
        public CheckState AddPlanetDetails
            {
            get { return AddPlanetDetails_; }
            set { AddPlanetDetails_ = value; }
            }

        private CheckState AddStarDetails_ = CheckState.Checked;
        public CheckState AddStarDetails
            {
            get { return AddStarDetails_; }
            set { AddStarDetails_ = value; }
            }

        private Filters Filter_ = null;
        public Filters Filter
            {
            get { return Filter_; }
            set { Filter_ = value; }
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

            AddItemsToListView (ExoplanetListView, true, true);
            ExoplanetListView.ColumnClick += new ColumnClickEventHandler (ExoplanetListView_ColumnClick);
            ExoplanetListView.Click += new EventHandler (ExoplanetListView_Click);
            Controls.Add (ExoplanetListView);
            }

        private void UpdateExoplanetListView (bool rebuildArray)
            {
            Cursor.Current = Cursors.WaitCursor;

            for (int index = ExoplanetListView.Items.Count - 1; index >= 0; --index)
                ExoplanetListView.Items.RemoveAt (index);

            AddItemsToListView (ExoplanetListView, false, rebuildArray);
            Cursor.Current = Cursors.Default;
            }

        private void AddColumnsToListView (ListView listView)
            {
            listView.Columns.Add ("Name", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("M (Mjup)", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("R (Rjup)", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("Period (day)", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("Semi-Major Axis (AU)", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("Eccentricity", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("Angular Distance", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("Inclination (deg)", -2, HorizontalAlignment.Left);

            if (AddPlanetDetails == CheckState.Checked)
                {
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
            listView.Columns.Add ("Detection Type", -2, HorizontalAlignment.Left);

            if (AddPlanetDetails == CheckState.Checked)
                {
                listView.Columns.Add ("Omega (deg)", -2, HorizontalAlignment.Left);
                listView.Columns.Add ("Molecules", -2, HorizontalAlignment.Left);
                }

            listView.Columns.Add ("Star Name", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("RA", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("Declination", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("SPType", -2, HorizontalAlignment.Left);

            if (AddStarDetails == CheckState.Checked)
                {
                listView.Columns.Add ("Age", -2, HorizontalAlignment.Left);
                listView.Columns.Add ("Distance", -2, HorizontalAlignment.Left);
                listView.Columns.Add ("M (Msun)", -2, HorizontalAlignment.Left);
                listView.Columns.Add ("R (Rsun)", -2, HorizontalAlignment.Left);
                }
            }

        private void AddItemsToListView (ListView listView, bool addColumns, bool rebuildArray)
            {
            if (rebuildArray)
                {
                if (ExoplanetsArray != null)
                    ExoplanetsArray.Clear ();

                ExoplanetsArray = ReadXML.Read (XmlFileName);
                }
            else
                {
                if (ExoplanetListView != null)
                    for (int index = ExoplanetListView.Items.Count - 1; index >= 0; --index)
                        ExoplanetListView.Items.RemoveAt (index);
                }

            if (addColumns)
                AddColumnsToListView (listView);

            if (ExoplanetsArray != null)
                foreach (Exoplanet exoplanet in ExoplanetsArray)
                    {
                    if (!Settings.MatchesFilter (exoplanet, Filter))
                        continue;

                    ListViewItem item = new ListViewItem (exoplanet.Name, 0);

                    item.SubItems.Add (exoplanet.Mass);
                    item.SubItems.Add (exoplanet.Radius);
                    item.SubItems.Add (exoplanet.OrbitalPeriod);
                    item.SubItems.Add (exoplanet.SemiMajorAxis);
                    item.SubItems.Add (exoplanet.Eccentricity);
                    item.SubItems.Add (exoplanet.AngularDistance);
                    item.SubItems.Add (exoplanet.Inclination);

                    if (AddPlanetDetails == CheckState.Checked)
                        {
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
                    item.SubItems.Add (exoplanet.DetectionType);

                    if (AddPlanetDetails == CheckState.Checked)
                        {
                        item.SubItems.Add (exoplanet.Omega);
                        item.SubItems.Add (exoplanet.Molecules);
                        }

                    item.SubItems.Add (exoplanet.Star.Name);
                    item.SubItems.Add (Helper.FormatHMS (exoplanet.Star.RightAccession));
                    item.SubItems.Add (Helper.FormatHMS (exoplanet.Star.Declination));
                    item.SubItems.Add (exoplanet.Star.Property.SPType);

                    if (AddStarDetails == CheckState.Checked)
                        {
                        item.SubItems.Add (exoplanet.Star.Property.Age);
                        item.SubItems.Add (exoplanet.Star.Property.Distance);
                        item.SubItems.Add (exoplanet.Star.Property.Mass);
                        item.SubItems.Add (exoplanet.Star.Property.Radius);
                        }

                    item.Tag = exoplanet;
                    listView.Items.Add (item);
                    }
            }

        private void ExoplanetListView_ColumnClick (object sender, ColumnClickEventArgs e)
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

        private void ExoplanetListView_Click (object sender, EventArgs e)
            {
            if (ExoplanetListView.SelectedItems.Count == 1)
                {
                Exoplanet exoplanet = ( Exoplanet )ExoplanetListView.SelectedItems [0].Tag;

                displayAllDetails (exoplanet);
                }
            }

        private void ExoplanetListView_DoubleClick (object sender, EventArgs e)
            {
            if (ExoplanetListView.SelectedItems.Count == 1)
                {
                ArrayList types = Helper.NumberOfStarTypes (ExoplanetsArray);
                string StarTypesString = null;

                for (int index = 0; index < types.Count; ++index)
                    {
                    StarTypes type = types [index] as StarTypes;

                    StarTypesString += "\rNumber of Type " + type.Name + "   " + type.Count.ToString ();
                    }

                MessageBox.Show ("Number of Exoplanets " + ExoplanetsArray.Count + "\rMulti-Planet Stars " + Helper.NumberOfMultiPlanetStars (ExoplanetsArray) + StarTypesString);
                }
            }

        private void displayAllDetails (Exoplanet exoplanet)
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

                        Cursor.Current = Cursors.WaitCursor;

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

                        UpdateExoplanetListView (true);

                        Cursor.Current = Cursors.Default;
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
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog () == DialogResult.OK)
                {
                try
                    {
                    Stream stream = null;

                    if (( stream = saveFileDialog.OpenFile () ) != null)
                        {
                        stream.Close ();
                        string fileName = saveFileDialog.FileName;

                        if (!fileName.EndsWith (".csv"))
                            fileName = fileName + ".csv";

                        WriteCSV.Write (fileName, ExoplanetsArray, Constant.Version1);
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

        private void LibraryDialog_FormClosing ( object sender, FormClosingEventArgs e )
            {
            Settings.WriteFileName (XmlFileName);
            Settings.WriteFilter (Filter);
            }

        public void ExoplanetDetailsClosed ()
            {
            ExoplanetDetails = null;
            }

        private void MenuCheckBox_CheckStateChanged (object sender, EventArgs e)
            {
            if (sender == typeOMenuItem)
                {
                Filter.TypeOEnabled = typeOMenuItem.CheckState;
                }
            else if (sender == typeBMenuItem)
                {
                Filter.TypeBEnabled = typeBMenuItem.CheckState;
                }
            else if (sender == typeAMenuItem)
                {
                Filter.TypeAEnabled = typeAMenuItem.CheckState;
                }
            else if (sender == typeFMenuItem)
                {
                Filter.TypeFEnabled = typeFMenuItem.CheckState;
                }
            else if (sender == typeGMenuItem)
                {
                Filter.TypeGEnabled = typeGMenuItem.CheckState;
                }
            else if (sender == typeKMenuItem)
                {
                Filter.TypeKEnabled = typeKMenuItem.CheckState;
                }
            else if (sender == typeMMenuItem)
                {
                Filter.TypeMEnabled = typeMMenuItem.CheckState;
                }
            else if (sender == unknownStarTypeMenuItem)
                {
                Filter.UnknownStarEnabled = unknownStarTypeMenuItem.CheckState;
                }
            ///
            else if (sender == primaryTransitMenuItem)
                {
                Filter.PrimaryTransitEnabled = primaryTransitMenuItem.CheckState;
                }
            else if (sender == radialVelocityMenuItem)
                {
                Filter.RadialVelocityEnabled = radialVelocityMenuItem.CheckState;
                }
            else if (sender == microlensingMenuItem)
                {
                Filter.MicrolensingEnabled = microlensingMenuItem.CheckState;
                }
            else if (sender == imagingMenuItem)
                {
                Filter.ImagingEnabled = imagingMenuItem.CheckState;
                }
            else if (sender == pulsarMenuItem)
                {
                Filter.PulsarEnabled = pulsarMenuItem.CheckState;
                }
            else if (sender == astrometryMenuItem)
                {
                Filter.AstrometryEnabled = astrometryMenuItem.CheckState;
                }
            else if (sender == tTVMenuItem)
                {
                Filter.TTVEnabled = tTVMenuItem.CheckState;
                }
            else if (sender == allDetectionMethodsMenuItem)
                {
                Filter.UnknownDetectionEnabled = allDetectionMethodsMenuItem.CheckState;
                }

            AddItemsToListView (ExoplanetListView, false, false);
            }

        private void MenuCheckBox_Click (object sender, EventArgs e)
            {
            if (sender == typeOMenuItem)
                {
                typeOMenuItem.Checked = typeOMenuItem.CheckState == CheckState.Checked ? false : true;
                }
            else if (sender == typeBMenuItem)
                {
                typeBMenuItem.Checked = typeBMenuItem.CheckState == CheckState.Checked ? false : true;
                }
            else if (sender == typeAMenuItem)
                {
                typeAMenuItem.Checked = typeAMenuItem.CheckState == CheckState.Checked ? false : true;
                }
            else if (sender == typeFMenuItem)
                {
                typeFMenuItem.Checked = typeFMenuItem.CheckState == CheckState.Checked ? false : true;
                }
            else if (sender == typeGMenuItem)
                {
                typeGMenuItem.Checked = typeGMenuItem.CheckState == CheckState.Checked ? false : true;
                }
            else if (sender == typeKMenuItem)
                {
                typeKMenuItem.Checked = typeKMenuItem.CheckState == CheckState.Checked ? false : true;
                }
            else if (sender == typeMMenuItem)
                {
                typeMMenuItem.Checked = typeMMenuItem.CheckState == CheckState.Checked ? false : true;
                }
            else if (sender == unknownStarTypeMenuItem)
                {
                unknownStarTypeMenuItem.Checked = unknownStarTypeMenuItem.CheckState == CheckState.Checked ? false : true;
                }
            ///
            else if (sender == primaryTransitMenuItem)
                {
                primaryTransitMenuItem.Checked = primaryTransitMenuItem.CheckState == CheckState.Checked ? false : true;
                }
            else if (sender == radialVelocityMenuItem)
                {
                radialVelocityMenuItem.Checked = radialVelocityMenuItem.CheckState == CheckState.Checked ? false : true;
                }
            else if (sender == microlensingMenuItem)
                {
                microlensingMenuItem.Checked = microlensingMenuItem.CheckState == CheckState.Checked ? false : true;
                }
            else if (sender == imagingMenuItem)
                {
                imagingMenuItem.Checked = imagingMenuItem.CheckState == CheckState.Checked ? false : true;
                }
            else if (sender == pulsarMenuItem)
                {
                pulsarMenuItem.Checked = pulsarMenuItem.CheckState == CheckState.Checked ? false : true;
                }
            else if (sender == astrometryMenuItem)
                {
                astrometryMenuItem.Checked = astrometryMenuItem.CheckState == CheckState.Checked ? false : true;
                }
            else if (sender == tTVMenuItem)
                {
                tTVMenuItem.Checked = tTVMenuItem.CheckState == CheckState.Checked ? false : true;
                }
            else if (sender == allDetectionMethodsMenuItem)
                {
                allDetectionMethodsMenuItem.Checked = allDetectionMethodsMenuItem.CheckState == CheckState.Checked ? false : true;
                }
            }

        private void ReadLastUsedSettings ()
            {
            XmlFileName = Settings.ReadFileName ();

            if (( Filter = Settings.ReadFilter () ) != null)
                {
                typeOMenuItem.CheckState = Filter.TypeOEnabled;
                typeBMenuItem.CheckState = Filter.TypeBEnabled;
                typeAMenuItem.CheckState = Filter.TypeAEnabled;
                typeFMenuItem.CheckState = Filter.TypeFEnabled;
                typeGMenuItem.CheckState = Filter.TypeGEnabled;
                typeKMenuItem.CheckState = Filter.TypeKEnabled;
                typeMMenuItem.CheckState = Filter.TypeMEnabled;
                unknownStarTypeMenuItem.CheckState = Filter.UnknownStarEnabled;

                primaryTransitMenuItem.CheckState = Filter.PrimaryTransitEnabled;
                radialVelocityMenuItem.CheckState = Filter.RadialVelocityEnabled;
                microlensingMenuItem.CheckState = Filter.MicrolensingEnabled;
                imagingMenuItem.CheckState = Filter.ImagingEnabled;
                pulsarMenuItem.CheckState = Filter.PulsarEnabled;
                astrometryMenuItem.CheckState = Filter.AstrometryEnabled;
                tTVMenuItem.CheckState = Filter.TTVEnabled;
                allDetectionMethodsMenuItem.CheckState = Filter.UnknownDetectionEnabled;
                }
            }
        }
    }
