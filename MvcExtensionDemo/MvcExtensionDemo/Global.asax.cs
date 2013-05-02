using Autofac;
using MvcExtensionDemo.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using Zing.Modules.Users;
using Zing.Framework.UI;
using MvcExtensions;

namespace MvcExtensionDemo
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public MvcApplication()
        {
        }

        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule(new UsersModule());
            builder.RegisterModule(new UIModule());

            FluentMetadataConfiguration.RegisterEachConfigurationWithContainer(r => builder.RegisterType(r.MetadataConfigurationType).As(r.InterfaceType));

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            FluentMetadataConfiguration.Register();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}