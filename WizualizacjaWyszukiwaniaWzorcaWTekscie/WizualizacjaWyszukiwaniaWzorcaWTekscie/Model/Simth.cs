﻿//Smith.cs
//
//Smith algorithm model.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringProject.Model
{
    /// <summary>
    /// Model of Smith algorithm step list and variables.
    /// </summary>
    public class Smith : MainModel
    {
        /// <summary>
        /// Array which contains list of used variables in main algorithm.
        /// </summary>
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
            "\tinteger[] delta3 - table of bad character heuristic indexes"};

        /// <summary>
        /// Array which containst list of algorithm steps of main algorithm.
        /// </summary>
        private string[] stepList = new string[] { "Procedure SearchPattern(pattern,range)",
            "begin",
            "\tj = 0;",
            "\tdelta1 = ComputeDelta1(pattern);",
            "\tdelta3 = ComputeDelta3(pattern);",
            "\twhile j <= r - p do",
            "\tbegin",
            "\t\ti = p - 1;",
            "\t\twhile i >= 0 and pattern[i] = range[i + j] do",
            "\t\t\ti = i - 1;",
            "\t\tif i < 0 then",
            "\t\t\tsearchResult.Add(j);",
            "\t\t\tj = j + delta1[range[p - 1 + j]];",
            "\t\telse",
            "\t\t\tj = j + Max(delta1[range[p - 1 + j]] - 1, delta3[range[p - 1 + j]] - 1);",
            "\t\tend if",
            "\tend while",
            "return searchResult;",
            "end procedure" };

        /// <summary>
        /// Returns array of steps.
        /// </summary>
        public override string[] GetStepList()
        {
            return this.stepList;
        }

        /// <summary>
        /// Returns array of variables
        /// </summary>
        /// <returns>Variables</returns>
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
