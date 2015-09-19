using System;
using System.Windows.Forms;

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

        private void InitializeComponent ( )
            {
            this.nameLabel = new System.Windows.Forms.Label ( );
            this.nameTextBox = new System.Windows.Forms.TextBox ( );
            this.massLabel = new System.Windows.Forms.Label ( );
            this.massTextBox = new System.Windows.Forms.TextBox ( );
            this.massErrorTextBox = new System.Windows.Forms.TextBox ( );
            this.radiusLabel = new System.Windows.Forms.Label ( );
            this.radiusTextBox = new System.Windows.Forms.TextBox ( );
            this.radiusErrorTextBox = new System.Windows.Forms.TextBox ( );
            this.orbitalPeriodLabel = new System.Windows.Forms.Label ( );
            this.orbitalPeriodTextBox = new System.Windows.Forms.TextBox ( );
            this.orbitalPeriodErrorTextBox = new System.Windows.Forms.TextBox ( );
            this.semimajorAxisLabel = new System.Windows.Forms.Label ( );
            this.semimajorAxisTextBox = new System.Windows.Forms.TextBox ( );
            this.semimajorAxisErrorTextBox = new System.Windows.Forms.TextBox ( );
            this.eccentricityLabel = new System.Windows.Forms.Label ( );
            this.eccentricityTextBox = new System.Windows.Forms.TextBox ( );
            this.eccentricityErrorTextBox = new System.Windows.Forms.TextBox ( );
            this.angularDistanceLabel = new System.Windows.Forms.Label ( );
            this.angularDistanceTextBox = new System.Windows.Forms.TextBox ( );
            this.inclinationLabel = new System.Windows.Forms.Label ( );
            this.inclinationTextBox = new System.Windows.Forms.TextBox ( );
            this.inclinationErrorTextBox = new System.Windows.Forms.TextBox ( );
            this.tzeroTrLabel = new System.Windows.Forms.Label ( );
            this.tzeroTrTextBox = new System.Windows.Forms.TextBox ( );
            this.tzeroTrErrorTextBox = new System.Windows.Forms.TextBox ( );
            this.tzeroTrSecLabel = new System.Windows.Forms.Label ( );
            this.tzeroTrSecTextBox = new System.Windows.Forms.TextBox ( );
            this.tzeroTrSecErrorTextBox = new System.Windows.Forms.TextBox ( );
            this.lambdaAngleLabel = new System.Windows.Forms.Label ( );
            this.lambdaAngleTextBox = new System.Windows.Forms.TextBox ( );
            this.lambdaAngleErrorTextBox = new System.Windows.Forms.TextBox ( );
            this.tzeroVrLabel = new System.Windows.Forms.Label ( );
            this.tzeroVrTextBox = new System.Windows.Forms.TextBox ( );
            this.tzeroVrErrorTextBox = new System.Windows.Forms.TextBox ( );
            this.calculatedTemperatureTextBox = new System.Windows.Forms.TextBox ( );
            this.calculatedTemperatureLabel = new System.Windows.Forms.Label ( );
            this.measuredTemperatureLabel = new System.Windows.Forms.Label ( );
            this.measuredTemperatureTextBox = new System.Windows.Forms.TextBox ( );
            this.hotPointLonLabel = new System.Windows.Forms.Label ( );
            this.hotPointLonTextBox = new System.Windows.Forms.TextBox ( );
            this.logGLabel = new System.Windows.Forms.Label ( );
            this.logGTextBox = new System.Windows.Forms.TextBox ( );
            this.publicationStatusLabel = new System.Windows.Forms.Label ( );
            this.publicationStatusTextBox = new System.Windows.Forms.TextBox ( );
            this.updatedLabel = new System.Windows.Forms.Label ( );
            this.updatedTextBox = new System.Windows.Forms.TextBox ( );
            this.omegaLabel = new System.Windows.Forms.Label ( );
            this.omegaTextBox = new System.Windows.Forms.TextBox ( );
            this.omagaErrorTextBox = new System.Windows.Forms.TextBox ( );
            this.tperiLabel = new System.Windows.Forms.Label ( );
            this.tperiTextBox = new System.Windows.Forms.TextBox ( );
            this.tperiErrorTextBox = new System.Windows.Forms.TextBox ( );
            this.detectionTypeTextBox = new System.Windows.Forms.TextBox ( );
            this.detectionTypeLabel = new System.Windows.Forms.Label ( );
            this.moleculesLabel = new System.Windows.Forms.Label ( );
            this.moleculesTextBox = new System.Windows.Forms.TextBox ( );
            this.impactParameterLabel = new System.Windows.Forms.Label ( );
            this.impactParameterTextBox = new System.Windows.Forms.TextBox ( );
            this.impactParameterErrorTextBox = new System.Windows.Forms.TextBox ( );
            this.kLabel = new System.Windows.Forms.Label ( );
            this.kTextBox = new System.Windows.Forms.TextBox ( );
            this.kErrorTextBox = new System.Windows.Forms.TextBox ( );
            this.geometricAlbedoLabel = new System.Windows.Forms.Label ( );
            this.geometricAlbedoTextBox = new System.Windows.Forms.TextBox ( );
            this.geometricAlbedoErrorTextBox = new System.Windows.Forms.TextBox ( );
            this.tconjLabel = new System.Windows.Forms.Label ( );
            this.tconjTextBox = new System.Windows.Forms.TextBox ( );
            this.tconjErrorTextBox = new System.Windows.Forms.TextBox ( );
            this.massDetectionLabel = new System.Windows.Forms.Label ( );
            this.massDetectionTextBox = new System.Windows.Forms.TextBox ( );
            this.radiusDetectionLabel = new System.Windows.Forms.Label ( );
            this.radiusDetectionTextBox = new System.Windows.Forms.TextBox ( );
            this.alternateNamesLabel = new System.Windows.Forms.Label ( );
            this.alternateNamesTextBox = new System.Windows.Forms.TextBox ( );
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
            this.nameTextBox.Location = new System.Drawing.Point ( 135, 5 );
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.nameTextBox.TabIndex = 1;
            // 
            // massLabel
            // 
            this.massLabel.AutoSize = true;
            this.massLabel.Location = new System.Drawing.Point ( 5, 30 );
            this.massLabel.Name = "massLabel";
            this.massLabel.Size = new System.Drawing.Size ( 67, 13 );
            this.massLabel.TabIndex = 2;
            this.massLabel.Text = "Mass (Mjup):";
            // 
            // massTextBox
            // 
            this.massTextBox.Location = new System.Drawing.Point ( 135, 30 );
            this.massTextBox.Name = "massTextBox";
            this.massTextBox.ReadOnly = true;
            this.massTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.massTextBox.TabIndex = 3;
            // 
            // massErrorTextBox
            // 
            this.massErrorTextBox.Location = new System.Drawing.Point ( 265, 30 );
            this.massErrorTextBox.Name = "massErrorTextBox";
            this.massErrorTextBox.ReadOnly = true;
            this.massErrorTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.massErrorTextBox.TabIndex = 4;
            // 
            // radiusLabel
            // 
            this.radiusLabel.AutoSize = true;
            this.radiusLabel.Location = new System.Drawing.Point ( 5, 55 );
            this.radiusLabel.Name = "radiusLabel";
            this.radiusLabel.Size = new System.Drawing.Size ( 74, 13 );
            this.radiusLabel.TabIndex = 5;
            this.radiusLabel.Text = "Radius (Rjup):";
            // 
            // radiusTextBox
            // 
            this.radiusTextBox.Location = new System.Drawing.Point ( 135, 55 );
            this.radiusTextBox.Name = "radiusTextBox";
            this.radiusTextBox.ReadOnly = true;
            this.radiusTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.radiusTextBox.TabIndex = 6;
            // 
            // radiusErrorTextBox
            // 
            this.radiusErrorTextBox.Location = new System.Drawing.Point ( 265, 55 );
            this.radiusErrorTextBox.Name = "radiusErrorTextBox";
            this.radiusErrorTextBox.ReadOnly = true;
            this.radiusErrorTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.radiusErrorTextBox.TabIndex = 7;
            // 
            // orbitalPeriodLabel
            // 
            this.orbitalPeriodLabel.AutoSize = true;
            this.orbitalPeriodLabel.Location = new System.Drawing.Point ( 5, 80 );
            this.orbitalPeriodLabel.Name = "orbitalPeriodLabel";
            this.orbitalPeriodLabel.Size = new System.Drawing.Size ( 101, 13 );
            this.orbitalPeriodLabel.TabIndex = 8;
            this.orbitalPeriodLabel.Text = "Orbital Period (Day):";
            // 
            // orbitalPeriodTextBox
            // 
            this.orbitalPeriodTextBox.Location = new System.Drawing.Point ( 135, 80 );
            this.orbitalPeriodTextBox.Name = "orbitalPeriodTextBox";
            this.orbitalPeriodTextBox.ReadOnly = true;
            this.orbitalPeriodTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.orbitalPeriodTextBox.TabIndex = 9;
            // 
            // orbitalPeriodErrorTextBox
            // 
            this.orbitalPeriodErrorTextBox.Location = new System.Drawing.Point ( 265, 80 );
            this.orbitalPeriodErrorTextBox.Name = "orbitalPeriodErrorTextBox";
            this.orbitalPeriodErrorTextBox.ReadOnly = true;
            this.orbitalPeriodErrorTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.orbitalPeriodErrorTextBox.TabIndex = 10;
            // 
            // semimajorAxisLabel
            // 
            this.semimajorAxisLabel.AutoSize = true;
            this.semimajorAxisLabel.Location = new System.Drawing.Point ( 5, 105 );
            this.semimajorAxisLabel.Name = "semimajorAxisLabel";
            this.semimajorAxisLabel.Size = new System.Drawing.Size ( 84, 13 );
            this.semimajorAxisLabel.TabIndex = 11;
            this.semimajorAxisLabel.Text = "Semi-Major Axis:";
            // 
            // semimajorAxisTextBox
            // 
            this.semimajorAxisTextBox.Location = new System.Drawing.Point ( 135, 105 );
            this.semimajorAxisTextBox.Name = "semimajorAxisTextBox";
            this.semimajorAxisTextBox.ReadOnly = true;
            this.semimajorAxisTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.semimajorAxisTextBox.TabIndex = 12;
            // 
            // semimajorAxisErrorTextBox
            // 
            this.semimajorAxisErrorTextBox.Location = new System.Drawing.Point ( 265, 105 );
            this.semimajorAxisErrorTextBox.Name = "semimajorAxisErrorTextBox";
            this.semimajorAxisErrorTextBox.ReadOnly = true;
            this.semimajorAxisErrorTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.semimajorAxisErrorTextBox.TabIndex = 13;
            // 
            // eccentricityLabel
            // 
            this.eccentricityLabel.AutoSize = true;
            this.eccentricityLabel.Location = new System.Drawing.Point ( 5, 130 );
            this.eccentricityLabel.Name = "eccentricityLabel";
            this.eccentricityLabel.Size = new System.Drawing.Size ( 65, 13 );
            this.eccentricityLabel.TabIndex = 14;
            this.eccentricityLabel.Text = "Eccentricity:";
            // 
            // eccentricityTextBox
            // 
            this.eccentricityTextBox.Location = new System.Drawing.Point ( 135, 130 );
            this.eccentricityTextBox.Name = "eccentricityTextBox";
            this.eccentricityTextBox.ReadOnly = true;
            this.eccentricityTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.eccentricityTextBox.TabIndex = 15;
            // 
            // eccentricityErrorTextBox
            // 
            this.eccentricityErrorTextBox.Location = new System.Drawing.Point ( 265, 130 );
            this.eccentricityErrorTextBox.Name = "eccentricityErrorTextBox";
            this.eccentricityErrorTextBox.ReadOnly = true;
            this.eccentricityErrorTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.eccentricityErrorTextBox.TabIndex = 16;
            // 
            // angularDistanceLabel
            // 
            this.angularDistanceLabel.AutoSize = true;
            this.angularDistanceLabel.Location = new System.Drawing.Point ( 5, 155 );
            this.angularDistanceLabel.Name = "angularDistanceLabel";
            this.angularDistanceLabel.Size = new System.Drawing.Size ( 91, 13 );
            this.angularDistanceLabel.TabIndex = 17;
            this.angularDistanceLabel.Text = "Angular Distance:";
            // 
            // angularDistanceTextBox
            // 
            this.angularDistanceTextBox.Location = new System.Drawing.Point ( 135, 155 );
            this.angularDistanceTextBox.Name = "angularDistanceTextBox";
            this.angularDistanceTextBox.ReadOnly = true;
            this.angularDistanceTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.angularDistanceTextBox.TabIndex = 18;
            // 
            // inclinationLabel
            // 
            this.inclinationLabel.AutoSize = true;
            this.inclinationLabel.Location = new System.Drawing.Point ( 5, 180 );
            this.inclinationLabel.Name = "inclinationLabel";
            this.inclinationLabel.Size = new System.Drawing.Size ( 58, 13 );
            this.inclinationLabel.TabIndex = 19;
            this.inclinationLabel.Text = "Inclination:";
            // 
            // inclinationTextBox
            // 
            this.inclinationTextBox.Location = new System.Drawing.Point ( 135, 180 );
            this.inclinationTextBox.Name = "inclinationTextBox";
            this.inclinationTextBox.ReadOnly = true;
            this.inclinationTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.inclinationTextBox.TabIndex = 20;
            // 
            // inclinationErrorTextBox
            // 
            this.inclinationErrorTextBox.Location = new System.Drawing.Point ( 265, 180 );
            this.inclinationErrorTextBox.Name = "inclinationErrorTextBox";
            this.inclinationErrorTextBox.ReadOnly = true;
            this.inclinationErrorTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.inclinationErrorTextBox.TabIndex = 21;
            // 
            // tzeroTrLabel
            // 
            this.tzeroTrLabel.AutoSize = true;
            this.tzeroTrLabel.Location = new System.Drawing.Point ( 5, 205 );
            this.tzeroTrLabel.Name = "tzeroTrLabel";
            this.tzeroTrLabel.Size = new System.Drawing.Size ( 45, 13 );
            this.tzeroTrLabel.TabIndex = 22;
            this.tzeroTrLabel.Text = "T0 (JD):";
            // 
            // tzeroTrTextBox
            // 
            this.tzeroTrTextBox.Location = new System.Drawing.Point ( 135, 205 );
            this.tzeroTrTextBox.Name = "tzeroTrTextBox";
            this.tzeroTrTextBox.ReadOnly = true;
            this.tzeroTrTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.tzeroTrTextBox.TabIndex = 23;
            // 
            // tzeroTrErrorTextBox
            // 
            this.tzeroTrErrorTextBox.Location = new System.Drawing.Point ( 265, 205 );
            this.tzeroTrErrorTextBox.Name = "tzeroTrErrorTextBox";
            this.tzeroTrErrorTextBox.ReadOnly = true;
            this.tzeroTrErrorTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.tzeroTrErrorTextBox.TabIndex = 24;
            // 
            // tzeroTrSecLabel
            // 
            this.tzeroTrSecLabel.AutoSize = true;
            this.tzeroTrSecLabel.Location = new System.Drawing.Point ( 5, 230 );
            this.tzeroTrSecLabel.Name = "tzeroTrSecLabel";
            this.tzeroTrSecLabel.Size = new System.Drawing.Size ( 65, 13 );
            this.tzeroTrSecLabel.TabIndex = 25;
            this.tzeroTrSecLabel.Text = "T0-sec (JD):";
            // 
            // tzeroTrSecTextBox
            // 
            this.tzeroTrSecTextBox.Location = new System.Drawing.Point ( 135, 230 );
            this.tzeroTrSecTextBox.Name = "tzeroTrSecTextBox";
            this.tzeroTrSecTextBox.ReadOnly = true;
            this.tzeroTrSecTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.tzeroTrSecTextBox.TabIndex = 26;
            // 
            // tzeroTrSecErrorTextBox
            // 
            this.tzeroTrSecErrorTextBox.Location = new System.Drawing.Point ( 265, 230 );
            this.tzeroTrSecErrorTextBox.Name = "tzeroTrSecErrorTextBox";
            this.tzeroTrSecErrorTextBox.ReadOnly = true;
            this.tzeroTrSecErrorTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.tzeroTrSecErrorTextBox.TabIndex = 27;
            // 
            // lambdaAngleLabel
            // 
            this.lambdaAngleLabel.AutoSize = true;
            this.lambdaAngleLabel.Location = new System.Drawing.Point ( 5, 255 );
            this.lambdaAngleLabel.Name = "lambdaAngleLabel";
            this.lambdaAngleLabel.Size = new System.Drawing.Size ( 105, 13 );
            this.lambdaAngleLabel.TabIndex = 28;
            this.lambdaAngleLabel.Text = "Lambda Angle (deg):";
            // 
            // lambdaAngleTextBox
            // 
            this.lambdaAngleTextBox.Location = new System.Drawing.Point ( 135, 255 );
            this.lambdaAngleTextBox.Name = "lambdaAngleTextBox";
            this.lambdaAngleTextBox.ReadOnly = true;
            this.lambdaAngleTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.lambdaAngleTextBox.TabIndex = 29;
            // 
            // lambdaAngleErrorTextBox
            // 
            this.lambdaAngleErrorTextBox.Location = new System.Drawing.Point ( 265, 255 );
            this.lambdaAngleErrorTextBox.Name = "lambdaAngleErrorTextBox";
            this.lambdaAngleErrorTextBox.ReadOnly = true;
            this.lambdaAngleErrorTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.lambdaAngleErrorTextBox.TabIndex = 30;
            // 
            // tzeroVrLabel
            // 
            this.tzeroVrLabel.AutoSize = true;
            this.tzeroVrLabel.Location = new System.Drawing.Point ( 5, 280 );
            this.tzeroVrLabel.Name = "tzeroVrLabel";
            this.tzeroVrLabel.Size = new System.Drawing.Size ( 48, 13 );
            this.tzeroVrLabel.TabIndex = 32;
            this.tzeroVrLabel.Text = "Tvr (JD):";
            // 
            // tzeroVrTextBox
            // 
            this.tzeroVrTextBox.Location = new System.Drawing.Point ( 135, 280 );
            this.tzeroVrTextBox.Name = "tzeroVrTextBox";
            this.tzeroVrTextBox.ReadOnly = true;
            this.tzeroVrTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.tzeroVrTextBox.TabIndex = 33;
            // 
            // tzeroVrErrorTextBox
            // 
            this.tzeroVrErrorTextBox.Location = new System.Drawing.Point ( 265, 280 );
            this.tzeroVrErrorTextBox.Name = "tzeroVrErrorTextBox";
            this.tzeroVrErrorTextBox.ReadOnly = true;
            this.tzeroVrErrorTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.tzeroVrErrorTextBox.TabIndex = 31;
            // 
            // calculatedTemperatureTextBox
            // 
            this.calculatedTemperatureTextBox.Location = new System.Drawing.Point ( 135, 305 );
            this.calculatedTemperatureTextBox.Name = "calculatedTemperatureTextBox";
            this.calculatedTemperatureTextBox.ReadOnly = true;
            this.calculatedTemperatureTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.calculatedTemperatureTextBox.TabIndex = 35;
            // 
            // calculatedTemperatureLabel
            // 
            this.calculatedTemperatureLabel.AutoSize = true;
            this.calculatedTemperatureLabel.Location = new System.Drawing.Point ( 5, 305 );
            this.calculatedTemperatureLabel.Name = "calculatedTemperatureLabel";
            this.calculatedTemperatureLabel.Size = new System.Drawing.Size ( 56, 13 );
            this.calculatedTemperatureLabel.TabIndex = 34;
            this.calculatedTemperatureLabel.Text = "Tcalc. (K):";
            // 
            // measuredTemperatureLabel
            // 
            this.measuredTemperatureLabel.AutoSize = true;
            this.measuredTemperatureLabel.Location = new System.Drawing.Point ( 5, 330 );
            this.measuredTemperatureLabel.Name = "measuredTemperatureLabel";
            this.measuredTemperatureLabel.Size = new System.Drawing.Size ( 58, 13 );
            this.measuredTemperatureLabel.TabIndex = 36;
            this.measuredTemperatureLabel.Text = "Tmeas (K):";
            // 
            // measuredTemperatureTextBox
            // 
            this.measuredTemperatureTextBox.Location = new System.Drawing.Point ( 135, 330 );
            this.measuredTemperatureTextBox.Name = "measuredTemperatureTextBox";
            this.measuredTemperatureTextBox.ReadOnly = true;
            this.measuredTemperatureTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.measuredTemperatureTextBox.TabIndex = 37;
            // 
            // hotPointLonLabel
            // 
            this.hotPointLonLabel.AutoSize = true;
            this.hotPointLonLabel.Location = new System.Drawing.Point ( 5, 355 );
            this.hotPointLonLabel.Name = "hotPointLonLabel";
            this.hotPointLonLabel.Size = new System.Drawing.Size ( 81, 13 );
            this.hotPointLonLabel.TabIndex = 38;
            this.hotPointLonLabel.Text = "Hot Point Long:";
            // 
            // hotPointLonTextBox
            // 
            this.hotPointLonTextBox.Location = new System.Drawing.Point ( 135, 355 );
            this.hotPointLonTextBox.Name = "hotPointLonTextBox";
            this.hotPointLonTextBox.ReadOnly = true;
            this.hotPointLonTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.hotPointLonTextBox.TabIndex = 39;
            // 
            // logGLabel
            // 
            this.logGLabel.AutoSize = true;
            this.logGLabel.Location = new System.Drawing.Point ( 5, 380 );
            this.logGLabel.Name = "logGLabel";
            this.logGLabel.Size = new System.Drawing.Size ( 40, 13 );
            this.logGLabel.TabIndex = 40;
            this.logGLabel.Text = "Log(g):";
            // 
            // logGTextBox
            // 
            this.logGTextBox.Location = new System.Drawing.Point ( 135, 380 );
            this.logGTextBox.Name = "logGTextBox";
            this.logGTextBox.ReadOnly = true;
            this.logGTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.logGTextBox.TabIndex = 41;
            // 
            // publicationStatusLabel
            // 
            this.publicationStatusLabel.AutoSize = true;
            this.publicationStatusLabel.Location = new System.Drawing.Point ( 5, 405 );
            this.publicationStatusLabel.Name = "publicationStatusLabel";
            this.publicationStatusLabel.Size = new System.Drawing.Size ( 65, 13 );
            this.publicationStatusLabel.TabIndex = 42;
            this.publicationStatusLabel.Text = "Pub. Status:";
            // 
            // publicationStatusTextBox
            // 
            this.publicationStatusTextBox.Location = new System.Drawing.Point ( 135, 405 );
            this.publicationStatusTextBox.Name = "publicationStatusTextBox";
            this.publicationStatusTextBox.ReadOnly = true;
            this.publicationStatusTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.publicationStatusTextBox.TabIndex = 43;
            // 
            // updatedLabel
            // 
            this.updatedLabel.AutoSize = true;
            this.updatedLabel.Location = new System.Drawing.Point ( 5, 431 );
            this.updatedLabel.Name = "updatedLabel";
            this.updatedLabel.Size = new System.Drawing.Size ( 51, 13 );
            this.updatedLabel.TabIndex = 44;
            this.updatedLabel.Text = "Updated:";
            // 
            // updatedTextBox
            // 
            this.updatedTextBox.Location = new System.Drawing.Point ( 135, 431 );
            this.updatedTextBox.Name = "updatedTextBox";
            this.updatedTextBox.ReadOnly = true;
            this.updatedTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.updatedTextBox.TabIndex = 45;
            // 
            // omegaLabel
            // 
            this.omegaLabel.AutoSize = true;
            this.omegaLabel.Location = new System.Drawing.Point ( 5, 455 );
            this.omegaLabel.Name = "omegaLabel";
            this.omegaLabel.Size = new System.Drawing.Size ( 44, 13 );
            this.omegaLabel.TabIndex = 46;
            this.omegaLabel.Text = "Omega:";
            // 
            // omegaTextBox
            // 
            this.omegaTextBox.Location = new System.Drawing.Point ( 135, 455 );
            this.omegaTextBox.Name = "omegaTextBox";
            this.omegaTextBox.ReadOnly = true;
            this.omegaTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.omegaTextBox.TabIndex = 47;
            // 
            // omagaErrorTextBox
            // 
            this.omagaErrorTextBox.Location = new System.Drawing.Point ( 265, 455 );
            this.omagaErrorTextBox.Name = "omagaErrorTextBox";
            this.omagaErrorTextBox.ReadOnly = true;
            this.omagaErrorTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.omagaErrorTextBox.TabIndex = 48;
            // 
            // tperiLabel
            // 
            this.tperiLabel.AutoSize = true;
            this.tperiLabel.Location = new System.Drawing.Point ( 5, 480 );
            this.tperiLabel.Name = "tperiLabel";
            this.tperiLabel.Size = new System.Drawing.Size ( 34, 13 );
            this.tperiLabel.TabIndex = 49;
            this.tperiLabel.Text = "Tperi:";
            // 
            // tperiTextBox
            // 
            this.tperiTextBox.Location = new System.Drawing.Point ( 135, 480 );
            this.tperiTextBox.Name = "tperiTextBox";
            this.tperiTextBox.ReadOnly = true;
            this.tperiTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.tperiTextBox.TabIndex = 50;
            // 
            // tperiErrorTextBox
            // 
            this.tperiErrorTextBox.Location = new System.Drawing.Point ( 265, 480 );
            this.tperiErrorTextBox.Name = "tperiErrorTextBox";
            this.tperiErrorTextBox.ReadOnly = true;
            this.tperiErrorTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.tperiErrorTextBox.TabIndex = 51;
            // 
            // detectionTypeTextBox
            // 
            this.detectionTypeTextBox.Location = new System.Drawing.Point ( 135, 505 );
            this.detectionTypeTextBox.Name = "detectionTypeTextBox";
            this.detectionTypeTextBox.ReadOnly = true;
            this.detectionTypeTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.detectionTypeTextBox.TabIndex = 53;
            // 
            // detectionTypeLabel
            // 
            this.detectionTypeLabel.AutoSize = true;
            this.detectionTypeLabel.Location = new System.Drawing.Point ( 5, 505 );
            this.detectionTypeLabel.Name = "detectionTypeLabel";
            this.detectionTypeLabel.Size = new System.Drawing.Size ( 83, 13 );
            this.detectionTypeLabel.TabIndex = 52;
            this.detectionTypeLabel.Text = "Detection Type:";
            // 
            // moleculesLabel
            // 
            this.moleculesLabel.AutoSize = true;
            this.moleculesLabel.Location = new System.Drawing.Point ( 5, 530 );
            this.moleculesLabel.Name = "moleculesLabel";
            this.moleculesLabel.Size = new System.Drawing.Size ( 58, 13 );
            this.moleculesLabel.TabIndex = 54;
            this.moleculesLabel.Text = "Molecules:";
            // 
            // moleculesTextBox
            // 
            this.moleculesTextBox.Location = new System.Drawing.Point ( 135, 530 );
            this.moleculesTextBox.Name = "moleculesTextBox";
            this.moleculesTextBox.ReadOnly = true;
            this.moleculesTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.moleculesTextBox.TabIndex = 55;
            // 
            // impactParameterLabel
            // 
            this.impactParameterLabel.AutoSize = true;
            this.impactParameterLabel.Location = new System.Drawing.Point ( 5, 554 );
            this.impactParameterLabel.Name = "impactParameterLabel";
            this.impactParameterLabel.Size = new System.Drawing.Size ( 93, 13 );
            this.impactParameterLabel.TabIndex = 56;
            this.impactParameterLabel.Text = "Impact Parameter:";
            // 
            // impactParameterTextBox
            // 
            this.impactParameterTextBox.Location = new System.Drawing.Point ( 135, 555 );
            this.impactParameterTextBox.Name = "impactParameterTextBox";
            this.impactParameterTextBox.ReadOnly = true;
            this.impactParameterTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.impactParameterTextBox.TabIndex = 57;
            // 
            // impactParameterErrorTextBox
            // 
            this.impactParameterErrorTextBox.Location = new System.Drawing.Point ( 265, 555 );
            this.impactParameterErrorTextBox.Name = "impactParameterErrorTextBox";
            this.impactParameterErrorTextBox.ReadOnly = true;
            this.impactParameterErrorTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.impactParameterErrorTextBox.TabIndex = 58;
            // 
            // kLabel
            // 
            this.kLabel.AutoSize = true;
            this.kLabel.Location = new System.Drawing.Point ( 5, 580 );
            this.kLabel.Name = "kLabel";
            this.kLabel.Size = new System.Drawing.Size ( 17, 13 );
            this.kLabel.TabIndex = 59;
            this.kLabel.Text = "K:";
            // 
            // kTextBox
            // 
            this.kTextBox.Location = new System.Drawing.Point ( 135, 581 );
            this.kTextBox.Name = "kTextBox";
            this.kTextBox.ReadOnly = true;
            this.kTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.kTextBox.TabIndex = 60;
            // 
            // kErrorTextBox
            // 
            this.kErrorTextBox.Location = new System.Drawing.Point ( 265, 581 );
            this.kErrorTextBox.Name = "kErrorTextBox";
            this.kErrorTextBox.ReadOnly = true;
            this.kErrorTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.kErrorTextBox.TabIndex = 61;
            // 
            // geometricAlbedoLabel
            // 
            this.geometricAlbedoLabel.AutoSize = true;
            this.geometricAlbedoLabel.Location = new System.Drawing.Point ( 5, 605 );
            this.geometricAlbedoLabel.Name = "geometricAlbedoLabel";
            this.geometricAlbedoLabel.Size = new System.Drawing.Size ( 94, 13 );
            this.geometricAlbedoLabel.TabIndex = 62;
            this.geometricAlbedoLabel.Text = "Geometric Albedo:";
            // 
            // geometricAlbedoTextBox
            // 
            this.geometricAlbedoTextBox.Location = new System.Drawing.Point ( 135, 606 );
            this.geometricAlbedoTextBox.Name = "geometricAlbedoTextBox";
            this.geometricAlbedoTextBox.ReadOnly = true;
            this.geometricAlbedoTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.geometricAlbedoTextBox.TabIndex = 63;
            // 
            // geometricAlbedoErrorTextBox
            // 
            this.geometricAlbedoErrorTextBox.Location = new System.Drawing.Point ( 265, 606 );
            this.geometricAlbedoErrorTextBox.Name = "geometricAlbedoErrorTextBox";
            this.geometricAlbedoErrorTextBox.ReadOnly = true;
            this.geometricAlbedoErrorTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.geometricAlbedoErrorTextBox.TabIndex = 64;
            // 
            // tconjLabel
            // 
            this.tconjLabel.AutoSize = true;
            this.tconjLabel.Location = new System.Drawing.Point ( 5, 630 );
            this.tconjLabel.Name = "tconjLabel";
            this.tconjLabel.Size = new System.Drawing.Size ( 37, 13 );
            this.tconjLabel.TabIndex = 65;
            this.tconjLabel.Text = "Tconj:";
            // 
            // tconjTextBox
            // 
            this.tconjTextBox.Location = new System.Drawing.Point ( 135, 631 );
            this.tconjTextBox.Name = "tconjTextBox";
            this.tconjTextBox.ReadOnly = true;
            this.tconjTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.tconjTextBox.TabIndex = 66;
            // 
            // tconjErrorTextBox
            // 
            this.tconjErrorTextBox.Location = new System.Drawing.Point ( 265, 631 );
            this.tconjErrorTextBox.Name = "tconjErrorTextBox";
            this.tconjErrorTextBox.ReadOnly = true;
            this.tconjErrorTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.tconjErrorTextBox.TabIndex = 67;
            // 
            // massDetectionLabel
            // 
            this.massDetectionLabel.AutoSize = true;
            this.massDetectionLabel.Location = new System.Drawing.Point ( 5, 655 );
            this.massDetectionLabel.Name = "massDetectionLabel";
            this.massDetectionLabel.Size = new System.Drawing.Size ( 84, 13 );
            this.massDetectionLabel.TabIndex = 68;
            this.massDetectionLabel.Text = "Mass Detection:";
            // 
            // massDetectionTextBox
            // 
            this.massDetectionTextBox.Location = new System.Drawing.Point ( 135, 656 );
            this.massDetectionTextBox.Name = "massDetectionTextBox";
            this.massDetectionTextBox.ReadOnly = true;
            this.massDetectionTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.massDetectionTextBox.TabIndex = 69;
            // 
            // radiusDetectionLabel
            // 
            this.radiusDetectionLabel.AutoSize = true;
            this.radiusDetectionLabel.Location = new System.Drawing.Point ( 5, 680 );
            this.radiusDetectionLabel.Name = "radiusDetectionLabel";
            this.radiusDetectionLabel.Size = new System.Drawing.Size ( 92, 13 );
            this.radiusDetectionLabel.TabIndex = 70;
            this.radiusDetectionLabel.Text = "Radius Detection:";
            // 
            // radiusDetectionTextBox
            // 
            this.radiusDetectionTextBox.Location = new System.Drawing.Point ( 135, 681 );
            this.radiusDetectionTextBox.Name = "radiusDetectionTextBox";
            this.radiusDetectionTextBox.ReadOnly = true;
            this.radiusDetectionTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.radiusDetectionTextBox.TabIndex = 71;
            // 
            // alternateNamesLabel
            // 
            this.alternateNamesLabel.AutoSize = true;
            this.alternateNamesLabel.Location = new System.Drawing.Point ( 5, 705 );
            this.alternateNamesLabel.Name = "alternateNamesLabel";
            this.alternateNamesLabel.Size = new System.Drawing.Size ( 88, 13 );
            this.alternateNamesLabel.TabIndex = 72;
            this.alternateNamesLabel.Text = "Alternate Names:";
            // 
            // alternateNamesTextBox
            // 
            this.alternateNamesTextBox.Location = new System.Drawing.Point ( 135, 706 );
            this.alternateNamesTextBox.Name = "alternateNamesTextBox";
            this.alternateNamesTextBox.ReadOnly = true;
            this.alternateNamesTextBox.Size = new System.Drawing.Size ( 120, 20 );
            this.alternateNamesTextBox.TabIndex = 73;
            // 
            // ExoplanetDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size ( 390, 734 );
            this.Controls.Add ( this.alternateNamesLabel );
            this.Controls.Add ( this.alternateNamesTextBox );
            this.Controls.Add ( this.radiusDetectionLabel );
            this.Controls.Add ( this.radiusDetectionTextBox );
            this.Controls.Add ( this.massDetectionLabel );
            this.Controls.Add ( this.massDetectionTextBox );
            this.Controls.Add ( this.tconjLabel );
            this.Controls.Add ( this.tconjTextBox );
            this.Controls.Add ( this.tconjErrorTextBox );
            this.Controls.Add ( this.geometricAlbedoLabel );
            this.Controls.Add ( this.geometricAlbedoTextBox );
            this.Controls.Add ( this.geometricAlbedoErrorTextBox );
            this.Controls.Add ( this.kLabel );
            this.Controls.Add ( this.kTextBox );
            this.Controls.Add ( this.kErrorTextBox );
            this.Controls.Add ( this.impactParameterLabel );
            this.Controls.Add ( this.impactParameterTextBox );
            this.Controls.Add ( this.impactParameterErrorTextBox );
            this.Controls.Add ( this.nameLabel );
            this.Controls.Add ( this.nameTextBox );
            this.Controls.Add ( this.massLabel );
            this.Controls.Add ( this.massTextBox );
            this.Controls.Add ( this.massErrorTextBox );
            this.Controls.Add ( this.radiusLabel );
            this.Controls.Add ( this.radiusTextBox );
            this.Controls.Add ( this.radiusErrorTextBox );
            this.Controls.Add ( this.orbitalPeriodLabel );
            this.Controls.Add ( this.orbitalPeriodTextBox );
            this.Controls.Add ( this.orbitalPeriodErrorTextBox );
            this.Controls.Add ( this.semimajorAxisLabel );
            this.Controls.Add ( this.semimajorAxisTextBox );
            this.Controls.Add ( this.semimajorAxisErrorTextBox );
            this.Controls.Add ( this.eccentricityLabel );
            this.Controls.Add ( this.eccentricityTextBox );
            this.Controls.Add ( this.eccentricityErrorTextBox );
            this.Controls.Add ( this.angularDistanceLabel );
            this.Controls.Add ( this.angularDistanceTextBox );
            this.Controls.Add ( this.inclinationLabel );
            this.Controls.Add ( this.inclinationTextBox );
            this.Controls.Add ( this.inclinationErrorTextBox );
            this.Controls.Add ( this.tzeroTrLabel );
            this.Controls.Add ( this.tzeroTrTextBox );
            this.Controls.Add ( this.tzeroTrErrorTextBox );
            this.Controls.Add ( this.tzeroTrSecLabel );
            this.Controls.Add ( this.tzeroTrSecTextBox );
            this.Controls.Add ( this.tzeroTrSecErrorTextBox );
            this.Controls.Add ( this.lambdaAngleLabel );
            this.Controls.Add ( this.lambdaAngleTextBox );
            this.Controls.Add ( this.lambdaAngleErrorTextBox );
            this.Controls.Add ( this.tzeroVrLabel );
            this.Controls.Add ( this.tzeroVrTextBox );
            this.Controls.Add ( this.tzeroVrErrorTextBox );
            this.Controls.Add ( this.calculatedTemperatureLabel );
            this.Controls.Add ( this.calculatedTemperatureTextBox );
            this.Controls.Add ( this.measuredTemperatureLabel );
            this.Controls.Add ( this.measuredTemperatureTextBox );
            this.Controls.Add ( this.hotPointLonLabel );
            this.Controls.Add ( this.hotPointLonTextBox );
            this.Controls.Add ( this.logGLabel );
            this.Controls.Add ( this.logGTextBox );
            this.Controls.Add ( this.publicationStatusLabel );
            this.Controls.Add ( this.publicationStatusTextBox );
            this.Controls.Add ( this.updatedLabel );
            this.Controls.Add ( this.updatedTextBox );
            this.Controls.Add ( this.omegaLabel );
            this.Controls.Add ( this.omegaTextBox );
            this.Controls.Add ( this.omagaErrorTextBox );
            this.Controls.Add ( this.tperiLabel );
            this.Controls.Add ( this.tperiTextBox );
            this.Controls.Add ( this.tperiErrorTextBox );
            this.Controls.Add ( this.detectionTypeTextBox );
            this.Controls.Add ( this.detectionTypeLabel );
            this.Controls.Add ( this.moleculesLabel );
            this.Controls.Add ( this.moleculesTextBox );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExoplanetDetails";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Exoplanet Details";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler ( this.ExoplanetDetails_FormClosing );
            this.ResumeLayout ( false );
            this.PerformLayout ( );

            }

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;

        private System.Windows.Forms.Label massLabel;
        private System.Windows.Forms.TextBox massTextBox;
        private System.Windows.Forms.TextBox massErrorTextBox;

        private System.Windows.Forms.Label radiusLabel;
        private System.Windows.Forms.TextBox radiusTextBox;
        private System.Windows.Forms.TextBox radiusErrorTextBox;

        private System.Windows.Forms.Label orbitalPeriodLabel;
        private System.Windows.Forms.TextBox orbitalPeriodTextBox;
        private System.Windows.Forms.TextBox orbitalPeriodErrorTextBox;

        private System.Windows.Forms.Label semimajorAxisLabel;
        private System.Windows.Forms.TextBox semimajorAxisTextBox;
        private System.Windows.Forms.TextBox semimajorAxisErrorTextBox;

        private System.Windows.Forms.Label eccentricityLabel;
        private System.Windows.Forms.TextBox eccentricityTextBox;
        private System.Windows.Forms.TextBox eccentricityErrorTextBox;

        private System.Windows.Forms.Label angularDistanceLabel;
        private System.Windows.Forms.TextBox angularDistanceTextBox;

        private System.Windows.Forms.Label inclinationLabel;
        private System.Windows.Forms.TextBox inclinationTextBox;
        private System.Windows.Forms.TextBox inclinationErrorTextBox;

        private System.Windows.Forms.Label tzeroTrLabel;
        private System.Windows.Forms.TextBox tzeroTrTextBox;
        private System.Windows.Forms.TextBox tzeroTrErrorTextBox;

        private System.Windows.Forms.Label tzeroTrSecLabel;
        private System.Windows.Forms.TextBox tzeroTrSecTextBox;
        private System.Windows.Forms.TextBox tzeroTrSecErrorTextBox;

        private System.Windows.Forms.Label lambdaAngleLabel;
        private System.Windows.Forms.TextBox lambdaAngleTextBox;
        private System.Windows.Forms.TextBox lambdaAngleErrorTextBox;

        private System.Windows.Forms.Label tzeroVrLabel;
        private System.Windows.Forms.TextBox tzeroVrTextBox;
        private System.Windows.Forms.TextBox tzeroVrErrorTextBox;

        private System.Windows.Forms.Label calculatedTemperatureLabel;
        private System.Windows.Forms.TextBox calculatedTemperatureTextBox;

        private System.Windows.Forms.Label measuredTemperatureLabel;
        private System.Windows.Forms.TextBox measuredTemperatureTextBox;

        private System.Windows.Forms.Label hotPointLonLabel;
        private System.Windows.Forms.TextBox hotPointLonTextBox;

        private System.Windows.Forms.Label logGLabel;
        private System.Windows.Forms.TextBox logGTextBox;

        private System.Windows.Forms.Label publicationStatusLabel;
        private System.Windows.Forms.TextBox publicationStatusTextBox;

        private System.Windows.Forms.Label updatedLabel;
        private System.Windows.Forms.TextBox updatedTextBox;

        private System.Windows.Forms.Label omegaLabel;
        private System.Windows.Forms.TextBox omegaTextBox;
        private System.Windows.Forms.TextBox omagaErrorTextBox;

        private System.Windows.Forms.Label tperiLabel;
        private System.Windows.Forms.TextBox tperiTextBox;
        private System.Windows.Forms.TextBox tperiErrorTextBox;

        private System.Windows.Forms.Label detectionTypeLabel;
        private System.Windows.Forms.TextBox detectionTypeTextBox;

        private System.Windows.Forms.Label moleculesLabel;
        private System.Windows.Forms.TextBox moleculesTextBox;
        private Label impactParameterLabel;
        private TextBox impactParameterTextBox;
        private TextBox impactParameterErrorTextBox;
        private Label kLabel;
        private TextBox kTextBox;
        private TextBox kErrorTextBox;
        private Label geometricAlbedoLabel;
        private TextBox geometricAlbedoTextBox;
        private TextBox geometricAlbedoErrorTextBox;
        private Label tconjLabel;
        private TextBox tconjTextBox;
        private TextBox tconjErrorTextBox;
        private Label massDetectionLabel;
        private TextBox massDetectionTextBox;
        private Label radiusDetectionLabel;
        private TextBox radiusDetectionTextBox;
        private Label alternateNamesLabel;
        private TextBox alternateNamesTextBox;
        }
    }