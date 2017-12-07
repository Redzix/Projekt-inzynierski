//NaiveController.cs
//
//Controller which is responsible for Naive algorithm execution.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineeringProject.View;
using EngineeringProject.Model;
using System.Text.RegularExpressions;
using System.Drawing;

namespace EngineeringProject.Controller
{
    sealed class NaiveController : MainController
    {
        /// <summary>
        /// Constructor which create new model. 
        /// </summary>
        public NaiveController()
        {
            model = new Naive();
        }

        /// <summary>
        /// Main constructor. Creates new model and view object. Allows loading variables, steplist to suitable ListBoxes.
        /// </summary>
        /// <param name="view">Current used view handler.</param>
        public NaiveController(MainWindow view)
        {
            this.model = new Naive();
            this.view = ((MainWindow)view);

            AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);
        }

        /// <summary>
        /// Method which implements Naive searching algorithm which works without any delaying.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user.</param>
        /// <param name="range">It's a text in which the pattern will be searched.</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty.</returns>
        override public List<int> SearchPattern(string pattern, string range)
        {
            List<int> searchResult = new List<int>();
            int k;

            if ((pattern.Length == 0) || (range.Length == 0))
            {
                
                return null;
            }

            ChangeControlsState();
            AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);

            stopWatch.Start();
            for (int i = 0; i <= (range.Length - pattern.Length); i++)
            {
                k = 0;

                while ((k < pattern.Length) && (range[i + k] == pattern[k]))
                {
                    k++;
                }

                if (k == pattern.Length)
                {
                    searchResult.Add(i);
                }
            }
            stopWatch.Start();
            this.algorithmTime = stopWatch.ElapsedMilliseconds;
            ChangeControlsState();
            return searchResult;
        }

        /// <summary>
        /// Method which implements Naive searching algorithm which works with delay between next steps. Allows higlighitng of next steps.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user.</param>
        /// <param name="range">It's a text in which the pattern will be searched.</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty.</returns>
        override public List<int> SearchPattern(string pattern, string range, int time, bool comparisons)
        {
            List<int> searchResult = new List<int>();
            int k;

            this.delayTime = time;
            if ((pattern.Length == 0) || (range.Length == 0))
            {
                return null;
            }

            ChangeControlsState();


            HiglightStep(2);
            
            for (int i = 0; i <= (range.Length - pattern.Length); i++)
            {
                if (comparisons)
                {
                    this.view.actualStepDataGridView.Rows.Clear();
                    this.view.actualStepDataGridView.Rows.Insert(0, Regex.Split(range.Substring(i, (range.Length - i >= 20 ? 20 : range.Length - i)), string.Empty).Skip(1).ToArray());
                    this.view.actualStepDataGridView.Rows.Insert(1, Regex.Split(pattern, string.Empty).Skip(1).ToArray());
                }
                HiglightStep(4);
                
                k = 0;

                HiglightStep(5);
                
                while ((k < pattern.Length) && (range[i + k] == pattern[k]))
                {
                    
                    if (range[i + k] == pattern[k] && comparisons)
                    {
                        SetDgvColor(k, Color.Green);
                        this.view.AddStepToLog();
                    }

                    HiglightStep(6);
                    
                    k++;

                    HiglightStep(5);
                    
                }


                if (k < pattern.Length && range[i + k] != pattern[k] && comparisons)
                {
                    SetDgvColor(k, Color.Red);
                    this.view.AddStepToLog();
                }

                HiglightStep(8);
                
                if (k == pattern.Length)
                {
                    HiglightStep(9);
                    
                    searchResult.Add(i);

                    if (comparisons)
                    {
                        AddFoundIndex(i, searchResult.Count.ToString());
                    }
                }
                
                HiglightStep(2);
                
            }
            ChangeControlsState();

            HiglightStep(12);
            
            return searchResult;
        }

        protected override int[] ComputeSufix(string pattern, int time)
        {
            throw new NotImplementedException();
        }
    }
}
