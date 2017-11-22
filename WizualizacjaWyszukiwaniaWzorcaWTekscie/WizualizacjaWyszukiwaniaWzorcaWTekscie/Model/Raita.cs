//Raita.cs
//
//Raita algorithm model.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringProject.Model
{
    class Raita : MainModel
    {
        //Array which contains list of used variables in main algorithm.
        private string[] variables = new string[] {"In",
            "\tstring pattern - searched sequence ",
            "\tstring range - text in which pattern is searched",
            "\tinteger p - length of pattern",
            "\tinteger r - length of range",
            "Out" +
            "\tinteger[] searchResult - list of indexes matched sequences",
            "Temporary variables",
            "\tinteger i - current compared index",
            "\tinteger j - start index of compared sequence",
            "\tinteger[] delta1 - table of bad character heuristic indexes"};

        //Array which containst list of algorithm steps of main algorithm.
        private string[] stepList = new string[] { "Procedure SearchPattern(pattern,range)",
            "begin",
            "\tj = 0;",
            "\tdelta1 = ComputeDelta1(pattern);",
            "\twhile j <= r - p do",
            "\tbegin",
            "\t\tif pattern[p - 1] = range[j + p - 1] and pattern[0] = range[j] and " +
            "pattern[pattern / 2] = range[j + p / 2] the",
            "\t\t\ti = p - 2;",
            "\t\t\twhile i > 0 and pattern[i] = range[i + j]",
            "\t\t\t\ti = i - 1;",
            "\t\t\tend while",
            "\t\t\tif i = 0 then",
            "\t\t\t\tsearchResult.Add(j);",
            "\t\t\tend if",
            "\t\tend if",
            "\t\tj = j + Max(1, delta1[range[i + j]] - p + i);",
            "\tend while",
            "return searchResult",
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
