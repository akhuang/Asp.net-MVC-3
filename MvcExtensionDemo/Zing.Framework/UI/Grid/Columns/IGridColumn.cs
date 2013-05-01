using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Framework.UI.Grid.Html;

namespace Zing.Framework.UI
{
    public interface IGridColumn
    {
        string Width
        {
            get;
            set;
        }

        bool Hidden
        {
            get;
            set;
        }

        IGridCellBuilder CreateHeaderBuilder();

        IGridDataCellBuilder CreateDisplayCellBuilder();
    }
}
