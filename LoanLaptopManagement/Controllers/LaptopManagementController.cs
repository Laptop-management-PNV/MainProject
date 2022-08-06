using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBModels;
using DBModels.Init;
using LoanLaptopManagement.Core;
using LoanLaptopManagement.Models;

namespace LoanLaptopManagement.Controllers
{
    public class LaptopManagementController : Controller
    {
        private readonly string[] exts = { ".jpg", ".jpeg", ".png" };
        public ActionResult Index()
        {
            if (!Check.isLogedIn()) return RedirectToAction("Index", "Login");
            return View(new LaptopModel().getLaptopList());
        }

        public ActionResult Create()
        {
            if (!Check.isLogedIn()) return RedirectToAction("Index", "Login");
            return View();
        }
        [HttpPost]
        public ActionResult Create(LaptopAndSpec model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0 && file.ContentLength <= 5200000)
                {
                    var fileExt = Path.GetExtension(file.FileName);
                    if (!Array.Exists(exts, ext => ext.Equals(fileExt))) {
                        ViewBag.fileError = "File extension must be JPG, GPEG or PNG.";
                        return View();
                    }
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine("~/Assets/img", fileName);
                    //file.SaveAs(path);
                    model.img = fileName;   
                }else
                {
                    ViewBag.fileError = "File is required and file size is less than 5MB.";
                    return View();
                }
                try
                {
                    new LaptopModel().Create(model.getLaptop());
                    new SpecModel().Create(model.getSpec());
                    return RedirectToAction("Index", "LaptopManagement");
                }
                catch (Exception ex)
                {
                    ViewBag.errorMessage = "Có lỗi xảy ra!";// ex.ToString();//"Có lỗi xảy ra!";
                }
            }
            return View(model);
        }

        public ActionResult Delete(string id)
        {
            if (!Check.isLogedIn()) return RedirectToAction("Index", "Login");
            if (id == null)
            {
                return RedirectToAction("Index", "LaptopManagement");
            }
            return View(new LaptopModel().getLaptopById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(laptop model)
        {
            try
            {
                new LaptopModel().Delete(model.id);
                return RedirectToAction("Index", "LaptopManagement");
            }
            catch (Exception ex)
            {
                ViewBag.errorMessage = "Có lỗi xảy ra! Vui lòng thử lại";//ex.ToString();//"Có lỗi xảy ra! Vui lòng thử lại";
                return View(model);
            }
        }
        public ActionResult Edit(string id)
        {
            if (!Check.isLogedIn()) return RedirectToAction("Index", "Login");
            if (id == null)
            {
                return RedirectToAction("Index", "LaptopManagement");
            }
            var laptop = new LaptopModel().getLaptopById(id);
            var spec = new SpecModel().getSpecById(id);
            if (laptop != null && spec != null)
            {
                return View(new LaptopAndSpec()
                {
                    id = laptop.id,
                    brand_id = laptop.brand_id,
                    name = laptop.name,
                    img = laptop.img,
                    memory = spec.memory,
                    graphic_card = spec.graphic_card,
                    hard_drive = spec.hard_drive,
                    resolution = spec.resolution
                });
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LaptopAndSpec model)
        {
            try
            {
                model.img = "";
                new LaptopModel().Update(model.getLaptop());
                new SpecModel().Update(model.getSpec());
                return RedirectToAction("Index", "LaptopManagement");
            } catch (Exception e)
            {
                ViewBag.errorMessage = "Có một số lỗi xảy ra! Vui lòng xử lại!"; //e.Message;// "Có một số lỗi xảy ra! Vui lòng xử lại!";
                return View(model);
            }
        }
        public ActionResult Detail(string id)
        {
            if (!Check.isLogedIn()) return RedirectToAction("Index", "Login");
            if (id == null)
            {
                return RedirectToAction("Index", "LaptopManagement");
            }
            var laptop = new LaptopModel().getLaptopById(id);
            var spec = new SpecModel().getSpecById(id);
            if (laptop != null && spec != null)
            {
                return View(new LaptopAndSpec()
                {
                    id = laptop.id,
                    brand_id = laptop.brand_id,
                    name = laptop.name,
                    img = laptop.img,
                    memory = spec.memory,
                    graphic_card = spec.graphic_card,
                    hard_drive = spec.hard_drive,
                    resolution = spec.resolution
                });
            }
            return View();   
        }
    }
}