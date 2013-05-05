﻿// (c) Copyright 2002-2010 Telerik 
// This source is subject to the GNU General Public License, version 2
// See http://www.gnu.org/licenses/gpl-2.0.html. 
// All other rights reserved.

namespace Zing.Framework.UI
{
    using System.Collections.Generic;
    using System.Linq;
    using Zing.Framework.Utility.Extensions;
    using Zing.Framework.Mvc;

    class GridColumnSerializer : IGridColumnSerializer
    {
        private readonly IGridColumn column;
        
        public GridColumnSerializer(IGridColumn column)
        {
            this.column = column;
        }

        public virtual IDictionary<string, object> Serialize()
        {
            IDictionary<string, object> result = new Dictionary<string, object>();
            FluentDictionary.For(result)
                  .Add("attr", column.HtmlAttributes.ToAttributeString(), () => column.HtmlAttributes.Any())
                  .Add("title", column.Title)
                  .Add("hidden", column.Hidden, false)
                  .Add("includeInContextMenu", column.IncludeInContextMenu, () => !column.IncludeInContextMenu)
                  .Add("width", column.Width, () => column.Hidden && !string.IsNullOrEmpty(column.Width));

            if (column.ClientTemplate.HasValue())                  
            {
                result.Add("template", Encode(column, column.ClientTemplate));
            }

            if (column.ClientFooterTemplate.HasValue())
            {
                result.Add("footerTemplate", Encode(column, column.ClientFooterTemplate));
            }

            return result;
        }

        protected string Encode(IGridColumn column, string template)
        {
            return column.Grid.IsSelfInitialized ? template.Replace("<", "%3c").Replace(">", "%3e") : template;
        }
    }
}
