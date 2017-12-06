//RaitaController.cs
//
//Controller which is responsible for Raita algorithm execution.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineeringProject.View;
using EngineeringProject.Model;

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

            this.view.LoadToListbox(this.view.stepListListBox, this.model.GetStepList());
            this.view.LoadToListbox(this.view.variablesListBox, this.model.GetVariables());
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
            this.view.HighlightActualStep(this.view.stepListListBox, 2);
            this.Delay(this.delayTime);
            j = 0;

            this.view.HighlightActualStep(this.view.stepListListBox, 3);
            this.Delay(this.delayTime);
            if (this.view.computeDeltaCheckBox.Checked)
            {
                delta1 = ComputeDelta1(pattern);

                AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);
            }
            else
            {
                delta1 = ComputeDelta1(pattern);
            }

            this.view.HighlightActualStep(this.view.stepListListBox, 4);
            this.Delay(this.delayTime);
            while (j <= range.Length - pattern.Length)
            {
                this.view.HighlightActualStep(this.view.stepListListBox, 6);
                this.Delay(this.delayTime);
                if ((pattern[pattern.Length - 1] == range[j + pattern.Length - 1]) && (pattern[0] == range[j]) &&
                    (pattern[pattern.Length / 2] == range[j + pattern.Length / 2]))
                {
                    this.view.HighlightActualStep(this.view.stepListListBox, 8);
                    this.Delay(this.delayTime);
                    i = pattern.Length - 2;

                    this.view.HighlightActualStep(this.view.stepListListBox, 9);
                    this.Delay(this.delayTime);
                    while ((i > 0) && (pattern[i] == range[i + j]))
                    {
                        this.view.HighlightActualStep(this.view.stepListListBox, 10);
                        this.Delay(this.delayTime);
                        i--;

                        this.view.HighlightActualStep(this.view.stepListListBox, 9);
                        this.Delay(this.delayTime);
                    }

                    this.view.HighlightActualStep(this.view.stepListListBox, 12);
                    this.Delay(this.delayTime);
                    if (i == 0)
                    {
                        this.view.HighlightActualStep(this.view.stepListListBox, 13);
                        this.Delay(this.delayTime);
                        searchResult.Add(j);
                    }
                }
                this.view.HighlightActualStep(this.view.stepListListBox, 16);
                this.Delay(this.delayTime);
                j += delta1[range[pattern.Length - 1 + j]];

                this.view.HighlightActualStep(this.view.stepListListBox, 4);
                this.Delay(this.delayTime);
            }
            ChangeControlsState();
            this.view.HighlightActualStep(this.view.stepListListBox, 18);
            this.Delay(this.delayTime);
            return searchResult; ;
        }
 
        protected override int[] ComputeSufix(string pattern, int time)
        {
            throw new NotImplementedException();
        }

    }
}
