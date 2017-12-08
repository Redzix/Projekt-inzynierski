using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EngineeringProject.Enum;
using EngineeringProject.Commons;
using EngineeringProject.Model;
using System.IO;
using NLog;

namespace EngineeringProject.View
{
    public partial class SaveResultsView : Form
    {
        #region Fields
        private List<Result> resultList;

        private Saver saver;

        private MainWindow mainWindow;

        private string path;

        private Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        /// <summary>
        /// Main controller. Creates new results list, MainWindows handler and saver objcet.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="mainWindow"></param>
        public SaveResultsView(List<Result> result, MainWindow mainWindow)
        {
            this.resultList = new List<Result>(result);
            this.mainWindow = mainWindow;
            this.saver = new Saver();

            InitializeComponent();
            CustomiseComponents();
        }

        /// <summary>
        /// defaultsCheckBox event which is responsible for setting control state.
        /// </summary>
        /// <param name="sender">CheckBox.</param>
        /// <param name="e">Event data.</param>
        private void defaultsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (defaultsCheckBox.Checked)
            {
                ChangeControlState(false);
                logger.Info("Save file paramaters set to custom");
            }
            else
            {
                ChangeControlState(true);
                logger.Info("Save file paramaters set to default");
                exampleTextBox.Text = "Method,Range length,Pattern length,Sequences number,Search time";
            }
        }

        /// <summary>
        /// Change controls state.
        /// </summary>
        /// <param name="state">State to be set.</param>
        private void ChangeControlState(bool state)
        {
            rangeCheckBox.Enabled = state;
            destinationPathTextBox.Enabled = state;
            patternCheckBox.Enabled = state;
            indexesCheckBox.Enabled = state;
            changePathButton.Enabled = state;
        }

        /// <summary>
        /// Save results in file
        /// </summary>
        /// <param name="sender">Pressed button.</param>
        /// <param name="e">Event data.</param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            string savedString;
            string header;
            string savePath = destinationPathTextBox.Text;
            bool saveState = false;

            switch (defaultsCheckBox.Checked)
            {
                case true:
                   if (DialogResult.Yes == MessageBox.Show("Do you want to overwrite file \"results.txt\"", "Save results", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                   {
                        File.WriteAllText(savePath, string.Empty);

                        foreach (var result in resultList)
                        {
                            savedString = result.Method.ToString() + "," + result.Range.Length + "," + result.Pattern.Length + "," +
                                result.Results.Count() + "," + result.Time;
                            saveState = saver.DefaultSaveResults(savedString);
                        }
                    }
                   else
                   {
                        MessageBox.Show("Save failed.", "Save results", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                   }
                    break;
                case false:
                    if (savePath == "")
                    {
                        MessageBox.Show("Please set destination path.", "Save results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (File.Exists(savePath))
                        {
                            if (DialogResult.Yes == MessageBox.Show("Do you want to overwrite file " + path, "Save results", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                            {
                                File.WriteAllText(savePath, string.Empty);

                                if (rangeCheckBox.Checked && patternCheckBox.Checked && indexesCheckBox.Checked)
                                {
                                    foreach (var result in resultList)
                                    {
                                        savedString = result.Method.ToString() + "," + result.Range.Length + "," + result.Pattern.Length + "," +
                                                        result.Results.Count() + "," + result.Time + "," + result.Range + "," + result.Pattern + "," + string.Join(",", result.Results.ToArray());
                                        header = "Method,Range length,Pattern length,Sequences number,Search time,Range,Pattern,Indexes";
                                        saveState = saver.CustomSaveResults(savedString, header, savePath);
                                        saver.SetFirstSave(false);
                                    }
                                    saver.SetFirstSave(true);
                                }
                                else if (rangeCheckBox.Checked && patternCheckBox.Checked && !indexesCheckBox.Checked)
                                {
                                    foreach (var result in resultList)
                                    {
                                        savedString = result.Method.ToString() + "," + result.Range.Length + "," + result.Pattern.Length + "," +
                                                        result.Results.Count() + "," + result.Time + "," + result.Range + "," + result.Pattern;
                                        header = "Method,Range length,Pattern length,Sequences number,Search time,Range,Pattern";
                                        saveState = saver.CustomSaveResults(savedString, header, path);
                                        saver.SetFirstSave(false);
                                    }
                                    saver.SetFirstSave(true);

                                }
                                else if (rangeCheckBox.Checked && !patternCheckBox.Checked && indexesCheckBox.Checked)
                                {
                                    foreach (var result in resultList)
                                    {
                                        savedString = result.Method.ToString() + "," + result.Range.Length + "," + result.Pattern.Length + "," +
                                                        result.Results.Count() + "," + result.Time + "," + result.Range + "," + string.Join(",", result.Results.ToArray());
                                        header = "Method,Range length,Pattern length,Sequences number,Search time,Range,Indexes";
                                        saveState = saver.CustomSaveResults(savedString, header, savePath);
                                        saver.SetFirstSave(false);
                                    }
                                    saver.SetFirstSave(true);
                                }
                                else if (rangeCheckBox.Checked && !patternCheckBox.Checked && !indexesCheckBox.Checked)
                                {
                                    foreach (var result in resultList)
                                    {
                                        savedString = result.Method.ToString() + "," + result.Range.Length + "," + result.Pattern.Length + "," +
                                                        result.Results.Count() + "," + result.Time + "," + result.Range;
                                        header = "Method,Range length,Pattern length,Sequences number,Search time,Range";
                                        saveState = saver.CustomSaveResults(savedString, header, savePath);
                                        saver.SetFirstSave(false);
                                    }
                                    saver.SetFirstSave(true);
                                }
                                else if (!rangeCheckBox.Checked && patternCheckBox.Checked && indexesCheckBox.Checked)
                                {
                                    foreach (var result in resultList)
                                    {
                                        savedString = result.Method.ToString() + "," + result.Range.Length + "," + result.Pattern.Length + "," +
                                                        result.Results.Count() + "," + result.Time + "," + result.Pattern + "," + string.Join(",", result.Results.ToArray());
                                        header = "Method,Range length,Pattern length,Sequences number,Search time,Pattern,Indexes";
                                        saveState = saver.CustomSaveResults(savedString, header, savePath);
                                        saver.SetFirstSave(false);
                                    }
                                    saver.SetFirstSave(true);
                                }
                                else if (!rangeCheckBox.Checked && patternCheckBox.Checked && !indexesCheckBox.Checked)
                                {
                                    foreach (var result in resultList)
                                    {
                                        savedString = result.Method.ToString() + "," + result.Range.Length + "," + result.Pattern.Length + "," +
                                                        result.Results.Count() + "," + result.Time + "," + result.Pattern + ",";
                                        header = "Method,Range length,Pattern length,Sequences number,Search time,Pattern";
                                        saveState = saver.CustomSaveResults(savedString, header, savePath);
                                        saver.SetFirstSave(false);
                                    }
                                    saver.SetFirstSave(true);
                                }
                                else if (!rangeCheckBox.Checked && !patternCheckBox.Checked && indexesCheckBox.Checked)
                                {
                                    foreach (var result in resultList)
                                    {
                                        savedString = result.Method.ToString() + "," + result.Range.Length + "," + result.Pattern.Length + "," +
                                                        result.Results.Count() + "," + result.Time + "," + string.Join(",", result.Results.ToArray());
                                        header = "Method,Range length,Pattern length,Sequences number,Search time,Indexes";
                                        saveState = saver.CustomSaveResults(savedString, header, savePath);
                                        saver.SetFirstSave(false);
                                    }
                                    saver.SetFirstSave(true);
                                }
                                else if (!rangeCheckBox.Checked && !patternCheckBox.Checked && !indexesCheckBox.Checked)
                                {
                                    foreach (var result in resultList)
                                    {
                                        savedString = result.Method.ToString() + "," + result.Range.Length + "," + result.Pattern.Length + "," +
                                            result.Results.Count() + "," + result.Time;
                                        header = "Method,Range length,Pattern length,Sequences number,Search time";
                                        saveState = saver.CustomSaveResults(savedString, header, savePath);
                                        saver.SetFirstSave(false);
                                    }
                                    saver.SetFirstSave(true);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Save failed.", "Save results", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            if (rangeCheckBox.Checked && patternCheckBox.Checked && indexesCheckBox.Checked)
                            {
                                foreach (var result in resultList)
                                {
                                    savedString = result.Method.ToString() + "," + result.Range.Length + "," + result.Pattern.Length + "," +
                                                    result.Results.Count() + "," + result.Time + "," + result.Range + "," + result.Pattern + "," + string.Join(",", result.Results.ToArray());
                                    header = "Method,Range length,Pattern length,Sequences number,Search time,Range,Pattern,Indexes";
                                    saveState = saver.CustomSaveResults(savedString, header, savePath);
                                    saver.SetFirstSave(false);
                                }
                                saver.SetFirstSave(true);
                            }
                            else if (rangeCheckBox.Checked && patternCheckBox.Checked && !indexesCheckBox.Checked)
                            {
                                foreach (var result in resultList)
                                {
                                    savedString = result.Method.ToString() + "," + result.Range.Length + "," + result.Pattern.Length + "," +
                                                    result.Results.Count() + "," + result.Time + "," + result.Range + "," + result.Pattern;
                                    header = "Method,Range length,Pattern length,Sequences number,Search time,Range,Pattern";
                                    saveState = saver.CustomSaveResults(savedString, header, path);
                                    saver.SetFirstSave(false);
                                }
                                saver.SetFirstSave(true);

                            }
                            else if (rangeCheckBox.Checked && !patternCheckBox.Checked && indexesCheckBox.Checked)
                            {
                                foreach (var result in resultList)
                                {
                                    savedString = result.Method.ToString() + "," + result.Range.Length + "," + result.Pattern.Length + "," +
                                                    result.Results.Count() + "," + result.Time + "," + result.Range + "," + string.Join(",", result.Results.ToArray());
                                    header = "Method,Range length,Pattern length,Sequences number,Search time,Range,Indexes";
                                    saveState = saver.CustomSaveResults(savedString, header, savePath);
                                    saver.SetFirstSave(false);
                                }
                                saver.SetFirstSave(true);
                            }
                            else if (rangeCheckBox.Checked && !patternCheckBox.Checked && !indexesCheckBox.Checked)
                            {
                                foreach (var result in resultList)
                                {
                                    savedString = result.Method.ToString() + "," + result.Range.Length + "," + result.Pattern.Length + "," +
                                                    result.Results.Count() + "," + result.Time + "," + result.Range;
                                    header = "Method,Range length,Pattern length,Sequences number,Search time,Range";
                                    saveState = saver.CustomSaveResults(savedString, header, savePath);
                                    saver.SetFirstSave(false);
                                }
                                saver.SetFirstSave(true);
                            }
                            else if (!rangeCheckBox.Checked && patternCheckBox.Checked && indexesCheckBox.Checked)
                            {
                                foreach (var result in resultList)
                                {
                                    savedString = result.Method.ToString() + "," + result.Range.Length + "," + result.Pattern.Length + "," +
                                                    result.Results.Count() + "," + result.Time + "," + result.Pattern + "," + string.Join(",", result.Results.ToArray());
                                    header = "Method,Range length,Pattern length,Sequences number,Search time,Pattern,Indexes";
                                    saveState = saver.CustomSaveResults(savedString, header, savePath);
                                    saver.SetFirstSave(false);
                                }
                                saver.SetFirstSave(true);
                            }
                            else if (!rangeCheckBox.Checked && patternCheckBox.Checked && !indexesCheckBox.Checked)
                            {
                                foreach (var result in resultList)
                                {
                                    savedString = result.Method.ToString() + "," + result.Range.Length + "," + result.Pattern.Length + "," +
                                                    result.Results.Count() + "," + result.Time + "," + result.Pattern + ",";
                                    header = "Method,Range length,Pattern length,Sequences number,Search time,Pattern";
                                    saveState = saver.CustomSaveResults(savedString, header, savePath);
                                    saver.SetFirstSave(false);
                                }
                                saver.SetFirstSave(true);
                            }
                            else if (!rangeCheckBox.Checked && !patternCheckBox.Checked && indexesCheckBox.Checked)
                            {
                                foreach (var result in resultList)
                                {
                                    savedString = result.Method.ToString() + "," + result.Range.Length + "," + result.Pattern.Length + "," +
                                                    result.Results.Count() + "," + result.Time + "," + string.Join(",", result.Results.ToArray());
                                    header = "Method,Range length,Pattern length,Sequences number,Search time,Indexes";
                                    saveState = saver.CustomSaveResults(savedString, header, savePath);
                                    saver.SetFirstSave(false);
                                }
                                saver.SetFirstSave(true);
                            }
                            else if (!rangeCheckBox.Checked && !patternCheckBox.Checked && !indexesCheckBox.Checked)
                            {
                                foreach (var result in resultList)
                                {
                                    savedString = result.Method.ToString() + "," + result.Range.Length + "," + result.Pattern.Length + "," +
                                        result.Results.Count() + "," + result.Time;
                                    header = "Method,Range length,Pattern length,Sequences number,Search time";
                                    saveState = saver.CustomSaveResults(savedString, header, savePath);
                                    saver.SetFirstSave(false);
                                }
                                saver.SetFirstSave(true);
                            }
                        }
                    }
                    break;
            }
            if (saveState)
            {
                MessageBox.Show("File saved", "Save results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mainWindow.saveFileMenuItem.Enabled = false;
                mainWindow.saveResultsButton.Enabled = false;
                Close();
            }
            else
            {
                MessageBox.Show("File can't be saved.", "Save results", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Closes current form.
        /// </summary>
        /// <param name="sender">Pressed button.</param>
        /// <param name="e">Event data.</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            mainWindow.saveFileMenuItem.Enabled = true;
            mainWindow.saveResultsButton.Enabled = true;
            Close();
        }

        /// <summary>
        /// Change example row value when a property is changed,
        /// </summary>
        private void ControlStateChanged(object sender, EventArgs e)
        {
            string example = resultList[0].Method.ToString() + "," + resultList[0].Range.Length + "," + resultList[0].Pattern.Length + "," +
                                resultList[0].Results.Count() + "," + resultList[0].Time;

            if (defaultsCheckBox.Checked)
            {
                exampleTextBox.Text = example;
                destinationPathTextBox.Text = Application.StartupPath + "\\Results\\results.txt";
                return;
            }
            else if(rangeCheckBox.Checked && patternCheckBox.Checked && indexesCheckBox.Checked)
            {
                destinationPathTextBox.Text = string.Empty;
                example = resultList[0].Method.ToString() + "," + resultList[0].Range.Length + "," + resultList[0].Pattern.Length + "," +
                                resultList[0].Results.Count() + "," + resultList[0].Time + "," + resultList[0].Range + "," + resultList[0].Pattern + "," + string.Join(",", resultList[0].Results.ToArray());
            }
            else if ( rangeCheckBox.Checked && patternCheckBox.Checked && !indexesCheckBox.Checked)
            {
                destinationPathTextBox.Text = string.Empty;
                example = resultList[0].Method.ToString() + "," + resultList[0].Range.Length + "," + resultList[0].Pattern.Length + "," +
                                resultList[0].Results.Count() + "," + resultList[0].Time + "," + resultList[0].Range + "," + resultList[0].Pattern;
            }
            else if ( rangeCheckBox.Checked && !patternCheckBox.Checked && indexesCheckBox.Checked)
            {
                destinationPathTextBox.Text = string.Empty;
                example = resultList[0].Method.ToString() + "," + resultList[0].Range.Length + "," + resultList[0].Pattern.Length + "," +
                                resultList[0].Results.Count() + "," + resultList[0].Time + "," + resultList[0].Range + "," + string.Join(",", resultList[0].Results.ToArray());
            }
            else if (rangeCheckBox.Checked && !patternCheckBox.Checked && !indexesCheckBox.Checked)
            {
                destinationPathTextBox.Text = string.Empty;
                example = resultList[0].Method.ToString() + "," + resultList[0].Range.Length + "," + resultList[0].Pattern.Length + "," +
                                resultList[0].Results.Count() + "," + resultList[0].Time + "," + resultList[0].Range;
            }
            else if (!rangeCheckBox.Checked && patternCheckBox.Checked && indexesCheckBox.Checked)
            {
                destinationPathTextBox.Text = string.Empty;
                example = resultList[0].Method.ToString() + "," + resultList[0].Range.Length + "," + resultList[0].Pattern.Length + "," +
                                resultList[0].Results.Count() + "," + resultList[0].Time + "," + resultList[0].Pattern + "," + string.Join(",", resultList[0].Results.ToArray());
            }
            else if (!rangeCheckBox.Checked && patternCheckBox.Checked && !indexesCheckBox.Checked)
            {
                destinationPathTextBox.Text = string.Empty;
                example = resultList[0].Method.ToString() + "," + resultList[0].Range.Length + "," + resultList[0].Pattern.Length + "," +
                                resultList[0].Results.Count() + "," + resultList[0].Time + "," + resultList[0].Pattern;
            }
            else if (!rangeCheckBox.Checked && !patternCheckBox.Checked && indexesCheckBox.Checked)
            {
                destinationPathTextBox.Text = string.Empty;
                example = resultList[0].Method.ToString() + "," + resultList[0].Range.Length + "," + resultList[0].Pattern.Length + "," +
                                resultList[0].Results.Count() + "," + resultList[0].Time + "," + string.Join(",", resultList[0].Results.ToArray());
            }
            else if (!rangeCheckBox.Checked && !patternCheckBox.Checked && !indexesCheckBox.Checked)
            {
                destinationPathTextBox.Text = string.Empty;
                example = resultList[0].Method.ToString() + "," + resultList[0].Range.Length + "," + resultList[0].Pattern.Length + "," +
                                resultList[0].Results.Count() + "," + resultList[0].Time;
            }
            exampleTextBox.Text = example;
        }

        /// <summary>
        /// Add event handlers to CheckBoxes
        /// </summary>
        private void CustomiseComponents()
        {
            this.defaultsCheckBox.CheckedChanged += new System.EventHandler(this.ControlStateChanged);
            this.rangeCheckBox.CheckedChanged += new System.EventHandler(this.ControlStateChanged);
            this.patternCheckBox.CheckedChanged += new System.EventHandler(this.ControlStateChanged);
            this.indexesCheckBox.CheckedChanged += new System.EventHandler(this.ControlStateChanged);

            exampleTextBox.Text = resultList[0].Method.ToString() + "," + resultList[0].Range.Length + "," + resultList[0].Pattern.Length + "," +
                                resultList[0].Results.Count() + "," + resultList[0].Time;
            destinationPathTextBox.Text = Application.StartupPath + "\\Results\\results.txt";

        }

        /// <summary>
        /// Set saved file path.
        /// </summary>
        /// <param name="sender">Pressed button.</param>
        /// <param name="e">Event data.</param>
        private void changePathButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            DialogResult selectedFile = saveFileDialog1.ShowDialog();

            if (selectedFile == DialogResult.OK)
            {
                try
                {
                    path = saveFileDialog1.FileName;

                    destinationPathTextBox.Text = path;
                }
                catch (IOException exc)
                {
                    logger.Error("Save file " + exc.ToString());
                    MessageBox.Show(exc.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }
    }
}
