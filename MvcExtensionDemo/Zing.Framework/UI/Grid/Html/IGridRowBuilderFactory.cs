using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI.Grid.Html
{
    public interface IGridRowBuilderFactory
    {
        IGridRowBuilder CreateBuilder(GridRenderingData renderingData, GridItem item);

        IGridRowBuilder CreateHeaderBuilder(GridRenderingData renderingData);

        IGridRowBuilder CreateFooterBuilder(GridRenderingData renderingData);
    }
}
