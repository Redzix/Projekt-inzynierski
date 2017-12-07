//BoyerMooreController.cs
//
//Controller which is responsible for Boyer Moore algorithm execution.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using EngineeringProject.View;
using EngineeringProject.Model;
using System.Drawing;
    
namespace EngineeringProject.Controller
{
    sealed class BoyerMooreController : MainController
    {       
        /// <summary>
        /// Constructor which create new model.
        /// </summary>
        public BoyerMooreController()
        {
            this.model = new BoyerMoore();
        }

        /// <summary>
        /// Main constructor. Creates new model and view object. Allows loading variables, steplist to suitable ListBoxes.
        /// </summary>
        /// <param name="view">Current used view handler.</param>
        public BoyerMooreController(MainWindow view)
        {
            this.model = new BoyerMoore();
            this.view = ((MainWindow)view);

            AddParametersToListBox(this.model.GetVariables(),this.model.GetStepList(), this.view);
        }

        /// <summary>
        /// Method which implements Boyer Moore searching algorithm which works without any delaying.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user.</param>
        /// <param name="range">It's a text in which the pattern will be searched.</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty.</returns>
        override public List<int> SearchPattern(string pattern, string range)
        {
            List<int> searchResult = new List<int>();
            int[] delta1;
            int[] delta2;
            int j = 0;
            int i;

            AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);

            if ((pattern.Length == 0) || (range.Length == 0))
            {
                return null;
            }
            ChangeControlsState();

            delta1 = ComputeDelta1(pattern);
            delta2 = ComputeDelta2(pattern);

            while (j <= range.Length - pattern.Length)
            {
                i = pattern.Length - 1;
                while((i >= 0) && (pattern[i] == range[i + j]))
                {
                    i--;
                }

                if (i < 0)
                {
                    searchResult.Add(j);
                    j += delta2[0];
                }
                else
                {
                    j += Math.Max(delta2[i], delta1[range[i + j]] - pattern.Length + i);
                }

            }
            ChangeControlsState();
            return searchResult;
        }
    

        #region searchWithDelay
        /// <summary>
        /// Method which implements Boyer Moore searching algorithm which works with delay between next steps. Allows higlighitng of next steps.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user.</param>
        /// <param name="range">It's a text in which the pattern will be searched.</param>
        /// <param name="time"></param>It's delay time between steps</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty.</returns>
        override public List<int> SearchPattern(string pattern, string range, int time)
        {
            List<int> searchResult = new List<int>();
            int[] delta1;
            int[] delta2;
            int i;
            int j;

            this.delayTime = time;

            if ((pattern.Length == 0) || (range.Length == 0))
            {
                return null;
            }
            ChangeControlsState();

            AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);

            HiglightStep(2);
            
            j = 0;

            HiglightStep(3);
            
            if (this.view.computeDeltaCheckBox.Checked)
            {
                delta1 = ComputeDelta1(pattern, time);

                AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);

                HiglightStep(4);
                

                delta2 = ComputeDelta2(pattern, time);

                AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);
            }
            else
            {
                delta1 = ComputeDelta1(pattern);

                HiglightStep(4);
                

                delta2 = ComputeDelta2(pattern);
            }

            HiglightStep(5);
            
            while (j <= range.Length - pattern.Length)
            {

                this.view.actualStepDataGridView.Rows.Clear();
                this.view.actualStepDataGridView.Rows.Insert(0, Regex.Split(range.Substring(j, (range.Length - j >= 20 ? 20 : range.Length - j)), string.Empty).Skip(1).ToArray());
                this.view.actualStepDataGridView.Rows.Insert(1, Regex.Split(pattern, string.Empty).Skip(1).ToArray());

                HiglightStep(7);
                
                i = pattern.Length - 1;

                HiglightStep(8);
                
                while ((i >= 0) && (pattern[i] == range[i + j]))
                {
                    SetDgvColor(i, Color.Green);
                    this.view.AddStepToLog();

                    HiglightStep(9);
                    
                    i--;

                    HiglightStep(8);
                    
                }

                if ((i >= 0) && (pattern[i] != range[i + j]))
                {
                    SetDgvColor(i, Color.Red);
                    this.view.AddStepToLog();
                }

                    HiglightStep(10);
                
                if (i < 0)
                {
                    HiglightStep(11);
                    
                    searchResult.Add(j);

                    AddFoundIndex(j, searchResult.Count.ToString());

                    HiglightStep(12);
                    
                    j += delta2[0];
                }
                else
                {
                    HiglightStep(14);
                    
                    j += Math.Max(delta2[i], delta1[range[i + j]] - pattern.Length + 1 + i);
                }
                HiglightStep(5);
                
            }
            ChangeControlsState();

            HiglightStep(17);
            
            return searchResult;
        }
               
        #endregion
    }
}
