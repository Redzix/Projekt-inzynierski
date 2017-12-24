//KnuthMorrisPratt.cs
//
//Knuth Morris Pratt algorithm model.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringProject.Model
{
    /// <summary>
    /// Model of Knuth Morris Pratt algorithm step list and variables.
    /// </summary>
    public class KnuthMorrisPratt : MainModel
    {
        /// <summary>
        /// Array which contains list of used in generating KMPNext array variables.
        /// </summary>
        private string[] nextArrayVariables = new string [] {"In",
            "\tstring pattern - searched sequence",
            "\tstring p - length of pattern",
            "Out",
            "\tinteger[] nextArray - aray of KMPNext indexes",
            "Temporary variables",
            "\tinteger i - actual position in arrayNext",
            "\tinteger j - position in pattern",
            };

        /// <summary>
        /// Array which contains list of variables used in main algorithm.
        /// </summary>
        private string[] variables = new string[] {"In",
            "\tstring pattern - searched sequence\n ",
            "\tstring range - text in which pattern is searched",
            "\tinteger p - length of pattern",
            "\tinteger r - length of range",
            "Out\n",
            "\tint[] searchResult - list of indexes matched sequences\n\n",
            "Temporary variables\n",
            "\tbool was - check if match was found",
            "\tinteger[] nextArray - array of KMPNext indexes",
            "\tinteger i - current position in pattern\n",
            "\tinteger m - start of current fit in range"};

        /// <summary>
        /// Array which containst list of algorithm steps.
        /// </summary>
        private string[] nextArrayStepList = new string[] { "Procedure GenerateNextArray(pattern)",
            "begin",
            "\tnextArray[0] = 0;",
            "\twhile i < p do",
            "\tbegin",
            "\t\twhile j > 0 and pattern[i] <> pattern[j] do",
            "\t\t\tj = nextArray[j - 1];",
            "\t\tend while;",
            "\t\ti = i + 1;",
            "\t\tj = j + 1;",
            "\t\tif pattern[j - 1] = pattern[i - 1] then",
            "\t\t\tnextArray[i - 1] = nextArray[j - 1];",
            "\t\telse",
            "\t\t\tnextArray[i - 1] = j - 1;",
            "\t\tend if",
            "\tend while",
            "return nextArray;",
            "end procedure" };

        /// <summary>
        /// Array which containst list of algorithm steps.
        /// </summary>
        private string[] stepList = new string[] { "Procedure SearchPattern(pattern,range)",
            "begin",
            "\tnextArray = GenerateNextArray(pattern, p);",
            "\twhile m + i < r do",
            "\tbegin",
            "\t\tif pattern[i] = range[m + i] and was = false then",
            "\t\t\tif i = p - 1 then",
            "\t\t\t\tsearchResult.Add(m);",
            "\t\t\t\twas = true;",
            "\t\t\telse",
            "\t\t\t\tif was = false then",
            "\t\t\t\t\ti = i + 1;",
            "\t\t\t\tend if",
            "\t\t\tend if",
            "\t\telse",
            "\t\t\twas = false;",
            "\t\t\tm = m + 1 - nextArray[i];",
            "\t\t\tif nextArray[i] > -1 then",
            "\t\t\t\ti = nextArray[i];",
            "\t\t\telse",
            "\t\t\t\ti = 0;",
            "\t\t\tend if",
            "\t\tend if",
            "\tend while",
            "return searchResult;",
            "end procedure" };

        /// <summary>
        /// Returns array of main algorithm's variables
        /// </summary>
        /// <returns>Variables</returns>
        public override string[] GetVariables()
        {
            return this.variables;
        }

        /// <summary>
        /// Returns array of main algorithm's steps.
        /// </summary>
        /// <returns>Step list</returns>
        public override string[] GetStepList()
        {
            return this.stepList;
        }

        /// <summary>
        /// Returns array of nextArray algorithm's steps.
        /// </summary>
        /// <returns>nextArray step list</returns>
        public override string[] GetNextArrayStepList()
        {
            return this.nextArrayStepList;
        }

        /// <summary>
        /// Returns array of nextArray algorithm's variables
        /// </summary>
        /// <returns>nextArray variables</returns>
        public override string[] GetNextArrayVariables()
        {
            return this.nextArrayVariables;
        }

    }
}
