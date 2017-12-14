//MainController.cs
//
//Main controller abstract class which specifies core operations for all algorithms.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineeringProject.View;
using System.Windows.Forms;
using EngineeringProject.Model;
using NLog;
using System.Drawing;

namespace EngineeringProject.Controller
{
    abstract class MainController
    {
        //Object of MainWindow class.
        protected MainWindow view;

        //Boyer Moore algorithm model.
        protected MainModel model;

        //Time of delay between next algorithm steps.
        protected int delayTime = 100;

        //Information about pressed pause button
        private bool pausePressed = false;

        //Information about enabled buttons. If algorithm works they are disabled.
        private bool controlEnabled = true;

        //Size of current alphabet
        protected int alphabetSize = 1251;

        //Algorithm duration time
        protected long algorithmTime;

        //Events logger
        protected Logger logger = LogManager.GetCurrentClassLogger();

        //Stopwatch
        protected System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

        #region searchMethods
        /// <summary>
        /// Method which implements searching algorithm which works without any delaying.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user.</param>
        /// <param name="range">It's a text in which the pattern will be searched.</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty.</returns>
        public abstract List<int> SearchPattern(string pattern, string range);

        /// <summary>
        /// Method which implements searching algorithm which works with delay between next steps. Allows higlighitng of next steps.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user.</param>
        /// <param name="range">It's a text in which the pattern will be searched.</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty.</returns>
        public abstract List<int> SearchPattern(string pattern, string range, int time, bool comparisons);

        #endregion

        #region systemMethods
        /// <summary>
        /// Disable or enable using some controls.
        /// </summary>
        protected virtual void ChangeControlsState()
        {
            controlEnabled = !controlEnabled;

            this.view.openFileButton.Enabled = controlEnabled;
            this.view.saveResultsButton.Enabled = controlEnabled;
            this.view.nextAlgorithmButton.Enabled = controlEnabled;
            this.view.previousAlgorithmButton.Enabled = controlEnabled;
            this.view.autoSearchButton.Enabled = controlEnabled;
            this.view.autoSearchMenuItem.Enabled = controlEnabled;
            this.view.stepSearchMenuItem.Enabled = controlEnabled;
            this.view.stepSearchButton.Enabled = controlEnabled;
            this.view.clearButton.Enabled = controlEnabled;
            this.view.algorithmComboBox.Enabled = controlEnabled;
            this.view.searchPatternTextBox.ReadOnly = !controlEnabled;
            this.view.rangeRichTextBox.ReadOnly = !controlEnabled;
        }

        /// <summary>
        /// Causes a delay between highlighting each algorithm steps.
        /// </summary>
        /// <param name="time">It's the delay time in miliseconds.</param>
        protected virtual void Delay(int time)
        {
            System.Diagnostics.Stopwatch stp = new System.Diagnostics.Stopwatch();
            this.delayTime = time;

            stp.Start();

            while (stp.ElapsedMilliseconds <= this.delayTime)
            {
                System.Windows.Forms.Application.DoEvents();

                if(this.view.delayTimeComboBox.Text != "")
                {
                    this.delayTime = Int32.Parse(this.view.delayTimeComboBox.Text);
                }

                while (pausePressed)
                {                   
                    System.Windows.Forms.Application.DoEvents();
                }
            }
            stp.Stop();
        }

        /// <summary>
        /// Changes state of pausePressed when the pauseButton is pressed.
        /// </summary>
        public virtual void Pause()
        {
            this.pausePressed = !pausePressed;

            if (this.pausePressed)
                logger.Info("Searching paused.");
            else
                logger.Info("Searching resumed.");
        }

        /// <summary>
        /// Loads variables and stepList to suitable ListBoxes.
        /// </summary>
        /// <param name="variables">Algorithm variables</param>
        /// <param name="stepList">Algorithm steps list</param>
        /// <param name="view">Current view handler.</param>
        protected virtual void AddParametersToListBox(string[] variables, string[] stepList, MainWindow view)
        {
            view.LoadToListbox(view.variablesListBox, variables);
            view.LoadToListbox(view.stepListListBox, stepList);
        }
        
        /// <summary>
        /// Get current algorithm duration time.
        /// </summary>
        /// <returns>Algorithm duration time.</returns>
        public virtual long GetAlgorithmTime()
        {
            return algorithmTime;
        }

        #endregion

        #region heuristic
        /// <summary>
        /// Calculates bad character heuristic
        /// </summary>
        /// /// <param name="pattern">Searched pattern</param>
        /// <returns>Returns array of computed indexes.</returns>
        protected virtual int[] ComputeDelta1(string pattern)
        {
            int[] delta1 = new int[alphabetSize];
            string result = "";

            logger.Info("Compute delta1 started.");
            for (int i = 0; i < alphabetSize; i++)
            {
                delta1[i] = pattern.Length - 1;
            }

            for (int j = 0; j < pattern.Length - 1; j++)
            {
                delta1[pattern[j]] = pattern.Length - 1 - j;
                result = result + ", " + (pattern.Length - 1 - j);
            }
            logger.Info("delta1: " + result);
            return delta1;
        }

        /// <summary>
        /// Calculates good sufixex heuristic.
        /// </summary>
        /// <param name="pattern">Searched pattern</param>
        /// <returns>Returns array of computed indexes.</returns>
        protected virtual int[] ComputeDelta2(string pattern)
        {
            int[] delta2 = new int[pattern.Length];
            int[] sufix;
            string result = "";
            logger.Info("Compute delta2 started.");
            sufix = ComputeSufix(pattern);

            for (int i = 0; i < pattern.Length; i++)
            {
                delta2[i] = pattern.Length;
            }

            for (int i = pattern.Length - 1; i >= 0; i--)
            {
                if (sufix[i] == i + 1)
                {
                    for (int j = 0; j < pattern.Length - 1 - i; j++)
                    {
                        delta2[j] = pattern.Length - 1 - i;
                    }
                }
            }

            for (int i = 0; i < pattern.Length - 1; i++)
            {
                delta2[pattern.Length - 1 - sufix[i]] = pattern.Length - 1 - i;
                result = result + ", " + (pattern.Length - 1 - i);
            }
            logger.Info("delta2: " + result);
            return delta2;
        }

        /// <summary>
        /// Calculates bad character heuristic
        /// </summary>
        /// /// <param name="pattern">Searched pattern</param>
        /// <returns>Returns array of computed indexes.</returns>
        protected virtual int[] ComputeDelta3(string pattern)
        {
            int[] delta3 = new int[alphabetSize];
            string result = "";

            logger.Info("Compute delta3 started.");
            for (int i = 0; i < alphabetSize; i++)
            {
                delta3[i] = pattern.Length;
            }

            for (int j = 0; j < pattern.Length; j++)
            {
                delta3[pattern[j]] = pattern.Length - j;
                result = result + ", " + (pattern.Length - j);
            }

            logger.Info("delta3: " + result);
            return delta3;
        }

        /// <summary>
        /// Calculates suffix table.
        /// </summary>
        /// <param name="pattern">Searched pattern.</param>
        /// <returns>Returns array of sufixes.</returns>
        protected virtual int[] ComputeSufix(string pattern)
        {
            int[] sufix = new int[pattern.Length];
            int j;
            string result = "";

            logger.Info("Compute sufix started.");
            sufix[pattern.Length - 1] = pattern.Length - 1;

            for (int i = pattern.Length - 2; i >= 0; i--)
            {
                j = 0;
                while ((j <= i) && (pattern[i - j] == pattern[pattern.Length - j - 1]))
                {
                    j++;
                }
                sufix[i] = j;
                result = result + ", " + j;
            }

            logger.Info("sufix: " + result);
            return sufix;
        }

        /// <summary>
        /// Calculates bad character heuristic ith delaying.
        /// </summary>
        /// <param name="pattern">Searched pattern</param>
        /// <param name="time">Delay time.</param>
        /// <returns>Returns array of computed indexes.</returns>
        protected virtual int[] ComputeDelta1(string pattern, int time)
        {
            int[] delta1 = new int[alphabetSize];

            AddParametersToListBox(this.model.GetComputeDelta1Variables(), this.model.GetComputeDelta1StepList(), this.view);

            HiglightStep(2);
            
            for (int i = 0; i < alphabetSize; i++)
            {
                HiglightStep(3);
                
                delta1[i] = pattern.Length - 1;

                HiglightStep(2);
                
            }

            HiglightStep(5);
            
            for (int j = 0; j < pattern.Length - 1; j++)
            {
                HiglightStep(6);
                
                delta1[pattern[j]] = pattern.Length - 1 - j;

                HiglightStep(5);
                
            }
            HiglightStep(8);
            
            return delta1;
        }

        /// <summary>
        /// Calculates good sufix heuristic with delaying.
        /// </summary>
        /// <param name="pattern">Searched pattern</param>
        /// <param name="time">Delay time.</param>
        /// <returns>Returns array of computed indexes.</returns>
        protected virtual int[] ComputeDelta2(string pattern, int time)
        {
            int[] delta2 = new int[pattern.Length];
            int[] sufix;

            AddParametersToListBox(this.model.GetComputeDelta2Variables(), this.model.GetComputeDelta2StepList(), this.view);

            HiglightStep(2);
            
            sufix = ComputeSufix(pattern, time);
            AddParametersToListBox(this.model.GetComputeDelta2Variables(), this.model.GetComputeDelta2StepList(), this.view);

            HiglightStep(3);
            
            for (int i = 0; i < pattern.Length; i++)
            {
                HiglightStep(4);
                
                delta2[i] = pattern.Length;

                HiglightStep(3);
                
            }

            HiglightStep(6);
            
            for (int i = pattern.Length - 1; i >= 0; i--)
            {
                HiglightStep(7);
                
                if (sufix[i] == i + 1)
                {
                    HiglightStep(8);
                    
                    for (int j = 0; j < pattern.Length - 1 - i; j++)
                    {
                        HiglightStep(9);
                        
                        delta2[j] = pattern.Length - 1 - i;

                        HiglightStep(8);
                        
                    }
                }
                HiglightStep(6);
                
            }

            HiglightStep(13);
            
            for (int i = 0; i < pattern.Length - 1; i++)
            {
                HiglightStep(14);
                
                delta2[pattern.Length - 1 - sufix[i]] = pattern.Length - 1 - i;

                HiglightStep(13);
                
            }
            HiglightStep(16);
            
            return delta2;
        }

        /// <summary>
        /// Calculates bad character heuristic ith delaying.
        /// </summary>
        /// <param name="pattern">Searched pattern</param>
        /// <param name="time">Delay time.</param>
        /// <returns>Returns array of computed indexes.</returns>
        protected virtual int[] ComputeDelta3(string pattern, int time)
        {
            int[] delta3 = new int[alphabetSize];

            AddParametersToListBox(this.model.GetComputeDelta3Variables(), this.model.GetComputeDelta3StepList(), this.view);

            HiglightStep(2);
            
            for (int i = 0; i < alphabetSize; i++)
            {
                HiglightStep(3);
                
                delta3[i] = pattern.Length + 1;

                HiglightStep(2);
                
            }

            HiglightStep(5);
            
            for (int j = 0; j < pattern.Length; j++)
            {
                HiglightStep(6);
                
                delta3[pattern[j]] = pattern.Length - j;

                HiglightStep(5);
                
            }
            HiglightStep(8);
            
            return delta3;
        }

        /// <summary>
        /// Calculates suffix table with delaying..
        /// </summary>
        /// <param name="pattern">Searched pattern</param>
        /// <param name="time">Delay time</param>
        /// <returns>Returns array of sufixes</returns>
        protected virtual int[] ComputeSufix(string pattern, int time)
        {
            int[] sufix = new int[pattern.Length];
            int j;

            AddParametersToListBox(this.model.GetComputeSufixVariables(), this.model.GetComputeSufixStepList(), this.view);

            HiglightStep(2);
            
            sufix[pattern.Length - 1] = pattern.Length;

            HiglightStep(3);
            
            for (int i = pattern.Length - 2; i >= 0; i--)
            {
                HiglightStep(4);
                
                j = 0;

                HiglightStep(5);
                
                while ((j <= i) && (pattern[i - j] == pattern[pattern.Length - j - 1]))
                {
                    HiglightStep(6);
                    
                    j++;

                    HiglightStep(5);
                    
                }
                HiglightStep(7);
                
                sufix[i] = j;

                HiglightStep(3);
                
            }
            HiglightStep(9);
            

            AddParametersToListBox(this.model.GetComputeDelta1Variables(), this.model.GetComputeDelta1StepList(),
                this.view);
            return sufix;
        }

        #endregion

        #region visio



        /// <summary>
        /// Higlights actual step and provides delay before next step.
        /// </summary>
        /// <param name="step">Actual step.</param>
        protected virtual void HiglightStep(int step)
        {
            this.view.HighlightActualStep(step);
            Delay(this.delayTime);
        }
        #endregion
    }
}
