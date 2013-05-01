using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI.Grid.Html
{
    public interface IGridCellBuilderDecorator
    {
        void Decorate(IHtmlNode td);
    }
}
