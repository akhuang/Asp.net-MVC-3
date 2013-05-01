using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI.Grid.Html
{
    public interface IGridDataSectionBuilder
    {
        IHtmlNode CreateBody(GridRenderingData data);

        IHtmlNode CreateHeader(GridRenderingData data);

        IHtmlNode CreateFooter(GridRenderingData data);
    }
}
