namespace ProjektInzynierski
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.rtb_zakres = new System.Windows.Forms.RichTextBox();
            this.tb_wzorzec = new System.Windows.Forms.TextBox();
            this.b_Szukaj = new System.Windows.Forms.Button();
            this.tb_liczbaWystapien = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rtb_zakres
            // 
            this.rtb_zakres.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_zakres.Location = new System.Drawing.Point(35, 70);
            this.rtb_zakres.Name = "rtb_zakres";
            this.rtb_zakres.Size = new System.Drawing.Size(622, 289);
            this.rtb_zakres.TabIndex = 0;
            this.rtb_zakres.Text = "";
            this.rtb_zakres.TextChanged += new System.EventHandler(this.rtb_zakres_TextChanged);
            // 
            // tb_wzorzec
            // 
            this.tb_wzorzec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_wzorzec.Location = new System.Drawing.Point(27, 27);
            this.tb_wzorzec.Name = "tb_wzorzec";
            this.tb_wzorzec.Size = new System.Drawing.Size(622, 26);
            this.tb_wzorzec.TabIndex = 1;
            this.tb_wzorzec.TextChanged += new System.EventHandler(this.tb_wzorzec_TextChanged);
            // 
            // b_Szukaj
            // 
            this.b_Szukaj.BackColor = System.Drawing.SystemColors.Control;
            this.b_Szukaj.Location = new System.Drawing.Point(693, 27);
            this.b_Szukaj.Name = "b_Szukaj";
            this.b_Szukaj.Size = new System.Drawing.Size(100, 39);
            this.b_Szukaj.TabIndex = 2;
            this.b_Szukaj.Text = "Szukaj";
            this.b_Szukaj.UseVisualStyleBackColor = false;
            this.b_Szukaj.Click += new System.EventHandler(this.b_Szukaj_Click);
            // 
            // tb_liczbaWystapien
            // 
            this.tb_liczbaWystapien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_liczbaWystapien.Location = new System.Drawing.Point(693, 100);
            this.tb_liczbaWystapien.Name = "tb_liczbaWystapien";
            this.tb_liczbaWystapien.Size = new System.Drawing.Size(100, 26);
            this.tb_liczbaWystapien.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 741);
            this.Controls.Add(this.tb_liczbaWystapien);
            this.Controls.Add(this.b_Szukaj);
            this.Controls.Add(this.tb_wzorzec);
            this.Controls.Add(this.rtb_zakres);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_zakres;
        private System.Windows.Forms.TextBox tb_wzorzec;
        private System.Windows.Forms.Button b_Szukaj;
        private System.Windows.Forms.TextBox tb_liczbaWystapien;
    }
}

