using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

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

            aboutMenuItem.Click += new EventHandler (about_Click);

            ResizeBegin += new EventHandler (LibraryResizeBegin);
            ResizeEnd += new EventHandler (LibraryResizeEnd);
            SizeChanged += new EventHandler (LibraryResize);
            }

        private string XmlFileName_ = string.Empty;
        public string XmlFileName
            {
            get { return XmlFileName_; }
            set { XmlFileName_ = value; }
            }

        private QueryDialog QueryDialog_ = null;
        public QueryDialog QueryDialog
            {
            get { return QueryDialog_; }
            set { QueryDialog_ = value; }
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

        private Queries Query_ = null;
        public Queries Query
            {
            get { return Query_; }
            set { Query_ = value; }
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
            ExoplanetListView.Sorting = SortOrder.None;

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
            if (listView != null)
                listView.BeginUpdate ();

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

            List<ListViewItem> items = new List<ListViewItem> ();

            if (Exoplanets.ExoplanetsArray != null)
                foreach (Exoplanet exoplanet in Exoplanets.ExoplanetsArray)
                    {
                    if (Queries.CurrentQueries != null)
                        if (!Queries.CurrentQueries.MatchesQuery (exoplanet))
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

                    items.Add (item);
                    }

            Text = "Exoplanet Library" + ( XmlFileName.Length > 0 ? " - " + XmlFileName : string.Empty );

            if (listView != null)
                {
                listView.Items.AddRange (items.ToArray ());
                listView.EndUpdate ();
                }
            }

        private void ExoplanetListView_ColumnClick (object sender, ColumnClickEventArgs e)
            {
            if (e.Column == LvwColumnSorter.ColumnToSort)
                {
                if (LvwColumnSorter.OrderOfSort == SortOrder.Ascending)
                    LvwColumnSorter.OrderOfSort = SortOrder.Descending;
                else
                    LvwColumnSorter.OrderOfSort = SortOrder.Ascending;
                }
            else
                {
                LvwColumnSorter.ColumnToSort = e.Column;
                LvwColumnSorter.OrderOfSort = SortOrder.Ascending;
                }

            LvwColumnSorter.IsAlphaNumeric = ( LvwColumnSorter.ColumnToSort == 0 || LvwColumnSorter.ColumnToSort == 13 ) ? true : false;
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
            openFileDialog.Filter = "xml files (*.xml)|*.xml|Exoplanet.eu Exoplanet Archive files (*.vot)|*.vot" +
                                                           "|NASA Exoplanet Archive files (*.vot)|*.vot" +
                                                           "|Exoplanets.org Archive files (*.csv)|*.csv" +
                                                           "|All files (*.*)|*.*";
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

                        if (openFileDialog.FilterIndex == 1)
                            {
                            XmlFileName = openFileDialog.FileName;
                            }
                        else if (openFileDialog.FilterIndex == 2 || openFileDialog.FilterIndex == 3)
                            {                                       // Exoplanet.EU or NASA data files
                            ReadVOT.Read (openFileDialog.FileName);
                            XmlFileName = ReadVOT.ReplaceExtension (openFileDialog.FileName);
                            }
                        else if (openFileDialog.FilterIndex == 4)
                            {                                       // Exoplanets.org data files
                            ReadCSV.Read (openFileDialog.FileName);
                            XmlFileName = ReadCSV.ReplaceExtension (openFileDialog.FileName);
                            }
                        else
                            {
                            if (ReadCSV.IsCSV (openFileDialog.FileName))
                                {
                                ReadCSV.Read (openFileDialog.FileName);
                                XmlFileName = ReadCSV.ReplaceExtension (openFileDialog.FileName);
                                }
                            else if (ReadVOT.IsVOT (openFileDialog.FileName))
                                {
                                ReadVOT.Read (openFileDialog.FileName);
                                XmlFileName = ReadVOT.ReplaceExtension (openFileDialog.FileName);
                                }
                            else if (ReadTBL.IsTBL (openFileDialog.FileName))
                                {
                                ReadTBL.Read (openFileDialog.FileName);
                                XmlFileName = ReadTBL.ReplaceExtension (openFileDialog.FileName);
                                }
                            else if (fileName.EndsWith (".xml"))
                                {
                                XmlFileName = openFileDialog.FileName;
                                }
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

        private void save_Click (object sender, System.EventArgs e)
            {
            WriteXML.WriteExoplanets (XmlFileName, Exoplanets.ExoplanetsArray);
            }

        private void saveAs_Click (object sender, System.EventArgs e)
            {
            SaveFileDialog saveFileDialog = new SaveFileDialog ();

            saveFileDialog.InitialDirectory = Constant.ProgramDataFolder;
            saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
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

                        if (!fileName.EndsWith (".xml"))
                            fileName = fileName + ".xml";

                        WriteXML.WriteExoplanets (fileName, Exoplanets.ExoplanetsArray);
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
            string xmlFileName = string.Empty;

            if (open (out xmlFileName) == 0)
                {
                System.Collections.ArrayList array2 = ReadXML.Read (xmlFileName);

                MessageBox.Show (Exoplanets.Compare (Exoplanets.ExoplanetsArray, array2), "Comparison " + xmlFileName);
                }
            }

        private void merge_Click (object sender, EventArgs e)
            {
            string xmlFileName = string.Empty;

            if (open (out xmlFileName) == 0)
                {
                System.Collections.ArrayList array2 = ReadXML.Read (xmlFileName);

                Exoplanets.ExoplanetsArray = Exoplanets.Merge (Exoplanets.ExoplanetsArray, array2);
                WriteXML.WriteExoplanets (XmlFileName, Exoplanets.ExoplanetsArray);
                UpdateExoplanetListView (false);
                }
            }

        private void verifyNames_Click (object sender, EventArgs e)
            {
            MessageBox.Show (Exoplanets.VerifyNames (Exoplanets.ExoplanetsArray), "Verify Names");
            }

        private int open (out string fileName)
            {
            OpenFileDialog openFileDialog = new OpenFileDialog ();

            openFileDialog.InitialDirectory = Constant.ProgramDataFolder;
            openFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            fileName = string.Empty;

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
            Settings.WriteLastEUVisit (System.DateTime.Now);
            }

        private void launchExoplanetEuCatalog_Click (object sender, EventArgs e)
            {
            string url = "http://exoplanet.eu//catalog";

            System.Diagnostics.Process.Start (url);
            Settings.WriteLastEUVisit (System.DateTime.Now);
            }

        private void launchExoplanetNasaCatalog_Click (object sender, EventArgs e)
            {
            string url = "http://exoplanetarchive.ipac.caltech.edu/";

            System.Diagnostics.Process.Start (url);
            Settings.WriteLastNASAVisit (System.DateTime.Now);
            }

        private void launchExoplanetOrg_Click (object sender, System.EventArgs e)
            {
            string url = "http://exoplanets.org";

            System.Diagnostics.Process.Start (url);
            Settings.WriteLastExoplanetsOrgVisit (System.DateTime.Now);
            }

        private void query_Click (object sender, System.EventArgs e)
            {
            if (QueryDialog == null)
                QueryDialog = new QueryDialog (this);

            QueryDialog.Show ();
            QueryDialog.BringToFront ();
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
            Settings.Write ();
            }

        public void QueryBuilderClosed ()
            {
            QueryDialog = null;
            }

        public void VisualizationClosed ()
            {
            Visualization = null;
            }

        public void ExoplanetDetailsClosed ()
            {
            ExoplanetDetails = null;
            }

        private void ReadLastUsedSettings ()
            {
            XmlFileName = Settings.ReadFileName ();

            Settings.Read ();
            }

        public void ProcessQuery ()
            {
            UpdateExoplanetListView (false);
            }
        }
    }
