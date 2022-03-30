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
    public class CreateAdminController : Controller
    {
        // GET: AddNewAdmin
        public ActionResult Index()
        {
            if (!Check.isLogedIn()) return RedirectToAction("Index", "Login");
            return View();
        }
        [HttpPost]
        public ActionResult Index(admin model)
        {
            if (ModelState.IsValid)
            {
                if (new AdminModel().Login(model.name, model.password))
                {
                    ViewBag.errorMessage = "Đã tồn tại tài khoản này!";
                }
                else
                {
                    try
                    {
                        new AdminModel().Create(model.name, model.password);
                        ViewBag.message = "Tạo mới thành công!";
                    } catch
                    {
                        ViewBag.errorMessage = "Xảy ra lỗi! Vui lòng thử lại!";
                    }
                }
            }
            return View();
        }
    }
}