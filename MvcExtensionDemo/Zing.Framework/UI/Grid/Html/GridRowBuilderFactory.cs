using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI.Grid.Html
{
    public class GridRowBuilderFactory : IGridRowBuilderFactory
    {
        private readonly IGridCellBuilderFactory cellBuilderFactory;
        private readonly IGridRowBuilderDecoratorProvider decoratorProvider;
        private readonly IGridTableBulderFactory tableBuilderFactory;

        public GridRowBuilderFactory(IGridTableBulderFactory tableBuilderFactory, IGridCellBuilderFactory cellBuilderFactory, IGridRowBuilderDecoratorProvider decoratorProvider)
        {
            this.tableBuilderFactory = tableBuilderFactory;
            this.cellBuilderFactory = cellBuilderFactory;
            this.decoratorProvider = decoratorProvider;

            BuilderRegistry = new Dictionary<GridItemType, Func<GridRenderingData, GridItem, IGridRowBuilder>>{
                { GridItemType.DataRow, CreateDataRowBuilder },
            };
        }

        protected IDictionary<GridItemType, Func<GridRenderingData, GridItem, IGridRowBuilder>> BuilderRegistry
        {
            get;
            private set;
        }

        protected virtual IGridRowBuilder CreateDataRowBuilder(GridRenderingData renderingData, GridItem item)
        {
            //if (renderingData.RowTemplate != null)
            //{
            //    return new GridTemplateRowBuilder(td => renderingData.RowTemplate(item.DataItem, td), renderingData.Colspan);
            //}

            return new GridDataRowBuilder(item.DataItem, renderingData.Columns.Select(column => cellBuilderFactory.CreateDisplayCellBuilder(column, renderingData.HtmlHelper)));
        }

        public virtual IGridRowBuilder CreateHeaderBuilder(GridRenderingData renderingData)
        {
            var builder = new GridRowBuilder(renderingData.Columns.Select(cellBuilderFactory.CreateHeaderCellBuilder));

            var item = new GridItem
            {
                // GroupLevel = renderingData.GroupMembers.Count(),
                Type = GridItemType.HeaderRow
            };

            return decoratorProvider.ApplyDecorators(builder, item, renderingData.HasDetailView);
        }

        public IGridRowBuilder CreateBuilder(GridRenderingData renderingData, GridItem item)
        {
            throw new NotImplementedException();
        }

        public IGridRowBuilder CreateFooterBuilder(GridRenderingData renderingData)
        {
            throw new NotImplementedException();
        }
    }
}
