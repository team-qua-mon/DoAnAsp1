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
    public class NguoiDungAPIController : ControllerBase
    {
        private readonly DPContext _context;

        public NguoiDungAPIController(DPContext context)
        {
            _context = context;
        }

        // GET: api/NguoiDungAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NguoiDungModel>>> GetNguoiDungs()
        {
            return await _context.NguoiDungs.ToListAsync();
        }

        // GET: api/NguoiDungAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NguoiDungModel>> GetNguoiDungModel(int id)
        {
            var nguoiDungModel = await _context.NguoiDungs.FindAsync(id);

            if (nguoiDungModel == null)
            {
                return NotFound();
            }

            return nguoiDungModel;
        }

        // PUT: api/NguoiDungAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNguoiDungModel(int id, NguoiDungModel nguoiDungModel)
        {
            if (id != nguoiDungModel.MaND)
            {
                return BadRequest();
            }

            _context.Entry(nguoiDungModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguoiDungModelExists(id))
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

        // POST: api/NguoiDungAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NguoiDungModel>> PostNguoiDungModel(NguoiDungModel nguoiDungModel)
        {
            _context.NguoiDungs.Add(nguoiDungModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNguoiDungModel", new { id = nguoiDungModel.MaND }, nguoiDungModel);
        }

        // DELETE: api/NguoiDungAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NguoiDungModel>> DeleteNguoiDungModel(int id)
        {
            var nguoiDungModel = await _context.NguoiDungs.FindAsync(id);
            if (nguoiDungModel == null)
            {
                return NotFound();
            }

            _context.NguoiDungs.Remove(nguoiDungModel);
            await _context.SaveChangesAsync();

            return nguoiDungModel;
        }

        private bool NguoiDungModelExists(int id)
        {
            return _context.NguoiDungs.Any(e => e.MaND == id);
        }
    }
}
