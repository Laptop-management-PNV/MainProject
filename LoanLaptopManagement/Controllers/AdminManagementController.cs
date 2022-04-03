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
    public class AdminManagementController : Controller
    {
        public ActionResult Index()
        {
            if (!Check.isLogedIn()) return RedirectToAction("Index", "Login");
            return View(new AdminModel().getAdminList(SessionHelper.getSession().adminName));
        }
        [HttpGet]
        public ActionResult Create()
        {
            if (!Check.isLogedIn()) return RedirectToAction("Index", "Login");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(admin model)
        {
            if (ModelState.IsValid)
            {
                if (new AdminModel().isDuplicated(model.name))
                {
                    ViewBag.errorMessage = "Đã tồn tại tài khoản này!";
                }
                else
                {
                    try
                    {
                        new AdminModel().Create(model.name, model.password, model.permission);
                        ViewBag.message = "Tạo mới thành công!";
                    } catch
                    {
                        ViewBag.errorMessage = "Xảy ra lỗi! Vui lòng thử lại!";
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(string adminName)
        {
            if (!Check.isLogedIn()) return RedirectToAction("Index", "Login");
            if (adminName == null)
            {
                return RedirectToAction("Index", "AdminManagement");
            }
            return View(new AdminModel().getAdminByName(adminName));
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collector)
        {
            var password = collector["password"];
            if (password == "")
            {
                ViewBag.errorMessage = "Chưa nhập mật khẩu";
            }
            else
            {
                var adminModel = new AdminModel();
                if (adminModel.Login(SessionHelper.getSession().adminName, password))
                {
                    try
                    {
                        adminModel.Delete(id);
                        return RedirectToAction("Index", "AdminManagement");
                    }
                    catch (Exception ex)
                    {
                        ViewBag.errorMessage = ex.ToString();//"Có lỗi xảy ra! Vui lòng thử lại!";
                    }
                } else
                {
                    ViewBag.errorMessage = "Sai mật khẩu! Vui lòng thử lại!";
                }
            }
            return View(new AdminModel().getAdminByName(id));
        }
        public ActionResult Active(string adminName)
        {
            if (!Check.isLogedIn()) return RedirectToAction("Index", "Login");
            if (adminName == null)
            {
                return RedirectToAction("Index", "AdminManagement");
            }
            return View(new AdminModel().getAdminByName(adminName));
        }
        [HttpPost]
        public ActionResult Active(string id, FormCollection collector)
        {
            var password = collector["password"];
            if (password == "")
            {
                ViewBag.errorMessage = "Chưa nhập mật khẩu";
            }
            else
            {
                var adminModel = new AdminModel();
                if (adminModel.Login(SessionHelper.getSession().adminName, password))
                {
                    try
                    {
                        adminModel.Active(id);
                        return RedirectToAction("Index", "AdminManagement");
                    }
                    catch (Exception ex)
                    {
                        ViewBag.errorMessage = ex.ToString();//"Có lỗi xảy ra! Vui lòng thử lại!";
                    }
                }
                else
                {
                    ViewBag.errorMessage = "Sai mật khẩu! Vui lòng thử lại!";
                }
            }
            return View(new AdminModel().getAdminByName(id));
        }
    }
}