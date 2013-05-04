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
        private IList<SortDescriptor> sortDescriptors;
        private IList<IFilterDescriptor> filterDescriptors;
        private IList<GroupDescriptor> groupDescriptors;

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

        private IEnumerable GetCustomDataSource(IEnumerable dataSource)
        {
            var customDataSourceWrapper = dataSource as IGridCustomGroupingWrapper;
            if (customDataSourceWrapper != null)
            {
                return customDataSourceWrapper.GroupedEnumerable.AsGenericEnumerable().AsQueryable();
            }
            return dataSource;
        }

        public int CurrentPage
        {
            get
            {
                return bindingContext.GetGridParameter<int?>(GridUrlParameters.CurrentPage) ?? bindingContext.CurrentPage;
            }
        }

        public int PageSize
        {
            get
            {
                return bindingContext.GetGridParameter<int?>(GridUrlParameters.PageSize) ?? bindingContext.PageSize;
            }
        }

        public IList<SortDescriptor> SortDescriptors
        {
            get
            {
                if (sortDescriptors == null)
                {
                    var sortExpression = bindingContext.GetGridParameter<string>(GridUrlParameters.OrderBy);

                    if (sortExpression != null)
                    {
                        sortDescriptors = GridDescriptorSerializer.Deserialize<SortDescriptor>(sortExpression);
                    }

                    if (sortDescriptors == null)
                    {
                        sortDescriptors = bindingContext.SortDescriptors;
                    }
                }

                return sortDescriptors;
            }
        }

        public virtual IList<GroupDescriptor> GroupDescriptors
        {
            get
            {
                if (groupDescriptors == null)
                {
                    var groupExpression = bindingContext.GetGridParameter<string>(GridUrlParameters.GroupBy);

                    if (groupExpression != null)
                    {
                        groupDescriptors = GridDescriptorSerializer.Deserialize<GroupDescriptor>(groupExpression);
                    }

                    if (groupDescriptors == null)
                    {
                        groupDescriptors = bindingContext.GroupDescriptors;
                    }
                }

                return groupDescriptors;
            }
        }

        public IList<IFilterDescriptor> FilterDescriptors
        {
            get
            {
                if (filterDescriptors == null)
                {
                    var filterExpression = bindingContext.GetGridParameter<string>(GridUrlParameters.Filter);

                    if (filterExpression != null)
                    {
                        filterDescriptors = FilterDescriptorFactory.Create(filterExpression);
                    }

                    if (filterDescriptors == null)
                    {
                        filterDescriptors = bindingContext.FilterDescriptors.Cast<IFilterDescriptor>().ToList();
                    }
                }

                return filterDescriptors;
            }
        }

        public int PageCount
        {
            get
            {
                EnsureDataSourceIsProcessed();

                var pageSize = PageSize;

                if ((totalCount == 0) || (pageSize == 0))
                {
                    return 1;
                }

                return (totalCount + pageSize - 1) / pageSize;
            }
        }
    }
}
