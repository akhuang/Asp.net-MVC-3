using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.UI;

namespace Zing.Framework.UI
{
    public abstract class ViewComponentBase : IViewComponent
    {
        public ViewComponentBase(ViewContext viewContext)
        {
            ViewContext = viewContext;
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Id
        {
            get { return Name; }
        }

        public ViewContext ViewContext
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the HTML attributes.
        /// </summary>
        /// <value>The HTML attributes.</value>
        public IDictionary<string, object> HtmlAttributes
        {
            get;
            private set;
        }

        public string ToHtmlString()
        {
            using (var output = new StringWriter())
            {
                HtmlTextWriter writer = new HtmlTextWriter(output);
                //writer.WriteLine("text from ViewComponentBuilderBase");
                WriteHtml(writer);
                return output.ToString();
            }
        }


        /// <summary>
        /// Writes the HTML.
        /// </summary>
        protected virtual void WriteHtml(HtmlTextWriter writer)
        {

        }
    }
}
