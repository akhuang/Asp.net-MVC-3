using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Framework.Utility.Extensions;

namespace Zing.Framework.UI.Grid.Html
{
    public interface IGridPagerStatusBuilder
    {
        IHtmlNode Create(GridPagerData pagerSection);
    }

    class GridPagerStatusBuilder : IGridPagerStatusBuilder
    {
        public IHtmlNode Create(GridPagerData pagerSection)
        {
            var firstItemInPage = pagerSection.Total > 0 ? (pagerSection.CurrentPage - 1) * pagerSection.PageSize + 1 : 0;
            var lastItemInPage = Math.Min(pagerSection.PageSize * pagerSection.CurrentPage, pagerSection.Total);

            var itemsText = pagerSection.DisplayingItemsText ?? string.Empty;
            return new HtmlElement("div")
                        .AddClass("t-status-text")
                        .Text(itemsText.FormatWith(firstItemInPage, lastItemInPage, pagerSection.Total));
        }
    }
}
