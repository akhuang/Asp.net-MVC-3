using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI.Grid.Html
{
    public class GridHtmlBuilderFactory : IGridHtmlBuilderFactory
    {
        private readonly IGridDataSectionBuilder dataSectionBuilder;

        private readonly IGridFunctionalSectionBuilder functionalSectionBuilder;

        private readonly IGridTableBulderFactory tableBuilderFactory;

        public GridHtmlBuilderFactory(IGridFunctionalSectionBuilder functionalSectionBuilder, IGridDataSectionBuilder dataSectionBuilder,
            IGridTableBulderFactory tableBuilderFactory)
        {
            this.tableBuilderFactory = tableBuilderFactory;
            this.functionalSectionBuilder = functionalSectionBuilder;
            this.dataSectionBuilder = dataSectionBuilder;
        }

        public IGridHtmlBuilder CreateBuilder(bool scrollable)
        {
            return new GridHtmlBuilder(functionalSectionBuilder, dataSectionBuilder, tableBuilderFactory);
        }
    }
}
