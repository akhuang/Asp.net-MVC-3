using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.UI;
using Zing.Framework.UI.Grid.Html;

namespace Zing.Framework.UI
{
    public class Grid<T> : ViewComponentBase
    {
        private readonly IGridHtmlBuilderFactory htmlBuilderFactory;

        public Grid(ViewContext viewContext, IGridHtmlBuilderFactory htmlBuilderFactory)
            : base(viewContext)
        {
            this.htmlBuilderFactory = htmlBuilderFactory;

            Columns = new List<GridColumnBase>();
        }

        public IList<GridColumnBase> Columns
        {
            get;
            private set;
        }

        protected override void WriteHtml(HtmlTextWriter writer)
        {
            writer.WriteLine("text from Grid");
            writer.WriteLine(Name);
            base.WriteHtml(writer);
        }
    }
}
