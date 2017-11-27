//QuickSearchController.cs
//
//Controller which is responsible for Quick Search algorithm execution.
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
    sealed class QuickSearchController : MainController
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
        /// <param name="view">Current used view handler.</param>
        public QuickSearchController(MainWindow view)
        {
            this.model = new QuickSearch();
            this.view = ((MainWindow)view);

            AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);
        }

        /// <summary>
        /// Method which implements Quick Search searching algorithm which works without any delaying.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user.</param>
        /// <param name="range">It's a text in which the pattern will be searched.</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty.</returns>
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
            ChangeControlsState();

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
                    j += Math.Max(1, delta3[range[pattern.Length - 1 + 1 + j]]);
                }

            }
            ChangeControlsState();
            return searchResult;
        }

        /// <summary>
        /// Method which implements Quick Search searching algorithm which works with delay between next steps. Allows higlighitng of next steps.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user.</param>
        /// <param name="range">It's a text in which the pattern will be searched.</param>
        /// <param name="time"></param>It's delay time between steps</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty.</returns>
        override public List<int> SearchPattern(string pattern, string range, int time)
        {
            List<int> searchResult = new List<int>();
            int[] delta3;
            int j;
            int i;

            this.delayTime = time;

            if ((pattern.Length == 0) || (range.Length == 0))
            {
                return null;
            }
            ChangeControlsState();

            AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);

            this.view.HighlightActualStep(this.view.stepListListBox, 2);
            Delay(this.delayTime);
            j = 0;

            this.view.HighlightActualStep(this.view.stepListListBox, 3);
            Delay(this.delayTime);

            AddParametersToListBox(this.model.GetComputeDelta3Variables(), this.model.GetComputeDelta3StepList(), this.view);
            delta3 = ComputeDelta3(pattern, time);

            AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);

            this.view.HighlightActualStep(this.view.stepListListBox, 4);
            Delay(this.delayTime);
            while (j <= range.Length - pattern.Length)
            {
                this.view.HighlightActualStep(this.view.stepListListBox, 6);
                Delay(this.delayTime);
                i = pattern.Length - 1;

                this.view.HighlightActualStep(this.view.stepListListBox, 7);
                Delay(this.delayTime);
                while ((i >= 0) && (pattern[i] == range[i + j]))
                {
                    this.view.HighlightActualStep(this.view.stepListListBox, 8);
                    Delay(this.delayTime);
                    i--;

                    this.view.HighlightActualStep(this.view.stepListListBox, 7);
                    Delay(this.delayTime);
                }

                this.view.HighlightActualStep(this.view.stepListListBox, 9);
                Delay(this.delayTime);
                if (i < 0)
                {
                    this.view.HighlightActualStep(this.view.stepListListBox, 10);
                    Delay(this.delayTime);
                    searchResult.Add(j);

                    this.view.HighlightActualStep(this.view.stepListListBox, 11);
                    Delay(this.delayTime);
                    j += delta3[range[i + j + 1]];
                }
                else
                {
                    this.view.HighlightActualStep(this.view.stepListListBox, 13);
                    Delay(this.delayTime);
                    j += Math.Max(1, delta3[range[i + j]] - pattern.Length + i);
                }
                this.view.HighlightActualStep(this.view.stepListListBox, 4);
                Delay(this.delayTime);
            }

            this.view.HighlightActualStep(this.view.stepListListBox, 16);
            Delay(this.delayTime);
            ChangeControlsState();
            return searchResult;
        }


        protected override int[] ComputeSufix(string pattern, int time)
        {
            throw new NotImplementedException();
        }
    }
}
