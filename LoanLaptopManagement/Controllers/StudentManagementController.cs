using DBModels;
using LoanLaptopManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanLaptopManagement.Controllers
{
    public class StudentManagementController : Controller
    {
        // GET: StudentManagement
        public ActionResult Index()
        {
            if (!Check.isLogedIn()) return RedirectToAction("Index", "Login");
            return View(new StudentModel().getStudentList());
        }
        public ActionResult Detail(string id)
        {
            if (!Check.isLogedIn()) return RedirectToAction("Index", "Login");
            if (id == null)
            {
                return RedirectToAction("Index", "StudentManagement");
            }
            return View(new StudentModel().getStudentById(id));
        }
    }
}