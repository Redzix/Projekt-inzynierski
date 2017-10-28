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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToUseProramMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.naiveAlgorithmMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.knuthMorrisPrattAlgorithmMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boyerMooreAlgorithmMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hosrpoolAlgorithmpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quickSearchAlgorithmMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smithsAlgorithmMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raitaAlgorithmMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notSoNaiveAlgorithmMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuSubItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panelTabControl = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpNaive = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.patternLabel = new System.Windows.Forms.Label();
            this.textBoxNaiveSearchPattern = new System.Windows.Forms.TextBox();
            this.richTextBoxNaiveRange = new System.Windows.Forms.RichTextBox();
            this.lNaiveSearchVariablesList = new System.Windows.Forms.Label();
            this.rtbNaiveSearchVariables = new System.Windows.Forms.RichTextBox();
            this.listBoxNaiveStepList = new System.Windows.Forms.ListBox();
            this.lNaiveSearchStepList = new System.Windows.Forms.Label();
            this.naiveClearButton = new System.Windows.Forms.Button();
            this.lNumberOfOccurences = new System.Windows.Forms.Label();
            this.textBoxNaiveSearchOccurenceNumber = new System.Windows.Forms.TextBox();
            this.tpKnuthMorrisPratt = new System.Windows.Forms.TabPage();
            this.tpBoyerMoore = new System.Windows.Forms.TabPage();
            this.tpHorspool = new System.Windows.Forms.TabPage();
            this.tpQuickSearch = new System.Windows.Forms.TabPage();
            this.tpSmith = new System.Windows.Forms.TabPage();
            this.tpRaita = new System.Windows.Forms.TabPage();
            this.tpNotSoNaive = new System.Windows.Forms.TabPage();
            this.panelToolStrip = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openFileButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.autoSearchButton = new System.Windows.Forms.ToolStripButton();
            this.stepSearchButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.startAutoStepSearchButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.fasterButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.delayTimeComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.msLabel = new System.Windows.Forms.ToolStripLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.panelTabControl.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpNaive.SuspendLayout();
            this.panelToolStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.aboutMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1257, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileMenuItem,
            this.saveFileMenuItem,
            this.toolStripSeparator1,
            this.exitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "File";
            // 
            // openFileMenuItem
            // 
            this.openFileMenuItem.Name = "openFileMenuItem";
            this.openFileMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openFileMenuItem.Text = "Open";
            this.openFileMenuItem.Click += new System.EventHandler(this.openFileDialog_Click);
            // 
            // saveFileMenuItem
            // 
            this.saveFileMenuItem.Name = "saveFileMenuItem";
            this.saveFileMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveFileMenuItem.Text = "Save";
            this.saveFileMenuItem.Click += new System.EventHandler(this.SaveResults_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(100, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpMenuItem,
            this.aboutMenuSubItem});
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutMenuItem.Text = "About";
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToUseProramMenuItem,
            this.naiveAlgorithmMenuItem,
            this.knuthMorrisPrattAlgorithmMenuItem,
            this.boyerMooreAlgorithmMenuItem,
            this.hosrpoolAlgorithmpMenuItem,
            this.quickSearchAlgorithmMenuItem,
            this.smithsAlgorithmMenuItem,
            this.raitaAlgorithmMenuItem,
            this.notSoNaiveAlgorithmMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(107, 22);
            this.helpMenuItem.Text = "Help";
            // 
            // howToUseProramMenuItem
            // 
            this.howToUseProramMenuItem.Name = "howToUseProramMenuItem";
            this.howToUseProramMenuItem.Size = new System.Drawing.Size(230, 22);
            this.howToUseProramMenuItem.Text = "How to use program.";
            // 
            // naiveAlgorithmMenuItem
            // 
            this.naiveAlgorithmMenuItem.Name = "naiveAlgorithmMenuItem";
            this.naiveAlgorithmMenuItem.Size = new System.Drawing.Size(230, 22);
            this.naiveAlgorithmMenuItem.Text = "Naive algorithm";
            // 
            // knuthMorrisPrattAlgorithmMenuItem
            // 
            this.knuthMorrisPrattAlgorithmMenuItem.Name = "knuthMorrisPrattAlgorithmMenuItem";
            this.knuthMorrisPrattAlgorithmMenuItem.Size = new System.Drawing.Size(230, 22);
            this.knuthMorrisPrattAlgorithmMenuItem.Text = "Knuth-Morris-Pratt algorithm";
            // 
            // boyerMooreAlgorithmMenuItem
            // 
            this.boyerMooreAlgorithmMenuItem.Name = "boyerMooreAlgorithmMenuItem";
            this.boyerMooreAlgorithmMenuItem.Size = new System.Drawing.Size(230, 22);
            this.boyerMooreAlgorithmMenuItem.Text = "Boyer-Moore algorithm";
            // 
            // hosrpoolAlgorithmpMenuItem
            // 
            this.hosrpoolAlgorithmpMenuItem.Name = "hosrpoolAlgorithmpMenuItem";
            this.hosrpoolAlgorithmpMenuItem.Size = new System.Drawing.Size(230, 22);
            this.hosrpoolAlgorithmpMenuItem.Text = "Hosrpool algorithm";
            // 
            // quickSearchAlgorithmMenuItem
            // 
            this.quickSearchAlgorithmMenuItem.Name = "quickSearchAlgorithmMenuItem";
            this.quickSearchAlgorithmMenuItem.Size = new System.Drawing.Size(230, 22);
            this.quickSearchAlgorithmMenuItem.Text = "Quick Search algorithm";
            // 
            // smithsAlgorithmMenuItem
            // 
            this.smithsAlgorithmMenuItem.Name = "smithsAlgorithmMenuItem";
            this.smithsAlgorithmMenuItem.Size = new System.Drawing.Size(230, 22);
            this.smithsAlgorithmMenuItem.Text = "Smith  algorithm";
            // 
            // raitaAlgorithmMenuItem
            // 
            this.raitaAlgorithmMenuItem.Name = "raitaAlgorithmMenuItem";
            this.raitaAlgorithmMenuItem.Size = new System.Drawing.Size(230, 22);
            this.raitaAlgorithmMenuItem.Text = "Raita  algorithm";
            // 
            // notSoNaiveAlgorithmMenuItem
            // 
            this.notSoNaiveAlgorithmMenuItem.Name = "notSoNaiveAlgorithmMenuItem";
            this.notSoNaiveAlgorithmMenuItem.Size = new System.Drawing.Size(230, 22);
            this.notSoNaiveAlgorithmMenuItem.Text = "Not So Naive algorithm";
            // 
            // aboutMenuSubItem
            // 
            this.aboutMenuSubItem.Name = "aboutMenuSubItem";
            this.aboutMenuSubItem.Size = new System.Drawing.Size(107, 22);
            this.aboutMenuSubItem.Text = "About";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Text(.txt)|*.txt";
            this.openFileDialog.Title = "Open file";
            // 
            // panelTabControl
            // 
            this.panelTabControl.Controls.Add(this.tabControl);
            this.panelTabControl.Controls.Add(this.panelToolStrip);
            this.panelTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabControl.Location = new System.Drawing.Point(0, 24);
            this.panelTabControl.Name = "panelTabControl";
            this.panelTabControl.Size = new System.Drawing.Size(1257, 822);
            this.panelTabControl.TabIndex = 9;
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
            this.tabControl.Location = new System.Drawing.Point(0, 40);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1257, 782);
            this.tabControl.TabIndex = 9;
            // 
            // tpNaive
            // 
            this.tpNaive.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tpNaive.Controls.Add(this.label1);
            this.tpNaive.Controls.Add(this.patternLabel);
            this.tpNaive.Controls.Add(this.textBoxNaiveSearchPattern);
            this.tpNaive.Controls.Add(this.richTextBoxNaiveRange);
            this.tpNaive.Controls.Add(this.lNaiveSearchVariablesList);
            this.tpNaive.Controls.Add(this.rtbNaiveSearchVariables);
            this.tpNaive.Controls.Add(this.listBoxNaiveStepList);
            this.tpNaive.Controls.Add(this.lNaiveSearchStepList);
            this.tpNaive.Controls.Add(this.naiveClearButton);
            this.tpNaive.Controls.Add(this.lNumberOfOccurences);
            this.tpNaive.Controls.Add(this.textBoxNaiveSearchOccurenceNumber);
            this.tpNaive.Location = new System.Drawing.Point(4, 22);
            this.tpNaive.Name = "tpNaive";
            this.tpNaive.Padding = new System.Windows.Forms.Padding(3);
            this.tpNaive.Size = new System.Drawing.Size(1249, 756);
            this.tpNaive.TabIndex = 0;
            this.tpNaive.Text = "Naive";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Put your text there";
            // 
            // patternLabel
            // 
            this.patternLabel.AutoSize = true;
            this.patternLabel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.patternLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patternLabel.Location = new System.Drawing.Point(6, 3);
            this.patternLabel.Name = "patternLabel";
            this.patternLabel.Size = new System.Drawing.Size(163, 20);
            this.patternLabel.TabIndex = 17;
            this.patternLabel.Text = "Put your pattern there";
            // 
            // textBoxNaiveSearchPattern
            // 
            this.textBoxNaiveSearchPattern.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxNaiveSearchPattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNaiveSearchPattern.Location = new System.Drawing.Point(8, 28);
            this.textBoxNaiveSearchPattern.Name = "textBoxNaiveSearchPattern";
            this.textBoxNaiveSearchPattern.Size = new System.Drawing.Size(452, 26);
            this.textBoxNaiveSearchPattern.TabIndex = 8;
            // 
            // richTextBoxNaiveRange
            // 
            this.richTextBoxNaiveRange.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.richTextBoxNaiveRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxNaiveRange.Location = new System.Drawing.Point(8, 82);
            this.richTextBoxNaiveRange.Name = "richTextBoxNaiveRange";
            this.richTextBoxNaiveRange.Size = new System.Drawing.Size(617, 249);
            this.richTextBoxNaiveRange.TabIndex = 6;
            this.richTextBoxNaiveRange.Text = "";
            this.richTextBoxNaiveRange.TextChanged += new System.EventHandler(this.richTextBoxNaiveRange_TextChanged);
            // 
            // lNaiveSearchVariablesList
            // 
            this.lNaiveSearchVariablesList.AutoSize = true;
            this.lNaiveSearchVariablesList.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lNaiveSearchVariablesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNaiveSearchVariablesList.Location = new System.Drawing.Point(4, 334);
            this.lNaiveSearchVariablesList.Name = "lNaiveSearchVariablesList";
            this.lNaiveSearchVariablesList.Size = new System.Drawing.Size(102, 20);
            this.lNaiveSearchVariablesList.TabIndex = 14;
            this.lNaiveSearchVariablesList.Text = "Variables list:";
            // 
            // rtbNaiveSearchVariables
            // 
            this.rtbNaiveSearchVariables.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rtbNaiveSearchVariables.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbNaiveSearchVariables.Location = new System.Drawing.Point(8, 359);
            this.rtbNaiveSearchVariables.Name = "rtbNaiveSearchVariables";
            this.rtbNaiveSearchVariables.Size = new System.Drawing.Size(617, 110);
            this.rtbNaiveSearchVariables.TabIndex = 15;
            this.rtbNaiveSearchVariables.Text = "";
            // 
            // listBoxNaiveStepList
            // 
            this.listBoxNaiveStepList.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.listBoxNaiveStepList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBoxNaiveStepList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxNaiveStepList.FormattingEnabled = true;
            this.listBoxNaiveStepList.Location = new System.Drawing.Point(8, 495);
            this.listBoxNaiveStepList.Name = "listBoxNaiveStepList";
            this.listBoxNaiveStepList.Size = new System.Drawing.Size(617, 251);
            this.listBoxNaiveStepList.TabIndex = 16;
            this.listBoxNaiveStepList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxNaiveStepList_DrawItem);
            this.listBoxNaiveStepList.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.listBoxNaiveStepList_MeasureItem);
            // 
            // lNaiveSearchStepList
            // 
            this.lNaiveSearchStepList.AutoSize = true;
            this.lNaiveSearchStepList.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lNaiveSearchStepList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNaiveSearchStepList.Location = new System.Drawing.Point(8, 472);
            this.lNaiveSearchStepList.Name = "lNaiveSearchStepList";
            this.lNaiveSearchStepList.Size = new System.Drawing.Size(70, 20);
            this.lNaiveSearchStepList.TabIndex = 13;
            this.lNaiveSearchStepList.Text = "Step list:";
            // 
            // naiveClearButton
            // 
            this.naiveClearButton.Location = new System.Drawing.Point(514, 334);
            this.naiveClearButton.Name = "naiveClearButton";
            this.naiveClearButton.Size = new System.Drawing.Size(100, 23);
            this.naiveClearButton.TabIndex = 11;
            this.naiveClearButton.Text = "Clear";
            this.naiveClearButton.UseVisualStyleBackColor = true;
            this.naiveClearButton.Click += new System.EventHandler(this.naiveClearButton_Click);
            // 
            // lNumberOfOccurences
            // 
            this.lNumberOfOccurences.AutoSize = true;
            this.lNumberOfOccurences.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNumberOfOccurences.Location = new System.Drawing.Point(462, 3);
            this.lNumberOfOccurences.Name = "lNumberOfOccurences";
            this.lNumberOfOccurences.Size = new System.Drawing.Size(169, 20);
            this.lNumberOfOccurences.TabIndex = 10;
            this.lNumberOfOccurences.Text = "Number of occurences";
            // 
            // textBoxNaiveSearchOccurenceNumber
            // 
            this.textBoxNaiveSearchOccurenceNumber.Enabled = false;
            this.textBoxNaiveSearchOccurenceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNaiveSearchOccurenceNumber.Location = new System.Drawing.Point(466, 28);
            this.textBoxNaiveSearchOccurenceNumber.Name = "textBoxNaiveSearchOccurenceNumber";
            this.textBoxNaiveSearchOccurenceNumber.Size = new System.Drawing.Size(100, 26);
            this.textBoxNaiveSearchOccurenceNumber.TabIndex = 9;
            // 
            // tpKnuthMorrisPratt
            // 
            this.tpKnuthMorrisPratt.Location = new System.Drawing.Point(4, 22);
            this.tpKnuthMorrisPratt.Name = "tpKnuthMorrisPratt";
            this.tpKnuthMorrisPratt.Padding = new System.Windows.Forms.Padding(3);
            this.tpKnuthMorrisPratt.Size = new System.Drawing.Size(1249, 756);
            this.tpKnuthMorrisPratt.TabIndex = 1;
            this.tpKnuthMorrisPratt.Text = "Knuth-Morris-Pratt";
            this.tpKnuthMorrisPratt.UseVisualStyleBackColor = true;
            // 
            // tpBoyerMoore
            // 
            this.tpBoyerMoore.Location = new System.Drawing.Point(4, 22);
            this.tpBoyerMoore.Name = "tpBoyerMoore";
            this.tpBoyerMoore.Padding = new System.Windows.Forms.Padding(3);
            this.tpBoyerMoore.Size = new System.Drawing.Size(1249, 756);
            this.tpBoyerMoore.TabIndex = 2;
            this.tpBoyerMoore.Text = "Boyer-Moore";
            this.tpBoyerMoore.UseVisualStyleBackColor = true;
            // 
            // tpHorspool
            // 
            this.tpHorspool.Location = new System.Drawing.Point(4, 22);
            this.tpHorspool.Name = "tpHorspool";
            this.tpHorspool.Padding = new System.Windows.Forms.Padding(3);
            this.tpHorspool.Size = new System.Drawing.Size(1249, 756);
            this.tpHorspool.TabIndex = 3;
            this.tpHorspool.Text = "Horspool";
            this.tpHorspool.UseVisualStyleBackColor = true;
            // 
            // tpQuickSearch
            // 
            this.tpQuickSearch.Location = new System.Drawing.Point(4, 22);
            this.tpQuickSearch.Name = "tpQuickSearch";
            this.tpQuickSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tpQuickSearch.Size = new System.Drawing.Size(1249, 756);
            this.tpQuickSearch.TabIndex = 4;
            this.tpQuickSearch.Text = "Quick Search";
            this.tpQuickSearch.UseVisualStyleBackColor = true;
            // 
            // tpSmith
            // 
            this.tpSmith.Location = new System.Drawing.Point(4, 22);
            this.tpSmith.Name = "tpSmith";
            this.tpSmith.Padding = new System.Windows.Forms.Padding(3);
            this.tpSmith.Size = new System.Drawing.Size(1249, 756);
            this.tpSmith.TabIndex = 5;
            this.tpSmith.Text = "Smith";
            this.tpSmith.UseVisualStyleBackColor = true;
            // 
            // tpRaita
            // 
            this.tpRaita.Location = new System.Drawing.Point(4, 22);
            this.tpRaita.Name = "tpRaita";
            this.tpRaita.Padding = new System.Windows.Forms.Padding(3);
            this.tpRaita.Size = new System.Drawing.Size(1249, 756);
            this.tpRaita.TabIndex = 6;
            this.tpRaita.Text = "Raita";
            this.tpRaita.UseVisualStyleBackColor = true;
            // 
            // tpNotSoNaive
            // 
            this.tpNotSoNaive.Location = new System.Drawing.Point(4, 22);
            this.tpNotSoNaive.Name = "tpNotSoNaive";
            this.tpNotSoNaive.Padding = new System.Windows.Forms.Padding(3);
            this.tpNotSoNaive.Size = new System.Drawing.Size(1249, 756);
            this.tpNotSoNaive.TabIndex = 7;
            this.tpNotSoNaive.Text = "Not So Naive";
            this.tpNotSoNaive.UseVisualStyleBackColor = true;
            // 
            // panelToolStrip
            // 
            this.panelToolStrip.Controls.Add(this.toolStrip1);
            this.panelToolStrip.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolStrip.Location = new System.Drawing.Point(0, 0);
            this.panelToolStrip.Name = "panelToolStrip";
            this.panelToolStrip.Size = new System.Drawing.Size(1257, 40);
            this.panelToolStrip.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(35, 35);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileButton,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.autoSearchButton,
            this.stepSearchButton,
            this.toolStripSeparator3,
            this.startAutoStepSearchButton,
            this.toolStripButton8,
            this.fasterButton,
            this.toolStripButton10,
            this.delayTimeComboBox,
            this.msLabel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1257, 40);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // openFileButton
            // 
            this.openFileButton.AutoSize = false;
            this.openFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openFileButton.Image = global::WizualizacjaWyszukiwaniaWzorcaWTekscie.Properties.Resources.if_folder_with_file_16786;
            this.openFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFileButton.Margin = new System.Windows.Forms.Padding(0);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(40, 40);
            this.openFileButton.Text = "Open file";
            this.openFileButton.Click += new System.EventHandler(this.openFileDialog_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::WizualizacjaWyszukiwaniaWzorcaWTekscie.Properties.Resources.if_floppy_285657__1_;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(39, 37);
            this.toolStripButton2.Text = "Save results";
            this.toolStripButton2.Click += new System.EventHandler(this.SaveResults_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::WizualizacjaWyszukiwaniaWzorcaWTekscie.Properties.Resources.if_Backward_Skip_2001868;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(39, 37);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::WizualizacjaWyszukiwaniaWzorcaWTekscie.Properties.Resources.if_Forward_Skip_2001880;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(39, 37);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::WizualizacjaWyszukiwaniaWzorcaWTekscie.Properties.Resources.if_Stop_2001885;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(39, 37);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // autoSearchButton
            // 
            this.autoSearchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.autoSearchButton.Image = global::WizualizacjaWyszukiwaniaWzorcaWTekscie.Properties.Resources.if_Play_2001879;
            this.autoSearchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.autoSearchButton.Name = "autoSearchButton";
            this.autoSearchButton.Size = new System.Drawing.Size(39, 37);
            this.autoSearchButton.Text = "Start auto-searching";
            this.autoSearchButton.Click += new System.EventHandler(this.autoSearchButton_Click);
            // 
            // stepSearchButton
            // 
            this.stepSearchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stepSearchButton.Image = global::WizualizacjaWyszukiwaniaWzorcaWTekscie.Properties.Resources.step;
            this.stepSearchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stepSearchButton.Name = "stepSearchButton";
            this.stepSearchButton.Size = new System.Drawing.Size(39, 37);
            this.stepSearchButton.Text = "Start user-step searching";
            this.stepSearchButton.Click += new System.EventHandler(this.stepSearchButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 40);
            // 
            // startAutoStepSearchButton
            // 
            this.startAutoStepSearchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startAutoStepSearchButton.Image = global::WizualizacjaWyszukiwaniaWzorcaWTekscie.Properties.Resources.if_Mixer_2001872;
            this.startAutoStepSearchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startAutoStepSearchButton.Name = "startAutoStepSearchButton";
            this.startAutoStepSearchButton.Size = new System.Drawing.Size(39, 37);
            this.startAutoStepSearchButton.Text = "Start auto-step searching";
            this.startAutoStepSearchButton.Click += new System.EventHandler(this.startAutoStepSearchButton_Click);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = global::WizualizacjaWyszukiwaniaWzorcaWTekscie.Properties.Resources.if_Pause_2001889;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(39, 37);
            this.toolStripButton8.Text = "toolStripButton8";
            // 
            // fasterButton
            // 
            this.fasterButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fasterButton.Image = global::WizualizacjaWyszukiwaniaWzorcaWTekscie.Properties.Resources.if_Plus_2001887;
            this.fasterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fasterButton.Name = "fasterButton";
            this.fasterButton.Size = new System.Drawing.Size(39, 37);
            this.fasterButton.Text = "toolStripButton9";
            this.fasterButton.Click += new System.EventHandler(this.fasterButton_Click);
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton10.Image = global::WizualizacjaWyszukiwaniaWzorcaWTekscie.Properties.Resources.if_Minus_2001871;
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(39, 37);
            this.toolStripButton10.Text = "toolStripButton10";
            // 
            // delayTimeComboBox
            // 
            this.delayTimeComboBox.AutoSize = false;
            this.delayTimeComboBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.delayTimeComboBox.Items.AddRange(new object[] {
            "5000",
            "4000",
            "3000",
            "2000",
            "1000",
            "500",
            "400",
            "200",
            "100",
            "50",
            "0"});
            this.delayTimeComboBox.Name = "delayTimeComboBox";
            this.delayTimeComboBox.Size = new System.Drawing.Size(90, 29);
            this.delayTimeComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.delayTimeComboBox_KeyPress);
            // 
            // msLabel
            // 
            this.msLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.msLabel.Name = "msLabel";
            this.msLabel.Size = new System.Drawing.Size(31, 37);
            this.msLabel.Text = "ms";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 846);
            this.Controls.Add(this.panelTabControl);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search pattern in text";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainWindow_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelTabControl.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tpNaive.ResumeLayout(false);
            this.tpNaive.PerformLayout();
            this.panelToolStrip.ResumeLayout(false);
            this.panelToolStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToUseProramMenuItem;
        private System.Windows.Forms.ToolStripMenuItem naiveAlgorithmMenuItem;
        private System.Windows.Forms.ToolStripMenuItem knuthMorrisPrattAlgorithmMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boyerMooreAlgorithmMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hosrpoolAlgorithmpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quickSearchAlgorithmMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smithsAlgorithmMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raitaAlgorithmMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notSoNaiveAlgorithmMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuSubItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel panelTabControl;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpNaive;
        public System.Windows.Forms.RichTextBox rtbNaiveSearchVariables;
        private System.Windows.Forms.Label lNaiveSearchVariablesList;
        private System.Windows.Forms.Label lNaiveSearchStepList;
       // public System.Windows.Forms.RichTextBox rtbNaiveSearchSteps;
        private System.Windows.Forms.Button naiveClearButton;
        private System.Windows.Forms.Label lNumberOfOccurences;
        private System.Windows.Forms.TextBox textBoxNaiveSearchOccurenceNumber;
        private System.Windows.Forms.RichTextBox richTextBoxNaiveRange;
        private System.Windows.Forms.TabPage tpKnuthMorrisPratt;
        private System.Windows.Forms.TabPage tpBoyerMoore;
        private System.Windows.Forms.TabPage tpHorspool;
        private System.Windows.Forms.TabPage tpQuickSearch;
        private System.Windows.Forms.TabPage tpSmith;
        private System.Windows.Forms.TabPage tpRaita;
        private System.Windows.Forms.TabPage tpNotSoNaive;
        private System.Windows.Forms.Panel panelToolStrip;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton openFileButton;
        private System.Windows.Forms.ListBox listBoxNaiveStepList;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton autoSearchButton;
        private System.Windows.Forms.ToolStripButton stepSearchButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton startAutoStepSearchButton;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton fasterButton;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.ToolStripComboBox delayTimeComboBox;
        private System.Windows.Forms.ToolStripLabel msLabel;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TextBox textBoxNaiveSearchPattern;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label patternLabel;
    }
}

