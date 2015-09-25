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
            menuStrip1 = new System.Windows.Forms.MenuStrip ( );
            fileMenuItem = new System.Windows.Forms.ToolStripMenuItem ( );
            openMenuItem = new System.Windows.Forms.ToolStripMenuItem ( );
            saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem ( );
            fileSeparator = new System.Windows.Forms.ToolStripSeparator ( );
            exitMenuItem = new System.Windows.Forms.ToolStripMenuItem ( );
            helpMenuItem = new System.Windows.Forms.ToolStripMenuItem ( );
            aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem ( );
            menuStrip1.SuspendLayout ( );
            SuspendLayout ( );
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange ( new System.Windows.Forms.ToolStripItem[] {
            fileMenuItem,
            helpMenuItem} );
            menuStrip1.Location = new System.Drawing.Point ( 0, 0 );
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size ( 784, 24 );
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            fileMenuItem.DropDownItems.AddRange ( new System.Windows.Forms.ToolStripItem[] {
            openMenuItem,
            saveAsMenuItem,
            fileSeparator,
            exitMenuItem} );
            fileMenuItem.Name = "fileMenuItem";
            fileMenuItem.Size = new System.Drawing.Size ( 37, 20 );
            fileMenuItem.Text = "File";
            // 
            // openMenuItem
            // 
            openMenuItem.Name = "openMenuItem";
            openMenuItem.Size = new System.Drawing.Size ( 139, 22 );
            openMenuItem.Text = "Open ...";
            // 
            // saveAsMenuItem
            // 
            saveAsMenuItem.Name = "saveAsMenuItem";
            saveAsMenuItem.Size = new System.Drawing.Size ( 139, 22 );
            saveAsMenuItem.Text = "Save as .CSV";
            // 
            // fileSeparator
            // 
            fileSeparator.Name = "fileSeparator";
            fileSeparator.Size = new System.Drawing.Size ( 136, 6 );
            // 
            // exitMenuItem
            // 
            exitMenuItem.Name = "exitMenuItem";
            exitMenuItem.Size = new System.Drawing.Size ( 139, 22 );
            exitMenuItem.Text = "Exit";
            // 
            // helpMenuItem
            // 
            helpMenuItem.DropDownItems.AddRange ( new System.Windows.Forms.ToolStripItem[] {
            aboutMenuItem} );
            helpMenuItem.Name = "helpMenuItem";
            helpMenuItem.Size = new System.Drawing.Size ( 44, 20 );
            helpMenuItem.Text = "Help";
            // 
            // aboutMenuItem
            // 
            aboutMenuItem.Name = "aboutMenuItem";
            aboutMenuItem.Size = new System.Drawing.Size ( 209, 22 );
            aboutMenuItem.Text = "About Exoplanet Library...";
            // 
            // LibraryDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF ( 6F, 13F );
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ClientSize = new System.Drawing.Size ( 784, 341 );
            Controls.Add ( menuStrip1 );
            Name = "LibraryDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            Text = "Exoplanent Library";
            TopMost = true;
            menuStrip1.ResumeLayout ( false );
            menuStrip1.PerformLayout ( );
            ResumeLayout ( false );
            PerformLayout ( );

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

