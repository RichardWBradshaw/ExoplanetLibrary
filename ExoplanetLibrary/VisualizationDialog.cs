using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace ExoplanetLibrary
    {
    public partial class VisualizationDialog : Form
        {
        private LibraryDialog ParentDialog_ = null;
        private LibraryDialog ParentDialog
            {
            get { return ParentDialog_; }
            set { ParentDialog_ = value; }
            }

        private PlotTypes PlotType_ = PlotTypes.Mass;
        private PlotTypes PlotType
            {
            get { return PlotType_; }
            set { PlotType_ = value; }
            }

        public VisualizationDialog ()
            {
            }

        public VisualizationDialog (LibraryDialog parent) : this ()
            {
            ParentDialog = parent;
            InitializeComponent ();

            ResizeBegin += new EventHandler (VisualizationResizeBegin);
            ResizeEnd += new EventHandler (VisualizationResizeEnd);
            SizeChanged += new EventHandler (VisualizationResize);

            errorBarsToolStripMenuItem.Checked = Visualization.IncludeErrorBars == CheckState.Checked ? true : false;
            colorFromStarTypeToolStripMenuItem.Checked = Visualization.ColorFromStarType == CheckState.Checked ? true : false;
            logXAxisToolStripMenuItem.Checked = Visualization.LogXAxis == CheckState.Checked ? true : false;
            logYAxisToolStripMenuItem.Checked = Visualization.LogYAxis == CheckState.Checked ? true : false;
            includeDuplicatesToolStripMenuItem.Checked = Visualization.IncludeDuplicates == CheckState.Checked ? true : false;

            RefreshGraphics ();
            }

        private void VisualizationResizeBegin (object sender, System.EventArgs e)
            {
            }

        private void VisualizationResizeEnd (object sender, System.EventArgs e)
            {
            Control control = ( Control )sender;

            if (PlotSurface2D != null)
                {
                PlotSurface2D.Height = Size.Height - ( 27 + 20 + 20 );
                PlotSurface2D.Width = Size.Width - ( 0 + 8 + 8 );
                }
            }

        private void VisualizationResize (object sender, System.EventArgs e)
            {
            Control control = ( Control )sender;

            if (PlotSurface2D != null)
                {
                PlotSurface2D.Height = Size.Height - ( 27 + 20 + 20 );
                PlotSurface2D.Width = Size.Width - ( 0 + 8 + 8 );
                }
            }

        private void Visualization_FormClosing (object sender, FormClosingEventArgs e)
            {
            if (ParentDialog != null)
                ParentDialog.VisualizationClosed ();
            }

        private void visualizeMass_Click (object sender, System.EventArgs e)
            {
            PlotType = PlotTypes.Mass;
            RefreshGraphics ();
            }

        private void visualizeRadii_Click (object sender, System.EventArgs e)
            {
            PlotType = PlotTypes.Radius;
            RefreshGraphics ();
            }

        private void visualizeOrbitalPeriod_Click (object sender, System.EventArgs e)
            {
            PlotType = PlotTypes.OrbitalPeriod;
            RefreshGraphics ();
            }

        private void visualizeSemiMajorAxis_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.SemiMajorAxis;
            RefreshGraphics ();
            }

        private void visualizeEccentricity_Click (object sender, System.EventArgs e)
            {
            PlotType = PlotTypes.Eccentricity;
            RefreshGraphics ();
            }

        private void visualizeAngularDistance_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.AngularDistance;
            RefreshGraphics ();
            }

        private void visualizeInclination_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.Inclination;
            RefreshGraphics ();
            }

        private void visualizeTcalc_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.TemperatureCalculated;
            RefreshGraphics ();
            }

        private void visualizeOmega_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.Omega;
            RefreshGraphics ();
            }

        private void visualizeK_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.VelocitySemiamplitude;
            RefreshGraphics ();
            }

        private void visualizeStars_Click (object sender, System.EventArgs e)
            {
            PlotType = PlotTypes.Stars;
            RefreshGraphics ();
            }

        private void visualizeDetectionMethod_Click (object sender, System.EventArgs e)
            {
            PlotType = PlotTypes.DetectionMethod;
            RefreshGraphics ();
            }

        private void visualizeMassVersusRadius_Click (object sender, System.EventArgs e)
            {
            PlotType = PlotTypes.MassAndRadius;
            RefreshGraphics ();
            }

        private void visualizeEccentricityVersusMass_Click (object sender, System.EventArgs e)
            {
            PlotType = PlotTypes.MassAndEccentricity;
            RefreshGraphics ();
            }
        private void visualizeMassVersusOrbitalPeriod_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.MassAndOrbitalPeriod;
            RefreshGraphics ();
            }

        private void visualizeMassVersusSemiMajorAxis_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.MassAndSemiMajorAxis;
            RefreshGraphics ();
            }

        private void visualizeMassVersusEccentricity_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.MassAndEccentricity;
            RefreshGraphics ();
            }

        private void visualizeMassVersusAngularDistance_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.MassAndAngularDistance;
            RefreshGraphics ();
            }

        private void visualizeMassVersusOmega_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.MassAndOmega;
            RefreshGraphics ();
            }

        private void visualizeMassVersusInclination_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.MassAndInclination;
            RefreshGraphics ();
            }

        private void visualizeMassVersusK_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.MassAndVelocitySemiamplitude;
            RefreshGraphics ();
            }

        private void visualizeRadiusVersusMass_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.RadiusAndMass;
            RefreshGraphics ();
            }

        private void visualizeRadiusVersusOrbitalPeriod_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.RadiusAndOrbitalPeriod;
            RefreshGraphics ();
            }

        private void visualizeRadiusVersusSemiMajorAxis_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.RadiusAndSemiMajorAxis;
            RefreshGraphics ();
            }

        private void visualizeRadiusVersusEccentricity_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.RadiusAndEccentricity;
            RefreshGraphics ();
            }

        private void visualizeRadiusVersusAngularDistance_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.RadiusAndAngularDistance;
            RefreshGraphics ();
            }

        private void visualizeRadiusVersusOmega_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.RadiusAndOmega;
            RefreshGraphics ();
            }

        private void visualizeRadiusVersusInclination_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.RadiusAndInclination;
            RefreshGraphics ();
            }

        private void visualizeRadiusVersusK_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.RadiusAndVelocitySemiamplitude;
            RefreshGraphics ();
            }

        public void RefreshGraphics ()
            {
            ArrayList array = null;
            bool includeDuplicates = Visualization.IncludeDuplicates == CheckState.Checked ? true : false;

            switch (PlotType)
                {
                case PlotTypes.Mass:
                    array = Exoplanets.PlanetsWithMass (Exoplanets.ExoplanetsArray, false, includeDuplicates);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.Radius:
                    array = Exoplanets.PlanetsWithRadius (Exoplanets.ExoplanetsArray, false, includeDuplicates);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.OrbitalPeriod:
                    array = Exoplanets.PlanetsWithOrbitalPeriods (Exoplanets.ExoplanetsArray, false, includeDuplicates);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.SemiMajorAxis:
                    array = Exoplanets.PlanetsWithSemiMajorAxis (Exoplanets.ExoplanetsArray, false, includeDuplicates);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.Eccentricity:
                    array = Exoplanets.PlanetsWithEccentricity (Exoplanets.ExoplanetsArray, false, includeDuplicates);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.AngularDistance:
                    array = Exoplanets.PlanetsWithAngularDistance (Exoplanets.ExoplanetsArray, includeDuplicates);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.Inclination:
                    array = Exoplanets.PlanetsWithInclination (Exoplanets.ExoplanetsArray, false, includeDuplicates);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.TemperatureCalculated:
                    array = Exoplanets.PlanetsWithTemperatureCalculated (Exoplanets.ExoplanetsArray, includeDuplicates);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.Omega:
                    array = Exoplanets.PlanetsWithOmega (Exoplanets.ExoplanetsArray, false, includeDuplicates);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.VelocitySemiamplitude:
                    array = Exoplanets.PlanetsWithVelocitySemiamplitude (Exoplanets.ExoplanetsArray, false, true, includeDuplicates);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.MassAndRadius:
                    if (( array = Exoplanets.PlanetsWithMass (Exoplanets.ExoplanetsArray, false, true) ) != null)
                        if (( array = Exoplanets.PlanetsWithRadius (array, false, true) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.MassAndRadius);
                    break;

                case PlotTypes.MassAndOrbitalPeriod:
                    if (( array = Exoplanets.PlanetsWithMass (Exoplanets.ExoplanetsArray, false, true) ) != null)
                        if (( array = Exoplanets.PlanetsWithOrbitalPeriods (array, false, true) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.MassAndOrbitalPeriod);
                    break;

                case PlotTypes.MassAndSemiMajorAxis:
                    if (( array = Exoplanets.PlanetsWithMass (Exoplanets.ExoplanetsArray, false, true) ) != null)
                        if (( array = Exoplanets.PlanetsWithSemiMajorAxis (array, false, true) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.MassAndSemiMajorAxis);
                    break;

                case PlotTypes.MassAndEccentricity:
                    if (( array = Exoplanets.PlanetsWithMass (Exoplanets.ExoplanetsArray, false, true) ) != null)
                        if (( array = Exoplanets.PlanetsWithEccentricity (array, false, true) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.MassAndEccentricity);
                    break;

                case PlotTypes.MassAndAngularDistance:
                    if (( array = Exoplanets.PlanetsWithMass (Exoplanets.ExoplanetsArray, false, true) ) != null)
                        if (( array = Exoplanets.PlanetsWithAngularDistance (array, true) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.MassAndAngularDistance);
                    break;

                case PlotTypes.MassAndOmega:
                    if (( array = Exoplanets.PlanetsWithMass (Exoplanets.ExoplanetsArray, false, true) ) != null)
                        if (( array = Exoplanets.PlanetsWithOmega (array, false, true) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.MassAndOmega);
                    break;

                case PlotTypes.MassAndInclination:
                    if (( array = Exoplanets.PlanetsWithMass (Exoplanets.ExoplanetsArray, false, true) ) != null)
                        if (( array = Exoplanets.PlanetsWithInclination (array, false, true) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.MassAndInclination);
                    break;

                case PlotTypes.MassAndVelocitySemiamplitude:
                    if (( array = Exoplanets.PlanetsWithMass (Exoplanets.ExoplanetsArray, false, true) ) != null)
                        if (( array = Exoplanets.PlanetsWithVelocitySemiamplitude (array, false, true, true) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.MassAndVelocitySemiamplitude);
                    break;

                case PlotTypes.RadiusAndMass:
                    if (( array = Exoplanets.PlanetsWithRadius (Exoplanets.ExoplanetsArray, false, true) ) != null)
                        if (( array = Exoplanets.PlanetsWithMass (array, false, true) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.RadiusAndMass);
                    break;

                case PlotTypes.RadiusAndOrbitalPeriod:
                    if (( array = Exoplanets.PlanetsWithRadius (Exoplanets.ExoplanetsArray, false, true) ) != null)
                        if (( array = Exoplanets.PlanetsWithOrbitalPeriods (array, false, true) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.RadiusAndOrbitalPeriod);
                    break;

                case PlotTypes.RadiusAndSemiMajorAxis:
                    if (( array = Exoplanets.PlanetsWithRadius (Exoplanets.ExoplanetsArray, false, true) ) != null)
                        if (( array = Exoplanets.PlanetsWithSemiMajorAxis (array, false, true) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.RadiusAndSemiMajorAxis);
                    break;

                case PlotTypes.RadiusAndEccentricity:
                    if (( array = Exoplanets.PlanetsWithRadius (Exoplanets.ExoplanetsArray, false, true) ) != null)
                        if (( array = Exoplanets.PlanetsWithEccentricity (array, false, true) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.RadiusAndEccentricity);
                    break;

                case PlotTypes.RadiusAndAngularDistance:
                    if (( array = Exoplanets.PlanetsWithRadius (Exoplanets.ExoplanetsArray, false, true) ) != null)
                        if (( array = Exoplanets.PlanetsWithAngularDistance (array, true) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.RadiusAndAngularDistance);
                    break;

                case PlotTypes.RadiusAndOmega:
                    if (( array = Exoplanets.PlanetsWithRadius (Exoplanets.ExoplanetsArray, false, true) ) != null)
                        if (( array = Exoplanets.PlanetsWithOmega (array, false, true) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.RadiusAndOmega);
                    break;

                case PlotTypes.RadiusAndInclination:
                    if (( array = Exoplanets.PlanetsWithRadius (Exoplanets.ExoplanetsArray, false, true) ) != null)
                        if (( array = Exoplanets.PlanetsWithInclination (array, false, true) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.RadiusAndInclination);
                    break;

                case PlotTypes.RadiusAndVelocitySemiamplitude:
                    if (( array = Exoplanets.PlanetsWithRadius (Exoplanets.ExoplanetsArray, false, true) ) != null)
                        if (( array = Exoplanets.PlanetsWithVelocitySemiamplitude (array, false, true, true) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.RadiusAndVelocitySemiamplitude);
                    break;

                case PlotTypes.Stars:
                    Plotting.VisualizeStars (PlotSurface2D, Exoplanets.ExoplanetsArray);
                    break;

                case PlotTypes.DetectionMethod:
                    Plotting.VisualizeDetectionMethod (PlotSurface2D, Exoplanets.ExoplanetsArray);
                    break;
                }

            PlotSurface2D.RightMenu = NPlot.Windows.PlotSurface2D.DefaultContextMenu;
            }

        private void MenuCheckBox_CheckStateChanged (object sender, EventArgs e)
            {
            if (sender == errorBarsToolStripMenuItem)
                {
                Visualization.IncludeErrorBars = errorBarsToolStripMenuItem.CheckState;

                if (PlotType != PlotTypes.Stars)
                    RefreshGraphics ();
                }
            else if (sender == colorFromStarTypeToolStripMenuItem)
                {
                Visualization.ColorFromStarType = colorFromStarTypeToolStripMenuItem.CheckState;

                if (PlotType == PlotTypes.Stars)
                    RefreshGraphics ();
                }
            else if (sender == logXAxisToolStripMenuItem)
                {
                Visualization.LogXAxis = logXAxisToolStripMenuItem.CheckState;

                if (PlotType != PlotTypes.Stars)
                    RefreshGraphics ();
                }
            else if (sender == logYAxisToolStripMenuItem)
                {
                Visualization.LogYAxis = logYAxisToolStripMenuItem.CheckState;

                if (PlotType != PlotTypes.Stars)
                    RefreshGraphics ();
                }
            else if (sender == includeDuplicatesToolStripMenuItem)
                {
                Visualization.IncludeDuplicates = includeDuplicatesToolStripMenuItem.CheckState;

                if (PlotType != PlotTypes.Stars)
                    RefreshGraphics ();
                }
            }

        private void MenuCheckBox_Click (object sender, EventArgs e)
            {
            if (sender == errorBarsToolStripMenuItem)
                {
                errorBarsToolStripMenuItem.Checked = errorBarsToolStripMenuItem.CheckState == CheckState.Checked ? false : true;
                }
            else if (sender == colorFromStarTypeToolStripMenuItem)
                {
                colorFromStarTypeToolStripMenuItem.Checked = colorFromStarTypeToolStripMenuItem.CheckState == CheckState.Checked ? false : true;
                }
            else if (sender == logXAxisToolStripMenuItem)
                {
                logXAxisToolStripMenuItem.Checked = logXAxisToolStripMenuItem.CheckState == CheckState.Checked ? false : true;
                }
            else if (sender == logYAxisToolStripMenuItem)
                {
                logYAxisToolStripMenuItem.Checked = logYAxisToolStripMenuItem.CheckState == CheckState.Checked ? false : true;
                }
            else if (sender == includeDuplicatesToolStripMenuItem)
                {
                includeDuplicatesToolStripMenuItem.Checked = includeDuplicatesToolStripMenuItem.CheckState == CheckState.Checked ? false : true;
                }
            }
        }
    }
