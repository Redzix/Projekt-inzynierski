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
            this.lbNaiveStepList = new System.Windows.Forms.ListBox();
            this.rtbNaiveSearchVariables = new System.Windows.Forms.RichTextBox();
            this.lNaiveSearchVariablesList = new System.Windows.Forms.Label();
            this.lNaiveSearchStepList = new System.Windows.Forms.Label();
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
            this.panelToolStrip = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripDelayTimeComboBox = new System.Windows.Forms.ToolStripComboBox();
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
            this.openFileMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveFileMenuItem
            // 
            this.saveFileMenuItem.Name = "saveFileMenuItem";
            this.saveFileMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveFileMenuItem.Text = "Save";
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
            this.exitMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
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
            this.tpNaive.BackColor = System.Drawing.Color.LightGray;
            this.tpNaive.Controls.Add(this.lbNaiveStepList);
            this.tpNaive.Controls.Add(this.rtbNaiveSearchVariables);
            this.tpNaive.Controls.Add(this.lNaiveSearchVariablesList);
            this.tpNaive.Controls.Add(this.lNaiveSearchStepList);
            this.tpNaive.Controls.Add(this.bNaiveClear);
            this.tpNaive.Controls.Add(this.lNumberOfOccurences);
            this.tpNaive.Controls.Add(this.tbNaiveSearchOccurenceNumber);
            this.tpNaive.Controls.Add(this.bNaiveStartSearch);
            this.tpNaive.Controls.Add(this.tbNaiveSearchPattern);
            this.tpNaive.Controls.Add(this.rtbNaiveRange);
            this.tpNaive.Location = new System.Drawing.Point(4, 22);
            this.tpNaive.Name = "tpNaive";
            this.tpNaive.Padding = new System.Windows.Forms.Padding(3);
            this.tpNaive.Size = new System.Drawing.Size(1249, 756);
            this.tpNaive.TabIndex = 0;
            this.tpNaive.Text = "Naive";
            // 
            // lbNaiveStepList
            // 
            this.lbNaiveStepList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lbNaiveStepList.Enabled = false;
            this.lbNaiveStepList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNaiveStepList.FormattingEnabled = true;
            this.lbNaiveStepList.Location = new System.Drawing.Point(6, 486);
            this.lbNaiveStepList.Name = "lbNaiveStepList";
            this.lbNaiveStepList.Size = new System.Drawing.Size(622, 277);
            this.lbNaiveStepList.TabIndex = 16;
            this.lbNaiveStepList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            this.lbNaiveStepList.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.listBox1_MeasureItem);
            // 
            // rtbNaiveSearchVariables
            // 
            this.rtbNaiveSearchVariables.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbNaiveSearchVariables.Location = new System.Drawing.Point(6, 328);
            this.rtbNaiveSearchVariables.Name = "rtbNaiveSearchVariables";
            this.rtbNaiveSearchVariables.Size = new System.Drawing.Size(622, 132);
            this.rtbNaiveSearchVariables.TabIndex = 15;
            this.rtbNaiveSearchVariables.Text = "";
            // 
            // lNaiveSearchVariablesList
            // 
            this.lNaiveSearchVariablesList.AutoSize = true;
            this.lNaiveSearchVariablesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNaiveSearchVariablesList.Location = new System.Drawing.Point(8, 305);
            this.lNaiveSearchVariablesList.Name = "lNaiveSearchVariablesList";
            this.lNaiveSearchVariablesList.Size = new System.Drawing.Size(102, 20);
            this.lNaiveSearchVariablesList.TabIndex = 14;
            this.lNaiveSearchVariablesList.Text = "Variables list:";
            // 
            // lNaiveSearchStepList
            // 
            this.lNaiveSearchStepList.AutoSize = true;
            this.lNaiveSearchStepList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNaiveSearchStepList.Location = new System.Drawing.Point(8, 463);
            this.lNaiveSearchStepList.Name = "lNaiveSearchStepList";
            this.lNaiveSearchStepList.Size = new System.Drawing.Size(70, 20);
            this.lNaiveSearchStepList.TabIndex = 13;
            this.lNaiveSearchStepList.Text = "Step list:";
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
            this.tbNaiveSearchPattern.TextChanged += new System.EventHandler(this.tbNaiveSearchPattern_TextChanged);
            // 
            // rtbNaiveRange
            // 
            this.rtbNaiveRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbNaiveRange.Location = new System.Drawing.Point(8, 41);
            this.rtbNaiveRange.Name = "rtbNaiveRange";
            this.rtbNaiveRange.Size = new System.Drawing.Size(622, 261);
            this.rtbNaiveRange.TabIndex = 6;
            this.rtbNaiveRange.Text = "";
            this.rtbNaiveRange.TextChanged += new System.EventHandler(this.rtbNaiveRange_TextChanged);
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
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator2,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripSeparator3,
            this.toolStripButton7,
            this.toolStripButton8,
            this.toolStripButton9,
            this.toolStripButton10,
            this.toolStripDelayTimeComboBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1257, 40);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::WizualizacjaWyszukiwaniaWzorcaWTekscie.Properties.Resources.if_folder_with_file_16786;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(40, 40);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::WizualizacjaWyszukiwaniaWzorcaWTekscie.Properties.Resources.if_floppy_285657__1_;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(39, 37);
            this.toolStripButton2.Text = "toolStripButton2";
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::WizualizacjaWyszukiwaniaWzorcaWTekscie.Properties.Resources.if_Play_2001879;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(39, 37);
            this.toolStripButton5.Text = "toolStripButton5";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::WizualizacjaWyszukiwaniaWzorcaWTekscie.Properties.Resources.step;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(39, 37);
            this.toolStripButton6.Text = "toolStripButton6";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 40);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = global::WizualizacjaWyszukiwaniaWzorcaWTekscie.Properties.Resources.if_Mixer_2001872;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(39, 37);
            this.toolStripButton7.Text = "toolStripButton7";
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
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = global::WizualizacjaWyszukiwaniaWzorcaWTekscie.Properties.Resources.if_Plus_2001887;
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(39, 37);
            this.toolStripButton9.Text = "toolStripButton9";
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
            // toolStripDelayTimeComboBox
            // 
            this.toolStripDelayTimeComboBox.AutoSize = false;
            this.toolStripDelayTimeComboBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripDelayTimeComboBox.Items.AddRange(new object[] {
            "5000ms",
            "4000ms",
            "3000ms",
            "2000ms",
            "1000ms",
            "500ms",
            "400ms",
            "200ms",
            "100ms",
            "50ms",
            "0ms"});
            this.toolStripDelayTimeComboBox.Name = "toolStripDelayTimeComboBox";
            this.toolStripDelayTimeComboBox.Size = new System.Drawing.Size(90, 29);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 846);
            this.Controls.Add(this.panelTabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Main window";
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
        private System.Windows.Forms.Button bNaiveClear;
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
        private System.Windows.Forms.Panel panelToolStrip;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ListBox lbNaiveStepList;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.ToolStripComboBox toolStripDelayTimeComboBox;
    }
}

