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
        BoyerMoore model;

        public BoyerMooreController()
        {
            this.model = new BoyerMoore();
        }

        public BoyerMooreController(MainWindow view)
        {
            this.model = new BoyerMoore();
            this.view = view;

            this.view.LoadToListbox(this.view.stepListListBox, this.model.GetStepList());
            this.view.LoadToListbox(this.view.variablesListBox, this.model.GetVariables());
            this.delayTime = Int32.Parse(this.view.delayTimeComboBox.Text);
        }

        override public List<int> SearchPattern(string pattern, string range)
        {
            List<int> searchResult = new List<int>();
            return searchResult;
        }

        override public List<int> SearchPattern(string pattern, string range, int time)
        {
            List<int> searchResult = new List<int>();
            return searchResult;
        }
    }
}
