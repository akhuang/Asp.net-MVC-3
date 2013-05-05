using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Zing.Framework.Localize;
using Zing.Framework.Mvc;
using Zing.Framework.UI.Html;

namespace Zing.Framework.UI
{
    public class UIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<ClientSideObjectWriterFactory>().As<IClientSideObjectWriterFactory>();
            builder.RegisterType<VirtualPathProviderWrapper>().As<IVirtualPathProvider>();
            builder.RegisterType<PathResolver>().As<IPathResolver>();

            builder.RegisterType<UrlGenerator>().As<IUrlGenerator>();

            builder.RegisterType<LocalizationService>().As<ILocalizationService>();
            builder.RegisterType<LocalizationServiceFactory>().As<ILocalizationServiceFactory>();
            builder.RegisterType<GridHtmlBuilder>().As<IGridHtmlBuilder>();
            builder.RegisterType<GridGroupHeaderBuilder>().As<IGridGroupHeaderBuilder>();
            builder.RegisterType<GridToolBarBuilder>().As<IGridToolBarBuilder>();
            builder.RegisterType<GridPagerButtonFactory>().As<IGridPagerButtonFactory>();
            builder.RegisterType<GridPagerNumericSectionBuilder>().As<IGridPagerNumericSectionBuilder>();
            builder.RegisterType<GridPagerInputSectionBuilder>().As<IGridPagerInputBuilder>();
            builder.RegisterType<GridPagerPageSizeSection>().As<IGridPagerPageSizeSection>();




            builder.RegisterType<ViewComponentFactory>();
            builder.RegisterType<GridHtmlBuilderFactory>().As<IGridHtmlBuilderFactory>();
            builder.RegisterType<GridDataSectionBuilder>().As<IGridDataSectionBuilder>();
            builder.RegisterType<GridFunctionalSectionBuilder>().As<IGridFunctionalSectionBuilder>();
            builder.RegisterType<GridTableBuilderFactory>().As<IGridTableBulderFactory>();
            builder.RegisterType<GridPagerBuilder>().As<IGridPagerBuilder>();
            builder.RegisterType<GridPagerSectionsBuilder>().As<IGridPagerSectionsBuilder>();
            builder.RegisterType<GridPagerRefreshBuilder>().As<IGridPagerRefreshBuilder>();
            builder.RegisterType<GridPagerStatusBuilder>().As<IGridPagerStatusBuilder>();
            builder.RegisterType<GridPagerPagingSectionsBuilder>().As<IGridPagerPagingSectionsBuilder>();
            builder.RegisterType<GridRowBuilderFactory>().As<IGridRowBuilderFactory>();
            builder.RegisterType<GridItemCreatorFactory>().As<IGridItemCreatorFactory>();
            builder.RegisterType<GridDataKeyComparer>().As<IGridDataKeyComparer>();
            builder.RegisterType<GridCellBuilderFactory>().As<IGridCellBuilderFactory>();
            builder.RegisterType<GridRowBuilderDecoratorProvider>().As<IGridRowBuilderDecoratorProvider>();
            builder.RegisterType<HtmlHelper>();


            //builder.RegisterType<MembershipRepository>().As<IMembershipRepository>();
        }
    }
}
