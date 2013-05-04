﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;

namespace Zing.Framework.UI
{

    public static class GridControllerExtensions
    {
        public static RouteValueDictionary GridRouteValues(this ControllerBase controller)
        {
            var routeValues = new RouteValueDictionary();

            var values = GetParams(controller.ControllerContext.HttpContext.Request);

            foreach (string key in values.Keys)
            {
                if (key.EndsWith(GridUrlParameters.CurrentPage, StringComparison.OrdinalIgnoreCase) ||
                    key.EndsWith(GridUrlParameters.Filter, StringComparison.OrdinalIgnoreCase) ||
                    key.EndsWith(GridUrlParameters.OrderBy, StringComparison.OrdinalIgnoreCase) ||
                    key.EndsWith(GridUrlParameters.GroupBy, StringComparison.OrdinalIgnoreCase) ||
                    key.EndsWith(GridUrlParameters.PageSize, StringComparison.OrdinalIgnoreCase))
                {
                    routeValues[key] = values[key];
                }
            }

            return routeValues;
        }

        private static IDictionary<string, object> GetParams(HttpRequestBase request)
        {
            var result = new Dictionary<string, object>();
            var unvalidated = request.Unvalidated();
            unvalidated.Form.CopyTo(result);
            unvalidated.QueryString.CopyTo(result);
            return result;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static T ValueOf<T>(this ControllerBase controller, string key)
        {
            ValueProviderResult result;
            bool found = true;

            result = controller.ValueProvider.GetValue(key);
            found = result != null;

            if (found)
            {
                return (T)result.ConvertTo(typeof(T), CultureInfo.CurrentCulture);
            }

            return default(T);
        }
    }
}
