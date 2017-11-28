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
        private bool buttonEnabled = true;

        //Size of current alphabet
        protected int alphabetSize = 1251;

        //Algorithm duration time
        protected long algorithmTime;

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
        public abstract List<int> SearchPattern(string pattern, string range, int time);

        #endregion

        #region systemMethods
        /// <summary>
        /// Disable or enable using some controls.
        /// </summary>
        protected virtual void ChangeControlsState()
        {
            buttonEnabled = !buttonEnabled;

            this.view.openFileButton.Enabled = buttonEnabled;
            this.view.saveResultsButton.Enabled = buttonEnabled;
            this.view.nextAlgorithmButton.Enabled = buttonEnabled;
            this.view.previousAlgorithmButton.Enabled = buttonEnabled;
            this.view.autoSearchButton.Enabled = buttonEnabled;
            this.view.stepSearchButton.Enabled = buttonEnabled;
            this.view.clearButton.Enabled = buttonEnabled;
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
                }else { }

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
        public virtual long GetAlgorithmTie()
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

            for (int i = 0; i < alphabetSize; i++)
            {
                delta1[i] = pattern.Length - 1;
            }

            for (int j = 0; j < pattern.Length - 1; j++)
            {
                delta1[pattern[j]] = pattern.Length - 1 - j;
            }

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
            }

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

            for (int i = 0; i < alphabetSize; i++)
            {
                delta3[i] = pattern.Length;
            }

            for (int j = 0; j < pattern.Length; j++)
            {
                delta3[pattern[j]] = pattern.Length - j;
            }

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

            sufix[pattern.Length - 1] = pattern.Length - 1;

            for (int i = pattern.Length - 2; i >= 0; i--)
            {
                j = 0;
                while ((j <= i) && (pattern[i - j] == pattern[pattern.Length - j - 1]))
                {
                    j++;
                }
                sufix[i] = j;
            }

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

            this.view.HighlightActualStep(this.view.stepListListBox, 2);
            Delay(this.delayTime);
            for (int i = 0; i < alphabetSize; i++)
            {
                this.view.HighlightActualStep(this.view.stepListListBox, 3);
                Delay(this.delayTime);
                delta1[i] = pattern.Length - 1;

                this.view.HighlightActualStep(this.view.stepListListBox, 2);
                Delay(this.delayTime);
            }

            this.view.HighlightActualStep(this.view.stepListListBox, 5);
            Delay(this.delayTime);
            for (int j = 0; j < pattern.Length - 1; j++)
            {
                this.view.HighlightActualStep(this.view.stepListListBox, 6);
                Delay(this.delayTime);
                delta1[pattern[j]] = pattern.Length - 1 - j;

                this.view.HighlightActualStep(this.view.stepListListBox, 5);
                Delay(this.delayTime);
            }
            this.view.HighlightActualStep(this.view.stepListListBox, 8);
            Delay(this.delayTime);
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

            this.view.HighlightActualStep(this.view.stepListListBox, 2);
            Delay(this.delayTime);
            sufix = ComputeSufix(pattern, time);

            this.view.HighlightActualStep(this.view.stepListListBox, 3);
            Delay(this.delayTime);
            for (int i = 0; i < pattern.Length; i++)
            {
                this.view.HighlightActualStep(this.view.stepListListBox, 4);
                Delay(this.delayTime);
                delta2[i] = pattern.Length;

                this.view.HighlightActualStep(this.view.stepListListBox, 3);
                Delay(this.delayTime);
            }

            this.view.HighlightActualStep(this.view.stepListListBox, 6);
            Delay(this.delayTime);
            for (int i = pattern.Length - 1; i >= 0; i--)
            {
                this.view.HighlightActualStep(this.view.stepListListBox, 7);
                Delay(this.delayTime);
                if (sufix[i] == i + 1)
                {
                    this.view.HighlightActualStep(this.view.stepListListBox, 8);
                    Delay(this.delayTime);
                    for (int j = 0; j < pattern.Length - 1 - i; j++)
                    {
                        this.view.HighlightActualStep(this.view.stepListListBox, 9);
                        Delay(this.delayTime);
                        delta2[j] = pattern.Length - 1 - i;

                        this.view.HighlightActualStep(this.view.stepListListBox, 8);
                        Delay(this.delayTime);
                    }
                }
                this.view.HighlightActualStep(this.view.stepListListBox, 6);
                Delay(this.delayTime);
            }

            this.view.HighlightActualStep(this.view.stepListListBox, 13);
            Delay(this.delayTime);
            for (int i = 0; i < pattern.Length - 1; i++)
            {
                this.view.HighlightActualStep(this.view.stepListListBox, 14);
                Delay(this.delayTime);
                delta2[pattern.Length - 1 - sufix[i]] = pattern.Length - 1 - i;

                this.view.HighlightActualStep(this.view.stepListListBox, 13);
                Delay(this.delayTime);
            }
            this.view.HighlightActualStep(this.view.stepListListBox, 16);
            Delay(this.delayTime);
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

            this.view.HighlightActualStep(this.view.stepListListBox, 2);
            Delay(this.delayTime);
            for (int i = 0; i < alphabetSize; i++)
            {
                this.view.HighlightActualStep(this.view.stepListListBox, 3);
                Delay(this.delayTime);
                delta3[i] = pattern.Length + 1;

                this.view.HighlightActualStep(this.view.stepListListBox, 2);
                Delay(this.delayTime);
            }

            this.view.HighlightActualStep(this.view.stepListListBox, 5);
            Delay(this.delayTime);
            for (int j = 0; j < pattern.Length; j++)
            {
                this.view.HighlightActualStep(this.view.stepListListBox, 6);
                Delay(this.delayTime);
                delta3[pattern[j]] = pattern.Length - j;

                this.view.HighlightActualStep(this.view.stepListListBox, 5);
                Delay(this.delayTime);
            }
            this.view.HighlightActualStep(this.view.stepListListBox, 8);
            Delay(this.delayTime);
            return delta3;
        }

        /// <summary>
        /// Calculates suffix table with delaying..
        /// </summary>
        /// <param name="pattern">Searched pattern</param>
        /// <param name="time">Delay time</param>
        /// <returns>Returns array of sufixes</returns>
        protected abstract int[] ComputeSufix(string pattern, int time);

        #endregion
    }
}
