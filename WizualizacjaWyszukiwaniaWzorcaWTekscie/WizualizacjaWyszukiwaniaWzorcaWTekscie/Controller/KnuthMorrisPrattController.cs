//KnuthMorrisPrattController.cs
//
//Controller which is responsible for Knuth-Morris-Pratt algorithm execution.
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
    /// Controller of Knuth Morris Pratt algorithm methods. Implements MainControler class.
    /// </summary>
    public class KnuthMorrisPrattController : MainController
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
        /// <param name="view">Current used view handler</param>
        public KnuthMorrisPrattController(MainWindow view)
        {
            this.model = new KnuthMorrisPratt();
            this.view = ((MainWindow)view); ;

            AddParametersToListBox(this.model.GetVariables(),this.model.GetStepList(), this.view);
        }

        /// <summary>
        /// Method which implements Knuth-Morris-Pratt searching algorithm which works without any delaying.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user</param>
        /// <param name="range">It's a text in which the pattern will be searched</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty</returns>
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
            this.view.ChangeControlsState();

            int[] nextArray = GenerateNextArray(pattern, pattern.Length);

            while (m + i < range.Length)
            {
                if ((pattern[i] == range[m + i]) && !was)
                {
                    if (i == pattern.Length - 1)
                    {
                        searchResult.Add(m);
                        m++;
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

            this.view.ChangeControlsState();
            return searchResult;
        }

        /// <summary>
        /// Method which implements Knuth-Morris-Pratt searching algorithm which works with delay between next steps. Allows higlighitng of next steps.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user</param>
        /// <param name="range">It's a text in which the pattern will be searched</param>
        /// <param name="time">Actually set delay time</param>
        /// <param name="comparisons">Enables visualisation characters comparing</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty</returns>
        override public List<int> SearchPattern(string pattern, string range, int time, bool comparisons)
        {
            List<int> searchResult = new List<int>();
            int i = 0, m = 0;
            bool was = false;
            int[] nextArray;
            int sequenceLength = 0;

            this.delayTime = time;

            if ((pattern.Length == 0) || (range.Length == 0))
            {
                return null;
            }

            this.view.ChangeControlsState();

            HiglightStep(2);
            
            if (this.view.computeDeltaCheckBox.Checked)
            {
                nextArray = GenerateNextArray(pattern, pattern.Length, this.delayTime);
                AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);
            }
            else
            {
                nextArray = GenerateNextArray(pattern, pattern.Length);
            }

            if (comparisons)
            {
                this.view.SetActualStrings(pattern, range, m);
            }

            HiglightStep(3);
            
            while ((m + i < range.Length))
            {                  
                HiglightStep(5);
                
                if ((pattern[i] == range[m + i]) && !was)
                {
                    if (comparisons)
                    {
                        sequenceLength++;
                        this.view.SetCurrentIndexes(i, m + i, sequenceLength);
                        this.view.SetDgvColor(i, Color.Green);
                        this.view.AddStepToLog();
                    }
                    HiglightStep(6);
                    
                    if (i == pattern.Length - 1)
                    {
                        HiglightStep(7);
                        
                        searchResult.Add(m);

                        if (comparisons)
                        {
                            this.view.SetCurrentIndexes(i, m + i, sequenceLength);
                            sequenceLength = 0;
                            this.view.AddFoundIndex(m, searchResult.Count.ToString());
                        }
                        HiglightStep(8);
                        
                        
                        was = true;
                        if (comparisons)
                        {
                            this.view.SetActualStrings(pattern, range, m);                 
                            this.view.SetCurrentIndexes(0, m + i, sequenceLength);
                        }
                        if (m + i == range.Length - 1) break;
                    }
                    else
                    {
                        HiglightStep(10);
                        
                        if (!was)
                        {
                            HiglightStep(11);
                            
                            i++;
                        }
                    }
                    
                }
                else
                {
                    if (range.Length - m == pattern.Length  && pattern[i] != range[m + i])
                    {
                        if (comparisons)
                        {
                            this.view.SetCurrentIndexes(i, m + i, sequenceLength);
                            this.view.SetDgvColor(i, Color.Red);
                            this.view.AddStepToLog();
                        }
                        if(range.Length - m == pattern.Length) break;
                    }
                    else if(pattern[i] != range[m + i] && comparisons)
                    {
                        this.view.SetCurrentIndexes(i, m + i, sequenceLength);
                        this.view.SetDgvColor(i, Color.Red);
                        this.view.AddStepToLog();
                    }

                    HiglightStep(15);
                    
                    was = false;

                    HiglightStep(16);
                    
                    m = m + 1 - nextArray[i];

                    HiglightStep(17);
                    
                    if (nextArray[i] > -1)
                    {
                        HiglightStep(18);
                        
                        i = nextArray[i];
                    }
                    else
                    {
                        HiglightStep(20);
                        
                        i = 0;
                    }
                    if (comparisons)
                    {
                        this.view.SetCurrentIndexes(i, m + i, sequenceLength);
                        this.view.SetActualStrings(pattern, range, m);
                    }
                }

                HiglightStep(3);
                
            }

            this.view.ChangeControlsState();
            HiglightStep(24);
            
            return searchResult;
        }

        /// <summary>
        /// Creates new KMPNext table which contains number of steps which are made if the characters doesn't fit.
        /// </summary>
        /// <param name="pattern">Searching string pattern</param>
        /// <param name="patternLength">Length of pattern</param>
        /// <returns>Table of indexes</returns>
        private int[] GenerateNextArray(string pattern, int patternLength)
        {
            int[] nextArray = new int[patternLength];
            int j = 0, i = 1;
            string result = "";
            nextArray[0] = 0;

            logger.Info("Generating NextArray started.");
            while (i < patternLength)
            {
                while (j > 0 && pattern[i] != pattern[j])
                {
                    j = nextArray[j - 1];
                }
                i++;
                j++;
                if (pattern[j - 1] == pattern[i - 1])
                {
                    nextArray[i - 1] = nextArray[j - 1];
                }
                else
                {
                    nextArray[i - 1] = j - 1;
                }
                result = result + ", " + nextArray[i - 1];
            }


            logger.Info("NextArray: " + result);
            return nextArray;
        }

        /// <summary>
        /// Creates new KMPNext table which contains number of steps which are made if the characters doesn't fit.
        /// </summary>
        /// <param name="pattern">Searching string pattern</param>
        /// <param name="patternLength">Length of pattern</param>
        /// <param name="time">Delay time</param>
        /// <returns>Table of indexes</returns>
        private int[] GenerateNextArray(string pattern, int patternLength, int time)
        {
            int[] nextArray = new int[patternLength];
            int j = 0, i = 1;

            AddParametersToListBox(this.model.GetNextArrayVariables(), this.model.GetNextArrayStepList(), this.view);

            HiglightStep(2);
            
            nextArray[0] = 0;

            HiglightStep(3);
            
            while (i < patternLength)
            {
                HiglightStep(5);
                
                while (j > 0 && pattern[i] != pattern[j])
                {
                    HiglightStep(6);
                    
                    j = nextArray[j - 1];

                    HiglightStep(5);
                    
                }
                HiglightStep(8);
                
                i++;

                HiglightStep(9);
                
                j++;

                HiglightStep(10);
                
                if (pattern[j - 1] == pattern[i - 1])
                {
                    HiglightStep(11);
                    
                    nextArray[i - 1] = nextArray[j - 1];
                }
                else
                {
                    HiglightStep(13);
                    
                    nextArray[i - 1] = j - 1;
                }
                HiglightStep(3);
                
            }
            HiglightStep(16);
            
            return nextArray;
        }
    }
}
