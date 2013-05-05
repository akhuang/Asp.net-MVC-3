using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Zing.Framework.UI.Html;
using Zing.Framework.Utility;

namespace Zing.Framework.UI
{
    public static class HtmlHelperExtension
    {

        public static ViewComponentFactory<TModel> CRM<TModel>(this HtmlHelper<TModel> helper)
        {
            Guard.IsNotNull(helper, "helper");

            IClientSideObjectWriterFactory clientSideObjectWriterFactory = DependencyResolver.Current.GetService<IClientSideObjectWriterFactory>();

            return new ViewComponentFactory<TModel>(helper, clientSideObjectWriterFactory);

            //return DependencyResolver.Current.GetService<ViewComponentFactory<TModel>>();

            //DependencyResolver.Current.GetService<IGridHtmlBuilder>();
        }


    }

}
