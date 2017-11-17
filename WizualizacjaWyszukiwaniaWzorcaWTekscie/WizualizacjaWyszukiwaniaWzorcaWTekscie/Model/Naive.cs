//Naive.cs
//
//Naive algorithm model.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringProject.Model
{
    class Naive
    {
        //Array which contains list of used variables.
        private string[] variables = {"In",
            "\tstring pattern - searched sequence", 
            "\tstring range - text in which pattern is searched",
            "\tinteger p - length of pattern",
            "\tinteger r - length of range",
            "Out",
            "\tint[] searchResult - list of indexes matched sequences",
            "Temporary variables",
            "\tinteger i - index in range",
            "\tinteger k - counter of matched characters"};

        //Array which containst list of algorithm steps.
        private string[] stepList = new string[] { "Procedure SearchPattern(pattern,range)",
            "begin",
            "\tfor i = 0 to r - p do",
            "\tbegin",
            "\t\tk:=0;",
            "\t\twhile k < p and range[i + k] = pattern[k] do",
            "\t\t\tk = k + 1;",
            "\t\tend while",
            "\t\tif k = p then",
            "\t\t\tsearchResult.Add(i);",
            "\t\tend if",
            "\tend for",
            "return searchResult",
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
