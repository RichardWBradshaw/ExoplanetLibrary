namespace ExoplanetLibrary
    {
    partial class QueryDialog
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
            this.queryTextBox = new System.Windows.Forms.TextBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.queryLabel = new System.Windows.Forms.Label();
            this.queryComboBox = new System.Windows.Forms.ComboBox();
            this.updateQueryButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // queryTextBox
            // 
            this.queryTextBox.Location = new System.Drawing.Point(10, 80);
            this.queryTextBox.Multiline = true;
            this.queryTextBox.Name = "queryTextBox";
            this.queryTextBox.Size = new System.Drawing.Size(260, 132);
            this.queryTextBox.TabIndex = 0;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(162, 220);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(108, 21);
            this.applyButton.TabIndex = 1;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // queryLabel
            // 
            this.queryLabel.AutoSize = true;
            this.queryLabel.Location = new System.Drawing.Point(10, 10);
            this.queryLabel.Name = "queryLabel";
            this.queryLabel.Size = new System.Drawing.Size(38, 13);
            this.queryLabel.TabIndex = 3;
            this.queryLabel.Text = "Name:";
            // 
            // queryComboBox
            // 
            this.queryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.queryComboBox.FormattingEnabled = true;
            this.queryComboBox.Location = new System.Drawing.Point(10, 30);
            this.queryComboBox.Name = "queryComboBox";
            this.queryComboBox.Size = new System.Drawing.Size(260, 21);
            this.queryComboBox.TabIndex = 4;
            this.queryComboBox.SelectedIndexChanged += new System.EventHandler(this.queryComboBox_selectedIndexChanged);
            // 
            // updateQueryButton
            // 
            this.updateQueryButton.Location = new System.Drawing.Point(10, 220);
            this.updateQueryButton.Name = "updateQueryButton";
            this.updateQueryButton.Size = new System.Drawing.Size(108, 21);
            this.updateQueryButton.TabIndex = 5;
            this.updateQueryButton.Text = "Update Query";
            this.updateQueryButton.UseVisualStyleBackColor = true;
            this.updateQueryButton.Click += new System.EventHandler(this.updateQueryButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Where Clause:";
            // 
            // QueryDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 246);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.updateQueryButton);
            this.Controls.Add(this.queryComboBox);
            this.Controls.Add(this.queryLabel);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.queryTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QueryDialog";
            this.ShowIcon = false;
            this.Text = "Query Builder";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QueryBuilder_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.TextBox queryTextBox;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label queryLabel;
        private System.Windows.Forms.ComboBox queryComboBox;
        private System.Windows.Forms.Button updateQueryButton;
        private System.Windows.Forms.Label label1;
        }
    }