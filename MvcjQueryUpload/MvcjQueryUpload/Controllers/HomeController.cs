using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

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

            return Json(new { StatusCode = 1, Message = "Success" }, "text/html");
        }

        public ActionResult NormalUpload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NormalUpload(string companyName)
        {
            HttpPostedFileBase file = Request.Files[0];

            string path = Server.MapPath("/uploadfiles/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            file.SaveAs(path + "a.jpg");

            ViewBag.FilePath = path + "a.jpg";
            return View();
        }
    }
}
