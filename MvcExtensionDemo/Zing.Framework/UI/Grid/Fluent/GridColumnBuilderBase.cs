using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Framework.Mvc;
using Zing.Framework.Utility;

namespace Zing.Framework.UI.Grid.Fluent
{
    /// <summary>
    /// Defines the fluent interface for configuring columns.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TColumnBuilder">The type of the column builder.</typeparam>
    public abstract class GridColumnBuilderBase<TColumn, TColumnBuilder> : IHideObjectMembers
        where TColumnBuilder : GridColumnBuilderBase<TColumn, TColumnBuilder>
        where TColumn : IGridColumn
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GridColumnBuilderBase&lt;T, TColumnBuilder&gt;"/> class.
        /// </summary>
        /// <param name="column">The column.</param>
        protected GridColumnBuilderBase(TColumn column)
        {
            Guard.IsNotNull(column, "column");

            Column = column;
        }

        /// <summary>
        /// Gets or sets the column.
        /// </summary>
        /// <value>The column.</value>
        public TColumn Column
        {
            get;
            private set;
        }
    }
}
