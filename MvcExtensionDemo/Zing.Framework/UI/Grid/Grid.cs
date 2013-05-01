using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;
using Zing.Framework.UI.Grid.Html;

namespace Zing.Framework.UI
{
    public class Grid<T> : ViewComponentBase where T : class
    {
        private readonly IGridHtmlBuilderFactory htmlBuilderFactory;

        public Grid(ViewContext viewContext, IGridHtmlBuilderFactory htmlBuilderFactory)
            : base(viewContext)
        {
            this.htmlBuilderFactory = htmlBuilderFactory;

            Columns = new List<GridColumnBase<T>>();

            TableHtmlAttributes = new RouteValueDictionary();
        }

        public IList<GridColumnBase<T>> Columns
        {
            get;
            private set;
        }

        public IList<GridColumnBase<T>> VisibleColumns
        {
            get
            {
                return Columns.Where(c => c.Visible).ToList();
            }
        }

        public IDictionary<string, object> TableHtmlAttributes
        {
            get;
            private set;
        }

        protected override void WriteHtml(HtmlTextWriter writer)
        {
            //writer.WriteLine("text from Grid");
            //writer.WriteLine(Name);

            var builder = htmlBuilderFactory.CreateBuilder(false);

            var renderingData = CreateRenderingData();

            var functionalData = CreateFunctionalData();

            var container = builder.CreateGrid(HtmlAttributes, functionalData, renderingData);

            container.WriteTo(writer);

            base.WriteHtml(writer);
        }


        private GridRenderingData CreateRenderingData()
        {
            var renderingData = new GridRenderingData
            {
                TableHtmlAttributes = TableHtmlAttributes,
                //DataKeyStore = DataKeyStore,
                //HtmlHelper = new GridHtmlHelper<T>(ViewContext, DataKeyStore),
                //UrlBuilder = UrlBuilder,
                //DataSource = DataProcessor.ProcessedDataSource,
                Columns = VisibleColumns.Cast<IGridColumn>(),
                //GroupMembers = DataProcessor.GroupDescriptors.Select(g => g.Member),
                //Mode = CurrentItemMode,
                //EditMode = Editing.Mode,
                //HasDetailView = HasDetailView,
                //Colspan = Colspan - Columns.Count(column => column.Hidden),
                //DetailViewTemplate = MapDetailViewTemplate(HasDetailView ? DetailView.Template : null),
                //NoRecordsTemplate = FormatNoRecordsTemplate(),
                //Localization = Localization,
                //ScrollingHeight = Scrolling.Height,
                //EditFormHtmlAttributes = Editing.FormHtmlAttributes,
                //ShowFooter = Footer && VisibleColumns.Any(c => c.FooterTemplate.HasValue() || c.ClientFooterTemplate.HasValue()),
                //AggregateResults = DataProcessor.AggregatesResults,
                //Aggregates = Aggregates.SelectMany(aggregate => aggregate.Aggregates),
                //GroupsCount = DataProcessor.GroupDescriptors.Count,
                //ShowGroupFooter = Aggregates.Any() && VisibleColumns.OfType<IGridBoundColumn>().Any(c => c.GroupFooterTemplate.HasValue()),
                //PopUpContainer = new HtmlFragment(),

                //CreateNewDataItem = () => Editing.DefaultDataItem(),
                //InsertRowPosition = Editing.InsertRowPosition,
                //EditTemplateName = Editing.TemplateName,
                //AdditionalViewData = Editing.AdditionalViewData,
                //FormId = ViewContext.FormContext.FormId,

                //Callback = RowActionCallback
            };

            //if (RowTemplate.HasValue())
            //{
            //    renderingData.RowTemplate = (dataItem, container) => RowTemplate.Apply((T)dataItem, container);
            //}

            return renderingData;
        }

        private GridFunctionalData CreateFunctionalData()
        {
            return new GridFunctionalData
            {
                //ShowTopPager = Paging.Enabled && (Paging.Position == GridPagerPosition.Top || Paging.Position == GridPagerPosition.Both),
                //ShowBottomPager = Paging.Enabled && (Paging.Position == GridPagerPosition.Bottom || Paging.Position == GridPagerPosition.Both),
                //ShowTopToolBar = ToolBar.Enabled && (ToolBar.Position == GridToolBarPosition.Top || ToolBar.Position == GridToolBarPosition.Both),
                //ShowBottomToolBar = ToolBar.Enabled && (ToolBar.Position == GridToolBarPosition.Bottom || ToolBar.Position == GridToolBarPosition.Both),
                //ShowGroupHeader = Grouping.Enabled && Grouping.Visible,
                //PagerData = CreatePagerData(),
                //GroupingData = CreateGroupingData(),
                //ToolBarData = CreateToolbarData(),
                //ShowFooter = Footer
            };
        }
    }
}
