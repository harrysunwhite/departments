using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using departments.Models;
using X.PagedList;

namespace departments.Controllers
{
    public class PhongbansController : Controller
    {

        private readonly DepartmentContext _context;

        public PhongbansController(DepartmentContext context)
        {
            _context = context;
        }

        // GET: Phongbans1

        
        public IActionResult Index(int page = 1)
        {
            var listPaged = GetPagedNames(page);
            ViewBag.Names = listPaged;
            return View(listPaged);
        }

        [HttpGet]
       
        public IActionResult AjaxIndex(int page = 1)
        {
            var listPaged = GetPagedNames(page);
            ViewBag.Names = listPaged;
            return PartialView("_NameListPartial");
        }


        public IActionResult GetOnePageOfNames(int page = 1)
        {
            var listPaged = GetPagedNames(page);
            ViewBag.Names = listPaged;
            return PartialView("_NameListPartial", ViewBag.Names);
        }

        protected IPagedList<Phongban> GetPagedNames(int? page)
        {

            if (page.HasValue && page < 1)
                return null;

            // retrieve list from database/whereverand
            var listUnpaged = GetStuffFromDatabase();

            // page the list
            const int pageSize = 3;
            var listPaged = listUnpaged.ToPagedList(page ?? 1, pageSize);

            // return a 404 if user browses to pages beyond last page. special case first page if no items exist
            if (listPaged.PageNumber != 1 && page.HasValue && page > listPaged.PageCount)
                return null;

            return listPaged;
        }

        protected IEnumerable<Phongban> GetStuffFromDatabase()
        {
            return _context.Phongbans;
        }

    }
}
