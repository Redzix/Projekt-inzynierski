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
    class KnuthMorrisPratt
    { 
        //Array which contains list of used in generating KMPNext array variables.
        private string[] nextArrayVariables = {"In",
            "\tpattern - searched sequence",
            "\tp - length of pattern",
            "Out",
            "\tnextArray - aray of KMPNext indexes",
            "Temporary variables",
            "\ti - actual position in arrayNext",
            "\tj - position in pattern",
            };

        //Array which contains list of variables used in main algorithm.
        private string[] variables = {"In",
            "\tstring pattern - searched sequence\n ",
            "\tstring range - text in which pattern is searched",
            "\tinteger p - length of pattern",
            "\tinteger r - length of range",
            "\tbool was - check if match was found",
            "\tint[] nextArray - array of KMPNext indexes",
            "Out\n",
            "\tint[] searchResult - list of indexes matched sequences\n\n",
            "Temporary variables\n",
            "\tinteger i - current position in pattern\n",
            "\tinteger m - start of current fit in range"};

        //Array which containst list of algorithm steps.
        private string[] nextArrayStepList = new string[] { "Procedure GenerateNextArray(pattern,range)",
            "begin",
            "\tnextArray[0] = 0;",
            "\twhile i < p do",
            "\tbegin",
            "\t\tif pattern[i] = pattern[j] then",
            "\t\t\tnextArray[i] = j + 1;",
            "\t\t\tj = j + 1;",
            "\t\t\ti = i + 1;",
            "\t\telse",
            "\t\tif j <> 0 then",
            "\t\t\tj = nextArray[j - 1];",
            "\t\telse",
            "\t\t\tnextArray[i] = 0;",
            "\t\t\ti = i + 1;",
            "\tend",
            "return nextArray;",
            "end procedure" };

        //Array which containst list of algorithm steps.
        private string[] stepList = new string[] { "Procedure SearchPattern(pattern,range)",
            "begin",
            "\tnextArray = GenerateNextArray(pattern, p);",
            "\twhile (m + i) < r do",
            "\tbegin",
            "\t\tif pattern[i] = range[m + i] and was = false then",
            "\t\t\tif i = p - 1 then",
            "\t\t\t\tsearchResult.Add(m);",
            "\t\t\t\twas = true;",
            "\t\t\telse",
            "\t\t\t\tif was = false then",
            "\t\t\t\t\ti = i + 1;",
            "\t\telse",
            "\t\t\twas = false;",
            "\t\t\tm = m + 1 - nextArray[i];",
            "\t\t\tif nextArray[i] > -1 then",
            "\t\t\t\ti = nextArray[i];",
            "\t\t\telse",
            "\t\t\t\ti = 0;",
            "\tend",
            "return searchResult",
            "end procedure" };

        //Returns array of main algorithm's steps.
        public string[] GetStepList()
        {
            return this.stepList;
        }

        //Returns array of nextArray algorithm's steps.
        public string[] GetNextArrayStepList()
        {
            return this.nextArrayStepList;
        }

        //Returns array of main algorithm's variables
        public string[] GetVariables()
        {
            return this.variables;
        }

        //Returns array of nextArray algorithm's variables
        public string[] GetNextArrayVariables()
        {
            return this.nextArrayVariables;
        }

        /// <summary>
        /// Copy two arrays into one array
        /// </summary>
        /// <param name="firstArray">First array</param>
        /// <param name="secondArray">Second array</param>
        /// <returns></returns>
        public string[] GetJoinedStringArray(string[] firstArray, string[] secondArray)
        {
            string[] joinedString = new string[firstArray.Length + secondArray.Length + 3];

            joinedString[0] = "Generate KMPNext array";

            Array.Copy(firstArray, 0, joinedString, 1, firstArray.Length);
            joinedString[firstArray.Length + 1] = "";
            joinedString[firstArray.Length + 2] = "Main algorithm:";

            Array.Copy(secondArray, 0, joinedString, (firstArray.Length + 3), secondArray.Length);

            return joinedString;
        }
    }
}
