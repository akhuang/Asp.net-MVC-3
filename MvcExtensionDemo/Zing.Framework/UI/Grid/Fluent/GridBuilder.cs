using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Framework.Utility;

namespace Zing.Framework.UI.Grid.Fluent
{
    public class GridBuilder<T> : ViewComponentBuilderBase<Grid<T>, GridBuilder<T>> where T : class
    {
        public GridBuilder(Grid<T> component)
            : base(component)
        {

        }

        /// <summary>
        /// Defines the columns of the grid.
        /// </summary>
        /// <param name="configurator">The add action.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Telerik().Grid()
        ///             .Name("Grid")
        ///             .Ajax(ajax => ajax.Action("_RelatedGrids_Orders", "Grid", new { customerID = "ALFKI" }))
        ///             .Columns(columns=>
        ///             {
        ///                 columns.Add(c => c.OrderID).Width(100);
        ///                 columns.Add(c => c.OrderDate).Width(200).Format("{0:dd/MM/yyyy}");
        ///                 columns.Add(c => c.ShipAddress);
        ///                 columns.Add(c => c.ShipCity).Width(200);
        ///             })
        ///             .BindTo((IEnumerable&lt;Order&gt;)ViewData["Orders"]);
        /// %&gt;
        /// </code>
        /// </example>
        public GridBuilder<T> Columns(Action<GridColumnFactory<T>> configurator)
        {
            Guard.IsNotNull(configurator, "addAction");

            GridColumnFactory<T> factory = new GridColumnFactory<T>(Component);

            configurator(factory);

            return this;
        }
    }
}
