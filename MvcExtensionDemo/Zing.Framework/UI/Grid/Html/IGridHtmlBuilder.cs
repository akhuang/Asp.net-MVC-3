using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI.Grid.Html
{
    public interface IGridHtmlBuilder
    {
        IHtmlNode CreateGrid(IDictionary<string, object> htmlAttributes, GridFunctionalData header, GridRenderingData body);
    }
}
