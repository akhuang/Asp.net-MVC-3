using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI.Grid.Html
{
    public class GridHtmlBuilder : IGridHtmlBuilder
    {
        private readonly IGridTableBulderFactory tableBuilderFactory;

        public GridHtmlBuilder(IGridFunctionalSectionBuilder functionalSectionBuilder, IGridDataSectionBuilder dataSectionBuilder, IGridTableBulderFactory tableBuilderFactory)
        {
            this.tableBuilderFactory = tableBuilderFactory;
            FunctionalSectionBuilder = functionalSectionBuilder;
            DataSectionBuilder = dataSectionBuilder;
        }

        protected IGridFunctionalSectionBuilder FunctionalSectionBuilder
        {
            get;
            private set;
        }

        protected IGridDataSectionBuilder DataSectionBuilder
        {
            get;
            private set;
        }


        public IHtmlNode CreateGrid(IDictionary<string, object> htmlAttributes, GridFunctionalData functionalData, GridRenderingData renderingData)
        {
            var div = CreateWrapper(htmlAttributes);

            AppendData(div, renderingData);

            //AppendBottomPager(div, functionalData);

            return div;
        }

        //why virtual?
        protected virtual IHtmlNode CreateWrapper(IDictionary<string, object> htmlAttributes)
        {
            var div = new HtmlElement("div").Attributes(htmlAttributes)
                                        .PrependClass(UIPrimitives.Widget, "t-grid");
            return div;
        }

        protected virtual void AppendData(IHtmlNode div, GridRenderingData renderingData)
        {
            var table = CreateTable(renderingData);
            table.AppendTo(div);

            AppendHeader(table, renderingData);

            //AppendFooter(table, renderingData);

            var tbody = CreateBody(renderingData);
            tbody.AppendTo(table);
        }

        protected virtual IHtmlNode CreateTable(GridRenderingData renderingData)
        {
            var tableBuilder = tableBuilderFactory.CreateDecoratedTableBuilder(renderingData.Columns.Select(c => new GridColData { Width = c.Width, Hidden = c.Hidden }), renderingData);

            return tableBuilder.CreateTable()
                               .Attributes(renderingData.TableHtmlAttributes);
        }

        protected void AppendHeader(IHtmlNode container, GridRenderingData renderingData)
        {
            var thead = CreateHeader(renderingData);
            thead.AppendTo(container);
        }

        protected void AppendFooter(IHtmlNode table, GridRenderingData renderingData)
        {
            //if (renderingData.ShowFooter)
            //{
            var tfoot = CreateFooter(renderingData);
            tfoot.AppendTo(table);
            //}
        }

        protected virtual IHtmlNode CreateHeader(GridRenderingData renderingData)
        {
            var thead = new HtmlElement("thead").AddClass("t-grid-header");

            var tr = DataSectionBuilder.CreateHeader(renderingData);
            tr.AppendTo(thead);

            return thead;
        }

        protected virtual IHtmlNode CreateFooter(GridRenderingData renderingData)
        {
            var tfoot = new HtmlElement("tfoot");

            var tr = DataSectionBuilder.CreateFooter(renderingData);
            tr.AppendTo(tfoot);
            return tfoot;
        }

        protected virtual IHtmlNode CreateBody(GridRenderingData renderingData)
        {
            return DataSectionBuilder.CreateBody(renderingData);
        }

        protected void AppendBottomPager(IHtmlNode div, GridFunctionalData functionalData)
        {
            //if (functionalData.ShowFooter)
            //{
            var pager = new HtmlElement("div").AddClass("t-grid-pager", "t-grid-bottom");

            pager.AppendTo(div);

            AppendRefreshButton(pager, functionalData.PagerData);

            //if (functionalData.ShowBottomPager)
            //{
            CreateBottomPager(functionalData.PagerData).AppendTo(pager);
            //}
            //}
        }

        protected void AppendRefreshButton(IHtmlNode div, GridPagerData pagerData)
        {
            var button = CreateRefreshButton(pagerData);
            button.AppendTo(div);
        }

        protected virtual IHtmlNode CreateBottomPager(GridPagerData pagerData)
        {
            return FunctionalSectionBuilder.CreatePager(pagerData);
        }

        protected virtual IHtmlNode CreateRefreshButton(GridPagerData pagerData)
        {
            return FunctionalSectionBuilder.CreateRefreshButton(pagerData);
        }



    }
}
