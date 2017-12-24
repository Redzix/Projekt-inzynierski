//QuickSearchController.cs
//
//Controller which is responsible for Quick Search algorithm execution.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EngineeringProject.View;
using EngineeringProject.Model;
using System.Drawing;

namespace EngineeringProject.Controller
{
    /// <summary>
    /// Controller of quick Search algorithm methods. Implements MainControler class.
    /// </summary>
    public class QuickSearchController : MainController
    {
        /// <summary>
        /// Constructor which create new model.
        /// </summary>
        public QuickSearchController()
        {
            this.model = new QuickSearch();
        }

        /// <summary>
        /// Main constructor. Creates new model and view object. Allows loading variables, steplist to suitable ListBoxes.
        /// </summary>
        /// <param name="view">Current used view handler</param>
        public QuickSearchController(MainWindow view)
        {
            this.model = new QuickSearch();
            this.view = ((MainWindow)view);

            AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);
        }

        /// <summary>
        /// Method which implements Quick Search searching algorithm which works without any delaying.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user</param>
        /// <param name="range">It's a text in which the pattern will be searched</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty</returns>
        override public List<int> SearchPattern(string pattern, string range)
        {
            List<int> searchResult = new List<int>();
            int[] delta3;
            int j = 0;
            int i;

            if ((pattern.Length == 0) || (range.Length == 0))
            {
                return null;
            }
            this.view.ChangeControlsState();

            AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);

            delta3 = ComputeDelta3(pattern);

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
                    j += delta3[range[pattern.Length - 1 + j]];
                }
                else
                {
                    j += Math.Max(1, delta3[range[i + j]] - pattern.Length - 1 + i);
                }

            }
            this.view.ChangeControlsState();
            return searchResult;
        }

        /// <summary>
        /// Method which implements Quick Search searching algorithm which works with delay between next steps. Allows higlighitng of next steps.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user</param>
        /// <param name="range">It's a text in which the pattern will be searched</param>
        /// <param name="time">Actually set delay time</param>
        /// <param name="comparisons">Enables visualisation characters comparing</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty</returns>
        override public List<int> SearchPattern(string pattern, string range, int time, bool comparisons)
        {
            List<int> searchResult = new List<int>();
            int[] delta3;
            int j;
            int i;
            int sequenceLength = 0;

            this.delayTime = time;

            if ((pattern.Length == 0) || (range.Length == 0))
            {
                return null;
            }
            this.view.ChangeControlsState();

            AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);

            HiglightStep(2);
            
            j = 0;

            HiglightStep(3);
            
            if (this.view.computeDeltaCheckBox.Checked)
            {
                delta3 = ComputeDelta3(pattern, time);
                AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);
            }
            else
            {
                delta3 = ComputeDelta3(pattern);
            }


            HiglightStep(4);
            
            while (j <= range.Length - pattern.Length)
            {
                if (comparisons)
                {                    
                    this.view.SetActualStrings(pattern, range, j);
                }

                HiglightStep(6);
                
                i = pattern.Length - 1;

                if(comparisons)
                    this.view.SetCurrentIndexes(i, i + j, sequenceLength);

                HiglightStep(7);
                
                while ((i >= 0) && (pattern[i] == range[i + j]))
                {
                    if (comparisons)
                    {
                        sequenceLength++;
                        this.view.SetCurrentIndexes(i, i + j, sequenceLength);
                        this.view.SetDgvColor(i, Color.Green);
                        this.view.AddStepToLog();
                    }

                    HiglightStep(8);
                    
                    i--;

                    HiglightStep(7);
                    
                }

                if ((comparisons) && (i >= 0) && (pattern[i] != range[i + j]))
                {
                    this.view.SetCurrentIndexes(i, i + j, sequenceLength);
                    this.view.SetDgvColor(i, Color.Red);
                    this.view.AddStepToLog();
                }
                HiglightStep(9);
                
                if (i < 0)
                {
                    HiglightStep(10);
                    
                    searchResult.Add(j);
                    if (comparisons)
                    {
                        this.view.SetCurrentIndexes(0, i + j, sequenceLength);
                        sequenceLength = 0;
                        this.view.AddFoundIndex(j, searchResult.Count.ToString());
                    }
                    HiglightStep(11);
                    
                    j += delta3[range[pattern.Length - 1 + j]];
                }
                else
                {
                    HiglightStep(13);
                    
                    j += Math.Max(1, delta3[range[i + j]] - pattern.Length  - 1 + i);
                }
                HiglightStep(4);
                
            }

            HiglightStep(16);
            
            this.view.ChangeControlsState();
            return searchResult;
        }

        /// <summary>
        /// Not implemented dompute sufix method.
        /// </summary>
        /// <param name="pattern">PAttern</param>
        /// <param name="time">Delay time</param>
        /// <returns>None</returns>
        protected override int[] ComputeSufix(string pattern, int time)
        {
            throw new NotImplementedException();
        }
    }
}
