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
    sealed class BoyerMoore : MainModel
    {
        //Array which contains list of variables used in main algorithm.
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
            "\tinteger[] delta1 - table of bad character heuristic indexes",
            "\tinteger[] delta2 - table of good sufix heuristic indexes"};

        //Array which containst list of main algorithm steps.
        private string[] stepList = new string[] { "Procedure SearchPattern(pattern,range)",
            "begin",
            "\tj = 0;",
            "\tdelta1 = ComputeDelta1(pattern);",
            "\tdelta2 = ComputeDelta2(pattern);",
            "\twhile j <= r - p do",
            "\tbegin",
            "\t\ti = pattern.Length - 1;",
            "\t\twhile i >= 0 and pattern[i] = range[i + j]",
            "\t\t\ti = i - 1;",
            "\t\tif i < 0 then",
            "\t\t\tsearchResult.Add(j);",
            "\t\t\tj = j + delta2[0];",
            "\t\telse",
            "\t\t\tj = j + Max(delta2[i], delta1[range[i + j]] - p + i);",
            "\t\tend if",
            "\tend while",
            "return searchResult",
            "end procedure" };
       
        //Returns array of main algorithm steps.
        public override string[] GetStepList()
        {
            return this.stepList;
        }

        //Returns array of main algorithm variables
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
