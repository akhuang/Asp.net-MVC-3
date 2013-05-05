﻿// (c) Copyright 2002-2009 Telerik 
// This source is subject to the GNU General Public License, version 2
// See http://www.gnu.org/licenses/gpl-2.0.html. 
// All other rights reserved.
namespace Zing.Framework.UI
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    internal class GridDynamicDataKey : IGridDataKey<object>
    {
        public GridDynamicDataKey(string memberName, Expression<Func<object, object>> expression)
        {
            RouteKey = "id";
            Name = memberName;
            Expression = expression;
            Value = expression.Compile();
        }

        public string Name
        {
            get;
            private set;
        }

        public string RouteKey
        {
            get;
            set;
        }

        public Func<object, object> Value
        {
            get;
            private set;
        }

        public Expression<Func<object, object>> Expression
        {
            get;
            private set;
        }



        public object GetValue(object dataItem)
        {
            try
            {
                return Value(dataItem);
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                return null;
            }
        }

        public string HiddenFieldHtml(HtmlHelper<object> htmlHelper)
        {
            return htmlHelper.Hidden(Name, null, new { id = "" }).ToString();
        }

    }
}