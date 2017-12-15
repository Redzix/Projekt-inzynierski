//ESearchMethods
//
//Enumerator of searching methods
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EngineeringProject.Enum
{
    /// <summary>
    /// Describes searching methods.
    /// </summary>
    public enum ESearchMethods
    {
        /// <summary>
        /// Naive
        /// </summary>
        NAIVE,
        /// <summary>
        /// Boyer-Moore
        /// </summary>
        BOYER_MOORE,
        /// <summary>
        /// Knuth-Morris-Pratt
        /// </summary>
        KMP,
        /// <summary>
        /// Horspool
        /// </summary>
        HORSPOOL,
        /// <summary>
        /// Quick Search
        /// </summary>
        QUICK_SEARCH,
        /// <summary>
        /// Raita
        /// </summary>
        RAITA,
        /// <summary>
        /// Smith
        /// </summary>
        SMITH,
        /// <summary>
        /// Not So Naives
        /// </summary>
        NOT_SO_NAIVE
    }
}
