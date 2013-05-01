using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI.Grid.Html
{
    public interface IGridItemCreatorData
    {
        bool HasDetailView
        {
            get;
        }

        GridItemMode Mode
        {
            get;
        }

        Func<object> CreateNewDataItem
        {
            get;
            set;
        }

        bool ShowGroupFooter
        {
            get;
            set;
        }

        int GroupsCount
        {
            get;
            set;
        }
    }
}
