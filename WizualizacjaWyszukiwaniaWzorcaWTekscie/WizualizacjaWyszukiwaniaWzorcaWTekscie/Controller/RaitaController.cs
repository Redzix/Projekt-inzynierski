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
    sealed class RaitaController : MainController
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
        /// <param name="view">Current used view handler.</param>
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
        /// <param name="pattern">It's a search pattern given by user.</param>
        /// <param name="range">It's a text in which the pattern will be searched.</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty.</returns>
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
            ChangeControlsState();

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
            ChangeControlsState();
            return searchResult;
        }

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
            int j;
            int i = 0;

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
                this.view.actualStepDataGridView.Rows.Clear();
                this.view.actualStepDataGridView.Rows.Insert(0, Regex.Split(range.Substring(j, (range.Length - j >= 20 ? 20 : range.Length - j)), string.Empty).Skip(1).ToArray());
                this.view.actualStepDataGridView.Rows.Insert(1, Regex.Split(pattern, string.Empty).Skip(1).ToArray());

                HiglightStep(6);
                
                if ((pattern[pattern.Length - 1] == range[pattern.Length - 1]) && (pattern[0] == range[j]) &&
                    (pattern[pattern.Length / 2] == range[pattern.Length / 2]))
                {
                    this.view.actualStepDataGridView.Rows[0].Cells[pattern.Length - 1].Style.BackColor = Color.Green;
                    this.view.actualStepDataGridView.Rows[0].Cells[0].Style.BackColor = Color.Green;
                    this.view.actualStepDataGridView.Rows[0].Cells[pattern.Length / 2].Style.BackColor = Color.Green;

                    this.view.actualStepDataGridView.Rows[1].Cells[pattern.Length - 1].Style.BackColor = Color.Green;
                    this.view.actualStepDataGridView.Rows[1].Cells[0].Style.BackColor = Color.Green;
                    this.view.actualStepDataGridView.Rows[1].Cells[pattern.Length / 2].Style.BackColor = Color.Green;

                    this.view.AddStepToLog();

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
                        SetDgvColor(i, Color.Green);
                        this.view.AddStepToLog();

                        HiglightStep(10);
                        
                        i--;

                        HiglightStep(9);
                    }

                    if ((i > 0) && (pattern[i] != range[i + j]))
                    {
                        SetDgvColor(i, Color.Green);
                        this.view.AddStepToLog();
                    }

                    HiglightStep(12);

                    if (i == 0)
                    {
                        HiglightStep(13);

                        searchResult.Add(j);

                        AddFoundIndex(j, searchResult.Count.ToString());
                    }
                }
                else
                {


                    if (pattern[pattern.Length - 1] != range[pattern.Length - 1])
                    {
                        SetDgvColor(pattern.Length - 1, Color.Red);
                    }
                    else
                    {
                        SetDgvColor(pattern.Length - 1, Color.Green);
                    }
                    if (pattern[0] == range[j])
                    {
                        SetDgvColor(0, Color.Red);
                    }
                    else
                    {
                        SetDgvColor(0, Color.Green);
                    }
                    if (pattern[pattern.Length / 2] == range[pattern.Length / 2])
                    {
                        SetDgvColor(pattern.Length / 2, Color.Red);
                    }
                    else
                    {
                        SetDgvColor(pattern.Length / 2, Color.Green);
                    }


                    this.view.AddStepToLog();
                }

                HiglightStep(16);

                j += delta1[range[pattern.Length - 1 + j]];

                HiglightStep(4);
            }

            ChangeControlsState();
            HiglightStep(18);
            return searchResult; ;
        }
 
        protected override int[] ComputeSufix(string pattern, int time)
        {
            throw new NotImplementedException();
        }

    }
}
