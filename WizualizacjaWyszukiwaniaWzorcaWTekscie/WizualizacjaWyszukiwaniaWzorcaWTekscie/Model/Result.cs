using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineeringProject.Enum;


namespace EngineeringProject.Model
{
    /// <summary>
    /// Model of found result.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Searched pattern.
        /// </summary>
        private string pattern;

        /// <summary>
        /// Range in which pattern was searched.
        /// </summary>
        private string range;

        /// <summary>
        /// List of found indexes.
        /// </summary>
        private List<int> results;

        /// <summary>
        /// Used search method.
        /// </summary>
        private ESearchMethods method;

        /// <summary>
        /// Duration of searching.
        /// </summary>
        private long time;

        /// <summary>
        /// Sets and gets current pattern.
        /// </summary>
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

        /// <summary>
        /// Sets and gets current range.
        /// </summary>
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

        /// <summary>
        /// Sets and gets list of found indexes.
        /// </summary>
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

        /// <summary>
        /// Sets and gets used searching method.
        /// </summary>
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

        /// <summary>
        /// Sets and gets search duration time.
        /// </summary>
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
