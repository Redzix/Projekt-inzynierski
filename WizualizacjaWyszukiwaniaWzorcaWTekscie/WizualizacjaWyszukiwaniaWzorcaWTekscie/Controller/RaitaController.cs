//RaitaController.cs
//
//Controller which is responsible for Raita algorithm execution.
//

using System;
using System.Collections.Generic;
using System.Linq;
using EngineeringProject.View;
using EngineeringProject.Model;
using System.Text.RegularExpressions;
using System.Drawing;

namespace EngineeringProject.Controller
{
    /// <summary>
    /// Controller of Raita algorithm methods. Implements MainControler class.
    /// </summary>
    public class RaitaController : MainController
    {
        /// <summary>
        /// Constructor which create new model.
        /// </summary>
        public RaitaController()
        {
            this.model = new Raita();
        }

        /// <summary>
        /// Main constructor. Creates new model and view object. Allows loading variables, steplist to suitable ListBoxes.
        /// </summary>
        /// <param name="view">Current used view handler</param>
        public RaitaController(MainWindow view)
        {
            this.model = new Raita();
            this.view = view;
            
            AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);
            this.delayTime = Int32.Parse(this.view.delayTimeComboBox.Text);
        }

        /// <summary>
        /// Method which implements Raita searching algorithm which works without any delaying.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user</param>
        /// <param name="range">It's a text in which the pattern will be searched</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty</returns>
        override public List<int> SearchPattern(string pattern, string range)
        {
            List<int> searchResult = new List<int>();
            int[] delta1;
            int j = 0;
            int i = 0;

            if ((pattern.Length == 0) || (range.Length == 0))
            {
                return null;
            }
            this.view.ChangeControlsState();

            AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);

            delta1 = ComputeDelta1(pattern);
            while (j <= range.Length - pattern.Length)
            {

                if ((pattern[pattern.Length - 1] == range[j + pattern.Length - 1]) && (pattern[0] == range[j]) &&
                    (pattern[pattern.Length / 2] == range[j + pattern.Length / 2]))
                {
                    if (pattern.Length == 1)
                    {
                        i = 0;
                    }
                    else
                    {
                        i = pattern.Length - 2;
                    }
                    while ((i > 0) && (pattern[i] == range[i + j]))
                    {
                        i--;
                    }

                    if (i == 0)
                    {
                        searchResult.Add(j);
                    }
                }
                j += delta1[range[pattern.Length - 1 + j]];
            }
            this.view.ChangeControlsState();
            return searchResult;
        }

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
            int j;
            int i = 0;
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
                delta1 = ComputeDelta1(pattern);

                AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);
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
                    this.view.SetCurrentIndexes(0, j, sequenceLength);
                    this.view.SetActualStrings(pattern, range, j);
                }

                HiglightStep(6);

                if ((pattern[pattern.Length - 1] == range[j + pattern.Length - 1]) && (pattern[0] == range[j]) &&
                   (pattern[pattern.Length / 2] == range[j + pattern.Length / 2]))
                {
                    if (comparisons)
                    {
                        sequenceLength = 3;
                        this.view.SetCurrentIndexes(0, 0, sequenceLength);
                        this.view.SetMultipleActualStepHiglight(Color.Green, 0, pattern.Length - 1, 0, pattern.Length / 2);
                        this.view.SetMultipleActualStepHiglight(Color.Red, 1, pattern.Length - 1, 0, pattern.Length / 2);

                        this.view.AddStepToLog();
                    }
                    HiglightStep(8);
                   
                    if (pattern.Length == 3)
                    {
                        i = 0;
                    }
                    else
                    {
                        i = pattern.Length - 2;
                    }

                    HiglightStep(9);
                    
                    while ((i > 0) && (pattern[i] == range[i + j]))
                    {
                        if (comparisons)
                        {
                            sequenceLength++;
                            this.view.SetCurrentIndexes(i,i + j, sequenceLength);
                            this.view.SetDgvColor(i, Color.Green);
                            this.view.AddStepToLog();
                        }

                        HiglightStep(10);
                        
                        i--;

                        HiglightStep(9);
                    }
                    if ((comparisons) && (i > 0) && (pattern[i] != range[i + j]))
                    {
                            this.view.SetCurrentIndexes(i,i + j, sequenceLength);
                            this.view.SetDgvColor(i, Color.Green);
                            this.view.AddStepToLog();
                    }
                    
                    HiglightStep(12);

                    if (i == 0)
                    {
                        HiglightStep(13);

                        searchResult.Add(j);
                        if (comparisons)
                        {
                            this.view.SetCurrentIndexes(i, i + j, sequenceLength);
                            sequenceLength = 0;
                            this.view.AddFoundIndex(j, searchResult.Count.ToString());
                        }
                    }
                }
                else
                {

                    if (comparisons)
                    {
                        if (pattern[pattern.Length - 1] != range[j + pattern.Length - 1])
                        {
                            this.view.SetDgvColor(pattern.Length - 1, Color.Red);
                        }
                        else
                        {
                            this.view.SetDgvColor(pattern.Length - 1, Color.Green);
                        }
                        if (pattern[0] != range[j])
                        {
                            this.view.SetDgvColor(0, Color.Red);
                        }
                        else
                        {
                            this.view.SetDgvColor(0, Color.Green);
                        }
                        if (pattern[pattern.Length / 2] != range[j +pattern.Length / 2])
                        {
                            this.view.SetDgvColor(pattern.Length / 2, Color.Red);
                        }
                        else
                        {
                            this.view.SetDgvColor(pattern.Length / 2, Color.Green);
                        }


                        this.view.AddStepToLog();
                    }
                }

                HiglightStep(16);

                j += delta1[range[pattern.Length - 1 + j]];

                HiglightStep(4);
            }

            this.view.ChangeControlsState();
            HiglightStep(18);
            return searchResult; ;
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
