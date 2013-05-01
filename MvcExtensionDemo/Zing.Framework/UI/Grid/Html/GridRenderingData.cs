using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI.Grid.Html
{
    public class GridRenderingData
    {

        //public IGridDataKeyStore DataKeyStore
        //{
        //    get;
        //    set;
        //}
        public IGridHtmlHelper HtmlHelper
        {
            get;
            set;
        }

        public bool ShowFooter
        {
            get;
            set;
        }

        public IEnumerable DataSource
        {
            get;
            set;
        }

        public IEnumerable<IGridColumn> Columns
        {
            get;
            set;
        }

        public IDictionary<string, object> TableHtmlAttributes
        {
            get;
            set;
        }

        public bool HasDetailView
        {
            get;
            set;
        }
    }
}
