using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringProject.Model
{
    class NaiveAlgorithm
    {
        private string variables = "In\n" +
            "\tpattern - searched sequence\n " +
            "\trange - text in which pattern is searched\n" +
            "\tp - length of pattern\n" +
            "\tr - length of range\n\n" +
            "Out\n" +
            "\tsearchResult - matched sequences\n\n";

        private string[] stepList = new string[] { "0123456789", "0123456789", "0123456789" };

        public string[] GetStepList()
        {
            return this.stepList;
        }
        public string GetVariables()
        {
            return this.variables;
        }
    }
}
