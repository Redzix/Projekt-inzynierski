//NaiveController.cs
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
    class NaiveController
    {
        //Naive algorithm model.
        private Naive model;

        //Object of MainWindow class.
        private MainWindow view;

        //Time of delay between next algorithm steps.
        private int delayTime = 100;

        //Constructor which create new model.
        public NaiveController()
        {
            model = new Naive();
        }

        //Main constructor. Creates new model and view object. Allows loading variables, steplist to suitable ListBoxes and set default delayTime.
        public NaiveController(MainWindow view)
        {
            this.model = new Naive();
            this.view = ((MainWindow)view);

            this.view.LoadToListbox(this.view.naiveStepListListBox, this.model.GetStepList());
            this.view.LoadToListbox(this.view.naiveVariablesListBox, this.model.GetVariables());
            this.delayTime = Int32.Parse(this.view.delayTimeComboBox.Text);
        }

        /// <summary>
        /// Method which implements Naive Pattern Searching algorithm which works without any delaying.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user.</param>
        /// <param name="range">It's a text in which the pattern will be searched.</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty.</returns>
        public List<int> SearchPattern(string pattern, string range)
        {
            List<int> searchResult = new List<int>();
            int k;

            if ((pattern.Length == 0) || (range.Length == 0))
            {
                return null;
            }

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
            return searchResult;
        }

        /// <summary>
        /// Method which implements Naive Pattern Searching algorithm which works with delay between next steps. Allows higlighitng of next steps.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user.</param>
        /// <param name="range">It's a text in which the pattern will be searched.</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty.</returns>
        public List<int> SearchPattern(string pattern, string range, int time)
        {
            List<int> searchResult = new List<int>();
            int k;

            this.delayTime = time;

            if ((pattern.Length == 0) || (range.Length == 0))
            {
                return null;
            }

            this.view.HighlightActualStep(this.view.naiveStepListListBox, 2);
            this.Delay(this.delayTime);
            for (int i = 0; i <= (range.Length - pattern.Length); i++)
            {
                this.view.HighlightActualStep(this.view.naiveStepListListBox, 4);
                this.Delay(this.delayTime);
                k = 0;

                this.view.HighlightActualStep(this.view.naiveStepListListBox, 5);
                this.Delay(this.delayTime);
                while ((k < pattern.Length) && (range[i + k] == pattern[k]))
                {
                    this.view.HighlightActualStep(this.view.naiveStepListListBox, 6);
                    this.Delay(this.delayTime);
                    k++;
                }

                this.view.HighlightActualStep(this.view.naiveStepListListBox, 8);
                this.Delay(this.delayTime);
                if (k == pattern.Length)
                {
                    this.view.HighlightActualStep(this.view.naiveStepListListBox, 9);
                    this.Delay(this.delayTime);
                    searchResult.Add(i);
                }
            }
            this.view.HighlightActualStep(this.view.naiveStepListListBox, 12);
            this.Delay(this.delayTime);
            return searchResult;
        }

        /// <summary>
        /// Causes a delay between highlighting each algorithm steps.
        /// </summary>
        /// <param name="time">It's the delay time in miliseconds.</param>
        private void Delay(int time)
        {
            System.Diagnostics.Stopwatch stp = new System.Diagnostics.Stopwatch();
            stp.Start();
            while (stp.ElapsedMilliseconds <= time)
            {
                System.Windows.Forms.Application.DoEvents();

                //TODO: maxint exception
                this.delayTime = Int32.Parse(this.view.delayTimeComboBox.Text);

            }
            stp.Stop();
        }

    }
}
