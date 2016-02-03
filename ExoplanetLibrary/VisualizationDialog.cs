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

        //

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

        private void visualizeT0_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.TzeroTr;
            RefreshGraphics ();
            }

        private void visualizeT0sec_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.TzeroTrSec;
            RefreshGraphics ();
            }

        private void visualizeLambdaAngle_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.LambdaAngle;
            RefreshGraphics ();
            }

        private void visualizeTvr_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.TzeroVr;
            RefreshGraphics ();
            }

        private void visualizeTcalc_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.TemperatureCalculated;
            RefreshGraphics ();
            }

        private void visualizeTmeas_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.TemperatureMeasured;
            RefreshGraphics ();
            }

        private void visualizeLogG_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.LogG;
            RefreshGraphics ();
            }

        private void visualizeOmega_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.Omega;
            RefreshGraphics ();
            }

        private void visualizeTperi_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.Tperi;
            RefreshGraphics ();
            }

        private void visualizeK_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.K;
            RefreshGraphics ();
            }

        private void visualizeGeometricAlbedo_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.GeometricAlbedo;
            RefreshGraphics ();
            }

        private void visualizeTconj_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.Tconj;
            RefreshGraphics ();
            }

        ///

        private void visualizeStars_Click (object sender, System.EventArgs e)
            {
            PlotType = PlotTypes.Stars;
            RefreshGraphics ();
            }

        private void visualizeMassVersusRadius_Click (object sender, System.EventArgs e)
            {
            PlotType = PlotTypes.MassAndRadius;
            RefreshGraphics ();
            }

        private void visualizeEccentricityVersusMass_Click (object sender, System.EventArgs e)
            {
            PlotType = PlotTypes.EccentricityAndMass;
            RefreshGraphics ();
            }

        ///

        private void visualizeRefreshView_Click (object sender, EventArgs e)
            {
            RefreshGraphics ();
            }

        private void RefreshGraphics ()
            {
            ArrayList array = null;

            switch (PlotType)
                {
                case PlotTypes.Mass:
                    array = Helper.PlanetsWithMass (ParentDialog.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.Radius:
                    array = Helper.PlanetsWithRadius (ParentDialog.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.OrbitalPeriod:
                    array = Helper.PlanetsWithOrbitalPeriods(ParentDialog.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.SemiMajorAxis:
                    array = Helper.PlanetsWithSemiMajorAxis (ParentDialog.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.Eccentricity:
                    array = Helper.PlanetsWithEccentricity(ParentDialog.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.AngularDistance:
                    array = Helper.PlanetsWithAngularDistance (ParentDialog.ExoplanetsArray);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.Inclination:
                    array = Helper.PlanetsWithInclination (ParentDialog.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.TzeroTr:
                    array = Helper.PlanetsWithTzeroTr (ParentDialog.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.TzeroTrSec:
                    array = Helper.PlanetsWithTzeroTrSec (ParentDialog.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.LambdaAngle:
                    array = Helper.PlanetsWithLambdaAngle (ParentDialog.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.TzeroVr:
                    array = Helper.PlanetsWithTzeroVr (ParentDialog.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.TemperatureCalculated:
                    array = Helper.PlanetsWithTemperatureCalculated (ParentDialog.ExoplanetsArray);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.TemperatureMeasured:
                    array = Helper.PlanetsWithTemperatureMeasured (ParentDialog.ExoplanetsArray);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.LogG:
                    array = Helper.PlanetsWithLogG (ParentDialog.ExoplanetsArray);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.Omega:
                    array = Helper.PlanetsWithOmega (ParentDialog.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.Tperi:
                    array = Helper.PlanetsWithTperi (ParentDialog.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.K:
                    array = Helper.PlanetsWithK (ParentDialog.ExoplanetsArray, false, true);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.GeometricAlbedo:
                    array = Helper.PlanetsWithGeometricAlbedo (ParentDialog.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.Tconj:
                    array = Helper.PlanetsWithTconj (ParentDialog.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.Stars:
                    Plotting.VisualizeStars (PlotSurface2D, ParentDialog.ExoplanetsArray);
                    break;

                case PlotTypes.MassAndRadius:
                    Plotting.VisualizeMassAndRadius (PlotSurface2D, ParentDialog.ExoplanetsArray);
                    break;

                case PlotTypes.EccentricityAndMass:
                    Plotting.VisualizeMassAndEccentricity (PlotSurface2D, ParentDialog.ExoplanetsArray);
                    break;
                }
            }

        private void visualizePrint_Click (object sender, System.EventArgs e)
            {
            PlotSurface2D.Print (false);
            }

        private void visualizePrintPreview_Click (object sender, EventArgs e)
            {
            PlotSurface2D.Print (true);
            }

        ///

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
            }

        }
    }
