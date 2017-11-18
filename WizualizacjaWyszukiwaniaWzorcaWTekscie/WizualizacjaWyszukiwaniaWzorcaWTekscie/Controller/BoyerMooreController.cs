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
        //Boyer Moore algorithm model.
        BoyerMoore model;
        
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

            if ((pattern.Length == 0) || (range.Length == 0))
            {
                return null;
            }

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
                    j += Math.Max(delta2[i], delta1[range[i + j]] - pattern.Length + 1 + i);
                }

            }

            return searchResult;
        }       

        /// <summary>
        /// Calculates bad character heuristic
        /// </summary>
        /// /// <param name="pattern">Searched pattern</param>
        /// <returns>Returns array of computed indexes.</returns>
        private int[] ComputeDelta1(string pattern)
        {
            int[] delta1 = new int[alphabetSize];

            for(int i = 0; i < alphabetSize; i++)
            {
                delta1[i] = pattern.Length;
            }

            for(int j =  0; j < pattern.Length; j++)
            {
                delta1[pattern[j]] = pattern.Length - j - 1;
            }

            return delta1;
        }

        /// <summary>
        /// Calculates good sufixex heuristic.
        /// </summary>
        /// <param name="pattern">Searched pattern</param>
        /// <returns>Returns array of computed indexes.</returns>
        public int[] ComputeDelta2(string pattern)
        {
            int[] delta2 = new int[pattern.Length];
            int[] sufix;
            sufix = ComputeSufix(pattern);

            for(int i = 0; i < pattern.Length; i++)
            {
                delta2[i] = pattern.Length;
            }

            for(int i = pattern.Length - 1; i >= 0; i--)
            {
                if(sufix[i] == i + 1)
                {
                    for(int j = 0; j < pattern.Length - 1 - i; j++)
                    {
                        delta2[j] = pattern.Length - 1 - i;
                    }
                }
            }

            for(int i = 0; i < pattern.Length - 1; i++)
            {
                delta2[pattern.Length - 1 - sufix[i]] = pattern.Length - 1 - i;
            }

            return delta2;
        }

        /// <summary>
        /// Calculates suffix table.
        /// </summary>
        /// <param name="pattern">Searched pattern.</param>
        /// <returns>Returns array of sufixes.</returns>
        public int[] ComputeSufix(string pattern)
        {
            int[] sufix = new int[pattern.Length];
            int j;
          
            sufix[pattern.Length - 1] = pattern.Length;

            for (int i = pattern.Length - 2; i >= 0; i--)
            {
                j = 0;
                while ((j <= i) && (pattern[i - j] == pattern[pattern.Length - j - 1]))
                {
                    j++;
                }
                sufix[i] = j;
            }

            return sufix;
        }

        #region searchWithDelay
        /// <summary>
        /// Method which implements Boyer Moore searching algorithm which works with delay between next steps. Allows higlighitng of next steps.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user.</param>
        /// <param name="range">It's a text in which the pattern will be searched.</param>
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

            AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);

            this.view.HighlightActualStep(this.view.stepListListBox, 2);
            Delay(this.delayTime);
            j = 0;

            this.view.HighlightActualStep(this.view.stepListListBox, 3);
            Delay(this.delayTime);
            delta1 = ComputeDelta1(pattern, time);

            AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);

            this.view.HighlightActualStep(this.view.stepListListBox, 4);
            Delay(this.delayTime);
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
            this.view.HighlightActualStep(this.view.stepListListBox, 17);
            Delay(this.delayTime);
            return searchResult;
        }

        /// <summary>
        /// Calculates bad character heuristic ith delaying.
        /// </summary>
        /// <param name="pattern">Searched pattern</param>
        /// <param name="time">Delay time.</param>
        /// <returns>Returns array of computed indexes.</returns>
        private int[] ComputeDelta1(string pattern, int time)
        {
            int[] delta1 = new int[alphabetSize];

            AddParametersToListBox(this.model.GetComputeDelta1Variables(), this.model.GetComputeDelta1StepList(),
                this.view);

            this.view.HighlightActualStep(this.view.stepListListBox, 2);
            Delay(this.delayTime);
            for (int i = 0; i < alphabetSize; i++)
            {
                this.view.HighlightActualStep(this.view.stepListListBox, 3);
                Delay(this.delayTime);
                delta1[i] = pattern.Length;

                this.view.HighlightActualStep(this.view.stepListListBox, 2);
                Delay(this.delayTime);
            }

            this.view.HighlightActualStep(this.view.stepListListBox, 5);
            Delay(this.delayTime);
            for (int j = 0; j < pattern.Length; j++)
            {
                this.view.HighlightActualStep(this.view.stepListListBox, 6);
                Delay(this.delayTime);
                delta1[pattern[j]] = pattern.Length - j - 1;

                this.view.HighlightActualStep(this.view.stepListListBox, 5);
                Delay(this.delayTime);
            }
            this.view.HighlightActualStep(this.view.stepListListBox, 8);
            Delay(this.delayTime);
            return delta1;
        }

        /// <summary>
        /// Calculates good sufix heuristic with delaying.
        /// </summary>
        /// <param name="pattern">Searched pattern</param>
        /// <param name="time">Delay time.</param>
        /// <returns>Returns array of computed indexes.</returns>
        public int[] ComputeDelta2(string pattern, int time)
        {
            int[] delta2 = new int[pattern.Length];
            int[] sufix;

            AddParametersToListBox(this.model.GetComputeDelta2Variables(), this.model.GetComputeDelta2StepList(),
                this.view);

            this.view.HighlightActualStep(this.view.stepListListBox, 2);
            Delay(this.delayTime);
            sufix = ComputeSufix(pattern, time);

            AddParametersToListBox(this.model.GetComputeDelta2Variables(), this.model.GetComputeDelta2StepList(),
               this.view);

            this.view.HighlightActualStep(this.view.stepListListBox, 3);
            Delay(this.delayTime);
            for (int i = 0; i < pattern.Length; i++)
            {
                this.view.HighlightActualStep(this.view.stepListListBox, 4);
                Delay(this.delayTime);
                delta2[i] = pattern.Length;

                this.view.HighlightActualStep(this.view.stepListListBox, 3);
                Delay(this.delayTime);
            }

            this.view.HighlightActualStep(this.view.stepListListBox, 6);
            Delay(this.delayTime);
            for (int i = pattern.Length - 1; i >= 0; i--)
            {
                this.view.HighlightActualStep(this.view.stepListListBox, 7);
                Delay(this.delayTime);
                if (sufix[i] == i + 1)
                {
                    this.view.HighlightActualStep(this.view.stepListListBox, 8);
                    Delay(this.delayTime);
                    for (int j = 0; j < pattern.Length - 1 - i; j++)
                    {
                        this.view.HighlightActualStep(this.view.stepListListBox, 9);
                        Delay(this.delayTime);
                        delta2[j] = pattern.Length - 1 - i;

                        this.view.HighlightActualStep(this.view.stepListListBox, 8);
                        Delay(this.delayTime);
                    }
                }
                this.view.HighlightActualStep(this.view.stepListListBox, 6);
                Delay(this.delayTime);
            }

            this.view.HighlightActualStep(this.view.stepListListBox, 13);
            Delay(this.delayTime);
            for (int i = 0; i < pattern.Length - 1; i++)
            {
                this.view.HighlightActualStep(this.view.stepListListBox, 14);
                Delay(this.delayTime);
                delta2[pattern.Length - 1 - sufix[i]] = pattern.Length - 1 - i;

                this.view.HighlightActualStep(this.view.stepListListBox, 13);
                Delay(this.delayTime);
            }
            this.view.HighlightActualStep(this.view.stepListListBox, 16);
            Delay(this.delayTime);
            return delta2;
        }


        /// <summary>
        /// Calculates suffix table with delaying..
        /// </summary>
        /// <param name="pattern">Searched pattern</param>
        /// <param name="time">Delay time</param>
        /// <returns>Returns array of sufixes</returns>
        public int[] ComputeSufix(string pattern, int time)
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
            return sufix;
        }
        #endregion
    }
}
