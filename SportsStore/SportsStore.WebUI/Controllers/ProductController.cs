using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public int PageSize = 4;

        private IProductRepository productRep;
        public ProductController(IProductRepository productRepParam)
        {
            productRep = productRepParam;
        }

        public ViewResult List(int page = 1)
        {
            //return View(productRep.Products
            //        .OrderBy(p => p.ProductID)
            //        .Skip((page - 1) * PageSize)
            //        .Take(PageSize)
            //    );

            ProductsListViewModel viewModel = new ProductsListViewModel
            {
                Products = productRep.Products
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = productRep.Products.Count()
                }
            };

            return View(viewModel);
        }
    }
}
