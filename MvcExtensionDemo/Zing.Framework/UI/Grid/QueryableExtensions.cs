using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Zing.Framework.Utility.Extensions;

namespace Zing.Framework.UI
{
    public static class QueryableExtensions
    {
        internal static GridModel ToGridModel(this GridDataTableWrapper enumerable, int page, int pageSize, IList<SortDescriptor> sortDescriptors, IEnumerable<IFilterDescriptor> filterDescriptors,
          IEnumerable<GroupDescriptor> groupDescriptors)
        {
            //if (filterDescriptors.Any())
            //{
            //    var dataTable = enumerable.Table;
            //    filterDescriptors.SelectMemberDescriptors()
            //        .Each(f => f.MemberType = GetFieldByTypeFromDataColumn(dataTable, f.Member));
            //}

            //if (groupDescriptors.Any())
            //{
            //    var dataTable = enumerable.Table;
            //    groupDescriptors.Each(g => g.MemberType = GetFieldByTypeFromDataColumn(dataTable, g.Member));
            //}

            return enumerable.AsQueryable().ToGridModel(page, pageSize, sortDescriptors, filterDescriptors, groupDescriptors);
        }

        public static GridModel ToGridModel(this IQueryable queryable, int page, int pageSize, IList<SortDescriptor> sortDescriptors, IEnumerable<IFilterDescriptor> filterDescriptors,
        IEnumerable<GroupDescriptor> groupDescriptors)
        {
            IQueryable data = queryable;


            if (queryable.ElementType.IsDynamicObject())
            {
                var firstItem = queryable.Cast<object>().FirstOrDefault();
                if (firstItem != null)
                {
                    //if (filterDescriptors.Any())
                    //{
                    //    filterDescriptors.SetMemberTypeFrom(firstItem);
                    //}

                    //if (groupDescriptors.Any())
                    //{
                    //    groupDescriptors.SetMemberTypeFrom(firstItem);
                    //}
                }
            }

            //if (filterDescriptors.Any())
            //{
            //    data = data.Where(filterDescriptors);
            //}

            GridModel result = new GridModel();

            result.Total = data.Count();
            IList<SortDescriptor> temporarySortDescriptors = new List<SortDescriptor>();

            if (!sortDescriptors.Any() && queryable.Provider.IsEntityFrameworkProvider())
            {
                // The Entity Framework provider demands OrderBy before calling Skip.
                SortDescriptor sortDescriptor = new SortDescriptor
                {
                    Member = queryable.ElementType.FirstSortableProperty()
                };
                sortDescriptors.Add(sortDescriptor);
                temporarySortDescriptors.Add(sortDescriptor);
            }

            if (groupDescriptors.Any())
            {
                groupDescriptors.Reverse().Each(groupDescriptor =>
                {
                    SortDescriptor sortDescriptor = new SortDescriptor
                    {
                        Member = groupDescriptor.Member,
                        SortDirection = groupDescriptor.SortDirection
                    };

                    sortDescriptors.Insert(0, sortDescriptor);
                    temporarySortDescriptors.Add(sortDescriptor);
                });
            }

            if (sortDescriptors.Any())
            {
                data = data.Sort(sortDescriptors);
            }

            var notPagedData = data;

            data = data.Page(page - 1, pageSize);

            if (groupDescriptors.Any())
            {
                data = data.GroupBy(notPagedData, groupDescriptors);
            }

            result.Data = data;

            temporarySortDescriptors.Each(sortDescriptor => sortDescriptors.Remove(sortDescriptor));

            return result;
        }

        /// <summary> Returns the number of elements in a sequence.</summary>
        /// <returns> The number of elements in the input sequence.</returns>
        /// <param name="source">
        /// The <see cref="IQueryable" /> that contains the elements to be counted.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="source" /> is null.</exception>
        public static int Count(this IQueryable source)
        {
            if (source == null) throw new ArgumentNullException("source");
            return source.Provider.Execute<int>(
                Expression.Call(
                    typeof(Queryable), "Count",
                    new Type[] { source.ElementType }, source.Expression));
        }

        /// <summary>
        /// Sorts the elements of a sequence using the specified sort descriptors.
        /// </summary>
        /// <param name="source">A sequence of values to sort.</param>
        /// <param name="sortDescriptors">The sort descriptors used for sorting.</param>
        /// <returns>
        /// An <see cref="IQueryable" /> whose elements are sorted according to a <paramref name="sortDescriptors"/>.
        /// </returns>
        public static IQueryable Sort(this IQueryable source, IEnumerable<SortDescriptor> sortDescriptors)
        {
            var builder = new SortDescriptorCollectionExpressionBuilder(source, sortDescriptors);
            return builder.Sort();
        }
    }
}
