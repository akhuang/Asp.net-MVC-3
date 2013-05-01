using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Zing.Framework.Utility;
using Zing.Framework.Utility.Extensions;

namespace Zing.Framework.UI
{
    public class GridBoundColumn<TModel, TValue> : GridColumnBase<TModel>, IGridBoundColumn where TModel : class
    {
        public GridBoundColumn(Grid<TModel> grid, Expression<Func<TModel, TValue>> expression)
            : base(grid)
        {
            Guard.IsNotNull(expression, "expression");

            Member = expression.MemberWithoutInstance();
        }
    }
}
