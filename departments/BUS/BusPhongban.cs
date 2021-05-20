using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using departments.Models;
using X.PagedList;

namespace departments.BUS
{
    public class BusPhongban : Controller
    {

        private readonly DepartmentContext _context;
        public BusPhongban()
        {
            
        }
        public BusPhongban(DepartmentContext context)
        {
            _context = context;
        }
        // GET: BusPhongban
        public IPagedList<Phongban>  busList(int page)
        {
            return GetPagedNames(page);
           
           
        }

        
      

       
        public ActionResult busAdd(Phongban phongban)
        {
            Phongban pb = new Phongban();
            pb.Name = phongban.Name;
            _context.Add(pb);
            _context.SaveChangesAsync();
            return Ok("Added");
        }

        public Phongban GetPhong(int id)
        {
            var phongban = _context.Phongbans.Find(id);

            if (phongban == null)
            {
                return null;
            }

            return phongban;
        }

        public IActionResult  busUpdate(int id, Phongban model )
        {
            if (!string.IsNullOrEmpty(model.Id.ToString()))
            {
                var find =  _context.Set<Phongban>().FirstOrDefault(x => x.Id == model.Id);
                if (find != null)
                {
                    find.Id = model.Id;
                    find.Name = model.Name;

                    _context.Set<Phongban>().Attach(find);
                    _context.SaveChangesAsync();
                    return Ok("Saved");
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }

       public IActionResult busDelete(int Id)
        {
            var phongban = _context.Phongbans.Find(Id);
            if (phongban == null)
            {
                return NotFound();
            }

            _context.Phongbans.Remove(phongban);
            _context.SaveChanges();

            return Ok("Xoá thành công");
        }

        public IPagedList<Phongban>  GetOnePageOfNames(int page = 1)
        {
            return GetPagedNames(page);
           
        }

        protected IPagedList<Phongban> GetPagedNames(int? page)
        {

            if (page.HasValue && page < 1)
                return null;

         
            var listUnpaged = GetStuffFromDatabase();

     
            const int pageSize = 3;
            var listPaged = listUnpaged.ToPagedList(page ?? 1, pageSize);

           
            if (listPaged.PageNumber != 1 && page.HasValue && page > listPaged.PageCount)
                return null;

            return listPaged;
        }

        protected IEnumerable<Phongban> GetStuffFromDatabase()
        {
            List<Phongban> data = new List<Phongban>();
            using (var dataContext = new DepartmentContext())
            {
                data = dataContext.Phongbans.ToList();
                
            }
            return data;
            
        }
    }
}
