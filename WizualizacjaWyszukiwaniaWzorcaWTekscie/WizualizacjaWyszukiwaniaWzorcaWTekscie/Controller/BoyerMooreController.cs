//BoyerMooreController.cs
//
//Controller which is responsible for Boyer Moore algorithm execution.
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

            this.view.HighlightActualStep(this.view.stepListListBox, 2);
            Delay(this.delayTime);
            j = 0;

            this.view.HighlightActualStep(this.view.stepListListBox, 3);
            Delay(this.delayTime);

            AddParametersToListBox(this.model.GetComputeDelta1Variables(), this.model.GetComputeDelta1StepList(),
                this.view);
            delta1 = ComputeDelta1(pattern, time);

            AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);

            this.view.HighlightActualStep(this.view.stepListListBox, 4);
            Delay(this.delayTime);


            AddParametersToListBox(this.model.GetComputeDelta2Variables(), this.model.GetComputeDelta2StepList(),
                this.view);
            delta2 = ComputeDelta2(pattern, time);

            AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);

            this.view.HighlightActualStep(this.view.stepListListBox, 5);
            Delay(this.delayTime);
            while (j <= range.Length - pattern.Length)
            {
                this.view.HighlightActualStep(this.view.stepListListBox, 7);
                Delay(this.delayTime);
                i = pattern.Length - 1;

                this.view.HighlightActualStep(this.view.stepListListBox, 8);
                Delay(this.delayTime);
                while ((i >= 0) && (pattern[i] == range[i + j]))
                {
                    this.view.HighlightActualStep(this.view.stepListListBox, 9);
                    Delay(this.delayTime);
                    i--;

                    this.view.HighlightActualStep(this.view.stepListListBox, 8);
                    Delay(this.delayTime);
                }

                this.view.HighlightActualStep(this.view.stepListListBox, 10);
                Delay(this.delayTime);
                if (i < 0)
                {
                    this.view.HighlightActualStep(this.view.stepListListBox, 11);
                    Delay(this.delayTime);
                    searchResult.Add(j);

                    this.view.HighlightActualStep(this.view.stepListListBox, 12);
                    Delay(this.delayTime);
                    j += delta2[0];
                }
                else
                {
                    this.view.HighlightActualStep(this.view.stepListListBox, 14);
                    Delay(this.delayTime);
                    j += Math.Max(delta2[i], delta1[range[i + j]] - pattern.Length + 1 + i);
                }
                this.view.HighlightActualStep(this.view.stepListListBox, 5);
                Delay(this.delayTime);
            }
            ChangeControlsState();

            this.view.HighlightActualStep(this.view.stepListListBox, 17);
            Delay(this.delayTime);
            return searchResult;
        }

        /// <summary>
        /// Calculates suffix table with delaying..
        /// </summary>
        /// <param name="pattern">Searched pattern</param>
        /// <param name="time">Delay time</param>
        /// <returns>Returns array of sufixes</returns>
        protected override int[] ComputeSufix(string pattern, int time)
        {
            int[] sufix = new int[pattern.Length];
            int j;

            AddParametersToListBox(this.model.GetComputeSufixVariables(), this.model.GetComputeSufixStepList(), this.view);

            this.view.HighlightActualStep(this.view.stepListListBox, 2);
            Delay(this.delayTime);
            sufix[pattern.Length - 1] = pattern.Length;

            this.view.HighlightActualStep(this.view.stepListListBox, 3);
            Delay(this.delayTime);
            for (int i = pattern.Length - 2; i >= 0; i--)
            {
                this.view.HighlightActualStep(this.view.stepListListBox, 4);
                Delay(this.delayTime);
                j = 0;

                this.view.HighlightActualStep(this.view.stepListListBox, 5);
                Delay(this.delayTime);
                while ((j <= i) && (pattern[i - j] == pattern[pattern.Length - j - 1]))
                {
                    this.view.HighlightActualStep(this.view.stepListListBox, 6);
                    Delay(this.delayTime);
                    j++;

                    this.view.HighlightActualStep(this.view.stepListListBox, 5);
                    Delay(this.delayTime);
                }
                this.view.HighlightActualStep(this.view.stepListListBox, 7);
                Delay(this.delayTime);
                sufix[i] = j;

                this.view.HighlightActualStep(this.view.stepListListBox, 3);
                Delay(this.delayTime);
            }
            this.view.HighlightActualStep(this.view.stepListListBox, 9);
            Delay(this.delayTime);

            AddParametersToListBox(this.model.GetComputeDelta1Variables(), this.model.GetComputeDelta1StepList(),
                this.view);
            return sufix;
        }
        #endregion
    }
}
