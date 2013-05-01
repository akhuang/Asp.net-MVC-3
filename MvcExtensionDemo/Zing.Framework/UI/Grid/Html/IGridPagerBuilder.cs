using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI.Grid.Html
{
    public interface IGridPagerBuilder
    {
        IHtmlNode Create(GridPagerData section);

        IHtmlNode CreateRefreshButton(GridPagerData pagerData);
    }

}
