﻿//NotSoNaive.cs
//
//Not So Naive algorithm model.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringProject.Model
{
    class NotSoNaive
    {
        //Array which contains list of used variables.
        private string[] variables = {"In",
            "\tpattern - searched sequence", 
            "\trange - text in which pattern is searched",
            "\tp - length of pattern",
            "\tr - length of range",
            "Out\n" +
            "\tsearchResult - list of indexes matched sequences",
            "Temporary variables",
            "\tinteger s - index in range",
            "\tinteger s0 - moving by one position",
            "\tinteger s1 - moving by two positions",
            "\tinteger i - length of acutally found sequence"};

        //Array which containst list of algorithm steps.
        private string[] stepList = new string[] { "Procedure SearchPattern(pattern,range)",
            "begin",
            "\tif pattern[0] = pattern[1] then",
            "\t\ts0 = 2;",
            "\t\ts1 = 1;",
            "\telse",
            "\t\ts0 = 1;",
            "\t\ts1 = 2;",
            "\tend if",
            "\twhile s <= r - p do",
            "\t\tif pattern[1] <> range[s + 1] then ",
            "\t\t\ts = s + s0;",
            "\t\telse",
            "\t\t\ti = 2;",
            "\t\t\twhile i <= p - 1 and range[s + i] <> pattern[i] do",
            "\t\t\t\ti = i + 1;",
            "\t\t\tend while",
            "\t\t\tif i = p - 1 and range[s] = pattern[0] then",
            "\t\t\t\tsearchResult.Add(s);",
            "\t\t\tend if",
            "\t\t\ts = s + s1;", 
            "\tend while",
            "sreturn searchResult",
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
