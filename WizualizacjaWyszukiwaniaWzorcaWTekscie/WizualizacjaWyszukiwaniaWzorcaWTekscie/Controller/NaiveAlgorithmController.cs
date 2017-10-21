using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineeringProject.View;
using EngineeringProject.Model;

namespace EngineeringProject.Controller
{
    class NaiveAlgorithmController
    {
        private NaiveAlgorithm model;

        private MainWindow view;      

        public NaiveAlgorithmController()
        {
            model = new NaiveAlgorithm();
        }

        public NaiveAlgorithmController(MainWindow view)
        {
            this.model = new NaiveAlgorithm();
            this.view = view;
            this.view.rtbNaiveSearchVariables.Text = this.SetVariables();
            this.view.rtbNaiveSearchSteps.Text = string.Join("\n",this.SetStepList());
        }

        private string SetVariables()
        {
            return this.model.GetVariables();
        }

        private string[] SetStepList()
        {
            return this.model.GetStepList();
        }
        /// <summary>
        /// Method which implements Naive Pattern Searching algorithm.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user.</param>
        /// <param name="range">It's a text in which the pattern will be searched.</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty..</returns>
        public List<int> SearchPattern(string pattern,string range)
        {
            List<int> searchResult = new List<int>();
            int k, step = 0;

            if((pattern.Length == 0) || (range.Length == 0))
            {
                return null;
            }
            this.view.HighlightActualStep(this.model.GetStepList(), 0);
            this.view.HighlightActualStep(this.model.GetStepList(), 1);
            this.view.HighlightActualStep(this.model.GetStepList(), 2);

            for (int i = 0; i <= (range.Length - pattern.Length); i++)
            {
                k = 0;
                while ((k < pattern.Length) && (range[i + k] == pattern[k]))
                {
                    k++;
                }

                if(k == pattern.Length)
                {
                    searchResult.Add(i);
                }             
            }

            /*List<int> listaWynikow = new List<int>();
              for (int i = 0; i < (zakres.Length - wzorzec.Length + 1); i++)
              {
                  if (wzorzec.Equals(zakres.Substring(i, wzorzec.Length)))
                      listaWynikow.Add(i);

              }*/
            return searchResult;
        }
    
        
    }
}
