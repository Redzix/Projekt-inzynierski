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
    /// <summary>
    /// Controller of Boyer Moore algorithm methods. Implements MainControler class.
    /// </summary>
    public class BoyerMooreController : MainController
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
        /// <param name="view">Current used view handler</param>
        public BoyerMooreController(MainWindow view)
        {
            this.model = new BoyerMoore();
            this.view = ((MainWindow)view);

            AddParametersToListBox(this.model.GetVariables(),this.model.GetStepList(), this.view);
        }

        /// <summary>
        /// Method which implements Boyer Moore searching algorithm which works without any delaying.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user</param>
        /// <param name="range">It's a text in which the pattern will be searched</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty</returns>
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
            this.view.ChangeControlsState();

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
            this.view.ChangeControlsState();
            return searchResult;
        }


        #region searchWithDelay
        /// <summary>
        /// Method which implements Boyer Moore searching algorithm which works with delay between next steps. Allows higlighitng of next steps.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user</param>
        /// <param name="range">It's a text in which the pattern will be searched</param>
        /// <param name="time">Actually set delay time</param>
        /// <param name="comparisons">Enables visualization characters comparing</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty</returns>
        override public List<int> SearchPattern(string pattern, string range, int time, bool comparisons)
        {
            List<int> searchResult = new List<int>();
            int[] delta1;
            int[] delta2;
            int i;
            int j;
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
                if (comparisons)
                {
                    this.view.SetActualStrings(pattern, range, j);
                }
                HiglightStep(7);
                
                i = pattern.Length - 1;

                if(comparisons)
                    this.view.SetCurrentIndexes(i, j + i, sequenceLength);

                HiglightStep(8);
                
                while ((i >= 0) && (pattern[i] == range[i + j]))
                {
                    if (comparisons)
                    {
                        sequenceLength++;
                        this.view.SetCurrentIndexes(i, j + i, sequenceLength);
                        this.view.SetDgvColor(i, Color.Green);
                        this.view.AddStepToLog();
                    }
                    HiglightStep(9);
                    
                    i--;

                    HiglightStep(8);
                    
                }

                if ((i >= 0) && (pattern[i] != range[i + j]) && comparisons)
                {
                    this.view.SetCurrentIndexes(i, j + i, sequenceLength);
                    this.view.SetDgvColor(i, Color.Red);
                    this.view.AddStepToLog();
                }

                    HiglightStep(11);
                
                if (i < 0)
                {
                    HiglightStep(12);
                    
                    searchResult.Add(j);

                    if (comparisons)
                    {
                        this.view.SetCurrentIndexes(0, j, sequenceLength);
                        sequenceLength = 0;
                        this.view.AddFoundIndex(j, searchResult.Count.ToString());
                    }

                    HiglightStep(13);
                    
                    j += delta2[0];
                }
                else
                {
                    HiglightStep(15);
                    
                    j += Math.Max(delta2[i], delta1[range[i + j]] - pattern.Length + 1 + i);
                }
                HiglightStep(5);
                
            }
            this.view.ChangeControlsState();

            HiglightStep(18);
            
            return searchResult;
        }
               
        #endregion
    }
}
