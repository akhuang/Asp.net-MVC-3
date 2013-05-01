using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI.Grid.Html
{
    public class GridCellBuilderFactory : IGridCellBuilderFactory
    {
        public IGridCellBuilder CreateHeaderCellBuilder(IGridColumn column)
        {
            return column.CreateHeaderBuilder();
        }


        public IGridDataCellBuilder CreateDisplayCellBuilder(IGridColumn column, IGridHtmlHelper htmlHelper)
        {
            return column.CreateDisplayCellBuilder();
        }
    }
}
