//SmithController.cs
//
//Controller which is responsible for Smith algorithm execution.
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
    sealed class SmithController : MainController
    {
        Smith model;

        public SmithController()
        {
            this.model = new Smith();
        }

        public SmithController(MainWindow view)
        {
            this.model = new Smith();
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
