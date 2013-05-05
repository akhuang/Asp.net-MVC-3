﻿// (c) Copyright 2002-2011 Telerik 
// This source is subject to the GNU General Public License, version 2
// See http://www.gnu.org/licenses/gpl-2.0.html. 
// All other rights reserved.

namespace Zing.Framework.UI
{
    using System.Collections.Generic;
    using System.Web.Routing;
    using Zing.Framework.Utility.Extensions;

    abstract public class GridCustomCommandBase : GridActionCommandBase, INavigatable
    {
        public GridCustomCommandBase()
        {
            RouteValues = new RouteValueDictionary();
        }

        public string RouteName
        {
            get;
            set;
        }

        public string ControllerName
        {
            get;
            set;
        }

        public string ActionName
        {
            get;
            set;
        }

        public RouteValueDictionary RouteValues
        {
            get;
            private set;
        }

        public string Url
        {
            get;
            set;
        }
        
        public bool Ajax
        {
            get;
            set;
        }

        protected string CssClass()
        {
            var classes = new List<string>();

            if (Ajax)
            {
                classes.Add("t-ajax");
            }

            if (Name.HasValue())
            {
                classes.Add("t-grid-" + Name);
            }

            return string.Join(" ", classes.ToArray());
        }

        public override string Name { get;set; }
    }
}
