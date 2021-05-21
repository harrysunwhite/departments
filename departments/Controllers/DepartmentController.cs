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

        [HttpGet]
        [Route("/PageList/")]
        public ActionResult PageList(int page = 1)
        {
            
            var listphongban = busPhongban.busList(page);
            ViewBag.Names = listphongban;
            return PartialView("_NameListPartial", ViewBag.Names);
        }
        [Route("/_thempb/")]
        public IActionResult Thempb()
        {
          
            
            return PartialView("_partialThempb");

        }
        [HttpPost]
        
       

        public IActionResult ThemPB(Phongban pb)
        {
            
                if (busPhongban.busAdd(pb))
               return Json(new { status = 1, title = "", text = "Thêm thành công.", obj = "" }, new Newtonsoft.Json.JsonSerializerSettings());
            else
               return Json(new { status = -2, title = "", text = "Thêm không thành công.", obj = "" }, new Newtonsoft.Json.JsonSerializerSettings());
        }

        
       

       

        
        [HttpGet]
        [Route("/_EditDeparment/")]
        public ActionResult _EditDeparment(int id)
        {
            if (busPhongban.GetPhong(id) == null)
            {
                return NotFound();
            }
            else
                return PartialView("_partialedit", busPhongban.GetPhong(id));
        }

       
        [HttpPost]
       
        public ActionResult UpdatePb(Phongban pb)
        {
           
            if (busPhongban.busUpdate(pb))
                return Json(new { status = 1, title = "", text = "Cập nhật thành công.", obj = "" }, new Newtonsoft.Json.JsonSerializerSettings());
            else
                return Json(new { status = -2, title = "", text = "Cập nhật không thành công.", obj = "" }, new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPost]

        public ActionResult DeletePb(int id)
        {
            if (busPhongban.busDelete(id)) 
                return Json(new { status = 1, title = "", text = "Cập nhật thành công.", obj = "" }, new Newtonsoft.Json.JsonSerializerSettings());
            else
                return Json(new { status = -2, title = "", text = "Cập nhật không thành công.", obj = "" }, new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}
