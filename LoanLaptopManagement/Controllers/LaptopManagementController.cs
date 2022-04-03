using System;
using System.Collections.Generic;
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
        // GET: Product
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
        public ActionResult Create(LaptopAndSpec model)
        {
            try
            {
                new LaptopModel().Create(model.getLaptop());
                new SpecModel().Create(model.getSpec());
                return RedirectToAction("Index", "LaptopManagement");
            } 
            catch (Exception ex)
            {
                ViewBag.errorMessage = ex.ToString();//"Có lỗi xảy ra!";
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
                ViewBag.errorMessage = ex.ToString();//"Có lỗi xảy ra! Vui lòng thử lại";
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
                new LaptopModel().Update(model.getLaptop());
                new SpecModel().Update(model.getSpec());
                return RedirectToAction("Index", "LaptopManagement");
            } catch
            {
                ViewBag.errorMessage = "Có một số lỗi xảy ra! Vui lòng xử lại!";
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