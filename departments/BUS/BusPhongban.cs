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

        
        public BusPhongban()
        {
            
        }
       
        // GET: BusPhongban
        public IPagedList<Phongban>  busList(int page)
        {
            return GetPagedNames(page);
           
           
        }

        
      private static  int pageSize = 3;


        public bool busAdd(Phongban phongban)
        {
            try
            {
                using (var _context = new DepartmentContext())
                {
                    Phongban pb = new Phongban();
                    pb.Name = phongban.Name;
                    _context.Add(pb);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
                
            }
            

          
           
        }

        public Phongban GetPhong(int id)
        {
            using (var _context = new DepartmentContext())
            {
                var phongban = _context.Phongbans.Find(id);

                if (phongban == null)
                {
                    return null;
                }

                return phongban;
            }

              
        }

        public bool  busUpdate(Phongban model )
        {
            try
            {
                using (var _context = new DepartmentContext())
                {
                    var find = _context.Set<Phongban>().FirstOrDefault(x => x.Id == model.Id);
                    if (find != null)
                    {
                        find.Id = model.Id;
                        find.Name = model.Name;

                        _context.Set<Phongban>().Attach(find);
                        _context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }    
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
                  
              
            
           
        }

       public bool busDelete(int Id)
        {
            try
            {
                using (var _context = new DepartmentContext())
                {
                    var phongban = _context.Phongbans.Find(Id);
                   

                    _context.Phongbans.Remove(phongban);
                    _context.SaveChanges();

                    return true;

                }
            }   
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            
         
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

     
           
            var listPaged = listUnpaged.ToPagedList(page ?? 1, pageSize);

           
            if (listPaged.PageNumber != 1 && page.HasValue && page > listPaged.PageCount)
                return null;

            return listPaged;
        }
        protected IPagedList<Phongban> busSearchListPb(PhongBanSearchModel model)
        {

            IEnumerable<Phongban> listUnpaged;
            using (var dataContext = new DepartmentContext())
            {
                 
                if (string.IsNullOrWhiteSpace(model.Name))
                {
                    listUnpaged = GetStuffFromDatabase();
                }    
                else
                {
                    listUnpaged = GetStuffFromDatabase().Where(x => x.Name.Contains(model.Name));
                }

                if (model.Page.HasValue && model.Page < 1)
                    return null;


               



                var listPaged = listUnpaged.ToPagedList(model.Page ?? 1, pageSize);


                if (listPaged.PageNumber != 1 && model.Page.HasValue && model.Page > listPaged.PageCount)
                    return null;

                return listPaged;

            }


           
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
