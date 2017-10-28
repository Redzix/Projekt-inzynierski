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

namespace EngineeringProject.View
{
    public partial class MainWindow : Form
    {
        bool wasSearched = false;

        private NaiveAlgorithmController naive = null;
       
        public MainWindow()
        {
            InitializeComponent();
            delayTimeComboBox.SelectedIndex = 0;
            naive = new NaiveAlgorithmController(this);        
        }

        private void textBoxNaiveSearchPattern_TextChanged(object sender, EventArgs e)
        {
            this.ClearHiglight(richTextBoxNaiveRange);
        }

        private void richTextBoxNaiveRange_TextChanged(object sender, EventArgs e)
        {
            if (wasSearched)
            {
                this.ClearHiglight(richTextBoxNaiveRange);

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
            if(e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult closeApplication = MessageBox.Show("Do you really want to close the application?", "Close",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2);

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

        private void naiveClearButton_Click(object sender, EventArgs e)
        {
            DialogResult clearNaiveFields = MessageBox.Show("Do you want to clear all fields on this page?", "Clear fields",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if(clearNaiveFields == DialogResult.Yes)
            {
                richTextBoxNaiveRange.Clear();
                textBoxNaiveSearchOccurenceNumber.Clear();
                textBoxNaiveSearchPattern.Clear();
            }
            else
            {
                return;
            }
        }

        private void openFileDialog_Click(object sender, EventArgs e)
        {
            int size = -1;
            string range = null;
            openFileDialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            DialogResult selectedFile = openFileDialog.ShowDialog();

            if(selectedFile == DialogResult.OK)
            {             
          
                string openfile = openFileDialog.FileName;

                try
                {
                    range = File.ReadAllText(openfile);
                    size = range.Length;
                }catch(IOException exc)
                {
                    MessageBox.Show(exc.ToString() ,"Error", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                finally
                {
                    switch (size)
                    {
                        case -1:
                            break;
                        case 0:
                            MessageBox.Show("File is empty.","Empty file", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                            break;
                        default:
                            richTextBoxNaiveRange.Text = range;
                            break;                      
                    }
                }

            }

        }

        /*public void HighlightActualStep(string[] stepList, int[,] stepPosition, int step)
        {
            rtbNaiveSearchSteps.Text = String.Join("\n", stepList);

            if (step - 1 >= 0)
            {
                rtbNaiveSearchSteps.Select(stepPosition[step - 1, 1], stepPosition[step - 1, 0]);
                rtbNaiveSearchSteps.SelectionBackColor = Color.White;

                rtbNaiveSearchSteps.Select(stepPosition[step, 1], stepPosition[step, 0]);
                rtbNaiveSearchSteps.SelectionBackColor = Color.Yellow;
                rtbNaiveSearchSteps.Select(stepPosition[step, 1] + stepPosition[step, 0] + step, rtbNaiveSearchSteps.TextLength - stepPosition[step, 1]);
                rtbNaiveSearchSteps.SelectionBackColor = Color.White;
            }
            else
            {
                rtbNaiveSearchSteps.Select(stepPosition[step, 1], stepPosition[step, 0]);
                rtbNaiveSearchSteps.SelectionBackColor = Color.Yellow;
            }
        }*/

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string[] stepList;
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    if (this.naive == null)
                    {
                        this.naive = new NaiveAlgorithmController();

                    }
                    else
                    {

                    }
                    break;                 
            }
        }

        private void ClearHiglight(RichTextBox rtb)
        {
            rtb.Select(0, richTextBoxNaiveRange.TextLength);
            rtb.SelectionBackColor = Color.White;
            rtb.Select(richTextBoxNaiveRange.TextLength, 0);
        }

        private void listBoxNaiveStepList_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics g = e.Graphics;
            Brush brush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ?
                          Brushes.Yellow : new SolidBrush(e.BackColor);
            g.FillRectangle(brush, e.Bounds);
            e.Graphics.DrawString(listBoxNaiveStepList.Items[e.Index].ToString(), new Font(FontFamily.GenericSansSerif, 12),
                     new SolidBrush(Color.Black), e.Bounds);
            e.DrawFocusRectangle();
        }

        public void LoadStepsToListbox(string[] stepList)
        {
            for(int i = 0; i < stepList.Length; i++)
            {
                listBoxNaiveStepList.Items.Add(stepList[i]);
            }
        }

        private void listBoxNaiveStepList_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 20;
        }

        public void HighlightActualStep(int step)
        {
            listBoxNaiveStepList.SelectedIndex = step;
        }

        private void autoSearchButton_Click(object sender, EventArgs e)
        {
            List<int> searchResult = new List<int>();
            this.ClearHiglight(richTextBoxNaiveRange);
            searchResult = this.naive.SearchPatternAutomatically(textBoxNaiveSearchPattern.Text, richTextBoxNaiveRange.Text);
            this.ShowSearchedResults(searchResult);
        }

        private void ShowSearchedResults(List<int> searchResult)
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
                        richTextBoxNaiveRange.Select(result, textBoxNaiveSearchPattern.TextLength);
                        richTextBoxNaiveRange.SelectionBackColor = Color.Red;
                    }

                    textBoxNaiveSearchOccurenceNumber.Text = searchResult.Count().ToString();
                }
                wasSearched = true;
            }
            else
            {
                MessageBox.Show("Range or pattern is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fasterButton_Click(object sender, EventArgs e)
        {

        }

        private void startAutoStepSearchButton_Click(object sender, EventArgs e)
        {
            List<int> searchResult = new List<int>();
            this.ClearHiglight(richTextBoxNaiveRange);
            searchResult = this.naive.SearchPatternWithDelay(textBoxNaiveSearchPattern.Text, richTextBoxNaiveRange.Text, Int32.Parse(delayTimeComboBox.Text));
            this.ShowSearchedResults(searchResult);
        }

        private void SaveResults_Click(object sender, EventArgs e)
        {

        }

        private void delayTimeComboBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void stepSearchButton_Click(object sender, EventArgs e)
        {

        }
    }
}
