using System.Windows.Forms;

namespace ExoplanetLibrary
    {
    partial class LibraryDialog
        {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose ( bool disposing )
            {
            if ( disposing && ( components != null ) )
                {
                components.Dispose ( );
                }
            base.Dispose ( disposing );
            }

        private void InitializeComponent ( )
            {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibraryDialog));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.launchExoplanetEuMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchExoplanetEUCatalogsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.starFiltersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeOMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeBMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeAMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeFMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeGMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeKMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeMMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unknownStarTypeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detectFiltersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.primaryTransitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radialVelocityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.microlensingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pulsarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.astrometryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tTVMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allDetectionMethodsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plottingMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.plottingMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.plottingMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.plottingMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.plottingMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.plottingMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.settingsMenuItem,
            this.helpMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenuItem,
            this.saveAsMenuItem,
            this.fileSeparator,
            this.launchExoplanetEuMenuItem,
            this.launchExoplanetEUCatalogsMenuItem,
            this.toolStripSeparator1,
            this.exitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "File";
            // 
            // openMenuItem
            // 
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(276, 22);
            this.openMenuItem.Text = "Open ...";
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.Name = "saveAsMenuItem";
            this.saveAsMenuItem.Size = new System.Drawing.Size(276, 22);
            this.saveAsMenuItem.Text = "Save as .CSV";
            // 
            // fileSeparator
            // 
            this.fileSeparator.Name = "fileSeparator";
            this.fileSeparator.Size = new System.Drawing.Size(273, 6);
            // 
            // launchExoplanetEuMenuItem
            // 
            this.launchExoplanetEuMenuItem.Name = "launchExoplanetEuMenuItem";
            this.launchExoplanetEuMenuItem.Size = new System.Drawing.Size(276, 22);
            this.launchExoplanetEuMenuItem.Text = "Launch http://exoplanet.eu ...";
            this.launchExoplanetEuMenuItem.Click += new System.EventHandler(this.launchExoplanetEu_Click);
            // 
            // launchExoplanetEUCatalogsMenuItem
            // 
            this.launchExoplanetEUCatalogsMenuItem.Name = "launchExoplanetEUCatalogsMenuItem";
            this.launchExoplanetEUCatalogsMenuItem.Size = new System.Drawing.Size(276, 22);
            this.launchExoplanetEUCatalogsMenuItem.Text = "Launch http://exoplanet.eu/Catalog ...";
            this.launchExoplanetEUCatalogsMenuItem.Click += new System.EventHandler(this.launchExoplanetEuCatalog_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(273, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(276, 22);
            this.exitMenuItem.Text = "Exit";
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.starFiltersMenuItem,
            this.detectFiltersMenuItem,
            this.plottingMenuItem1,
            this.plottingMenuItem2,
            this.plottingMenuItem3,
            this.plottingMenuItem4,
            this.plottingMenuItem5,
            this.plottingMenuItem10});
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsMenuItem.Text = "Settings";
            // 
            // starFiltersMenuItem
            // 
            this.starFiltersMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.typeOMenuItem,
            this.typeBMenuItem,
            this.typeAMenuItem,
            this.typeFMenuItem,
            this.typeGMenuItem,
            this.typeKMenuItem,
            this.typeMMenuItem,
            this.unknownStarTypeMenuItem});
            this.starFiltersMenuItem.Name = "starFiltersMenuItem";
            this.starFiltersMenuItem.Size = new System.Drawing.Size(238, 22);
            this.starFiltersMenuItem.Text = "Star Classifications";
            // 
            // typeOMenuItem
            // 
            this.typeOMenuItem.Name = "typeOMenuItem";
            this.typeOMenuItem.Size = new System.Drawing.Size(130, 22);
            this.typeOMenuItem.Text = "Type O";
            this.typeOMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.typeOMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // typeBMenuItem
            // 
            this.typeBMenuItem.Name = "typeBMenuItem";
            this.typeBMenuItem.Size = new System.Drawing.Size(130, 22);
            this.typeBMenuItem.Text = "Type B";
            this.typeBMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.typeBMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // typeAMenuItem
            // 
            this.typeAMenuItem.Name = "typeAMenuItem";
            this.typeAMenuItem.Size = new System.Drawing.Size(130, 22);
            this.typeAMenuItem.Text = "Type A";
            this.typeAMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.typeAMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // typeFMenuItem
            // 
            this.typeFMenuItem.Name = "typeFMenuItem";
            this.typeFMenuItem.Size = new System.Drawing.Size(130, 22);
            this.typeFMenuItem.Text = "Type F";
            this.typeFMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.typeFMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // typeGMenuItem
            // 
            this.typeGMenuItem.Name = "typeGMenuItem";
            this.typeGMenuItem.Size = new System.Drawing.Size(130, 22);
            this.typeGMenuItem.Text = "Type G";
            this.typeGMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.typeGMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // typeKMenuItem
            // 
            this.typeKMenuItem.Name = "typeKMenuItem";
            this.typeKMenuItem.Size = new System.Drawing.Size(130, 22);
            this.typeKMenuItem.Text = "Type K";
            this.typeKMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.typeKMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // typeMMenuItem
            // 
            this.typeMMenuItem.Name = "typeMMenuItem";
            this.typeMMenuItem.Size = new System.Drawing.Size(130, 22);
            this.typeMMenuItem.Text = "Type M";
            this.typeMMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.typeMMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // unknownStarTypeMenuItem
            // 
            this.unknownStarTypeMenuItem.Name = "unknownStarTypeMenuItem";
            this.unknownStarTypeMenuItem.Size = new System.Drawing.Size(130, 22);
            this.unknownStarTypeMenuItem.Text = "Unknown?";
            this.unknownStarTypeMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.unknownStarTypeMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // detectFiltersMenuItem
            // 
            this.detectFiltersMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.primaryTransitMenuItem,
            this.radialVelocityMenuItem,
            this.microlensingMenuItem,
            this.imagingMenuItem,
            this.pulsarMenuItem,
            this.astrometryMenuItem,
            this.tTVMenuItem,
            this.allDetectionMethodsMenuItem});
            this.detectFiltersMenuItem.Name = "detectFiltersMenuItem";
            this.detectFiltersMenuItem.Size = new System.Drawing.Size(238, 22);
            this.detectFiltersMenuItem.Text = "Detect Methods";
            // 
            // primaryTransitMenuItem
            // 
            this.primaryTransitMenuItem.Name = "primaryTransitMenuItem";
            this.primaryTransitMenuItem.Size = new System.Drawing.Size(153, 22);
            this.primaryTransitMenuItem.Text = "Primary Transit";
            this.primaryTransitMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.primaryTransitMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // radialVelocityMenuItem
            // 
            this.radialVelocityMenuItem.Name = "radialVelocityMenuItem";
            this.radialVelocityMenuItem.Size = new System.Drawing.Size(153, 22);
            this.radialVelocityMenuItem.Text = "Radial Velocity";
            this.radialVelocityMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.radialVelocityMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // microlensingMenuItem
            // 
            this.microlensingMenuItem.Name = "microlensingMenuItem";
            this.microlensingMenuItem.Size = new System.Drawing.Size(153, 22);
            this.microlensingMenuItem.Text = "Microlensing";
            this.microlensingMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.microlensingMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // imagingMenuItem
            // 
            this.imagingMenuItem.Name = "imagingMenuItem";
            this.imagingMenuItem.Size = new System.Drawing.Size(153, 22);
            this.imagingMenuItem.Text = "Imaging";
            this.imagingMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.imagingMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // pulsarMenuItem
            // 
            this.pulsarMenuItem.Name = "pulsarMenuItem";
            this.pulsarMenuItem.Size = new System.Drawing.Size(153, 22);
            this.pulsarMenuItem.Text = "Pulsar";
            this.pulsarMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.pulsarMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // astrometryMenuItem
            // 
            this.astrometryMenuItem.Name = "astrometryMenuItem";
            this.astrometryMenuItem.Size = new System.Drawing.Size(153, 22);
            this.astrometryMenuItem.Text = "Astrometry";
            this.astrometryMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.astrometryMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // tTVMenuItem
            // 
            this.tTVMenuItem.Name = "tTVMenuItem";
            this.tTVMenuItem.Size = new System.Drawing.Size(153, 22);
            this.tTVMenuItem.Text = "TTV";
            this.tTVMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.tTVMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // allDetectionMethodsMenuItem
            // 
            this.allDetectionMethodsMenuItem.Name = "allDetectionMethodsMenuItem";
            this.allDetectionMethodsMenuItem.Size = new System.Drawing.Size(153, 22);
            this.allDetectionMethodsMenuItem.Text = "Unknown?";
            this.allDetectionMethodsMenuItem.CheckStateChanged += new System.EventHandler(this.MenuCheckBox_CheckStateChanged);
            this.allDetectionMethodsMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // plottingMenuItem1
            // 
            this.plottingMenuItem1.Name = "plottingMenuItem1";
            this.plottingMenuItem1.Size = new System.Drawing.Size(238, 22);
            this.plottingMenuItem1.Text = "Visualize Stars and Exoplanets...";
            this.plottingMenuItem1.Click += new System.EventHandler(this.plotting_Click1);
            // 
            // plottingMenuItem2
            // 
            this.plottingMenuItem2.Name = "plottingMenuItem2";
            this.plottingMenuItem2.Size = new System.Drawing.Size(238, 22);
            this.plottingMenuItem2.Text = "Visualize Masses...";
            this.plottingMenuItem2.Click += new System.EventHandler(this.plotting_Click2);
            // 
            // plottingMenuItem3
            // 
            this.plottingMenuItem3.Name = "plottingMenuItem3";
            this.plottingMenuItem3.Size = new System.Drawing.Size(238, 22);
            this.plottingMenuItem3.Text = "Visualize Radii...";
            this.plottingMenuItem3.Click += new System.EventHandler(this.plotting_Click3);
            // 
            // plottingMenuItem4
            // 
            this.plottingMenuItem4.Name = "plottingMenuItem4";
            this.plottingMenuItem4.Size = new System.Drawing.Size(238, 22);
            this.plottingMenuItem4.Text = "Visualize Orbital Period...";
            this.plottingMenuItem4.Click += new System.EventHandler(this.plotting_Click4);
            // 
            // plottingMenuItem5
            // 
            this.plottingMenuItem5.Name = "plottingMenuItem5";
            this.plottingMenuItem5.Size = new System.Drawing.Size(238, 22);
            this.plottingMenuItem5.Text = "Visualize Eccentrities...";
            this.plottingMenuItem5.Click += new System.EventHandler(this.plotting_Click5);
            // 
            // plottingMenuItem10
            // 
            this.plottingMenuItem10.Name = "plottingMenuItem5";
            this.plottingMenuItem10.Size = new System.Drawing.Size(238, 22);
            this.plottingMenuItem10.Text = "Visualize Masses and Radii...";
            this.plottingMenuItem10.Click += new System.EventHandler(this.plotting_Click10);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpMenuItem.Text = "Help";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(209, 22);
            this.aboutMenuItem.Text = "About Exoplanet Library...";
            // 
            // LibraryDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(784, 341);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LibraryDialog";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Exoplanet Library";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LibraryDialog_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileMenuItem;
        private ToolStripSeparator fileSeparator;
        private ToolStripMenuItem exitMenuItem;
        private ToolStripMenuItem openMenuItem;
        private ToolStripMenuItem helpMenuItem;
        private ToolStripMenuItem aboutMenuItem;
        private ToolStripMenuItem saveAsMenuItem;
        private ToolStripMenuItem settingsMenuItem;
        private ToolStripMenuItem starFiltersMenuItem;
        private ToolStripMenuItem typeOMenuItem;
        private ToolStripMenuItem detectFiltersMenuItem;
        private ToolStripMenuItem unknownStarTypeMenuItem;
        private ToolStripMenuItem typeBMenuItem;
        private ToolStripMenuItem typeAMenuItem;
        private ToolStripMenuItem typeFMenuItem;
        private ToolStripMenuItem typeGMenuItem;
        private ToolStripMenuItem typeKMenuItem;
        private ToolStripMenuItem typeMMenuItem;
        private ToolStripMenuItem primaryTransitMenuItem;
        private ToolStripMenuItem radialVelocityMenuItem;
        private ToolStripMenuItem microlensingMenuItem;
        private ToolStripMenuItem imagingMenuItem;
        private ToolStripMenuItem pulsarMenuItem;
        private ToolStripMenuItem astrometryMenuItem;
        private ToolStripMenuItem tTVMenuItem;
        private ToolStripMenuItem allDetectionMethodsMenuItem;
        private ToolStripMenuItem launchExoplanetEUCatalogsMenuItem;
        private ToolStripMenuItem launchExoplanetEuMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem plottingMenuItem1;
        private ToolStripMenuItem plottingMenuItem2;
        private ToolStripMenuItem plottingMenuItem3;
        private ToolStripMenuItem plottingMenuItem4;
        private ToolStripMenuItem plottingMenuItem5;
        private ToolStripMenuItem plottingMenuItem10;
        }
    }

