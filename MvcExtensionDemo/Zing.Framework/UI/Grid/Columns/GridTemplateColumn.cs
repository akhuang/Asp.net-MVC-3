﻿// (c) Copyright 2002-2010 Telerik 
// This source is subject to the GNU General Public License, version 2
// See http://www.gnu.org/licenses/gpl-2.0.html. 
// All other rights reserved.

namespace Zing.Framework.UI
{
    using Zing.Framework.UI.Html;
    using System;
    using Zing.Framework.Mvc;
    using Zing.Framework.Utility;

    public class GridTemplateColumn<T> : GridColumnBase<T>, IGridTemplateColumn<T> where T : class
    {
        public GridTemplateColumn(Grid<T> grid, Action<T> template) : base(grid)
        {
            Guard.IsNotNull(template, "value");

            Template = template;
        }
        
        public GridTemplateColumn(Grid<T> grid, Func<T, object> template)
            : base(grid)
        {
            Guard.IsNotNull(template, "value");

            InlineTemplate = template;
        }
       
        protected override IGridDataCellBuilder CreateEditBuilderCore(IGridHtmlHelper htmlHelper)
        {
            return CreateDisplayBuilderCore(htmlHelper);
        }
        
        protected override IGridDataCellBuilder CreateInsertBuilderCore(IGridHtmlHelper htmlHelper)
        {
            return CreateDisplayBuilderCore(htmlHelper);
        }
    }
}