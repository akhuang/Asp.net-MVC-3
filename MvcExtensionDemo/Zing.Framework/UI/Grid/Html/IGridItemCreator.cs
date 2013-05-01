using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI.Grid.Html
{
    public interface IGridItemCreator
    {
        GridItem CreateItem(object dataItem);

        GridItem CreateInsertItem();

        GridItem CreateGroupFooterItem(object dataItem);
    }
}
