// (c) Copyright 2002-2010 Telerik 
// This source is subject to the GNU General Public License, version 2
// See http://www.gnu.org/licenses/gpl-2.0.html. 
// All other rights reserved.

namespace Zing.Framework.UI
{
    using System.Web.Mvc;

    public interface IGridDataKey
    {
        string Name
        {
            get;
        }

        string RouteKey
        {
            get;
            set;
        }

        object GetValue(object dataItem);
    }

    public interface IGridDataKey<T> : IGridDataKey
            where T : class
    {
        string HiddenFieldHtml(HtmlHelper<T> htmlHelper);

    }
}
