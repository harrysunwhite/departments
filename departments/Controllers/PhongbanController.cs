using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using departments.Models;

namespace departments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhongbanController : ControllerBase
    {
        private readonly DepartmentContext _context;

        public PhongbanController(DepartmentContext context)
        {
            _context = context;
        }

        // GET: api/Phongban
       

        // GET: api/Phongban/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Phongban>> GetPhongban(int id)
        {
            var phongban = await _context.Phongbans.FindAsync(id);

            if (phongban == null)
            {
                return NotFound();
            }

            return phongban;
        }

        // PUT: api/Phongban/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> PutPhongban( Phongbanmodel model)
        {

            if (!string.IsNullOrEmpty(model.Id.ToString()))
            {
                var find = await _context.Set<Phongban>().FirstOrDefaultAsync(x => x.Id == model.Id);
                if (find != null)
                {
                    find.Id = model.Id;
                    find.Name = model.Name;

                    _context.Set<Phongban>().Attach(find);
                    await _context.SaveChangesAsync();
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

        // POST: api/Phongban
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Phongban>> PostPhongban(Phongban phongban)
        {


            Phongban pb = new Phongban();
            pb.Name = phongban.Name;
            _context.Add(pb);
            await _context.SaveChangesAsync();
            return Ok("Added");
          
        }

        // DELETE: api/Phongban/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Phongban>> DeletePhongban(int id)
        {
            var phongban = await _context.Phongbans.FindAsync(id);
            if (phongban == null)
            {
                return NotFound();
            }

            _context.Phongbans.Remove(phongban);
            await _context.SaveChangesAsync();

            return phongban;
        }

        private bool PhongbanExists(int id)
        {
            return _context.Phongbans.Any(e => e.Id == id);
        }
    }
}
