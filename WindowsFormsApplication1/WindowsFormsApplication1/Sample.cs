using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// 
    /// </summary>
    /// <example>
    /// <code language="bash">
    /// application -c 2 -s 30:100
    /// </code> 
    /// </example>
    public class Sample
    {
        /// <summary>
        /// A Boolean Switch.
        /// </summary>
        /// <example>
        /// <code language="c#">
        /// [Option('b', "verbose", "Description goes here", false)].
        /// </code> 
        /// </example>
        public bool BooleanSwitch { get; set; }

        /// <summary>
        /// Sample.
        /// </summary>
        /// <example>
        /// <code language="cs">
        /// [Option('m', "min", "Minimal value for applications", 0);.
        /// </code> 
        /// </example>
        public int Minimal { get; set; }
    }
}
