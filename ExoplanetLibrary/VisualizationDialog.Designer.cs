namespace ExoplanetLibrary
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
            this.t0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.t0secToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lambdaAngleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tvrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcalcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmeasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loggToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.omegaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tperiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geometricAlbedoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tconjToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightAccessionVsDeclinationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.massVsRadiusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massVsOrbitalPeriodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massVsSemiMajorAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massVsEccentricityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massVsAngularDistanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massVsOmegaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massVsInclinationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massVsT0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massVsTperiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massVsKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.radiusVsMassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radiusVsOrbitalPeriodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radiusVsSemiMajorAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radiusVsEccentricityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radiusVsAngularDistanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radiusVsOmegaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radiusVsInclinationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radiusVsT0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radiusVsTperiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radiusVsKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorBarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorFromStarTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logXAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logYAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeDuplicatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.t0ToolStripMenuItem,
            this.t0secToolStripMenuItem,
            this.lambdaAngleToolStripMenuItem,
            this.tvrToolStripMenuItem,
            this.tcalcToolStripMenuItem,
            this.tmeasToolStripMenuItem,
            this.loggToolStripMenuItem,
            this.omegaToolStripMenuItem,
            this.tperiToolStripMenuItem,
            this.kToolStripMenuItem,
            this.geometricAlbedoToolStripMenuItem,
            this.tconjToolStripMenuItem});
            this.visualizationToolStripMenuItem.Name = "visualizationToolStripMenuItem";
            this.visualizationToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.visualizationToolStripMenuItem.Text = "Linear Diagrams";
            // 
            // massToolStripMenuItem
            // 
            this.massToolStripMenuItem.Name = "massToolStripMenuItem";
            this.massToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.massToolStripMenuItem.Text = "Mass";
            this.massToolStripMenuItem.Click += new System.EventHandler(this.visualizeMass_Click);
            // 
            // radiiToolStripMenuItem
            // 
            this.radiiToolStripMenuItem.Name = "radiiToolStripMenuItem";
            this.radiiToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.radiiToolStripMenuItem.Text = "Radii";
            this.radiiToolStripMenuItem.Click += new System.EventHandler(this.visualizeRadii_Click);
            // 
            // orbitalPeriodToolStripMenuItem
            // 
            this.orbitalPeriodToolStripMenuItem.Name = "orbitalPeriodToolStripMenuItem";
            this.orbitalPeriodToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.orbitalPeriodToolStripMenuItem.Text = "Orbital Period";
            this.orbitalPeriodToolStripMenuItem.Click += new System.EventHandler(this.visualizeOrbitalPeriod_Click);
            // 
            // semiMajorAxisToolStripMenuItem
            // 
            this.semiMajorAxisToolStripMenuItem.Name = "semiMajorAxisToolStripMenuItem";
            this.semiMajorAxisToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.semiMajorAxisToolStripMenuItem.Text = "Semi-Major Axis";
            this.semiMajorAxisToolStripMenuItem.Click += new System.EventHandler(this.visualizeSemiMajorAxis_Click);
            // 
            // eccentricityToolStripMenuItem
            // 
            this.eccentricityToolStripMenuItem.Name = "eccentricityToolStripMenuItem";
            this.eccentricityToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.eccentricityToolStripMenuItem.Text = "Eccentricity";
            this.eccentricityToolStripMenuItem.Click += new System.EventHandler(this.visualizeEccentricity_Click);
            // 
            // angularDistanceToolStripMenuItem
            // 
            this.angularDistanceToolStripMenuItem.Name = "angularDistanceToolStripMenuItem";
            this.angularDistanceToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.angularDistanceToolStripMenuItem.Text = "Angular Distance";
            this.angularDistanceToolStripMenuItem.Click += new System.EventHandler(this.visualizeAngularDistance_Click);
            // 
            // inclinationToolStripMenuItem
            // 
            this.inclinationToolStripMenuItem.Name = "inclinationToolStripMenuItem";
            this.inclinationToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.inclinationToolStripMenuItem.Text = "Inclination";
            this.inclinationToolStripMenuItem.Click += new System.EventHandler(this.visualizeInclination_Click);
            // 
            // t0ToolStripMenuItem
            // 
            this.t0ToolStripMenuItem.Name = "t0ToolStripMenuItem";
            this.t0ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.t0ToolStripMenuItem.Text = "T0";
            this.t0ToolStripMenuItem.Click += new System.EventHandler(this.visualizeT0_Click);
            // 
            // t0secToolStripMenuItem
            // 
            this.t0secToolStripMenuItem.Name = "t0secToolStripMenuItem";
            this.t0secToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.t0secToolStripMenuItem.Text = "T0-sec";
            this.t0secToolStripMenuItem.Click += new System.EventHandler(this.visualizeT0sec_Click);
            // 
            // lambdaAngleToolStripMenuItem
            // 
            this.lambdaAngleToolStripMenuItem.Name = "lambdaAngleToolStripMenuItem";
            this.lambdaAngleToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.lambdaAngleToolStripMenuItem.Text = "Lambda Angle";
            this.lambdaAngleToolStripMenuItem.Click += new System.EventHandler(this.visualizeLambdaAngle_Click);
            // 
            // tvrToolStripMenuItem
            // 
            this.tvrToolStripMenuItem.Name = "tvrToolStripMenuItem";
            this.tvrToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.tvrToolStripMenuItem.Text = "Tvr";
            this.tvrToolStripMenuItem.Click += new System.EventHandler(this.visualizeTvr_Click);
            // 
            // tcalcToolStripMenuItem
            // 
            this.tcalcToolStripMenuItem.Name = "tcalcToolStripMenuItem";
            this.tcalcToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.tcalcToolStripMenuItem.Text = "Tcalc";
            this.tcalcToolStripMenuItem.Click += new System.EventHandler(this.visualizeTcalc_Click);
            // 
            // tmeasToolStripMenuItem
            // 
            this.tmeasToolStripMenuItem.Name = "tmeasToolStripMenuItem";
            this.tmeasToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.tmeasToolStripMenuItem.Text = "Tmeas";
            this.tmeasToolStripMenuItem.Click += new System.EventHandler(this.visualizeTmeas_Click);
            // 
            // loggToolStripMenuItem
            // 
            this.loggToolStripMenuItem.Name = "loggToolStripMenuItem";
            this.loggToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.loggToolStripMenuItem.Text = "Log(g)";
            this.loggToolStripMenuItem.Click += new System.EventHandler(this.visualizeLogG_Click);
            // 
            // omegaToolStripMenuItem
            // 
            this.omegaToolStripMenuItem.Name = "omegaToolStripMenuItem";
            this.omegaToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.omegaToolStripMenuItem.Text = "Omega";
            this.omegaToolStripMenuItem.Click += new System.EventHandler(this.visualizeOmega_Click);
            // 
            // tperiToolStripMenuItem
            // 
            this.tperiToolStripMenuItem.Name = "tperiToolStripMenuItem";
            this.tperiToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.tperiToolStripMenuItem.Text = "Tperi";
            this.tperiToolStripMenuItem.Click += new System.EventHandler(this.visualizeTperi_Click);
            // 
            // kToolStripMenuItem
            // 
            this.kToolStripMenuItem.Name = "kToolStripMenuItem";
            this.kToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.kToolStripMenuItem.Text = "K";
            this.kToolStripMenuItem.Click += new System.EventHandler(this.visualizeK_Click);
            // 
            // geometricAlbedoToolStripMenuItem
            // 
            this.geometricAlbedoToolStripMenuItem.Name = "geometricAlbedoToolStripMenuItem";
            this.geometricAlbedoToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.geometricAlbedoToolStripMenuItem.Text = "Geometric Albedo";
            this.geometricAlbedoToolStripMenuItem.Click += new System.EventHandler(this.visualizeGeometricAlbedo_Click);
            // 
            // tconjToolStripMenuItem
            // 
            this.tconjToolStripMenuItem.Name = "tconjToolStripMenuItem";
            this.tconjToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.tconjToolStripMenuItem.Text = "Tconj";
            this.tconjToolStripMenuItem.Click += new System.EventHandler(this.visualizeTconj_Click);
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
            this.massVsOmegaToolStripMenuItem,
            this.massVsInclinationToolStripMenuItem,
            this.massVsT0ToolStripMenuItem,
            this.massVsTperiToolStripMenuItem,
            this.massVsKToolStripMenuItem,
            this.toolStripSeparator4,
            this.radiusVsMassToolStripMenuItem,
            this.radiusVsOrbitalPeriodToolStripMenuItem,
            this.radiusVsSemiMajorAxisToolStripMenuItem,
            this.radiusVsEccentricityToolStripMenuItem,
            this.radiusVsAngularDistanceToolStripMenuItem,
            this.radiusVsOmegaToolStripMenuItem,
            this.radiusVsInclinationToolStripMenuItem,
            this.radiusVsT0ToolStripMenuItem,
            this.radiusVsTperiToolStripMenuItem,
            this.radiusVsKToolStripMenuItem});
            this.pointToolStripMenuItem.Name = "pointToolStripMenuItem";
            this.pointToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.pointToolStripMenuItem.Text = "Point Diagrams";
            // 
            // rightAccessionVsDeclinationToolStripMenuItem
            // 
            this.rightAccessionVsDeclinationToolStripMenuItem.Name = "rightAccessionVsDeclinationToolStripMenuItem";
            this.rightAccessionVsDeclinationToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.rightAccessionVsDeclinationToolStripMenuItem.Text = "Right Accession vs Declination";
            this.rightAccessionVsDeclinationToolStripMenuItem.Click += new System.EventHandler(this.visualizeStars_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(232, 6);
            // 
            // massVsRadiusToolStripMenuItem
            // 
            this.massVsRadiusToolStripMenuItem.Name = "massVsRadiusToolStripMenuItem";
            this.massVsRadiusToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.massVsRadiusToolStripMenuItem.Text = "Mass vs Radius";
            this.massVsRadiusToolStripMenuItem.Click += new System.EventHandler(this.visualizeMassVersusRadius_Click);
            // 
            // massVsOrbitalPeriodToolStripMenuItem
            // 
            this.massVsOrbitalPeriodToolStripMenuItem.Name = "massVsOrbitalPeriodToolStripMenuItem";
            this.massVsOrbitalPeriodToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.massVsOrbitalPeriodToolStripMenuItem.Text = "Mass vs Orbital Period";
            this.massVsOrbitalPeriodToolStripMenuItem.Click += new System.EventHandler(this.visualizeMassVersusOrbitalPeriod_Click);
            // 
            // massVsSemiMajorAxisToolStripMenuItem
            // 
            this.massVsSemiMajorAxisToolStripMenuItem.Name = "massVsSemiMajorAxisToolStripMenuItem";
            this.massVsSemiMajorAxisToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.massVsSemiMajorAxisToolStripMenuItem.Text = "Mass vs Semi-Major Axis";
            this.massVsSemiMajorAxisToolStripMenuItem.Click += new System.EventHandler(this.visualizeMassVersusSemiMajorAxis_Click);
            // 
            // massVsEccentricityToolStripMenuItem
            // 
            this.massVsEccentricityToolStripMenuItem.Name = "massVsEccentricityToolStripMenuItem";
            this.massVsEccentricityToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.massVsEccentricityToolStripMenuItem.Text = "Mass vs Eccentricity";
            this.massVsEccentricityToolStripMenuItem.Click += new System.EventHandler(this.visualizeMassVersusEccentricity_Click);
            // 
            // massVsAngularDistanceToolStripMenuItem
            // 
            this.massVsAngularDistanceToolStripMenuItem.Name = "massVsAngularDistanceToolStripMenuItem";
            this.massVsAngularDistanceToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.massVsAngularDistanceToolStripMenuItem.Text = "Mass vs Angular Distance";
            this.massVsAngularDistanceToolStripMenuItem.Click += new System.EventHandler(this.visualizeMassVersusAngularDistance_Click);
            // 
            // massVsOmegaToolStripMenuItem
            // 
            this.massVsOmegaToolStripMenuItem.Name = "massVsOmegaToolStripMenuItem";
            this.massVsOmegaToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.massVsOmegaToolStripMenuItem.Text = "Mass vs Omega";
            this.massVsOmegaToolStripMenuItem.Click += new System.EventHandler(this.visualizeMassVersusOmega_Click);
            // 
            // massVsInclinationToolStripMenuItem
            // 
            this.massVsInclinationToolStripMenuItem.Name = "massVsInclinationToolStripMenuItem";
            this.massVsInclinationToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.massVsInclinationToolStripMenuItem.Text = "Mass vs Inclination";
            this.massVsInclinationToolStripMenuItem.Click += new System.EventHandler(this.visualizeMassVersusInclination_Click);
            // 
            // massVsT0ToolStripMenuItem
            // 
            this.massVsT0ToolStripMenuItem.Name = "massVsT0ToolStripMenuItem";
            this.massVsT0ToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.massVsT0ToolStripMenuItem.Text = "Mass vs T0";
            this.massVsT0ToolStripMenuItem.Click += new System.EventHandler(this.visualizeMassVersusTzeroTr_Click);
            // 
            // massVsTperiToolStripMenuItem
            // 
            this.massVsTperiToolStripMenuItem.Name = "massVsTperiToolStripMenuItem";
            this.massVsTperiToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.massVsTperiToolStripMenuItem.Text = "Mass vs Tperi";
            this.massVsTperiToolStripMenuItem.Click += new System.EventHandler(this.visualizeMassVersusTperi_Click);
            // 
            // massVsKToolStripMenuItem
            // 
            this.massVsKToolStripMenuItem.Name = "massVsKToolStripMenuItem";
            this.massVsKToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.massVsKToolStripMenuItem.Text = "Mass vs K";
            this.massVsKToolStripMenuItem.Click += new System.EventHandler(this.visualizeMassVersusK_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(232, 6);
            // 
            // radiusVsMassToolStripMenuItem
            // 
            this.radiusVsMassToolStripMenuItem.Name = "radiusVsMassToolStripMenuItem";
            this.radiusVsMassToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.radiusVsMassToolStripMenuItem.Text = "Radius vs Mass";
            this.radiusVsMassToolStripMenuItem.Click += new System.EventHandler(this.visualizeRadiusVersusMass_Click);
            // 
            // radiusVsOrbitalPeriodToolStripMenuItem
            // 
            this.radiusVsOrbitalPeriodToolStripMenuItem.Name = "radiusVsOrbitalPeriodToolStripMenuItem";
            this.radiusVsOrbitalPeriodToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.radiusVsOrbitalPeriodToolStripMenuItem.Text = "Radius vs Orbital Period";
            this.radiusVsOrbitalPeriodToolStripMenuItem.Click += new System.EventHandler(this.visualizeRadiusVersusOrbitalPeriod_Click);
            // 
            // radiusVsSemiMajorAxisToolStripMenuItem
            // 
            this.radiusVsSemiMajorAxisToolStripMenuItem.Name = "radiusVsSemiMajorAxisToolStripMenuItem";
            this.radiusVsSemiMajorAxisToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.radiusVsSemiMajorAxisToolStripMenuItem.Text = "Radius vs Semi-Major Axis";
            this.radiusVsSemiMajorAxisToolStripMenuItem.Click += new System.EventHandler(this.visualizeRadiusVersusSemiMajorAxis_Click);
            // 
            // radiusVsEccentricityToolStripMenuItem
            // 
            this.radiusVsEccentricityToolStripMenuItem.Name = "radiusVsEccentricityToolStripMenuItem";
            this.radiusVsEccentricityToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.radiusVsEccentricityToolStripMenuItem.Text = "Radius vs Eccentricity";
            this.radiusVsEccentricityToolStripMenuItem.Click += new System.EventHandler(this.visualizeRadiusVersusEccentricity_Click);
            // 
            // radiusVsAngularDistanceToolStripMenuItem
            // 
            this.radiusVsAngularDistanceToolStripMenuItem.Name = "radiusVsAngularDistanceToolStripMenuItem";
            this.radiusVsAngularDistanceToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.radiusVsAngularDistanceToolStripMenuItem.Text = "Radius vs Angular Distance";
            this.radiusVsAngularDistanceToolStripMenuItem.Click += new System.EventHandler(this.visualizeRadiusVersusAngularDistance_Click);
            // 
            // radiusVsOmegaToolStripMenuItem
            // 
            this.radiusVsOmegaToolStripMenuItem.Name = "radiusVsOmegaToolStripMenuItem";
            this.radiusVsOmegaToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.radiusVsOmegaToolStripMenuItem.Text = "Radius vs Omega";
            this.radiusVsOmegaToolStripMenuItem.Click += new System.EventHandler(this.visualizeRadiusVersusOmega_Click);
            // 
            // radiusVsInclinationToolStripMenuItem
            // 
            this.radiusVsInclinationToolStripMenuItem.Name = "radiusVsInclinationToolStripMenuItem";
            this.radiusVsInclinationToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.radiusVsInclinationToolStripMenuItem.Text = "Radius vs Inclination";
            this.radiusVsInclinationToolStripMenuItem.Click += new System.EventHandler(this.visualizeRadiusVersusInclination_Click);
            // 
            // radiusVsT0ToolStripMenuItem
            // 
            this.radiusVsT0ToolStripMenuItem.Name = "radiusVsT0ToolStripMenuItem";
            this.radiusVsT0ToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.radiusVsT0ToolStripMenuItem.Text = "Radius vs T0";
            this.radiusVsT0ToolStripMenuItem.Click += new System.EventHandler(this.visualizeRadiusVersusTzeroTr_Click);
            // 
            // radiusVsTperiToolStripMenuItem
            // 
            this.radiusVsTperiToolStripMenuItem.Name = "radiusVsTperiToolStripMenuItem";
            this.radiusVsTperiToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.radiusVsTperiToolStripMenuItem.Text = "Radius vs Tperi";
            this.radiusVsTperiToolStripMenuItem.Click += new System.EventHandler(this.visualizeRadiusVersusTperi_Click);
            // 
            // radiusVsKToolStripMenuItem
            // 
            this.radiusVsKToolStripMenuItem.Name = "radiusVsKToolStripMenuItem";
            this.radiusVsKToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.radiusVsKToolStripMenuItem.Text = "Radius vs K";
            this.radiusVsKToolStripMenuItem.Click += new System.EventHandler(this.visualizeRadiusVersusK_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.errorBarsToolStripMenuItem,
            this.colorFromStarTypeToolStripMenuItem,
            this.logXAxisToolStripMenuItem,
            this.logYAxisToolStripMenuItem,
            this.includeDuplicatesToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.settingsToolStripMenuItem.Text = "Settings...";
            // 
            // errorBarsToolStripMenuItem
            // 
            this.errorBarsToolStripMenuItem.Name = "errorBarsToolStripMenuItem";
            this.errorBarsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.errorBarsToolStripMenuItem.Text = "Include Error Bars";
            this.errorBarsToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.errorBarsToolStripMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // colorFromStarTypeToolStripMenuItem
            // 
            this.colorFromStarTypeToolStripMenuItem.Name = "colorFromStarTypeToolStripMenuItem";
            this.colorFromStarTypeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.colorFromStarTypeToolStripMenuItem.Text = "Color by Star Type";
            this.colorFromStarTypeToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.colorFromStarTypeToolStripMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // logXAxisToolStripMenuItem
            // 
            this.logXAxisToolStripMenuItem.Name = "logXAxisToolStripMenuItem";
            this.logXAxisToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.logXAxisToolStripMenuItem.Text = "Log X Axis";
            this.logXAxisToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.logXAxisToolStripMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // logYAxisToolStripMenuItem
            // 
            this.logYAxisToolStripMenuItem.Name = "logYAxisToolStripMenuItem";
            this.logYAxisToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.logYAxisToolStripMenuItem.Text = "Log Y Axis";
            this.logYAxisToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.logYAxisToolStripMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // includeDuplicatesToolStripMenuItem
            // 
            this.includeDuplicatesToolStripMenuItem.Name = "includeDuplicatesToolStripMenuItem";
            this.includeDuplicatesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.includeDuplicatesToolStripMenuItem.Text = "Include Duplicates";
            this.includeDuplicatesToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.includeDuplicatesToolStripMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
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
        private System.Windows.Forms.ToolStripMenuItem t0ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem t0secToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lambdaAngleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tvrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tcalcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tmeasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loggToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem omegaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tperiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem massVsRadiusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem massVsEccentricityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geometricAlbedoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tconjToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightAccessionVsDeclinationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem errorBarsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorFromStarTypeToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem massVsT0ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem massVsTperiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem massVsKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radiusVsInclinationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radiusVsT0ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radiusVsTperiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radiusVsKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem includeDuplicatesToolStripMenuItem;
        }
    }