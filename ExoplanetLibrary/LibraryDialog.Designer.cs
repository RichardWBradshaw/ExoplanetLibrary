using System;
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip ( );
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem ( );
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem ( );
            this.saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem ( );
            this.fileSeparator = new System.Windows.Forms.ToolStripSeparator ( );
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem ( );
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem ( );
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem ( );
            this.menuStrip1.SuspendLayout ( );
            this.SuspendLayout ( );
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange ( new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.helpMenuItem} );
            this.menuStrip1.Location = new System.Drawing.Point ( 0, 0 );
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size ( 784, 24 );
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange ( new System.Windows.Forms.ToolStripItem[] {
            this.openMenuItem,
            this.saveAsMenuItem,
            this.fileSeparator,
            this.exitMenuItem} );
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size ( 37, 20 );
            this.fileMenuItem.Text = "File";
            // 
            // openMenuItem
            // 
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size ( 139, 22 );
            this.openMenuItem.Text = "Open ...";
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.Name = "saveAsMenuItem";
            this.saveAsMenuItem.Size = new System.Drawing.Size ( 139, 22 );
            this.saveAsMenuItem.Text = "Save as .CSV";
            // 
            // fileSeparator
            // 
            this.fileSeparator.Name = "fileSeparator";
            this.fileSeparator.Size = new System.Drawing.Size ( 136, 6 );
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size ( 139, 22 );
            this.exitMenuItem.Text = "Exit";
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange ( new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem} );
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size ( 44, 20 );
            this.helpMenuItem.Text = "Help";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size ( 209, 22 );
            this.aboutMenuItem.Text = "About Exoplanet Library...";
            // 
            // LibraryDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size ( 784, 341 );
            this.Controls.Add ( this.menuStrip1 );
            this.Name = "LibraryDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Exoplanent Library";
            this.TopMost = true;
            this.menuStrip1.ResumeLayout ( false );
            this.menuStrip1.PerformLayout ( );
            this.ResumeLayout ( false );
            this.PerformLayout ( );

            }

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileMenuItem;
        private ToolStripSeparator fileSeparator;
        private ToolStripMenuItem exitMenuItem;
        private ToolStripMenuItem openMenuItem;
        private ToolStripMenuItem helpMenuItem;
        private ToolStripMenuItem aboutMenuItem;
        private ToolStripMenuItem saveAsMenuItem;
        }
    }

