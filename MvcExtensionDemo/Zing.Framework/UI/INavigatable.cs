﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace Zing.Framework.UI
{
    /// <summary>
    /// Defines an interface that supports navigation.
    /// </summary>
    public interface INavigatable
    {
        /// <summary>
        /// Gets or sets the name of the route.
        /// </summary>
        /// <value>The name of the route.</value>
        string RouteName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the controller.
        /// </summary>
        /// <value>The name of the controller.</value>
        string ControllerName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the action.
        /// </summary>
        /// <value>The name of the action.</value>
        string ActionName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the route values.
        /// </summary>
        /// <value>The route values.</value>
        RouteValueDictionary RouteValues
        {
            get;
        }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        string Url
        {
            get;
            set;
        }
    }
}
