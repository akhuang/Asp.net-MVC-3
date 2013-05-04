using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI
{
    public enum FilterTokenType
    {
        Property,
        ComparisonOperator,
        Or,
        And,
        Not,
        Function,
        Number,
        String,
        Boolean,
        DateTime,
        LeftParenthesis,
        RightParenthesis,
        Comma
    }
}
