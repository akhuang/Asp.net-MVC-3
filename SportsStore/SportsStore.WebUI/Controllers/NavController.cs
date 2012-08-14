using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository productRep;
        public NavController(IProductRepository productRepParam)
        {
            this.productRep = productRepParam;
        }
        //
        // GET: /Nav/

        public PartialViewResult Menu()
        {
            IEnumerable<string> categories = productRep.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return PartialView(categories);
        }

    }
}
