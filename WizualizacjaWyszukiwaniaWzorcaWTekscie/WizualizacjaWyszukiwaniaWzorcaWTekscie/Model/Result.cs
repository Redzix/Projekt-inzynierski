using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineeringProject.Enum;

namespace EngineeringProject.Model
{
    public class Result
    {
        private string pattern;

        private string range;

        private List<int> results;

        private ESearchMethods method;

        private long time;

        public string Pattern
        {
            get
            {
                return pattern;
            }
            set
            {
                pattern = value;
            }
        }

        public string Range
        {
            get
            {
                return range;
            }
            set
            {
                range = value;
            }
        }

        public List<int> Results
        {
            get
            {
                return results;
            }
            set
            {
                results = value;
            }
        }

        public ESearchMethods Method
        {
            get
            {
                return method;
            }
            set
            {
                method = value;
            }
        }

        public long Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }
    }
}
