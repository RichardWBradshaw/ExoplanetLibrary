﻿using System;
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

        private void MyResizeBegin (object sender, EventArgs e)
            {
            }

        private void MyResizeEnd (object sender, EventArgs e)
            {
            }

        private void MyResize (object sender, EventArgs e)
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
            DetailsListView.ShowItemToolTips = true;

            AddItemsToListView (DetailsListView, true, null);
            Controls.Add (DetailsListView);

            ResizeBegin += new System.EventHandler (MyResizeBegin);
            ResizeEnd += new System.EventHandler (MyResizeEnd);
            SizeChanged += new System.EventHandler (MyResize);

            DetailsListView.MouseMove += new MouseEventHandler (listView_MouseMove);
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

                Text = "Exoplanet '" + exoplanet.Name + "' Details";

                if (Helper.IsDefined (exoplanet.DetectionType))
                    {
                    item = new ListViewItem ("Detection Type", 0);
                    item.SubItems.Add (exoplanet.DetectionType);
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Mass))
                    {
                    item = new ListViewItem ("Mass", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Mass, exoplanet.MassErrorMin, exoplanet.MassErrorMax, "Mjup"));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.MassSini))
                    {
                    item = new ListViewItem ("MassSini", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.MassSini, exoplanet.MassSiniErrorMin, exoplanet.MassSiniErrorMax, "Mjup"));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Radius))
                    {
                    item = new ListViewItem ("Radius", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Radius, exoplanet.RadiusErrorMin, exoplanet.RadiusErrorMax, "Rjup"));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.OrbitalPeriod))
                    {
                    item = new ListViewItem ("Orbital Period", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.OrbitalPeriod, exoplanet.OrbitalPeriodErrorMin, exoplanet.OrbitalPeriodErrorMax, "day"));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.SemiMajorAxis))
                    {
                    item = new ListViewItem ("Semi-Major Axis", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.SemiMajorAxis, exoplanet.SemiMajorAxisErrorMin, exoplanet.SemiMajorAxisErrorMax, "AU"));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Eccentricity))
                    {
                    item = new ListViewItem ("Eccentricity", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Eccentricity, exoplanet.EccentricityErrorMin, exoplanet.EccentricityErrorMax, string.Empty));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.AngularDistance))
                    {
                    item = new ListViewItem ("Angular Distance", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.AngularDistance));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Inclination))
                    {
                    item = new ListViewItem ("Inclination", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Inclination, exoplanet.InclinationErrorMin, exoplanet.InclinationErrorMax, "deg"));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Omega))
                    {
                    item = new ListViewItem ("Omega", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Omega, exoplanet.OmegaErrorMin, exoplanet.OmegaErrorMax, "deg"));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.VelocitySemiamplitude))
                    {
                    item = new ListViewItem ("Velocity Semiamplitude", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.VelocitySemiamplitude, exoplanet.VelocitySemiamplitudeErrorMin, exoplanet.VelocitySemiamplitudeErrorMax, "m/s"));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.TemperatureCalculated))
                    {
                    item = new ListViewItem ("Calculated Temperature", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.TemperatureCalculated, "K"));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.TemperatureMeasured))
                    {
                    item = new ListViewItem ("Measured Temperature", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.TemperatureMeasured, "K"));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.TzeroTr))
                    {
                    item = new ListViewItem ("Primary Transit", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.TzeroTr, exoplanet.TzeroTrErrorMin, exoplanet.TzeroTrErrorMax, "JD"));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.TzeroTrSec))
                    {
                    item = new ListViewItem ("Secondary Transit", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.TzeroTrSec, exoplanet.TzeroTrSecErrorMin, exoplanet.TzeroTrSecErrorMax, "JD"));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.LambdaAngle))
                    {
                    item = new ListViewItem ("Lambda Angle", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.LambdaAngle, exoplanet.LambdaAngleErrorMin, exoplanet.LambdaAngleErrorMax, "deg"));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.TzeroVr))
                    {
                    item = new ListViewItem ("Zero Radial Speed Time", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.TzeroVr, exoplanet.TzeroVrErrorMin, exoplanet.TzeroVrErrorMax, "JD"));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.ImpactParameter))
                    {
                    item = new ListViewItem ("Impact Parameter b(%)", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.ImpactParameter, exoplanet.ImpactParameterErrorMin, exoplanet.ImpactParameterErrorMax, string.Empty));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.GeometricAlbedo))
                    {
                    item = new ListViewItem ("Geometric Albedo", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.GeometricAlbedo, exoplanet.GeometricAlbedoErrorMin, exoplanet.GeometricAlbedoErrorMax, string.Empty));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.LogG))
                    {
                    item = new ListViewItem ("Surface Gravity log(g)", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.LogG));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.TemperatureHotPointLo))
                    {
                    item = new ListViewItem ("Hottest Point Longitude", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.TemperatureHotPointLo, "deg"));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Tperi))
                    {
                    item = new ListViewItem ("Epoch of Periastron", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Tperi, exoplanet.TperiErrorMin, exoplanet.TperiErrorMax, "JD"));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Tconj))
                    {
                    item = new ListViewItem ("Conjunction Date", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Tconj, exoplanet.TconjErrorMin, exoplanet.TconjErrorMax, "JD"));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Molecules))
                    {
                    item = new ListViewItem ("Molecules", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Molecules, string.Empty));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Discovered))
                    {
                    item = new ListViewItem ("Year of Discovery", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Discovered));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Updated))
                    {
                    item = new ListViewItem ("Last Update", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Updated));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Status))
                    {
                    item = new ListViewItem ("Publication Status", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Status));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Molecules))
                    {
                    item = new ListViewItem ("List of Detected Molecules", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Molecules));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.MassDetectionType))
                    {
                    item = new ListViewItem ("Mass Measurement Method", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.MassDetectionType));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.RadiusDetectionType))
                    {
                    item = new ListViewItem ("Radius Measurement Method", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.RadiusDetectionType));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.AlternateNames))
                    {
                    item = new ListViewItem ("Alternate Names", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.AlternateNames));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Star.Name))
                    {
                    item = new ListViewItem ("Stellar Name", 0);
                    item.SubItems.Add (exoplanet.Star.Name);
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Star.Property.SPType))
                    {
                    item = new ListViewItem ("Stellar Spectral Type", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Star.Property.SPType));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Star.Property.Mass))
                    {
                    item = new ListViewItem ("Stellar Mass", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Star.Property.Mass, exoplanet.Star.Property.MassErrorMin, exoplanet.Star.Property.MassErrorMax, "Msun"));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Star.Property.Radius))
                    {
                    item = new ListViewItem ("Stellar Radius", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Star.Property.Radius, exoplanet.Star.Property.RadiusErrorMin, exoplanet.Star.Property.RadiusErrorMax, "Rsun"));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Star.Property.Distance))
                    {
                    item = new ListViewItem ("Stellar Distance", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Star.Property.Distance, exoplanet.Star.Property.DistanceErrorMin, exoplanet.Star.Property.DistanceErrorMax, "pc"));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Star.RightAccession))
                    {
                    item = new ListViewItem ("Right Accession - Epoch 2000", 0);
                    item.SubItems.Add (Helper.Format (Helper.FormatHMS (exoplanet.Star.RightAccession)));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Star.Declination))
                    {
                    item = new ListViewItem ("Declination - Epoch 2000", 0);
                    item.SubItems.Add (Helper.Format (Helper.FormatHMS (exoplanet.Star.Declination)));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Star.Property.Metallicity))
                    {
                    item = new ListViewItem ("Stellar Metallicity", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Star.Property.Metallicity, exoplanet.Star.Property.MetallicityErrorMin, exoplanet.Star.Property.MetallicityErrorMax, string.Empty));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Star.Property.Age))
                    {
                    item = new ListViewItem ("Stellar Age", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Star.Property.Age, exoplanet.Star.Property.AgeErrorMin, exoplanet.Star.Property.AgeErrorMax, "Gy"));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Star.Property.Teff))
                    {
                    item = new ListViewItem ("Stellar Effective Temperature", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Star.Property.Teff, exoplanet.Star.Property.TeffErrorMin, exoplanet.Star.Property.TeffErrorMax, "K"));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Star.Property.DetectedDisc))
                    {
                    item = new ListViewItem ("Stellar Detected Disc", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Star.Property.DetectedDisc));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Star.Property.MagneticField))
                    {
                    item = new ListViewItem ("Stellar Magnetic Field", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Star.Property.MagneticField));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Star.Magnitude.V))
                    {
                    item = new ListViewItem ("V Magnitude", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Star.Magnitude.V));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Star.Magnitude.I))
                    {
                    item = new ListViewItem ("I Magnitude", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Star.Magnitude.I));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Star.Magnitude.J))
                    {
                    item = new ListViewItem ("J Magnitude", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Star.Magnitude.J));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Star.Magnitude.H))
                    {
                    item = new ListViewItem ("H Magnitude", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Star.Magnitude.H));
                    DetailsListView.Items.Add (item);
                    }

                if (Helper.IsDefined (exoplanet.Star.Magnitude.K))
                    {
                    item = new ListViewItem ("K Magnitude", 0);
                    item.SubItems.Add (Helper.Format (exoplanet.Star.Magnitude.K));
                    DetailsListView.Items.Add (item);
                    }

                listView.Refresh ();
                }
            }

        public void DisplayDetails (ExoplanetLibrary.Exoplanet exoplanet)
            {
            for (int index = DetailsListView.Items.Count - 1; index >= 0; --index)
                DetailsListView.Items.RemoveAt (index);

            AddItemsToListView (DetailsListView, false, exoplanet);
            }

        void listView_MouseMove (object sender, MouseEventArgs e)
            {
            ListViewItem item = DetailsListView.GetItemAt (e.X, e.Y);
            ListViewHitTestInfo info = DetailsListView.HitTest (e.X, e.Y);

            if (( item != null ) && ( info.SubItem != null ))
                {
                //
                // https://en.wikipedia.org/wiki/Exoplanet
                // https://www.paulanthonywilson.com/exoplanets/exoplanet-detection-techniques/the-exoplanet-transit-method/
                //

                if (item.Text == "Detection Type")
                    item.ToolTipText = string.Empty +
                                       "\r\r(Ref. https://en.wikipedia.org/wiki/Methods_of_detecting_exoplanets)";
                else if (item.Text == "Mass")
                    item.ToolTipText = "The planetary mass is a measure of the total amount of material in a body, defined either by the inertial properties of the body or by its gravitational influence on other bodies'" +
                                       "\r\r(Ref. http://www.seasky.org/astronomy)";
                else if (item.Text == "MassSini")
                    item.ToolTipText = "The planetary mass is a measure of the total amount of material in a body, defined either by the inertial properties of the body or by its gravitational influence on other bodies'" +
                                       "\r\r(Ref. http://www.seasky.org/astronomy)";
                else if (item.Text == "Radius")
                    item.ToolTipText = "The planetary radius is the distance between a planet's center and its surface. Therefore, planetary radius is a measure of a planet's size";
                else if (item.Text == "Orbital Period")
                    item.ToolTipText = "The orbital period is the time taken for a given object to make one complete orbit around another object'" +
                                       "\r\r(Ref. https://en.wikipedia.org/wiki/Orbital_period)";
                else if (item.Text == "Semi-Major Axis")
                    item.ToolTipText = string.Empty;
                else if (item.Text == "Eccentricity")
                    item.ToolTipText = "The orbital eccentricity of an astronomical object is a parameter that determines the amount by which its orbit around another body deviates from a perfect circle. A value of 0 is a circular orbit, values between 0 and 1 form an elliptical orbit, 1 is a parabolic escape orbit, and greater than 1 is a hyperbola'" +
                                       "\r\r(Ref. https://en.wikipedia.org/wiki/Orbital_eccentricity)";
                else if (item.Text == "Angular Distance")
                    item.ToolTipText = string.Empty;
                else if (item.Text == "Orbital Inclination")
                    item.ToolTipText = "Orbital inclination is the minimum angle between a reference plane and the orbital plane or axis of direction of an object in orbit around another object'" +
                                       "\r\r(Ref. https://en.wikipedia.org/wiki/Orbital_inclination)";
                else if (item.Text == "Omega")
                    item.ToolTipText = "Omega is the argument of periastron precession is the rotation of a planet's orbit within the orbital plane, i.e. the axes of the ellipse change direction'" +
                                       "\r\r(Ref. https://en.wikipedia.org/wiki/Exoplanet#Periastron_precession)";
                else if (item.Text == "Velocity Semiamplitude")
                    item.ToolTipText = "It is the most widely used measure of orbital wobble in astronomy and the measurement of small radial velocity semi-amplitudes of nearby stars is important in the search for exoplanets'" +
                                       "\r\r(Ref. https://en.wikipedia.org/wiki/Amplitude)";
                else if (item.Text == "Calculated Temperature")
                    item.ToolTipText = string.Empty;
                else if (item.Text == "Measured Temperature")
                    item.ToolTipText = string.Empty;
                else if (item.Text == "Primary Transit")
                    item.ToolTipText = "A transit is the astronomical event that occurs when one celestial body appears to move across the face of another celestial body, hiding a small part of it, as seen by an observer at some particular vantage point'" +
                                       "\r\r(Ref. https://en.wikipedia.org/wiki/Transit_(astronomy))";
                else if (item.Text == "Secondary Transit")
                    item.ToolTipText = string.Empty;
                else if (item.Text == "Lambda Angle")
                    item.ToolTipText = "Sky-projected angle between the planetary orbital spin and the stellar rotational spin";
                else if (item.Text == "Zero Radial Speed Time")
                    item.ToolTipText = string.Empty;
                else if (item.Text == "Impact Parameter b(%)")
                    item.ToolTipText = "The impact parameter b is defined as the perpendicular distance between the path of a projectile and the center of a potential field U(r) created by an object that the projectile is approaching'" +
                                      "\r\r(Ref. https://en.wikipedia.org/wiki/Impact_parameter)";
                else if (item.Text == "Geometric Albedo")
                    item.ToolTipText = "Geometric albedo of a celestial body is the ratio of its actual brightness as seen from the light source (i.e at zero phase angle) to that of an idealized flat, fully reflecting, diffusively scattering (Lambertian) disk with the same cross-section'" +
                                       "\r\r(Ref. https://en.wikipedia.org/wiki/Geometric_albedo)";
                else if (item.Text == "Surface Gravity log(g)")
                    item.ToolTipText = string.Empty;
                else if (item.Text == "Hottest Point Longitude")
                    item.ToolTipText = string.Empty;
                else if (item.Text == "Epoch of Periastron")
                    item.ToolTipText = string.Empty;
                else if (item.Text == "Conjonction Date")
                    item.ToolTipText = string.Empty;
                else if (item.Text == "Molecules")
                    item.ToolTipText = string.Empty;
                else if (item.Text == "Year of Discovery")
                    item.ToolTipText = string.Empty;
                else if (item.Text == "Last Update")
                    item.ToolTipText = string.Empty;
                else if (item.Text == "Publication Status")
                    item.ToolTipText = string.Empty;
                else if (item.Text == "List of Detected Molecules")
                    item.ToolTipText = string.Empty;
                else if (item.Text == "Mass Measurement Method")
                    item.ToolTipText = string.Empty;
                else if (item.Text == "Radius Measurement Method")
                    item.ToolTipText = string.Empty;
                else if (item.Text == "Alternate Names")
                    item.ToolTipText = "List of planet alternative names";
                else
                    item.ToolTipText = info.SubItem.Text;

                if (item.ToolTipText.Length == 0)
                    item.ToolTipText = info.SubItem.Text;
                }
            }
        }
    }
