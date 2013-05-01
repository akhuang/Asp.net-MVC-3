using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI.Grid.Fluent
{
    /// <summary>
    /// Defines the fluent interface for configuring bound columns
    /// </summary>
    /// <typeparam name="T">The type of the data item</typeparam>
    public class GridBoundColumnBuilder<T> : GridColumnBuilderBase<IGridBoundColumn, GridBoundColumnBuilder<T>>
        where T : class
    {
        public GridBoundColumnBuilder(IGridBoundColumn column)
            : base(column)
        {

        }
    }
}
