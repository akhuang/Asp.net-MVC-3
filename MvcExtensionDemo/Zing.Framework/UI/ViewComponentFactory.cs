namespace Zing.Framework.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using Zing.Framework.Utility.Extensions;
    using Zing.Framework.UI.Fluent;
    using Zing.Framework.UI.Html;
    using Zing.Framework.Mvc;
    using Zing.Framework.Utility;
    using Zing.Framework.Localize;

    /// <summary>
    /// Provides the factory methods for creating Telerik View Components.
    /// </summary>
    public class ViewComponentFactory : IHideObjectMembers
    {
        public ViewComponentFactory(HtmlHelper htmlHelper, IClientSideObjectWriterFactory clientSideObjectWriterFactory)
        {
            Guard.IsNotNull(htmlHelper, "htmlHelper");
            Guard.IsNotNull(clientSideObjectWriterFactory, "clientSideObjectWriterFactory");

            HtmlHelper = htmlHelper;
            ClientSideObjectWriterFactory = clientSideObjectWriterFactory;

        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HtmlHelper HtmlHelper
        {
            get;
            set;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public IClientSideObjectWriterFactory ClientSideObjectWriterFactory
        {
            get;
            private set;
        }

        private ViewContext ViewContext
        {
            get
            {
                return HtmlHelper.ViewContext;
            }
        }

        /// <summary>
        /// Creates a new <see cref="Grid&lt;T&gt;"/> bound to the specified data item type.
        /// </summary>
        /// <example>
        /// <typeparam name="T">The type of the data item</typeparam>
        /// <code lang="CS">
        ///  &lt;%= Html.Telerik().Grid&lt;Order&gt;()
        ///             .Name("Grid")
        ///             .BindTo(Model)
        /// %&gt;
        /// </code>
        /// </example>
        /// <remarks>
        /// Do not forget to bind the grid using the <see cref="GridBuilder{T}.BindTo(System.String)" /> method when using this overload.
        /// </remarks>
        public virtual GridBuilder<T> Grid<T>() where T : class
        {
            return GridBuilder<T>.Create(Register(() => new Grid<T>(ViewContext,
                        ClientSideObjectWriterFactory,
                        DependencyResolver.Current.GetService<IUrlGenerator>(), DependencyResolver.Current.GetService<ILocalizationServiceFactory>().Create("GridLocalization", CultureInfo.CurrentUICulture),
                        DependencyResolver.Current.GetService<IGridHtmlBuilderFactory>()
                    )
                )
            );
        }

        /// <summary>
        /// Creates a new <see cref="Telerik.Web.UI.Grid&lt;T&gt;"/> bound to the specified data source.
        /// </summary>
        /// <typeparam name="T">The type of the data item</typeparam>
        /// <param name="dataSource">The data source.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Telerik().Grid(Model)
        ///             .Name("Grid")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual GridBuilder<T> Grid<T>(IEnumerable<T> dataSource) where T : class
        {
            GridBuilder<T> builder = Grid<T>();

            builder.Component.DataSource = dataSource;

            return builder;
        }

        /// <summary>
        /// Creates a new <see cref="Telerik.Web.UI.Grid&lt;T&gt;"/> bound to a DataTable.
        /// </summary>
        /// <param name="dataSource">DataTable from which the grid instance will be bound</param>
        public virtual GridBuilder<DataRowView> Grid(DataTable dataSource)
        {
            GridBuilder<DataRowView> builder = Grid<DataRowView>();

            builder.Component.DataSource = dataSource.WrapAsEnumerable();

            return builder;
        }

        /// <summary>
        /// Creates a new <see cref="Telerik.Web.UI.Grid&lt;T&gt;"/> bound to a DataView.
        /// </summary>
        /// <param name="dataSource">DataView from which the grid instance will be bound</param>
        public virtual GridBuilder<DataRowView> Grid(DataView dataSource)
        {
            Guard.IsNotNull(dataSource, "dataSource");

            GridBuilder<DataRowView> builder = Grid<DataRowView>();

            builder.Component.DataSource = dataSource.Table.WrapAsEnumerable();

            return builder;
        }

        /// <summary>
        /// Creates a new <see cref="Telerik.Web.UI.Grid&lt;T&gt;"/> bound an item in ViewData.
        /// </summary>
        /// <typeparam name="T">Type of the data item</typeparam>
        /// <param name="dataSourceViewDataKey">The data source view data key.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Telerik().Grid&lt;Order&gt;("orders")
        ///             .Name("Grid")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual GridBuilder<T> Grid<T>(string dataSourceViewDataKey) where T : class
        {
            GridBuilder<T> builder = Grid<T>();

            builder.Component.DataSource = ViewContext.ViewData.Eval(dataSourceViewDataKey) as IEnumerable<T>;

            return builder;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public TViewComponent Register<TViewComponent>(Func<TViewComponent> factory) where TViewComponent : ViewComponentBase
        {
            var component = factory();

            //scriptRegistrarBuilder.ToRegistrar().Register(component);

            return component;
        }
    }

    public class ViewComponentFactory<TModel> : ViewComponentFactory
    {
        private string minimumValidator;
        private string maximumValidator;

        public ViewComponentFactory(HtmlHelper<TModel> htmlHelper, IClientSideObjectWriterFactory clientSideObjectWriterFactory)
            : base(htmlHelper, clientSideObjectWriterFactory)
        {
            this.HtmlHelper = htmlHelper;

            minimumValidator = "min";
            maximumValidator = "max";
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new HtmlHelper<TModel> HtmlHelper
        {
            get;
            set;
        }
    }

}
