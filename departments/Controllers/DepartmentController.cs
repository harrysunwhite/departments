using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using departments.Models;
using departments.BUS;
using VisioForge.MediaFramework.ONVIF;

namespace departments.Controllers
{
   
    public class DepartmentController : Controller
    {
        BusPhongban busPhongban = new BusPhongban();

        public IActionResult Index(PhongBanSearchModel phongBan)
        {
           
            if (!phongBan.Page.HasValue) phongBan.Page = 1;
            var listPaged = busPhongban.busList(phongBan);
            ViewBag.Names = listPaged;
            ViewBag.Data = phongBan;
            return View(listPaged);
        }
       
        // GET: DepartmentController
        [HttpGet]
        [Route("/PageList/")]
        public ActionResult PageList(PhongBanSearchModel phongBan)
        {
          if  (busPhongban.busList(phongBan).Count()>0)
            {
               
                if (!phongBan.Page.HasValue) phongBan.Page = 1;



                var listphongban = busPhongban.busList(phongBan);
                ViewBag.Names = listphongban;
                ViewBag.Data = phongBan;
                return PartialView("_NameListPartial", ViewBag.Names);
            }
          else
            {
                
                return Json(new { status = -2, title = "", text = "Không tìm thấy phòng ban phù hợp", obj = "" }, new Newtonsoft.Json.JsonSerializerSettings());
            }    
          
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
                return Json(new { status = 1, title = "", text = "Xoá thành công.", obj = "" }, new Newtonsoft.Json.JsonSerializerSettings());
            else
                return Json(new { status = -2, title = "", text = "Xoá không thành công.", obj = "" }, new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}
