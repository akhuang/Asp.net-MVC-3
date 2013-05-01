﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI.Grid.Html
{
    public class GridDataRowBuilder : IGridRowBuilder
    {
        private readonly object dataItem;

        private readonly IEnumerable<IGridDataCellBuilder> cellBuilders;

        public GridDataRowBuilder(object dataItem, IEnumerable<IGridDataCellBuilder> cellBuilders)
        {
            this.cellBuilders = cellBuilders;
            this.dataItem = dataItem;
        }

        public IHtmlNode CreateRow()
        {
            var tr = new HtmlElement("tr");

            foreach (var cellBuilder in cellBuilders)
            {
                var td = cellBuilder.CreateCell(dataItem);
                td.AppendTo(tr);
            }

            return tr;
        }
    }
}
