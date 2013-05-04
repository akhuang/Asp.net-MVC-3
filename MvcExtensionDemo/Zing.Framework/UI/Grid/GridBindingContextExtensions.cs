using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Framework.Mvc.Extensions;

namespace Zing.Framework.UI
{
    public static class GridBindingContextExtensions
    {
        public static T GetGridParameter<T>(this IGridBindingContext context, string key)
        {
            return context.Controller.ValueOf<T>(context.Prefix(key));
        }
    }
}
