using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI
{
    /// <summary>
    /// Logical operator used for filter descriptor composition.
    /// </summary>
    public enum FilterCompositionLogicalOperator
    {
        /// <summary>
        /// Combines filters with logical AND.
        /// </summary>
        And,

        /// <summary>
        /// Combines filters with logical OR.
        /// </summary>
        Or
    }
}
