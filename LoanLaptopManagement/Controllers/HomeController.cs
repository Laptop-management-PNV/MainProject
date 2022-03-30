using LoanLaptopManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanLaptopManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (!Check.isLogedIn()) return RedirectToAction("Index", "Login");
            return View();
        }
        public ActionResult Logout()
        {
            SessionHelper.setSession(null);
            return RedirectToAction("Index", "Login");
        }
    }
}