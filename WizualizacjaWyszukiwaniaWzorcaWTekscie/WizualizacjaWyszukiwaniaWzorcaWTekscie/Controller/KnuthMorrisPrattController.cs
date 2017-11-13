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
        //Knuth-Morris-Pratt algorithm model
        KnuthMorrisPratt model;

        //Contructor which create new model
        public KnuthMorrisPrattController()
        {
            this.model = new KnuthMorrisPratt();
        }

        /// <summary>
        ///Main constructor. Creates new model and view object. Allows loading variables, steplist to suitable ListBoxes.
        /// </summary>
        /// <param name="view">Current used view handler.</param>
        public KnuthMorrisPrattController(MainWindow view)
        {
            this.model = new KnuthMorrisPratt();
            this.view = view;

            this.view.LoadToListbox(this.view.stepListListBox, this.model.GetStepList());
            this.view.LoadToListbox(this.view.variablesListBox, this.model.GetVariables());
            this.delayTime = Int32.Parse(this.view.delayTimeComboBox.Text);
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
            int[] nextArray = GenerateNextArray(pattern, pattern.Length);

            while (((m + i) < range.Length))
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
            int[] nextArray = GenerateNextArray(pattern, pattern.Length);

            while (((m + i) < range.Length))
            {
                if ((pattern[i] == range[m + i]) && !was)
                {
                    if (i == pattern.Length - 1)
                    {
                        searchResult.Add(m);
                        was = true;
                    }
                    else
                    {
                        if (!was)
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

            return searchResult;
        }

        /// <summary>
        /// Creates new KMPNext table which contains number of steps which are made if the characters doesn't fit.
        /// </summary>
        /// <param name="pattern">Searching string pattern.</param>
        /// <param name="patternLength">Length of pattern.</param>
        /// <returns></returns>
        private int[] GenerateNextArray(string pattern, int patternLength)
        {
            int[] nextArray = new int[patternLength];
            int j = 0, i = 1;
            nextArray[0] = 0;
            
            while(i < patternLength)
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
            }

            return nextArray;
        }
    }
}
