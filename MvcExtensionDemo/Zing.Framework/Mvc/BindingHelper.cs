// (c) Copyright 2002-2009 Telerik 
// This source is subject to the GNU General Public License, version 2
// See http://www.gnu.org/licenses/gpl-2.0.html. 
// All other rights reserved.


namespace Zing.Framework.Mvc
{
    using System;
    using Zing.Framework.Utility.Extensions;
    using Expressions;
    using Zing.Framework.UI;

    internal static class BindingHelper
    {
        internal static Type ExtractMemberTypeFromObject(object item, string memberName)
        {
            if (item.GetType().IsDynamicObject())
            {
                var lambda = ExpressionBuilder.Lambda<object>(memberName, true);
                var result = ((Func<object, object>)lambda.Compile()).Invoke(item);

                if (result != null)
                {
                    return result.GetType();
                }
                return null;
            }
            return new PropertyAccessExpressionBuilder(item.GetType(), memberName).CreateMemberAccessExpression().Type;
        }
    }
}
