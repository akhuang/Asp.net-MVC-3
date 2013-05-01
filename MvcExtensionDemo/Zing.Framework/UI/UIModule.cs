using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Zing.Framework.UI.Grid.Html;

namespace Zing.Framework.UI
{
    public class UIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<GridHtmlBuilder>().As<IGridHtmlBuilder>();
            builder.RegisterType<ViewComponentFactory>();
            builder.RegisterType<GridHtmlBuilderFactory>().As<IGridHtmlBuilderFactory>();

            builder.RegisterType<HtmlHelper>();
            //builder.RegisterType<MembershipRepository>().As<IMembershipRepository>();
        }
    }
}
