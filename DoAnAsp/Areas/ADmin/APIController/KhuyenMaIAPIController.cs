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
    public class KhuyenMaIAPIController : ControllerBase
    {
        private readonly DPContext _context;

        public KhuyenMaIAPIController(DPContext context)
        {
            _context = context;
        }

        // GET: api/KhuyenMaIAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhuyenMaiModel>>> GetKhuyenMais()
        {
            return await _context.KhuyenMais.ToListAsync();
        }

        // GET: api/KhuyenMaIAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KhuyenMaiModel>> GetKhuyenMaiModel(int id)
        {
            var khuyenMaiModel = await _context.KhuyenMais.FindAsync(id);

            if (khuyenMaiModel == null)
            {
                return NotFound();
            }

            return khuyenMaiModel;
        }

        // PUT: api/KhuyenMaIAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhuyenMaiModel(int id, KhuyenMaiModel khuyenMaiModel)
        {
            if (id != khuyenMaiModel.MaKM)
            {
                return BadRequest();
            }

            _context.Entry(khuyenMaiModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhuyenMaiModelExists(id))
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

        // POST: api/KhuyenMaIAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<KhuyenMaiModel>> PostKhuyenMaiModel(KhuyenMaiModel khuyenMaiModel)
        {
            _context.KhuyenMais.Add(khuyenMaiModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KhuyenMaiModelExists(khuyenMaiModel.MaKM))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKhuyenMaiModel", new { id = khuyenMaiModel.MaKM }, khuyenMaiModel);
        }

        // DELETE: api/KhuyenMaIAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KhuyenMaiModel>> DeleteKhuyenMaiModel(int id)
        {
            var khuyenMaiModel = await _context.KhuyenMais.FindAsync(id);
            if (khuyenMaiModel == null)
            {
                return NotFound();
            }

            _context.KhuyenMais.Remove(khuyenMaiModel);
            await _context.SaveChangesAsync();

            return khuyenMaiModel;
        }

        private bool KhuyenMaiModelExists(int id)
        {
            return _context.KhuyenMais.Any(e => e.MaKM == id);
        }
    }
}
