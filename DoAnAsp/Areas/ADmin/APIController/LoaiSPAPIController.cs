using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoAnAsp.Areas.ADmin.Data;
using DoAnAsp.Areas.ADmin.Models;

namespace DoAnAsp.Areas.ADmin.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiSPAPIController : ControllerBase
    {
        private readonly DPContext _context;

        public LoaiSPAPIController(DPContext context)
        {
            _context = context;
        }

        // GET: api/LoaiSPAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiSPModelcs>>> GetLoaiSPs()
        {
            return await _context.LoaiSPs.ToListAsync();
        }

        // GET: api/LoaiSPAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoaiSPModelcs>> GetLoaiSPModelcs(int id)
        {
            var loaiSPModelcs = await _context.LoaiSPs.FindAsync(id);

            if (loaiSPModelcs == null)
            {
                return NotFound();
            }

            return loaiSPModelcs;
        }

        // PUT: api/LoaiSPAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoaiSPModelcs(int id, LoaiSPModelcs loaiSPModelcs)
        {
            if (id != loaiSPModelcs.MaLoaiSP)
            {
                return BadRequest();
            }

            _context.Entry(loaiSPModelcs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiSPModelcsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LoaiSPAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LoaiSPModelcs>> PostLoaiSPModelcs(LoaiSPModelcs loaiSPModelcs)
        {
            _context.LoaiSPs.Add(loaiSPModelcs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoaiSPModelcs", new { id = loaiSPModelcs.MaLoaiSP }, loaiSPModelcs);
        }

        // DELETE: api/LoaiSPAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoaiSPModelcs>> DeleteLoaiSPModelcs(int id)
        {
            var loaiSPModelcs = await _context.LoaiSPs.FindAsync(id);
            if (loaiSPModelcs == null)
            {
                return NotFound();
            }

            _context.LoaiSPs.Remove(loaiSPModelcs);
            await _context.SaveChangesAsync();

            return loaiSPModelcs;
        }

        private bool LoaiSPModelcsExists(int id)
        {
            return _context.LoaiSPs.Any(e => e.MaLoaiSP == id);
        }
    }
}
