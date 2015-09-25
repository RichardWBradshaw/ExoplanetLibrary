namespace ExoplanetLibrary
    {
    partial class ExoplanetDetails
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

        #region Windows Form Designer generated code

        private void InitializeComponent ( )
            {
            this.SuspendLayout();
            // 
            // ExoplanetDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(434, 623);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExoplanetDetails";
            this.Text = "Planet & Star Details";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlanetNStarDetails_FormClosing);
            this.ResumeLayout(false);

            }

        #endregion
        }
    }