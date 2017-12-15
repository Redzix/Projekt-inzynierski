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
    /// <summary>
    /// Model of Naive algorithm step list and variables.
    /// </summary>
    public class Naive : MainModel
    {
        /// <summary>
        /// Array which contains list of used variables.
        /// </summary>
        private string[] variables = new string[] {"In",
            "\tstring pattern - searched sequence", 
            "\tstring range - text in which pattern is searched",
            "\tinteger p - length of pattern",
            "\tinteger r - length of range",
            "Out",
            "\tinteger[] searchResult - list of indexes matched sequences",
            "Temporary variables",
            "\tinteger i - index in range",
            "\tinteger k - counter of matched characters"};

        /// <summary>
        /// Array which containst list of algorithm steps.
        /// </summary>
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

        /// <summary>
        /// Returns array of steps
        /// </summary>
        /// <returns>Step list</returns>
        public override string[] GetStepList()
        {
            return this.stepList;
        }

        /// <summary>
        /// Returns array of variables
        /// </summary>
        /// <returns>Variables list</returns>
        public override string[] GetVariables()
        {
            return this.variables;
        }

        /// <summary>
        /// Not implemented getter of nextArray step list.
        /// </summary>
        /// <returns>None</returns>
        public override string[] GetNextArrayStepList()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented getter of nextArray variables.
        /// </summary>
        /// <returns>None</returns>
        public override string[] GetNextArrayVariables()
        {
            throw new NotImplementedException();
        }
    }
}
