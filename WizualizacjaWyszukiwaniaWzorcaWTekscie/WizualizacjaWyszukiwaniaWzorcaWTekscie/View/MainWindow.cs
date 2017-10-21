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
            naive = new NaiveAlgorithmController(this); 
            openFileDialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
        }

        private void bNaiveStartSearch_Click(object sender, EventArgs e)
        {
            List<int> searchResult = new List<int>();
            searchResult = this.naive.SearchPattern(tbNaiveSearchPattern.Text,rtbNaiveRange.Text);

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
                        rtbNaiveRange.Select(result, tbNaiveSearchPattern.TextLength);
                        rtbNaiveRange.SelectionBackColor = Color.Red;
                    }

                    tbNaiveSearchOccurenceNumber.Text = searchResult.Count().ToString();
                }
                wasSearched = true;
            }
            else
            {
                MessageBox.Show("Range or pattern is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbNaiveSearchPattern_TextChanged(object sender, EventArgs e)
        {
            this.ClearHiglight(rtbNaiveRange);
        }

        private void rtbNaiveRange_TextChanged(object sender, EventArgs e)
        {
            if (wasSearched)
            {
                this.ClearHiglight(rtbNaiveRange);

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
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
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


        private void bNaiveClear_Click(object sender, EventArgs e)
        {
            DialogResult clearNaiveFields = MessageBox.Show("Do you want to clear all fields on this page?", "Clear fields",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if(clearNaiveFields == DialogResult.Yes)
            {
                rtbNaiveRange.Clear();
                tbNaiveSearchOccurenceNumber.Clear();
                tbNaiveSearchPattern.Clear();
            }
            else
            {
                return;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int size = -1;
            string range = null;
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
                            rtbNaiveRange.Text = range;
                            break;                      
                    }
                }

            }

        }

        public void HighlightActualStep(string[] stepList, int step)
        {
            rtbNaiveSearchSteps.Text = String.Join("\n", stepList);

            if (step - 1 >= 0)
            {
                //ogar indeksow
                rtbNaiveSearchSteps.Select(0, stepList[step -1].Length);
                rtbNaiveSearchSteps.SelectionBackColor = Color.White;
                rtbNaiveSearchSteps.Select(stepList[step - 1].Length, 0);

                rtbNaiveSearchSteps.Select(stepList[step - 1].Length, stepList[step].Length);
                rtbNaiveSearchSteps.SelectionBackColor = Color.Yellow;
            }
            else
            {
                rtbNaiveSearchSteps.Select(0, stepList[step].Length-1);
                rtbNaiveSearchSteps.SelectionBackColor = Color.Yellow;
            }
             


        }

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
            rtb.Select(0, rtbNaiveRange.TextLength);
            rtb.SelectionBackColor = Color.White;
            rtb.Select(rtbNaiveRange.TextLength, 0);
        }
    }
}
