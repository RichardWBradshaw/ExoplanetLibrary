using System;
using System.Drawing;
using System.Windows.Forms;

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

            ResizeBegin += new EventHandler (MyResizeBegin);
            ResizeEnd += new EventHandler (MyResizeEnd);
            SizeChanged += new EventHandler (MyResize);

            errorBarsToolStripMenuItem.Checked = Visualization.IncludeErrorBars == CheckState.Checked ? true : false;
            colorFromStarTypeToolStripMenuItem.Checked = Visualization.ColorFromStarType == CheckState.Checked ? true : false;

            RefreshGraphics ();
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

            if (PlotSurface2D != null)
                {
                PlotSurface2D.Height = Size.Height - ( 20 + 24 );
                PlotSurface2D.Width = Size.Width - 10;
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
            switch (PlotType)
                {
                case PlotTypes.Mass:
                    Plotting.VisualizeMass (PlotSurface2D, ParentDialog.ExoplanetsArray);
                    break;
                case PlotTypes.Radius:
                    Plotting.VisualizeRadius (PlotSurface2D, ParentDialog.ExoplanetsArray);
                    break;
                case PlotTypes.OrbitalPeriod:
                    Plotting.VisualizeOrbitalPeriod (PlotSurface2D, ParentDialog.ExoplanetsArray);
                    break;
                case PlotTypes.SemiMajorAxis:
                    Plotting.VisualizeSemiMajorAxis (PlotSurface2D, ParentDialog.ExoplanetsArray);
                    break;
                case PlotTypes.Eccentricity:
                    Plotting.VisualizeEccentricity (PlotSurface2D, ParentDialog.ExoplanetsArray);
                    break;
                case PlotTypes.AngularDistance:
                    Plotting.VisualizeAngularDistance (PlotSurface2D, ParentDialog.ExoplanetsArray);
                    break;
                case PlotTypes.Inclination:
                    Plotting.VisualizeInclination (PlotSurface2D, ParentDialog.ExoplanetsArray);
                    break;
                case PlotTypes.TzeroTr:
                    Plotting.VisualizeTzeroTr (PlotSurface2D, ParentDialog.ExoplanetsArray);
                    break;
                case PlotTypes.TzeroTrSec:
                    Plotting.VisualizeTzeroTrSec (PlotSurface2D, ParentDialog.ExoplanetsArray);
                    break;
                case PlotTypes.LambdaAngle:
                    Plotting.VisualizeLambdaAngle (PlotSurface2D, ParentDialog.ExoplanetsArray);
                    break;
                case PlotTypes.TzeroVr:
                    Plotting.VisualizeTzeroVr (PlotSurface2D, ParentDialog.ExoplanetsArray);
                    break;
                case PlotTypes.TemperatureCalculated:
                    Plotting.VisualizeTemperatureCalculated (PlotSurface2D, ParentDialog.ExoplanetsArray);
                    break;
                case PlotTypes.TemperatureMeasured:
                    Plotting.VisualizeTemperatureMeasured (PlotSurface2D, ParentDialog.ExoplanetsArray);
                    break;
                case PlotTypes.LogG:
                    Plotting.VisualizeLogG (PlotSurface2D, ParentDialog.ExoplanetsArray);
                    break;
                case PlotTypes.Omega:
                    Plotting.VisualizeOmega (PlotSurface2D, ParentDialog.ExoplanetsArray);
                    break;
                case PlotTypes.Tperi:
                    Plotting.VisualizeTperi (PlotSurface2D, ParentDialog.ExoplanetsArray);
                    break;
                case PlotTypes.K:
                    Plotting.VisualizeK (PlotSurface2D, ParentDialog.ExoplanetsArray);
                    break;
                case PlotTypes.GeometricAlbedo:
                    Plotting.VisualizeGeometricAlbedo (PlotSurface2D, ParentDialog.ExoplanetsArray);
                    break;
                case PlotTypes.Tconj:
                    Plotting.VisualizeTconj (PlotSurface2D, ParentDialog.ExoplanetsArray);
                    break;
                case PlotTypes.Stars:
                    Plotting.VisualizeStars (PlotSurface2D, ParentDialog.ExoplanetsArray);
                    break;
                case PlotTypes.MassAndRadius:
                    Plotting.VisualizeMassAndRadius (PlotSurface2D, ParentDialog.ExoplanetsArray);
                    break;
                case PlotTypes.EccentricityAndMass:
                    Plotting.VisualizeEccentricityAndMass (PlotSurface2D, ParentDialog.ExoplanetsArray);
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

                if(PlotType == PlotTypes.Stars)
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
            }

        }
    }
