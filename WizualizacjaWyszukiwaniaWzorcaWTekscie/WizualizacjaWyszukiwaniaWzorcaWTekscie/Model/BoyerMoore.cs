//BoyerMoore.cs
//
//Boyer-Moore algorithm model.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringProject.Model
{
    class BoyerMoore
    {
        //Array which contains list of used variables.
        private string[] variables = {"In\n",
            "\tpattern - searched sequence\n ",
            "\trange - text in which pattern is searched\n",
            "\tp - length of pattern\n",
            "\tr - length of range\n\n",
            "Out\n" +
            "\tsearchResult - list of indexes matched sequences\n\n",
            "Temporary variables\n",
            "\tinteger i - index in range\n",
            "\tinteger k - counter of matched characters\n",
            "\tinteger n - length of range\n",
            "\tinteger m - length of pattern"};

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
        public string[] GetStepList()
        {
            return this.stepList;
        }

        //Returns array of variables
        public string[] GetVariables()
        {
            return this.variables;
        }
    }
}
