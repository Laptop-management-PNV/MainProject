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
    public class LoanManagementController : Controller
    {
        // GET: LoanManagement
        public ActionResult Index()
        {
            if (!Check.isLogedIn()) return RedirectToAction("Index", "Login");
            return View(new LoanModel().getLoanHistory());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection collector)
        {
            var studentId = collector["studentId"];
            if (studentId == "")
            {
                ViewBag.errorMessage = "Không được để trống!";
            }
            else
            {
                var student = new StudentModel().getStudentById(studentId);
                if (student == null)
                {
                    ViewBag.errorMessage = "Không có sinh viên này!";
                }
                else if (student.loan_status)
                {
                    ViewBag.errorMessage = "Sinh viên đã được mượn rồi!";
                } else
                {
                    return RedirectToAction("SignUp", "LoanManagement", new {id = studentId});
                }
            }
            return View(new LoanModel().getLoanHistory());
        }
        public ActionResult SignUp (string id)
        {
            if (!Check.isLogedIn()) return RedirectToAction("Index", "Login");
            if (id == null) return RedirectToAction("Index", "LoanManagement");
            ViewData["studentId"] = id;
            return View(new loan() { student_id = id});
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(loan model)
        {
            try
            {
                model.loaned_date = DateTime.Now;
                model.admin_name = SessionHelper.getSession().adminName;
                new LoanModel().createLoanDetail(model);
                new StudentModel().updateLoanStatus(model.student_id);
                new LaptopModel().updateLoanStatus(model.laptop_id);
                return RedirectToAction("Index", "LoanManagement");
            } catch (Exception ex)
            {
                ViewBag.errorMessage = model.laptop_id + " " + ex.ToString();
            }
            return View();
        }
    }
}