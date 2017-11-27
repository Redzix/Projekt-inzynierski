//KnuthMorrisPrattController.cs
//
//Controller which is responsible for Knuth-Morris-Pratt algorithm execution.
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
    sealed class KnuthMorrisPrattController : MainController
    {
        /// <summary>
        /// Constructor which create new model. 
        /// </summary>
        public KnuthMorrisPrattController()
        {
            this.model = new KnuthMorrisPratt();
        }

        /// <summary>
        /// Main constructor. Creates new model and view object. Allows loading variables, steplist to suitable ListBoxes.
        /// </summary>
        /// <param name="view">Current used view handler.</param>
        public KnuthMorrisPrattController(MainWindow view)
        {
            this.model = new KnuthMorrisPratt();
            this.view = ((MainWindow)view); ;

            AddParametersToListBox(this.model.GetVariables(),this.model.GetStepList(), this.view);
        }

        /// <summary>
        /// Method which implements Knuth-Morris-Pratt searching algorithm which works without any delaying.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user.</param>
        /// <param name="range">It's a text in which the pattern will be searched.</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty.</returns>
        override public List<int> SearchPattern(string pattern, string range)
        {
            List<int> searchResult = new List<int>();
            int i = 0, m = 0;
            bool was = false;
            

            AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);

            if ((pattern.Length == 0) || (range.Length == 0))
            {
                return null;
            }
            ChangeControlsState();

            int[] nextArray = GenerateNextArray(pattern, pattern.Length);
            
            while (m + i < range.Length)
            {
                if ((pattern[i] == range[m + i]) && !was)
                {
                    if (i == pattern.Length - 1)
                    {
                        searchResult.Add(m);
                        was = true;
                    }
                    else
                    {  if(!was)
                            i++;
                    }
                }
                else
                {
                    was = false;
                    m = m + 1 - nextArray[i];
                    if (nextArray[i] > -1)
                    {
                        i = nextArray[i];
                    }
                    else
                    {
                        i = 0;
                    }
                }
            }

            ChangeControlsState();
            return searchResult;
        }

        /// <summary>
        /// Method which implements Knuth-Morris-Pratt searching algorithm which works with delay between next steps. Allows higlighitng of next steps.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user.</param>
        /// <param name="range">It's a text in which the pattern will be searched.</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty.</returns>
        override public List<int> SearchPattern(string pattern, string range, int time)
        {
            List<int> searchResult = new List<int>();
            int i = 0, m = 0;
            bool was = false;

            this.delayTime = time;

            if ((pattern.Length == 0) || (range.Length == 0))
            {
                return null;
            }

            ChangeControlsState();

            this.view.HighlightActualStep(this.view.stepListListBox, 2);
            Delay(this.delayTime);
            int[] nextArray = GenerateNextArray(pattern, pattern.Length,this.delayTime);

            AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);

            this.view.HighlightActualStep(this.view.stepListListBox, 3);
            Delay(this.delayTime);
            while (((m + i) < range.Length))
            {
                this.view.HighlightActualStep(this.view.stepListListBox, 5);
                Delay(this.delayTime);
                if ((pattern[i] == range[m + i]) && !was)
                {
                    this.view.HighlightActualStep(this.view.stepListListBox, 6);
                    Delay(this.delayTime);
                    if (i == pattern.Length - 1)
                    {
                        this.view.HighlightActualStep(this.view.stepListListBox, 7);
                        Delay(this.delayTime);
                        searchResult.Add(m);

                        this.view.HighlightActualStep(this.view.stepListListBox, 8);
                        Delay(this.delayTime);
                        was = true;
                    }
                    else
                    {
                        this.view.HighlightActualStep(this.view.stepListListBox, 10);
                        Delay(this.delayTime);
                        if (!was)
                            this.view.HighlightActualStep(this.view.stepListListBox, 11);
                            Delay(this.delayTime);
                            i++;
                    }
                }
                else
                {
                    this.view.HighlightActualStep(this.view.stepListListBox, 13);
                    Delay(this.delayTime);
                    was = false;

                    this.view.HighlightActualStep(this.view.stepListListBox, 14);
                    Delay(this.delayTime);
                    m = m + 1 - nextArray[i];

                    this.view.HighlightActualStep(this.view.stepListListBox, 15);
                    Delay(this.delayTime);
                    if (nextArray[i] > -1)
                    {
                        this.view.HighlightActualStep(this.view.stepListListBox, 16);
                        Delay(this.delayTime);
                        i = nextArray[i];
                    }
                    else
                    {
                        this.view.HighlightActualStep(this.view.stepListListBox, 18);
                        Delay(this.delayTime);
                        i = 0;
                    }
                }
            }

            ChangeControlsState();
            this.view.HighlightActualStep(this.view.stepListListBox, 20);
            Delay(this.delayTime);
            return searchResult;
        }

        /// <summary>
        /// Creates new KMPNext table which contains number of steps which are made if the characters doesn't fit.
        /// </summary>
        /// <param name="pattern">Searching string pattern.</param>
        /// <param name="patternLength">Length of pattern.</param>
        /// <returns>Table of indexes</returns>
        private int[] GenerateNextArray(string pattern, int patternLength)
        {
            int[] nextArray = new int[patternLength];
            int j = 0, i = 1;
            nextArray[0] = 0;
            
            while(i < patternLength)
            {
                while(j > 0 && pattern[i] != pattern[j])
                {
                    j = nextArray[j - 1];
                }
                i++;
                j++;
                if(pattern[j - 1] == pattern[i - 1])
                {
                    nextArray[i - 1] = nextArray[j - 1];
                }
                else
                {
                    nextArray[i - 1] = j - 1;
                }
            }


            /*while (i < patternLength)
            {
                if (pattern[i] == pattern[j])
                {
                    nextArray[i] = j + 1;
                    j++;
                    i++;
                }
                else
                {
                    if (j != 0)
                    {
                        j = nextArray[j - 1];
                    }
                    else
                    {
                        nextArray[i] = 0;
                        i++;
                    }
                }
            }*/

            return nextArray;
        }

        /// <summary>
        /// Creates new KMPNext table which contains number of steps which are made if the characters doesn't fit.
        /// </summary>
        /// <param name="pattern">Searching string pattern.</param>
        /// <param name="patternLength">Length of pattern.</param>
        /// <param name="time">Delay time</param>
        /// <returns>Table of indexes</returns>
        private int[] GenerateNextArray(string pattern, int patternLength, int time)
        {
            int[] nextArray = new int[patternLength];
            int j = 0, i = 1;

            AddParametersToListBox(this.model.GetNextArrayVariables(), this.model.GetNextArrayStepList(), this.view);

            this.view.HighlightActualStep(this.view.stepListListBox, 2);
            Delay(this.delayTime);
            nextArray[0] = 0;

            this.view.HighlightActualStep(this.view.stepListListBox, 3);
            Delay(this.delayTime);
            while (i < patternLength)
            {
                this.view.HighlightActualStep(this.view.stepListListBox, 5);
                Delay(this.delayTime);
                while (j > 0 && pattern[i] != pattern[j])
                {
                    this.view.HighlightActualStep(this.view.stepListListBox, 6);
                    Delay(this.delayTime);
                    j = nextArray[j - 1];

                    this.view.HighlightActualStep(this.view.stepListListBox, 5);
                    Delay(this.delayTime);
                }
                this.view.HighlightActualStep(this.view.stepListListBox, 7);
                Delay(this.delayTime);
                i++;

                this.view.HighlightActualStep(this.view.stepListListBox, 8);
                Delay(this.delayTime);
                j++;

                this.view.HighlightActualStep(this.view.stepListListBox, 9);
                Delay(this.delayTime);
                if (pattern[j - 1] == pattern[i - 1])
                {
                    this.view.HighlightActualStep(this.view.stepListListBox, 10);
                    Delay(this.delayTime);
                    nextArray[i - 1] = nextArray[j - 1];
                }
                else
                {
                    this.view.HighlightActualStep(this.view.stepListListBox, 12);
                    Delay(this.delayTime);
                    nextArray[i - 1] = j - 1;
                }
                this.view.HighlightActualStep(this.view.stepListListBox, 3);
                Delay(this.delayTime);
            }
            this.view.HighlightActualStep(this.view.stepListListBox, 15);
            Delay(this.delayTime);
            return nextArray;
/*
            this.view.HighlightActualStep(this.view.stepListListBox, 3);
            Delay(this.delayTime);
            while (i < patternLength)
            {
                this.view.HighlightActualStep(this.view.stepListListBox, 5);
                Delay(this.delayTime);
                if (pattern[i] == pattern[j])
                {
                    this.view.HighlightActualStep(this.view.stepListListBox, 6);
                    Delay(this.delayTime);
                    nextArray[i] = j + 1;

                    this.view.HighlightActualStep(this.view.stepListListBox, 7);
                    Delay(this.delayTime);
                    j++;

                    this.view.HighlightActualStep(this.view.stepListListBox, 8);
                    Delay(this.delayTime);
                    i++;
                }
                else
                {
                    this.view.HighlightActualStep(this.view.stepListListBox, 10);
                    Delay(this.delayTime);
                    if (j != 0)
                    {
                        this.view.HighlightActualStep(this.view.stepListListBox, 11);
                        Delay(this.delayTime);
                        j = nextArray[j - 1];
                    }
                    else
                    {
                        this.view.HighlightActualStep(this.view.stepListListBox, 13);
                        Delay(this.delayTime);
                        nextArray[i] = 0;

                        this.view.HighlightActualStep(this.view.stepListListBox, 14);
                        Delay(this.delayTime);
                        i++;
                    }
                }
            }

            this.view.HighlightActualStep(this.view.stepListListBox, 16);
            Delay(this.delayTime);
            return nextArray;*/
        }

         protected override int[] ComputeSufix(string pattern, int time)
        {
            throw new NotImplementedException();
        }
    }
}
