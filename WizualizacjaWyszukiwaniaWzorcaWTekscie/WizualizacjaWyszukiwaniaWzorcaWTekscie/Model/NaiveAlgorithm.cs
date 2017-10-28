using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringProject.Model
{
    class NaiveAlgorithm
    {
        private string variables = "In\n" +
            "\tpattern - searched sequence\n " +
            "\trange - text in which pattern is searched\n" +
            "\tp - length of pattern\n" +
            "\tr - length of range\n\n" +
            "Out\n" +
            "\tsearchResult - list of indexes matched sequences\n\n" +
            "Temporary variables\n" +
            "\tinteger i - index in range\n" +
            "\tinteger k - counter of matched characters\n" +
            "\tinteger n - length of range\n" +
            "\tinteger m - length of pattern";

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

        //Contains information about length and indexes in RichTextBox each step from steplist .
        //private int[,] stepPosition;

        //Returns table of steps
        public string[] GetStepList()
        {
            return this.stepList;
        }

        //Returns table of variables
        public string GetVariables()
        {
            return this.variables;
        }

        //Returns table of indexes and steps string length
      /*  public int[,] GetStepPosition()
        {
            this.stepPosition = new int[this.stepList.Length, 2];
            for(int i = 0; i < this.stepList.Length; i++)
            {
                if(i == 0)
                {
                    // set string length
                    this.stepPosition[i, 0] = this.stepList[0].Length;
                    // set start position 
                    this.stepPosition[i, 1] = 0;
                }
                else
                {
                    this.stepPosition[i, 0] = this.stepList[i].Length;
                    this.stepPosition[i, 1] = this.stepPosition[i-1,1] + this.stepList[i-1].Length + 1;
                }
            }
            return this.stepPosition;
        }*/
    }
}
