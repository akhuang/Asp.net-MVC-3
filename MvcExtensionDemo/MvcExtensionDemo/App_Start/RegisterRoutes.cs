using MvcExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcExtensionDemo.App_Start
{
    public class RegisterRoutes : RegisterRoutesBase
    {
        public RegisterRoutes(RouteCollection routes)
            : base(routes)
        {
        }

        protected override void Register()
        {
            Routes.IgnoreRoute("favicon.ico");
            Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            Routes.MapRoute("Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}