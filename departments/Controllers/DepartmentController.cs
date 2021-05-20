using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using departments.Models;
using departments.BUS;

namespace departments.Controllers
{
    
    public class DepartmentController : Controller
    {
       
        public IActionResult Index(int page = 1)
        {
            var listPaged = busPhongban.busList(page);
            ViewBag.Names = listPaged;
            return View(listPaged);
        }
        BusPhongban busPhongban = new BusPhongban();
        // GET: DepartmentController
        public ActionResult PageList(int page = 1)
        {
            var listphongban = busPhongban.busList(page);
            ViewBag.Names = listphongban;
            return PartialView("_NameListPartial", ViewBag.Names);
        }

        
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            if (busPhongban.busList(id) == null)
            {
                return NotFound();
            }
            else
                return PartialView("edit", busPhongban.busList(id));
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
