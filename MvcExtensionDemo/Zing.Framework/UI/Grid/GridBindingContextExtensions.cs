﻿// (c) Copyright 2002-2010 Telerik 
// This source is subject to the GNU General Public License, version 2
// See http://www.gnu.org/licenses/gpl-2.0.html. 
// All other rights reserved.

namespace Zing.Framework.UI
{
    using Zing.Framework.Utility.Extensions;

    public static class GridBindingContextExtensions
    {
        public static T GetGridParameter<T>(this IGridBindingContext context, string key)
        {
            return context.Controller.ValueOf<T>(context.Prefix(key));
        }
    }
}