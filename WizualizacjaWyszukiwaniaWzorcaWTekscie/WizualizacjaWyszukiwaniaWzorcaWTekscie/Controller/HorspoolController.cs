//HorspoolController.cs
//
//Controller which is responsible for Horspool algorithm execution.
//

using System;
using System.Collections.Generic;
using System.Linq;
using EngineeringProject.View;
using EngineeringProject.Model;
using System.Drawing;
using System.Text.RegularExpressions;

namespace EngineeringProject.Controller
{
    sealed class HorspoolController : MainController
    {
        /// <summary>
        /// Constructor which create new model.
        /// </summary>
        public HorspoolController()
        {
            this.model = new Horspool();
        }

        /// <summary>
        /// Main constructor. Creates new model and view object. Allows loading variables, steplist to suitable ListBoxes.
        /// </summary>
        /// <param name="view">Current used view handler.</param>
        public HorspoolController(MainWindow view)
        {
            this.model = new Horspool();
            this.view = ((MainWindow)view);

            AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);
        }

        /// <summary>
        /// Method which implements Boyer Moore Horspool searching algorithm which works without any delaying.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user.</param>
        /// <param name="range">It's a text in which the pattern will be searched.</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty.</returns>
        override public List<int> SearchPattern(string pattern, string range)
        {
            List<int> searchResult = new List<int>();
            int[] delta1;
            int j = 0;
            int i;

            if ((pattern.Length == 0) || (range.Length == 0))
            {
                return null;
            }
            ChangeControlsState();

            AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);

            delta1 = ComputeDelta1(pattern);

            while (j <= range.Length - pattern.Length)
            {
                i = pattern.Length - 1;
                while ((i >= 0) && (pattern[i] == range[i + j]))
                {
                    i--;
                }

                if (i < 0)
                {
                    searchResult.Add(j);
                    j += delta1[range[pattern.Length - 1 + j]];
                }
                else
                {
                    j += delta1[range[pattern.Length - 1 + j]];
                }

            }
            ChangeControlsState();
            return searchResult;
        }

        /// <summary>
        /// Method which implements Boyer Moore Horspool searching algorithm which works with delay between next steps. Allows higlighitng of next steps.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user.</param>
        /// <param name="range">It's a text in which the pattern will be searched.</param>
        /// <param name="time"></param>It's delay time between steps</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty.</returns>
        override public List<int> SearchPattern(string pattern, string range, int time, bool comparisons)
        {
            List<int> searchResult = new List<int>();
            int[] delta1;
            int j;
            int i;

            if ((pattern.Length == 0) || (range.Length == 0))
            {
                return null;
            }
            ChangeControlsState();

            AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(),
                             this.view);

            HiglightStep(2);
            
            j = 0;

            HiglightStep(3);
            

            if (this.view.computeDeltaCheckBox.Checked)
            {
                delta1 = ComputeDelta1(pattern, time);
                AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(),
                             this.view);
            }
            else
            {
                delta1 = ComputeDelta1(pattern);
            }

            HiglightStep(4);
            

            while (j <= range.Length - pattern.Length)
            {
                if (comparisons)
                {
                    this.view.actualStepDataGridView.Rows.Clear();
                    this.view.actualStepDataGridView.Rows.Insert(0, Regex.Split(range.Substring(j, (range.Length - j >= 20 ? 20 : range.Length - j)), string.Empty).Skip(1).ToArray());
                    this.view.actualStepDataGridView.Rows.Insert(1, Regex.Split(pattern, string.Empty).Skip(1).ToArray());
                }
                HiglightStep(6);
                
                i = pattern.Length - 1;

                HiglightStep(7);
                
                while ((i >= 0) && (pattern[i] == range[i + j]))
                {
                    if (comparisons)
                    {
                        SetDgvColor(i, Color.Green);
                        this.view.AddStepToLog();
                    }
                    HiglightStep(8);
                    
                    i--;

                    HiglightStep(7);
                    
                }
                if(i >= 0 && pattern[i] != range[i + j] && comparisons)
                {
                    SetDgvColor(i, Color.Red);
                    this.view.AddStepToLog();
                }

                HiglightStep(9);
                
                if (i < 0)
                {
                    HiglightStep(10);                    

                    searchResult.Add(j);
                    if (comparisons)
                    {
                        AddFoundIndex(j, searchResult.Count.ToString());
                    }

                    HiglightStep(11);
                    
                    j += delta1[range[pattern.Length - 1 + j]];
                }
                else
                {
                    HiglightStep(13);
                    
                    j += delta1[range[pattern.Length - 1 + j]];
                }
                HiglightStep(4);
                
            }

            HiglightStep(16);
            
            ChangeControlsState();
            return searchResult;
        }

        protected override int[] ComputeSufix(string pattern, int time)
        {
            throw new NotImplementedException();
        }
    }
}
