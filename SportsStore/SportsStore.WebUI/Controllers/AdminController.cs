using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository repository;
        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Edit(int productId)
        {
            return View(repository.Products.FirstOrDefault(p => p.ProductID == productId));
        }

        [HttpPost]
        public ActionResult Edit(Product model)
        {
            //repository.Products.
            if (ModelState.IsValid)
            {
                repository.SaveProduct(model);
                TempData["message"] = string.Format("{0} has been saved", model.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
    }
}
