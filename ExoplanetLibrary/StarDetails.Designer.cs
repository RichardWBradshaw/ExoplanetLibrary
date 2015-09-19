namespace ExoplanetLibrary
    {
    partial class StarDetails
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
            this.nameLabel = new System.Windows.Forms.Label ( );
            this.nameTextBox = new System.Windows.Forms.TextBox ( );
            this.raLabel = new System.Windows.Forms.Label ( );
            this.raTextBox = new System.Windows.Forms.TextBox ( );
            this.decLabel = new System.Windows.Forms.Label ( );
            this.decTextBox = new System.Windows.Forms.TextBox ( );

            this.magnitudeGroupBox = new System.Windows.Forms.GroupBox ( );
            this.magnitudeVLabel = new System.Windows.Forms.Label ( );
            this.magnitudeVTextBox = new System.Windows.Forms.TextBox ( );
            this.magnitudeILabel = new System.Windows.Forms.Label ( );
            this.magnitudeITextBox = new System.Windows.Forms.TextBox ( );
            this.magnitudeJLlabel = new System.Windows.Forms.Label ( );
            this.magnitudeJTextBox = new System.Windows.Forms.TextBox ( );
            this.magnitudeHLabel = new System.Windows.Forms.Label ( );
            this.magnitudeHTextBox = new System.Windows.Forms.TextBox ( );
            this.magnitudeKLabel = new System.Windows.Forms.Label ( );
            this.magnitudeKTextBox = new System.Windows.Forms.TextBox ( );

            this.propertiesGroupBox = new System.Windows.Forms.GroupBox ( );
            this.spTypeLabel = new System.Windows.Forms.Label ( );
            this.spTypeTextBox = new System.Windows.Forms.TextBox ( );
            this.ageLabel = new System.Windows.Forms.Label ( );
            this.ageTextBox = new System.Windows.Forms.TextBox ( );
            this.distanceLabel = new System.Windows.Forms.Label ( );
            this.distanceTextBox = new System.Windows.Forms.TextBox ( );
            this.massLabel = new System.Windows.Forms.Label ( );
            this.massTextBox = new System.Windows.Forms.TextBox ( );
            this.radiusLabel = new System.Windows.Forms.Label ( );
            this.radiusTextBox = new System.Windows.Forms.TextBox ( );
            this.metallicityLabel = new System.Windows.Forms.Label ( );
            this.metallicityTextBox = new System.Windows.Forms.TextBox ( );
            this.teffLabel = new System.Windows.Forms.Label ( );
            this.teffTextBox = new System.Windows.Forms.TextBox ( );
            this.detectedDiscLabel = new System.Windows.Forms.Label ( );
            this.detectedDiscTextBox = new System.Windows.Forms.TextBox ( );
            this.magneticFieldLabel = new System.Windows.Forms.Label ( );
            this.magneticFieldTextBox = new System.Windows.Forms.TextBox ( );
            this.magnitudeGroupBox.SuspendLayout ( );
            this.propertiesGroupBox.SuspendLayout ( );
            this.SuspendLayout ( );
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point ( 5, 5 );
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size ( 38, 13 );
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point ( 100, 5 );
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.nameTextBox.TabIndex = 1;
            // 
            // raLabel
            // 
            this.raLabel.AutoSize = true;
            this.raLabel.Location = new System.Drawing.Point ( 5, 30 );
            this.raLabel.Name = "raLabel";
            this.raLabel.Size = new System.Drawing.Size ( 25, 13 );
            this.raLabel.TabIndex = 2;
            this.raLabel.Text = "RA:";
            // 
            // raTextBox
            // 
            this.raTextBox.Location = new System.Drawing.Point ( 100, 30 );
            this.raTextBox.Name = "raTextBox";
            this.raTextBox.ReadOnly = true;
            this.raTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.raTextBox.TabIndex = 3;
            // 
            // decLabel
            // 
            this.decLabel.AutoSize = true;
            this.decLabel.Location = new System.Drawing.Point ( 5, 55 );
            this.decLabel.Name = "decLabel";
            this.decLabel.Size = new System.Drawing.Size ( 30, 13 );
            this.decLabel.TabIndex = 4;
            this.decLabel.Text = "Dec:";
            // 
            // decTextBox
            // 
            this.decTextBox.Location = new System.Drawing.Point ( 100, 55 );
            this.decTextBox.Name = "decTextBox";
            this.decTextBox.ReadOnly = true;
            this.decTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.decTextBox.TabIndex = 5;
            // 
            // magnitudeGroupBox
            // 
            this.magnitudeGroupBox.Controls.Add ( this.magnitudeVLabel );
            this.magnitudeGroupBox.Controls.Add ( this.magnitudeVTextBox );
            this.magnitudeGroupBox.Controls.Add ( this.magnitudeILabel );
            this.magnitudeGroupBox.Controls.Add ( this.magnitudeITextBox );
            this.magnitudeGroupBox.Controls.Add ( this.magnitudeJLlabel );
            this.magnitudeGroupBox.Controls.Add ( this.magnitudeJTextBox );
            this.magnitudeGroupBox.Controls.Add ( this.magnitudeHLabel );
            this.magnitudeGroupBox.Controls.Add ( this.magnitudeHTextBox );
            this.magnitudeGroupBox.Controls.Add ( this.magnitudeKLabel );
            this.magnitudeGroupBox.Controls.Add ( this.magnitudeKTextBox );
            this.magnitudeGroupBox.Location = new System.Drawing.Point ( 10, 85 );
            this.magnitudeGroupBox.Name = "magnitudeGroupBox";
            this.magnitudeGroupBox.Size = new System.Drawing.Size ( 220, 148 );
            this.magnitudeGroupBox.TabIndex = 6;
            this.magnitudeGroupBox.TabStop = false;
            this.magnitudeGroupBox.Text = "Magnitudes";
            // 
            // magnitudeVLabel
            // 
            this.magnitudeVLabel.AutoSize = true;
            this.magnitudeVLabel.Location = new System.Drawing.Point ( 10, 25 );
            this.magnitudeVLabel.Name = "magnitudeVLabel";
            this.magnitudeVLabel.Size = new System.Drawing.Size ( 17, 13 );
            this.magnitudeVLabel.TabIndex = 0;
            this.magnitudeVLabel.Text = "V:";
            // 
            // magnitudeVTextBox
            // 
            this.magnitudeVTextBox.Location = new System.Drawing.Point ( 90, 20 );
            this.magnitudeVTextBox.Name = "magnitudeVTextBox";
            this.magnitudeVTextBox.ReadOnly = true;
            this.magnitudeVTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.magnitudeVTextBox.TabIndex = 1;
            // 
            // magnitudeILabel
            // 
            this.magnitudeILabel.AutoSize = true;
            this.magnitudeILabel.Location = new System.Drawing.Point ( 10, 50 );
            this.magnitudeILabel.Name = "magnitudeILabel";
            this.magnitudeILabel.Size = new System.Drawing.Size ( 13, 13 );
            this.magnitudeILabel.TabIndex = 2;
            this.magnitudeILabel.Text = "I:";
            // 
            // magnitudeITextBox
            // 
            this.magnitudeITextBox.Location = new System.Drawing.Point ( 90, 45 );
            this.magnitudeITextBox.Name = "magnitudeITextBox";
            this.magnitudeITextBox.ReadOnly = true;
            this.magnitudeITextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.magnitudeITextBox.TabIndex = 3;
            // 
            // magnitudeJLlabel
            // 
            this.magnitudeJLlabel.AutoSize = true;
            this.magnitudeJLlabel.Location = new System.Drawing.Point ( 10, 75 );
            this.magnitudeJLlabel.Name = "magnitudeJLlabel";
            this.magnitudeJLlabel.Size = new System.Drawing.Size ( 15, 13 );
            this.magnitudeJLlabel.TabIndex = 4;
            this.magnitudeJLlabel.Text = "J:";
            // 
            // magnitudeJTextBox
            // 
            this.magnitudeJTextBox.Location = new System.Drawing.Point ( 90, 70 );
            this.magnitudeJTextBox.Name = "magnitudeJTextBox";
            this.magnitudeJTextBox.ReadOnly = true;
            this.magnitudeJTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.magnitudeJTextBox.TabIndex = 5;
            // 
            // magnitudeHLabel
            // 
            this.magnitudeHLabel.AutoSize = true;
            this.magnitudeHLabel.Location = new System.Drawing.Point ( 10, 100 );
            this.magnitudeHLabel.Name = "magnitudeHLabel";
            this.magnitudeHLabel.Size = new System.Drawing.Size ( 18, 13 );
            this.magnitudeHLabel.TabIndex = 6;
            this.magnitudeHLabel.Text = "H:";
            // 
            // magnitudeHTextBox
            // 
            this.magnitudeHTextBox.Location = new System.Drawing.Point ( 90, 95 );
            this.magnitudeHTextBox.Name = "magnitudeHTextBox";
            this.magnitudeHTextBox.ReadOnly = true;
            this.magnitudeHTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.magnitudeHTextBox.TabIndex = 7;
            // 
            // magnitudeKLabel
            // 
            this.magnitudeKLabel.AutoSize = true;
            this.magnitudeKLabel.Location = new System.Drawing.Point ( 10, 125 );
            this.magnitudeKLabel.Name = "magnitudeKLabel";
            this.magnitudeKLabel.Size = new System.Drawing.Size ( 17, 13 );
            this.magnitudeKLabel.TabIndex = 8;
            this.magnitudeKLabel.Text = "K:";
            // 
            // magnitudeKTextBox
            // 
            this.magnitudeKTextBox.Location = new System.Drawing.Point ( 90, 120 );
            this.magnitudeKTextBox.Name = "magnitudeKTextBox";
            this.magnitudeKTextBox.ReadOnly = true;
            this.magnitudeKTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.magnitudeKTextBox.TabIndex = 9;
            // 
            // propertiesGroupBox
            // 
            this.propertiesGroupBox.Controls.Add ( this.spTypeLabel );
            this.propertiesGroupBox.Controls.Add ( this.spTypeTextBox );
            this.propertiesGroupBox.Controls.Add ( this.ageLabel );
            this.propertiesGroupBox.Controls.Add ( this.ageTextBox );
            this.propertiesGroupBox.Controls.Add ( this.distanceLabel );
            this.propertiesGroupBox.Controls.Add ( this.distanceTextBox );
            this.propertiesGroupBox.Controls.Add ( this.massLabel );
            this.propertiesGroupBox.Controls.Add ( this.massTextBox );
            this.propertiesGroupBox.Controls.Add ( this.radiusLabel );
            this.propertiesGroupBox.Controls.Add ( this.radiusTextBox );
            this.propertiesGroupBox.Controls.Add ( this.metallicityLabel );
            this.propertiesGroupBox.Controls.Add ( this.metallicityTextBox );
            this.propertiesGroupBox.Controls.Add ( this.teffLabel );
            this.propertiesGroupBox.Controls.Add ( this.teffTextBox );
            this.propertiesGroupBox.Controls.Add ( this.detectedDiscLabel );
            this.propertiesGroupBox.Controls.Add ( this.detectedDiscTextBox );
            this.propertiesGroupBox.Controls.Add ( this.magneticFieldLabel );
            this.propertiesGroupBox.Controls.Add ( this.magneticFieldTextBox );
            this.propertiesGroupBox.Location = new System.Drawing.Point ( 12, 239 );
            this.propertiesGroupBox.Name = "propertiesGroupBox";
            this.propertiesGroupBox.Size = new System.Drawing.Size ( 220, 251 );
            this.propertiesGroupBox.TabIndex = 17;
            this.propertiesGroupBox.TabStop = false;
            this.propertiesGroupBox.Text = "Properties";
            // 
            // spTypeLabel
            // 
            this.spTypeLabel.AutoSize = true;
            this.spTypeLabel.Location = new System.Drawing.Point ( 10, 25 );
            this.spTypeLabel.Name = "spTypeLabel";
            this.spTypeLabel.Size = new System.Drawing.Size ( 51, 13 );
            this.spTypeLabel.TabIndex = 0;
            this.spTypeLabel.Text = "SP Type:";
            // 
            // spTypeTextBox
            // 
            this.spTypeTextBox.Location = new System.Drawing.Point ( 90, 25 );
            this.spTypeTextBox.Name = "spTypeTextBox";
            this.spTypeTextBox.ReadOnly = true;
            this.spTypeTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.spTypeTextBox.TabIndex = 1;
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.Location = new System.Drawing.Point ( 10, 50 );
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size ( 29, 13 );
            this.ageLabel.TabIndex = 2;
            this.ageLabel.Text = "Age:";
            // 
            // ageTextBox
            // 
            this.ageTextBox.Location = new System.Drawing.Point ( 90, 50 );
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.ReadOnly = true;
            this.ageTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.ageTextBox.TabIndex = 3;
            // 
            // distanceLabel
            // 
            this.distanceLabel.AutoSize = true;
            this.distanceLabel.Location = new System.Drawing.Point ( 10, 75 );
            this.distanceLabel.Name = "distanceLabel";
            this.distanceLabel.Size = new System.Drawing.Size ( 52, 13 );
            this.distanceLabel.TabIndex = 4;
            this.distanceLabel.Text = "Distance:";
            // 
            // distanceTextBox
            // 
            this.distanceTextBox.Location = new System.Drawing.Point ( 90, 75 );
            this.distanceTextBox.Name = "distanceTextBox";
            this.distanceTextBox.ReadOnly = true;
            this.distanceTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.distanceTextBox.TabIndex = 5;
            // 
            // massLabel
            // 
            this.massLabel.AutoSize = true;
            this.massLabel.Location = new System.Drawing.Point ( 10, 100 );
            this.massLabel.Name = "massLabel";
            this.massLabel.Size = new System.Drawing.Size ( 35, 13 );
            this.massLabel.TabIndex = 6;
            this.massLabel.Text = "Mass:";
            // 
            // massTextBox
            // 
            this.massTextBox.Location = new System.Drawing.Point ( 90, 100 );
            this.massTextBox.Name = "massTextBox";
            this.massTextBox.ReadOnly = true;
            this.massTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.massTextBox.TabIndex = 7;
            // 
            // radiusLabel
            // 
            this.radiusLabel.AutoSize = true;
            this.radiusLabel.Location = new System.Drawing.Point ( 10, 125 );
            this.radiusLabel.Name = "radiusLabel";
            this.radiusLabel.Size = new System.Drawing.Size ( 43, 13 );
            this.radiusLabel.TabIndex = 8;
            this.radiusLabel.Text = "Radius:";
            // 
            // radiusTextBox
            // 
            this.radiusTextBox.Location = new System.Drawing.Point ( 90, 125 );
            this.radiusTextBox.Name = "radiusTextBox";
            this.radiusTextBox.ReadOnly = true;
            this.radiusTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.radiusTextBox.TabIndex = 9;
            // 
            // metallicityLabel
            // 
            this.metallicityLabel.AutoSize = true;
            this.metallicityLabel.Location = new System.Drawing.Point ( 10, 150 );
            this.metallicityLabel.Name = "metallicityLabel";
            this.metallicityLabel.Size = new System.Drawing.Size ( 56, 13 );
            this.metallicityLabel.TabIndex = 10;
            this.metallicityLabel.Text = "Metallicity:";
            // 
            // metallicityTextBox
            // 
            this.metallicityTextBox.Location = new System.Drawing.Point ( 90, 150 );
            this.metallicityTextBox.Name = "metallicityTextBox";
            this.metallicityTextBox.ReadOnly = true;
            this.metallicityTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.metallicityTextBox.TabIndex = 11;
            // 
            // teffLabel
            // 
            this.teffLabel.AutoSize = true;
            this.teffLabel.Location = new System.Drawing.Point ( 10, 175 );
            this.teffLabel.Name = "teffLabel";
            this.teffLabel.Size = new System.Drawing.Size ( 29, 13 );
            this.teffLabel.TabIndex = 12;
            this.teffLabel.Text = "Teff:";
            // 
            // teffTextBox
            // 
            this.teffTextBox.Location = new System.Drawing.Point ( 90, 175 );
            this.teffTextBox.Name = "teffTextBox";
            this.teffTextBox.ReadOnly = true;
            this.teffTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.teffTextBox.TabIndex = 13;
            // 
            // detedtedDiscLabel
            // 
            this.detectedDiscLabel.AutoSize = true;
            this.detectedDiscLabel.Location = new System.Drawing.Point ( 10, 200 );
            this.detectedDiscLabel.Name = "detedtedDiscLabel";
            this.detectedDiscLabel.Size = new System.Drawing.Size ( 78, 13 );
            this.detectedDiscLabel.TabIndex = 14;
            this.detectedDiscLabel.Text = "Detected Disc:";
            // 
            // detectedDiscTextBox
            // 
            this.detectedDiscTextBox.Location = new System.Drawing.Point ( 90, 200 );
            this.detectedDiscTextBox.Name = "detectedDiscTextBox";
            this.detectedDiscTextBox.ReadOnly = true;
            this.detectedDiscTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.detectedDiscTextBox.TabIndex = 15;
            // 
            // magneticFieldLabel
            // 
            this.magneticFieldLabel.AutoSize = true;
            this.magneticFieldLabel.Location = new System.Drawing.Point ( 10, 225 );
            this.magneticFieldLabel.Name = "magneticFieldLabel";
            this.magneticFieldLabel.Size = new System.Drawing.Size ( 79, 13 );
            this.magneticFieldLabel.TabIndex = 16;
            this.magneticFieldLabel.Text = "Magnetic Field:";
            // 
            // magneticFieldTextBox
            // 
            this.magneticFieldTextBox.Location = new System.Drawing.Point ( 90, 225 );
            this.magneticFieldTextBox.Name = "magneticFieldTextBox";
            this.magneticFieldTextBox.ReadOnly = true;
            this.magneticFieldTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.magneticFieldTextBox.TabIndex = 17;

            this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size ( 230, 492 );
            this.Controls.Add ( this.propertiesGroupBox );
            this.Controls.Add ( this.magnitudeGroupBox );
            this.Controls.Add ( this.nameLabel );
            this.Controls.Add ( this.nameTextBox );
            this.Controls.Add ( this.raLabel );
            this.Controls.Add ( this.raTextBox );
            this.Controls.Add ( this.decLabel );
            this.Controls.Add ( this.decTextBox );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StarDetails";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Star Attributes";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler ( this.StarDetails_FormClosing );
            this.magnitudeGroupBox.ResumeLayout ( false );
            this.magnitudeGroupBox.PerformLayout ( );
            this.propertiesGroupBox.ResumeLayout ( false );
            this.propertiesGroupBox.PerformLayout ( );
            this.ResumeLayout ( false );
            this.PerformLayout ( );
            }

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label raLabel;
        private System.Windows.Forms.TextBox raTextBox;
        private System.Windows.Forms.Label decLabel;
        private System.Windows.Forms.TextBox decTextBox;
        private System.Windows.Forms.GroupBox magnitudeGroupBox;
        private System.Windows.Forms.Label magnitudeVLabel;
        private System.Windows.Forms.TextBox magnitudeVTextBox;
        private System.Windows.Forms.Label magnitudeILabel;
        private System.Windows.Forms.TextBox magnitudeITextBox;
        private System.Windows.Forms.Label magnitudeJLlabel;
        private System.Windows.Forms.TextBox magnitudeJTextBox;
        private System.Windows.Forms.Label magnitudeHLabel;
        private System.Windows.Forms.TextBox magnitudeHTextBox;
        private System.Windows.Forms.Label magnitudeKLabel;
        private System.Windows.Forms.TextBox magnitudeKTextBox;
        private System.Windows.Forms.GroupBox propertiesGroupBox;
        private System.Windows.Forms.Label spTypeLabel;
        private System.Windows.Forms.TextBox spTypeTextBox;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.TextBox ageTextBox;
        private System.Windows.Forms.Label distanceLabel;
        private System.Windows.Forms.TextBox distanceTextBox;
        private System.Windows.Forms.Label massLabel;
        private System.Windows.Forms.TextBox massTextBox;
        private System.Windows.Forms.Label radiusLabel;
        private System.Windows.Forms.TextBox radiusTextBox;
        private System.Windows.Forms.Label metallicityLabel;
        private System.Windows.Forms.TextBox metallicityTextBox;
        private System.Windows.Forms.Label teffLabel;
        private System.Windows.Forms.TextBox teffTextBox;
        private System.Windows.Forms.Label magneticFieldLabel;
        private System.Windows.Forms.TextBox magneticFieldTextBox;
        private System.Windows.Forms.Label detectedDiscLabel;
        private System.Windows.Forms.TextBox detectedDiscTextBox;
        }
    }