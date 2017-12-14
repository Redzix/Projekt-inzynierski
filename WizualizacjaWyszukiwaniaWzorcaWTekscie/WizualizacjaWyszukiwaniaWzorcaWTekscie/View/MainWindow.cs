//MainWindow.cs
//
//Partial class of MainWindow. Implements all GUI's events.
//

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using EngineeringProject.Controller;
using System.IO;
using System.Text.RegularExpressions;
using EngineeringProject.Enum;
using NLog;
using EngineeringProject.Model;
using System.ComponentModel;

namespace EngineeringProject.View
{
    public partial class MainWindow : Form
    {
        #region Fields
        //Logger
        Logger logger = LogManager.GetCurrentClassLogger();

        //Check if there was an search algorithm iteration.
        bool wasSearched = false;

        //Controller of Naive algorithm.
        private MainController controller = null;

        //Enum which contains searching methods names
        private ESearchMethods searchMethod;

        //Found indexes
        private List<int> searchResult = new List<int>();

        //List of all searched combinations
        private List<Result> resultList;

        //Count of pattern length
        private int keyCount = 0;

        //Information about enabled buttons. If algorithm works they are disabled.
        private bool controlEnabled = true;
        #endregion

        #region constructors
        //Main constructor. Creates new Naive algorithm controller and sets default delay time.
        public MainWindow()
        {
            InitializeComponent();
            delayTimeComboBox.SelectedIndex = 0;
            algorithmComboBox.SelectedIndex = 0;
            resultList = new List<Result>();
            controller = new NaiveController(this);
            logger.Info("Application Searching Pattern Visualisation succesfully started.");
        }
        #endregion

        #region public
        /// <summary>
        /// Load step list or variables list to correspondent ListBox.
        /// </summary>
        /// <param name="listBox">Choosen ListBox to which parameters should be loaded.</param>
        /// <param name="stepList">String array of loaded values.</param>
        public void LoadToListbox(ListBox listBox, string[] valuesList)
        {
            ((ListBox)listBox).Items.Clear();

            for (int i = 0; i < valuesList.Length; i++)
            {
                ((ListBox)listBox).Items.Add(valuesList[i]);
            }
        }

        /// <summary>
        /// Changes backgound color actual algorithm step.
        /// </summary>
        /// <param name="listBox">Choosen ListBox in which the operation will be make.</param>
        /// <param name="step">Index of acual step in step list to higlight.</param>
        public void HighlightActualStep(int step)
        {
            stepListListBox.SelectedIndex = step;
        }
        #endregion

        #region private
        /// <summary>
        /// Clear search result in naiveRichTextBox after modifying pattern.
        /// </summary>
        /// <param name="sender">Choosen TextBox.</param>
        /// <param name="e">System event.</param>
        private void TextBooxPatternTextChanged(object sender, EventArgs e)
        {
            ClearHiglight(rangeRichTextBox);
        }

        /// <summary>
        /// Clear search result in naiveRichTextBox after modifying searched range.
        /// </summary>
        /// <param name="sender">Choosen TetBox.</param>
        /// <param name="e">System event.</param>
        private void RichTextBoxRangeTextChanged(object sender, EventArgs e)
        {
            if (wasSearched)
            {
                this.ClearHiglight(((RichTextBox)sender));

                wasSearched = false;
            }
        }

        /// <summary>
        /// Method which performs an FormClosing event past pressing(hmm) ApplicationExit(X) button. Program asks user for
        /// confirmation of his decision. If he confirms, application will be  closed. Otherwise program will work continuously.
        /// </summary>
        /// <param name="sender">Recognition of initializing parameter.</param>
        /// <param name="e">System FormClosingEvent event.</param>
        private void mainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult closeApplication = MessageBox.Show("Do you really want to close the application?", "Close",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (closeApplication == DialogResult.Yes)
                {
                    logger.Info("Application exit");
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// Method which performs an event past pressing exit button in menu strip. Program asks user for
        /// confirmation of his decision. If he confirms, application will be closed. Otherwise program will work continuously.
        /// </summary>
        /// <param name="sender">Recognition of initializing parameter.</param>
        /// <param name="e">System FormClosingEvent event.</param>
        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult closeApplication = MessageBox.Show("Do you really want to close the application?", "Close",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (closeApplication == DialogResult.Yes)
            {
                logger.Info("Application exit");
                Application.Exit();
            }
            else
            {
                return;
            }

        }

        /// <summary>
        /// Clears all inputs and outputs on current TabPage.
        /// </summary>
        /// <param name="sender">Pressed button.</param>
        /// <param name="e">System event.</param>
        private void naiveClearButton_Click(object sender, EventArgs e)
        {
            DialogResult clearNaiveFields = MessageBox.Show("Do you want to clear all fields on this page?", "Clear fields",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (clearNaiveFields == DialogResult.Yes)
            {
                rangeRichTextBox.Text = "";
                searchOccurenceNumberTextBox.Text = "0";
                searchPatternTextBox.Text = "";
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// System dialog which allows user to open external file with text to be searched.
        /// </summary>
        /// <param name="sender">Pressed button.</param>
        /// <param name="e">System event.</param>
        private void OpenFileDialogClick(object sender, EventArgs e)
        {
            int size = -1;
            string range = null;

            openFileDialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            DialogResult selectedFile = openFileDialog.ShowDialog();

            if (selectedFile == DialogResult.OK)
            {
                string openfile = openFileDialog.FileName;

                try
                {
                    range = File.ReadAllText(openfile);
                    size = range.Length;

                }
                catch (IOException exc)
                {
                    logger.Error("Open file " + exc.ToString());
                    MessageBox.Show(exc.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    switch (size)
                    {
                        case -1:
                            break;
                        case 0:
                            logger.Info("Read empty file");
                            MessageBox.Show("File is empty.", "Empty file", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            break;
                        default:
                            rangeRichTextBox.Text = range;
                            break;
                    }
                }

            }

        }

        /// <summary>
        /// Switch between different algorithms.
        /// </summary>
        /// <param name="sender">Used combobox.</param>
        /// <param name="e">system event.</param>
        private void ComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            saveResultsButton.Enabled = false;
            saveFileMenuItem.Enabled = false;

            switch (algorithmComboBox.SelectedIndex)
            {
                case 0:
                    this.controller = new NaiveController(this);
                    searchMethod = ESearchMethods.NAIVE;
                    this.ClearHiglight(rangeRichTextBox);
                    break;
                case 1:
                    this.controller = new KnuthMorrisPrattController(this);
                    searchMethod = ESearchMethods.KMP;
                    this.ClearHiglight(rangeRichTextBox);
                    break;
                case 2:
                    this.controller = new BoyerMooreController(this);
                    searchMethod = ESearchMethods.BOYER_MOORE;
                    this.ClearHiglight(rangeRichTextBox);
                    break;
                case 3:
                    this.controller = new HorspoolController(this);
                    searchMethod = ESearchMethods.HORSPOOL;
                    this.ClearHiglight(rangeRichTextBox);
                    break;
                case 4:
                    this.controller = new QuickSearchController(this);
                    searchMethod = ESearchMethods.QUICK_SEARCH;
                    this.ClearHiglight(rangeRichTextBox);
                    break;
                case 5:
                    this.controller = new RaitaController(this);
                    searchMethod = ESearchMethods.RAITA;
                    this.ClearHiglight(rangeRichTextBox);
                    break;
                case 6:
                    this.controller = new SmithController(this);
                    searchMethod = ESearchMethods.SMITH;
                    this.ClearHiglight(rangeRichTextBox);
                    break;
                case 7:
                    this.controller = new NotSoNaiveController(this);
                    searchMethod = ESearchMethods.NOT_SO_NAIVE;
                    this.ClearHiglight(rangeRichTextBox);
                    break;
                default:
                    this.controller = new NaiveController(this);
                    searchMethod = ESearchMethods.NAIVE;
                    this.ClearHiglight(rangeRichTextBox);
                    break;
            }
            logger.Info("Search using " + searchMethod.ToString());
        }

        /// <summary>
        /// Clears all higlighted text in choosen RichTextBox.
        /// </summary>
        /// <param name="rtb">RichTextBox to be cleared.</param>
        private void ClearHiglight(RichTextBox rtb)
        {
            rtb.Select(0, rtb.TextLength);
            rtb.SelectionBackColor = Color.White;
            rtb.Select(rtb.TextLength, 0);

            
            ClearTextFields();
        }

        /// <summary>
        /// Clears results in searchOccurenceNumberTextBox, rangeIndexTextBox, patternIndexTextBox and matchedCharactersTextBox.
        /// </summary>
        private void ClearTextFields()
        {
            searchOccurenceNumberTextBox.Text = "0";

            rangeIndexTextBox.Text = "0";
            patternIndexTextBox.Text = "0";
            matchedCharactersTextBox.Text = "0";
        }

        /// <summary>
        /// Changes ListBox selection background color from  default.
        /// </summary>
        /// <param name="sender">Choosen ListBox</param>
        /// <param name="e">System event</param>
        private void ListBoxDrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics g = e.Graphics;
            Brush brush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ?
                          Brushes.Yellow : new SolidBrush(e.BackColor);
            g.FillRectangle(brush, e.Bounds);
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), new Font(FontFamily.GenericSansSerif, 12),
                     new SolidBrush(Color.Black), e.Bounds);
            e.DrawFocusRectangle();
        }

        /// <summary>
        /// Changes ListBox row size.
        /// </summary>
        /// <param name="sender">Choosen ListBox.</param>
        /// <param name="e">System event.</param>
        private void ListBoxMeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 20;
        }

        /// <summary>
        /// Start auto-searching using currently choosen algorithm.
        /// </summary>
        /// <param name="sender">Pressed button.</param>
        /// <param name="e">System event.</param>
        private void AutoSearchButtonClick(object sender, EventArgs e)
        {
            actualStepDataGridView.Rows.Clear();
            logDataGridView.Rows.Clear();
            resultsDataGridView.Rows.Clear();
            resultsDataGridView.Columns.Clear();

            if (keyCount >= 3)
            {
                logger.Info("Auto searching started");
                logger.Info("Pattern: " + searchPatternTextBox.Text + ", range: " + rangeRichTextBox.Text + ", method: " + searchMethod.ToString());

                computeDeltaCheckBox.Enabled = false;
                simulateComparisonsCheckBox.Enabled = false;

                this.ClearHiglight(rangeRichTextBox);
                searchResult = this.controller.SearchPattern(searchPatternTextBox.Text.ToLower(), rangeRichTextBox.Text.ToLower());
                AddResultToList();

                this.ShowSearchedResults(rangeRichTextBox, searchOccurenceNumberTextBox, searchResult);

                computeDeltaCheckBox.Enabled = true;
                simulateComparisonsCheckBox.Enabled = true;
            }
            else
            {
                MessageBox.Show("Pattern must have more than 2 characters", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                logger.Info("Pattern is too short.");
            }
        }

        /// <summary>
        /// Show searched result on corresponding outputs. Higlights all searched sequences in RichTextBox and puts occurence number into TextBox.
        /// </summary>
        /// <param name="richTextBox"></param>
        /// <param name="textBox"></param>
        /// <param name="searchResult"></param>
        private void ShowSearchedResults(RichTextBox range, TextBox occurrenceNumber, List<int> searchResult)
        {
            string indexes = "";

            if (searchResult != null)
            {
                if (searchResult.Count() == 0)
                {
                    logger.Info("No matched sequences found.");
                    ((TextBox)occurrenceNumber).Text = "0";
                    MessageBox.Show("No matched sequences were found.", "Nothing found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    foreach (var result in searchResult)
                    {
                        ((RichTextBox)range).Select(result, searchPatternTextBox.TextLength);
                        ((RichTextBox)range).SelectionBackColor = Color.Red;
                        ((RichTextBox)range).Select(result + searchPatternTextBox.TextLength, 0);

                        indexes = indexes + ", " + result;
                    }


                    ((TextBox)occurrenceNumber).Text = searchResult.Count().ToString();
                    logger.Info("Found " + searchResult.Count() + " matching sequences. On positions: " + indexes);
                }
                wasSearched = true;
            }
            else
            {
                MessageBox.Show("Range or pattern is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Info("Range or pattern is empty.");
            }
        }

        /// <summary>
        /// Accelerates current algorithm. Allows decreasing delay time.
        /// </summary>
        /// <param name="sender">Pressed button.</param>
        /// <param name="e">System event</param>
        private void FasterButtonClick(object sender, EventArgs e)
        {
            int actualSpeed = Int32.Parse(delayTimeComboBox.Text);

            if ((actualSpeed - 100) >= 0)
            {
                delayTimeComboBox.Text = (actualSpeed - 100).ToString();
                logger.Info("Actual speed: " + delayTimeComboBox.Text);
            }
        }

        /// <summary>
        /// Start searching using currently choosen algorithm. Allows to use delays between steps.
        /// </summary>
        /// <param name="sender">Pressed button.</param>
        /// <param name="e">System event.</param>
        private void StepSearchButtonClick(object sender, EventArgs e)
        {
            actualStepDataGridView.Rows.Clear();
            logDataGridView.Rows.Clear();
            resultsDataGridView.Rows.Clear();
            resultsDataGridView.Columns.Clear();

            if (keyCount >= 3)
            { 
                logger.Info("Step searching started");
                logger.Info("Pattern: " + searchPatternTextBox.Text + ", range: " + rangeRichTextBox.Text + ", method: " + searchMethod.ToString());

                this.ClearHiglight(rangeRichTextBox);
                computeDeltaCheckBox.Enabled = false;
                simulateComparisonsCheckBox.Enabled = false;
                searchResult = this.controller.SearchPattern(searchPatternTextBox.Text.ToLower(),
                        rangeRichTextBox.Text.ToLower(), Int32.Parse(delayTimeComboBox.Text), simulateComparisonsCheckBox.Checked);

                this.ShowSearchedResults(rangeRichTextBox, searchOccurenceNumberTextBox, searchResult);

                saveResultsButton.Enabled = false;
                saveFileMenuItem.Enabled = false;
                computeDeltaCheckBox.Enabled = true;
                simulateComparisonsCheckBox.Enabled = true;
            }
            else
            {
                MessageBox.Show("Pattern must have more than 2 characters", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                logger.Info("Pattern is too short.");
            }
         }

        /// <summary>
        /// Prevents user to put other signsthan digits into delay time ComboBox.
        /// </summary>
        /// <param name="sender">ComboBox.</param>
        /// <param name="e">Data forthe KeyPress event.</param>
        private void DelayTimeComboBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Slow down current algorithm. Allows decreasing delay time.
        /// </summary>
        /// <param name="sender">Pressed button.</param>
        /// <param name="e">System event</param>
        private void SlowerButtonClick(object sender, EventArgs e)
        {
            int actualSpeed = Int32.Parse(delayTimeComboBox.Text);

            delayTimeComboBox.Text = (actualSpeed + 100).ToString();
            logger.Info("Actual speed: " + delayTimeComboBox.Text);
        }

        /// <summary>
        /// Switch to next algorithm.
        /// </summary>
        /// <param name="sender">Pressed button.</param>
        /// <param name="e">System event.</param>
        private void NextAlgorithmButtonClick(object sender, EventArgs e)
        {
            if (algorithmComboBox.SelectedIndex == 7)
            {
                stepListListBox.Items.Clear();
                variablesListBox.Items.Clear();
                algorithmComboBox.SelectedIndex = 0;
            }
            else
            {
                stepListListBox.Items.Clear();
                variablesListBox.Items.Clear();
                algorithmComboBox.SelectedIndex++;
            }


        }

        /// <summary>
        /// Switch to previous algorithm.
        /// </summary>
        /// <param name="sender">Pressed button.</param>
        /// <param name="e">System event.</param>
        private void PreviousAlgorithmButtonClick(object sender, EventArgs e)
        {
            if (algorithmComboBox.SelectedIndex == 0)
            {
                stepListListBox.Items.Clear();
                variablesListBox.Items.Clear();
                algorithmComboBox.SelectedIndex = 7;
            }
            else
            {
                stepListListBox.Items.Clear();
                variablesListBox.Items.Clear();
                algorithmComboBox.SelectedIndex--;
            }
        }

        /// <summary>
        /// Open save file view which allow to choose save parameters.
        /// </summary>
        /// <param name="sender">Pressed button.</param>
        /// <param name="e">Event data.</param>
        private void saveResults_Click(object sender, EventArgs e)
        {
            SaveResultsView saveView = new SaveResultsView(resultList, this);
            saveView.Show();
            saveResultsButton.Enabled = false;
            saveFileMenuItem.Enabled = false;
        }


        /// <summary>
        /// Enable pausing algorithm.
        /// </summary>
        /// <param name="sender">Pressed button.</param>
        /// <param name="e">System event.</param>
        private void pauseButton_Click(object sender, EventArgs e)
        {
            this.controller.Pause();
        }

        #endregion

        /// <summary>
        /// Add current counted search result to list.
        /// </summary>
        private void AddResultToList()
        {
            Result result = new Result();
            result.Pattern = searchPatternTextBox.Text;
            result.Range = rangeRichTextBox.Text;
            result.Results = searchResult;
            result.Method = searchMethod;
            result.Time = this.controller.GetAlgorithmTime();

            resultList.Add(result);
        }

        /// <summary>
        /// Overrides system PocessCmdKey method which listen key commands and perform 
        /// the suitable click of ToolStripButton.
        /// </summary>
        /// <param name="msg">Windows message.</param>
        /// <param name="keyData">Pressed key.</param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.F3):
                    logger.Info(keyData.ToString() + " pressed");
                    toolStrip1.Items[2].PerformClick();
                    break;
                case (Keys.F4):
                    logger.Info(keyData.ToString() + " pressed");
                    toolStrip1.Items[3].PerformClick();
                    break;
                case (Keys.F7):
                    logger.Info(keyData.ToString() + " pressed");
                    toolStrip1.Items[9].PerformClick();
                    break;
                case (Keys.F8):
                    logger.Info(keyData.ToString() + " pressed");
                    toolStrip1.Items[4].PerformClick();
                    break;
                case (Keys.F9):
                    logger.Info(keyData.ToString() + " pressed");
                    toolStrip1.Items[10].PerformClick();
                    break;
                case (Keys.F10):
                    logger.Info(keyData.ToString() + " pressed");
                    toolStrip1.Items[11].PerformClick();
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void aboutMenuSubItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();

            aboutForm.Show();
        }

        /// <summary>
        /// Count pattern length
        /// </summary>
        /// <param name="sender">Key pressed</param>
        /// <param name="e">Key data</param>
        private void searchPatternTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back && searchPatternTextBox.Text.Length < 20)
            {
                keyCount++;
            }
            else if(e.KeyChar == (char)Keys.Back && searchPatternTextBox.Text.Length > 0)
            {
                keyCount--;
            }

        }

        /// <summary>
        /// Adds current step to logDataGridView
        /// </summary>
        public void AddStepToLog()
        {
            DataGridViewRow clonedPattern  = ChangeBulkColor((DataGridViewRow)actualStepDataGridView.Rows[1].Clone(), Color.FromArgb(245, 245, 220), Color.LightGoldenrodYellow);
            DataGridViewRow clonedRange = ChangeBulkColor((DataGridViewRow)actualStepDataGridView.Rows[0].Clone(), Color.FromArgb(245, 245, 220), Color.LightGoldenrodYellow);

            for (int i = 0; i < actualStepDataGridView.Rows[0].Cells.Count; i++)
            {
                clonedRange.Cells[i].Value = actualStepDataGridView.Rows[0].Cells[i].Value;
                clonedPattern.Cells[i].Value = actualStepDataGridView.Rows[1].Cells[i].Value;

            }

            logDataGridView.Rows.Add(clonedRange);
            logDataGridView.Rows.Add(clonedPattern);
            logDataGridView.Rows.Add();

            logDataGridView.Rows[logDataGridView.Rows.Count - 1].Height = 3;
            logDataGridView.Rows[logDataGridView.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Black;
        }

        /// <summary>
        /// Change colors of empty cells for lower contrast.
        /// </summary>
        /// <param name="row">Actual row.</param>
        /// <param name="first">First  color.</param>
        /// <param name="second">Second color</param>
        /// <returns></returns>
        private DataGridViewRow ChangeBulkColor(DataGridViewRow row, Color first, Color second)
        {

            foreach (DataGridViewCell cell in row.Cells)
            {
                //if (cell.Style.BackColor != Color.LightGreen && cell.Style.BackColor != Color.IndianRed)
                if (cell.Style.BackColor != Color.Green && cell.Style.BackColor != Color.Red)
                {
                    if ((logDataGridView.Rows.Count / 3) % 2 != 0)
                        cell.Style.BackColor = first;
                    else
                        cell.Style.BackColor = second;
                }
            }

            return row;
        }

        /// <summary>
        /// Stops and reset appliaction
        /// </summary>
        /// <param name="sender">Pressed button.</param>
        /// <param name="e">Event data.</param>
        private void stopButton_Click(object sender, EventArgs e)
        {
            Application.Restart();

            // if(closeThis != null)
            // closeThis();
        }

        /// <summary>
        /// Add found indexes to resultsDataGridView.
        /// </summary>
        /// <param name="index">Found index.</param>
        /// <param name="count">Count of found indexes.</param>
        public void AddFoundIndex(int index, string count)
        {
            if (resultsDataGridView.Rows.Count == 0)
            {
                resultsDataGridView.Columns.Add(count, count);
                resultsDataGridView.Rows.Add(index.ToString());
            }
            else
            {
                resultsDataGridView.Columns.Add(count, count);
                resultsDataGridView.Rows[0].Cells[Int32.Parse(count) - 1].Value = index.ToString();
            }

            foreach (DataGridViewCell cell in resultsDataGridView.Rows[0].Cells)
            {
                cell.Style.Font = new System.Drawing.Font("Arial", 13F);
            }
        }

        /// <summary>
        /// Set background color of currently compared characters.
        /// </summary>
        /// <param name="index">Current index.</param>
        /// <param name="color">Choosen color.</param>
        public void SetDgvColor(int index, Color color)
        {
            actualStepDataGridView.Rows[0].Cells[index].Style.BackColor = color;
            actualStepDataGridView.Rows[1].Cells[index].Style.BackColor = color;
            actualStepDataGridView.Refresh();
        }

        /// <summary>
        /// Clears pattern and range TextBox
        /// </summary>
        /// <param name="sender">Pressed button.</param>
        /// <param name="e">Event data.</param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            rangeIndexTextBox.Text = "";
            searchPatternTextBox.Text = "";
        }

        /// <summary>
        /// Adds actual index in range, pattern and actual found sequence length to TextBoxes
        /// </summary>
        /// <param name="patternIndex">Actual index in pattern.</param>
        /// <param name="rangeIndex">Actual index in range.</param>
        /// <param name="sequenceLength">Actual found sequence lenght.</param>
        public void SetCurrentIndexes(int patternIndex, int rangeIndex, int sequenceLength)
        {
            rangeIndexTextBox.Text = rangeIndex.ToString();
            patternIndexTextBox.Text = patternIndex.ToString();
            matchedCharactersTextBox.Text = sequenceLength.ToString(); 
        }

        /// <summary>
        /// Sets actually compared strings in actualStepDataGridView
        /// </summary>
        /// <param name="range"></param>
        /// <param name="position"></param>
        public void SetActualStrings(string pattern,string range, int position)
        {
            actualStepDataGridView.Rows.Clear();
            actualStepDataGridView.Rows.Insert(0, Regex.Split(range.Substring(position, (range.Length - position >= 20 ? 20 : range.Length - position)), string.Empty).Skip(1).ToArray());
            actualStepDataGridView.Rows.Insert(1, Regex.Split(pattern, string.Empty).Skip(1).ToArray());
        }

        /// <summary>
        /// Sets higlights of three compared indexes.
        /// </summary>
        /// <param name="color">Color to be set.</param>
        /// <param name="row">Row to be changed.</param>
        /// <param name="index1">First cell to be changed.</param>
        /// <param name="index2">Second cell to be changed.</param>
        /// <param name="index3">Third cell to be changed.</param>
        public void SetMultipleActualStepHiglight(Color color, int row, int index1, int index2, int index3)
        {
            actualStepDataGridView.Rows[row].Cells[index1].Style.BackColor = Color.Green;
            actualStepDataGridView.Rows[row].Cells[index2].Style.BackColor = Color.Green;
            actualStepDataGridView.Rows[row].Cells[index3].Style.BackColor = Color.Green;
        }

        /// <summary>
        /// Disable or enable using some controls.
        /// </summary>
        public void ChangeControlsState()
        {
            controlEnabled = !controlEnabled;

            openFileButton.Enabled = controlEnabled;
            saveResultsButton.Enabled = controlEnabled;
            nextAlgorithmButton.Enabled = controlEnabled;
            previousAlgorithmButton.Enabled = controlEnabled;
            autoSearchButton.Enabled = controlEnabled;
            autoSearchMenuItem.Enabled = controlEnabled;
            stepSearchMenuItem.Enabled = controlEnabled;
            stepSearchButton.Enabled = controlEnabled;
            clearButton.Enabled = controlEnabled;
            algorithmComboBox.Enabled = controlEnabled;
            searchPatternTextBox.ReadOnly = !controlEnabled;
            rangeRichTextBox.ReadOnly = !controlEnabled;
        }

    }
}
