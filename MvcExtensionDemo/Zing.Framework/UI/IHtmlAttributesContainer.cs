using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI
{
    /// <summary>
    /// Defines whether one navigation item can have content output immediately
    /// </summary>
    public interface IHtmlAttributesContainer
    {
        /// <summary>
        /// The HtmlAttributes applied to objects which can have child items
        /// </summary>
        IDictionary<string, object> HtmlAttributes
        {
            get;
        }
    }
}
