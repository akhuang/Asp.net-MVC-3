using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Zing.Framework.Utility;
using Zing.Framework.Utility.Extensions;

namespace Zing.Framework.UI
{
    public class GridDataProcessor
    {
        private readonly IGridBindingContext bindingContext;
        private IEnumerable processedDataSource;
        private bool dataSourceIsProcessed;
        private int totalCount;


        public GridDataProcessor(IGridBindingContext bindingContext)
        {
            Guard.IsNotNull(bindingContext, "bindingContext");
            this.bindingContext = bindingContext;
        }

        public int Total
        {
            get
            {
                EnsureDataSourceIsProcessed();
                return totalCount;
            }
        }

        private void EnsureDataSourceIsProcessed()
        {
            if (dataSourceIsProcessed)
            {
                return;
            }

            if (bindingContext.DataSource == null)
            {
                dataSourceIsProcessed = true;
                return;
            }

            if (!bindingContext.EnableCustomBinding)
            {
                GridModel model;

                //if (GroupDescriptors.Any() && Aggregates.Any())
                //{
                //    GroupDescriptors.Each(g => g.AggregateFunctions.AddRange(Aggregates));
                //}

                var dataTableEnumerable = bindingContext.DataSource as GridDataTableWrapper;
                if (dataTableEnumerable != null)
                {
                    model = dataTableEnumerable.ToGridModel(CurrentPage, PageSize, SortDescriptors, FilterDescriptors, GroupDescriptors);
                }
                else
                {
                    var dataSource = bindingContext.DataSource.AsQueryable();
                    model = dataSource.ToGridModel(CurrentPage, PageSize, SortDescriptors, FilterDescriptors, GroupDescriptors);
                }

                totalCount = model.Total;
                processedDataSource = model.Data.AsGenericEnumerable();
            }
            else
            {
                processedDataSource = GetCustomDataSource(bindingContext.DataSource);
                totalCount = bindingContext.Total;
            }

            dataSourceIsProcessed = true;
        }
    }
}
