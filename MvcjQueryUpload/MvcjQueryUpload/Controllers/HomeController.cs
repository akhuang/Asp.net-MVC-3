using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcjQueryUpload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Upload(string key1)
        {
            HttpPostedFileBase hp = Request.Files["pic"];

            hp.SaveAs("E:\\temp\\UploadFiles\\a.jpg");

            return new JsonResult();
        }
    }
}
