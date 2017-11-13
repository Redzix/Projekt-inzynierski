﻿//NaiveController.cs
//
//Controller which is responsible for Naive algorithm execution.
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
    sealed class NaiveController : MainController
    {
        //Naive algorithm model.
        private Naive model;

        //Constructor which create new model.
        public NaiveController()
        {
            model = new Naive();
        }

        /// <summary>
        ///Main constructor. Creates new model and view object. Allows loading variables, steplist to suitable ListBoxes.
        /// </summary>
        /// <param name="view">Current used view handler.</param>
        public NaiveController(MainWindow view)
        {
            this.model = new Naive();
            this.view = ((MainWindow)view);

            this.view.LoadToListbox(this.view.stepListListBox, this.model.GetStepList());
            this.view.LoadToListbox(this.view.variablesListBox, this.model.GetVariables());
        }

        /// <summary>
        /// Method which implements Naive searching algorithm which works without any delaying.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user.</param>
        /// <param name="range">It's a text in which the pattern will be searched.</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty.</returns>
        override public List<int> SearchPattern(string pattern, string range)
        {
            List<int> searchResult = new List<int>();
            int k;

            if ((pattern.Length == 0) || (range.Length == 0))
            {
                
                return null;
            }

            ChangeControlsState();
            for (int i = 0; i <= (range.Length - pattern.Length); i++)
            {
                k = 0;

                while ((k < pattern.Length) && (range[i + k] == pattern[k]))
                {
                    k++;
                }

                if (k == pattern.Length)
                {
                    searchResult.Add(i);
                }
            }

            ChangeControlsState();
            return searchResult;
        }

        /// <summary>
        /// Method which implements Naive searching algorithm which works with delay between next steps. Allows higlighitng of next steps.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user.</param>
        /// <param name="range">It's a text in which the pattern will be searched.</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty.</returns>
        override public List<int> SearchPattern(string pattern, string range, int time)
        {
            List<int> searchResult = new List<int>();
            int k;

            this.delayTime = time;

            if ((pattern.Length == 0) || (range.Length == 0))
            {
                return null;
            }

            ChangeControlsState();
            this.view.HighlightActualStep(this.view.stepListListBox, 2);
            this.Delay(this.delayTime);
            for (int i = 0; i <= (range.Length - pattern.Length); i++)
            {
                this.view.HighlightActualStep(this.view.stepListListBox, 4);
                this.Delay(this.delayTime);
                k = 0;

                this.view.HighlightActualStep(this.view.stepListListBox, 5);
                this.Delay(this.delayTime);
                while ((k < pattern.Length) && (range[i + k] == pattern[k]))
                {
                    this.view.HighlightActualStep(this.view.stepListListBox, 6);
                    this.Delay(this.delayTime);
                    k++;
                }

                this.view.HighlightActualStep(this.view.stepListListBox, 8);
                this.Delay(this.delayTime);
                if (k == pattern.Length)
                {
                    this.view.HighlightActualStep(this.view.stepListListBox, 9);
                    this.Delay(this.delayTime);
                    searchResult.Add(i);
                }
            }
            this.view.HighlightActualStep(this.view.stepListListBox, 12);
            this.Delay(this.delayTime);

            ChangeControlsState();
            return searchResult;
        }
    }
}