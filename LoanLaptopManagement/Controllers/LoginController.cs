using DBModels;
using DBModels.Init;
using LoanLaptopManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanLaptopManagement.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(admin model)
        {
            if (ModelState.IsValid) {
               if (new AdminModel().Login(model.name, model.password))
               {
                    SessionHelper.setSession(new AdminSession() { adminName = model.name });
                    return RedirectToAction("Index", "Home");
               } else
               {
                    ViewBag.loginError = "AdminName hoặc mật khẩu không đúng! Vui lòng thử lại!";
               } 
            }
            return View();
        }
    }
}