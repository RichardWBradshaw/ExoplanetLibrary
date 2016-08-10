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
            this.compareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verifyNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryBuilderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchExoplanetNASAMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.launchExoplanetNASAMenuItem,
            this.toolStripSeparator1,
            this.compareToolStripMenuItem,
            this.verifyNamesToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "File";
            // 
            // openMenuItem
            // 
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(346, 22);
            this.openMenuItem.Text = "Open ...";
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.Name = "saveAsMenuItem";
            this.saveAsMenuItem.Size = new System.Drawing.Size(346, 22);
            this.saveAsMenuItem.Text = "Save as .CSV";
            // 
            // fileSeparator
            // 
            this.fileSeparator.Name = "fileSeparator";
            this.fileSeparator.Size = new System.Drawing.Size(343, 6);
            // 
            // launchExoplanetEuMenuItem
            // 
            this.launchExoplanetEuMenuItem.Name = "launchExoplanetEuMenuItem";
            this.launchExoplanetEuMenuItem.Size = new System.Drawing.Size(346, 22);
            this.launchExoplanetEuMenuItem.Text = "Launch http://exoplanet.eu ...";
            this.launchExoplanetEuMenuItem.Click += new System.EventHandler(this.launchExoplanetEu_Click);
            // 
            // launchExoplanetEUCatalogsMenuItem
            // 
            this.launchExoplanetEUCatalogsMenuItem.Name = "launchExoplanetEUCatalogsMenuItem";
            this.launchExoplanetEUCatalogsMenuItem.Size = new System.Drawing.Size(346, 22);
            this.launchExoplanetEUCatalogsMenuItem.Text = "Launch http://exoplanet.eu/Catalog ...";
            this.launchExoplanetEUCatalogsMenuItem.Click += new System.EventHandler(this.launchExoplanetEuCatalog_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(343, 6);
            // 
            // compareToolStripMenuItem
            // 
            this.compareToolStripMenuItem.Name = "compareToolStripMenuItem";
            this.compareToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
            this.compareToolStripMenuItem.Text = "Compare ...";
            this.compareToolStripMenuItem.Click += new System.EventHandler(this.compare_Click);
            // 
            // verifyNamesToolStripMenuItem
            // 
            this.verifyNamesToolStripMenuItem.Name = "verifyNamesToolStripMenuItem";
            this.verifyNamesToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
            this.verifyNamesToolStripMenuItem.Text = "Verify Names ...";
            this.verifyNamesToolStripMenuItem.Click += new System.EventHandler(this.verifyNames_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(343, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(346, 22);
            this.exitMenuItem.Text = "Exit";
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.queryBuilderToolStripMenuItem,
            this.visualizationToolStripMenuItem});
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Size = new System.Drawing.Size(47, 20);
            this.settingsMenuItem.Text = "Tools";
            // 
            // queryBuilderToolStripMenuItem
            // 
            this.queryBuilderToolStripMenuItem.Name = "queryBuilderToolStripMenuItem";
            this.queryBuilderToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.queryBuilderToolStripMenuItem.Text = "Query Builder...";
            this.queryBuilderToolStripMenuItem.Click += new System.EventHandler(this.query_Click);
            // 
            // visualizationToolStripMenuItem
            // 
            this.visualizationToolStripMenuItem.Name = "visualizationToolStripMenuItem";
            this.visualizationToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.visualizationToolStripMenuItem.Text = "Visualization...";
            this.visualizationToolStripMenuItem.Click += new System.EventHandler(this.visualize_Click);
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
            // launchExoplanetNASAMenuItem
            // 
            this.launchExoplanetNASAMenuItem.Name = "launchExoplanetNASAMenuItem";
            this.launchExoplanetNASAMenuItem.Size = new System.Drawing.Size(346, 22);
            this.launchExoplanetNASAMenuItem.Text = "Launch http://exoplanetarchive.ipac.caltech.edu/ ...";
            this.launchExoplanetNASAMenuItem.Click += new System.EventHandler(this.launchExoplanetNasaCatalog_Click);
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
        private ToolStripMenuItem launchExoplanetEUCatalogsMenuItem;
        private ToolStripMenuItem launchExoplanetEuMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem visualizationToolStripMenuItem;
        private ToolStripMenuItem compareToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem queryBuilderToolStripMenuItem;
        private ToolStripMenuItem verifyNamesToolStripMenuItem;
        private ToolStripMenuItem launchExoplanetNASAMenuItem;
        }
    }

