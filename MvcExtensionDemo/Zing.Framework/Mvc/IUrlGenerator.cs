// (c) Copyright 2002-2010 Telerik 
// This source is subject to the GNU General Public License, version 2
// See http://www.gnu.org/licenses/gpl-2.0.html. 
// All other rights reserved.

namespace Zing.Framework.Mvc
{
    using System.Web.Routing;
    using Zing.Framework.UI;

    public interface IUrlGenerator
    {
        string Generate(RequestContext requestContext, INavigatable navigationItem);
        string Generate(RequestContext requestContext, INavigatable navigationItem, RouteValueDictionary routeValues);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "Should accept url as string.")]
        string Generate(RequestContext requestContext, string url);
    }
}