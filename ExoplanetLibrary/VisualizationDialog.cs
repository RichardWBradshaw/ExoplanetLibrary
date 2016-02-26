﻿using System;
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

        ///

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

        private void visualizeMassVersusTzeroTr_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.MassAndTzeroTr;
            RefreshGraphics ();
            }

        private void visualizeMassVersusTperi_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.MassAndTperi;
            RefreshGraphics ();
            }

        private void visualizeMassVersusK_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.MassAndK;
            RefreshGraphics ();
            }

        ///

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

        private void visualizeRadiusVersusTzeroTr_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.RadiusAndTzeroTr;
            RefreshGraphics ();
            }

        private void visualizeRadiusVersusTperi_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.RadiusAndTperi;
            RefreshGraphics ();
            }

        private void visualizeRadiusVersusK_Click (object sender, EventArgs e)
            {
            PlotType = PlotTypes.RadiusAndK;
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
                    array = Exoplanets.PlanetsWithMass (Exoplanets.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.Radius:
                    array = Exoplanets.PlanetsWithRadius (Exoplanets.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.OrbitalPeriod:
                    array = Exoplanets.PlanetsWithOrbitalPeriods (Exoplanets.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.SemiMajorAxis:
                    array = Exoplanets.PlanetsWithSemiMajorAxis (Exoplanets.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.Eccentricity:
                    array = Exoplanets.PlanetsWithEccentricity (Exoplanets.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.AngularDistance:
                    array = Exoplanets.PlanetsWithAngularDistance (Exoplanets.ExoplanetsArray);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.Inclination:
                    array = Exoplanets.PlanetsWithInclination (Exoplanets.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.TzeroTr:
                    array = Exoplanets.PlanetsWithTzeroTr (Exoplanets.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.TzeroTrSec:
                    array = Exoplanets.PlanetsWithTzeroTrSec (Exoplanets.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.LambdaAngle:
                    array = Exoplanets.PlanetsWithLambdaAngle (Exoplanets.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.TzeroVr:
                    array = Exoplanets.PlanetsWithTzeroVr (Exoplanets.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.TemperatureCalculated:
                    array = Exoplanets.PlanetsWithTemperatureCalculated (Exoplanets.ExoplanetsArray);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.TemperatureMeasured:
                    array = Exoplanets.PlanetsWithTemperatureMeasured (Exoplanets.ExoplanetsArray);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.LogG:
                    array = Exoplanets.PlanetsWithLogG (Exoplanets.ExoplanetsArray);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.Omega:
                    array = Exoplanets.PlanetsWithOmega (Exoplanets.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.Tperi:
                    array = Exoplanets.PlanetsWithTperi (Exoplanets.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.K:
                    array = Exoplanets.PlanetsWithK (Exoplanets.ExoplanetsArray, false, true);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.GeometricAlbedo:
                    array = Exoplanets.PlanetsWithGeometricAlbedo (Exoplanets.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                case PlotTypes.Tconj:
                    array = Exoplanets.PlanetsWithTconj (Exoplanets.ExoplanetsArray, false);
                    Plotting.VisualizeLinearDiagrams (PlotSurface2D, array, PlotType);
                    break;

                //

                case PlotTypes.MassAndRadius:
                    if (( array = Exoplanets.PlanetsWithMass (Exoplanets.ExoplanetsArray, false) ) != null)
                        if (( array = Exoplanets.PlanetsWithRadius (array, false) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.MassAndRadius);
                    break;

                case PlotTypes.MassAndOrbitalPeriod:
                    if (( array = Exoplanets.PlanetsWithMass (Exoplanets.ExoplanetsArray, false) ) != null)
                        if (( array = Exoplanets.PlanetsWithOrbitalPeriods (array, false) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.MassAndOrbitalPeriod);
                    break;

                case PlotTypes.MassAndSemiMajorAxis:
                    if (( array = Exoplanets.PlanetsWithMass (Exoplanets.ExoplanetsArray, false) ) != null)
                        if (( array = Exoplanets.PlanetsWithSemiMajorAxis (array, false) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.MassAndSemiMajorAxis);
                    break;

                case PlotTypes.MassAndEccentricity:
                    if (( array = Exoplanets.PlanetsWithMass (Exoplanets.ExoplanetsArray, false) ) != null)
                        if (( array = Exoplanets.PlanetsWithEccentricity (array, false) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.MassAndEccentricity);
                    break;

                case PlotTypes.MassAndAngularDistance:
                    if (( array = Exoplanets.PlanetsWithMass (Exoplanets.ExoplanetsArray, false) ) != null)
                        if (( array = Exoplanets.PlanetsWithAngularDistance (array) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.MassAndAngularDistance);
                    break;

                case PlotTypes.MassAndOmega:
                    if (( array = Exoplanets.PlanetsWithMass (Exoplanets.ExoplanetsArray, false) ) != null)
                        if (( array = Exoplanets.PlanetsWithOmega (array, false) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.MassAndOmega);
                    break;

                case PlotTypes.MassAndInclination:
                    if (( array = Exoplanets.PlanetsWithMass (Exoplanets.ExoplanetsArray, false) ) != null)
                        if (( array = Exoplanets.PlanetsWithInclination (array, false) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.MassAndInclination);
                    break;

                case PlotTypes.MassAndTzeroTr:
                    if (( array = Exoplanets.PlanetsWithMass (Exoplanets.ExoplanetsArray, false) ) != null)
                        if (( array = Exoplanets.PlanetsWithTzeroTr (array, false) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.MassAndTzeroTr);
                    break;

                case PlotTypes.MassAndTperi:
                    if (( array = Exoplanets.PlanetsWithMass (Exoplanets.ExoplanetsArray, false) ) != null)
                        if (( array = Exoplanets.PlanetsWithTperi (array, false) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.MassAndTperi);
                    break;

                case PlotTypes.MassAndK:
                    if (( array = Exoplanets.PlanetsWithMass (Exoplanets.ExoplanetsArray, false) ) != null)
                        if (( array = Exoplanets.PlanetsWithK (array, false, true) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.MassAndK);
                    break;
                //

                case PlotTypes.RadiusAndMass:
                    if (( array = Exoplanets.PlanetsWithRadius (Exoplanets.ExoplanetsArray, false) ) != null)
                        if (( array = Exoplanets.PlanetsWithMass (array, false) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.RadiusAndMass);
                    break;

                case PlotTypes.RadiusAndOrbitalPeriod:
                    if (( array = Exoplanets.PlanetsWithRadius (Exoplanets.ExoplanetsArray, false) ) != null)
                        if (( array = Exoplanets.PlanetsWithOrbitalPeriods (array, false) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.RadiusAndOrbitalPeriod);
                    break;

                case PlotTypes.RadiusAndSemiMajorAxis:
                    if (( array = Exoplanets.PlanetsWithRadius (Exoplanets.ExoplanetsArray, false) ) != null)
                        if (( array = Exoplanets.PlanetsWithSemiMajorAxis (array, false) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.RadiusAndSemiMajorAxis);
                    break;

                case PlotTypes.RadiusAndEccentricity:
                    if (( array = Exoplanets.PlanetsWithRadius (Exoplanets.ExoplanetsArray, false) ) != null)
                        if (( array = Exoplanets.PlanetsWithEccentricity (array, false) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.RadiusAndEccentricity);
                    break;

                case PlotTypes.RadiusAndAngularDistance:
                    if (( array = Exoplanets.PlanetsWithRadius (Exoplanets.ExoplanetsArray, false) ) != null)
                        if (( array = Exoplanets.PlanetsWithAngularDistance (array) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.RadiusAndAngularDistance);
                    break;

                case PlotTypes.RadiusAndOmega:
                    if (( array = Exoplanets.PlanetsWithRadius (Exoplanets.ExoplanetsArray, false) ) != null)
                        if (( array = Exoplanets.PlanetsWithOmega (array, false) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.RadiusAndOmega);
                    break;

                case PlotTypes.RadiusAndInclination:
                    if (( array = Exoplanets.PlanetsWithRadius (Exoplanets.ExoplanetsArray, false) ) != null)
                        if (( array = Exoplanets.PlanetsWithInclination (array, false) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.RadiusAndInclination);
                    break;

                case PlotTypes.RadiusAndTzeroTr:
                    if (( array = Exoplanets.PlanetsWithRadius (Exoplanets.ExoplanetsArray, false) ) != null)
                        if (( array = Exoplanets.PlanetsWithTzeroTr (array, false) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.RadiusAndTzeroTr);
                    break;

                case PlotTypes.RadiusAndTperi:
                    if (( array = Exoplanets.PlanetsWithRadius (Exoplanets.ExoplanetsArray, false) ) != null)
                        if (( array = Exoplanets.PlanetsWithTperi (array, false) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.RadiusAndTperi);
                    break;

                case PlotTypes.RadiusAndK:
                    if (( array = Exoplanets.PlanetsWithRadius (Exoplanets.ExoplanetsArray, false) ) != null)
                        if (( array = Exoplanets.PlanetsWithK (array, false, true) ) != null)
                            Plotting.VisualizePointDiagrams (PlotSurface2D, array, PlotTypes.RadiusAndK);
                    break;

                //

                case PlotTypes.Stars:
                    Plotting.VisualizeStars (PlotSurface2D, Exoplanets.ExoplanetsArray);
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

        private void visualizeCopyToClipBoard_Click (object sender, EventArgs e)
            {
            PlotSurface2D.CopyToClipboard ();
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
