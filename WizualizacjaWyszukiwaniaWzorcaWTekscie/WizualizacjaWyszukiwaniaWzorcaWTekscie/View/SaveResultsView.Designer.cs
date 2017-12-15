namespace EngineeringProject.View
{
    partial class SaveResultsView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.destinationPathTextBox = new System.Windows.Forms.TextBox();
            this.detinationPathLabel = new System.Windows.Forms.Label();
            this.changePathButton = new System.Windows.Forms.Button();
            this.exampleTextBox = new System.Windows.Forms.TextBox();
            this.exampleLabel = new System.Windows.Forms.Label();
            this.defaultsCheckBox = new System.Windows.Forms.CheckBox();
            this.patternCheckBox = new System.Windows.Forms.CheckBox();
            this.patternLabel = new System.Windows.Forms.Label();
            this.indexesCheckBox = new System.Windows.Forms.CheckBox();
            this.indexesLabel = new System.Windows.Forms.Label();
            this.rangeCheckBox = new System.Windows.Forms.CheckBox();
            this.rangeLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // destinationPathTextBox
            // 
            this.destinationPathTextBox.Enabled = false;
            this.destinationPathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationPathTextBox.Location = new System.Drawing.Point(12, 30);
            this.destinationPathTextBox.Name = "destinationPathTextBox";
            this.destinationPathTextBox.Size = new System.Drawing.Size(197, 23);
            this.destinationPathTextBox.TabIndex = 0;
            // 
            // detinationPathLabel
            // 
            this.detinationPathLabel.AutoSize = true;
            this.detinationPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detinationPathLabel.Location = new System.Drawing.Point(12, 10);
            this.detinationPathLabel.Name = "detinationPathLabel";
            this.detinationPathLabel.Size = new System.Drawing.Size(111, 17);
            this.detinationPathLabel.TabIndex = 1;
            this.detinationPathLabel.Text = "Destination path";
            // 
            // changePathButton
            // 
            this.changePathButton.Enabled = false;
            this.changePathButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changePathButton.Location = new System.Drawing.Point(215, 27);
            this.changePathButton.Name = "changePathButton";
            this.changePathButton.Size = new System.Drawing.Size(83, 26);
            this.changePathButton.TabIndex = 2;
            this.changePathButton.Text = "Change";
            this.changePathButton.UseVisualStyleBackColor = true;
            this.changePathButton.Click += new System.EventHandler(this.changePathButton_Click);
            // 
            // exampleTextBox
            // 
            this.exampleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exampleTextBox.Location = new System.Drawing.Point(12, 232);
            this.exampleTextBox.Name = "exampleTextBox";
            this.exampleTextBox.ReadOnly = true;
            this.exampleTextBox.Size = new System.Drawing.Size(319, 23);
            this.exampleTextBox.TabIndex = 3;
            this.exampleTextBox.Text = "Przykł linia";
            // 
            // exampleLabel
            // 
            this.exampleLabel.AutoSize = true;
            this.exampleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exampleLabel.Location = new System.Drawing.Point(12, 212);
            this.exampleLabel.Name = "exampleLabel";
            this.exampleLabel.Size = new System.Drawing.Size(87, 17);
            this.exampleLabel.TabIndex = 4;
            this.exampleLabel.Text = "Example row";
            // 
            // defaultsCheckBox
            // 
            this.defaultsCheckBox.AutoSize = true;
            this.defaultsCheckBox.Checked = true;
            this.defaultsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.defaultsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultsCheckBox.Location = new System.Drawing.Point(192, 63);
            this.defaultsCheckBox.Name = "defaultsCheckBox";
            this.defaultsCheckBox.Size = new System.Drawing.Size(106, 21);
            this.defaultsCheckBox.TabIndex = 17;
            this.defaultsCheckBox.Text = "Use defaults";
            this.defaultsCheckBox.UseVisualStyleBackColor = true;
            this.defaultsCheckBox.CheckedChanged += new System.EventHandler(this.defaultsCheckBox_CheckedChanged);
            // 
            // patternCheckBox
            // 
            this.patternCheckBox.AutoSize = true;
            this.patternCheckBox.Enabled = false;
            this.patternCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patternCheckBox.Location = new System.Drawing.Point(15, 87);
            this.patternCheckBox.Name = "patternCheckBox";
            this.patternCheckBox.Size = new System.Drawing.Size(73, 21);
            this.patternCheckBox.TabIndex = 20;
            this.patternCheckBox.Tag = "pattern";
            this.patternCheckBox.Text = "Pattern";
            this.patternCheckBox.UseVisualStyleBackColor = true;
            // 
            // patternLabel
            // 
            this.patternLabel.AutoSize = true;
            this.patternLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patternLabel.Location = new System.Drawing.Point(12, 64);
            this.patternLabel.Name = "patternLabel";
            this.patternLabel.Size = new System.Drawing.Size(82, 17);
            this.patternLabel.TabIndex = 19;
            this.patternLabel.Text = "Add pattern";
            // 
            // indexesCheckBox
            // 
            this.indexesCheckBox.AutoSize = true;
            this.indexesCheckBox.Enabled = false;
            this.indexesCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.indexesCheckBox.Location = new System.Drawing.Point(15, 182);
            this.indexesCheckBox.Name = "indexesCheckBox";
            this.indexesCheckBox.Size = new System.Drawing.Size(119, 21);
            this.indexesCheckBox.TabIndex = 26;
            this.indexesCheckBox.Tag = "indexes";
            this.indexesCheckBox.Text = "Result indexes";
            this.indexesCheckBox.UseVisualStyleBackColor = true;
            // 
            // indexesLabel
            // 
            this.indexesLabel.AutoSize = true;
            this.indexesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.indexesLabel.Location = new System.Drawing.Point(12, 159);
            this.indexesLabel.Name = "indexesLabel";
            this.indexesLabel.Size = new System.Drawing.Size(124, 17);
            this.indexesLabel.TabIndex = 25;
            this.indexesLabel.Text = "Add result indexes";
            // 
            // rangeCheckBox
            // 
            this.rangeCheckBox.AutoSize = true;
            this.rangeCheckBox.Enabled = false;
            this.rangeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rangeCheckBox.Location = new System.Drawing.Point(15, 134);
            this.rangeCheckBox.Name = "rangeCheckBox";
            this.rangeCheckBox.Size = new System.Drawing.Size(69, 21);
            this.rangeCheckBox.TabIndex = 23;
            this.rangeCheckBox.Tag = "range";
            this.rangeCheckBox.Text = "Range";
            this.rangeCheckBox.UseVisualStyleBackColor = true;
            // 
            // rangeLabel
            // 
            this.rangeLabel.AutoSize = true;
            this.rangeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rangeLabel.Location = new System.Drawing.Point(12, 111);
            this.rangeLabel.Name = "rangeLabel";
            this.rangeLabel.Size = new System.Drawing.Size(74, 17);
            this.rangeLabel.TabIndex = 22;
            this.rangeLabel.Text = "Add range";
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(186, 271);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(83, 26);
            this.saveButton.TabIndex = 27;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(275, 271);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(83, 26);
            this.cancelButton.TabIndex = 28;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Text(.txt)|*.txt";
            // 
            // SaveResultsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 308);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.indexesCheckBox);
            this.Controls.Add(this.indexesLabel);
            this.Controls.Add(this.rangeCheckBox);
            this.Controls.Add(this.rangeLabel);
            this.Controls.Add(this.patternCheckBox);
            this.Controls.Add(this.patternLabel);
            this.Controls.Add(this.defaultsCheckBox);
            this.Controls.Add(this.exampleLabel);
            this.Controls.Add(this.exampleTextBox);
            this.Controls.Add(this.changePathButton);
            this.Controls.Add(this.detinationPathLabel);
            this.Controls.Add(this.destinationPathTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SaveResultsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save results";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox destinationPathTextBox;
        private System.Windows.Forms.Label detinationPathLabel;
        private System.Windows.Forms.Button changePathButton;
        private System.Windows.Forms.TextBox exampleTextBox;
        private System.Windows.Forms.Label exampleLabel;
        private System.Windows.Forms.CheckBox defaultsCheckBox;
        private System.Windows.Forms.CheckBox patternCheckBox;
        private System.Windows.Forms.Label patternLabel;
        private System.Windows.Forms.CheckBox indexesCheckBox;
        private System.Windows.Forms.Label indexesLabel;
        private System.Windows.Forms.CheckBox rangeCheckBox;
        private System.Windows.Forms.Label rangeLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}