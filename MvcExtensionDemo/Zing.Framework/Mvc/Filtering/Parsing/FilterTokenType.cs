// (c) Copyright 2002-2010 Telerik 
// This source is subject to the GNU General Public License, version 2
// See http://www.gnu.org/licenses/gpl-2.0.html. 
// All other rights reserved.

namespace Zing.Framework.Mvc
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
