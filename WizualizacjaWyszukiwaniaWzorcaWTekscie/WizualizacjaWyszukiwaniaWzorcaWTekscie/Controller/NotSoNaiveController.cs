//NotSoNaiveController.cs
//
//Controller which is responsible for Not So Naive algorithm execution.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineeringProject.View;
using EngineeringProject.Model;
using System.Text.RegularExpressions;
using System.Drawing;

namespace EngineeringProject.Controller
{
    sealed class NotSoNaiveController : MainController
    {
        /// <summary>
        /// Constructor which create new model. 
        /// </summary>
        public NotSoNaiveController()
        {
            this.model = new NotSoNaive();
        }

        /// <summary>
        /// Main constructor. Creates new model and view object. Allows loading variables, steplist to suitable ListBoxes.
        /// </summary>
        /// <param name="view">Current used view handler.</param>
        public NotSoNaiveController(MainWindow view)
        {
            this.model = new NotSoNaive();
            this.view = ((MainWindow)view); ;

            AddParametersToListBox(this.model.GetVariables(), this.model.GetStepList(), this.view);
        }

        /// <summary>
        /// Method which implements Not So Naive searching algorithm which works without any delaying.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user.</param>
        /// <param name="range">It's a text in which the pattern will be searched.</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty.</returns>
        override public List<int> SearchPattern(string pattern, string range)
        {
            List<int> searchResult = new List<int>();
            int s0, s1, s = 0, i;


            if ((pattern.Length == 0) || (range.Length == 0) || (pattern.Length == 1))
            {
                return null;
            }

            ChangeControlsState();



            if (pattern[0] == pattern[1])
            {
                s0 = 2;
                s1 = 1;
            }
            else
            {
                s0 = 1;
                s1 = 2;
            }

            while(s <= range.Length - pattern.Length)
            {
                if(pattern[1] != range[s + 1])
                {
                    s += s0;
                }
                else
                {
                    i = 1;
                    while((i < pattern.Length) && (range[s + i] == pattern[i]))
                    {
                        i++;
                    }

                    if ((i == pattern.Length ) && (range[s] == pattern[0]))
                    {
                        searchResult.Add(s);
                    }                  

                    s += s1;
                }
            }
            ChangeControlsState();
            return searchResult;
        }

        /// <summary>
        /// Method which implements Not So Naive searching algorithm which works with delay between next steps. Allows higlighitng of next steps.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user.</param>
        /// <param name="range">It's a text in which the pattern will be searched.</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty.</returns
        override public List<int> SearchPattern(string pattern, string range, int time)
        {
            List<int> searchResult = new List<int>();
            int s0, s1, s = 0, i;
            ChangeControlsState();

            this.delayTime = time;

            if ((pattern.Length == 0) || (range.Length == 0) || (pattern.Length == 1))
            {
                return null;
            }

            HiglightStep(2);
            
            if (pattern[0] == pattern[1])
            {

                HiglightStep(3);
                
                s0 = 2;

                HiglightStep(4);
                
                s1 = 1;
            }
            else
            {
                HiglightStep(6);
                
                s0 = 1;

                HiglightStep(7);
                
                s1 = 2;
            }

            HiglightStep(9);
            
            while (s <= range.Length - pattern.Length)
            {
                this.view.actualStepDataGridView.Rows.Clear();
                this.view.actualStepDataGridView.Rows.Insert(0, Regex.Split(range.Substring(s, (range.Length - s>= 20 ? 20 : range.Length -s)), string.Empty).Skip(1).ToArray());
                this.view.actualStepDataGridView.Rows.Insert(1, Regex.Split(pattern, string.Empty).Skip(1).ToArray());

                HiglightStep(9);
                

                HiglightStep(10);
                
                if (pattern[1] != range[s + 1])
                {
                    SetDgvColor(1, Color.Red);
                    this.view.AddStepToLog();

                    HiglightStep(11);
                    
                    s += s0;
                }
                else
                {                
                    HiglightStep(13);
                    
                    i = 1;                 

                    HiglightStep(14);
                    
                    while ((i < pattern.Length) && (range[s + i] == pattern[i]))
                    {
                        SetDgvColor(i, Color.Green);
                        this.view.AddStepToLog();

                        HiglightStep(15);
                        
                        i++;

                        HiglightStep(14);
                        
                    }

                    if(i < pattern.Length && range[s + i] != pattern[i])
                    {
                        SetDgvColor(i, Color.Red);
                        this.view.AddStepToLog();
                    }

                    HiglightStep(17);
                    
                    if ((i == pattern.Length ) && (range[s] == pattern[0]))
                    {
                        SetDgvColor(0, Color.Green);
                        this.view.AddStepToLog();

                        HiglightStep(18);
                        
                        searchResult.Add(s);

                        AddFoundIndex(s, searchResult.Count.ToString());
                    }
                    else if(range[s] != pattern[0])
                    {
                        SetDgvColor(0, Color.Red);
                        this.view.AddStepToLog();
                    }
                    HiglightStep(20);
                    
                    s += s1;
                }
            }
            HiglightStep(22);
            
            ChangeControlsState();
            return searchResult;
        }

        protected override int[] ComputeSufix(string pattern, int time)
        {
            throw new NotImplementedException();
        }
    }
}
