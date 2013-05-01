using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Zing.Framework.UI
{
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
