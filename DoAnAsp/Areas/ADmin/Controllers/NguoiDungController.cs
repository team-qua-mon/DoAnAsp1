using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnAsp.Areas.ADmin.Data;
using DoAnAsp.Areas.ADmin.Models;

namespace DoAnAsp.Areas.ADmin.Controllers
{
    [Area("ADmin")]
    public class NguoiDungController : Controller
    {
        private readonly DPContext _context;

        public NguoiDungController(DPContext context)
        {
            _context = context;
        }

        // GET: ADmin/NguoiDung
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.NguoiDungs.Include(n => n.PhanQuyens);
            return View(await dPContext.ToListAsync());
        }

        // GET: ADmin/NguoiDung/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDungModel = await _context.NguoiDungs
                .Include(n => n.PhanQuyens)
                .FirstOrDefaultAsync(m => m.MaND == id);
            if (nguoiDungModel == null)
            {
                return NotFound();
            }

            return View(nguoiDungModel);
        }

        // GET: ADmin/NguoiDung/Create
        public IActionResult Create()
        {
            ViewData["MAQuyen"] = new SelectList(_context.PhanQuyens, "MAQuyen", "TenQuyen");
            return View();
        }

        // POST: ADmin/NguoiDung/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaND,Ho,TenLot,TenND,GioiTinh,HinhAnh,SDT,Andress,UserName,PassWord,TrangThai,MAQuyen")] NguoiDungModel nguoiDungModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nguoiDungModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MAQuyen"] = new SelectList(_context.PhanQuyens, "MAQuyen", "TenQuyen", nguoiDungModel.MAQuyen);
            return View(nguoiDungModel);
        }

        // GET: ADmin/NguoiDung/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDungModel = await _context.NguoiDungs.FindAsync(id);
            if (nguoiDungModel == null)
            {
                return NotFound();
            }
            ViewData["MAQuyen"] = new SelectList(_context.PhanQuyens, "MAQuyen", "TenQuyen", nguoiDungModel.MAQuyen);
            return View(nguoiDungModel);
        }

        // POST: ADmin/NguoiDung/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaND,Ho,TenLot,TenND,GioiTinh,HinhAnh,SDT,Andress,UserName,PassWord,TrangThai,MAQuyen")] NguoiDungModel nguoiDungModel)
        {
            if (id != nguoiDungModel.MaND)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nguoiDungModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguoiDungModelExists(nguoiDungModel.MaND))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MAQuyen"] = new SelectList(_context.PhanQuyens, "MAQuyen", "TenQuyen", nguoiDungModel.MAQuyen);
            return View(nguoiDungModel);
        }

        // GET: ADmin/NguoiDung/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDungModel = await _context.NguoiDungs
                .Include(n => n.PhanQuyens)
                .FirstOrDefaultAsync(m => m.MaND == id);
            if (nguoiDungModel == null)
            {
                return NotFound();
            }

            return View(nguoiDungModel);
        }

        // POST: ADmin/NguoiDung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nguoiDungModel = await _context.NguoiDungs.FindAsync(id);
            _context.NguoiDungs.Remove(nguoiDungModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NguoiDungModelExists(int id)
        {
            return _context.NguoiDungs.Any(e => e.MaND == id);
        }
    }
}
