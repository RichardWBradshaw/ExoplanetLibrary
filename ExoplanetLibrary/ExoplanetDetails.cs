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
        private LibraryDialog ParentDialog_ = null;
        private LibraryDialog ParentDialog
            {
            get
                {
                return ParentDialog_;
                }
            set
                {
                ParentDialog_ = value;
                }
            }

        private ListView DetailsListView_ = null;
        private ListView DetailsListView
            {
            get
                {
                return DetailsListView_;
                }
            set
                {
                DetailsListView_ = value;
                }
            }

        public ExoplanetDetails(LibraryDialog parent)
            {
            ParentDialog = parent;
            InitializeComponent ();
            CreatePlanetListView ();
            }

        private void PlanetNStarDetails_FormClosing(object sender, FormClosingEventArgs e)
            {
            if (ParentDialog != null)
                ParentDialog.ExoplanetDetailsClosed ();
            }

        private void CreatePlanetListView()
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
            }

        private void UpdatePlanetsListView()
            {
            for (int index = DetailsListView.Items.Count - 1; index >= 0; --index)
                DetailsListView.Items.RemoveAt (index);

            AddItemsToListView (DetailsListView, false, null);
            }

        private void AddItemsToListView(ListView listView, bool addColumns, ExoplanetLibrary.CExoplanet exoplanet)
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

                item = new ListViewItem ("Mass (Mjup)", 0);
                item.SubItems.Add (Format (exoplanet.Mass, exoplanet.MassErrorMin, exoplanet.MassErrorMax));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Radius (Rjup)", 0);
                item.SubItems.Add (Format (exoplanet.Radius, exoplanet.RadiusErrorMin, exoplanet.RadiusErrorMax));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Orbitat Period (day)", 0);
                item.SubItems.Add (Format (exoplanet.OrbitalPeriod, exoplanet.OrbitalPeriodErrorMin, exoplanet.OrbitalPeriodErrorMax));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Semi-Major Axis (AU)", 0);
                item.SubItems.Add (Format (exoplanet.SemiMajorAxis, exoplanet.SemiMajorAxisErrorMin, exoplanet.SemiMajorAxisErrorMax));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Eccentricity", 0);
                item.SubItems.Add (Format (exoplanet.Eccentricity, exoplanet.EccentricityErrorMin, exoplanet.EccentricityErrorMax));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Angular Distance", 0);
                item.SubItems.Add (Format (exoplanet.AngularDistance));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Inclination (deg)", 0);
                item.SubItems.Add (Format (exoplanet.Inclination, exoplanet.InclinationErrorMin, exoplanet.InclinationErrorMax));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("T0 (JD)", 0);
                item.SubItems.Add (Format (exoplanet.TzeroTr, exoplanet.TzeroTrErrorMin, exoplanet.TzeroTrErrorMax));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("T0-sec (JD)", 0);
                item.SubItems.Add (Format (exoplanet.TzeroTrSec, exoplanet.TzeroTrSecErrorMin, exoplanet.TzeroTrSecErrorMax));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Lambda Angle (deg)", 0);
                item.SubItems.Add (Format (exoplanet.LambdaAngle, exoplanet.LambdaAngleErrorMin, exoplanet.LambdaAngleErrorMax));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Tvr (JD)", 0);
                item.SubItems.Add (Format (exoplanet.TzeroVr, exoplanet.TzeroVrErrorMin, exoplanet.TzeroVrErrorMax));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Tcalc (K)", 0);
                item.SubItems.Add (Format (exoplanet.TemperatureCalculated));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Tmeas (K)", 0);
                item.SubItems.Add (Format (exoplanet.TemperatureMeasured));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Hot pt (deg)", 0);
                item.SubItems.Add (Format (exoplanet.TemperatureHotPointLo));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Log(g)", 0);
                item.SubItems.Add (Format (exoplanet.LogG));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Publication Status", 0);
                item.SubItems.Add (Format (exoplanet.Status));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Discovered", 0);
                item.SubItems.Add (Format (exoplanet.Discovered));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Updated", 0);
                item.SubItems.Add (Format (exoplanet.Updated));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Omega (deg)", 0);
                item.SubItems.Add (Format (exoplanet.Omega, exoplanet.OmegaErrorMin, exoplanet.OmegaErrorMax));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Tperi (JD)", 0);
                item.SubItems.Add (Format (exoplanet.Tperi, exoplanet.TperiErrorMin, exoplanet.TperiErrorMax));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Detection Type", 0);
                item.SubItems.Add (exoplanet.DetectionType);
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Molecules", 0);
                item.SubItems.Add (Format (exoplanet.Molecules));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Impact Parameter b(%)", 0);
                item.SubItems.Add (Format (exoplanet.ImpactParameter, exoplanet.ImpactParameterErrorMin, exoplanet.ImpactParameterErrorMax));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("K (m/s)", 0);
                item.SubItems.Add (Format (exoplanet.K, exoplanet.KErrorMin, exoplanet.KErrorMax));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Geometric Albedo", 0);
                item.SubItems.Add (Format (exoplanet.GeometricAlbedo, exoplanet.GeometricAlbedoErrorMin, exoplanet.GeometricAlbedoErrorMax));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Tconj", 0);
                item.SubItems.Add (Format (exoplanet.Tconj, exoplanet.TconjErrorMin, exoplanet.TconjErrorMax));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Mass Detection Type", 0);
                item.SubItems.Add (Format (exoplanet.MassDetectionType));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Radius Detection Type", 0);
                item.SubItems.Add (Format (exoplanet.RadiusDetectionType));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("AlternateNames", 0);
                item.SubItems.Add (Format (exoplanet.AlternateNames));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Star", 0);
                item.SubItems.Add (exoplanet.Star.Name);
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Right Accession", 0);
                item.SubItems.Add (Format (exoplanet.Star.RightAccession));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("Declination", 0);
                item.SubItems.Add (Format (exoplanet.Star.Declination));
                DetailsListView.Items.Add (item);

                item = new ListViewItem ("SPType", 0);
                item.SubItems.Add (Format (exoplanet.Star.Properties.SPType));
                DetailsListView.Items.Add (item);

                listView.Refresh ();
                }
            }

        private string Format(string value, string minimumError, string maximumError)
            {
            if (minimumError != null && maximumError != null && minimumError.Length > 0 && maximumError.Length > 0)
                {
                if (string.Equals (minimumError, maximumError))
                    return value + " (+/-" + maximumError + ")";
                else
                    return value + " (+" + maximumError + "/-" + minimumError + ")";
                }
            else if (value != null && value.Length > 0)
                return value;
            else
                return " - ";
            }

        private string Format(string value)
            {
            if (value != null && value.Length > 0)
                return value;
            else
                return " - ";
            }

        public void DisplayDetails(ExoplanetLibrary.CExoplanet exoplanet)
            {
            for (int index = DetailsListView.Items.Count - 1; index >= 0; --index)
                DetailsListView.Items.RemoveAt (index);

            AddItemsToListView (DetailsListView, false, exoplanet);
            }
        }
    }
