using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI.Grid.Html
{
    public interface IGridRowBuilderDecorator : IGridRowBuilder
    {
        void Decorate(IGridRowBuilder rowBuilder, GridItem gridItem, bool hasDetailView);

        bool ShouldDecorate(GridItem gridItem);
    }
}
