namespace ExoplanetLibrary
    {
    partial class ExoplanetDetails
        {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose (bool disposing)
            {
            if (disposing && ( components != null ))
                {
                components.Dispose ();
                }
            base.Dispose (disposing);
            }

        #region Windows Form Designer generated code

        private void InitializeComponent ()
            {
            SuspendLayout();
            // 
            // ExoplanetDetails
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ClientSize = new System.Drawing.Size(434, 561);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ExoplanetDetails";
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            Text = "Planet & Star Details";
            TopMost = true;
            FormClosing += new System.Windows.Forms.FormClosingEventHandler(PlanetNStarDetails_FormClosing);
            ResumeLayout(false);

            }

        #endregion
        }
    }