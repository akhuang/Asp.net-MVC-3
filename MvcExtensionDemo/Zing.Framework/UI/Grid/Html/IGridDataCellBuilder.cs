using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI.Grid.Html
{
    public interface IGridDataCellBuilder //: IGridDecoratableCellBuilder
    {
        string Html
        {
            get;
            set;
        }

        IHtmlNode CreateCell(object dataItem);

        IDictionary<string, object> HtmlAttributes
        {
            get;
        }

        Action<object> Callback
        {
            get;
            set;
        }
    }
}
