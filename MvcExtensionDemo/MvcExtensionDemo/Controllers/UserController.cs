using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zing.Modules.Users.Services;
using Zing.Modules.Users.ViewModels;
using Zing.Modules.Users.Models;
using Zing.Framework.Logging;

namespace MvcExtensionDemo.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public ILogger Logger
        {
            get;
            set;
        }

        public UserController(IUserService userService)
        {
            _userService = userService;
            Logger = NullLogger.Instance;
        }
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            Logger.Debug("kjfkdjkfj");
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            try
            {
                Logger.Debug("kjfkdjkfj");
                // TODO: Add insert logic here
                UserEntity userInfo = new UserEntity()
                {
                    UserName = model.UserName,
                    NormalizedUserName = model.UserName,
                    Password = model.UserPassword
                };
                _userService.Add(userInfo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /User/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
