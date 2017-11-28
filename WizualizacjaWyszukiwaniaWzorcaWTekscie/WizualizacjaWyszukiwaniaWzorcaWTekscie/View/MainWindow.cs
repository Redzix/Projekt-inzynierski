//MainWindow.cs
//
//Partial class of MainWindow. Implements all GUI's events.
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EngineeringProject.Controller;
using System.IO;
using System.Text.RegularExpressions;
using EngineeringProject.Commons;
using EngineeringProject.Enum;

namespace EngineeringProject.View
{
    public partial class MainWindow : Form
    {
        //Check if there was an search algorithm iteration.
        bool wasSearched = false;

        //Controller of Naive algorithm.
        private MainController controller = null;

        private ESearchMethods searcMethod;

        private Saver saver = null;


        #region constructors
        //Main constructor. Creates new Naive algorithm controller and sets default delay time.
        public MainWindow()
        {
            InitializeComponent();
            delayTimeComboBox.SelectedIndex = 0;
            algorithmComboBox.SelectedIndex = 0;
            controller = new NaiveController(this);
            saver = new Saver();
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
        public void HighlightActualStep(ListBox listBox, int step)
        {
            ((ListBox)listBox).SelectedIndex = step;
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
            this.ClearHiglight(rangeRichTextBox);
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
                rangeRichTextBox.Clear();
                searchOccurenceNumberTextBox.Clear();
                searchPatternTextBox.Clear();
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
                    MessageBox.Show(exc.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    switch (size)
                    {
                        case -1:
                            break;
                        case 0:
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
            switch (algorithmComboBox.SelectedIndex)
            {
                case 0:
                    this.controller = new NaiveController(this);
                    searcMethod = ESearchMethods.NAIVE;
                    this.ClearHiglight(rangeRichTextBox);
                    break;
                case 1:
                    this.controller = new KnuthMorrisPrattController(this);
                    searcMethod = ESearchMethods.KMP;
                    this.ClearHiglight(rangeRichTextBox);
                    break;
                case 2:
                    this.controller = new BoyerMooreController(this);
                    searcMethod = ESearchMethods.BOYER_MOORE;
                    this.ClearHiglight(rangeRichTextBox);
                    break;
                case 3:
                    this.controller = new HorspoolController(this);
                    searcMethod = ESearchMethods.HORSPOOL;
                    this.ClearHiglight(rangeRichTextBox);
                    break;
                case 4:
                    this.controller = new QuickSearchController(this);
                    searcMethod = ESearchMethods.QUICK_SEARCH;
                    this.ClearHiglight(rangeRichTextBox);
                    break;
                case 5:
                    this.controller = new RaitaController(this);
                    searcMethod = ESearchMethods.RAITA;
                    this.ClearHiglight(rangeRichTextBox);
                    break;
                case 6:
                    this.controller = new SmithController(this);
                    searcMethod = ESearchMethods.SMITH;
                    this.ClearHiglight(rangeRichTextBox);
                    break;
                case 7:
                    this.controller = new NotSoNaiveController(this);
                    searcMethod = ESearchMethods.NOT_SO_NAIVE;
                    this.ClearHiglight(rangeRichTextBox);
                    break;
                default:
                    this.controller = new NaiveController(this);
                    searcMethod = ESearchMethods.NAIVE;
                    this.ClearHiglight(rangeRichTextBox);
                    break;
            }
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

            searchOccurenceNumberTextBox.Text = "";
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
            List<int> searchResult = new List<int>();

            this.ClearHiglight(rangeRichTextBox);
            searchResult = this.controller.SearchPattern(searchPatternTextBox.Text.ToLower(), rangeRichTextBox.Text.ToLower());
            this.ShowSearchedResults(rangeRichTextBox, searchOccurenceNumberTextBox, searchResult);
        }

        /// <summary>
        /// Show searched result on corresponding outputs. Higlights all searched sequences in RichTextBox and puts occurence number into TextBox.
        /// </summary>
        /// <param name="richTextBox"></param>
        /// <param name="textBox"></param>
        /// <param name="searchResult"></param>
        private void ShowSearchedResults(RichTextBox range, TextBox occurrenceNumber, List<int> searchResult)
        {
            if (searchResult != null)
            {
                if (searchResult.Count() == 0)
                {
                    MessageBox.Show("No matched sequences were found.", "Nothing found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    foreach (var result in searchResult)
                    {
                        ((RichTextBox)range).Select(result, searchPatternTextBox.TextLength);
                        ((RichTextBox)range).SelectionBackColor = Color.Red;
                        ((RichTextBox)range).Select(result + searchPatternTextBox.TextLength, 0);
                    }

                    ((TextBox)occurrenceNumber).Text = searchResult.Count().ToString();
                }
                wasSearched = true;
            }
            else
            {
                MessageBox.Show("Range or pattern is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                delayTimeComboBox.Text = (actualSpeed - 100).ToString();
            else { }
        }

        /// <summary>
        /// Start searching using currently choosen algorithm. Allows to use delays between steps.
        /// </summary>
        /// <param name="sender">Pressed button.</param>
        /// <param name="e">System event.</param>
        private void StepSearchButtonClick(object sender, EventArgs e)
        {
            List<int> searchResult = new List<int>();

            actualStepDataGridView.Rows.Clear();

            this.ClearHiglight(rangeRichTextBox);
           //this.AddToDataGridView(actualStepDataGridView, rangeRichTextBox.Text.Substring(0, (rangeRichTextBox.Text.Length >= 20 ? 20 : rangeRichTextBox.Text.Length)));
              //this.AddToDataGridView(actualStepDataGridView, searchPatternTextBox.Text);

            searchResult = this.controller.SearchPattern(searchPatternTextBox.Text.ToLower(), 
                rangeRichTextBox.Text.ToLower(), Int32.Parse(delayTimeComboBox.Text));
            this.ShowSearchedResults(rangeRichTextBox, searchOccurenceNumberTextBox, searchResult);
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

        private void saveResults_Click(object sender, EventArgs e)
        {
            if(saver.SaveResults(searchPatternTextBox.Text.Length, rangeRichTextBox.Text.Length, 
                Int32.Parse(searchOccurenceNumberTextBox.Text), this.controller.GetAlgorithmTie(), searcMethod))
            {
                MessageBox.Show("Results saved.", "Save results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Results couldn't be saved.", "Save results", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        //testing
        private void AddToDataGridView(DataGridView dataGridView, string text)
        {
            string[] splitted;

            splitted = Regex.Split(text, string.Empty);
            splitted = splitted.Skip(1).ToArray();
            dataGridView.Rows.Add(splitted);
            //TODO: kolejne kroki pokazywane w listvwiev, oddzielane pustymi wierszami, albo poprostu zmiany w jednym i tym samym, a do tego log, widoczny tylko poprzedni, obecny i kolejny krok, w logu wszystko, log sie wyswietla w nowym oknie po wcisniecu, mozna go zapisac do pliku
            dataGridView.Rows[0].Cells[5].Style.BackColor = Color.Green;
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
                    toolStrip1.Items[2].PerformClick();
                    break;
                case (Keys.F4):
                    toolStrip1.Items[3].PerformClick();
                    break;
                case (Keys.F7):
                    toolStrip1.Items[9].PerformClick();
                    break;
                case (Keys.F9):
                    toolStrip1.Items[10].PerformClick();
                    break;
                case (Keys.F10):
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
    }
}
