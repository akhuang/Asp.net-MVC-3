using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zing.Framework.UI;
using Zing.Modules.Users.ViewModels;

namespace MvcExtensionDemo.Controllers
{
    public class UserData
    {
        public IEnumerable<UserViewModel> List
        {
            get;
            set;
        }
    }
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            IEnumerable<UserViewModel> list = new List<UserViewModel>()
            {
                new UserViewModel(){ UserName="phoenix1", Email="Phoenix@gmail.com"},
new UserViewModel(){UserName="phoenix", Email="Phoenix@gmail.com"}
            };

            return View(new UserData() { List = list });
        }

        [GridAction]
        public ActionResult GetUsers()
        {
            IEnumerable<UserViewModel> list = new List<UserViewModel>()
            {
                new UserViewModel(){ UserName="phoenix1", Email="Phoenix@gmail.com"},
new UserViewModel(){UserName="phoenix", Email="Phoenix@gmail.com"}
            };

            return View(new UserData() { List = list });

        }

    }
}
