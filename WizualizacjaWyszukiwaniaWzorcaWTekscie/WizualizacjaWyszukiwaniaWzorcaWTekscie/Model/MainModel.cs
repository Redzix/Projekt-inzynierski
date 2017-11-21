using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringProject.Model
{
    abstract class MainModel
    {
        //Array which contains list of variables used in computing delta1.
        private string[] computeDelta1Variables = new string[] {"In",
            "\tstring pattern - searched sequence ",
            "\tinteger p - length of pattern",
            "\tinteger alphabetSize - size of delta1 array",
            "Out" +
            "\tinteger[] delta1- list of computed indexes",
            "Temporary variables",
            "\tinteger i - current character in alphabet",
            "\tinteger j - current index in pattern"};

        //Array which containst list of ComputeDelta1 algorithm steps.
        private string[] computeDelta1StepList = new string[] { "Procedure ComputeDelta1(pattern)",
            "begin",
            "\tfor i = 0 to alphabetSize do",
            "\t\tdelta1[i] = pattern.Length",
            "\tend for",
            "\tfor j = 0 to p do",
            "\t\tdelta1[pattern[i]] = p - i - 1",
            "\tend for",
            "return delta1",
            "end procedure" };

        //Array which contains list of variables used in computing delta2.
        private string[] computeDelta2Variables = new string[] {"In",
            "\tstring pattern - searched sequence ",
            "\tinteger p - length of pattern",
            "Out" +
            "\tinteger[] delta2 - list of computed indexes",
            "Temporary variables",
            "\tinteger i - current inxdex in pattern",
            "\tinteger j - index in delta2 array",
            "\tinteger[] sufix - table of sufixes"};

        //Array which containst list of ComputeDelta2 algorithm steps.
        private string[] computeDelta2StepList = new string[] { "Procedure ComputeDelta2(pattern)",
            "begin",
            "\tsufix = ComputeSufix(pattern);",
            "\tfor i = 0 to p do",
            "\t\tdelta2[i] = p;",
            "\tend for",
            "\tfor i = p - 1 to -1 do", // dopóki >=0
            "\t\tif sufix[i] = i + 1 then ",
            "\t\t\tfor j = 0 to p - 1 - i do", // dopóki< p - 1 - i
            "\t\t\t\tdelta2[j] = p - 1 - i;",
            "\t\t\tend for",
            "\t\tend if",
            "\tend for",
            "\tfor i = 0 to p - 1 do", // dopóki <= p - 2
            "\t\tdelta2[p - 1 - sufix[i]] = p - 1 - i;",
            "\tend for",
            "return delta2",
            "end procedure" };

        //Array which contains list of variables used in computing sufix.
        private string[] computeSufixVariables = new string[] {"In",
            "\tstring pattern - searched sequence ",
            "\tinteger p - length of pattern",
            "Out" +
            "\tinteger[] sufix - list of computed sufixes",
            "Temporary variables",
            "\tinteger i - index in sufix array",
            "\tinteger j - next computed sufix"};

        //Array which containst list of ComputeSufix algorithm steps.
        private string[] computeSufixStepList = new string[] { "Procedure ComputeSufix(pattern)",
            "begin",
            "\tsufix[p - 1] = p;",
            "\tfor i = p - 2 to -1 do",
            "\t\tj = 0;",
            "\t\twhile j <= i and pattern[i - j] == pattern[p - j - 1]",
            "\t\t\tj = j + 1;",
            "\t\tsufix[i] = j;",
            "\tend for",
            "return sufix",
            "end procedure" };

        //Returns array o main algorithm variables
        public abstract string[] GetVariables();

        //Returns array of main algorithm stepss.
        public abstract string[] GetStepList();

        //Returns array of nextArray algorithm's steps.
        public abstract string[] GetNextArrayStepList();

        //Returns array of nextArray algorithm's variables
        public abstract string[] GetNextArrayVariables();

        //Returns array of ComputeDelta1 steps.
        public virtual string[] GetComputeDelta1StepList()
        {
            return this.computeDelta1StepList;
        }

        //Returns array of ComputeDelta1 variables
        public virtual string[] GetComputeDelta1Variables()
        {
            return this.computeDelta1Variables;
        }

        //Returns array of ComputeDelta2 steps.
        public virtual string[] GetComputeDelta2StepList()
        {
            return this.computeDelta2StepList;
        }

        //Returns array of ComputeDelta2 variables
        public virtual string[] GetComputeDelta2Variables()
        {
            return this.computeDelta2Variables;
        }

        //Returns array of ComputeSufix steps.
        public virtual string[] GetComputeSufixStepList()
        {
            return this.computeSufixStepList;
        }

        //Returns array of ComputeSufix variables
        public virtual string[] GetComputeSufixVariables()
        {
            return this.computeSufixVariables;
        }

    }
}
