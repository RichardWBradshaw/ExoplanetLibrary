﻿using System;
using System.Drawing;
using System.Windows.Forms;
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

            ResizeBegin += new EventHandler (LibraryResizeBegin);
            ResizeEnd += new EventHandler (LibraryResizeEnd);
            SizeChanged += new EventHandler (LibraryResize);
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

        private VisualizationDialog Visualization_ = null;
        public VisualizationDialog Visualization
            {
            get { return Visualization_; }
            set { Visualization_ = value; }
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

        private ListViewColumnSorter LvwColumnSorter_ = null;
        public ListViewColumnSorter LvwColumnSorter
            {
            get { return LvwColumnSorter_; }
            set { LvwColumnSorter_ = value; }
            }

        private Filters Filter_ = null;
        public Filters Filter
            {
            get { return Filter_; }
            set { Filter_ = value; }
            }

        private void LibraryResizeBegin (object sender, System.EventArgs e)
            {
            }

        private void LibraryResizeEnd (object sender, System.EventArgs e)
            {
            }

        private void LibraryResize (object sender, System.EventArgs e)
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
            ExoplanetListView.PreviewKeyDown += new PreviewKeyDownEventHandler (ExoplanetListView_PreviewKey);
            ExoplanetListView.KeyDown += new KeyEventHandler (ExoplanetListView_Key);
            ExoplanetListView.KeyUp += new KeyEventHandler (ExoplanetListView_Key);
            Controls.Add (ExoplanetListView);
            }

        //
        // Down, Up, PageDown and PageUp are special, hence ExoplanetListView_PreviewKey and ExoplanetListView_Key
        //

        private void ExoplanetListView_PreviewKey (object sender, PreviewKeyDownEventArgs e)
            {
            switch (e.KeyCode)
                {
                case Keys.Down:
                case Keys.Up:
                case Keys.PageDown:
                case Keys.PageUp:
                case Keys.Home:
                case Keys.End:
                    e.IsInputKey = true;
                    break;
                }
            }

        void ExoplanetListView_Key (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case Keys.Down:
                case Keys.Up:
                case Keys.PageDown:
                case Keys.PageUp:
                case Keys.Home:
                case Keys.End:
                    if (ExoplanetListView.SelectedItems.Count == 1)
                        {
                        Exoplanet exoplanet = ( Exoplanet )ExoplanetListView.SelectedItems [0].Tag;

                        displayAllDetails (exoplanet);
                        Focus ();
                        }
                    break;
                }
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
            listView.Columns.Add ("Detection Type", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("Mass (Mjup)", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("Radius (Rjup)", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("Orbital Period (day)", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("Semi-Major Axis (AU)", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("Eccentricity", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("Angular Distance", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("Inclination (deg)", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("Omega (deg)", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("Velocity Semiamplitude", -2, HorizontalAlignment.Left);

            listView.Columns.Add ("Year of Discovered", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("Last Updated", -2, HorizontalAlignment.Left);

            listView.Columns.Add ("Star Name", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("Spectral Type", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("Mass (Msun)", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("Radius (Rsun)", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("Distance (pc)", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("Age (Gy)", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("Right Accession", -2, HorizontalAlignment.Left);
            listView.Columns.Add ("Declination", -2, HorizontalAlignment.Left);
            }

        private void AddItemsToListView (ListView listView, bool addColumns, bool rebuildArray)
            {
            if (rebuildArray)
                {
                if (Exoplanets.ExoplanetsArray != null)
                    Exoplanets.ExoplanetsArray.Clear ();

                Exoplanets.ExoplanetsArray = ReadXML.Read (XmlFileName);
                }
            else
                {
                if (ExoplanetListView != null)
                    for (int index = ExoplanetListView.Items.Count - 1; index >= 0; --index)
                        ExoplanetListView.Items.RemoveAt (index);
                }

            if (addColumns)
                AddColumnsToListView (listView);

            if (Exoplanets.ExoplanetsArray != null)
                foreach (Exoplanet exoplanet in Exoplanets.ExoplanetsArray)
                    {
                    if (!Settings.MatchesFilter (exoplanet, Filter))
                        continue;

                    ListViewItem item = new ListViewItem (exoplanet.Name, 0);

                    item.SubItems.Add (Helper.Format (exoplanet.DetectionType));
                    item.SubItems.Add (Helper.Format (exoplanet.Mass));
                    item.SubItems.Add (Helper.Format (exoplanet.Radius));
                    item.SubItems.Add (Helper.Format (exoplanet.OrbitalPeriod));
                    item.SubItems.Add (Helper.Format (exoplanet.SemiMajorAxis));
                    item.SubItems.Add (Helper.Format (exoplanet.Eccentricity));
                    item.SubItems.Add (Helper.Format (exoplanet.AngularDistance));
                    item.SubItems.Add (Helper.Format (exoplanet.Inclination));
                    item.SubItems.Add (Helper.Format (exoplanet.Omega));
                    item.SubItems.Add (Helper.Format (exoplanet.VelocitySemiamplitude));

                    item.SubItems.Add (Helper.Format (exoplanet.Discovered));
                    item.SubItems.Add (Helper.Format (exoplanet.Updated));

                    item.SubItems.Add (Helper.Format (exoplanet.Star.Name));
                    item.SubItems.Add (Helper.Format (exoplanet.Star.Property.SPType));
                    item.SubItems.Add (Helper.Format (exoplanet.Star.Property.Mass));
                    item.SubItems.Add (Helper.Format (exoplanet.Star.Property.Radius));
                    item.SubItems.Add (Helper.Format (exoplanet.Star.Property.Distance));
                    item.SubItems.Add (Helper.Format (exoplanet.Star.Property.Age));
                    item.SubItems.Add (Helper.FormatHMS (exoplanet.Star.RightAccession));
                    item.SubItems.Add (Helper.FormatHMS (exoplanet.Star.Declination));

                    item.Tag = exoplanet;
                    listView.Items.Add (item);
                    }

            Text = "Exoplanet Library" + ( XmlFileName.Length > 0 ? " - " + XmlFileName : "" );
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
                Focus ();
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

            openFileDialog.InitialDirectory = Constant.ProgramDataFolder;
            openFileDialog.Filter = "xml files (*.xml)|*.xml|csv files (*.csv)|*.csv|vot files (*.vot)|*.vot|All files (*.*)|*.*";
            openFileDialog.FilterIndex = Settings.FilterIndex;
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
                        else if (fileName.EndsWith (".dat"))
                            {
                            ReadCSV.Read (openFileDialog.FileName);
                            XmlFileName = openFileDialog.FileName.Replace (".dat", ".xml");
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

                        if (Visualization != null)
                            Visualization.RefreshGraphics ();

                        if (ExoplanetDetails != null)
                            if (ExoplanetListView.SelectedItems.Count == 1)
                                {
                                Exoplanet exoplanet = ( Exoplanet )ExoplanetListView.SelectedItems [0].Tag;

                                displayAllDetails (exoplanet);
                                Focus ();
                                }
                            else
                                ExoplanetDetails.Close ();

                        Settings.FilterIndex = openFileDialog.FilterIndex;

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

            saveFileDialog.InitialDirectory = Constant.ProgramDataFolder;
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

                        WriteCSV.Write (fileName, Exoplanets.ExoplanetsArray, Constant.Version1);
                        }
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show ("Error: " + ex.Message);
                    }
                }
            }

        private void compare_Click (object sender, System.EventArgs e)
            {
            string xmlFileName = "";

            if (open (out xmlFileName) == 0)
                {
                System.Collections.ArrayList array2 = ReadXML.Read (xmlFileName);

                MessageBox.Show (Exoplanets.Compare (Exoplanets.ExoplanetsArray, array2), "Comparison " + xmlFileName);
                }
            }

        private int open (out string fileName)
            {
            OpenFileDialog openFileDialog = new OpenFileDialog ();

            openFileDialog.InitialDirectory = Constant.ProgramDataFolder;
            openFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            fileName = "";

            if (openFileDialog.ShowDialog () == DialogResult.OK)
                {
                try
                    {
                    if (openFileDialog.OpenFile () != null)
                        {
                        fileName = openFileDialog.FileName;
                        }
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show ("Error: " + ex.Message);
                    }
                }
            else
                return 1;

            return 0;
            }

        private void launchExoplanetEu_Click (object sender, System.EventArgs e)
            {
            string url = "http://exoplanet.eu";

            System.Diagnostics.Process.Start (url);
            Settings.WriteLastVisit (System.DateTime.Now);
            }

        private void launchExoplanetEuCatalog_Click (object sender, EventArgs e)
            {
            string url = "http://exoplanet.eu//catalog";

            System.Diagnostics.Process.Start (url);
            Settings.WriteLastVisit (System.DateTime.Now);
            }

        private void visualize_Click (object sender, System.EventArgs e)
            {
            if (Visualization == null)
                Visualization = new VisualizationDialog (this);

            Visualization.Show ();
            Visualization.BringToFront ();
            }

        private void about_Click (object sender, System.EventArgs e)
            {
            About = new AboutBox ();
            About.ShowDialog ();     // modal
            }

        private void LibraryDialog_FormClosing (object sender, FormClosingEventArgs e)
            {
            Settings.WriteFileName (XmlFileName);
            Settings.WriteFilter (Filter);
            }

        public void VisualizationClosed ()
            {
            Visualization = null;
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
