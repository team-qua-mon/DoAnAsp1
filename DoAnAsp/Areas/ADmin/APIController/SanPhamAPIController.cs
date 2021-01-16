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
    public class SanPhamAPIController : ControllerBase
    {
        private readonly DPContext _context;

        public SanPhamAPIController(DPContext context)
        {
            _context = context;
        }

        // GET: api/SanPhamAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanPhamModel>>> GetSanPhams()
        {
            return await _context.SanPhams.ToListAsync();
        }

        // GET: api/SanPhamAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SanPhamModel>> GetSanPhamModel(int id)
        {
            var sanPhamModel = await _context.SanPhams.FindAsync(id);

            if (sanPhamModel == null)
            {
                return NotFound();
            }

            return sanPhamModel;
        }

        // PUT: api/SanPhamAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSanPhamModel(int id, SanPhamModel sanPhamModel)
        {
            if (id != sanPhamModel.MaSP)
            {
                return BadRequest();
            }

            _context.Entry(sanPhamModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanPhamModelExists(id))
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

        // POST: api/SanPhamAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SanPhamModel>> PostSanPhamModel(SanPhamModel sanPhamModel)
        {
            _context.SanPhams.Add(sanPhamModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSanPhamModel", new { id = sanPhamModel.MaSP }, sanPhamModel);
        }

        // DELETE: api/SanPhamAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SanPhamModel>> DeleteSanPhamModel(int id)
        {
            var sanPhamModel = await _context.SanPhams.FindAsync(id);
            if (sanPhamModel == null)
            {
                return NotFound();
            }

            _context.SanPhams.Remove(sanPhamModel);
            await _context.SaveChangesAsync();

            return sanPhamModel;
        }

        private bool SanPhamModelExists(int id)
        {
            return _context.SanPhams.Any(e => e.MaSP == id);
        }
    }
}
