using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI.Grid.Html
{
    public interface IGridTableBulderFactory
    {
        IGridTableBuilder CreateTableBuilder(IEnumerable<GridColData> colsData);
        IGridTableBuilder CreateDecoratedTableBuilder(IEnumerable<GridColData> colsData, GridRenderingData renderingData);
    }
}
