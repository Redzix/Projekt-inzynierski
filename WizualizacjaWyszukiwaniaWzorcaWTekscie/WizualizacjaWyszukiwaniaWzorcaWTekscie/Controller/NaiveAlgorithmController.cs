using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineeringProject.View;
using EngineeringProject.Model;

namespace EngineeringProject.Controller
{
    class NaiveAlgorithmController
    {
        private NaiveAlgorithm model;

        private MainWindow view;

        public NaiveAlgorithmController()
        {
            model = new NaiveAlgorithm();
        }

        public NaiveAlgorithmController(MainWindow view)
        {
            this.model = new NaiveAlgorithm();
            this.view = view;
            this.view.rtbNaiveSearchVariables.Text = this.SetVariables();
            //  this.view.rtbNaiveSearchSteps.Text = string.Join("\n",this.SetStepList());    
            this.view.LoadStepsToListbox(this.model.GetStepList());
        }

        private string SetVariables()
        {
            return this.model.GetVariables();
        }

        private string[] SetStepList()
        {
            return this.model.GetStepList();
        }
        /// <summary>
        /// Method which implements Naive Pattern Searching algorithm.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user.</param>
        /// <param name="range">It's a text in which the pattern will be searched.</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty..</returns>
        public List<int> SearchPatternAutomatically(string pattern, string range)
        {
            List<int> searchResult = new List<int>();
            int k;

            if ((pattern.Length == 0) || (range.Length == 0))
            {
                return null;
            }         

            for (int i = 0; i <= (range.Length - pattern.Length); i++)
            {               
                k = 0;
                while ((k < pattern.Length) && (range[i + k] == pattern[k]))
                {
                    k++;
                }

                if(k == pattern.Length)
                {
                    searchResult.Add(i);
                }             
            }
            return searchResult;
        }

        public List<int> SearchPatternWithDelay(string pattern, string range)
        {
            List<int> searchResult = new List<int>();
            int k;
            //int[,] stepPosition;
            //string[] stepList;

            if ((pattern.Length == 0) || (range.Length == 0))
            {
                return null;
            }

            //stepPosition = this.model.GetStepPosition();
            //stepList = this.model.GetStepList();

            //this.view.HighlightActualStep(stepList, stepPosition, 2);
            this.view.HighlightActualStep(2);
            this.Delay(1000);
            for (int i = 0; i <= (range.Length - pattern.Length); i++)
            {
                // this.view.HighlightActualStep(stepList, stepPosition, 4);
                this.view.HighlightActualStep(4);
                this.Delay(1000);
                k = 0;

                // this.view.HighlightActualStep(stepList, stepPosition, 5);
                this.view.HighlightActualStep(5);
                this.Delay(1000);
                while ((k < pattern.Length) && (range[i + k] == pattern[k]))
                {
                    // this.view.HighlightActualStep(stepList, stepPosition, 6);
                    this.view.HighlightActualStep(6);
                    this.Delay(1000);
                    k++;
                }

                //this.view.HighlightActualStep(stepList, stepPosition, 8);
                this.view.HighlightActualStep(8);
                this.Delay(1000);
                if (k == pattern.Length)
                {
                    // this.view.HighlightActualStep(stepList, stepPosition, 9);
                    this.view.HighlightActualStep(9);
                    this.Delay(1000);
                    searchResult.Add(i);
                }
            }
            //this.view.HighlightActualStep(stepList, stepPosition, 12);
            this.view.HighlightActualStep(12);
            this.Delay(1000);
            return searchResult;
        }

        /// <summary>
        /// Causes a delay between highlighting each algorithm steps.
        /// </summary>
        /// <param name="time">It's the delay time.</param>
        private void Delay(int time)
        {
            System.Diagnostics.Stopwatch stp = new System.Diagnostics.Stopwatch();
            stp.Start();
            while (stp.ElapsedMilliseconds <= time)
            {
                System.Windows.Forms.Application.DoEvents();
            }
            stp.Stop();
        }

    }
}
