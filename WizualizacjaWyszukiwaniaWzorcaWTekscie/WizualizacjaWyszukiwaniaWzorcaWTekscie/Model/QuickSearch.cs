//QuickSearch.cs
//
//Quick Search algorithm model.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringProject.Model
{
    class QuickSearch : MainModel
    {
        //Array which contains list of used variables.
        private string[] variables = new string[] {"In\n",
            "\tpattern - searched sequence\n ", 
            "\trange - text in which pattern is searched\n",
            "\tp - length of pattern\n",
            "\tr - length of range\n\n",
            "Out\n" +
            "\tsearchResult - list of indexes matched sequences\n\n",
            "Temporary variables\n",
            "\t i - index in range\n",
            "\t k - counter of matched characters\n",
            "\t n - length of range\n",
            "\t m - length of pattern"};

        //Array which containst list of algorithm steps.
        private string[] stepList = new string[] { "Procedure SearchPattern(pattern,range)",
            "begin",
            "\tfor i = 0 to n - m do",
            "\tbegin",
            "\t\tk:=0;",
            "\t\twhile k < m and range[i + k] = pattern[k] do",
            "\t\t\tk = k + 1;",
            "\t\tend while",
            "\t\tif k = m then",
            "\t\t\tsearchResult.Add(i)",
            "\t\tend if",
            "\tend for",
            "\treturn searchResult",
            "end procedure" };

        //Returns array of steps.
        public override string[] GetStepList()
        {
            return this.stepList;
        }

        //Returns array of variables
        public override string[] GetVariables()
        {
            return this.variables;
        }

        public override string[] GetNextArrayStepList()
        {
            throw new NotImplementedException();
        }

        public override string[] GetNextArrayVariables()
        {
            throw new NotImplementedException();
        }
    }
}
