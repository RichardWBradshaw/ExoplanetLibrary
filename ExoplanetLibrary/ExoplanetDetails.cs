using System.Drawing;
using System.Windows.Forms;

namespace ExoplanetLibrary
    {
    public partial class ExoplanetDetails : Form
        {
        public ExoplanetDetails ()
            {
            }

        public ExoplanetDetails (LibraryDialog parent) : this ()
            {
            ParentDialog = parent;
            InitializeComponent ();
            CreatePlanetListView ();
            }

        private LibraryDialog ParentDialog_ = null;
        private LibraryDialog ParentDialog
            {
            get { return ParentDialog_; }
            set { ParentDialog_ = value; }
            }

        private ListView DetailsListView_ = null;
        private ListView DetailsListView
            {
            get { return DetailsListView_; }
            set { DetailsListView_ = value; }
            }

        private void PlanetNStarDetails_FormClosing (object sender, FormClosingEventArgs e)
            {
            if (ParentDialog != null)
                ParentDialog.ExoplanetDetailsClosed ();
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

            if (DetailsListView != null)
                {
                DetailsListView.Height = Size.Height - ( 60 );
                DetailsListView.Width = Size.Width - 45;
                }
            }

        private void CreatePlanetListView ()
            {
            DetailsListView = new ListView ();
            DetailsListView.Bounds = new Rectangle (new Point (10, 10), new Size (Width - 45, Height - ( 60 )));

            DetailsListView.View = View.Details;
            DetailsListView.LabelEdit = false;
            DetailsListView.AllowColumnReorder = false;
            DetailsListView.CheckBoxes = false;
            DetailsListView.FullRowSelect = true;
            DetailsListView.GridLines = true;
            DetailsListView.Sorting = SortOrder.None;

            AddItemsToListView (DetailsListView, true, null);
            Controls.Add (DetailsListView);

            ResizeBegin += new System.EventHandler (MyResizeBegin);
            ResizeEnd += new System.EventHandler (MyResizeEnd);
            SizeChanged += new System.EventHandler (MyResize);
            }

        private void UpdatePlanetsListView ()
            {
            for (int index = DetailsListView.Items.Count - 1; index >= 0; --index)
                DetailsListView.Items.RemoveAt (index);

            AddItemsToListView (DetailsListView, false, null);
            }

        private void AddItemsToListView (ListView listView, bool addColumns, Exoplanet exoplanet)
            {
            if (addColumns)
                {
                int width = ( listView.Width - 10 ) / 2;

                listView.Columns.Add ("Property", width, HorizontalAlignment.Left);
                listView.Columns.Add ("Value", width, HorizontalAlignment.Left);
                }

            if (exoplanet != null)
                {
                ListViewItem item = null;

                item = new ListViewItem ("Planet", 0);
                item.SubItems.Add (exoplanet.Name);
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Mass", 0);
                item.SubItems.Add (Helper.Format (exoplanet.Mass, exoplanet.MassErrorMin, exoplanet.MassErrorMax, "Mjup"));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Radius", 0);
                item.SubItems.Add (Helper.Format (exoplanet.Radius, exoplanet.RadiusErrorMin, exoplanet.RadiusErrorMax, "Rjup"));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Orbitat Period", 0);
                item.SubItems.Add (Helper.Format (exoplanet.OrbitalPeriod, exoplanet.OrbitalPeriodErrorMin, exoplanet.OrbitalPeriodErrorMax, "day"));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Semi-major Axis", 0);
                item.SubItems.Add (Helper.Format (exoplanet.SemiMajorAxis, exoplanet.SemiMajorAxisErrorMin, exoplanet.SemiMajorAxisErrorMax, "AU"));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Eccentricity", 0);
                item.SubItems.Add (Helper.Format (exoplanet.Eccentricity, exoplanet.EccentricityErrorMin, exoplanet.EccentricityErrorMax, ""));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Angular Distance", 0);
                item.SubItems.Add (Helper.Format (exoplanet.AngularDistance));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Inclination", 0);
                item.SubItems.Add (Helper.Format (exoplanet.Inclination, exoplanet.InclinationErrorMin, exoplanet.InclinationErrorMax, "deg"));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("T0", 0);
                item.SubItems.Add (Helper.Format (exoplanet.TzeroTr, exoplanet.TzeroTrErrorMin, exoplanet.TzeroTrErrorMax, "JD"));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("T0-sec", 0);
                item.SubItems.Add (Helper.Format (exoplanet.TzeroTrSec, exoplanet.TzeroTrSecErrorMin, exoplanet.TzeroTrSecErrorMax, "JD"));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Lambda Angle", 0);
                item.SubItems.Add (Helper.Format (exoplanet.LambdaAngle, exoplanet.LambdaAngleErrorMin, exoplanet.LambdaAngleErrorMax, "deg"));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Tvr", 0);
                item.SubItems.Add (Helper.Format (exoplanet.TzeroVr, exoplanet.TzeroVrErrorMin, exoplanet.TzeroVrErrorMax, "JD"));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Tcalc", 0);
                item.SubItems.Add (Helper.Format (exoplanet.TemperatureCalculated, "K"));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Tmeas", 0);
                item.SubItems.Add (Helper.Format (exoplanet.TemperatureMeasured, "K"));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Hot pt", 0);
                item.SubItems.Add (Helper.Format (exoplanet.TemperatureHotPointLo, "deg"));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Surface gravity log(g/gH)", 0);
                item.SubItems.Add (Helper.Format (exoplanet.LogG));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Publication Status", 0);
                item.SubItems.Add (Helper.Format (exoplanet.Status));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Discovered", 0);
                item.SubItems.Add (Helper.Format (exoplanet.Discovered));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Updated", 0);
                item.SubItems.Add (Helper.Format (exoplanet.Updated));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Detection Type", 0);
                item.SubItems.Add (exoplanet.DetectionType);
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Omega", 0);
                item.SubItems.Add (Helper.Format (exoplanet.Omega, exoplanet.OmegaErrorMin, exoplanet.OmegaErrorMax, "deg"));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Tperi", 0);
                item.SubItems.Add (Helper.Format (exoplanet.Tperi, exoplanet.TperiErrorMin, exoplanet.TperiErrorMax, "JD"));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Molecules", 0);
                item.SubItems.Add (Helper.Format (exoplanet.Molecules));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Impact Parameter b(%)", 0);
                item.SubItems.Add (Helper.Format (exoplanet.ImpactParameter, exoplanet.ImpactParameterErrorMin, exoplanet.ImpactParameterErrorMax, ""));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Velocity Semiamplitude K", 0);
                item.SubItems.Add (Helper.Format (exoplanet.K, exoplanet.KErrorMin, exoplanet.KErrorMax, "m/s"));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Geometric Albedo", 0);
                item.SubItems.Add (Helper.Format (exoplanet.GeometricAlbedo, exoplanet.GeometricAlbedoErrorMin, exoplanet.GeometricAlbedoErrorMax, ""));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Tconj", 0);
                item.SubItems.Add (Helper.Format (exoplanet.Tconj, exoplanet.TconjErrorMin, exoplanet.TconjErrorMax, "JD"));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Mass Detection Type", 0);
                item.SubItems.Add (Helper.Format (exoplanet.MassDetectionType));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Radius Detection Type", 0);
                item.SubItems.Add (Helper.Format (exoplanet.RadiusDetectionType));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Alternate Names", 0);
                item.SubItems.Add (Helper.Format (exoplanet.AlternateNames));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Star", 0);
                item.SubItems.Add (exoplanet.Star.Name);
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Right Accession - Epoch 2000", 0);
                item.SubItems.Add (Helper.Format (Helper.FormatHMS (exoplanet.Star.RightAccession)));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Declination - Epoch 2000", 0);
                item.SubItems.Add (Helper.Format (Helper.FormatHMS (exoplanet.Star.Declination)));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Distance", 0);
                item.SubItems.Add (Helper.Format (exoplanet.Star.Property.Distance, "pc"));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Metallicity", 0);
                item.SubItems.Add (Helper.Format (exoplanet.Star.Property.Metallicity));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Mass", 0);
                item.SubItems.Add (Helper.Format (exoplanet.Star.Property.Mass, "Msun"));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Radius", 0);
                item.SubItems.Add (Helper.Format (exoplanet.Star.Property.Radius, "Rsun"));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Spectral type", 0);
                item.SubItems.Add (Helper.Format (exoplanet.Star.Property.SPType));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Age", 0);
                item.SubItems.Add (Helper.Format (exoplanet.Star.Property.Age, "Gy"));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Effective temperature", 0);
                item.SubItems.Add (Helper.Format (exoplanet.Star.Property.Teff));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Detected Disc", 0);
                item.SubItems.Add (Helper.Format (exoplanet.Star.Property.DetectedDisc));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Magnetic Field", 0);
                item.SubItems.Add (Helper.Format (exoplanet.Star.Property.MagneticField));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("V Magnitude", 0);
                item.SubItems.Add (Helper.Format (exoplanet.Star.Magnitude.V));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("I Magnitude", 0);
                item.SubItems.Add (Helper.Format (exoplanet.Star.Magnitude.I));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("J Magnitude", 0);
                item.SubItems.Add (Helper.Format (exoplanet.Star.Magnitude.J));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("H Magnitude", 0);
                item.SubItems.Add (Helper.Format (exoplanet.Star.Magnitude.H));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("K Magnitude", 0);
                item.SubItems.Add (Helper.Format (exoplanet.Star.Magnitude.K));
                DetailsListView.Items.Add (item);

                listView.Refresh ();
                }
            }

        public void DisplayDetails (ExoplanetLibrary.Exoplanet exoplanet)
            {
            for (int index = DetailsListView.Items.Count - 1; index >= 0; --index)
                DetailsListView.Items.RemoveAt (index);

            AddItemsToListView (DetailsListView, false, exoplanet);
            }
        }
    }
