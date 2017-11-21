﻿//KnuthMorrisPratt.cs
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
    sealed class KnuthMorrisPratt : MainModel
    { 
        //Array which contains list of used in generating KMPNext array variables.
        private string[] nextArrayVariables = new string [] {"In",
            "\tstring pattern - searched sequence",
            "\tstring p - length of pattern",
            "Out",
            "\tinteger[] nextArray - aray of KMPNext indexes",
            "Temporary variables",
            "\tinteger i - actual position in arrayNext",
            "\tinteger j - position in pattern",
            };

        //Array which contains list of variables used in main algorithm.
        private string[] variables = new string[] {"In",
            "\tstring pattern - searched sequence\n ",
            "\tstring range - text in which pattern is searched",
            "\tinteger p - length of pattern",
            "\tinteger r - length of range",
            "\tbool was - check if match was found",
            "\tinteger[] nextArray - array of KMPNext indexes",
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

        //Returns array of main algorithm's variables
        public override string[] GetVariables()
        {
            return this.variables;
        }

        //Returns array of main algorithm's steps.
        public override string[] GetStepList()
        {
            return this.stepList;
        }

        //Returns array of nextArray algorithm's steps.
        public override string[] GetNextArrayStepList()
        {
            return this.nextArrayStepList;
        }

        //Returns array of nextArray algorithm's variables
        public override string[] GetNextArrayVariables()
        {
            return this.nextArrayVariables;
        }

    }
}
