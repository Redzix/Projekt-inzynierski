namespace EngineeringProject.View
{
    partial class MainWindow
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToUseProramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.naiveAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.knuthMorrisPrattAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boyerMooreAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hosrpoolAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quickSearchAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smithsAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raitaAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notSoNaiveAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpNaive = new System.Windows.Forms.TabPage();
            this.rtbNaiveSearchVariables = new System.Windows.Forms.RichTextBox();
            this.lNaiveSearchVariablesList = new System.Windows.Forms.Label();
            this.lNaiveSearchStepList = new System.Windows.Forms.Label();
            this.rtbNaiveSearchSteps = new System.Windows.Forms.RichTextBox();
            this.bNaiveClear = new System.Windows.Forms.Button();
            this.lNumberOfOccurences = new System.Windows.Forms.Label();
            this.tbNaiveSearchOccurenceNumber = new System.Windows.Forms.TextBox();
            this.bNaiveStartSearch = new System.Windows.Forms.Button();
            this.tbNaiveSearchPattern = new System.Windows.Forms.TextBox();
            this.rtbNaiveRange = new System.Windows.Forms.RichTextBox();
            this.tpKnuthMorrisPratt = new System.Windows.Forms.TabPage();
            this.tpBoyerMoore = new System.Windows.Forms.TabPage();
            this.tpHorspool = new System.Windows.Forms.TabPage();
            this.tpQuickSearch = new System.Windows.Forms.TabPage();
            this.tpSmith = new System.Windows.Forms.TabPage();
            this.tpRaita = new System.Windows.Forms.TabPage();
            this.tpNotSoNaive = new System.Windows.Forms.TabPage();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpNaive.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1257, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(100, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stepListToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // stepListToolStripMenuItem
            // 
            this.stepListToolStripMenuItem.Name = "stepListToolStripMenuItem";
            this.stepListToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.stepListToolStripMenuItem.Text = "Step list";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToUseProramToolStripMenuItem,
            this.naiveAlgorithmToolStripMenuItem,
            this.knuthMorrisPrattAlgorithmToolStripMenuItem,
            this.boyerMooreAlgorithmToolStripMenuItem,
            this.hosrpoolAlgorithmToolStripMenuItem,
            this.quickSearchAlgorithmToolStripMenuItem,
            this.smithsAlgorithmToolStripMenuItem,
            this.raitaAlgorithmToolStripMenuItem,
            this.notSoNaiveAlgorithmToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // howToUseProramToolStripMenuItem
            // 
            this.howToUseProramToolStripMenuItem.Name = "howToUseProramToolStripMenuItem";
            this.howToUseProramToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.howToUseProramToolStripMenuItem.Text = "How to use proram.";
            // 
            // naiveAlgorithmToolStripMenuItem
            // 
            this.naiveAlgorithmToolStripMenuItem.Name = "naiveAlgorithmToolStripMenuItem";
            this.naiveAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.naiveAlgorithmToolStripMenuItem.Text = "Naive algorithm";
            // 
            // knuthMorrisPrattAlgorithmToolStripMenuItem
            // 
            this.knuthMorrisPrattAlgorithmToolStripMenuItem.Name = "knuthMorrisPrattAlgorithmToolStripMenuItem";
            this.knuthMorrisPrattAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.knuthMorrisPrattAlgorithmToolStripMenuItem.Text = "Knuth-Morris-Pratt algorithm";
            // 
            // boyerMooreAlgorithmToolStripMenuItem
            // 
            this.boyerMooreAlgorithmToolStripMenuItem.Name = "boyerMooreAlgorithmToolStripMenuItem";
            this.boyerMooreAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.boyerMooreAlgorithmToolStripMenuItem.Text = "Boyer-Moore algorithm";
            // 
            // hosrpoolAlgorithmToolStripMenuItem
            // 
            this.hosrpoolAlgorithmToolStripMenuItem.Name = "hosrpoolAlgorithmToolStripMenuItem";
            this.hosrpoolAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.hosrpoolAlgorithmToolStripMenuItem.Text = "Hosrpool algorithm";
            // 
            // quickSearchAlgorithmToolStripMenuItem
            // 
            this.quickSearchAlgorithmToolStripMenuItem.Name = "quickSearchAlgorithmToolStripMenuItem";
            this.quickSearchAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.quickSearchAlgorithmToolStripMenuItem.Text = "Quick Search algorithm";
            // 
            // smithsAlgorithmToolStripMenuItem
            // 
            this.smithsAlgorithmToolStripMenuItem.Name = "smithsAlgorithmToolStripMenuItem";
            this.smithsAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.smithsAlgorithmToolStripMenuItem.Text = "Smith  algorithm";
            // 
            // raitaAlgorithmToolStripMenuItem
            // 
            this.raitaAlgorithmToolStripMenuItem.Name = "raitaAlgorithmToolStripMenuItem";
            this.raitaAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.raitaAlgorithmToolStripMenuItem.Text = "Raita  algorithm";
            // 
            // notSoNaiveAlgorithmToolStripMenuItem
            // 
            this.notSoNaiveAlgorithmToolStripMenuItem.Name = "notSoNaiveAlgorithmToolStripMenuItem";
            this.notSoNaiveAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.notSoNaiveAlgorithmToolStripMenuItem.Text = "Not So Naive algorithm";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpNaive);
            this.tabControl.Controls.Add(this.tpKnuthMorrisPratt);
            this.tabControl.Controls.Add(this.tpBoyerMoore);
            this.tabControl.Controls.Add(this.tpHorspool);
            this.tabControl.Controls.Add(this.tpQuickSearch);
            this.tabControl.Controls.Add(this.tpSmith);
            this.tabControl.Controls.Add(this.tpRaita);
            this.tabControl.Controls.Add(this.tpNotSoNaive);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1257, 771);
            this.tabControl.TabIndex = 6;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tpNaive
            // 
            this.tpNaive.BackColor = System.Drawing.Color.LightGray;
            this.tpNaive.Controls.Add(this.rtbNaiveSearchVariables);
            this.tpNaive.Controls.Add(this.lNaiveSearchVariablesList);
            this.tpNaive.Controls.Add(this.lNaiveSearchStepList);
            this.tpNaive.Controls.Add(this.rtbNaiveSearchSteps);
            this.tpNaive.Controls.Add(this.bNaiveClear);
            this.tpNaive.Controls.Add(this.lNumberOfOccurences);
            this.tpNaive.Controls.Add(this.tbNaiveSearchOccurenceNumber);
            this.tpNaive.Controls.Add(this.bNaiveStartSearch);
            this.tpNaive.Controls.Add(this.tbNaiveSearchPattern);
            this.tpNaive.Controls.Add(this.rtbNaiveRange);
            this.tpNaive.Location = new System.Drawing.Point(4, 22);
            this.tpNaive.Name = "tpNaive";
            this.tpNaive.Padding = new System.Windows.Forms.Padding(3);
            this.tpNaive.Size = new System.Drawing.Size(1249, 745);
            this.tpNaive.TabIndex = 0;
            this.tpNaive.Text = "Naive";
            // 
            // rtbNaiveSearchVariables
            // 
            this.rtbNaiveSearchVariables.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbNaiveSearchVariables.Location = new System.Drawing.Point(6, 365);
            this.rtbNaiveSearchVariables.Name = "rtbNaiveSearchVariables";
            this.rtbNaiveSearchVariables.Size = new System.Drawing.Size(622, 124);
            this.rtbNaiveSearchVariables.TabIndex = 15;
            this.rtbNaiveSearchVariables.Text = "";
            // 
            // lNaiveSearchVariablesList
            // 
            this.lNaiveSearchVariablesList.AutoSize = true;
            this.lNaiveSearchVariablesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNaiveSearchVariablesList.Location = new System.Drawing.Point(8, 342);
            this.lNaiveSearchVariablesList.Name = "lNaiveSearchVariablesList";
            this.lNaiveSearchVariablesList.Size = new System.Drawing.Size(102, 20);
            this.lNaiveSearchVariablesList.TabIndex = 14;
            this.lNaiveSearchVariablesList.Text = "Variables list:";
            // 
            // lNaiveSearchStepList
            // 
            this.lNaiveSearchStepList.AutoSize = true;
            this.lNaiveSearchStepList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNaiveSearchStepList.Location = new System.Drawing.Point(8, 500);
            this.lNaiveSearchStepList.Name = "lNaiveSearchStepList";
            this.lNaiveSearchStepList.Size = new System.Drawing.Size(70, 20);
            this.lNaiveSearchStepList.TabIndex = 13;
            this.lNaiveSearchStepList.Text = "Step list:";
            // 
            // rtbNaiveSearchSteps
            // 
            this.rtbNaiveSearchSteps.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbNaiveSearchSteps.Location = new System.Drawing.Point(3, 524);
            this.rtbNaiveSearchSteps.Name = "rtbNaiveSearchSteps";
            this.rtbNaiveSearchSteps.Size = new System.Drawing.Size(622, 215);
            this.rtbNaiveSearchSteps.TabIndex = 12;
            this.rtbNaiveSearchSteps.Text = "";
            // 
            // bNaiveClear
            // 
            this.bNaiveClear.Location = new System.Drawing.Point(751, 10);
            this.bNaiveClear.Name = "bNaiveClear";
            this.bNaiveClear.Size = new System.Drawing.Size(100, 26);
            this.bNaiveClear.TabIndex = 11;
            this.bNaiveClear.Text = "Clear";
            this.bNaiveClear.UseVisualStyleBackColor = true;
            this.bNaiveClear.Click += new System.EventHandler(this.bNaiveClear_Click);
            // 
            // lNumberOfOccurences
            // 
            this.lNumberOfOccurences.AutoSize = true;
            this.lNumberOfOccurences.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNumberOfOccurences.Location = new System.Drawing.Point(636, 44);
            this.lNumberOfOccurences.Name = "lNumberOfOccurences";
            this.lNumberOfOccurences.Size = new System.Drawing.Size(169, 20);
            this.lNumberOfOccurences.TabIndex = 10;
            this.lNumberOfOccurences.Text = "Number of occurences";
            // 
            // tbNaiveSearchOccurenceNumber
            // 
            this.tbNaiveSearchOccurenceNumber.Enabled = false;
            this.tbNaiveSearchOccurenceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNaiveSearchOccurenceNumber.Location = new System.Drawing.Point(640, 67);
            this.tbNaiveSearchOccurenceNumber.Name = "tbNaiveSearchOccurenceNumber";
            this.tbNaiveSearchOccurenceNumber.Size = new System.Drawing.Size(100, 26);
            this.tbNaiveSearchOccurenceNumber.TabIndex = 9;
            // 
            // bNaiveStartSearch
            // 
            this.bNaiveStartSearch.BackColor = System.Drawing.SystemColors.Control;
            this.bNaiveStartSearch.Location = new System.Drawing.Point(636, 9);
            this.bNaiveStartSearch.Name = "bNaiveStartSearch";
            this.bNaiveStartSearch.Size = new System.Drawing.Size(100, 26);
            this.bNaiveStartSearch.TabIndex = 8;
            this.bNaiveStartSearch.Text = "Search";
            this.bNaiveStartSearch.UseVisualStyleBackColor = false;
            this.bNaiveStartSearch.Click += new System.EventHandler(this.bNaiveStartSearch_Click);
            // 
            // tbNaiveSearchPattern
            // 
            this.tbNaiveSearchPattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNaiveSearchPattern.Location = new System.Drawing.Point(8, 9);
            this.tbNaiveSearchPattern.Name = "tbNaiveSearchPattern";
            this.tbNaiveSearchPattern.Size = new System.Drawing.Size(622, 26);
            this.tbNaiveSearchPattern.TabIndex = 7;
            this.tbNaiveSearchPattern.TextChanged += new System.EventHandler(this.rtbNaiveRange_TextChanged);
            // 
            // rtbNaiveRange
            // 
            this.rtbNaiveRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbNaiveRange.Location = new System.Drawing.Point(8, 41);
            this.rtbNaiveRange.Name = "rtbNaiveRange";
            this.rtbNaiveRange.Size = new System.Drawing.Size(622, 289);
            this.rtbNaiveRange.TabIndex = 6;
            this.rtbNaiveRange.Text = "";
            this.rtbNaiveRange.TextChanged += new System.EventHandler(this.rtbNaiveRange_TextChanged);
            // 
            // tpKnuthMorrisPratt
            // 
            this.tpKnuthMorrisPratt.Location = new System.Drawing.Point(4, 22);
            this.tpKnuthMorrisPratt.Name = "tpKnuthMorrisPratt";
            this.tpKnuthMorrisPratt.Padding = new System.Windows.Forms.Padding(3);
            this.tpKnuthMorrisPratt.Size = new System.Drawing.Size(1249, 745);
            this.tpKnuthMorrisPratt.TabIndex = 1;
            this.tpKnuthMorrisPratt.Text = "Knuth-Morris-Pratt";
            this.tpKnuthMorrisPratt.UseVisualStyleBackColor = true;
            // 
            // tpBoyerMoore
            // 
            this.tpBoyerMoore.Location = new System.Drawing.Point(4, 22);
            this.tpBoyerMoore.Name = "tpBoyerMoore";
            this.tpBoyerMoore.Padding = new System.Windows.Forms.Padding(3);
            this.tpBoyerMoore.Size = new System.Drawing.Size(1249, 745);
            this.tpBoyerMoore.TabIndex = 2;
            this.tpBoyerMoore.Text = "Boyer-Moore";
            this.tpBoyerMoore.UseVisualStyleBackColor = true;
            // 
            // tpHorspool
            // 
            this.tpHorspool.Location = new System.Drawing.Point(4, 22);
            this.tpHorspool.Name = "tpHorspool";
            this.tpHorspool.Padding = new System.Windows.Forms.Padding(3);
            this.tpHorspool.Size = new System.Drawing.Size(1249, 745);
            this.tpHorspool.TabIndex = 3;
            this.tpHorspool.Text = "Horspool";
            this.tpHorspool.UseVisualStyleBackColor = true;
            // 
            // tpQuickSearch
            // 
            this.tpQuickSearch.Location = new System.Drawing.Point(4, 22);
            this.tpQuickSearch.Name = "tpQuickSearch";
            this.tpQuickSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tpQuickSearch.Size = new System.Drawing.Size(1249, 745);
            this.tpQuickSearch.TabIndex = 4;
            this.tpQuickSearch.Text = "Quick Search";
            this.tpQuickSearch.UseVisualStyleBackColor = true;
            // 
            // tpSmith
            // 
            this.tpSmith.Location = new System.Drawing.Point(4, 22);
            this.tpSmith.Name = "tpSmith";
            this.tpSmith.Padding = new System.Windows.Forms.Padding(3);
            this.tpSmith.Size = new System.Drawing.Size(1249, 745);
            this.tpSmith.TabIndex = 5;
            this.tpSmith.Text = "Smith";
            this.tpSmith.UseVisualStyleBackColor = true;
            // 
            // tpRaita
            // 
            this.tpRaita.Location = new System.Drawing.Point(4, 22);
            this.tpRaita.Name = "tpRaita";
            this.tpRaita.Padding = new System.Windows.Forms.Padding(3);
            this.tpRaita.Size = new System.Drawing.Size(1249, 745);
            this.tpRaita.TabIndex = 6;
            this.tpRaita.Text = "Raita";
            this.tpRaita.UseVisualStyleBackColor = true;
            // 
            // tpNotSoNaive
            // 
            this.tpNotSoNaive.Location = new System.Drawing.Point(4, 22);
            this.tpNotSoNaive.Name = "tpNotSoNaive";
            this.tpNotSoNaive.Padding = new System.Windows.Forms.Padding(3);
            this.tpNotSoNaive.Size = new System.Drawing.Size(1249, 745);
            this.tpNotSoNaive.TabIndex = 7;
            this.tpNotSoNaive.Text = "Not So Naive";
            this.tpNotSoNaive.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Text(.txt)|*.txt";
            this.openFileDialog.Title = "Open file";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 795);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Main window";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainWindow_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tpNaive.ResumeLayout(false);
            this.tpNaive.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpNaive;
        private System.Windows.Forms.Label lNumberOfOccurences;
        private System.Windows.Forms.TextBox tbNaiveSearchOccurenceNumber;
        private System.Windows.Forms.Button bNaiveStartSearch;
        private System.Windows.Forms.TextBox tbNaiveSearchPattern;
        private System.Windows.Forms.RichTextBox rtbNaiveRange;
        private System.Windows.Forms.TabPage tpKnuthMorrisPratt;
        private System.Windows.Forms.TabPage tpBoyerMoore;
        private System.Windows.Forms.TabPage tpHorspool;
        private System.Windows.Forms.TabPage tpQuickSearch;
        private System.Windows.Forms.TabPage tpSmith;
        private System.Windows.Forms.TabPage tpRaita;
        private System.Windows.Forms.TabPage tpNotSoNaive;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToUseProramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem naiveAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem knuthMorrisPrattAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boyerMooreAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hosrpoolAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quickSearchAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smithsAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raitaAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notSoNaiveAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.Button bNaiveClear;
        private System.Windows.Forms.ToolStripMenuItem stepListToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label lNaiveSearchStepList;
        public System.Windows.Forms.RichTextBox rtbNaiveSearchSteps;
        private System.Windows.Forms.Label lNaiveSearchVariablesList;
        public System.Windows.Forms.RichTextBox rtbNaiveSearchVariables;
    }
}

