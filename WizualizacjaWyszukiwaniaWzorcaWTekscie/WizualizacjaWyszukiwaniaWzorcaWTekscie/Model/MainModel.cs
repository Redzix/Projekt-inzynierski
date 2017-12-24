using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringProject.Model
{
    /// <summary>
    /// Main model abstract class which contains declarations and definitions of model fields and getters.
    /// </summary>
    public abstract class MainModel
    {
        /// <summary>
        /// Array which contains list of variables used in computing delta1.
        /// </summary>
        private string[] computeDelta1Variables = new string[] {"In",
            "\tstring pattern - searched sequence ",
            "\tinteger p - length of pattern",
            "\tinteger alphabetSize - size of delta1 array",
            "Out" +
            "\tinteger[] delta1- list of computed indexes",
            "Temporary variables",
            "\tinteger i - current character in alphabet",
            "\tinteger j - current index in pattern"};

        /// <summary>
        /// Array which containst list of ComputeDelta1 algorithm steps.
        /// </summary>
        private string[] computeDelta1StepList = new string[] { "Procedure ComputeDelta1(pattern)",
            "begin",
            "\tfor i = 0 to alphabetSize do",
            "\t\tdelta1[i] = p - 1;",
            "\tend for",
            "\tfor j = 0 to p - 1 do",
            "\t\tdelta1[pattern[j]] = p - j - 1;",
            "\tend for",
            "return delta1;",
            "end procedure" };

        /// <summary>
        /// Array which contains list of variables used in computing delta2.
        /// </summary>
        private string[] computeDelta2Variables = new string[] {"In",
            "\tstring pattern - searched sequence ",
            "\tinteger p - length of pattern",
            "Out" +
            "\tinteger[] delta2 - list of computed indexes",
            "Temporary variables",
            "\tinteger i - current index in pattern",
            "\tinteger j - index in delta2 array",
            "\tinteger[] sufix - table of sufixes"};

        /// <summary>
        /// Array which containst list of ComputeDelta2 algorithm steps.
        /// </summary>
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
            "return delta2;",
            "end procedure" };

        /// <summary>
        /// Array which contains list of variables used in computing delta1.
        /// </summary>
        private string[] computeDelta3Variables = new string[] {"In",
            "\tstring pattern - searched sequence ",
            "\tinteger p - length of pattern",
            "\tinteger alphabetSize - size of delta3 array",
            "Out" +
            "\tinteger[] delta3- list of computed indexes",
            "Temporary variables",
            "\tinteger i - current character in alphabet",
            "\tinteger j - current index in pattern"};

        /// <summary>
        /// Array which containst list of ComputeDelta1 algorithm steps.
        /// </summary>
        private string[] computeDelta3StepList = new string[] { "Procedure ComputeDelta3(pattern)",
            "begin",
            "\tfor i = 0 to alphabetSize do",
            "\t\tdelta1[i] = p;",
            "\tend for",
            "\tfor j = 0 to p do",
            "\t\tdelta1[pattern[j]] = p - j",
            "\tend for",
            "return delta3;",
            "end procedure" };

        /// <summary>
        /// Array which contains list of variables used in computing sufix.
        /// </summary>
        private string[] computeSufixVariables = new string[] {"In",
            "\tstring pattern - searched sequence ",
            "\tinteger p - length of pattern",
            "Out" +
            "\tinteger[] sufix - list of computed sufixes",
            "Temporary variables",
            "\tinteger i - index in sufix array",
            "\tinteger j - next computed sufix"};

        /// <summary>
        /// Array which containst list of ComputeSufix algorithm steps.
        /// </summary>
        private string[] computeSufixStepList = new string[] { "Procedure ComputeSufix(pattern)",
            "begin",
            "\tsufix[p - 1] = p;",
            "\tfor i = p - 2 to -1 do",
            "\t\tj = 0;",
            "\t\twhile j <= i and pattern[i - j] == pattern[p - j - 1]",
            "\t\t\tj = j + 1;",
            "\t\tend while",
            "\t\tsufix[i] = j;",
            "\tend for",
            "return sufix;",
            "end procedure" };

        /// <summary>
        /// Returns array o main algorithm variables
        /// </summary>
        /// <returns>Variables</returns>
        public abstract string[] GetVariables();

        /// <summary>
        /// Returns array of main algorithm stepss.
        /// </summary>
        /// <returns>Step list</returns>
        public abstract string[] GetStepList();

        /// <summary>
        /// Returns array of nextArray algorithm's steps.
        /// </summary>
        /// <returns>nextArray step list</returns>
        public abstract string[] GetNextArrayStepList();

        /// <summary>
        /// Returns array of nextArray algorithm's variables
        /// </summary>
        /// <returns>nextArray variables</returns>
        public abstract string[] GetNextArrayVariables();

        /// <summary>
        /// Returns array of ComputeDelta1 steps.
        /// </summary>
        /// <returns>Delta1 step list</returns>
        public virtual string[] GetComputeDelta1StepList()
        {
            return this.computeDelta1StepList;
        }

        /// <summary>
        /// Returns array of ComputeDelta1 variables
        /// </summary>
        /// <returns>Delta1 variables</returns>
        public virtual string[] GetComputeDelta1Variables()
        {
            return this.computeDelta1Variables;
        }

        /// <summary>
        /// Returns array of ComputeDelta2 steps.
        /// </summary>
        /// <returns>Delta2 step list</returns>
        public virtual string[] GetComputeDelta2StepList()
        {
            return this.computeDelta2StepList;
        }

        /// <summary>
        /// Returns array of ComputeDelta2 variables
        /// </summary>
        /// <returns>Delta2 variables</returns>
        public virtual string[] GetComputeDelta2Variables()
        {
            return this.computeDelta2Variables;
        }

        /// <summary>
        /// Returns array of ComputeDelta1 steps.
        /// </summary>
        /// <returns>Delta1 step list</returns>
        public virtual string[] GetComputeDelta3StepList()
        {
            return this.computeDelta3StepList;
        }

        /// <summary>
        /// Returns array of ComputeDelta1 variables
        /// </summary>
        /// <returns>Delta1 variables</returns>
        public virtual string[] GetComputeDelta3Variables()
        {
            return this.computeDelta3Variables;
        }

        /// <summary>
        /// Returns array of ComputeSufix steps.
        /// </summary>
        /// <returns>ComputeSufix step list</returns>
        public virtual string[] GetComputeSufixStepList()
        {
            return this.computeSufixStepList;
        }

        /// <summary>
        /// Returns array of ComputeSufix variables
        /// </summary>
        /// <returns>ComputeSufix variables</returns>
        public virtual string[] GetComputeSufixVariables()
        {
            return this.computeSufixVariables;
        }

    }
}
