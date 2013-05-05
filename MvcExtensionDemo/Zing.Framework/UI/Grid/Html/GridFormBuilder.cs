// (c) Copyright 2002-2009 Telerik 
// This source is subject to the GNU General Public License, version 2
// See http://www.gnu.org/licenses/gpl-2.0.html. 
// All other rights reserved.
namespace Zing.Framework.UI.Html
{
    using System.Collections.Generic;
    using Zing.Framework.Mvc;
    
    public class GridFormBuilder : IGridFormBuilder
    {
        private readonly IDictionary<string, object> htmlAttributes;

        public GridFormBuilder(IDictionary<string, object> htmlAttributes)
        {
            this.htmlAttributes = htmlAttributes;
        }

        public IHtmlNode CreateForm()
        {
            var form = new HtmlElement("form")
                        .Attribute("method", "post")
                        .Attributes(htmlAttributes);
                        
            return form;
        }
    }
}