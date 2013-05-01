using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI.Grid.Html
{
    public interface IGridFunctionalSectionBuilder
    {
        //IHtmlNode CreateToolBar(GridToolBarData toolBarData);

        //IHtmlNode CreateGroupHeader(GridGroupingData renderingData);

        IHtmlNode CreatePager(GridPagerData pagerSection);

        IHtmlNode CreateRefreshButton(GridPagerData pagerData);
    }
}
