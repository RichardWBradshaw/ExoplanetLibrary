﻿namespace ExoplanetLibrary
    {
    partial class VisualizationDialog
        {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose (bool disposing)
            {
            if (disposing && ( components != null ))
                components.Dispose ();

            base.Dispose (disposing);
            }

        private void InitializeComponent ()
            {
            this.PlotSurface2D = new NPlot.Windows.PlotSurface2D();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.visualizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radiiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orbitalPeriodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.semiMajorAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eccentricityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.angularDistanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inclinationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.omegaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcalcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightAccessionVsDeclinationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.massVsRadiusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massVsOrbitalPeriodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massVsSemiMajorAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massVsEccentricityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massVsAngularDistanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massVsInclinationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massVsOmegaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massVsKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.radiusVsMassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radiusVsOrbitalPeriodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radiusVsSemiMajorAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radiusVsEccentricityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radiusVsAngularDistanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radiusVsInclinationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radiusVsOmegaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radiusVsKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logXAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logYAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.includeNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeErrorBarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeDuplicatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.includeBestFitLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeBestFitCurveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilizeQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlotSurface2D
            // 
            this.PlotSurface2D.AutoScaleAutoGeneratedAxes = false;
            this.PlotSurface2D.AutoScaleTitle = false;
            this.PlotSurface2D.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PlotSurface2D.DateTimeToolTip = false;
            this.PlotSurface2D.Legend = null;
            this.PlotSurface2D.LegendZOrder = -1;
            this.PlotSurface2D.Location = new System.Drawing.Point(0, 27);
            this.PlotSurface2D.Name = "PlotSurface2D";
            this.PlotSurface2D.RightMenu = null;
            this.PlotSurface2D.ShowCoordinates = true;
            this.PlotSurface2D.Size = new System.Drawing.Size(885, 430);
            this.PlotSurface2D.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            this.PlotSurface2D.TabIndex = 0;
            this.PlotSurface2D.Text = "PlotSurface2D";
            this.PlotSurface2D.Title = "";
            this.PlotSurface2D.TitleFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.PlotSurface2D.XAxis1 = null;
            this.PlotSurface2D.XAxis2 = null;
            this.PlotSurface2D.YAxis1 = null;
            this.PlotSurface2D.YAxis2 = null;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualizationToolStripMenuItem,
            this.pointToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(884, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // visualizationToolStripMenuItem
            // 
            this.visualizationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.massToolStripMenuItem,
            this.radiiToolStripMenuItem,
            this.orbitalPeriodToolStripMenuItem,
            this.semiMajorAxisToolStripMenuItem,
            this.eccentricityToolStripMenuItem,
            this.angularDistanceToolStripMenuItem,
            this.inclinationToolStripMenuItem,
            this.omegaToolStripMenuItem,
            this.kToolStripMenuItem,
            this.tcalcToolStripMenuItem});
            this.visualizationToolStripMenuItem.Name = "visualizationToolStripMenuItem";
            this.visualizationToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.visualizationToolStripMenuItem.Text = "Linear Diagrams";
            // 
            // massToolStripMenuItem
            // 
            this.massToolStripMenuItem.Name = "massToolStripMenuItem";
            this.massToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.massToolStripMenuItem.Text = "Mass";
            this.massToolStripMenuItem.Click += new System.EventHandler(this.visualizeMass_Click);
            // 
            // radiiToolStripMenuItem
            // 
            this.radiiToolStripMenuItem.Name = "radiiToolStripMenuItem";
            this.radiiToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.radiiToolStripMenuItem.Text = "Radius";
            this.radiiToolStripMenuItem.Click += new System.EventHandler(this.visualizeRadii_Click);
            // 
            // orbitalPeriodToolStripMenuItem
            // 
            this.orbitalPeriodToolStripMenuItem.Name = "orbitalPeriodToolStripMenuItem";
            this.orbitalPeriodToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.orbitalPeriodToolStripMenuItem.Text = "Orbital Period";
            this.orbitalPeriodToolStripMenuItem.Click += new System.EventHandler(this.visualizeOrbitalPeriod_Click);
            // 
            // semiMajorAxisToolStripMenuItem
            // 
            this.semiMajorAxisToolStripMenuItem.Name = "semiMajorAxisToolStripMenuItem";
            this.semiMajorAxisToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.semiMajorAxisToolStripMenuItem.Text = "Semi-Major Axis";
            this.semiMajorAxisToolStripMenuItem.Click += new System.EventHandler(this.visualizeSemiMajorAxis_Click);
            // 
            // eccentricityToolStripMenuItem
            // 
            this.eccentricityToolStripMenuItem.Name = "eccentricityToolStripMenuItem";
            this.eccentricityToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.eccentricityToolStripMenuItem.Text = "Eccentricity";
            this.eccentricityToolStripMenuItem.Click += new System.EventHandler(this.visualizeEccentricity_Click);
            // 
            // angularDistanceToolStripMenuItem
            // 
            this.angularDistanceToolStripMenuItem.Name = "angularDistanceToolStripMenuItem";
            this.angularDistanceToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.angularDistanceToolStripMenuItem.Text = "Angular Distance";
            this.angularDistanceToolStripMenuItem.Click += new System.EventHandler(this.visualizeAngularDistance_Click);
            // 
            // inclinationToolStripMenuItem
            // 
            this.inclinationToolStripMenuItem.Name = "inclinationToolStripMenuItem";
            this.inclinationToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.inclinationToolStripMenuItem.Text = "Inclination";
            this.inclinationToolStripMenuItem.Click += new System.EventHandler(this.visualizeInclination_Click);
            // 
            // omegaToolStripMenuItem
            // 
            this.omegaToolStripMenuItem.Name = "omegaToolStripMenuItem";
            this.omegaToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.omegaToolStripMenuItem.Text = "Omega";
            this.omegaToolStripMenuItem.Click += new System.EventHandler(this.visualizeOmega_Click);
            // 
            // kToolStripMenuItem
            // 
            this.kToolStripMenuItem.Name = "kToolStripMenuItem";
            this.kToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.kToolStripMenuItem.Text = "Velocity Semiamplitude";
            this.kToolStripMenuItem.Click += new System.EventHandler(this.visualizeK_Click);
            // 
            // tcalcToolStripMenuItem
            // 
            this.tcalcToolStripMenuItem.Name = "tcalcToolStripMenuItem";
            this.tcalcToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.tcalcToolStripMenuItem.Text = "Calculated Temperature";
            this.tcalcToolStripMenuItem.Click += new System.EventHandler(this.visualizeTcalc_Click);
            // 
            // pointToolStripMenuItem
            // 
            this.pointToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rightAccessionVsDeclinationToolStripMenuItem,
            this.toolStripSeparator3,
            this.massVsRadiusToolStripMenuItem,
            this.massVsOrbitalPeriodToolStripMenuItem,
            this.massVsSemiMajorAxisToolStripMenuItem,
            this.massVsEccentricityToolStripMenuItem,
            this.massVsAngularDistanceToolStripMenuItem,
            this.massVsInclinationToolStripMenuItem,
            this.massVsOmegaToolStripMenuItem,
            this.massVsKToolStripMenuItem,
            this.toolStripSeparator4,
            this.radiusVsMassToolStripMenuItem,
            this.radiusVsOrbitalPeriodToolStripMenuItem,
            this.radiusVsSemiMajorAxisToolStripMenuItem,
            this.radiusVsEccentricityToolStripMenuItem,
            this.radiusVsAngularDistanceToolStripMenuItem,
            this.radiusVsInclinationToolStripMenuItem,
            this.radiusVsOmegaToolStripMenuItem,
            this.radiusVsKToolStripMenuItem});
            this.pointToolStripMenuItem.Name = "pointToolStripMenuItem";
            this.pointToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.pointToolStripMenuItem.Text = "Point Diagrams";
            // 
            // rightAccessionVsDeclinationToolStripMenuItem
            // 
            this.rightAccessionVsDeclinationToolStripMenuItem.Name = "rightAccessionVsDeclinationToolStripMenuItem";
            this.rightAccessionVsDeclinationToolStripMenuItem.ShowShortcutKeys = false;
            this.rightAccessionVsDeclinationToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.rightAccessionVsDeclinationToolStripMenuItem.Text = "Stars";
            this.rightAccessionVsDeclinationToolStripMenuItem.Click += new System.EventHandler(this.visualizeStars_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(247, 6);
            // 
            // massVsRadiusToolStripMenuItem
            // 
            this.massVsRadiusToolStripMenuItem.Name = "massVsRadiusToolStripMenuItem";
            this.massVsRadiusToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.massVsRadiusToolStripMenuItem.Text = "Mass vs Radius";
            this.massVsRadiusToolStripMenuItem.Click += new System.EventHandler(this.visualizeMassVersusRadius_Click);
            // 
            // massVsOrbitalPeriodToolStripMenuItem
            // 
            this.massVsOrbitalPeriodToolStripMenuItem.Name = "massVsOrbitalPeriodToolStripMenuItem";
            this.massVsOrbitalPeriodToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.massVsOrbitalPeriodToolStripMenuItem.Text = "Mass vs Orbital Period";
            this.massVsOrbitalPeriodToolStripMenuItem.Click += new System.EventHandler(this.visualizeMassVersusOrbitalPeriod_Click);
            // 
            // massVsSemiMajorAxisToolStripMenuItem
            // 
            this.massVsSemiMajorAxisToolStripMenuItem.Name = "massVsSemiMajorAxisToolStripMenuItem";
            this.massVsSemiMajorAxisToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.massVsSemiMajorAxisToolStripMenuItem.Text = "Mass vs Semi-Major Axis";
            this.massVsSemiMajorAxisToolStripMenuItem.Click += new System.EventHandler(this.visualizeMassVersusSemiMajorAxis_Click);
            // 
            // massVsEccentricityToolStripMenuItem
            // 
            this.massVsEccentricityToolStripMenuItem.Name = "massVsEccentricityToolStripMenuItem";
            this.massVsEccentricityToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.massVsEccentricityToolStripMenuItem.Text = "Mass vs Eccentricity";
            this.massVsEccentricityToolStripMenuItem.Click += new System.EventHandler(this.visualizeMassVersusEccentricity_Click);
            // 
            // massVsAngularDistanceToolStripMenuItem
            // 
            this.massVsAngularDistanceToolStripMenuItem.Name = "massVsAngularDistanceToolStripMenuItem";
            this.massVsAngularDistanceToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.massVsAngularDistanceToolStripMenuItem.Text = "Mass vs Angular Distance";
            this.massVsAngularDistanceToolStripMenuItem.Click += new System.EventHandler(this.visualizeMassVersusAngularDistance_Click);
            // 
            // massVsInclinationToolStripMenuItem
            // 
            this.massVsInclinationToolStripMenuItem.Name = "massVsInclinationToolStripMenuItem";
            this.massVsInclinationToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.massVsInclinationToolStripMenuItem.Text = "Mass vs Inclination";
            this.massVsInclinationToolStripMenuItem.Click += new System.EventHandler(this.visualizeMassVersusInclination_Click);
            // 
            // massVsOmegaToolStripMenuItem
            // 
            this.massVsOmegaToolStripMenuItem.Name = "massVsOmegaToolStripMenuItem";
            this.massVsOmegaToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.massVsOmegaToolStripMenuItem.Text = "Mass vs Omega";
            this.massVsOmegaToolStripMenuItem.Click += new System.EventHandler(this.visualizeMassVersusOmega_Click);
            // 
            // massVsKToolStripMenuItem
            // 
            this.massVsKToolStripMenuItem.Name = "massVsKToolStripMenuItem";
            this.massVsKToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.massVsKToolStripMenuItem.Text = "Mass vs Velocity Semiamplitude";
            this.massVsKToolStripMenuItem.Click += new System.EventHandler(this.visualizeMassVersusK_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(247, 6);
            // 
            // radiusVsMassToolStripMenuItem
            // 
            this.radiusVsMassToolStripMenuItem.Name = "radiusVsMassToolStripMenuItem";
            this.radiusVsMassToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.radiusVsMassToolStripMenuItem.Text = "Radius vs Mass";
            this.radiusVsMassToolStripMenuItem.Click += new System.EventHandler(this.visualizeRadiusVersusMass_Click);
            // 
            // radiusVsOrbitalPeriodToolStripMenuItem
            // 
            this.radiusVsOrbitalPeriodToolStripMenuItem.Name = "radiusVsOrbitalPeriodToolStripMenuItem";
            this.radiusVsOrbitalPeriodToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.radiusVsOrbitalPeriodToolStripMenuItem.Text = "Radius vs Orbital Period";
            this.radiusVsOrbitalPeriodToolStripMenuItem.Click += new System.EventHandler(this.visualizeRadiusVersusOrbitalPeriod_Click);
            // 
            // radiusVsSemiMajorAxisToolStripMenuItem
            // 
            this.radiusVsSemiMajorAxisToolStripMenuItem.Name = "radiusVsSemiMajorAxisToolStripMenuItem";
            this.radiusVsSemiMajorAxisToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.radiusVsSemiMajorAxisToolStripMenuItem.Text = "Radius vs Semi-Major Axis";
            this.radiusVsSemiMajorAxisToolStripMenuItem.Click += new System.EventHandler(this.visualizeRadiusVersusSemiMajorAxis_Click);
            // 
            // radiusVsEccentricityToolStripMenuItem
            // 
            this.radiusVsEccentricityToolStripMenuItem.Name = "radiusVsEccentricityToolStripMenuItem";
            this.radiusVsEccentricityToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.radiusVsEccentricityToolStripMenuItem.Text = "Radius vs Eccentricity";
            this.radiusVsEccentricityToolStripMenuItem.Click += new System.EventHandler(this.visualizeRadiusVersusEccentricity_Click);
            // 
            // radiusVsAngularDistanceToolStripMenuItem
            // 
            this.radiusVsAngularDistanceToolStripMenuItem.Name = "radiusVsAngularDistanceToolStripMenuItem";
            this.radiusVsAngularDistanceToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.radiusVsAngularDistanceToolStripMenuItem.Text = "Radius vs Angular Distance";
            this.radiusVsAngularDistanceToolStripMenuItem.Click += new System.EventHandler(this.visualizeRadiusVersusAngularDistance_Click);
            // 
            // radiusVsInclinationToolStripMenuItem
            // 
            this.radiusVsInclinationToolStripMenuItem.Name = "radiusVsInclinationToolStripMenuItem";
            this.radiusVsInclinationToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.radiusVsInclinationToolStripMenuItem.Text = "Radius vs Inclination";
            this.radiusVsInclinationToolStripMenuItem.Click += new System.EventHandler(this.visualizeRadiusVersusInclination_Click);
            // 
            // radiusVsOmegaToolStripMenuItem
            // 
            this.radiusVsOmegaToolStripMenuItem.Name = "radiusVsOmegaToolStripMenuItem";
            this.radiusVsOmegaToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.radiusVsOmegaToolStripMenuItem.Text = "Radius vs Omega";
            this.radiusVsOmegaToolStripMenuItem.Click += new System.EventHandler(this.visualizeRadiusVersusOmega_Click);
            // 
            // radiusVsKToolStripMenuItem
            // 
            this.radiusVsKToolStripMenuItem.Name = "radiusVsKToolStripMenuItem";
            this.radiusVsKToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.radiusVsKToolStripMenuItem.Text = "Radius vs Velocity Semiamplitude";
            this.radiusVsKToolStripMenuItem.Click += new System.EventHandler(this.visualizeRadiusVersusK_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logXAxisToolStripMenuItem,
            this.logYAxisToolStripMenuItem,
            this.toolStripSeparator1,
            this.includeNamesToolStripMenuItem,
            this.includeErrorBarsToolStripMenuItem,
            this.includeDuplicatesToolStripMenuItem,
            this.toolStripSeparator5,
            this.utilizeQueryToolStripMenuItem,
            this.toolStripSeparator2,
            this.includeBestFitLineToolStripMenuItem,
            this.includeBestFitCurveToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.settingsToolStripMenuItem.Text = "Settings...";
            // 
            // logXAxisToolStripMenuItem
            // 
            this.logXAxisToolStripMenuItem.Name = "logXAxisToolStripMenuItem";
            this.logXAxisToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.logXAxisToolStripMenuItem.Text = "Log X Axis";
            this.logXAxisToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.logXAxisToolStripMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // logYAxisToolStripMenuItem
            // 
            this.logYAxisToolStripMenuItem.Name = "logYAxisToolStripMenuItem";
            this.logYAxisToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.logYAxisToolStripMenuItem.Text = "Log Y Axis";
            this.logYAxisToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.logYAxisToolStripMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(185, 6);
            // 
            // includeNamesToolStripMenuItem
            // 
            this.includeNamesToolStripMenuItem.Name = "includeNamesToolStripMenuItem";
            this.includeNamesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.includeNamesToolStripMenuItem.Text = "Include Names";
            this.includeNamesToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.includeNamesToolStripMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // includeErrorBarsToolStripMenuItem
            // 
            this.includeErrorBarsToolStripMenuItem.Name = "includeErrorBarsToolStripMenuItem";
            this.includeErrorBarsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.includeErrorBarsToolStripMenuItem.Text = "Include Error Bars";
            this.includeErrorBarsToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.includeErrorBarsToolStripMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // includeDuplicatesToolStripMenuItem
            // 
            this.includeDuplicatesToolStripMenuItem.Name = "includeDuplicatesToolStripMenuItem";
            this.includeDuplicatesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.includeDuplicatesToolStripMenuItem.Text = "Include Duplicates";
            this.includeDuplicatesToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.includeDuplicatesToolStripMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(185, 6);
            // 
            // includeBestFitLineToolStripMenuItem
            // 
            this.includeBestFitLineToolStripMenuItem.Name = "includeBestFitLineToolStripMenuItem";
            this.includeBestFitLineToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.includeBestFitLineToolStripMenuItem.Text = "Include Best Fit Line";
            this.includeBestFitLineToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.includeBestFitLineToolStripMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // includeBestFitCurveToolStripMenuItem
            // 
            this.includeBestFitCurveToolStripMenuItem.Name = "includeBestFitCurveToolStripMenuItem";
            this.includeBestFitCurveToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.includeBestFitCurveToolStripMenuItem.Text = "Include Best Fit Curve";
            this.includeBestFitCurveToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.includeBestFitCurveToolStripMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // utilizeQueryToolStripMenuItem
            // 
            this.utilizeQueryToolStripMenuItem.Name = "utilizeQueryToolStripMenuItem";
            this.utilizeQueryToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.utilizeQueryToolStripMenuItem.Text = "Utilize Query";
            this.utilizeQueryToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.utilizeQueryToolStripMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(185, 6);
            // 
            // VisualizationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.PlotSurface2D);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "VisualizationDialog";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Visualization";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Visualization_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        public NPlot.Windows.PlotSurface2D PlotSurface2D;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem visualizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem massToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radiiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orbitalPeriodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem semiMajorAxisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eccentricityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem angularDistanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inclinationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tcalcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem omegaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem massVsRadiusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem massVsEccentricityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightAccessionVsDeclinationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem includeErrorBarsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logXAxisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logYAxisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem massVsOrbitalPeriodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem massVsSemiMajorAxisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem massVsAngularDistanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem massVsOmegaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem radiusVsMassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radiusVsOrbitalPeriodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radiusVsSemiMajorAxisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radiusVsEccentricityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radiusVsAngularDistanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radiusVsOmegaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem massVsInclinationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem massVsKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radiusVsInclinationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radiusVsKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem includeDuplicatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem includeBestFitLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem includeBestFitCurveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem includeNamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem utilizeQueryToolStripMenuItem;
        }
    }