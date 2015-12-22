namespace ExoplanetLibrary
    {
    partial class FilterByStarType
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
            {
            if (disposing && ( components != null ))
                {
                components.Dispose ();
                }
            base.Dispose (disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
            {
            this.TypeOCheckBox = new System.Windows.Forms.CheckBox();
            this.typeBCheckBox = new System.Windows.Forms.CheckBox();
            this.typeACheckBox = new System.Windows.Forms.CheckBox();
            this.typeFCheckBox = new System.Windows.Forms.CheckBox();
            this.typeGCheckBox = new System.Windows.Forms.CheckBox();
            this.typeKCheckBox = new System.Windows.Forms.CheckBox();
            this.starTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.allStarTypesCheckBox = new System.Windows.Forms.CheckBox();
            this.TypeMCheckBox = new System.Windows.Forms.CheckBox();
            this.starTypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // TypeOCheckBox
            // 
            this.TypeOCheckBox.AutoSize = true;
            this.TypeOCheckBox.Location = new System.Drawing.Point(10, 50);
            this.TypeOCheckBox.Name = "TypeOCheckBox";
            this.TypeOCheckBox.Size = new System.Drawing.Size(61, 17);
            this.TypeOCheckBox.TabIndex = 1;
            this.TypeOCheckBox.Text = "Type O";
            this.TypeOCheckBox.UseVisualStyleBackColor = true;
            // 
            // typeBCheckBox
            // 
            this.typeBCheckBox.AutoSize = true;
            this.typeBCheckBox.Location = new System.Drawing.Point(10, 75);
            this.typeBCheckBox.Name = "typeBCheckBox";
            this.typeBCheckBox.Size = new System.Drawing.Size(60, 17);
            this.typeBCheckBox.TabIndex = 2;
            this.typeBCheckBox.Text = "Type B";
            this.typeBCheckBox.UseVisualStyleBackColor = true;
            // 
            // typeACheckBox
            // 
            this.typeACheckBox.AutoSize = true;
            this.typeACheckBox.Location = new System.Drawing.Point(10, 100);
            this.typeACheckBox.Name = "typeACheckBox";
            this.typeACheckBox.Size = new System.Drawing.Size(60, 17);
            this.typeACheckBox.TabIndex = 3;
            this.typeACheckBox.Text = "Type A";
            this.typeACheckBox.UseVisualStyleBackColor = true;
            // 
            // typeFCheckBox
            // 
            this.typeFCheckBox.AutoSize = true;
            this.typeFCheckBox.Location = new System.Drawing.Point(10, 125);
            this.typeFCheckBox.Name = "typeFCheckBox";
            this.typeFCheckBox.Size = new System.Drawing.Size(59, 17);
            this.typeFCheckBox.TabIndex = 4;
            this.typeFCheckBox.Text = "Type F";
            this.typeFCheckBox.UseVisualStyleBackColor = true;
            // 
            // typeGCheckBox
            // 
            this.typeGCheckBox.AutoSize = true;
            this.typeGCheckBox.Location = new System.Drawing.Point(10, 150);
            this.typeGCheckBox.Name = "typeGCheckBox";
            this.typeGCheckBox.Size = new System.Drawing.Size(61, 17);
            this.typeGCheckBox.TabIndex = 5;
            this.typeGCheckBox.Text = "Type G";
            this.typeGCheckBox.UseVisualStyleBackColor = true;
            // 
            // typeKCheckBox
            // 
            this.typeKCheckBox.AutoSize = true;
            this.typeKCheckBox.Location = new System.Drawing.Point(10, 175);
            this.typeKCheckBox.Name = "typeKCheckBox";
            this.typeKCheckBox.Size = new System.Drawing.Size(60, 17);
            this.typeKCheckBox.TabIndex = 6;
            this.typeKCheckBox.Text = "Type K";
            this.typeKCheckBox.UseVisualStyleBackColor = true;
            // 
            // starTypeGroupBox
            // 
            this.starTypeGroupBox.Controls.Add(this.allStarTypesCheckBox);
            this.starTypeGroupBox.Controls.Add(this.TypeMCheckBox);
            this.starTypeGroupBox.Controls.Add(this.typeKCheckBox);
            this.starTypeGroupBox.Controls.Add(this.typeBCheckBox);
            this.starTypeGroupBox.Controls.Add(this.typeGCheckBox);
            this.starTypeGroupBox.Controls.Add(this.typeFCheckBox);
            this.starTypeGroupBox.Controls.Add(this.typeACheckBox);
            this.starTypeGroupBox.Controls.Add(this.TypeOCheckBox);
            this.starTypeGroupBox.Location = new System.Drawing.Point(10, 30);
            this.starTypeGroupBox.Name = "starTypeGroupBox";
            this.starTypeGroupBox.Size = new System.Drawing.Size(123, 222);
            this.starTypeGroupBox.TabIndex = 7;
            this.starTypeGroupBox.TabStop = false;
            this.starTypeGroupBox.Text = "Star Types";
            // 
            // allStarTypesCheckBox
            // 
            this.allStarTypesCheckBox.AutoSize = true;
            this.allStarTypesCheckBox.Location = new System.Drawing.Point(10, 25);
            this.allStarTypesCheckBox.Name = "allStarTypesCheckBox";
            this.allStarTypesCheckBox.Size = new System.Drawing.Size(91, 17);
            this.allStarTypesCheckBox.TabIndex = 8;
            this.allStarTypesCheckBox.Text = "All Star Types";
            this.allStarTypesCheckBox.UseVisualStyleBackColor = true;
            // 
            // TypeMCheckBox
            // 
            this.TypeMCheckBox.AutoSize = true;
            this.TypeMCheckBox.Location = new System.Drawing.Point(10, 200);
            this.TypeMCheckBox.Name = "TypeMCheckBox";
            this.TypeMCheckBox.Size = new System.Drawing.Size(62, 17);
            this.TypeMCheckBox.TabIndex = 7;
            this.TypeMCheckBox.Text = "Type M";
            this.TypeMCheckBox.UseVisualStyleBackColor = true;
            // 
            // FilterByStarType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(141, 300);
            this.Controls.Add(this.starTypeGroupBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterByStarType";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Filter";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Filter_FormClosing);
            this.starTypeGroupBox.ResumeLayout(false);
            this.starTypeGroupBox.PerformLayout();
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.CheckBox TypeOCheckBox;
        private System.Windows.Forms.CheckBox typeBCheckBox;
        private System.Windows.Forms.CheckBox typeACheckBox;
        private System.Windows.Forms.CheckBox typeFCheckBox;
        private System.Windows.Forms.CheckBox typeGCheckBox;
        private System.Windows.Forms.CheckBox typeKCheckBox;
        private System.Windows.Forms.GroupBox starTypeGroupBox;
        private System.Windows.Forms.CheckBox allStarTypesCheckBox;
        private System.Windows.Forms.CheckBox TypeMCheckBox;
        }
    }